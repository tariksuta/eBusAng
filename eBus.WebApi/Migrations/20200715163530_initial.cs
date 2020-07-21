﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eBus.WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(maxLength: 50, nullable: false),
                    KorisnickoIme = table.Column<string>(maxLength: 50, nullable: false),
                    LozinkaHash = table.Column<string>(nullable: false),
                    LozinkaSalt = table.Column<string>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Putnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(maxLength: 50, nullable: false),
                    KorisnickoIme = table.Column<string>(maxLength: 50, nullable: false),
                    LozinkaHash = table.Column<string>(nullable: false),
                    LozinkaSalt = table.Column<string>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    DatumRegistracije = table.Column<DateTime>(type: "datetime", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Putnik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloga", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    DrzavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Novosti",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(maxLength: 100, nullable: false),
                    Sadrzaj = table.Column<string>(type: "text", nullable: false),
                    DatumObjave = table.Column<DateTime>(type: "datetime", nullable: true),
                    KorisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novosti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Novosti_Korisnici",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisniciUloge",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(nullable: false),
                    UlogaID = table.Column<int>(nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciUloge", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Korisnik",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Uloga",
                        column: x => x.UlogaID,
                        principalTable: "Uloga",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kompanija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    KontaktBroj = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Adresa = table.Column<string>(maxLength: 50, nullable: true),
                    GradID = table.Column<int>(nullable: true),
                    LokacijaSlike = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompanija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kompanija_Grad",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Linija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    PolazisteID = table.Column<int>(nullable: false),
                    OdredisteID = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Linija_Korisnici",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Linija_Grad1",
                        column: x => x.OdredisteID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Linija_Grad",
                        column: x => x.PolazisteID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifikacije",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(maxLength: 50, nullable: false),
                    DatumSlanja = table.Column<DateTime>(type: "datetime", nullable: true),
                    NovostID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifikacije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notifikacije_Novosti",
                        column: x => x.NovostID,
                        principalTable: "Novosti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PutnikID = table.Column<int>(nullable: false),
                    KompanijaID = table.Column<int>(nullable: false),
                    OcjenaUsluge = table.Column<int>(nullable: false),
                    Komentar = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ocjena_Kompanija",
                        column: x => x.KompanijaID,
                        principalTable: "Kompanija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ocjena_Putnik",
                        column: x => x.PutnikID,
                        principalTable: "Putnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vozilo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Proizvodjac = table.Column<string>(maxLength: 50, nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: false),
                    Registracija = table.Column<string>(maxLength: 10, nullable: false),
                    BrojSjedista = table.Column<int>(nullable: false),
                    KompanijaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vozilo_Kompanija",
                        column: x => x.KompanijaID,
                        principalTable: "Kompanija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cijena",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinijaID = table.Column<int>(nullable: false),
                    Iznos = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    Popust = table.Column<float>(nullable: true),
                    KompanijaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cijena", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cijena_Kompanija",
                        column: x => x.KompanijaID,
                        principalTable: "Kompanija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cijena_Linija",
                        column: x => x.LinijaID,
                        principalTable: "Linija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PutnikNotifikacije",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotifikacijaID = table.Column<int>(nullable: false),
                    PutnikID = table.Column<int>(nullable: false),
                    Pregledana = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PutnikNotifikacije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PutnikNotifikacija_notif",
                        column: x => x.NotifikacijaID,
                        principalTable: "Notifikacije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PutnikNOtifikaicja_putnik",
                        column: x => x.PutnikID,
                        principalTable: "Putnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Angazuje",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoziloID = table.Column<int>(nullable: false),
                    LinijaID = table.Column<int>(nullable: false),
                    DatumAngazovanja = table.Column<DateTime>(type: "datetime", nullable: false),
                    DatumIsteka = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angazuje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Angazuje_Linija",
                        column: x => x.LinijaID,
                        principalTable: "Linija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Anagazuje_Vozilo",
                        column: x => x.VoziloID,
                        principalTable: "Vozilo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sjediste",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Red = table.Column<int>(nullable: false),
                    Kolona = table.Column<int>(nullable: false),
                    VoziloID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sjediste", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sjediste_Vozilo",
                        column: x => x.VoziloID,
                        principalTable: "Vozilo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Karta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojKarte = table.Column<string>(maxLength: 20, nullable: false),
                    DatumIzdavanja = table.Column<DateTime>(type: "datetime", nullable: false),
                    SjedisteID = table.Column<int>(nullable: false),
                    AngazujeID = table.Column<int>(nullable: false),
                    VrijemePolaska = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    VrijemeDolaska = table.Column<TimeSpan>(type: "time(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Karta_angazuje",
                        column: x => x.AngazujeID,
                        principalTable: "Angazuje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Karta_Sjediste",
                        column: x => x.SjedisteID,
                        principalTable: "Sjediste",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime", nullable: false),
                    DatumIsteka = table.Column<DateTime>(type: "datetime", nullable: false),
                    Otkazana = table.Column<bool>(nullable: true),
                    PutnikID = table.Column<int>(nullable: false),
                    KartaID = table.Column<int>(nullable: false),
                    QRcode = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Karta",
                        column: x => x.KartaID,
                        principalTable: "Karta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Putnik",
                        column: x => x.PutnikID,
                        principalTable: "Putnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Drzava",
                columns: new[] { "ID", "Naziv" },
                values: new object[] { 1, "Bosna i Hercegovina" });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "ID", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Slika", "Status" },
                values: new object[,]
                {
                    { 1, "desktop@mail.com", "Desktop", "desktop", "9gCslij6VP1OyRiqNFEBoHKkdtM=", "yZdkc3BmvECxX+waaC86Ig==", "Test", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 1, 100, 0, 0, 1, 144, 8, 3, 0, 0, 0, 174, 198, 234, 29, 0, 0, 1, 221, 80, 76, 84, 69, 0, 0, 0, 246, 110, 89, 210, 108, 88, 189, 107, 90, 249, 110, 88, 235, 115, 94, 249, 110, 88, 249, 110, 88, 249, 110, 88, 249, 110, 88, 249, 110, 88, 137, 107, 94, 193, 166, 133, 249, 110, 88, 249, 110, 88, 249, 110, 88, 249, 110, 88, 136, 106, 95, 74, 105, 120, 131, 103, 97, 58, 105, 123, 249, 110, 88, 249, 110, 88, 249, 110, 88, 249, 110, 88, 126, 98, 87, 126, 96, 81, 249, 110, 88, 122, 98, 90, 80, 105, 119, 249, 110, 88, 117, 90, 75, 126, 97, 81, 125, 98, 86, 126, 97, 81, 126, 103, 100, 171, 138, 122, 97, 106, 116, 107, 106, 114, 114, 106, 113, 184, 160, 133, 177, 154, 130, 204, 177, 142, 130, 100, 84, 130, 100, 84, 172, 144, 126, 168, 139, 122, 170, 139, 122, 130, 100, 84, 174, 149, 128, 89, 105, 117, 172, 144, 125, 173, 142, 125, 249, 110, 88, 36, 104, 127, 249, 206, 155, 130, 100, 84, 32, 93, 114, 237, 194, 148, 213, 174, 133, 210, 173, 135, 192, 158, 124, 29, 181, 203, 243, 242, 242, 117, 90, 75, 70, 71, 71, 224, 185, 139, 218, 217, 217, 255, 255, 255, 244, 202, 152, 207, 170, 132, 49, 109, 129, 202, 166, 129, 197, 161, 126, 232, 234, 235, 30, 165, 187, 125, 96, 81, 119, 91, 76, 73, 119, 128, 247, 203, 153, 217, 179, 138, 239, 224, 209, 128, 98, 83, 235, 193, 147, 122, 94, 79, 228, 188, 144, 221, 182, 139, 96, 200, 215, 215, 177, 136, 207, 198, 188, 232, 109, 89, 239, 198, 151, 232, 192, 145, 35, 101, 123, 33, 96, 118, 163, 103, 93, 225, 155, 120, 183, 105, 94, 174, 142, 113, 162, 133, 107, 218, 108, 90, 246, 121, 96, 137, 105, 87, 33, 137, 159, 211, 172, 132, 240, 215, 188, 185, 152, 120, 32, 144, 166, 146, 115, 93, 37, 110, 132, 233, 133, 105, 240, 184, 140, 201, 108, 94, 120, 103, 108, 151, 123, 101, 144, 105, 104, 97, 99, 106, 243, 240, 237, 203, 153, 119, 214, 145, 113, 54, 95, 111, 87, 83, 79, 75, 97, 110, 249, 165, 126, 199, 211, 216, 186, 202, 208, 29, 174, 196, 239, 203, 165, 197, 103, 84, 34, 123, 146, 249, 191, 145, 218, 168, 130, 101, 106, 115, 222, 228, 230, 169, 191, 198, 150, 178, 187, 129, 166, 179, 243, 233, 224, 75, 75, 73, 80, 132, 150, 249, 138, 108, 209, 219, 223, 65, 122, 141, 111, 154, 168, 93, 140, 157, 130, 113, 99, 100, 94, 85, 194, 131, 106, 138, 92, 78, 216, 189, 161, 113, 103, 91, 104, 78, 74, 138, 193, 204, 125, 184, 196, 192, 183, 182, 252, 250, 248, 188, 159, 157, 63, 156, 174, 136, 163, 172, 127, 1, 205, 204, 0, 0, 0, 53, 116, 82, 78, 83, 0, 253, 4, 11, 242, 17, 68, 30, 167, 138, 48, 46, 254, 88, 121, 194, 204, 29, 253, 74, 253, 227, 183, 151, 104, 93, 182, 216, 145, 239, 236, 232, 205, 129, 162, 114, 85, 214, 192, 171, 244, 235, 253, 243, 232, 159, 140, 110, 222, 219, 227, 184, 132, 9, 109, 52, 73, 0, 0, 26, 222, 73, 68, 65, 84, 120, 218, 236, 217, 189, 142, 180, 32, 24, 5, 96, 50, 150, 84, 198, 10, 66, 194, 143, 165, 22, 150, 167, 228, 2, 164, 49, 222, 255, 181, 124, 126, 179, 187, 226, 174, 113, 150, 56, 144, 108, 128, 167, 157, 132, 226, 4, 15, 47, 12, 249, 91, 56, 35, 85, 98, 13, 160, 58, 82, 37, 213, 97, 195, 41, 169, 18, 210, 120, 50, 53, 230, 132, 56, 54, 117, 55, 167, 165, 176, 83, 236, 65, 170, 20, 70, 28, 140, 186, 37, 85, 124, 248, 129, 215, 237, 28, 93, 131, 147, 193, 212, 145, 46, 93, 200, 222, 104, 186, 186, 159, 35, 194, 133, 193, 176, 218, 207, 177, 224, 133, 73, 116, 53, 232, 24, 70, 188, 54, 153, 158, 214, 234, 120, 147, 66, 0, 101, 116, 215, 214, 168, 111, 227, 8, 54, 113, 163, 89, 71, 105, 67, 170, 51, 42, 174, 119, 161, 192, 13, 227, 52, 41, 165, 248, 198, 232, 158, 213, 212, 55, 108, 0, 191, 204, 129, 225, 93, 203, 106, 37, 23, 93, 217, 73, 107, 108, 84, 123, 181, 203, 241, 190, 217, 217, 141, 18, 229, 94, 98, 4, 158, 166, 139, 148, 31, 3, 34, 88, 237, 147, 20, 101, 62, 229, 233, 189, 71, 233, 213, 201, 23, 195, 226, 236, 7, 213, 151, 215, 27, 29, 118, 67, 119, 170, 10, 166, 133, 81, 136, 99, 182, 159, 164, 46, 44, 230, 102, 196, 1, 59, 254, 194, 184, 180, 255, 57, 68, 178, 184, 66, 99, 214, 248, 102, 31, 229, 90, 33, 237, 151, 5, 177, 172, 246, 139, 44, 232, 47, 240, 211, 169, 198, 91, 178, 105, 132, 179, 222, 140, 104, 102, 187, 83, 197, 28, 129, 12, 63, 77, 148, 16, 42, 237, 209, 10, 47, 94, 101, 88, 167, 11, 185, 135, 27, 156, 12, 61, 243, 65, 68, 236, 11, 127, 51, 217, 169, 50, 158, 240, 212, 229, 213, 225, 104, 70, 76, 135, 148, 101, 17, 183, 147, 225, 197, 55, 237, 57, 164, 74, 217, 106, 146, 63, 92, 152, 19, 245, 197, 121, 117, 147, 127, 49, 15, 175, 14, 40, 111, 69, 186, 148, 121, 246, 41, 79, 8, 219, 203, 75, 202, 148, 115, 191, 152, 240, 176, 230, 180, 43, 234, 94, 190, 173, 71, 96, 202, 75, 202, 148, 13, 201, 26, 5, 16, 84, 203, 14, 177, 173, 214, 19, 36, 107, 42, 52, 229, 53, 105, 202, 121, 191, 100, 48, 132, 166, 60, 35, 182, 195, 234, 46, 239, 135, 12, 21, 156, 242, 130, 104, 206, 171, 203, 172, 71, 12, 26, 252, 77, 187, 122, 248, 221, 69, 101, 64, 16, 62, 229, 90, 203, 183, 50, 254, 173, 108, 23, 151, 48, 229, 34, 10, 163, 149, 1, 71, 218, 154, 46, 229, 165, 128, 57, 174, 149, 65, 131, 195, 236, 124, 202, 9, 11, 35, 207, 9, 227, 161, 252, 224, 16, 218, 204, 115, 186, 194, 224, 36, 71, 255, 216, 183, 191, 149, 198, 129, 40, 12, 224, 105, 181, 213, 118, 209, 42, 75, 183, 106, 151, 46, 235, 222, 238, 237, 225, 12, 138, 32, 66, 74, 3, 9, 145, 24, 75, 48, 23, 197, 68, 134, 34, 185, 234, 19, 248, 16, 62, 240, 214, 191, 147, 108, 55, 153, 100, 182, 137, 147, 193, 223, 35, 124, 76, 191, 57, 51, 147, 30, 179, 5, 154, 255, 65, 195, 117, 72, 89, 19, 134, 138, 87, 248, 135, 69, 6, 7, 22, 179, 101, 126, 46, 229, 162, 133, 204, 82, 230, 199, 108, 149, 176, 152, 77, 165, 91, 249, 232, 156, 201, 187, 165, 153, 238, 250, 23, 179, 165, 240, 137, 228, 144, 56, 150, 192, 197, 188, 99, 90, 194, 49, 243, 143, 59, 138, 61, 95, 63, 127, 159, 229, 10, 61, 74, 59, 166, 187, 214, 152, 45, 101, 223, 85, 191, 191, 228, 85, 248, 253, 131, 5, 109, 113, 186, 89, 100, 41, 255, 208, 84, 178, 159, 24, 26, 196, 198, 51, 199, 92, 90, 71, 206, 170, 110, 125, 199, 43, 45, 203, 118, 180, 202, 185, 106, 158, 173, 191, 172, 254, 248, 217, 148, 81, 57, 71, 205, 190, 56, 78, 249, 245, 63, 35, 149, 179, 84, 236, 139, 125, 34, 151, 88, 95, 252, 210, 84, 241, 147, 200, 197, 84, 240, 104, 221, 252, 77, 36, 163, 96, 41, 31, 18, 217, 196, 74, 89, 149, 67, 223, 17, 145, 141, 171, 220, 91, 223, 6, 145, 142, 169, 220, 164, 44, 95, 91, 196, 39, 229, 217, 174, 18, 47, 170, 249, 218, 98, 49, 94, 144, 234, 176, 144, 31, 97, 115, 183, 165, 213, 93, 174, 63, 75, 211, 49, 162, 29, 144, 202, 196, 78, 246, 0, 10, 196, 252, 149, 240, 133, 62, 62, 153, 83, 242, 63, 168, 208, 120, 209, 128, 165, 205, 90, 151, 70, 115, 231, 150, 112, 25, 248, 202, 15, 137, 184, 123, 159, 138, 140, 23, 55, 240, 172, 127, 80, 219, 111, 195, 219, 123, 48, 35, 28, 244, 20, 25, 47, 34, 98, 130, 43, 196, 64, 36, 228, 59, 120, 53, 220, 209, 234, 168, 251, 13, 0, 40, 47, 227, 75, 140, 179, 13, 42, 18, 241, 53, 46, 77, 197, 66, 126, 215, 235, 106, 117, 211, 234, 192, 210, 13, 225, 240, 240, 47, 250, 25, 21, 138, 120, 41, 18, 8, 249, 1, 98, 6, 53, 219, 1, 119, 250, 240, 228, 142, 100, 27, 227, 42, 221, 40, 80, 26, 244, 254, 4, 223, 24, 130, 33, 51, 163, 58, 85, 115, 183, 7, 47, 30, 56, 187, 21, 254, 155, 23, 146, 92, 194, 185, 141, 140, 78, 69, 67, 102, 246, 234, 210, 25, 27, 29, 120, 115, 155, 157, 17, 166, 242, 13, 94, 206, 52, 156, 248, 152, 100, 136, 135, 204, 116, 106, 49, 206, 181, 135, 240, 110, 150, 25, 211, 9, 102, 241, 231, 65, 106, 111, 44, 238, 79, 117, 92, 97, 71, 226, 33, 51, 253, 182, 38, 187, 214, 0, 32, 103, 200, 99, 228, 242, 189, 179, 96, 65, 73, 76, 20, 6, 198, 84, 79, 171, 25, 209, 144, 147, 182, 37, 223, 0, 219, 125, 136, 163, 156, 178, 200, 199, 62, 185, 158, 94, 158, 122, 151, 211, 107, 31, 179, 5, 34, 33, 215, 108, 49, 111, 12, 32, 137, 164, 163, 87, 184, 126, 122, 84, 232, 88, 157, 12, 185, 30, 211, 92, 119, 8, 73, 13, 146, 238, 12, 203, 112, 65, 9, 223, 121, 242, 48, 82, 167, 197, 220, 220, 5, 200, 31, 114, 164, 99, 41, 230, 132, 203, 201, 10, 153, 233, 72, 56, 51, 111, 245, 32, 129, 115, 224, 155, 96, 73, 140, 66, 31, 41, 223, 64, 186, 222, 150, 38, 153, 246, 8, 138, 132, 28, 217, 88, 22, 163, 72, 200, 13, 200, 48, 146, 235, 210, 168, 217, 1, 40, 20, 242, 4, 203, 51, 206, 63, 92, 184, 144, 109, 32, 81, 101, 176, 170, 72, 106, 84, 185, 144, 153, 139, 40, 239, 112, 241, 8, 28, 123, 210, 84, 70, 183, 15, 41, 56, 23, 245, 101, 241, 131, 156, 195, 197, 12, 120, 70, 146, 76, 25, 7, 13, 40, 24, 50, 213, 177, 100, 94, 148, 171, 146, 111, 129, 171, 113, 160, 125, 188, 230, 0, 210, 81, 206, 237, 91, 121, 236, 73, 196, 169, 100, 118, 22, 225, 216, 254, 240, 98, 110, 173, 214, 49, 255, 238, 226, 10, 171, 224, 133, 52, 189, 146, 217, 4, 199, 215, 107, 105, 31, 106, 107, 8, 197, 67, 14, 177, 34, 250, 31, 102, 206, 174, 181, 137, 32, 10, 195, 54, 73, 53, 138, 85, 111, 218, 8, 66, 255, 197, 97, 36, 221, 128, 59, 184, 33, 1, 101, 35, 49, 75, 52, 11, 106, 98, 164, 44, 165, 66, 64, 37, 228, 70, 234, 149, 165, 55, 173, 95, 160, 127, 214, 212, 177, 57, 217, 116, 179, 103, 102, 187, 51, 179, 207, 189, 23, 62, 30, 222, 243, 158, 217, 32, 62, 228, 37, 158, 34, 79, 65, 142, 109, 59, 175, 204, 216, 142, 83, 121, 67, 60, 191, 25, 192, 227, 205, 70, 52, 68, 217, 24, 201, 88, 46, 72, 42, 22, 215, 223, 214, 6, 164, 243, 153, 88, 123, 230, 232, 36, 69, 242, 43, 144, 198, 218, 250, 187, 3, 4, 201, 223, 248, 134, 204, 6, 19, 76, 11, 133, 189, 135, 220, 185, 102, 133, 228, 43, 143, 62, 249, 58, 204, 6, 109, 76, 139, 53, 123, 175, 128, 215, 95, 169, 10, 136, 74, 135, 59, 96, 86, 24, 188, 187, 212, 45, 158, 192, 130, 98, 86, 185, 242, 14, 32, 74, 245, 34, 98, 118, 24, 97, 90, 96, 36, 43, 177, 99, 248, 27, 107, 25, 235, 177, 106, 189, 8, 152, 29, 246, 112, 237, 37, 68, 114, 1, 11, 51, 158, 32, 202, 155, 239, 29, 179, 132, 255, 14, 223, 45, 48, 146, 213, 184, 103, 208, 242, 230, 61, 144, 100, 163, 32, 221, 226, 156, 225, 197, 218, 195, 150, 92, 96, 203, 41, 142, 233, 80, 222, 103, 182, 104, 226, 218, 195, 215, 33, 85, 30, 16, 150, 77, 56, 166, 207, 17, 143, 81, 132, 157, 80, 53, 9, 122, 157, 46, 35, 25, 136, 65, 78, 254, 190, 87, 176, 89, 38, 118, 30, 209, 148, 71, 148, 137, 209, 212, 117, 221, 233, 200, 99, 210, 116, 39, 231, 127, 228, 108, 232, 147, 247, 200, 211, 180, 180, 40, 146, 101, 194, 49, 149, 23, 13, 150, 74, 112, 230, 10, 206, 184, 116, 10, 76, 93, 193, 79, 106, 154, 163, 71, 68, 90, 200, 113, 87, 123, 147, 43, 237, 128, 26, 223, 226, 146, 211, 221, 133, 83, 247, 130, 105, 151, 73, 209, 57, 118, 47, 56, 35, 198, 63, 32, 210, 66, 150, 29, 226, 42, 49, 115, 231, 33, 227, 89, 55, 94, 224, 124, 150, 198, 169, 139, 156, 50, 25, 188, 51, 23, 161, 178, 104, 57, 147, 31, 122, 239, 199, 112, 153, 34, 220, 126, 53, 144, 1, 21, 207, 45, 76, 228, 35, 217, 113, 151, 233, 51, 9, 34, 119, 137, 99, 98, 99, 30, 60, 66, 206, 83, 255, 40, 171, 230, 218, 53, 141, 220, 1, 21, 102, 254, 249, 168, 69, 50, 95, 80, 113, 144, 145, 9, 147, 224, 167, 187, 204, 144, 104, 202, 232, 248, 121, 228, 177, 57, 51, 32, 48, 255, 38, 183, 5, 82, 224, 24, 207, 241, 156, 119, 210, 55, 245, 52, 102, 108, 202, 104, 6, 110, 140, 159, 196, 75, 28, 74, 62, 104, 136, 0, 63, 2, 2, 211, 239, 203, 215, 55, 64, 129, 35, 246, 95, 242, 232, 33, 146, 26, 201, 117, 55, 142, 199, 72, 28, 87, 229, 223, 133, 163, 228, 161, 144, 156, 221, 178, 166, 111, 37, 183, 42, 160, 192, 123, 118, 33, 185, 141, 142, 211, 19, 32, 112, 227, 244, 24, 201, 109, 55, 198, 49, 209, 168, 31, 46, 214, 94, 67, 72, 206, 110, 185, 162, 229, 187, 223, 230, 54, 40, 48, 99, 11, 201, 206, 129, 228, 51, 103, 232, 198, 233, 50, 146, 166, 154, 228, 197, 230, 27, 161, 228, 172, 185, 188, 173, 225, 40, 41, 41, 29, 33, 39, 108, 73, 242, 80, 242, 19, 170, 39, 107, 12, 225, 110, 140, 51, 66, 242, 104, 177, 246, 132, 100, 193, 9, 100, 226, 110, 254, 69, 78, 173, 32, 31, 45, 75, 110, 45, 36, 135, 68, 85, 32, 182, 24, 185, 43, 39, 132, 228, 104, 177, 246, 80, 114, 246, 88, 174, 162, 29, 179, 229, 13, 7, 25, 37, 59, 19, 201, 183, 228, 161, 108, 31, 67, 38, 238, 50, 45, 150, 74, 216, 90, 172, 61, 148, 76, 140, 178, 193, 34, 119, 29, 148, 56, 138, 75, 30, 146, 123, 79, 48, 152, 186, 200, 212, 99, 18, 240, 99, 50, 45, 144, 48, 88, 172, 61, 148, 76, 140, 178, 185, 138, 113, 99, 23, 84, 24, 179, 184, 228, 166, 236, 131, 125, 195, 69, 110, 51, 41, 70, 75, 33, 222, 161, 36, 115, 113, 88, 143, 132, 100, 100, 12, 217, 216, 189, 145, 227, 210, 187, 7, 74, 204, 98, 146, 49, 47, 90, 10, 202, 70, 76, 14, 31, 207, 196, 6, 35, 37, 191, 19, 107, 111, 85, 242, 12, 50, 114, 175, 100, 231, 197, 2, 59, 50, 74, 142, 164, 191, 161, 70, 83, 145, 21, 17, 147, 102, 40, 18, 99, 218, 100, 180, 228, 137, 88, 123, 40, 153, 200, 11, 146, 154, 225, 107, 26, 57, 90, 149, 252, 255, 180, 30, 48, 26, 175, 49, 57, 157, 160, 1, 25, 6, 209, 228, 116, 212, 242, 25, 73, 143, 143, 196, 218, 91, 149, 236, 67, 102, 182, 114, 10, 228, 10, 40, 194, 46, 73, 30, 89, 253, 80, 141, 146, 135, 98, 237, 173, 74, 102, 144, 153, 202, 13, 147, 129, 140, 140, 47, 75, 110, 99, 185, 176, 8, 231, 145, 88, 123, 210, 146, 77, 197, 242, 77, 160, 160, 37, 139, 211, 122, 200, 44, 195, 121, 67, 172, 189, 60, 37, 195, 77, 35, 13, 153, 142, 11, 81, 149, 35, 102, 23, 159, 243, 182, 88, 123, 185, 74, 134, 235, 6, 159, 133, 16, 255, 178, 228, 22, 190, 92, 88, 195, 227, 188, 41, 214, 158, 218, 226, 211, 254, 84, 84, 5, 26, 186, 93, 136, 188, 8, 152, 93, 6, 156, 239, 139, 181, 71, 84, 56, 85, 170, 6, 218, 27, 125, 140, 136, 188, 232, 50, 187, 212, 57, 239, 139, 181, 167, 126, 140, 104, 236, 113, 155, 187, 144, 133, 147, 85, 201, 226, 180, 246, 152, 93, 186, 115, 201, 79, 163, 36, 201, 39, 112, 53, 118, 175, 18, 24, 59, 144, 13, 63, 38, 89, 48, 177, 94, 147, 67, 206, 131, 131, 70, 130, 100, 31, 174, 74, 213, 88, 88, 32, 179, 4, 201, 209, 1, 179, 12, 159, 51, 76, 146, 60, 131, 43, 179, 101, 170, 89, 32, 99, 63, 38, 89, 96, 251, 22, 241, 249, 156, 70, 146, 100, 144, 68, 71, 96, 212, 32, 51, 179, 4, 201, 182, 107, 178, 23, 151, 236, 19, 131, 172, 72, 205, 216, 25, 130, 28, 93, 150, 188, 199, 236, 82, 79, 146, 172, 222, 223, 114, 61, 73, 74, 15, 32, 59, 24, 24, 40, 185, 195, 236, 18, 174, 145, 60, 134, 92, 120, 80, 210, 240, 85, 143, 224, 196, 47, 154, 228, 94, 178, 228, 19, 200, 137, 59, 218, 31, 56, 17, 180, 92, 44, 201, 62, 95, 149, 156, 221, 113, 94, 143, 158, 85, 184, 42, 227, 127, 185, 236, 23, 69, 242, 96, 69, 178, 48, 63, 134, 252, 168, 154, 220, 122, 241, 159, 117, 22, 69, 114, 24, 151, 220, 198, 94, 145, 27, 183, 52, 188, 212, 211, 140, 103, 126, 97, 36, 247, 226, 146, 91, 140, 189, 31, 67, 190, 220, 211, 115, 235, 209, 156, 236, 21, 67, 178, 199, 87, 36, 231, 22, 198, 89, 239, 190, 242, 54, 228, 198, 151, 11, 201, 125, 102, 147, 250, 138, 228, 79, 160, 129, 237, 178, 150, 250, 70, 243, 186, 24, 146, 69, 36, 7, 186, 36, 171, 215, 184, 205, 10, 228, 6, 74, 118, 152, 69, 124, 190, 34, 249, 16, 116, 80, 217, 212, 241, 237, 148, 230, 176, 16, 146, 235, 171, 146, 199, 160, 133, 155, 58, 238, 16, 154, 241, 66, 178, 199, 236, 17, 10, 201, 253, 133, 100, 208, 67, 229, 134, 201, 65, 70, 246, 47, 36, 15, 88, 118, 188, 65, 189, 123, 78, 125, 48, 240, 178, 167, 5, 223, 187, 112, 252, 17, 52, 81, 179, 49, 200, 75, 245, 162, 158, 77, 111, 183, 23, 244, 157, 24, 253, 160, 87, 247, 179, 164, 5, 111, 226, 222, 211, 196, 198, 13, 27, 131, 140, 155, 47, 204, 16, 165, 61, 244, 187, 66, 167, 55, 80, 185, 68, 4, 45, 220, 123, 186, 168, 217, 24, 100, 220, 124, 129, 242, 107, 131, 147, 78, 191, 231, 73, 95, 34, 130, 182, 222, 189, 39, 157, 202, 53, 200, 155, 76, 69, 217, 15, 59, 142, 4, 157, 174, 194, 218, 227, 1, 70, 178, 62, 110, 154, 235, 200, 8, 134, 178, 167, 160, 184, 239, 72, 210, 239, 74, 175, 61, 222, 215, 30, 201, 114, 93, 249, 14, 228, 13, 134, 50, 234, 32, 64, 197, 82, 154, 235, 244, 15, 46, 4, 77, 253, 145, 12, 18, 163, 92, 222, 133, 188, 193, 166, 204, 37, 179, 184, 227, 40, 18, 120, 82, 131, 140, 145, 188, 1, 26, 217, 165, 94, 48, 238, 67, 254, 96, 94, 200, 253, 135, 66, 78, 6, 66, 162, 191, 25, 136, 100, 228, 62, 249, 245, 84, 3, 175, 21, 206, 145, 65, 223, 201, 68, 199, 163, 7, 121, 31, 211, 66, 43, 15, 168, 15, 34, 58, 56, 148, 207, 139, 208, 201, 76, 157, 72, 100, 237, 105, 129, 92, 39, 126, 252, 166, 3, 204, 11, 234, 78, 227, 206, 21, 8, 137, 65, 238, 96, 90, 104, 102, 39, 245, 16, 1, 29, 72, 31, 125, 126, 224, 92, 9, 158, 210, 145, 77, 156, 123, 200, 45, 99, 23, 53, 50, 150, 186, 71, 252, 142, 115, 69, 130, 164, 99, 15, 215, 158, 169, 180, 72, 109, 113, 229, 10, 104, 129, 170, 202, 232, 56, 127, 203, 61, 206, 141, 61, 14, 33, 187, 101, 83, 253, 13, 193, 213, 215, 87, 112, 252, 227, 25, 73, 135, 178, 92, 79, 24, 228, 49, 232, 38, 237, 147, 234, 93, 208, 5, 174, 190, 80, 126, 142, 63, 60, 38, 121, 70, 204, 178, 199, 141, 14, 50, 114, 119, 157, 227, 91, 160, 143, 67, 39, 189, 96, 120, 9, 89, 241, 135, 150, 252, 53, 33, 49, 252, 196, 176, 232, 52, 112, 237, 153, 224, 150, 177, 181, 135, 224, 247, 17, 78, 159, 32, 217, 37, 227, 89, 130, 97, 33, 104, 97, 127, 51, 192, 218, 213, 87, 218, 6, 141, 224, 40, 215, 137, 19, 36, 171, 100, 164, 158, 16, 22, 134, 7, 25, 182, 75, 198, 174, 61, 4, 71, 217, 25, 72, 62, 8, 189, 160, 249, 157, 246, 96, 228, 99, 88, 236, 53, 12, 15, 242, 186, 171, 175, 10, 90, 57, 68, 7, 161, 220, 247, 143, 169, 75, 242, 211, 89, 67, 207, 195, 51, 4, 231, 24, 7, 89, 63, 85, 131, 37, 25, 249, 178, 252, 61, 195, 23, 134, 189, 180, 239, 31, 103, 46, 201, 105, 74, 101, 14, 2, 97, 56, 216, 107, 163, 227, 79, 96, 138, 74, 153, 248, 141, 161, 22, 14, 227, 235, 233, 252, 175, 223, 119, 210, 56, 117, 73, 38, 206, 90, 230, 155, 174, 221, 154, 131, 134, 177, 35, 27, 97, 203, 96, 90, 32, 175, 29, 53, 70, 46, 73, 228, 172, 163, 217, 64, 108, 12, 114, 226, 43, 209, 166, 254, 131, 126, 188, 239, 40, 209, 58, 118, 9, 206, 20, 29, 127, 220, 0, 115, 108, 148, 13, 166, 5, 114, 232, 16, 168, 230, 197, 72, 210, 49, 110, 61, 147, 108, 153, 76, 11, 228, 139, 226, 40, 79, 51, 14, 114, 179, 109, 61, 44, 32, 161, 95, 148, 42, 160, 29, 245, 192, 136, 48, 48, 126, 125, 127, 245, 230, 243, 231, 55, 175, 190, 255, 194, 255, 3, 177, 189, 214, 177, 253, 176, 152, 83, 41, 153, 188, 68, 144, 195, 108, 187, 239, 215, 155, 151, 176, 224, 229, 43, 225, 249, 56, 90, 155, 21, 69, 8, 11, 184, 124, 143, 212, 192, 8, 234, 13, 227, 120, 174, 248, 45, 172, 240, 249, 87, 186, 227, 34, 132, 197, 95, 238, 237, 166, 53, 117, 32, 10, 227, 184, 233, 21, 223, 160, 218, 77, 109, 225, 194, 253, 22, 103, 211, 144, 77, 23, 195, 204, 46, 32, 74, 184, 8, 247, 5, 133, 172, 90, 87, 74, 215, 126, 4, 191, 240, 61, 145, 148, 7, 6, 211, 26, 239, 52, 231, 152, 255, 78, 112, 245, 99, 56, 206, 76, 34, 247, 224, 33, 223, 83, 51, 173, 247, 53, 149, 255, 190, 253, 161, 19, 253, 122, 171, 107, 188, 165, 198, 187, 247, 111, 57, 155, 106, 109, 106, 42, 111, 87, 116, 162, 141, 173, 60, 131, 156, 206, 173, 169, 249, 70, 222, 203, 89, 77, 21, 189, 48, 79, 189, 14, 63, 201, 107, 117, 168, 250, 174, 75, 180, 12, 228, 162, 177, 247, 42, 64, 115, 237, 92, 221, 197, 108, 14, 43, 66, 209, 166, 146, 216, 232, 50, 166, 169, 119, 57, 212, 96, 187, 132, 149, 107, 102, 15, 155, 205, 138, 219, 108, 14, 230, 163, 235, 10, 53, 63, 122, 156, 119, 232, 235, 81, 147, 69, 219, 196, 66, 42, 88, 198, 105, 51, 38, 234, 213, 120, 240, 20, 94, 57, 177, 161, 141, 109, 162, 207, 152, 134, 29, 116, 71, 205, 182, 102, 101, 103, 190, 96, 25, 171, 56, 233, 17, 154, 192, 248, 27, 53, 93, 161, 156, 88, 19, 144, 88, 165, 49, 134, 50, 70, 114, 131, 241, 196, 8, 198, 108, 108, 242, 65, 187, 136, 4, 235, 9, 236, 146, 125, 101, 102, 14, 66, 172, 113, 30, 31, 27, 139, 236, 146, 161, 188, 43, 143, 98, 230, 63, 7, 133, 102, 99, 154, 226, 154, 147, 68, 42, 149, 19, 103, 205, 165, 139, 248, 157, 88, 215, 25, 132, 80, 23, 23, 23, 66, 189, 48, 195, 229, 206, 133, 176, 118, 99, 162, 62, 158, 60, 201, 20, 29, 55, 25, 112, 14, 178, 134, 209, 118, 77, 242, 221, 226, 40, 34, 85, 100, 97, 2, 232, 207, 128, 109, 114, 78, 54, 34, 5, 13, 241, 198, 172, 88, 123, 227, 219, 56, 107, 141, 169, 224, 101, 95, 151, 156, 151, 51, 191, 73, 67, 147, 18, 185, 75, 114, 237, 227, 220, 157, 70, 114, 172, 141, 248, 99, 82, 39, 27, 199, 58, 144, 203, 7, 125, 125, 146, 139, 145, 227, 216, 36, 161, 115, 38, 214, 130, 76, 125, 252, 238, 9, 197, 200, 92, 110, 3, 225, 98, 25, 235, 65, 190, 197, 121, 79, 42, 70, 230, 48, 51, 2, 228, 242, 88, 19, 242, 24, 175, 181, 8, 197, 200, 101, 198, 133, 155, 20, 170, 144, 7, 184, 231, 148, 234, 53, 139, 193, 28, 134, 88, 25, 242, 157, 248, 230, 130, 94, 103, 105, 28, 128, 25, 196, 234, 144, 187, 55, 194, 155, 11, 70, 126, 98, 101, 100, 236, 229, 196, 150, 103, 177, 66, 100, 234, 227, 50, 89, 38, 70, 126, 154, 45, 226, 24, 229, 214, 93, 188, 136, 117, 34, 247, 240, 55, 84, 153, 24, 153, 123, 134, 204, 69, 206, 174, 88, 196, 106, 145, 31, 113, 115, 33, 20, 35, 115, 115, 31, 40, 63, 127, 60, 91, 83, 8, 43, 70, 30, 74, 239, 224, 24, 249, 216, 50, 139, 253, 242, 252, 211, 171, 54, 87, 2, 235, 70, 30, 8, 95, 15, 189, 35, 99, 48, 251, 177, 52, 168, 145, 179, 236, 123, 4, 214, 143, 60, 193, 251, 156, 34, 1, 25, 35, 227, 116, 89, 150, 166, 139, 180, 40, 195, 162, 191, 14, 228, 31, 252, 236, 137, 4, 3, 50, 183, 76, 207, 212, 187, 50, 100, 186, 17, 222, 38, 23, 200, 104, 222, 78, 228, 126, 103, 68, 146, 1, 185, 156, 204, 109, 68, 30, 9, 159, 69, 74, 100, 52, 207, 218, 135, 220, 19, 62, 139, 16, 144, 193, 220, 54, 228, 199, 206, 152, 36, 3, 50, 154, 61, 103, 237, 66, 30, 203, 30, 248, 128, 236, 51, 183, 9, 121, 40, 123, 224, 3, 178, 207, 60, 79, 219, 131, 252, 160, 20, 153, 91, 46, 218, 130, 60, 232, 76, 73, 48, 32, 87, 44, 231, 86, 32, 79, 101, 175, 46, 42, 145, 49, 157, 211, 235, 71, 158, 116, 190, 147, 104, 64, 174, 94, 207, 139, 236, 186, 145, 255, 81, 119, 55, 45, 106, 67, 81, 24, 199, 77, 91, 250, 6, 211, 22, 233, 27, 20, 250, 45, 238, 129, 116, 115, 161, 46, 2, 89, 148, 134, 98, 177, 218, 169, 4, 220, 184, 40, 40, 81, 144, 33, 193, 141, 73, 20, 241, 165, 139, 110, 134, 210, 207, 90, 219, 14, 62, 76, 102, 156, 152, 123, 207, 53, 206, 239, 35, 252, 57, 156, 196, 168, 55, 111, 74, 120, 62, 100, 117, 252, 95, 231, 231, 225, 98, 17, 187, 67, 57, 70, 205, 27, 67, 43, 76, 244, 207, 90, 173, 22, 70, 209, 249, 249, 175, 95, 126, 71, 148, 232, 197, 97, 191, 70, 109, 250, 193, 164, 74, 68, 114, 11, 145, 115, 67, 127, 173, 191, 255, 252, 177, 88, 228, 11, 145, 109, 219, 103, 131, 192, 111, 138, 82, 220, 59, 92, 228, 78, 123, 242, 156, 46, 184, 10, 145, 209, 186, 254, 190, 81, 44, 114, 98, 95, 24, 245, 219, 37, 204, 244, 129, 34, 91, 126, 127, 19, 24, 22, 219, 200, 221, 130, 141, 177, 168, 115, 35, 127, 217, 70, 78, 237, 13, 132, 246, 45, 113, 16, 136, 44, 140, 107, 182, 39, 148, 17, 109, 35, 123, 57, 53, 53, 46, 136, 136, 252, 219, 206, 24, 28, 182, 179, 233, 200, 150, 143, 194, 144, 110, 35, 207, 80, 141, 121, 158, 27, 181, 173, 181, 13, 152, 103, 177, 211, 237, 138, 220, 9, 158, 19, 192, 42, 115, 229, 211, 233, 220, 200, 93, 201, 181, 15, 54, 192, 40, 104, 138, 67, 48, 27, 25, 67, 156, 181, 148, 153, 165, 172, 163, 254, 57, 103, 91, 132, 246, 46, 131, 158, 48, 207, 100, 100, 191, 74, 187, 197, 219, 200, 195, 2, 57, 139, 60, 230, 248, 88, 203, 92, 247, 74, 203, 108, 46, 114, 27, 137, 1, 82, 166, 81, 198, 199, 239, 29, 131, 140, 149, 188, 203, 153, 47, 204, 50, 19, 25, 83, 188, 211, 90, 50, 92, 250, 0, 95, 15, 98, 144, 225, 212, 190, 217, 153, 233, 105, 54, 113, 159, 220, 171, 82, 174, 152, 119, 148, 177, 52, 48, 200, 216, 22, 185, 6, 29, 97, 18, 127, 228, 102, 159, 246, 48, 69, 228, 225, 248, 29, 147, 122, 3, 183, 22, 48, 183, 247, 240, 195, 18, 166, 240, 127, 226, 179, 218, 14, 237, 195, 113, 179, 11, 131, 115, 53, 55, 106, 144, 216, 123, 25, 249, 194, 148, 123, 204, 79, 225, 58, 85, 218, 83, 42, 193, 123, 199, 151, 249, 35, 150, 5, 6, 121, 47, 131, 166, 48, 227, 5, 235, 243, 100, 43, 32, 40, 48, 202, 88, 203, 12, 234, 104, 140, 65, 222, 203, 168, 45, 128, 53, 242, 51, 193, 6, 99, 92, 96, 43, 243, 87, 254, 180, 105, 12, 75, 27, 74, 26, 230, 103, 140, 223, 241, 249, 14, 21, 178, 144, 48, 100, 172, 220, 149, 46, 26, 255, 182, 11, 25, 245, 4, 191, 167, 108, 223, 86, 91, 125, 42, 104, 46, 141, 204, 178, 39, 37, 42, 71, 167, 118, 65, 129, 37, 184, 189, 228, 57, 211, 23, 171, 162, 224, 194, 96, 191, 250, 181, 60, 249, 79, 156, 89, 22, 101, 174, 140, 135, 44, 191, 32, 42, 190, 42, 240, 88, 25, 102, 12, 247, 203, 227, 153, 148, 18, 149, 87, 54, 148, 183, 50, 94, 241, 252, 22, 46, 32, 37, 14, 214, 50, 207, 98, 238, 74, 112, 241, 89, 175, 40, 95, 176, 122, 162, 245, 171, 78, 172, 99, 69, 203, 88, 94, 226, 141, 181, 199, 24, 220, 228, 155, 173, 40, 16, 156, 94, 87, 78, 244, 27, 79, 72, 217, 220, 149, 153, 97, 110, 41, 39, 246, 228, 101, 161, 131, 200, 69, 245, 5, 163, 19, 253, 95, 218, 55, 171, 68, 90, 149, 89, 50, 183, 188, 225, 149, 198, 68, 234, 149, 7, 150, 96, 115, 95, 253, 63, 35, 104, 172, 101, 30, 75, 253, 204, 227, 77, 226, 140, 200, 33, 58, 146, 202, 15, 148, 255, 253, 132, 198, 154, 150, 11, 9, 42, 187, 185, 213, 157, 201, 43, 146, 239, 68, 122, 149, 207, 216, 42, 223, 173, 84, 222, 10, 13, 205, 231, 164, 205, 137, 228, 85, 67, 116, 206, 41, 140, 33, 150, 48, 37, 162, 99, 169, 124, 175, 82, 41, 252, 132, 136, 117, 142, 241, 68, 14, 208, 185, 155, 19, 122, 140, 194, 151, 196, 115, 250, 239, 40, 54, 198, 27, 197, 211, 80, 209, 152, 199, 58, 150, 144, 9, 221, 29, 183, 174, 25, 224, 77, 223, 217, 80, 94, 47, 113, 136, 142, 168, 242, 75, 173, 119, 229, 88, 85, 226, 226, 36, 242, 6, 195, 153, 183, 137, 125, 193, 243, 144, 23, 32, 94, 17, 232, 86, 22, 12, 94, 233, 156, 119, 97, 77, 136, 209, 122, 33, 115, 185, 50, 31, 198, 24, 202, 189, 95, 126, 162, 115, 114, 75, 159, 120, 77, 99, 253, 200, 209, 156, 0, 108, 101, 109, 161, 237, 68, 227, 12, 162, 128, 184, 57, 83, 87, 47, 114, 184, 166, 235, 157, 218, 202, 124, 161, 235, 113, 69, 249, 152, 0, 159, 128, 49, 115, 172, 30, 57, 66, 98, 206, 202, 29, 161, 199, 186, 163, 252, 2, 179, 142, 67, 70, 124, 95, 133, 74, 145, 221, 116, 73, 192, 89, 121, 212, 20, 90, 222, 40, 159, 104, 143, 27, 11, 126, 203, 52, 46, 26, 57, 90, 57, 148, 113, 52, 183, 24, 15, 149, 207, 168, 158, 144, 81, 243, 116, 177, 119, 100, 23, 133, 13, 85, 14, 132, 142, 71, 170, 167, 206, 182, 201, 184, 229, 42, 137, 115, 35, 15, 195, 116, 253, 157, 192, 80, 229, 158, 208, 112, 162, 240, 222, 0, 44, 100, 243, 150, 235, 105, 180, 216, 17, 217, 13, 147, 233, 60, 27, 248, 24, 215, 242, 227, 202, 95, 119, 44, 145, 161, 183, 144, 249, 83, 175, 166, 105, 18, 69, 97, 24, 46, 194, 48, 74, 146, 116, 186, 154, 59, 84, 220, 105, 41, 107, 249, 174, 218, 235, 181, 2, 186, 165, 190, 149, 240, 153, 228, 153, 218, 123, 193, 123, 116, 107, 253, 97, 239, 108, 90, 226, 8, 130, 48, 92, 51, 238, 124, 236, 68, 103, 39, 16, 119, 7, 6, 60, 229, 160, 11, 30, 66, 176, 15, 9, 196, 163, 16, 33, 151, 16, 2, 11, 70, 132, 128, 7, 89, 80, 146, 67, 8, 70, 16, 66, 16, 2, 201, 53, 57, 248, 95, 179, 32, 164, 68, 119, 103, 187, 122, 186, 219, 154, 233, 126, 110, 94, 31, 138, 183, 171, 170, 219, 157, 15, 246, 3, 99, 116, 227, 24, 183, 23, 28, 195, 98, 49, 237, 8, 140, 114, 241, 23, 115, 186, 24, 22, 15, 19, 24, 153, 202, 183, 159, 62, 138, 86, 99, 59, 48, 122, 33, 40, 124, 205, 229, 187, 104, 53, 7, 150, 183, 158, 3, 149, 79, 164, 30, 137, 150, 99, 111, 36, 193, 121, 143, 56, 243, 5, 79, 68, 219, 81, 191, 88, 165, 10, 198, 121, 15, 238, 174, 148, 187, 123, 234, 97, 96, 216, 91, 45, 71, 112, 3, 225, 198, 122, 178, 39, 218, 143, 250, 217, 23, 236, 80, 169, 0, 145, 189, 76, 61, 19, 29, 224, 192, 98, 27, 55, 66, 199, 24, 202, 157, 110, 223, 30, 160, 148, 215, 0, 137, 102, 127, 187, 82, 200, 51, 236, 109, 150, 35, 0, 164, 216, 113, 167, 144, 49, 48, 140, 151, 114, 1, 183, 233, 187, 84, 200, 66, 216, 74, 229, 62, 32, 114, 143, 47, 38, 162, 51, 216, 42, 229, 24, 110, 19, 246, 118, 92, 232, 145, 45, 150, 50, 46, 46, 144, 212, 133, 97, 15, 57, 176, 50, 246, 165, 128, 200, 53, 113, 135, 162, 75, 152, 222, 96, 96, 3, 71, 106, 226, 90, 188, 171, 215, 217, 43, 127, 86, 108, 224, 112, 221, 217, 205, 75, 39, 189, 165, 60, 33, 175, 57, 145, 220, 153, 254, 237, 6, 11, 255, 227, 151, 3, 34, 181, 137, 11, 186, 176, 26, 178, 124, 244, 37, 112, 143, 194, 161, 99, 175, 81, 41, 159, 146, 199, 61, 164, 236, 242, 173, 147, 206, 82, 62, 35, 220, 83, 223, 37, 113, 100, 218, 251, 143, 242, 212, 71, 239, 45, 144, 129, 83, 105, 97, 60, 47, 134, 48, 143, 210, 153, 38, 217, 74, 94, 172, 193, 60, 162, 192, 169, 180, 192, 82, 54, 146, 23, 189, 8, 230, 146, 58, 149, 22, 134, 243, 34, 133, 249, 196, 14, 245, 22, 152, 23, 134, 230, 145, 24, 22, 80, 185, 50, 137, 96, 41, 155, 154, 71, 214, 67, 88, 64, 238, 200, 222, 162, 113, 94, 76, 200, 35, 53, 146, 56, 176, 174, 215, 146, 23, 71, 244, 145, 26, 25, 186, 20, 201, 51, 76, 52, 113, 216, 36, 147, 142, 190, 64, 116, 21, 99, 161, 28, 67, 13, 149, 75, 145, 140, 121, 161, 59, 148, 171, 16, 106, 40, 93, 138, 228, 25, 134, 66, 185, 132, 58, 86, 54, 92, 138, 100, 245, 188, 248, 68, 157, 246, 150, 190, 114, 233, 210, 53, 53, 65, 178, 250, 77, 95, 31, 234, 73, 92, 89, 92, 52, 11, 229, 47, 42, 253, 27, 146, 58, 116, 238, 25, 58, 249, 82, 88, 70, 230, 200, 118, 200, 224, 201, 151, 193, 82, 210, 54, 220, 83, 79, 175, 206, 95, 75, 115, 126, 53, 213, 30, 202, 135, 42, 131, 8, 146, 181, 160, 185, 192, 31, 94, 150, 227, 124, 79, 183, 228, 51, 165, 66, 70, 134, 252, 155, 139, 111, 187, 68, 126, 80, 67, 89, 189, 189, 24, 128, 12, 25, 251, 161, 250, 231, 46, 153, 95, 214, 218, 139, 24, 164, 24, 114, 127, 95, 127, 69, 151, 252, 91, 119, 123, 161, 86, 200, 72, 198, 189, 131, 251, 67, 151, 252, 87, 119, 123, 49, 81, 75, 100, 36, 101, 222, 193, 113, 144, 124, 170, 214, 90, 32, 25, 243, 245, 144, 138, 100, 221, 237, 197, 145, 98, 33, 35, 35, 222, 109, 50, 7, 201, 135, 138, 195, 30, 146, 244, 188, 100, 68, 126, 15, 23, 36, 64, 160, 207, 122, 22, 185, 126, 79, 230, 218, 202, 52, 210, 7, 10, 209, 58, 231, 23, 90, 39, 175, 200, 28, 211, 167, 17, 186, 228, 141, 8, 72, 148, 94, 50, 34, 59, 242, 149, 64, 164, 96, 60, 85, 51, 149, 92, 132, 64, 36, 243, 146, 107, 249, 90, 59, 80, 83, 39, 18, 134, 79, 180, 120, 74, 78, 129, 78, 210, 243, 146, 41, 146, 123, 9, 32, 212, 179, 79, 240, 131, 165, 228, 18, 148, 24, 120, 201, 242, 146, 139, 16, 148, 200, 2, 47, 89, 90, 114, 6, 138, 228, 94, 178, 172, 228, 62, 168, 18, 86, 94, 178, 156, 228, 106, 5, 148, 201, 188, 100, 57, 201, 49, 168, 128, 139, 162, 23, 138, 96, 235, 199, 90, 242, 155, 151, 106, 172, 54, 13, 11, 36, 44, 188, 228, 122, 201, 24, 22, 234, 100, 129, 151, 188, 76, 114, 144, 65, 67, 114, 47, 121, 153, 228, 28, 154, 18, 142, 189, 228, 122, 201, 131, 16, 26, 243, 244, 157, 151, 92, 39, 185, 151, 128, 6, 182, 189, 228, 58, 201, 107, 160, 133, 77, 110, 146, 143, 247, 201, 24, 147, 60, 2, 61, 68, 99, 110, 146, 249, 84, 114, 129, 221, 91, 227, 88, 246, 146, 231, 75, 222, 72, 64, 27, 219, 111, 89, 73, 190, 164, 75, 190, 52, 35, 57, 6, 141, 60, 107, 187, 228, 169, 17, 201, 57, 232, 36, 92, 229, 36, 89, 208, 37, 11, 19, 146, 135, 160, 151, 199, 99, 78, 146, 247, 169, 142, 247, 77, 72, 174, 34, 64, 52, 29, 126, 140, 36, 147, 27, 229, 19, 3, 146, 241, 208, 211, 121, 248, 241, 145, 76, 14, 229, 75, 253, 146, 131, 24, 12, 240, 156, 143, 100, 113, 65, 77, 11, 253, 146, 75, 48, 194, 22, 31, 201, 196, 188, 56, 214, 47, 121, 11, 204, 16, 110, 178, 145, 60, 37, 57, 190, 152, 106, 151, 188, 21, 130, 33, 162, 49, 23, 201, 180, 82, 62, 17, 186, 37, 111, 70, 96, 140, 71, 99, 46, 146, 167, 23, 148, 66, 214, 45, 121, 245, 95, 123, 119, 179, 154, 58, 16, 134, 113, 252, 69, 113, 149, 108, 242, 177, 17, 50, 11, 201, 183, 160, 98, 148, 185, 4, 21, 2, 65, 40, 186, 58, 123, 11, 37, 183, 32, 228, 206, 207, 145, 22, 166, 61, 181, 38, 149, 73, 242, 204, 232, 255, 18, 126, 188, 188, 206, 196, 64, 12, 106, 49, 99, 15, 130, 204, 79, 191, 217, 200, 146, 145, 205, 128, 90, 45, 56, 130, 32, 243, 188, 249, 209, 66, 50, 242, 46, 160, 150, 91, 28, 64, 144, 203, 115, 211, 101, 33, 25, 121, 183, 160, 214, 18, 202, 24, 200, 188, 58, 55, 52, 150, 139, 188, 89, 83, 7, 173, 15, 24, 200, 188, 106, 98, 92, 113, 185, 200, 155, 57, 181, 154, 80, 198, 64, 22, 179, 124, 191, 49, 47, 48, 141, 47, 202, 24, 200, 181, 202, 121, 201, 107, 145, 65, 141, 47, 202, 24, 200, 188, 204, 111, 94, 66, 74, 94, 143, 140, 106, 124, 81, 198, 64, 190, 53, 204, 121, 197, 185, 92, 228, 221, 156, 58, 109, 113, 4, 65, 230, 229, 233, 42, 243, 249, 196, 27, 85, 96, 157, 221, 190, 22, 236, 65, 144, 255, 117, 202, 107, 166, 88, 10, 178, 25, 80, 231, 5, 83, 24, 100, 206, 203, 234, 45, 63, 127, 140, 112, 254, 86, 149, 188, 113, 5, 178, 49, 145, 49, 197, 65, 126, 151, 190, 36, 124, 229, 34, 39, 6, 245, 210, 200, 196, 66, 22, 201, 71, 78, 70, 212, 83, 131, 244, 81, 144, 211, 1, 245, 215, 242, 229, 17, 144, 95, 151, 212, 107, 179, 131, 254, 200, 155, 25, 245, 220, 98, 175, 59, 178, 185, 160, 222, 51, 76, 189, 145, 19, 131, 0, 26, 166, 58, 35, 47, 135, 132, 209, 234, 160, 43, 242, 102, 69, 48, 5, 83, 61, 145, 17, 214, 177, 104, 148, 232, 136, 156, 90, 132, 213, 234, 160, 27, 50, 210, 170, 16, 43, 67, 47, 100, 51, 32, 192, 134, 233, 139, 70, 200, 48, 167, 138, 255, 155, 239, 117, 65, 54, 231, 4, 155, 149, 232, 129, 12, 247, 139, 247, 181, 217, 81, 125, 100, 179, 247, 103, 21, 117, 25, 137, 234, 200, 41, 196, 61, 186, 166, 245, 84, 101, 100, 228, 109, 252, 185, 225, 242, 143, 170, 200, 155, 229, 136, 84, 41, 48, 213, 68, 78, 32, 207, 198, 63, 54, 219, 171, 135, 108, 2, 94, 241, 110, 55, 138, 213, 80, 46, 84, 220, 20, 34, 43, 228, 10, 244, 129, 252, 154, 170, 181, 41, 68, 78, 198, 225, 123, 71, 78, 160, 158, 105, 254, 178, 49, 227, 224, 21, 10, 29, 219, 126, 204, 7, 103, 46, 20, 184, 224, 53, 104, 2, 248, 17, 13, 17, 91, 13, 72, 139, 112, 167, 153, 249, 164, 79, 152, 187, 89, 43, 226, 75, 14, 220, 129, 46, 116, 72, 191, 172, 8, 232, 187, 48, 110, 164, 194, 179, 182, 123, 26, 122, 32, 91, 131, 121, 168, 127, 46, 73, 218, 26, 189, 143, 243, 86, 203, 61, 1, 53, 206, 154, 15, 177, 200, 136, 109, 222, 75, 182, 182, 155, 248, 106, 78, 247, 191, 130, 110, 164, 255, 154, 184, 226, 220, 225, 60, 219, 209, 152, 30, 52, 39, 102, 188, 131, 88, 252, 128, 51, 252, 57, 107, 210, 238, 121, 195, 13, 39, 216, 47, 81, 116, 149, 19, 103, 173, 64, 187, 217, 163, 143, 240, 55, 232, 208, 150, 186, 132, 195, 39, 240, 213, 44, 63, 202, 92, 25, 3, 28, 249, 207, 21, 81, 35, 29, 135, 204, 189, 147, 151, 133, 241, 211, 183, 57, 245, 216, 139, 132, 117, 19, 221, 200, 27, 63, 121, 239, 196, 118, 124, 47, 142, 194, 140, 49, 219, 117, 183, 226, 45, 131, 173, 235, 218, 140, 101, 97, 20, 123, 190, 131, 142, 251, 23, 97, 210, 124, 27, 220, 190, 110, 68, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, true },
                    { 2, "uposlenik@mail.com", "Uposlenik", "uposlenik", "65zLFSYrA5WmxUIBlo96+zeCas0=", "NLfhPm8aZqwuvG4CpRytUQ==", "Test", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 1, 100, 0, 0, 1, 144, 8, 3, 0, 0, 0, 174, 198, 234, 29, 0, 0, 1, 221, 80, 76, 84, 69, 0, 0, 0, 246, 110, 89, 210, 108, 88, 189, 107, 90, 249, 110, 88, 235, 115, 94, 249, 110, 88, 249, 110, 88, 249, 110, 88, 249, 110, 88, 249, 110, 88, 137, 107, 94, 193, 166, 133, 249, 110, 88, 249, 110, 88, 249, 110, 88, 249, 110, 88, 136, 106, 95, 74, 105, 120, 131, 103, 97, 58, 105, 123, 249, 110, 88, 249, 110, 88, 249, 110, 88, 249, 110, 88, 126, 98, 87, 126, 96, 81, 249, 110, 88, 122, 98, 90, 80, 105, 119, 249, 110, 88, 117, 90, 75, 126, 97, 81, 125, 98, 86, 126, 97, 81, 126, 103, 100, 171, 138, 122, 97, 106, 116, 107, 106, 114, 114, 106, 113, 184, 160, 133, 177, 154, 130, 204, 177, 142, 130, 100, 84, 130, 100, 84, 172, 144, 126, 168, 139, 122, 170, 139, 122, 130, 100, 84, 174, 149, 128, 89, 105, 117, 172, 144, 125, 173, 142, 125, 249, 110, 88, 36, 104, 127, 249, 206, 155, 130, 100, 84, 32, 93, 114, 237, 194, 148, 213, 174, 133, 210, 173, 135, 192, 158, 124, 29, 181, 203, 243, 242, 242, 117, 90, 75, 70, 71, 71, 224, 185, 139, 218, 217, 217, 255, 255, 255, 244, 202, 152, 207, 170, 132, 49, 109, 129, 202, 166, 129, 197, 161, 126, 232, 234, 235, 30, 165, 187, 125, 96, 81, 119, 91, 76, 73, 119, 128, 247, 203, 153, 217, 179, 138, 239, 224, 209, 128, 98, 83, 235, 193, 147, 122, 94, 79, 228, 188, 144, 221, 182, 139, 96, 200, 215, 215, 177, 136, 207, 198, 188, 232, 109, 89, 239, 198, 151, 232, 192, 145, 35, 101, 123, 33, 96, 118, 163, 103, 93, 225, 155, 120, 183, 105, 94, 174, 142, 113, 162, 133, 107, 218, 108, 90, 246, 121, 96, 137, 105, 87, 33, 137, 159, 211, 172, 132, 240, 215, 188, 185, 152, 120, 32, 144, 166, 146, 115, 93, 37, 110, 132, 233, 133, 105, 240, 184, 140, 201, 108, 94, 120, 103, 108, 151, 123, 101, 144, 105, 104, 97, 99, 106, 243, 240, 237, 203, 153, 119, 214, 145, 113, 54, 95, 111, 87, 83, 79, 75, 97, 110, 249, 165, 126, 199, 211, 216, 186, 202, 208, 29, 174, 196, 239, 203, 165, 197, 103, 84, 34, 123, 146, 249, 191, 145, 218, 168, 130, 101, 106, 115, 222, 228, 230, 169, 191, 198, 150, 178, 187, 129, 166, 179, 243, 233, 224, 75, 75, 73, 80, 132, 150, 249, 138, 108, 209, 219, 223, 65, 122, 141, 111, 154, 168, 93, 140, 157, 130, 113, 99, 100, 94, 85, 194, 131, 106, 138, 92, 78, 216, 189, 161, 113, 103, 91, 104, 78, 74, 138, 193, 204, 125, 184, 196, 192, 183, 182, 252, 250, 248, 188, 159, 157, 63, 156, 174, 136, 163, 172, 127, 1, 205, 204, 0, 0, 0, 53, 116, 82, 78, 83, 0, 253, 4, 11, 242, 17, 68, 30, 167, 138, 48, 46, 254, 88, 121, 194, 204, 29, 253, 74, 253, 227, 183, 151, 104, 93, 182, 216, 145, 239, 236, 232, 205, 129, 162, 114, 85, 214, 192, 171, 244, 235, 253, 243, 232, 159, 140, 110, 222, 219, 227, 184, 132, 9, 109, 52, 73, 0, 0, 26, 222, 73, 68, 65, 84, 120, 218, 236, 217, 189, 142, 180, 32, 24, 5, 96, 50, 150, 84, 198, 10, 66, 194, 143, 165, 22, 150, 167, 228, 2, 164, 49, 222, 255, 181, 124, 126, 179, 187, 226, 174, 113, 150, 56, 144, 108, 128, 167, 157, 132, 226, 4, 15, 47, 12, 249, 91, 56, 35, 85, 98, 13, 160, 58, 82, 37, 213, 97, 195, 41, 169, 18, 210, 120, 50, 53, 230, 132, 56, 54, 117, 55, 167, 165, 176, 83, 236, 65, 170, 20, 70, 28, 140, 186, 37, 85, 124, 248, 129, 215, 237, 28, 93, 131, 147, 193, 212, 145, 46, 93, 200, 222, 104, 186, 186, 159, 35, 194, 133, 193, 176, 218, 207, 177, 224, 133, 73, 116, 53, 232, 24, 70, 188, 54, 153, 158, 214, 234, 120, 147, 66, 0, 101, 116, 215, 214, 168, 111, 227, 8, 54, 113, 163, 89, 71, 105, 67, 170, 51, 42, 174, 119, 161, 192, 13, 227, 52, 41, 165, 248, 198, 232, 158, 213, 212, 55, 108, 0, 191, 204, 129, 225, 93, 203, 106, 37, 23, 93, 217, 73, 107, 108, 84, 123, 181, 203, 241, 190, 217, 217, 141, 18, 229, 94, 98, 4, 158, 166, 139, 148, 31, 3, 34, 88, 237, 147, 20, 101, 62, 229, 233, 189, 71, 233, 213, 201, 23, 195, 226, 236, 7, 213, 151, 215, 27, 29, 118, 67, 119, 170, 10, 166, 133, 81, 136, 99, 182, 159, 164, 46, 44, 230, 102, 196, 1, 59, 254, 194, 184, 180, 255, 57, 68, 178, 184, 66, 99, 214, 248, 102, 31, 229, 90, 33, 237, 151, 5, 177, 172, 246, 139, 44, 232, 47, 240, 211, 169, 198, 91, 178, 105, 132, 179, 222, 140, 104, 102, 187, 83, 197, 28, 129, 12, 63, 77, 148, 16, 42, 237, 209, 10, 47, 94, 101, 88, 167, 11, 185, 135, 27, 156, 12, 61, 243, 65, 68, 236, 11, 127, 51, 217, 169, 50, 158, 240, 212, 229, 213, 225, 104, 70, 76, 135, 148, 101, 17, 183, 147, 225, 197, 55, 237, 57, 164, 74, 217, 106, 146, 63, 92, 152, 19, 245, 197, 121, 117, 147, 127, 49, 15, 175, 14, 40, 111, 69, 186, 148, 121, 246, 41, 79, 8, 219, 203, 75, 202, 148, 115, 191, 152, 240, 176, 230, 180, 43, 234, 94, 190, 173, 71, 96, 202, 75, 202, 148, 13, 201, 26, 5, 16, 84, 203, 14, 177, 173, 214, 19, 36, 107, 42, 52, 229, 53, 105, 202, 121, 191, 100, 48, 132, 166, 60, 35, 182, 195, 234, 46, 239, 135, 12, 21, 156, 242, 130, 104, 206, 171, 203, 172, 71, 12, 26, 252, 77, 187, 122, 248, 221, 69, 101, 64, 16, 62, 229, 90, 203, 183, 50, 254, 173, 108, 23, 151, 48, 229, 34, 10, 163, 149, 1, 71, 218, 154, 46, 229, 165, 128, 57, 174, 149, 65, 131, 195, 236, 124, 202, 9, 11, 35, 207, 9, 227, 161, 252, 224, 16, 218, 204, 115, 186, 194, 224, 36, 71, 255, 216, 183, 191, 149, 198, 129, 40, 12, 224, 105, 181, 213, 118, 209, 42, 75, 183, 106, 151, 46, 235, 222, 238, 237, 225, 12, 138, 32, 66, 74, 3, 9, 145, 24, 75, 48, 23, 197, 68, 134, 34, 185, 234, 19, 248, 16, 62, 240, 214, 191, 147, 108, 55, 153, 100, 182, 137, 147, 193, 223, 35, 124, 76, 191, 57, 51, 147, 30, 179, 5, 154, 255, 65, 195, 117, 72, 89, 19, 134, 138, 87, 248, 135, 69, 6, 7, 22, 179, 101, 126, 46, 229, 162, 133, 204, 82, 230, 199, 108, 149, 176, 152, 77, 165, 91, 249, 232, 156, 201, 187, 165, 153, 238, 250, 23, 179, 165, 240, 137, 228, 144, 56, 150, 192, 197, 188, 99, 90, 194, 49, 243, 143, 59, 138, 61, 95, 63, 127, 159, 229, 10, 61, 74, 59, 166, 187, 214, 152, 45, 101, 223, 85, 191, 191, 228, 85, 248, 253, 131, 5, 109, 113, 186, 89, 100, 41, 255, 208, 84, 178, 159, 24, 26, 196, 198, 51, 199, 92, 90, 71, 206, 170, 110, 125, 199, 43, 45, 203, 118, 180, 202, 185, 106, 158, 173, 191, 172, 254, 248, 217, 148, 81, 57, 71, 205, 190, 56, 78, 249, 245, 63, 35, 149, 179, 84, 236, 139, 125, 34, 151, 88, 95, 252, 210, 84, 241, 147, 200, 197, 84, 240, 104, 221, 252, 77, 36, 163, 96, 41, 31, 18, 217, 196, 74, 89, 149, 67, 223, 17, 145, 141, 171, 220, 91, 223, 6, 145, 142, 169, 220, 164, 44, 95, 91, 196, 39, 229, 217, 174, 18, 47, 170, 249, 218, 98, 49, 94, 144, 234, 176, 144, 31, 97, 115, 183, 165, 213, 93, 174, 63, 75, 211, 49, 162, 29, 144, 202, 196, 78, 246, 0, 10, 196, 252, 149, 240, 133, 62, 62, 153, 83, 242, 63, 168, 208, 120, 209, 128, 165, 205, 90, 151, 70, 115, 231, 150, 112, 25, 248, 202, 15, 137, 184, 123, 159, 138, 140, 23, 55, 240, 172, 127, 80, 219, 111, 195, 219, 123, 48, 35, 28, 244, 20, 25, 47, 34, 98, 130, 43, 196, 64, 36, 228, 59, 120, 53, 220, 209, 234, 168, 251, 13, 0, 40, 47, 227, 75, 140, 179, 13, 42, 18, 241, 53, 46, 77, 197, 66, 126, 215, 235, 106, 117, 211, 234, 192, 210, 13, 225, 240, 240, 47, 250, 25, 21, 138, 120, 41, 18, 8, 249, 1, 98, 6, 53, 219, 1, 119, 250, 240, 228, 142, 100, 27, 227, 42, 221, 40, 80, 26, 244, 254, 4, 223, 24, 130, 33, 51, 163, 58, 85, 115, 183, 7, 47, 30, 56, 187, 21, 254, 155, 23, 146, 92, 194, 185, 141, 140, 78, 69, 67, 102, 246, 234, 210, 25, 27, 29, 120, 115, 155, 157, 17, 166, 242, 13, 94, 206, 52, 156, 248, 152, 100, 136, 135, 204, 116, 106, 49, 206, 181, 135, 240, 110, 150, 25, 211, 9, 102, 241, 231, 65, 106, 111, 44, 238, 79, 117, 92, 97, 71, 226, 33, 51, 253, 182, 38, 187, 214, 0, 32, 103, 200, 99, 228, 242, 189, 179, 96, 65, 73, 76, 20, 6, 198, 84, 79, 171, 25, 209, 144, 147, 182, 37, 223, 0, 219, 125, 136, 163, 156, 178, 200, 199, 62, 185, 158, 94, 158, 122, 151, 211, 107, 31, 179, 5, 34, 33, 215, 108, 49, 111, 12, 32, 137, 164, 163, 87, 184, 126, 122, 84, 232, 88, 157, 12, 185, 30, 211, 92, 119, 8, 73, 13, 146, 238, 12, 203, 112, 65, 9, 223, 121, 242, 48, 82, 167, 197, 220, 220, 5, 200, 31, 114, 164, 99, 41, 230, 132, 203, 201, 10, 153, 233, 72, 56, 51, 111, 245, 32, 129, 115, 224, 155, 96, 73, 140, 66, 31, 41, 223, 64, 186, 222, 150, 38, 153, 246, 8, 138, 132, 28, 217, 88, 22, 163, 72, 200, 13, 200, 48, 146, 235, 210, 168, 217, 1, 40, 20, 242, 4, 203, 51, 206, 63, 92, 184, 144, 109, 32, 81, 101, 176, 170, 72, 106, 84, 185, 144, 153, 139, 40, 239, 112, 241, 8, 28, 123, 210, 84, 70, 183, 15, 41, 56, 23, 245, 101, 241, 131, 156, 195, 197, 12, 120, 70, 146, 76, 25, 7, 13, 40, 24, 50, 213, 177, 100, 94, 148, 171, 146, 111, 129, 171, 113, 160, 125, 188, 230, 0, 210, 81, 206, 237, 91, 121, 236, 73, 196, 169, 100, 118, 22, 225, 216, 254, 240, 98, 110, 173, 214, 49, 255, 238, 226, 10, 171, 224, 133, 52, 189, 146, 217, 4, 199, 215, 107, 105, 31, 106, 107, 8, 197, 67, 14, 177, 34, 250, 31, 102, 206, 174, 181, 137, 32, 10, 195, 54, 73, 53, 138, 85, 111, 218, 8, 66, 255, 197, 97, 36, 221, 128, 59, 184, 33, 1, 101, 35, 49, 75, 52, 11, 106, 98, 164, 44, 165, 66, 64, 37, 228, 70, 234, 149, 165, 55, 173, 95, 160, 127, 214, 212, 177, 57, 217, 116, 179, 103, 102, 187, 51, 179, 207, 189, 23, 62, 30, 222, 243, 158, 217, 32, 62, 228, 37, 158, 34, 79, 65, 142, 109, 59, 175, 204, 216, 142, 83, 121, 67, 60, 191, 25, 192, 227, 205, 70, 52, 68, 217, 24, 201, 88, 46, 72, 42, 22, 215, 223, 214, 6, 164, 243, 153, 88, 123, 230, 232, 36, 69, 242, 43, 144, 198, 218, 250, 187, 3, 4, 201, 223, 248, 134, 204, 6, 19, 76, 11, 133, 189, 135, 220, 185, 102, 133, 228, 43, 143, 62, 249, 58, 204, 6, 109, 76, 139, 53, 123, 175, 128, 215, 95, 169, 10, 136, 74, 135, 59, 96, 86, 24, 188, 187, 212, 45, 158, 192, 130, 98, 86, 185, 242, 14, 32, 74, 245, 34, 98, 118, 24, 97, 90, 96, 36, 43, 177, 99, 248, 27, 107, 25, 235, 177, 106, 189, 8, 152, 29, 246, 112, 237, 37, 68, 114, 1, 11, 51, 158, 32, 202, 155, 239, 29, 179, 132, 255, 14, 223, 45, 48, 146, 213, 184, 103, 208, 242, 230, 61, 144, 100, 163, 32, 221, 226, 156, 225, 197, 218, 195, 150, 92, 96, 203, 41, 142, 233, 80, 222, 103, 182, 104, 226, 218, 195, 215, 33, 85, 30, 16, 150, 77, 56, 166, 207, 17, 143, 81, 132, 157, 80, 53, 9, 122, 157, 46, 35, 25, 136, 65, 78, 254, 190, 87, 176, 89, 38, 118, 30, 209, 148, 71, 148, 137, 209, 212, 117, 221, 233, 200, 99, 210, 116, 39, 231, 127, 228, 108, 232, 147, 247, 200, 211, 180, 180, 40, 146, 101, 194, 49, 149, 23, 13, 150, 74, 112, 230, 10, 206, 184, 116, 10, 76, 93, 193, 79, 106, 154, 163, 71, 68, 90, 200, 113, 87, 123, 147, 43, 237, 128, 26, 223, 226, 146, 211, 221, 133, 83, 247, 130, 105, 151, 73, 209, 57, 118, 47, 56, 35, 198, 63, 32, 210, 66, 150, 29, 226, 42, 49, 115, 231, 33, 227, 89, 55, 94, 224, 124, 150, 198, 169, 139, 156, 50, 25, 188, 51, 23, 161, 178, 104, 57, 147, 31, 122, 239, 199, 112, 153, 34, 220, 126, 53, 144, 1, 21, 207, 45, 76, 228, 35, 217, 113, 151, 233, 51, 9, 34, 119, 137, 99, 98, 99, 30, 60, 66, 206, 83, 255, 40, 171, 230, 218, 53, 141, 220, 1, 21, 102, 254, 249, 168, 69, 50, 95, 80, 113, 144, 145, 9, 147, 224, 167, 187, 204, 144, 104, 202, 232, 248, 121, 228, 177, 57, 51, 32, 48, 255, 38, 183, 5, 82, 224, 24, 207, 241, 156, 119, 210, 55, 245, 52, 102, 108, 202, 104, 6, 110, 140, 159, 196, 75, 28, 74, 62, 104, 136, 0, 63, 2, 2, 211, 239, 203, 215, 55, 64, 129, 35, 246, 95, 242, 232, 33, 146, 26, 201, 117, 55, 142, 199, 72, 28, 87, 229, 223, 133, 163, 228, 161, 144, 156, 221, 178, 166, 111, 37, 183, 42, 160, 192, 123, 118, 33, 185, 141, 142, 211, 19, 32, 112, 227, 244, 24, 201, 109, 55, 198, 49, 209, 168, 31, 46, 214, 94, 67, 72, 206, 110, 185, 162, 229, 187, 223, 230, 54, 40, 48, 99, 11, 201, 206, 129, 228, 51, 103, 232, 198, 233, 50, 146, 166, 154, 228, 197, 230, 27, 161, 228, 172, 185, 188, 173, 225, 40, 41, 41, 29, 33, 39, 108, 73, 242, 80, 242, 19, 170, 39, 107, 12, 225, 110, 140, 51, 66, 242, 104, 177, 246, 132, 100, 193, 9, 100, 226, 110, 254, 69, 78, 173, 32, 31, 45, 75, 110, 45, 36, 135, 68, 85, 32, 182, 24, 185, 43, 39, 132, 228, 104, 177, 246, 80, 114, 246, 88, 174, 162, 29, 179, 229, 13, 7, 25, 37, 59, 19, 201, 183, 228, 161, 108, 31, 67, 38, 238, 50, 45, 150, 74, 216, 90, 172, 61, 148, 76, 140, 178, 193, 34, 119, 29, 148, 56, 138, 75, 30, 146, 123, 79, 48, 152, 186, 200, 212, 99, 18, 240, 99, 50, 45, 144, 48, 88, 172, 61, 148, 76, 140, 178, 185, 138, 113, 99, 23, 84, 24, 179, 184, 228, 166, 236, 131, 125, 195, 69, 110, 51, 41, 70, 75, 33, 222, 161, 36, 115, 113, 88, 143, 132, 100, 100, 12, 217, 216, 189, 145, 227, 210, 187, 7, 74, 204, 98, 146, 49, 47, 90, 10, 202, 70, 76, 14, 31, 207, 196, 6, 35, 37, 191, 19, 107, 111, 85, 242, 12, 50, 114, 175, 100, 231, 197, 2, 59, 50, 74, 142, 164, 191, 161, 70, 83, 145, 21, 17, 147, 102, 40, 18, 99, 218, 100, 180, 228, 137, 88, 123, 40, 153, 200, 11, 146, 154, 225, 107, 26, 57, 90, 149, 252, 255, 180, 30, 48, 26, 175, 49, 57, 157, 160, 1, 25, 6, 209, 228, 116, 212, 242, 25, 73, 143, 143, 196, 218, 91, 149, 236, 67, 102, 182, 114, 10, 228, 10, 40, 194, 46, 73, 30, 89, 253, 80, 141, 146, 135, 98, 237, 173, 74, 102, 144, 153, 202, 13, 147, 129, 140, 140, 47, 75, 110, 99, 185, 176, 8, 231, 145, 88, 123, 210, 146, 77, 197, 242, 77, 160, 160, 37, 139, 211, 122, 200, 44, 195, 121, 67, 172, 189, 60, 37, 195, 77, 35, 13, 153, 142, 11, 81, 149, 35, 102, 23, 159, 243, 182, 88, 123, 185, 74, 134, 235, 6, 159, 133, 16, 255, 178, 228, 22, 190, 92, 88, 195, 227, 188, 41, 214, 158, 218, 226, 211, 254, 84, 84, 5, 26, 186, 93, 136, 188, 8, 152, 93, 6, 156, 239, 139, 181, 71, 84, 56, 85, 170, 6, 218, 27, 125, 140, 136, 188, 232, 50, 187, 212, 57, 239, 139, 181, 167, 126, 140, 104, 236, 113, 155, 187, 144, 133, 147, 85, 201, 226, 180, 246, 152, 93, 186, 115, 201, 79, 163, 36, 201, 39, 112, 53, 118, 175, 18, 24, 59, 144, 13, 63, 38, 89, 48, 177, 94, 147, 67, 206, 131, 131, 70, 130, 100, 31, 174, 74, 213, 88, 88, 32, 179, 4, 201, 209, 1, 179, 12, 159, 51, 76, 146, 60, 131, 43, 179, 101, 170, 89, 32, 99, 63, 38, 89, 96, 251, 22, 241, 249, 156, 70, 146, 100, 144, 68, 71, 96, 212, 32, 51, 179, 4, 201, 182, 107, 178, 23, 151, 236, 19, 131, 172, 72, 205, 216, 25, 130, 28, 93, 150, 188, 199, 236, 82, 79, 146, 172, 222, 223, 114, 61, 73, 74, 15, 32, 59, 24, 24, 40, 185, 195, 236, 18, 174, 145, 60, 134, 92, 120, 80, 210, 240, 85, 143, 224, 196, 47, 154, 228, 94, 178, 228, 19, 200, 137, 59, 218, 31, 56, 17, 180, 92, 44, 201, 62, 95, 149, 156, 221, 113, 94, 143, 158, 85, 184, 42, 227, 127, 185, 236, 23, 69, 242, 96, 69, 178, 48, 63, 134, 252, 168, 154, 220, 122, 241, 159, 117, 22, 69, 114, 24, 151, 220, 198, 94, 145, 27, 183, 52, 188, 212, 211, 140, 103, 126, 97, 36, 247, 226, 146, 91, 140, 189, 31, 67, 190, 220, 211, 115, 235, 209, 156, 236, 21, 67, 178, 199, 87, 36, 231, 22, 198, 89, 239, 190, 242, 54, 228, 198, 151, 11, 201, 125, 102, 147, 250, 138, 228, 79, 160, 129, 237, 178, 150, 250, 70, 243, 186, 24, 146, 69, 36, 7, 186, 36, 171, 215, 184, 205, 10, 228, 6, 74, 118, 152, 69, 124, 190, 34, 249, 16, 116, 80, 217, 212, 241, 237, 148, 230, 176, 16, 146, 235, 171, 146, 199, 160, 133, 155, 58, 238, 16, 154, 241, 66, 178, 199, 236, 17, 10, 201, 253, 133, 100, 208, 67, 229, 134, 201, 65, 70, 246, 47, 36, 15, 88, 118, 188, 65, 189, 123, 78, 125, 48, 240, 178, 167, 5, 223, 187, 112, 252, 17, 52, 81, 179, 49, 200, 75, 245, 162, 158, 77, 111, 183, 23, 244, 157, 24, 253, 160, 87, 247, 179, 164, 5, 111, 226, 222, 211, 196, 198, 13, 27, 131, 140, 155, 47, 204, 16, 165, 61, 244, 187, 66, 167, 55, 80, 185, 68, 4, 45, 220, 123, 186, 168, 217, 24, 100, 220, 124, 129, 242, 107, 131, 147, 78, 191, 231, 73, 95, 34, 130, 182, 222, 189, 39, 157, 202, 53, 200, 155, 76, 69, 217, 15, 59, 142, 4, 157, 174, 194, 218, 227, 1, 70, 178, 62, 110, 154, 235, 200, 8, 134, 178, 167, 160, 184, 239, 72, 210, 239, 74, 175, 61, 222, 215, 30, 201, 114, 93, 249, 14, 228, 13, 134, 50, 234, 32, 64, 197, 82, 154, 235, 244, 15, 46, 4, 77, 253, 145, 12, 18, 163, 92, 222, 133, 188, 193, 166, 204, 37, 179, 184, 227, 40, 18, 120, 82, 131, 140, 145, 188, 1, 26, 217, 165, 94, 48, 238, 67, 254, 96, 94, 200, 253, 135, 66, 78, 6, 66, 162, 191, 25, 136, 100, 228, 62, 249, 245, 84, 3, 175, 21, 206, 145, 65, 223, 201, 68, 199, 163, 7, 121, 31, 211, 66, 43, 15, 168, 15, 34, 58, 56, 148, 207, 139, 208, 201, 76, 157, 72, 100, 237, 105, 129, 92, 39, 126, 252, 166, 3, 204, 11, 234, 78, 227, 206, 21, 8, 137, 65, 238, 96, 90, 104, 102, 39, 245, 16, 1, 29, 72, 31, 125, 126, 224, 92, 9, 158, 210, 145, 77, 156, 123, 200, 45, 99, 23, 53, 50, 150, 186, 71, 252, 142, 115, 69, 130, 164, 99, 15, 215, 158, 169, 180, 72, 109, 113, 229, 10, 104, 129, 170, 202, 232, 56, 127, 203, 61, 206, 141, 61, 14, 33, 187, 101, 83, 253, 13, 193, 213, 215, 87, 112, 252, 227, 25, 73, 135, 178, 92, 79, 24, 228, 49, 232, 38, 237, 147, 234, 93, 208, 5, 174, 190, 80, 126, 142, 63, 60, 38, 121, 70, 204, 178, 199, 141, 14, 50, 114, 119, 157, 227, 91, 160, 143, 67, 39, 189, 96, 120, 9, 89, 241, 135, 150, 252, 53, 33, 49, 252, 196, 176, 232, 52, 112, 237, 153, 224, 150, 177, 181, 135, 224, 247, 17, 78, 159, 32, 217, 37, 227, 89, 130, 97, 33, 104, 97, 127, 51, 192, 218, 213, 87, 218, 6, 141, 224, 40, 215, 137, 19, 36, 171, 100, 164, 158, 16, 22, 134, 7, 25, 182, 75, 198, 174, 61, 4, 71, 217, 25, 72, 62, 8, 189, 160, 249, 157, 246, 96, 228, 99, 88, 236, 53, 12, 15, 242, 186, 171, 175, 10, 90, 57, 68, 7, 161, 220, 247, 143, 169, 75, 242, 211, 89, 67, 207, 195, 51, 4, 231, 24, 7, 89, 63, 85, 131, 37, 25, 249, 178, 252, 61, 195, 23, 134, 189, 180, 239, 31, 103, 46, 201, 105, 74, 101, 14, 2, 97, 56, 216, 107, 163, 227, 79, 96, 138, 74, 153, 248, 141, 161, 22, 14, 227, 235, 233, 252, 175, 223, 119, 210, 56, 117, 73, 38, 206, 90, 230, 155, 174, 221, 154, 131, 134, 177, 35, 27, 97, 203, 96, 90, 32, 175, 29, 53, 70, 46, 73, 228, 172, 163, 217, 64, 108, 12, 114, 226, 43, 209, 166, 254, 131, 126, 188, 239, 40, 209, 58, 118, 9, 206, 20, 29, 127, 220, 0, 115, 108, 148, 13, 166, 5, 114, 232, 16, 168, 230, 197, 72, 210, 49, 110, 61, 147, 108, 153, 76, 11, 228, 139, 226, 40, 79, 51, 14, 114, 179, 109, 61, 44, 32, 161, 95, 148, 42, 160, 29, 245, 192, 136, 48, 48, 126, 125, 127, 245, 230, 243, 231, 55, 175, 190, 255, 194, 255, 3, 177, 189, 214, 177, 253, 176, 152, 83, 41, 153, 188, 68, 144, 195, 108, 187, 239, 215, 155, 151, 176, 224, 229, 43, 225, 249, 56, 90, 155, 21, 69, 8, 11, 184, 124, 143, 212, 192, 8, 234, 13, 227, 120, 174, 248, 45, 172, 240, 249, 87, 186, 227, 34, 132, 197, 95, 238, 237, 166, 53, 117, 32, 10, 227, 184, 233, 21, 223, 160, 218, 77, 109, 225, 194, 253, 22, 103, 211, 144, 77, 23, 195, 204, 46, 32, 74, 184, 8, 247, 5, 133, 172, 90, 87, 74, 215, 126, 4, 191, 240, 61, 145, 148, 7, 6, 211, 26, 239, 52, 231, 152, 255, 78, 112, 245, 99, 56, 206, 76, 34, 247, 224, 33, 223, 83, 51, 173, 247, 53, 149, 255, 190, 253, 161, 19, 253, 122, 171, 107, 188, 165, 198, 187, 247, 111, 57, 155, 106, 109, 106, 42, 111, 87, 116, 162, 141, 173, 60, 131, 156, 206, 173, 169, 249, 70, 222, 203, 89, 77, 21, 189, 48, 79, 189, 14, 63, 201, 107, 117, 168, 250, 174, 75, 180, 12, 228, 162, 177, 247, 42, 64, 115, 237, 92, 221, 197, 108, 14, 43, 66, 209, 166, 146, 216, 232, 50, 166, 169, 119, 57, 212, 96, 187, 132, 149, 107, 102, 15, 155, 205, 138, 219, 108, 14, 230, 163, 235, 10, 53, 63, 122, 156, 119, 232, 235, 81, 147, 69, 219, 196, 66, 42, 88, 198, 105, 51, 38, 234, 213, 120, 240, 20, 94, 57, 177, 161, 141, 109, 162, 207, 152, 134, 29, 116, 71, 205, 182, 102, 101, 103, 190, 96, 25, 171, 56, 233, 17, 154, 192, 248, 27, 53, 93, 161, 156, 88, 19, 144, 88, 165, 49, 134, 50, 70, 114, 131, 241, 196, 8, 198, 108, 108, 242, 65, 187, 136, 4, 235, 9, 236, 146, 125, 101, 102, 14, 66, 172, 113, 30, 31, 27, 139, 236, 146, 161, 188, 43, 143, 98, 230, 63, 7, 133, 102, 99, 154, 226, 154, 147, 68, 42, 149, 19, 103, 205, 165, 139, 248, 157, 88, 215, 25, 132, 80, 23, 23, 23, 66, 189, 48, 195, 229, 206, 133, 176, 118, 99, 162, 62, 158, 60, 201, 20, 29, 55, 25, 112, 14, 178, 134, 209, 118, 77, 242, 221, 226, 40, 34, 85, 100, 97, 2, 232, 207, 128, 109, 114, 78, 54, 34, 5, 13, 241, 198, 172, 88, 123, 227, 219, 56, 107, 141, 169, 224, 101, 95, 151, 156, 151, 51, 191, 73, 67, 147, 18, 185, 75, 114, 237, 227, 220, 157, 70, 114, 172, 141, 248, 99, 82, 39, 27, 199, 58, 144, 203, 7, 125, 125, 146, 139, 145, 227, 216, 36, 161, 115, 38, 214, 130, 76, 125, 252, 238, 9, 197, 200, 92, 110, 3, 225, 98, 25, 235, 65, 190, 197, 121, 79, 42, 70, 230, 48, 51, 2, 228, 242, 88, 19, 242, 24, 175, 181, 8, 197, 200, 101, 198, 133, 155, 20, 170, 144, 7, 184, 231, 148, 234, 53, 139, 193, 28, 134, 88, 25, 242, 157, 248, 230, 130, 94, 103, 105, 28, 128, 25, 196, 234, 144, 187, 55, 194, 155, 11, 70, 126, 98, 101, 100, 236, 229, 196, 150, 103, 177, 66, 100, 234, 227, 50, 89, 38, 70, 126, 154, 45, 226, 24, 229, 214, 93, 188, 136, 117, 34, 247, 240, 55, 84, 153, 24, 153, 123, 134, 204, 69, 206, 174, 88, 196, 106, 145, 31, 113, 115, 33, 20, 35, 115, 115, 31, 40, 63, 127, 60, 91, 83, 8, 43, 70, 30, 74, 239, 224, 24, 249, 216, 50, 139, 253, 242, 252, 211, 171, 54, 87, 2, 235, 70, 30, 8, 95, 15, 189, 35, 99, 48, 251, 177, 52, 168, 145, 179, 236, 123, 4, 214, 143, 60, 193, 251, 156, 34, 1, 25, 35, 227, 116, 89, 150, 166, 139, 180, 40, 195, 162, 191, 14, 228, 31, 252, 236, 137, 4, 3, 50, 183, 76, 207, 212, 187, 50, 100, 186, 17, 222, 38, 23, 200, 104, 222, 78, 228, 126, 103, 68, 146, 1, 185, 156, 204, 109, 68, 30, 9, 159, 69, 74, 100, 52, 207, 218, 135, 220, 19, 62, 139, 16, 144, 193, 220, 54, 228, 199, 206, 152, 36, 3, 50, 154, 61, 103, 237, 66, 30, 203, 30, 248, 128, 236, 51, 183, 9, 121, 40, 123, 224, 3, 178, 207, 60, 79, 219, 131, 252, 160, 20, 153, 91, 46, 218, 130, 60, 232, 76, 73, 48, 32, 87, 44, 231, 86, 32, 79, 101, 175, 46, 42, 145, 49, 157, 211, 235, 71, 158, 116, 190, 147, 104, 64, 174, 94, 207, 139, 236, 186, 145, 255, 81, 119, 55, 45, 106, 67, 81, 24, 199, 77, 91, 250, 6, 211, 22, 233, 27, 20, 250, 45, 238, 129, 116, 115, 161, 46, 2, 89, 148, 134, 98, 177, 218, 169, 4, 220, 184, 40, 40, 81, 144, 33, 193, 141, 73, 20, 241, 165, 139, 110, 134, 210, 207, 90, 219, 14, 62, 76, 102, 156, 152, 123, 207, 53, 206, 239, 35, 252, 57, 156, 196, 168, 55, 111, 74, 120, 62, 100, 117, 252, 95, 231, 231, 225, 98, 17, 187, 67, 57, 70, 205, 27, 67, 43, 76, 244, 207, 90, 173, 22, 70, 209, 249, 249, 175, 95, 126, 71, 148, 232, 197, 97, 191, 70, 109, 250, 193, 164, 74, 68, 114, 11, 145, 115, 67, 127, 173, 191, 255, 252, 177, 88, 228, 11, 145, 109, 219, 103, 131, 192, 111, 138, 82, 220, 59, 92, 228, 78, 123, 242, 156, 46, 184, 10, 145, 209, 186, 254, 190, 81, 44, 114, 98, 95, 24, 245, 219, 37, 204, 244, 129, 34, 91, 126, 127, 19, 24, 22, 219, 200, 221, 130, 141, 177, 168, 115, 35, 127, 217, 70, 78, 237, 13, 132, 246, 45, 113, 16, 136, 44, 140, 107, 182, 39, 148, 17, 109, 35, 123, 57, 53, 53, 46, 136, 136, 252, 219, 206, 24, 28, 182, 179, 233, 200, 150, 143, 194, 144, 110, 35, 207, 80, 141, 121, 158, 27, 181, 173, 181, 13, 152, 103, 177, 211, 237, 138, 220, 9, 158, 19, 192, 42, 115, 229, 211, 233, 220, 200, 93, 201, 181, 15, 54, 192, 40, 104, 138, 67, 48, 27, 25, 67, 156, 181, 148, 153, 165, 172, 163, 254, 57, 103, 91, 132, 246, 46, 131, 158, 48, 207, 100, 100, 191, 74, 187, 197, 219, 200, 195, 2, 57, 139, 60, 230, 248, 88, 203, 92, 247, 74, 203, 108, 46, 114, 27, 137, 1, 82, 166, 81, 198, 199, 239, 29, 131, 140, 149, 188, 203, 153, 47, 204, 50, 19, 25, 83, 188, 211, 90, 50, 92, 250, 0, 95, 15, 98, 144, 225, 212, 190, 217, 153, 233, 105, 54, 113, 159, 220, 171, 82, 174, 152, 119, 148, 177, 52, 48, 200, 216, 22, 185, 6, 29, 97, 18, 127, 228, 102, 159, 246, 48, 69, 228, 225, 248, 29, 147, 122, 3, 183, 22, 48, 183, 247, 240, 195, 18, 166, 240, 127, 226, 179, 218, 14, 237, 195, 113, 179, 11, 131, 115, 53, 55, 106, 144, 216, 123, 25, 249, 194, 148, 123, 204, 79, 225, 58, 85, 218, 83, 42, 193, 123, 199, 151, 249, 35, 150, 5, 6, 121, 47, 131, 166, 48, 227, 5, 235, 243, 100, 43, 32, 40, 48, 202, 88, 203, 12, 234, 104, 140, 65, 222, 203, 168, 45, 128, 53, 242, 51, 193, 6, 99, 92, 96, 43, 243, 87, 254, 180, 105, 12, 75, 27, 74, 26, 230, 103, 140, 223, 241, 249, 14, 21, 178, 144, 48, 100, 172, 220, 149, 46, 26, 255, 182, 11, 25, 245, 4, 191, 167, 108, 223, 86, 91, 125, 42, 104, 46, 141, 204, 178, 39, 37, 42, 71, 167, 118, 65, 129, 37, 184, 189, 228, 57, 211, 23, 171, 162, 224, 194, 96, 191, 250, 181, 60, 249, 79, 156, 89, 22, 101, 174, 140, 135, 44, 191, 32, 42, 190, 42, 240, 88, 25, 102, 12, 247, 203, 227, 153, 148, 18, 149, 87, 54, 148, 183, 50, 94, 241, 252, 22, 46, 32, 37, 14, 214, 50, 207, 98, 238, 74, 112, 241, 89, 175, 40, 95, 176, 122, 162, 245, 171, 78, 172, 99, 69, 203, 88, 94, 226, 141, 181, 199, 24, 220, 228, 155, 173, 40, 16, 156, 94, 87, 78, 244, 27, 79, 72, 217, 220, 149, 153, 97, 110, 41, 39, 246, 228, 101, 161, 131, 200, 69, 245, 5, 163, 19, 253, 95, 218, 55, 171, 68, 90, 149, 89, 50, 183, 188, 225, 149, 198, 68, 234, 149, 7, 150, 96, 115, 95, 253, 63, 35, 104, 172, 101, 30, 75, 253, 204, 227, 77, 226, 140, 200, 33, 58, 146, 202, 15, 148, 255, 253, 132, 198, 154, 150, 11, 9, 42, 187, 185, 213, 157, 201, 43, 146, 239, 68, 122, 149, 207, 216, 42, 223, 173, 84, 222, 10, 13, 205, 231, 164, 205, 137, 228, 85, 67, 116, 206, 41, 140, 33, 150, 48, 37, 162, 99, 169, 124, 175, 82, 41, 252, 132, 136, 117, 142, 241, 68, 14, 208, 185, 155, 19, 122, 140, 194, 151, 196, 115, 250, 239, 40, 54, 198, 27, 197, 211, 80, 209, 152, 199, 58, 150, 144, 9, 221, 29, 183, 174, 25, 224, 77, 223, 217, 80, 94, 47, 113, 136, 142, 168, 242, 75, 173, 119, 229, 88, 85, 226, 226, 36, 242, 6, 195, 153, 183, 137, 125, 193, 243, 144, 23, 32, 94, 17, 232, 86, 22, 12, 94, 233, 156, 119, 97, 77, 136, 209, 122, 33, 115, 185, 50, 31, 198, 24, 202, 189, 95, 126, 162, 115, 114, 75, 159, 120, 77, 99, 253, 200, 209, 156, 0, 108, 101, 109, 161, 237, 68, 227, 12, 162, 128, 184, 57, 83, 87, 47, 114, 184, 166, 235, 157, 218, 202, 124, 161, 235, 113, 69, 249, 152, 0, 159, 128, 49, 115, 172, 30, 57, 66, 98, 206, 202, 29, 161, 199, 186, 163, 252, 2, 179, 142, 67, 70, 124, 95, 133, 74, 145, 221, 116, 73, 192, 89, 121, 212, 20, 90, 222, 40, 159, 104, 143, 27, 11, 126, 203, 52, 46, 26, 57, 90, 57, 148, 113, 52, 183, 24, 15, 149, 207, 168, 158, 144, 81, 243, 116, 177, 119, 100, 23, 133, 13, 85, 14, 132, 142, 71, 170, 167, 206, 182, 201, 184, 229, 42, 137, 115, 35, 15, 195, 116, 253, 157, 192, 80, 229, 158, 208, 112, 162, 240, 222, 0, 44, 100, 243, 150, 235, 105, 180, 216, 17, 217, 13, 147, 233, 60, 27, 248, 24, 215, 242, 227, 202, 95, 119, 44, 145, 161, 183, 144, 249, 83, 175, 166, 105, 18, 69, 97, 24, 46, 194, 48, 74, 146, 116, 186, 154, 59, 84, 220, 105, 41, 107, 249, 174, 218, 235, 181, 2, 186, 165, 190, 149, 240, 153, 228, 153, 218, 123, 193, 123, 116, 107, 253, 97, 239, 108, 90, 226, 8, 130, 48, 92, 51, 238, 124, 236, 68, 103, 39, 16, 119, 7, 6, 60, 229, 160, 11, 30, 66, 176, 15, 9, 196, 163, 16, 33, 151, 16, 2, 11, 70, 132, 128, 7, 89, 80, 146, 67, 8, 70, 16, 66, 16, 2, 201, 53, 57, 248, 95, 179, 32, 164, 68, 119, 103, 187, 122, 186, 219, 154, 233, 126, 110, 94, 31, 138, 183, 171, 170, 219, 157, 15, 246, 3, 99, 116, 227, 24, 183, 23, 28, 195, 98, 49, 237, 8, 140, 114, 241, 23, 115, 186, 24, 22, 15, 19, 24, 153, 202, 183, 159, 62, 138, 86, 99, 59, 48, 122, 33, 40, 124, 205, 229, 187, 104, 53, 7, 150, 183, 158, 3, 149, 79, 164, 30, 137, 150, 99, 111, 36, 193, 121, 143, 56, 243, 5, 79, 68, 219, 81, 191, 88, 165, 10, 198, 121, 15, 238, 174, 148, 187, 123, 234, 97, 96, 216, 91, 45, 71, 112, 3, 225, 198, 122, 178, 39, 218, 143, 250, 217, 23, 236, 80, 169, 0, 145, 189, 76, 61, 19, 29, 224, 192, 98, 27, 55, 66, 199, 24, 202, 157, 110, 223, 30, 160, 148, 215, 0, 137, 102, 127, 187, 82, 200, 51, 236, 109, 150, 35, 0, 164, 216, 113, 167, 144, 49, 48, 140, 151, 114, 1, 183, 233, 187, 84, 200, 66, 216, 74, 229, 62, 32, 114, 143, 47, 38, 162, 51, 216, 42, 229, 24, 110, 19, 246, 118, 92, 232, 145, 45, 150, 50, 46, 46, 144, 212, 133, 97, 15, 57, 176, 50, 246, 165, 128, 200, 53, 113, 135, 162, 75, 152, 222, 96, 96, 3, 71, 106, 226, 90, 188, 171, 215, 217, 43, 127, 86, 108, 224, 112, 221, 217, 205, 75, 39, 189, 165, 60, 33, 175, 57, 145, 220, 153, 254, 237, 6, 11, 255, 227, 151, 3, 34, 181, 137, 11, 186, 176, 26, 178, 124, 244, 37, 112, 143, 194, 161, 99, 175, 81, 41, 159, 146, 199, 61, 164, 236, 242, 173, 147, 206, 82, 62, 35, 220, 83, 223, 37, 113, 100, 218, 251, 143, 242, 212, 71, 239, 45, 144, 129, 83, 105, 97, 60, 47, 134, 48, 143, 210, 153, 38, 217, 74, 94, 172, 193, 60, 162, 192, 169, 180, 192, 82, 54, 146, 23, 189, 8, 230, 146, 58, 149, 22, 134, 243, 34, 133, 249, 196, 14, 245, 22, 152, 23, 134, 230, 145, 24, 22, 80, 185, 50, 137, 96, 41, 155, 154, 71, 214, 67, 88, 64, 238, 200, 222, 162, 113, 94, 76, 200, 35, 53, 146, 56, 176, 174, 215, 146, 23, 71, 244, 145, 26, 25, 186, 20, 201, 51, 76, 52, 113, 216, 36, 147, 142, 190, 64, 116, 21, 99, 161, 28, 67, 13, 149, 75, 145, 140, 121, 161, 59, 148, 171, 16, 106, 40, 93, 138, 228, 25, 134, 66, 185, 132, 58, 86, 54, 92, 138, 100, 245, 188, 248, 68, 157, 246, 150, 190, 114, 233, 210, 53, 53, 65, 178, 250, 77, 95, 31, 234, 73, 92, 89, 92, 52, 11, 229, 47, 42, 253, 27, 146, 58, 116, 238, 25, 58, 249, 82, 88, 70, 230, 200, 118, 200, 224, 201, 151, 193, 82, 210, 54, 220, 83, 79, 175, 206, 95, 75, 115, 126, 53, 213, 30, 202, 135, 42, 131, 8, 146, 181, 160, 185, 192, 31, 94, 150, 227, 124, 79, 183, 228, 51, 165, 66, 70, 134, 252, 155, 139, 111, 187, 68, 126, 80, 67, 89, 189, 189, 24, 128, 12, 25, 251, 161, 250, 231, 46, 153, 95, 214, 218, 139, 24, 164, 24, 114, 127, 95, 127, 69, 151, 252, 91, 119, 123, 161, 86, 200, 72, 198, 189, 131, 251, 67, 151, 252, 87, 119, 123, 49, 81, 75, 100, 36, 101, 222, 193, 113, 144, 124, 170, 214, 90, 32, 25, 243, 245, 144, 138, 100, 221, 237, 197, 145, 98, 33, 35, 35, 222, 109, 50, 7, 201, 135, 138, 195, 30, 146, 244, 188, 100, 68, 126, 15, 23, 36, 64, 160, 207, 122, 22, 185, 126, 79, 230, 218, 202, 52, 210, 7, 10, 209, 58, 231, 23, 90, 39, 175, 200, 28, 211, 167, 17, 186, 228, 141, 8, 72, 148, 94, 50, 34, 59, 242, 149, 64, 164, 96, 60, 85, 51, 149, 92, 132, 64, 36, 243, 146, 107, 249, 90, 59, 80, 83, 39, 18, 134, 79, 180, 120, 74, 78, 129, 78, 210, 243, 146, 41, 146, 123, 9, 32, 212, 179, 79, 240, 131, 165, 228, 18, 148, 24, 120, 201, 242, 146, 139, 16, 148, 200, 2, 47, 89, 90, 114, 6, 138, 228, 94, 178, 172, 228, 62, 168, 18, 86, 94, 178, 156, 228, 106, 5, 148, 201, 188, 100, 57, 201, 49, 168, 128, 139, 162, 23, 138, 96, 235, 199, 90, 242, 155, 151, 106, 172, 54, 13, 11, 36, 44, 188, 228, 122, 201, 24, 22, 234, 100, 129, 151, 188, 76, 114, 144, 65, 67, 114, 47, 121, 153, 228, 28, 154, 18, 142, 189, 228, 122, 201, 131, 16, 26, 243, 244, 157, 151, 92, 39, 185, 151, 128, 6, 182, 189, 228, 58, 201, 107, 160, 133, 77, 110, 146, 143, 247, 201, 24, 147, 60, 2, 61, 68, 99, 110, 146, 249, 84, 114, 129, 221, 91, 227, 88, 246, 146, 231, 75, 222, 72, 64, 27, 219, 111, 89, 73, 190, 164, 75, 190, 52, 35, 57, 6, 141, 60, 107, 187, 228, 169, 17, 201, 57, 232, 36, 92, 229, 36, 89, 208, 37, 11, 19, 146, 135, 160, 151, 199, 99, 78, 146, 247, 169, 142, 247, 77, 72, 174, 34, 64, 52, 29, 126, 140, 36, 147, 27, 229, 19, 3, 146, 241, 208, 211, 121, 248, 241, 145, 76, 14, 229, 75, 253, 146, 131, 24, 12, 240, 156, 143, 100, 113, 65, 77, 11, 253, 146, 75, 48, 194, 22, 31, 201, 196, 188, 56, 214, 47, 121, 11, 204, 16, 110, 178, 145, 60, 37, 57, 190, 152, 106, 151, 188, 21, 130, 33, 162, 49, 23, 201, 180, 82, 62, 17, 186, 37, 111, 70, 96, 140, 71, 99, 46, 146, 167, 23, 148, 66, 214, 45, 121, 245, 95, 123, 119, 179, 154, 58, 16, 134, 113, 252, 69, 113, 149, 108, 242, 177, 17, 50, 11, 201, 183, 160, 98, 148, 185, 4, 21, 2, 65, 40, 186, 58, 123, 11, 37, 183, 32, 228, 206, 207, 145, 22, 166, 61, 181, 38, 149, 73, 242, 204, 232, 255, 18, 126, 188, 188, 206, 196, 64, 12, 106, 49, 99, 15, 130, 204, 79, 191, 217, 200, 146, 145, 205, 128, 90, 45, 56, 130, 32, 243, 188, 249, 209, 66, 50, 242, 46, 160, 150, 91, 28, 64, 144, 203, 115, 211, 101, 33, 25, 121, 183, 160, 214, 18, 202, 24, 200, 188, 58, 55, 52, 150, 139, 188, 89, 83, 7, 173, 15, 24, 200, 188, 106, 98, 92, 113, 185, 200, 155, 57, 181, 154, 80, 198, 64, 22, 179, 124, 191, 49, 47, 48, 141, 47, 202, 24, 200, 181, 202, 121, 201, 107, 145, 65, 141, 47, 202, 24, 200, 188, 204, 111, 94, 66, 74, 94, 143, 140, 106, 124, 81, 198, 64, 190, 53, 204, 121, 197, 185, 92, 228, 221, 156, 58, 109, 113, 4, 65, 230, 229, 233, 42, 243, 249, 196, 27, 85, 96, 157, 221, 190, 22, 236, 65, 144, 255, 117, 202, 107, 166, 88, 10, 178, 25, 80, 231, 5, 83, 24, 100, 206, 203, 234, 45, 63, 127, 140, 112, 254, 86, 149, 188, 113, 5, 178, 49, 145, 49, 197, 65, 126, 151, 190, 36, 124, 229, 34, 39, 6, 245, 210, 200, 196, 66, 22, 201, 71, 78, 70, 212, 83, 131, 244, 81, 144, 211, 1, 245, 215, 242, 229, 17, 144, 95, 151, 212, 107, 179, 131, 254, 200, 155, 25, 245, 220, 98, 175, 59, 178, 185, 160, 222, 51, 76, 189, 145, 19, 131, 0, 26, 166, 58, 35, 47, 135, 132, 209, 234, 160, 43, 242, 102, 69, 48, 5, 83, 61, 145, 17, 214, 177, 104, 148, 232, 136, 156, 90, 132, 213, 234, 160, 27, 50, 210, 170, 16, 43, 67, 47, 100, 51, 32, 192, 134, 233, 139, 70, 200, 48, 167, 138, 255, 155, 239, 117, 65, 54, 231, 4, 155, 149, 232, 129, 12, 247, 139, 247, 181, 217, 81, 125, 100, 179, 247, 103, 21, 117, 25, 137, 234, 200, 41, 196, 61, 186, 166, 245, 84, 101, 100, 228, 109, 252, 185, 225, 242, 143, 170, 200, 155, 229, 136, 84, 41, 48, 213, 68, 78, 32, 207, 198, 63, 54, 219, 171, 135, 108, 2, 94, 241, 110, 55, 138, 213, 80, 46, 84, 220, 20, 34, 43, 228, 10, 244, 129, 252, 154, 170, 181, 41, 68, 78, 198, 225, 123, 71, 78, 160, 158, 105, 254, 178, 49, 227, 224, 21, 10, 29, 219, 126, 204, 7, 103, 46, 20, 184, 224, 53, 104, 2, 248, 17, 13, 17, 91, 13, 72, 139, 112, 167, 153, 249, 164, 79, 152, 187, 89, 43, 226, 75, 14, 220, 129, 46, 116, 72, 191, 172, 8, 232, 187, 48, 110, 164, 194, 179, 182, 123, 26, 122, 32, 91, 131, 121, 168, 127, 46, 73, 218, 26, 189, 143, 243, 86, 203, 61, 1, 53, 206, 154, 15, 177, 200, 136, 109, 222, 75, 182, 182, 155, 248, 106, 78, 247, 191, 130, 110, 164, 255, 154, 184, 226, 220, 225, 60, 219, 209, 152, 30, 52, 39, 102, 188, 131, 88, 252, 128, 51, 252, 57, 107, 210, 238, 121, 195, 13, 39, 216, 47, 81, 116, 149, 19, 103, 173, 64, 187, 217, 163, 143, 240, 55, 232, 208, 150, 186, 132, 195, 39, 240, 213, 44, 63, 202, 92, 25, 3, 28, 249, 207, 21, 81, 35, 29, 135, 204, 189, 147, 151, 133, 241, 211, 183, 57, 245, 216, 139, 132, 117, 19, 221, 200, 27, 63, 121, 239, 196, 118, 124, 47, 142, 194, 140, 49, 219, 117, 183, 226, 45, 131, 173, 235, 218, 140, 101, 97, 20, 123, 190, 131, 142, 251, 23, 97, 210, 124, 27, 220, 190, 110, 68, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, true }
                });

            migrationBuilder.InsertData(
                table: "Putnik",
                columns: new[] { "ID", "DatumRegistracije", "DatumRodjenja", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Slika" },
                values: new object[] { 1, new DateTime(2020, 7, 15, 18, 35, 27, 973, DateTimeKind.Local).AddTicks(4722), new DateTime(1989, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile@mail.com", "Mobile", "mobile", "wMALKTYmL74ju10FSBgXqLXWRwQ=", "UKlofHqzbY1vOlg7NXGRKg==", "Test", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 1, 100, 0, 0, 1, 144, 8, 3, 0, 0, 0, 174, 198, 234, 29, 0, 0, 1, 221, 80, 76, 84, 69, 0, 0, 0, 246, 110, 89, 210, 108, 88, 189, 107, 90, 249, 110, 88, 235, 115, 94, 249, 110, 88, 249, 110, 88, 249, 110, 88, 249, 110, 88, 249, 110, 88, 137, 107, 94, 193, 166, 133, 249, 110, 88, 249, 110, 88, 249, 110, 88, 249, 110, 88, 136, 106, 95, 74, 105, 120, 131, 103, 97, 58, 105, 123, 249, 110, 88, 249, 110, 88, 249, 110, 88, 249, 110, 88, 126, 98, 87, 126, 96, 81, 249, 110, 88, 122, 98, 90, 80, 105, 119, 249, 110, 88, 117, 90, 75, 126, 97, 81, 125, 98, 86, 126, 97, 81, 126, 103, 100, 171, 138, 122, 97, 106, 116, 107, 106, 114, 114, 106, 113, 184, 160, 133, 177, 154, 130, 204, 177, 142, 130, 100, 84, 130, 100, 84, 172, 144, 126, 168, 139, 122, 170, 139, 122, 130, 100, 84, 174, 149, 128, 89, 105, 117, 172, 144, 125, 173, 142, 125, 249, 110, 88, 36, 104, 127, 249, 206, 155, 130, 100, 84, 32, 93, 114, 237, 194, 148, 213, 174, 133, 210, 173, 135, 192, 158, 124, 29, 181, 203, 243, 242, 242, 117, 90, 75, 70, 71, 71, 224, 185, 139, 218, 217, 217, 255, 255, 255, 244, 202, 152, 207, 170, 132, 49, 109, 129, 202, 166, 129, 197, 161, 126, 232, 234, 235, 30, 165, 187, 125, 96, 81, 119, 91, 76, 73, 119, 128, 247, 203, 153, 217, 179, 138, 239, 224, 209, 128, 98, 83, 235, 193, 147, 122, 94, 79, 228, 188, 144, 221, 182, 139, 96, 200, 215, 215, 177, 136, 207, 198, 188, 232, 109, 89, 239, 198, 151, 232, 192, 145, 35, 101, 123, 33, 96, 118, 163, 103, 93, 225, 155, 120, 183, 105, 94, 174, 142, 113, 162, 133, 107, 218, 108, 90, 246, 121, 96, 137, 105, 87, 33, 137, 159, 211, 172, 132, 240, 215, 188, 185, 152, 120, 32, 144, 166, 146, 115, 93, 37, 110, 132, 233, 133, 105, 240, 184, 140, 201, 108, 94, 120, 103, 108, 151, 123, 101, 144, 105, 104, 97, 99, 106, 243, 240, 237, 203, 153, 119, 214, 145, 113, 54, 95, 111, 87, 83, 79, 75, 97, 110, 249, 165, 126, 199, 211, 216, 186, 202, 208, 29, 174, 196, 239, 203, 165, 197, 103, 84, 34, 123, 146, 249, 191, 145, 218, 168, 130, 101, 106, 115, 222, 228, 230, 169, 191, 198, 150, 178, 187, 129, 166, 179, 243, 233, 224, 75, 75, 73, 80, 132, 150, 249, 138, 108, 209, 219, 223, 65, 122, 141, 111, 154, 168, 93, 140, 157, 130, 113, 99, 100, 94, 85, 194, 131, 106, 138, 92, 78, 216, 189, 161, 113, 103, 91, 104, 78, 74, 138, 193, 204, 125, 184, 196, 192, 183, 182, 252, 250, 248, 188, 159, 157, 63, 156, 174, 136, 163, 172, 127, 1, 205, 204, 0, 0, 0, 53, 116, 82, 78, 83, 0, 253, 4, 11, 242, 17, 68, 30, 167, 138, 48, 46, 254, 88, 121, 194, 204, 29, 253, 74, 253, 227, 183, 151, 104, 93, 182, 216, 145, 239, 236, 232, 205, 129, 162, 114, 85, 214, 192, 171, 244, 235, 253, 243, 232, 159, 140, 110, 222, 219, 227, 184, 132, 9, 109, 52, 73, 0, 0, 26, 222, 73, 68, 65, 84, 120, 218, 236, 217, 189, 142, 180, 32, 24, 5, 96, 50, 150, 84, 198, 10, 66, 194, 143, 165, 22, 150, 167, 228, 2, 164, 49, 222, 255, 181, 124, 126, 179, 187, 226, 174, 113, 150, 56, 144, 108, 128, 167, 157, 132, 226, 4, 15, 47, 12, 249, 91, 56, 35, 85, 98, 13, 160, 58, 82, 37, 213, 97, 195, 41, 169, 18, 210, 120, 50, 53, 230, 132, 56, 54, 117, 55, 167, 165, 176, 83, 236, 65, 170, 20, 70, 28, 140, 186, 37, 85, 124, 248, 129, 215, 237, 28, 93, 131, 147, 193, 212, 145, 46, 93, 200, 222, 104, 186, 186, 159, 35, 194, 133, 193, 176, 218, 207, 177, 224, 133, 73, 116, 53, 232, 24, 70, 188, 54, 153, 158, 214, 234, 120, 147, 66, 0, 101, 116, 215, 214, 168, 111, 227, 8, 54, 113, 163, 89, 71, 105, 67, 170, 51, 42, 174, 119, 161, 192, 13, 227, 52, 41, 165, 248, 198, 232, 158, 213, 212, 55, 108, 0, 191, 204, 129, 225, 93, 203, 106, 37, 23, 93, 217, 73, 107, 108, 84, 123, 181, 203, 241, 190, 217, 217, 141, 18, 229, 94, 98, 4, 158, 166, 139, 148, 31, 3, 34, 88, 237, 147, 20, 101, 62, 229, 233, 189, 71, 233, 213, 201, 23, 195, 226, 236, 7, 213, 151, 215, 27, 29, 118, 67, 119, 170, 10, 166, 133, 81, 136, 99, 182, 159, 164, 46, 44, 230, 102, 196, 1, 59, 254, 194, 184, 180, 255, 57, 68, 178, 184, 66, 99, 214, 248, 102, 31, 229, 90, 33, 237, 151, 5, 177, 172, 246, 139, 44, 232, 47, 240, 211, 169, 198, 91, 178, 105, 132, 179, 222, 140, 104, 102, 187, 83, 197, 28, 129, 12, 63, 77, 148, 16, 42, 237, 209, 10, 47, 94, 101, 88, 167, 11, 185, 135, 27, 156, 12, 61, 243, 65, 68, 236, 11, 127, 51, 217, 169, 50, 158, 240, 212, 229, 213, 225, 104, 70, 76, 135, 148, 101, 17, 183, 147, 225, 197, 55, 237, 57, 164, 74, 217, 106, 146, 63, 92, 152, 19, 245, 197, 121, 117, 147, 127, 49, 15, 175, 14, 40, 111, 69, 186, 148, 121, 246, 41, 79, 8, 219, 203, 75, 202, 148, 115, 191, 152, 240, 176, 230, 180, 43, 234, 94, 190, 173, 71, 96, 202, 75, 202, 148, 13, 201, 26, 5, 16, 84, 203, 14, 177, 173, 214, 19, 36, 107, 42, 52, 229, 53, 105, 202, 121, 191, 100, 48, 132, 166, 60, 35, 182, 195, 234, 46, 239, 135, 12, 21, 156, 242, 130, 104, 206, 171, 203, 172, 71, 12, 26, 252, 77, 187, 122, 248, 221, 69, 101, 64, 16, 62, 229, 90, 203, 183, 50, 254, 173, 108, 23, 151, 48, 229, 34, 10, 163, 149, 1, 71, 218, 154, 46, 229, 165, 128, 57, 174, 149, 65, 131, 195, 236, 124, 202, 9, 11, 35, 207, 9, 227, 161, 252, 224, 16, 218, 204, 115, 186, 194, 224, 36, 71, 255, 216, 183, 191, 149, 198, 129, 40, 12, 224, 105, 181, 213, 118, 209, 42, 75, 183, 106, 151, 46, 235, 222, 238, 237, 225, 12, 138, 32, 66, 74, 3, 9, 145, 24, 75, 48, 23, 197, 68, 134, 34, 185, 234, 19, 248, 16, 62, 240, 214, 191, 147, 108, 55, 153, 100, 182, 137, 147, 193, 223, 35, 124, 76, 191, 57, 51, 147, 30, 179, 5, 154, 255, 65, 195, 117, 72, 89, 19, 134, 138, 87, 248, 135, 69, 6, 7, 22, 179, 101, 126, 46, 229, 162, 133, 204, 82, 230, 199, 108, 149, 176, 152, 77, 165, 91, 249, 232, 156, 201, 187, 165, 153, 238, 250, 23, 179, 165, 240, 137, 228, 144, 56, 150, 192, 197, 188, 99, 90, 194, 49, 243, 143, 59, 138, 61, 95, 63, 127, 159, 229, 10, 61, 74, 59, 166, 187, 214, 152, 45, 101, 223, 85, 191, 191, 228, 85, 248, 253, 131, 5, 109, 113, 186, 89, 100, 41, 255, 208, 84, 178, 159, 24, 26, 196, 198, 51, 199, 92, 90, 71, 206, 170, 110, 125, 199, 43, 45, 203, 118, 180, 202, 185, 106, 158, 173, 191, 172, 254, 248, 217, 148, 81, 57, 71, 205, 190, 56, 78, 249, 245, 63, 35, 149, 179, 84, 236, 139, 125, 34, 151, 88, 95, 252, 210, 84, 241, 147, 200, 197, 84, 240, 104, 221, 252, 77, 36, 163, 96, 41, 31, 18, 217, 196, 74, 89, 149, 67, 223, 17, 145, 141, 171, 220, 91, 223, 6, 145, 142, 169, 220, 164, 44, 95, 91, 196, 39, 229, 217, 174, 18, 47, 170, 249, 218, 98, 49, 94, 144, 234, 176, 144, 31, 97, 115, 183, 165, 213, 93, 174, 63, 75, 211, 49, 162, 29, 144, 202, 196, 78, 246, 0, 10, 196, 252, 149, 240, 133, 62, 62, 153, 83, 242, 63, 168, 208, 120, 209, 128, 165, 205, 90, 151, 70, 115, 231, 150, 112, 25, 248, 202, 15, 137, 184, 123, 159, 138, 140, 23, 55, 240, 172, 127, 80, 219, 111, 195, 219, 123, 48, 35, 28, 244, 20, 25, 47, 34, 98, 130, 43, 196, 64, 36, 228, 59, 120, 53, 220, 209, 234, 168, 251, 13, 0, 40, 47, 227, 75, 140, 179, 13, 42, 18, 241, 53, 46, 77, 197, 66, 126, 215, 235, 106, 117, 211, 234, 192, 210, 13, 225, 240, 240, 47, 250, 25, 21, 138, 120, 41, 18, 8, 249, 1, 98, 6, 53, 219, 1, 119, 250, 240, 228, 142, 100, 27, 227, 42, 221, 40, 80, 26, 244, 254, 4, 223, 24, 130, 33, 51, 163, 58, 85, 115, 183, 7, 47, 30, 56, 187, 21, 254, 155, 23, 146, 92, 194, 185, 141, 140, 78, 69, 67, 102, 246, 234, 210, 25, 27, 29, 120, 115, 155, 157, 17, 166, 242, 13, 94, 206, 52, 156, 248, 152, 100, 136, 135, 204, 116, 106, 49, 206, 181, 135, 240, 110, 150, 25, 211, 9, 102, 241, 231, 65, 106, 111, 44, 238, 79, 117, 92, 97, 71, 226, 33, 51, 253, 182, 38, 187, 214, 0, 32, 103, 200, 99, 228, 242, 189, 179, 96, 65, 73, 76, 20, 6, 198, 84, 79, 171, 25, 209, 144, 147, 182, 37, 223, 0, 219, 125, 136, 163, 156, 178, 200, 199, 62, 185, 158, 94, 158, 122, 151, 211, 107, 31, 179, 5, 34, 33, 215, 108, 49, 111, 12, 32, 137, 164, 163, 87, 184, 126, 122, 84, 232, 88, 157, 12, 185, 30, 211, 92, 119, 8, 73, 13, 146, 238, 12, 203, 112, 65, 9, 223, 121, 242, 48, 82, 167, 197, 220, 220, 5, 200, 31, 114, 164, 99, 41, 230, 132, 203, 201, 10, 153, 233, 72, 56, 51, 111, 245, 32, 129, 115, 224, 155, 96, 73, 140, 66, 31, 41, 223, 64, 186, 222, 150, 38, 153, 246, 8, 138, 132, 28, 217, 88, 22, 163, 72, 200, 13, 200, 48, 146, 235, 210, 168, 217, 1, 40, 20, 242, 4, 203, 51, 206, 63, 92, 184, 144, 109, 32, 81, 101, 176, 170, 72, 106, 84, 185, 144, 153, 139, 40, 239, 112, 241, 8, 28, 123, 210, 84, 70, 183, 15, 41, 56, 23, 245, 101, 241, 131, 156, 195, 197, 12, 120, 70, 146, 76, 25, 7, 13, 40, 24, 50, 213, 177, 100, 94, 148, 171, 146, 111, 129, 171, 113, 160, 125, 188, 230, 0, 210, 81, 206, 237, 91, 121, 236, 73, 196, 169, 100, 118, 22, 225, 216, 254, 240, 98, 110, 173, 214, 49, 255, 238, 226, 10, 171, 224, 133, 52, 189, 146, 217, 4, 199, 215, 107, 105, 31, 106, 107, 8, 197, 67, 14, 177, 34, 250, 31, 102, 206, 174, 181, 137, 32, 10, 195, 54, 73, 53, 138, 85, 111, 218, 8, 66, 255, 197, 97, 36, 221, 128, 59, 184, 33, 1, 101, 35, 49, 75, 52, 11, 106, 98, 164, 44, 165, 66, 64, 37, 228, 70, 234, 149, 165, 55, 173, 95, 160, 127, 214, 212, 177, 57, 217, 116, 179, 103, 102, 187, 51, 179, 207, 189, 23, 62, 30, 222, 243, 158, 217, 32, 62, 228, 37, 158, 34, 79, 65, 142, 109, 59, 175, 204, 216, 142, 83, 121, 67, 60, 191, 25, 192, 227, 205, 70, 52, 68, 217, 24, 201, 88, 46, 72, 42, 22, 215, 223, 214, 6, 164, 243, 153, 88, 123, 230, 232, 36, 69, 242, 43, 144, 198, 218, 250, 187, 3, 4, 201, 223, 248, 134, 204, 6, 19, 76, 11, 133, 189, 135, 220, 185, 102, 133, 228, 43, 143, 62, 249, 58, 204, 6, 109, 76, 139, 53, 123, 175, 128, 215, 95, 169, 10, 136, 74, 135, 59, 96, 86, 24, 188, 187, 212, 45, 158, 192, 130, 98, 86, 185, 242, 14, 32, 74, 245, 34, 98, 118, 24, 97, 90, 96, 36, 43, 177, 99, 248, 27, 107, 25, 235, 177, 106, 189, 8, 152, 29, 246, 112, 237, 37, 68, 114, 1, 11, 51, 158, 32, 202, 155, 239, 29, 179, 132, 255, 14, 223, 45, 48, 146, 213, 184, 103, 208, 242, 230, 61, 144, 100, 163, 32, 221, 226, 156, 225, 197, 218, 195, 150, 92, 96, 203, 41, 142, 233, 80, 222, 103, 182, 104, 226, 218, 195, 215, 33, 85, 30, 16, 150, 77, 56, 166, 207, 17, 143, 81, 132, 157, 80, 53, 9, 122, 157, 46, 35, 25, 136, 65, 78, 254, 190, 87, 176, 89, 38, 118, 30, 209, 148, 71, 148, 137, 209, 212, 117, 221, 233, 200, 99, 210, 116, 39, 231, 127, 228, 108, 232, 147, 247, 200, 211, 180, 180, 40, 146, 101, 194, 49, 149, 23, 13, 150, 74, 112, 230, 10, 206, 184, 116, 10, 76, 93, 193, 79, 106, 154, 163, 71, 68, 90, 200, 113, 87, 123, 147, 43, 237, 128, 26, 223, 226, 146, 211, 221, 133, 83, 247, 130, 105, 151, 73, 209, 57, 118, 47, 56, 35, 198, 63, 32, 210, 66, 150, 29, 226, 42, 49, 115, 231, 33, 227, 89, 55, 94, 224, 124, 150, 198, 169, 139, 156, 50, 25, 188, 51, 23, 161, 178, 104, 57, 147, 31, 122, 239, 199, 112, 153, 34, 220, 126, 53, 144, 1, 21, 207, 45, 76, 228, 35, 217, 113, 151, 233, 51, 9, 34, 119, 137, 99, 98, 99, 30, 60, 66, 206, 83, 255, 40, 171, 230, 218, 53, 141, 220, 1, 21, 102, 254, 249, 168, 69, 50, 95, 80, 113, 144, 145, 9, 147, 224, 167, 187, 204, 144, 104, 202, 232, 248, 121, 228, 177, 57, 51, 32, 48, 255, 38, 183, 5, 82, 224, 24, 207, 241, 156, 119, 210, 55, 245, 52, 102, 108, 202, 104, 6, 110, 140, 159, 196, 75, 28, 74, 62, 104, 136, 0, 63, 2, 2, 211, 239, 203, 215, 55, 64, 129, 35, 246, 95, 242, 232, 33, 146, 26, 201, 117, 55, 142, 199, 72, 28, 87, 229, 223, 133, 163, 228, 161, 144, 156, 221, 178, 166, 111, 37, 183, 42, 160, 192, 123, 118, 33, 185, 141, 142, 211, 19, 32, 112, 227, 244, 24, 201, 109, 55, 198, 49, 209, 168, 31, 46, 214, 94, 67, 72, 206, 110, 185, 162, 229, 187, 223, 230, 54, 40, 48, 99, 11, 201, 206, 129, 228, 51, 103, 232, 198, 233, 50, 146, 166, 154, 228, 197, 230, 27, 161, 228, 172, 185, 188, 173, 225, 40, 41, 41, 29, 33, 39, 108, 73, 242, 80, 242, 19, 170, 39, 107, 12, 225, 110, 140, 51, 66, 242, 104, 177, 246, 132, 100, 193, 9, 100, 226, 110, 254, 69, 78, 173, 32, 31, 45, 75, 110, 45, 36, 135, 68, 85, 32, 182, 24, 185, 43, 39, 132, 228, 104, 177, 246, 80, 114, 246, 88, 174, 162, 29, 179, 229, 13, 7, 25, 37, 59, 19, 201, 183, 228, 161, 108, 31, 67, 38, 238, 50, 45, 150, 74, 216, 90, 172, 61, 148, 76, 140, 178, 193, 34, 119, 29, 148, 56, 138, 75, 30, 146, 123, 79, 48, 152, 186, 200, 212, 99, 18, 240, 99, 50, 45, 144, 48, 88, 172, 61, 148, 76, 140, 178, 185, 138, 113, 99, 23, 84, 24, 179, 184, 228, 166, 236, 131, 125, 195, 69, 110, 51, 41, 70, 75, 33, 222, 161, 36, 115, 113, 88, 143, 132, 100, 100, 12, 217, 216, 189, 145, 227, 210, 187, 7, 74, 204, 98, 146, 49, 47, 90, 10, 202, 70, 76, 14, 31, 207, 196, 6, 35, 37, 191, 19, 107, 111, 85, 242, 12, 50, 114, 175, 100, 231, 197, 2, 59, 50, 74, 142, 164, 191, 161, 70, 83, 145, 21, 17, 147, 102, 40, 18, 99, 218, 100, 180, 228, 137, 88, 123, 40, 153, 200, 11, 146, 154, 225, 107, 26, 57, 90, 149, 252, 255, 180, 30, 48, 26, 175, 49, 57, 157, 160, 1, 25, 6, 209, 228, 116, 212, 242, 25, 73, 143, 143, 196, 218, 91, 149, 236, 67, 102, 182, 114, 10, 228, 10, 40, 194, 46, 73, 30, 89, 253, 80, 141, 146, 135, 98, 237, 173, 74, 102, 144, 153, 202, 13, 147, 129, 140, 140, 47, 75, 110, 99, 185, 176, 8, 231, 145, 88, 123, 210, 146, 77, 197, 242, 77, 160, 160, 37, 139, 211, 122, 200, 44, 195, 121, 67, 172, 189, 60, 37, 195, 77, 35, 13, 153, 142, 11, 81, 149, 35, 102, 23, 159, 243, 182, 88, 123, 185, 74, 134, 235, 6, 159, 133, 16, 255, 178, 228, 22, 190, 92, 88, 195, 227, 188, 41, 214, 158, 218, 226, 211, 254, 84, 84, 5, 26, 186, 93, 136, 188, 8, 152, 93, 6, 156, 239, 139, 181, 71, 84, 56, 85, 170, 6, 218, 27, 125, 140, 136, 188, 232, 50, 187, 212, 57, 239, 139, 181, 167, 126, 140, 104, 236, 113, 155, 187, 144, 133, 147, 85, 201, 226, 180, 246, 152, 93, 186, 115, 201, 79, 163, 36, 201, 39, 112, 53, 118, 175, 18, 24, 59, 144, 13, 63, 38, 89, 48, 177, 94, 147, 67, 206, 131, 131, 70, 130, 100, 31, 174, 74, 213, 88, 88, 32, 179, 4, 201, 209, 1, 179, 12, 159, 51, 76, 146, 60, 131, 43, 179, 101, 170, 89, 32, 99, 63, 38, 89, 96, 251, 22, 241, 249, 156, 70, 146, 100, 144, 68, 71, 96, 212, 32, 51, 179, 4, 201, 182, 107, 178, 23, 151, 236, 19, 131, 172, 72, 205, 216, 25, 130, 28, 93, 150, 188, 199, 236, 82, 79, 146, 172, 222, 223, 114, 61, 73, 74, 15, 32, 59, 24, 24, 40, 185, 195, 236, 18, 174, 145, 60, 134, 92, 120, 80, 210, 240, 85, 143, 224, 196, 47, 154, 228, 94, 178, 228, 19, 200, 137, 59, 218, 31, 56, 17, 180, 92, 44, 201, 62, 95, 149, 156, 221, 113, 94, 143, 158, 85, 184, 42, 227, 127, 185, 236, 23, 69, 242, 96, 69, 178, 48, 63, 134, 252, 168, 154, 220, 122, 241, 159, 117, 22, 69, 114, 24, 151, 220, 198, 94, 145, 27, 183, 52, 188, 212, 211, 140, 103, 126, 97, 36, 247, 226, 146, 91, 140, 189, 31, 67, 190, 220, 211, 115, 235, 209, 156, 236, 21, 67, 178, 199, 87, 36, 231, 22, 198, 89, 239, 190, 242, 54, 228, 198, 151, 11, 201, 125, 102, 147, 250, 138, 228, 79, 160, 129, 237, 178, 150, 250, 70, 243, 186, 24, 146, 69, 36, 7, 186, 36, 171, 215, 184, 205, 10, 228, 6, 74, 118, 152, 69, 124, 190, 34, 249, 16, 116, 80, 217, 212, 241, 237, 148, 230, 176, 16, 146, 235, 171, 146, 199, 160, 133, 155, 58, 238, 16, 154, 241, 66, 178, 199, 236, 17, 10, 201, 253, 133, 100, 208, 67, 229, 134, 201, 65, 70, 246, 47, 36, 15, 88, 118, 188, 65, 189, 123, 78, 125, 48, 240, 178, 167, 5, 223, 187, 112, 252, 17, 52, 81, 179, 49, 200, 75, 245, 162, 158, 77, 111, 183, 23, 244, 157, 24, 253, 160, 87, 247, 179, 164, 5, 111, 226, 222, 211, 196, 198, 13, 27, 131, 140, 155, 47, 204, 16, 165, 61, 244, 187, 66, 167, 55, 80, 185, 68, 4, 45, 220, 123, 186, 168, 217, 24, 100, 220, 124, 129, 242, 107, 131, 147, 78, 191, 231, 73, 95, 34, 130, 182, 222, 189, 39, 157, 202, 53, 200, 155, 76, 69, 217, 15, 59, 142, 4, 157, 174, 194, 218, 227, 1, 70, 178, 62, 110, 154, 235, 200, 8, 134, 178, 167, 160, 184, 239, 72, 210, 239, 74, 175, 61, 222, 215, 30, 201, 114, 93, 249, 14, 228, 13, 134, 50, 234, 32, 64, 197, 82, 154, 235, 244, 15, 46, 4, 77, 253, 145, 12, 18, 163, 92, 222, 133, 188, 193, 166, 204, 37, 179, 184, 227, 40, 18, 120, 82, 131, 140, 145, 188, 1, 26, 217, 165, 94, 48, 238, 67, 254, 96, 94, 200, 253, 135, 66, 78, 6, 66, 162, 191, 25, 136, 100, 228, 62, 249, 245, 84, 3, 175, 21, 206, 145, 65, 223, 201, 68, 199, 163, 7, 121, 31, 211, 66, 43, 15, 168, 15, 34, 58, 56, 148, 207, 139, 208, 201, 76, 157, 72, 100, 237, 105, 129, 92, 39, 126, 252, 166, 3, 204, 11, 234, 78, 227, 206, 21, 8, 137, 65, 238, 96, 90, 104, 102, 39, 245, 16, 1, 29, 72, 31, 125, 126, 224, 92, 9, 158, 210, 145, 77, 156, 123, 200, 45, 99, 23, 53, 50, 150, 186, 71, 252, 142, 115, 69, 130, 164, 99, 15, 215, 158, 169, 180, 72, 109, 113, 229, 10, 104, 129, 170, 202, 232, 56, 127, 203, 61, 206, 141, 61, 14, 33, 187, 101, 83, 253, 13, 193, 213, 215, 87, 112, 252, 227, 25, 73, 135, 178, 92, 79, 24, 228, 49, 232, 38, 237, 147, 234, 93, 208, 5, 174, 190, 80, 126, 142, 63, 60, 38, 121, 70, 204, 178, 199, 141, 14, 50, 114, 119, 157, 227, 91, 160, 143, 67, 39, 189, 96, 120, 9, 89, 241, 135, 150, 252, 53, 33, 49, 252, 196, 176, 232, 52, 112, 237, 153, 224, 150, 177, 181, 135, 224, 247, 17, 78, 159, 32, 217, 37, 227, 89, 130, 97, 33, 104, 97, 127, 51, 192, 218, 213, 87, 218, 6, 141, 224, 40, 215, 137, 19, 36, 171, 100, 164, 158, 16, 22, 134, 7, 25, 182, 75, 198, 174, 61, 4, 71, 217, 25, 72, 62, 8, 189, 160, 249, 157, 246, 96, 228, 99, 88, 236, 53, 12, 15, 242, 186, 171, 175, 10, 90, 57, 68, 7, 161, 220, 247, 143, 169, 75, 242, 211, 89, 67, 207, 195, 51, 4, 231, 24, 7, 89, 63, 85, 131, 37, 25, 249, 178, 252, 61, 195, 23, 134, 189, 180, 239, 31, 103, 46, 201, 105, 74, 101, 14, 2, 97, 56, 216, 107, 163, 227, 79, 96, 138, 74, 153, 248, 141, 161, 22, 14, 227, 235, 233, 252, 175, 223, 119, 210, 56, 117, 73, 38, 206, 90, 230, 155, 174, 221, 154, 131, 134, 177, 35, 27, 97, 203, 96, 90, 32, 175, 29, 53, 70, 46, 73, 228, 172, 163, 217, 64, 108, 12, 114, 226, 43, 209, 166, 254, 131, 126, 188, 239, 40, 209, 58, 118, 9, 206, 20, 29, 127, 220, 0, 115, 108, 148, 13, 166, 5, 114, 232, 16, 168, 230, 197, 72, 210, 49, 110, 61, 147, 108, 153, 76, 11, 228, 139, 226, 40, 79, 51, 14, 114, 179, 109, 61, 44, 32, 161, 95, 148, 42, 160, 29, 245, 192, 136, 48, 48, 126, 125, 127, 245, 230, 243, 231, 55, 175, 190, 255, 194, 255, 3, 177, 189, 214, 177, 253, 176, 152, 83, 41, 153, 188, 68, 144, 195, 108, 187, 239, 215, 155, 151, 176, 224, 229, 43, 225, 249, 56, 90, 155, 21, 69, 8, 11, 184, 124, 143, 212, 192, 8, 234, 13, 227, 120, 174, 248, 45, 172, 240, 249, 87, 186, 227, 34, 132, 197, 95, 238, 237, 166, 53, 117, 32, 10, 227, 184, 233, 21, 223, 160, 218, 77, 109, 225, 194, 253, 22, 103, 211, 144, 77, 23, 195, 204, 46, 32, 74, 184, 8, 247, 5, 133, 172, 90, 87, 74, 215, 126, 4, 191, 240, 61, 145, 148, 7, 6, 211, 26, 239, 52, 231, 152, 255, 78, 112, 245, 99, 56, 206, 76, 34, 247, 224, 33, 223, 83, 51, 173, 247, 53, 149, 255, 190, 253, 161, 19, 253, 122, 171, 107, 188, 165, 198, 187, 247, 111, 57, 155, 106, 109, 106, 42, 111, 87, 116, 162, 141, 173, 60, 131, 156, 206, 173, 169, 249, 70, 222, 203, 89, 77, 21, 189, 48, 79, 189, 14, 63, 201, 107, 117, 168, 250, 174, 75, 180, 12, 228, 162, 177, 247, 42, 64, 115, 237, 92, 221, 197, 108, 14, 43, 66, 209, 166, 146, 216, 232, 50, 166, 169, 119, 57, 212, 96, 187, 132, 149, 107, 102, 15, 155, 205, 138, 219, 108, 14, 230, 163, 235, 10, 53, 63, 122, 156, 119, 232, 235, 81, 147, 69, 219, 196, 66, 42, 88, 198, 105, 51, 38, 234, 213, 120, 240, 20, 94, 57, 177, 161, 141, 109, 162, 207, 152, 134, 29, 116, 71, 205, 182, 102, 101, 103, 190, 96, 25, 171, 56, 233, 17, 154, 192, 248, 27, 53, 93, 161, 156, 88, 19, 144, 88, 165, 49, 134, 50, 70, 114, 131, 241, 196, 8, 198, 108, 108, 242, 65, 187, 136, 4, 235, 9, 236, 146, 125, 101, 102, 14, 66, 172, 113, 30, 31, 27, 139, 236, 146, 161, 188, 43, 143, 98, 230, 63, 7, 133, 102, 99, 154, 226, 154, 147, 68, 42, 149, 19, 103, 205, 165, 139, 248, 157, 88, 215, 25, 132, 80, 23, 23, 23, 66, 189, 48, 195, 229, 206, 133, 176, 118, 99, 162, 62, 158, 60, 201, 20, 29, 55, 25, 112, 14, 178, 134, 209, 118, 77, 242, 221, 226, 40, 34, 85, 100, 97, 2, 232, 207, 128, 109, 114, 78, 54, 34, 5, 13, 241, 198, 172, 88, 123, 227, 219, 56, 107, 141, 169, 224, 101, 95, 151, 156, 151, 51, 191, 73, 67, 147, 18, 185, 75, 114, 237, 227, 220, 157, 70, 114, 172, 141, 248, 99, 82, 39, 27, 199, 58, 144, 203, 7, 125, 125, 146, 139, 145, 227, 216, 36, 161, 115, 38, 214, 130, 76, 125, 252, 238, 9, 197, 200, 92, 110, 3, 225, 98, 25, 235, 65, 190, 197, 121, 79, 42, 70, 230, 48, 51, 2, 228, 242, 88, 19, 242, 24, 175, 181, 8, 197, 200, 101, 198, 133, 155, 20, 170, 144, 7, 184, 231, 148, 234, 53, 139, 193, 28, 134, 88, 25, 242, 157, 248, 230, 130, 94, 103, 105, 28, 128, 25, 196, 234, 144, 187, 55, 194, 155, 11, 70, 126, 98, 101, 100, 236, 229, 196, 150, 103, 177, 66, 100, 234, 227, 50, 89, 38, 70, 126, 154, 45, 226, 24, 229, 214, 93, 188, 136, 117, 34, 247, 240, 55, 84, 153, 24, 153, 123, 134, 204, 69, 206, 174, 88, 196, 106, 145, 31, 113, 115, 33, 20, 35, 115, 115, 31, 40, 63, 127, 60, 91, 83, 8, 43, 70, 30, 74, 239, 224, 24, 249, 216, 50, 139, 253, 242, 252, 211, 171, 54, 87, 2, 235, 70, 30, 8, 95, 15, 189, 35, 99, 48, 251, 177, 52, 168, 145, 179, 236, 123, 4, 214, 143, 60, 193, 251, 156, 34, 1, 25, 35, 227, 116, 89, 150, 166, 139, 180, 40, 195, 162, 191, 14, 228, 31, 252, 236, 137, 4, 3, 50, 183, 76, 207, 212, 187, 50, 100, 186, 17, 222, 38, 23, 200, 104, 222, 78, 228, 126, 103, 68, 146, 1, 185, 156, 204, 109, 68, 30, 9, 159, 69, 74, 100, 52, 207, 218, 135, 220, 19, 62, 139, 16, 144, 193, 220, 54, 228, 199, 206, 152, 36, 3, 50, 154, 61, 103, 237, 66, 30, 203, 30, 248, 128, 236, 51, 183, 9, 121, 40, 123, 224, 3, 178, 207, 60, 79, 219, 131, 252, 160, 20, 153, 91, 46, 218, 130, 60, 232, 76, 73, 48, 32, 87, 44, 231, 86, 32, 79, 101, 175, 46, 42, 145, 49, 157, 211, 235, 71, 158, 116, 190, 147, 104, 64, 174, 94, 207, 139, 236, 186, 145, 255, 81, 119, 55, 45, 106, 67, 81, 24, 199, 77, 91, 250, 6, 211, 22, 233, 27, 20, 250, 45, 238, 129, 116, 115, 161, 46, 2, 89, 148, 134, 98, 177, 218, 169, 4, 220, 184, 40, 40, 81, 144, 33, 193, 141, 73, 20, 241, 165, 139, 110, 134, 210, 207, 90, 219, 14, 62, 76, 102, 156, 152, 123, 207, 53, 206, 239, 35, 252, 57, 156, 196, 168, 55, 111, 74, 120, 62, 100, 117, 252, 95, 231, 231, 225, 98, 17, 187, 67, 57, 70, 205, 27, 67, 43, 76, 244, 207, 90, 173, 22, 70, 209, 249, 249, 175, 95, 126, 71, 148, 232, 197, 97, 191, 70, 109, 250, 193, 164, 74, 68, 114, 11, 145, 115, 67, 127, 173, 191, 255, 252, 177, 88, 228, 11, 145, 109, 219, 103, 131, 192, 111, 138, 82, 220, 59, 92, 228, 78, 123, 242, 156, 46, 184, 10, 145, 209, 186, 254, 190, 81, 44, 114, 98, 95, 24, 245, 219, 37, 204, 244, 129, 34, 91, 126, 127, 19, 24, 22, 219, 200, 221, 130, 141, 177, 168, 115, 35, 127, 217, 70, 78, 237, 13, 132, 246, 45, 113, 16, 136, 44, 140, 107, 182, 39, 148, 17, 109, 35, 123, 57, 53, 53, 46, 136, 136, 252, 219, 206, 24, 28, 182, 179, 233, 200, 150, 143, 194, 144, 110, 35, 207, 80, 141, 121, 158, 27, 181, 173, 181, 13, 152, 103, 177, 211, 237, 138, 220, 9, 158, 19, 192, 42, 115, 229, 211, 233, 220, 200, 93, 201, 181, 15, 54, 192, 40, 104, 138, 67, 48, 27, 25, 67, 156, 181, 148, 153, 165, 172, 163, 254, 57, 103, 91, 132, 246, 46, 131, 158, 48, 207, 100, 100, 191, 74, 187, 197, 219, 200, 195, 2, 57, 139, 60, 230, 248, 88, 203, 92, 247, 74, 203, 108, 46, 114, 27, 137, 1, 82, 166, 81, 198, 199, 239, 29, 131, 140, 149, 188, 203, 153, 47, 204, 50, 19, 25, 83, 188, 211, 90, 50, 92, 250, 0, 95, 15, 98, 144, 225, 212, 190, 217, 153, 233, 105, 54, 113, 159, 220, 171, 82, 174, 152, 119, 148, 177, 52, 48, 200, 216, 22, 185, 6, 29, 97, 18, 127, 228, 102, 159, 246, 48, 69, 228, 225, 248, 29, 147, 122, 3, 183, 22, 48, 183, 247, 240, 195, 18, 166, 240, 127, 226, 179, 218, 14, 237, 195, 113, 179, 11, 131, 115, 53, 55, 106, 144, 216, 123, 25, 249, 194, 148, 123, 204, 79, 225, 58, 85, 218, 83, 42, 193, 123, 199, 151, 249, 35, 150, 5, 6, 121, 47, 131, 166, 48, 227, 5, 235, 243, 100, 43, 32, 40, 48, 202, 88, 203, 12, 234, 104, 140, 65, 222, 203, 168, 45, 128, 53, 242, 51, 193, 6, 99, 92, 96, 43, 243, 87, 254, 180, 105, 12, 75, 27, 74, 26, 230, 103, 140, 223, 241, 249, 14, 21, 178, 144, 48, 100, 172, 220, 149, 46, 26, 255, 182, 11, 25, 245, 4, 191, 167, 108, 223, 86, 91, 125, 42, 104, 46, 141, 204, 178, 39, 37, 42, 71, 167, 118, 65, 129, 37, 184, 189, 228, 57, 211, 23, 171, 162, 224, 194, 96, 191, 250, 181, 60, 249, 79, 156, 89, 22, 101, 174, 140, 135, 44, 191, 32, 42, 190, 42, 240, 88, 25, 102, 12, 247, 203, 227, 153, 148, 18, 149, 87, 54, 148, 183, 50, 94, 241, 252, 22, 46, 32, 37, 14, 214, 50, 207, 98, 238, 74, 112, 241, 89, 175, 40, 95, 176, 122, 162, 245, 171, 78, 172, 99, 69, 203, 88, 94, 226, 141, 181, 199, 24, 220, 228, 155, 173, 40, 16, 156, 94, 87, 78, 244, 27, 79, 72, 217, 220, 149, 153, 97, 110, 41, 39, 246, 228, 101, 161, 131, 200, 69, 245, 5, 163, 19, 253, 95, 218, 55, 171, 68, 90, 149, 89, 50, 183, 188, 225, 149, 198, 68, 234, 149, 7, 150, 96, 115, 95, 253, 63, 35, 104, 172, 101, 30, 75, 253, 204, 227, 77, 226, 140, 200, 33, 58, 146, 202, 15, 148, 255, 253, 132, 198, 154, 150, 11, 9, 42, 187, 185, 213, 157, 201, 43, 146, 239, 68, 122, 149, 207, 216, 42, 223, 173, 84, 222, 10, 13, 205, 231, 164, 205, 137, 228, 85, 67, 116, 206, 41, 140, 33, 150, 48, 37, 162, 99, 169, 124, 175, 82, 41, 252, 132, 136, 117, 142, 241, 68, 14, 208, 185, 155, 19, 122, 140, 194, 151, 196, 115, 250, 239, 40, 54, 198, 27, 197, 211, 80, 209, 152, 199, 58, 150, 144, 9, 221, 29, 183, 174, 25, 224, 77, 223, 217, 80, 94, 47, 113, 136, 142, 168, 242, 75, 173, 119, 229, 88, 85, 226, 226, 36, 242, 6, 195, 153, 183, 137, 125, 193, 243, 144, 23, 32, 94, 17, 232, 86, 22, 12, 94, 233, 156, 119, 97, 77, 136, 209, 122, 33, 115, 185, 50, 31, 198, 24, 202, 189, 95, 126, 162, 115, 114, 75, 159, 120, 77, 99, 253, 200, 209, 156, 0, 108, 101, 109, 161, 237, 68, 227, 12, 162, 128, 184, 57, 83, 87, 47, 114, 184, 166, 235, 157, 218, 202, 124, 161, 235, 113, 69, 249, 152, 0, 159, 128, 49, 115, 172, 30, 57, 66, 98, 206, 202, 29, 161, 199, 186, 163, 252, 2, 179, 142, 67, 70, 124, 95, 133, 74, 145, 221, 116, 73, 192, 89, 121, 212, 20, 90, 222, 40, 159, 104, 143, 27, 11, 126, 203, 52, 46, 26, 57, 90, 57, 148, 113, 52, 183, 24, 15, 149, 207, 168, 158, 144, 81, 243, 116, 177, 119, 100, 23, 133, 13, 85, 14, 132, 142, 71, 170, 167, 206, 182, 201, 184, 229, 42, 137, 115, 35, 15, 195, 116, 253, 157, 192, 80, 229, 158, 208, 112, 162, 240, 222, 0, 44, 100, 243, 150, 235, 105, 180, 216, 17, 217, 13, 147, 233, 60, 27, 248, 24, 215, 242, 227, 202, 95, 119, 44, 145, 161, 183, 144, 249, 83, 175, 166, 105, 18, 69, 97, 24, 46, 194, 48, 74, 146, 116, 186, 154, 59, 84, 220, 105, 41, 107, 249, 174, 218, 235, 181, 2, 186, 165, 190, 149, 240, 153, 228, 153, 218, 123, 193, 123, 116, 107, 253, 97, 239, 108, 90, 226, 8, 130, 48, 92, 51, 238, 124, 236, 68, 103, 39, 16, 119, 7, 6, 60, 229, 160, 11, 30, 66, 176, 15, 9, 196, 163, 16, 33, 151, 16, 2, 11, 70, 132, 128, 7, 89, 80, 146, 67, 8, 70, 16, 66, 16, 2, 201, 53, 57, 248, 95, 179, 32, 164, 68, 119, 103, 187, 122, 186, 219, 154, 233, 126, 110, 94, 31, 138, 183, 171, 170, 219, 157, 15, 246, 3, 99, 116, 227, 24, 183, 23, 28, 195, 98, 49, 237, 8, 140, 114, 241, 23, 115, 186, 24, 22, 15, 19, 24, 153, 202, 183, 159, 62, 138, 86, 99, 59, 48, 122, 33, 40, 124, 205, 229, 187, 104, 53, 7, 150, 183, 158, 3, 149, 79, 164, 30, 137, 150, 99, 111, 36, 193, 121, 143, 56, 243, 5, 79, 68, 219, 81, 191, 88, 165, 10, 198, 121, 15, 238, 174, 148, 187, 123, 234, 97, 96, 216, 91, 45, 71, 112, 3, 225, 198, 122, 178, 39, 218, 143, 250, 217, 23, 236, 80, 169, 0, 145, 189, 76, 61, 19, 29, 224, 192, 98, 27, 55, 66, 199, 24, 202, 157, 110, 223, 30, 160, 148, 215, 0, 137, 102, 127, 187, 82, 200, 51, 236, 109, 150, 35, 0, 164, 216, 113, 167, 144, 49, 48, 140, 151, 114, 1, 183, 233, 187, 84, 200, 66, 216, 74, 229, 62, 32, 114, 143, 47, 38, 162, 51, 216, 42, 229, 24, 110, 19, 246, 118, 92, 232, 145, 45, 150, 50, 46, 46, 144, 212, 133, 97, 15, 57, 176, 50, 246, 165, 128, 200, 53, 113, 135, 162, 75, 152, 222, 96, 96, 3, 71, 106, 226, 90, 188, 171, 215, 217, 43, 127, 86, 108, 224, 112, 221, 217, 205, 75, 39, 189, 165, 60, 33, 175, 57, 145, 220, 153, 254, 237, 6, 11, 255, 227, 151, 3, 34, 181, 137, 11, 186, 176, 26, 178, 124, 244, 37, 112, 143, 194, 161, 99, 175, 81, 41, 159, 146, 199, 61, 164, 236, 242, 173, 147, 206, 82, 62, 35, 220, 83, 223, 37, 113, 100, 218, 251, 143, 242, 212, 71, 239, 45, 144, 129, 83, 105, 97, 60, 47, 134, 48, 143, 210, 153, 38, 217, 74, 94, 172, 193, 60, 162, 192, 169, 180, 192, 82, 54, 146, 23, 189, 8, 230, 146, 58, 149, 22, 134, 243, 34, 133, 249, 196, 14, 245, 22, 152, 23, 134, 230, 145, 24, 22, 80, 185, 50, 137, 96, 41, 155, 154, 71, 214, 67, 88, 64, 238, 200, 222, 162, 113, 94, 76, 200, 35, 53, 146, 56, 176, 174, 215, 146, 23, 71, 244, 145, 26, 25, 186, 20, 201, 51, 76, 52, 113, 216, 36, 147, 142, 190, 64, 116, 21, 99, 161, 28, 67, 13, 149, 75, 145, 140, 121, 161, 59, 148, 171, 16, 106, 40, 93, 138, 228, 25, 134, 66, 185, 132, 58, 86, 54, 92, 138, 100, 245, 188, 248, 68, 157, 246, 150, 190, 114, 233, 210, 53, 53, 65, 178, 250, 77, 95, 31, 234, 73, 92, 89, 92, 52, 11, 229, 47, 42, 253, 27, 146, 58, 116, 238, 25, 58, 249, 82, 88, 70, 230, 200, 118, 200, 224, 201, 151, 193, 82, 210, 54, 220, 83, 79, 175, 206, 95, 75, 115, 126, 53, 213, 30, 202, 135, 42, 131, 8, 146, 181, 160, 185, 192, 31, 94, 150, 227, 124, 79, 183, 228, 51, 165, 66, 70, 134, 252, 155, 139, 111, 187, 68, 126, 80, 67, 89, 189, 189, 24, 128, 12, 25, 251, 161, 250, 231, 46, 153, 95, 214, 218, 139, 24, 164, 24, 114, 127, 95, 127, 69, 151, 252, 91, 119, 123, 161, 86, 200, 72, 198, 189, 131, 251, 67, 151, 252, 87, 119, 123, 49, 81, 75, 100, 36, 101, 222, 193, 113, 144, 124, 170, 214, 90, 32, 25, 243, 245, 144, 138, 100, 221, 237, 197, 145, 98, 33, 35, 35, 222, 109, 50, 7, 201, 135, 138, 195, 30, 146, 244, 188, 100, 68, 126, 15, 23, 36, 64, 160, 207, 122, 22, 185, 126, 79, 230, 218, 202, 52, 210, 7, 10, 209, 58, 231, 23, 90, 39, 175, 200, 28, 211, 167, 17, 186, 228, 141, 8, 72, 148, 94, 50, 34, 59, 242, 149, 64, 164, 96, 60, 85, 51, 149, 92, 132, 64, 36, 243, 146, 107, 249, 90, 59, 80, 83, 39, 18, 134, 79, 180, 120, 74, 78, 129, 78, 210, 243, 146, 41, 146, 123, 9, 32, 212, 179, 79, 240, 131, 165, 228, 18, 148, 24, 120, 201, 242, 146, 139, 16, 148, 200, 2, 47, 89, 90, 114, 6, 138, 228, 94, 178, 172, 228, 62, 168, 18, 86, 94, 178, 156, 228, 106, 5, 148, 201, 188, 100, 57, 201, 49, 168, 128, 139, 162, 23, 138, 96, 235, 199, 90, 242, 155, 151, 106, 172, 54, 13, 11, 36, 44, 188, 228, 122, 201, 24, 22, 234, 100, 129, 151, 188, 76, 114, 144, 65, 67, 114, 47, 121, 153, 228, 28, 154, 18, 142, 189, 228, 122, 201, 131, 16, 26, 243, 244, 157, 151, 92, 39, 185, 151, 128, 6, 182, 189, 228, 58, 201, 107, 160, 133, 77, 110, 146, 143, 247, 201, 24, 147, 60, 2, 61, 68, 99, 110, 146, 249, 84, 114, 129, 221, 91, 227, 88, 246, 146, 231, 75, 222, 72, 64, 27, 219, 111, 89, 73, 190, 164, 75, 190, 52, 35, 57, 6, 141, 60, 107, 187, 228, 169, 17, 201, 57, 232, 36, 92, 229, 36, 89, 208, 37, 11, 19, 146, 135, 160, 151, 199, 99, 78, 146, 247, 169, 142, 247, 77, 72, 174, 34, 64, 52, 29, 126, 140, 36, 147, 27, 229, 19, 3, 146, 241, 208, 211, 121, 248, 241, 145, 76, 14, 229, 75, 253, 146, 131, 24, 12, 240, 156, 143, 100, 113, 65, 77, 11, 253, 146, 75, 48, 194, 22, 31, 201, 196, 188, 56, 214, 47, 121, 11, 204, 16, 110, 178, 145, 60, 37, 57, 190, 152, 106, 151, 188, 21, 130, 33, 162, 49, 23, 201, 180, 82, 62, 17, 186, 37, 111, 70, 96, 140, 71, 99, 46, 146, 167, 23, 148, 66, 214, 45, 121, 245, 95, 123, 119, 179, 154, 58, 16, 134, 113, 252, 69, 113, 149, 108, 242, 177, 17, 50, 11, 201, 183, 160, 98, 148, 185, 4, 21, 2, 65, 40, 186, 58, 123, 11, 37, 183, 32, 228, 206, 207, 145, 22, 166, 61, 181, 38, 149, 73, 242, 204, 232, 255, 18, 126, 188, 188, 206, 196, 64, 12, 106, 49, 99, 15, 130, 204, 79, 191, 217, 200, 146, 145, 205, 128, 90, 45, 56, 130, 32, 243, 188, 249, 209, 66, 50, 242, 46, 160, 150, 91, 28, 64, 144, 203, 115, 211, 101, 33, 25, 121, 183, 160, 214, 18, 202, 24, 200, 188, 58, 55, 52, 150, 139, 188, 89, 83, 7, 173, 15, 24, 200, 188, 106, 98, 92, 113, 185, 200, 155, 57, 181, 154, 80, 198, 64, 22, 179, 124, 191, 49, 47, 48, 141, 47, 202, 24, 200, 181, 202, 121, 201, 107, 145, 65, 141, 47, 202, 24, 200, 188, 204, 111, 94, 66, 74, 94, 143, 140, 106, 124, 81, 198, 64, 190, 53, 204, 121, 197, 185, 92, 228, 221, 156, 58, 109, 113, 4, 65, 230, 229, 233, 42, 243, 249, 196, 27, 85, 96, 157, 221, 190, 22, 236, 65, 144, 255, 117, 202, 107, 166, 88, 10, 178, 25, 80, 231, 5, 83, 24, 100, 206, 203, 234, 45, 63, 127, 140, 112, 254, 86, 149, 188, 113, 5, 178, 49, 145, 49, 197, 65, 126, 151, 190, 36, 124, 229, 34, 39, 6, 245, 210, 200, 196, 66, 22, 201, 71, 78, 70, 212, 83, 131, 244, 81, 144, 211, 1, 245, 215, 242, 229, 17, 144, 95, 151, 212, 107, 179, 131, 254, 200, 155, 25, 245, 220, 98, 175, 59, 178, 185, 160, 222, 51, 76, 189, 145, 19, 131, 0, 26, 166, 58, 35, 47, 135, 132, 209, 234, 160, 43, 242, 102, 69, 48, 5, 83, 61, 145, 17, 214, 177, 104, 148, 232, 136, 156, 90, 132, 213, 234, 160, 27, 50, 210, 170, 16, 43, 67, 47, 100, 51, 32, 192, 134, 233, 139, 70, 200, 48, 167, 138, 255, 155, 239, 117, 65, 54, 231, 4, 155, 149, 232, 129, 12, 247, 139, 247, 181, 217, 81, 125, 100, 179, 247, 103, 21, 117, 25, 137, 234, 200, 41, 196, 61, 186, 166, 245, 84, 101, 100, 228, 109, 252, 185, 225, 242, 143, 170, 200, 155, 229, 136, 84, 41, 48, 213, 68, 78, 32, 207, 198, 63, 54, 219, 171, 135, 108, 2, 94, 241, 110, 55, 138, 213, 80, 46, 84, 220, 20, 34, 43, 228, 10, 244, 129, 252, 154, 170, 181, 41, 68, 78, 198, 225, 123, 71, 78, 160, 158, 105, 254, 178, 49, 227, 224, 21, 10, 29, 219, 126, 204, 7, 103, 46, 20, 184, 224, 53, 104, 2, 248, 17, 13, 17, 91, 13, 72, 139, 112, 167, 153, 249, 164, 79, 152, 187, 89, 43, 226, 75, 14, 220, 129, 46, 116, 72, 191, 172, 8, 232, 187, 48, 110, 164, 194, 179, 182, 123, 26, 122, 32, 91, 131, 121, 168, 127, 46, 73, 218, 26, 189, 143, 243, 86, 203, 61, 1, 53, 206, 154, 15, 177, 200, 136, 109, 222, 75, 182, 182, 155, 248, 106, 78, 247, 191, 130, 110, 164, 255, 154, 184, 226, 220, 225, 60, 219, 209, 152, 30, 52, 39, 102, 188, 131, 88, 252, 128, 51, 252, 57, 107, 210, 238, 121, 195, 13, 39, 216, 47, 81, 116, 149, 19, 103, 173, 64, 187, 217, 163, 143, 240, 55, 232, 208, 150, 186, 132, 195, 39, 240, 213, 44, 63, 202, 92, 25, 3, 28, 249, 207, 21, 81, 35, 29, 135, 204, 189, 147, 151, 133, 241, 211, 183, 57, 245, 216, 139, 132, 117, 19, 221, 200, 27, 63, 121, 239, 196, 118, 124, 47, 142, 194, 140, 49, 219, 117, 183, 226, 45, 131, 173, 235, 218, 140, 101, 97, 20, 123, 190, 131, 142, 251, 23, 97, 210, 124, 27, 220, 190, 110, 68, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 } });

            migrationBuilder.InsertData(
                table: "Uloga",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Uposlenik" }
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "ID", "DrzavaID", "Naziv" },
                values: new object[,]
                {
                    { 1, 1, "Mostar" },
                    { 2, 1, "Sarajevo" }
                });

            migrationBuilder.InsertData(
                table: "KorisniciUloge",
                columns: new[] { "ID", "DatumIzmjene", "KorisnikID", "UlogaID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 15, 18, 35, 27, 883, DateTimeKind.Local).AddTicks(6646), 1, 1 },
                    { 2, new DateTime(2020, 7, 15, 18, 35, 27, 967, DateTimeKind.Local).AddTicks(6378), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Novosti",
                columns: new[] { "ID", "DatumObjave", "KorisnikID", "Naslov", "Sadrzaj" },
                values: new object[] { 1, new DateTime(2020, 7, 15, 18, 35, 27, 992, DateTimeKind.Local).AddTicks(8213), 2, "Vazna obavjest", "Nastavlja se red voznje uz smanjen obim" });

            migrationBuilder.InsertData(
                table: "Kompanija",
                columns: new[] { "ID", "Adresa", "Email", "GradID", "KontaktBroj", "LokacijaSlike", "Naziv" },
                values: new object[,]
                {
                    { 1, "Bisce polje bb", "autoprevoz@mail.com", 1, "38736563222", "https://autoprevoz.ba/wp-content/uploads/2015/07/bus.png", "Autoprevoz-bus" },
                    { 2, "Stefana Nemanje 12", "centrotrans@mail.com", 2, "38733563222", "https://sarajevo.travel/assets/photos/texts/extra-big/new-night-buses-to-run-between-vijecnica-and-dobrinja-1469775617.jpg", "Centrotrans" }
                });

            migrationBuilder.InsertData(
                table: "Linija",
                columns: new[] { "ID", "KorisnikID", "Naziv", "OdredisteID", "PolazisteID" },
                values: new object[] { 1, 2, "Mostar-Sarajevo", 2, 1 });

            migrationBuilder.InsertData(
                table: "Notifikacije",
                columns: new[] { "ID", "DatumSlanja", "Naslov", "NovostID" },
                values: new object[] { 1, new DateTime(2020, 7, 15, 18, 35, 27, 994, DateTimeKind.Local).AddTicks(8000), "Obavjest", 1 });

            migrationBuilder.InsertData(
                table: "Cijena",
                columns: new[] { "ID", "Iznos", "KompanijaID", "LinijaID", "Popust" },
                values: new object[,]
                {
                    { 1, 22m, 1, 1, 0f },
                    { 2, 23m, 2, 1, 0f }
                });

            migrationBuilder.InsertData(
                table: "PutnikNotifikacije",
                columns: new[] { "ID", "NotifikacijaID", "Pregledana", "PutnikID" },
                values: new object[] { 1, 1, false, 1 });

            migrationBuilder.InsertData(
                table: "Vozilo",
                columns: new[] { "ID", "BrojSjedista", "KompanijaID", "Model", "Proizvodjac", "Registracija" },
                values: new object[,]
                {
                    { 1, 44, 1, "Lion's coach", "MAN", "112-A-23E" },
                    { 2, 44, 2, "COACH B4SC", "VOLVO", "L23-K-298" }
                });

            migrationBuilder.InsertData(
                table: "Angazuje",
                columns: new[] { "ID", "DatumAngazovanja", "DatumIsteka", "LinijaID", "VoziloID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Sjediste",
                columns: new[] { "ID", "Kolona", "Red", "VoziloID" },
                values: new object[,]
                {
                    { 85, 1, 11, 2 },
                    { 62, 2, 5, 2 },
                    { 61, 1, 5, 2 },
                    { 60, 4, 4, 2 },
                    { 59, 3, 4, 2 },
                    { 58, 2, 4, 2 },
                    { 57, 1, 4, 2 },
                    { 56, 4, 3, 2 },
                    { 55, 3, 3, 2 },
                    { 54, 2, 3, 2 },
                    { 53, 1, 3, 2 },
                    { 52, 4, 2, 2 },
                    { 51, 3, 2, 2 },
                    { 50, 2, 2, 2 },
                    { 49, 1, 2, 2 },
                    { 48, 4, 1, 2 },
                    { 47, 3, 1, 2 },
                    { 46, 2, 1, 2 },
                    { 63, 3, 5, 2 },
                    { 64, 4, 5, 2 },
                    { 65, 1, 6, 2 },
                    { 45, 1, 1, 2 },
                    { 84, 4, 10, 2 },
                    { 83, 3, 10, 2 },
                    { 82, 2, 10, 2 },
                    { 81, 1, 10, 2 },
                    { 80, 4, 9, 2 },
                    { 79, 3, 9, 2 },
                    { 78, 2, 9, 2 },
                    { 77, 1, 9, 2 },
                    { 86, 2, 11, 2 },
                    { 76, 4, 8, 2 },
                    { 74, 2, 8, 2 },
                    { 73, 1, 8, 2 },
                    { 72, 4, 7, 2 },
                    { 71, 3, 7, 2 },
                    { 70, 2, 7, 2 },
                    { 69, 1, 7, 2 },
                    { 68, 4, 6, 2 },
                    { 67, 3, 6, 2 },
                    { 75, 3, 8, 2 },
                    { 66, 2, 6, 2 },
                    { 44, 4, 11, 1 },
                    { 43, 3, 11, 1 },
                    { 19, 3, 5, 1 },
                    { 18, 2, 5, 1 },
                    { 17, 1, 5, 1 },
                    { 16, 4, 4, 1 },
                    { 15, 3, 4, 1 },
                    { 14, 2, 4, 1 },
                    { 13, 1, 4, 1 },
                    { 12, 4, 3, 1 },
                    { 11, 3, 3, 1 },
                    { 10, 2, 3, 1 },
                    { 9, 1, 3, 1 },
                    { 8, 4, 2, 1 },
                    { 7, 3, 2, 1 },
                    { 6, 2, 2, 1 },
                    { 5, 1, 2, 1 },
                    { 4, 4, 1, 1 },
                    { 3, 3, 1, 1 },
                    { 2, 2, 1, 1 },
                    { 1, 1, 1, 1 },
                    { 20, 4, 5, 1 },
                    { 87, 3, 11, 2 },
                    { 21, 1, 6, 1 },
                    { 23, 3, 6, 1 },
                    { 42, 2, 11, 1 },
                    { 41, 1, 11, 1 },
                    { 40, 4, 10, 1 },
                    { 39, 3, 10, 1 },
                    { 38, 2, 10, 1 },
                    { 37, 1, 10, 1 },
                    { 36, 4, 9, 1 },
                    { 35, 3, 9, 1 },
                    { 34, 2, 9, 1 },
                    { 33, 1, 9, 1 },
                    { 32, 4, 8, 1 },
                    { 31, 3, 8, 1 },
                    { 30, 2, 8, 1 },
                    { 29, 1, 8, 1 },
                    { 28, 4, 7, 1 },
                    { 27, 3, 7, 1 },
                    { 26, 2, 7, 1 },
                    { 25, 1, 7, 1 },
                    { 24, 4, 6, 1 },
                    { 22, 2, 6, 1 },
                    { 88, 4, 11, 2 }
                });

            migrationBuilder.InsertData(
                table: "Karta",
                columns: new[] { "ID", "AngazujeID", "BrojKarte", "DatumIzdavanja", "SjedisteID", "VrijemeDolaska", "VrijemePolaska" },
                values: new object[,]
                {
                    { 1, 1, "affdsddvda", new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 11, 2, "exwelbkvpt", new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 17, 2, "rutfkyxcty", new DateTime(2020, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 10, 2, "rxttxbxvpo", new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 16, 2, "grtrklxcto", new DateTime(2020, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 9, 2, "retdsbxvlk", new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 34, 1, "pwtdglxcgy", new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 33, 1, "qwtjglbcgb", new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 32, 1, "eqtjhlbsgv", new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 31, 1, "mqfjnlbsgv", new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 8, 1, "xewdszxvlp", new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 4, 1, "xrftlgdvdk", new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 30, 1, "kqfjllksgb", new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 27, 1, "wqqjlnkggk", new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 24, 1, "kqrjjncgkk", new DateTime(2020, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 21, 1, "hqtrkecvrk", new DateTime(2020, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 15, 1, "gdrrmlxctp", new DateTime(2020, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 7, 1, "xetdszdvdp", new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 5, 1, "affdstdoda", new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 13, 1, "reztssxclp", new DateTime(2020, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 19, 1, "tqvlkyxcrh", new DateTime(2020, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 22, 1, "yqbrmncvrk", new DateTime(2020, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 25, 1, "rqrjzncggk", new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 28, 1, "qqfjlvksgr", new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 18, 2, "wqtlkzxcth", new DateTime(2020, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 2, 1, "arfelpdvda", new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 14, 1, "cdrtklxclp", new DateTime(2020, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 20, 1, "xqvrkexvrk", new DateTime(2020, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 23, 1, "tqrmjncghk", new DateTime(2020, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 26, 1, "rfrjgncvgt", new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 29, 1, "rtfjlmksgr", new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 3, 1, "xrftlgdvdk", new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 6, 1, "yetdsudvda", new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 12, 2, "krpeobkvpt", new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Angazuje_LinijaID",
                table: "Angazuje",
                column: "LinijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Angazuje_VoziloID",
                table: "Angazuje",
                column: "VoziloID");

            migrationBuilder.CreateIndex(
                name: "IX_Cijena_KompanijaID",
                table: "Cijena",
                column: "KompanijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Cijena_LinijaID",
                table: "Cijena",
                column: "LinijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_AngazujeID",
                table: "Karta",
                column: "AngazujeID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_SjedisteID",
                table: "Karta",
                column: "SjedisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Kompanija_GradID",
                table: "Kompanija",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_KorisnikID",
                table: "KorisniciUloge",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_UlogaID",
                table: "KorisniciUloge",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Linija_KorisnikID",
                table: "Linija",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Linija_OdredisteID",
                table: "Linija",
                column: "OdredisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Linija_PolazisteID",
                table: "Linija",
                column: "PolazisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifikacije_NovostID",
                table: "Notifikacije",
                column: "NovostID");

            migrationBuilder.CreateIndex(
                name: "IX_Novosti_KorisnikID",
                table: "Novosti",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_KompanijaID",
                table: "Ocjena",
                column: "KompanijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_PutnikID",
                table: "Ocjena",
                column: "PutnikID");

            migrationBuilder.CreateIndex(
                name: "IX_PutnikNotifikacije_NotifikacijaID",
                table: "PutnikNotifikacije",
                column: "NotifikacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_PutnikNotifikacije_PutnikID",
                table: "PutnikNotifikacije",
                column: "PutnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KartaID",
                table: "Rezervacija",
                column: "KartaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_PutnikID",
                table: "Rezervacija",
                column: "PutnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Sjediste_VoziloID",
                table: "Sjediste",
                column: "VoziloID");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_KompanijaID",
                table: "Vozilo",
                column: "KompanijaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cijena");

            migrationBuilder.DropTable(
                name: "KorisniciUloge");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "PutnikNotifikacije");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "Notifikacije");

            migrationBuilder.DropTable(
                name: "Karta");

            migrationBuilder.DropTable(
                name: "Putnik");

            migrationBuilder.DropTable(
                name: "Novosti");

            migrationBuilder.DropTable(
                name: "Angazuje");

            migrationBuilder.DropTable(
                name: "Sjediste");

            migrationBuilder.DropTable(
                name: "Linija");

            migrationBuilder.DropTable(
                name: "Vozilo");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Kompanija");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
