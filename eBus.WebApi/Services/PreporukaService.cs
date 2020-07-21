using AutoMapper;
using eBus.Model;
using eBus.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace eBus.WebApi.Services
{
    public class PreporukaService : IPreporukaService
    {

        private readonly _170048Context _context;
        private readonly IMapper _mapper;

        private int PreporucenBroj = 2;

        public PreporukaService(_170048Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<LinijaPodaci> GetPreporuka(int id)
        {

            List<LinijaPodaci> ListaLinija = new List<LinijaPodaci>();

        //pronadjemo putnika koji je logovan
          Database.Putnik putnik = _context.Putnik.Find(id);

            if(putnik != null)
            {

                var korisnikoveRezervacije = _context.Rezervacija.Where(l => l.PutnikId == putnik.Id).ToList();

                Dictionary<int, int> Angazman = new Dictionary<int, int>();

              

                var listaOdredista = new List<int>();
                var listaPolazista = new List<int>();
                var listaVremenaPolaska = new List<TimeSpan>();

                foreach (var item in korisnikoveRezervacije)
                {
                    var dkarta = _context.Karta.Include(x => x.Angazuje).Where(l => l.Id == item.KartaId).FirstOrDefault();

                    var mkarta = _mapper.Map<Model.Karta>(dkarta);

                    var linija = _context.Linija.Where(l => l.Id == mkarta.Angazuje.LinijaId).FirstOrDefault();

                    // zabiljezimo sva odredista i polazista iz karata koje je putnik rezervisao
                    // radi kasnije provjere
                    listaOdredista.Add(linija.OdredisteId);
                    listaPolazista.Add(linija.PolazisteId);

                    listaVremenaPolaska.Add(item.Karta.VrijemePolaska);

                }

               
                Dictionary<TimeSpan, int> VrijemePolaska = new Dictionary<TimeSpan, int>();
                foreach (var item in listaVremenaPolaska)
                {

                    int brojac23 = 0;

                    foreach (var item2 in listaVremenaPolaska)
                    {
                        if (item == item2)
                            brojac23++;
                    }

                    if (brojac23 >= PreporucenBroj)
                    {
                        if (!VrijemePolaska.ContainsKey(item))
                        {
                            VrijemePolaska.Add(item, brojac23);
                        }
                    }
                }

           

                var listaAngazmana = _context.Angazuje.ToList();

                foreach (var item in listaAngazmana)
                {
                    var brojacRez = 0;
                                                                            
                    for (int i = 0; i < listaOdredista.Count; i++)
                    {
                        // kako mora biti isti broj odredista i polazista nije bitno koju listu izmemo za petlji
                        // poredimo koliko puta se pojavljuju spremljeni polaziste i odrediste u angazmanu

                        var dlinija = _context.Linija.Find(item.LinijaId);
                        var mlinija = _mapper.Map<Model.Linija>(dlinija);
                        if (mlinija.OdredisteId == listaOdredista[i] && mlinija.PolazisteId == listaPolazista[i]
                            && item.DatumIsteka.Date > DateTime.Now.Date)
                        {
                            brojacRez++;


                        }


                    }

                    if (brojacRez >= PreporucenBroj)
                    {
                        if (!Angazman.ContainsKey(item.Id))
                        {
                            //spasimo angazman tj njegova id za svaki koji ima veci od dva ponavljanja
                            Angazman.Add(item.Id, brojacRez);
                        }
                    }
                }


                // prolazimo petljom kroz spremljene angazmane koji su ispunili prethodni uslov
                foreach (var item in Angazman)
                {
                    var angazuje1 = _context.Angazuje.Include(l => l.Vozilo).Where(k => k.Id == item.Key).FirstOrDefault();

                    var angazuje = _mapper.Map<Model.Angazuje>(angazuje1);

                  

                    var cijena = _context.Cijena.Where(l => l.LinijaId == angazuje.LinijaId && l.KompanijaId == angazuje.Vozilo.KompanijaId).ToList();

                

                    var linija = _context.Linija.Find(angazuje.LinijaId);

                    

                    var polaz = _context.Grad.Find(linija.PolazisteId);
                    var odred = _context.Grad.Find(linija.OdredisteId);

                 

                    var karta = _context.Karta.Where(l => l.AngazujeId == item.Key).ToList();

                    Dictionary<DateTime, int> DatumKarte = new Dictionary<DateTime, int>();
                    // prolazimo kroz listu karata u odnosu na angazujeID
                    foreach (var item2 in karta.OrderByDescending(l => l.DatumIzdavanja))
                    {

                        // pronadjemo svaku prvu kartu gdje je i datum izdavanja veci od danasnjeg datuma
                        // isto tako da datum izdavanja ne prelazi vise od pet dana radi obimnosti
                        // jer prikazuje sve kompanije i njihova vremena
                        if (item2.DatumIzdavanja.Date > DateTime.Now.Date
                            && item2.DatumIzdavanja.Date <= DateTime.Now.AddDays(5))
                        {
                            /*item2.Sjediste.red == 1 && item2.Sjediste.kolona == 1*/


                            foreach (var item3 in VrijemePolaska) // sa ovim ovdje mi prikazuje koje sam destinacije najvise rezervisao po vremenima
                            {
                                if (item2.VrijemePolaska == item3.Key) // npr ako sam u 7 najvise rezervisao prikazuje mi samo ta vremena
                                {
                                    if (!DatumKarte.ContainsKey(item2.DatumIzdavanja))
                                    {
                                        DatumKarte.Add(item2.DatumIzdavanja, 1);

                                        ListaLinija.Add(new LinijaPodaci()
                                        {
                                            AngazujeID = angazuje.Id,
                                            DatumPretrage = item2.DatumIzdavanja.Date,
                                            VoziloID = angazuje.VoziloId,
                                            Cijena = cijena[0].Iznos,
                                            Kompanija = angazuje.Vozilo.Model,
                                            OdredisteNaziv = odred.Naziv,
                                            PolazisteNaziv = polaz.Naziv,
                                            VrijemePolaska = item2.VrijemePolaska
                                        });
                                    }
                                }
                            }

                        }

                    }

                    return ListaLinija;

                }
            }


            return ListaLinija;
        }
    }
}
