using AutoMapper;
using eBus.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBus.WebApi.Mappers
{
    public class Mapper : Profile
    {

        public Mapper()
        {
           

            CreateMap<Database.Korisnici, Model.Korisnici>();
            CreateMap<KorisniciUpsertRequest, Database.Korisnici>();
            CreateMap<Database.Putnik, Model.Korisnici>();

            CreateMap<Database.Drzava, Model.Drzava>();
            CreateMap<DrzavaUpsertRequest, Database.Drzava>();

            CreateMap<Database.Grad, Model.Grad>();
            CreateMap<GradUpsertRequest, Database.Grad>();

            CreateMap<Database.KorisniciUloge, Model.KorisniciUloge>();
            

            CreateMap<Database.Uloga, Model.Uloga>();

            CreateMap<Database.Cijena, Model.Cijena>();
            CreateMap<CijenaUpsertRequest, Database.Cijena>();

            CreateMap<Database.Kompanija, Model.Kompanija>();
            CreateMap<KompanijaUpsertRequest, Database.Kompanija>();

            CreateMap<Database.Karta, Model.Karta>();
            CreateMap<KartaUpsertRequest, Database.Karta>();

            CreateMap<Database.Linija, Model.Linija>();
            CreateMap<LinijaUpsertRequest, Database.Linija>();
            CreateMap<Database.Linija, Model.LinijaPodaci>(); // zadnje dodano

            CreateMap<Database.Notifikacije, Model.Notifikacije>();
            CreateMap<NotifikacijaUpsertRequest, Database.Notifikacije>();

            CreateMap<Database.Novosti, Model.Novosti>();
            CreateMap<NovostiUpsertRequest, Database.Novosti>();

            CreateMap<Database.Ocjena, Model.Ocjena>();
            CreateMap<OcjenaUpsertRequest, Database.Ocjena>();

            CreateMap<Database.Putnik, Model.Putnik>();
            CreateMap<PutnikUpsertRequest, Database.Putnik>();

            CreateMap<Database.Rezervacija, Model.Rezervacija>();
            CreateMap<RezervacijaUpsertRequest, Database.Rezervacija>();

            CreateMap<Database.Sjediste, Model.Sjediste>();
            CreateMap<SjedisteUpsertRequest, Database.Sjediste>();

            CreateMap<Database.Vozilo, Model.Vozilo>();
            CreateMap<VoziloUpsertRequest, Database.Vozilo>();

            CreateMap<Database.Angazuje, Model.Angazuje>();
            CreateMap<AngazujeUpsertRequest, Database.Angazuje>();

            CreateMap<Database.PutnikNotifikacije, Model.PutnikNotifikacije>();
            CreateMap<PutnikNotifikacijeUpsertRequest, Database.PutnikNotifikacije>();
        }
    }
}
