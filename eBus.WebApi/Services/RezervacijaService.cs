using AutoMapper;
using eBus.Model;
using eBus.Model.Requests;
using eBus.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eBus.WebApi.Services
{
    public class RezervacijaService : BaseCRUDService<Model.Rezervacija, RezervacijaSearchRequest, Database.Rezervacija, RezervacijaUpsertRequest, RezervacijaUpsertRequest>
    {
        public RezervacijaService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Rezervacija> Get(RezervacijaSearchRequest search)
        {
            var query = _context.Rezervacija
                                            .Include(l => l.Karta.Angazuje) // ovo Angazuje dodao
                                            .Include(l => l.Putnik).AsQueryable();

            if(search != null)
            {
                if (search.PoAngazmanu)
                {
                    query = query.Where(l => l.Karta.AngazujeId == search.AngazmanId);
                }
                else
                {
                    if (search.PutnikId.HasValue)
                    {
                        query = query.Where(l => l.PutnikId == search.PutnikId.Value);
                    }
                }
               
            }


            var lista = query.OrderByDescending(l => l.DatumKreiranja).ToList();

            return _mapper.Map<List<Model.Rezervacija>>(lista);
        }

        public override Model.Rezervacija Insert(RezervacijaUpsertRequest request)
        {
            var entitet = _mapper.Map<Database.Rezervacija>(request);

           

            if(entitet == null)
            {
                throw new Exception("Greska kod rezervacije");
            }
            var putnik = _mapper.Map<Model.Putnik>(_context.Putnik.FirstOrDefault(l => l.Id == entitet.PutnikId));
            var karta = _mapper.Map<Model.Karta>(_context.Karta.Include(k => k.Sjediste.Vozilo)
                                                                .Include(a => a.Angazuje.Linija)
                                                                .FirstOrDefault(l => l.Id == entitet.KartaId));
            var cijena = _context.Cijena.FirstOrDefault(l => l.KompanijaId == karta.Angazuje.Vozilo.KompanijaId && l.LinijaId == karta.Angazuje.LinijaId);


            var dodatak = $"Ime i prezime :{putnik.Ime} {putnik.Prezime} \n -> Informacije o karti {karta.BrojKarte}:{karta.Sjediste.Pozicija} : {karta.DatumIzdavanja.ToString("dd.MM.yyyy")} \n " + $" { karta.VrijemePolaska } \n\n"+
                $"-> Podaci o angazmanu {karta.Angazuje.PodaciAngazovani} \n\n" +
                $"Cijena  : { Math.Round(cijena.Iznos, 2)} KM \n" 
                + $"Cijena sa popustom : { Math.Round( request.CijenaSaPopustom,2)} KM";

            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(dodatak, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);

            Bitmap qrCodeImage = code.GetGraphic(10);
            var bitmapBytes = BitmapToBytes(qrCodeImage);
            entitet.Qrcode = bitmapBytes;

            _context.Rezervacija.Add(entitet);
            _context.SaveChanges();

            return _mapper.Map<Model.Rezervacija>(entitet);
        }
        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public override Model.Rezervacija GetById(int id)
        {
            var query = _context.Rezervacija.Include(l => l.Karta.Angazuje).Include(t => t.Karta.Sjediste).Where(r => r.Id == id).FirstOrDefault();

            return _mapper.Map<Model.Rezervacija>(query);
        }
    }
}
