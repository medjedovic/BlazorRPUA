using BlazorRPUA.Shared;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRPUA.Server.Hubs
{
    public class PrimalacUHub : Hub
    {


        //public void printss()
        //{
        //    Console.WriteLine("Javlja se primalac usluga HUB!!!!");
        //}

        private readonly EFDB db;
        public PrimalacUHub(EFDB baza)
        {
            db = baza;
        }

        public void ispisPrimalacAdrese()
        {
            db.Adresas.ToList();
            var pu = db.PrimalacUslugas.First();
            Console.WriteLine($"Prvi korisnik je: Ime:{pu.Ime}\n Prezime:{pu.Prezime}\n Ulica:{pu.Adresa.Ulica}!!!!");
        }


        //čitanje postojećih podataka iz baze
        public async Task UcitajPrimalacUslugaData()
        {
            db.Adresas.ToList();
            await Clients.Caller.SendAsync("PrimalacUslugaCL", db.PrimalacUslugas.ToList());
        }

        //metoda za brisanje selektovanog objekta
        public void PrimalacUslugeB(PrimalacUsluga PU)
        {
            try
            {
                db.PrimalacUslugas.Remove(PU);
                db.SaveChanges();
                UcitajPrimalacUslugaData();
                Clients.Caller.SendAsync("porukaModal", $"Uspešno ste obrisali podatke!");
            }
            catch (Exception ex)
            {
                Clients.Caller.SendAsync("porukaModal", $"GREŠA!\n {ex.Message}");
                //Console.WriteLine("Takvi podaci Već POSTOJE U BAZI PODATAKA!" + ex.Message);
            }

        }


        public async Task PrimalacUslugaIS(PrimalacUsluga PU)
        {
            //Console.WriteLine($"Primalac usluga koji se šalje na snimanje:{PU.Ime}, Ulica:{PU.Adresa.Ulica} br.:{PU.Adresa.Broj}");

            //pronalaženje id od PruzalacUsluga u tabeli ako NE postoji njegov ID dodaj novi poslani zapis odnosno objekat PU
            var UCur = db.PrimalacUslugas.Find(PU.ID);
            if (UCur == null)
            {
                try
                {
                    db.PrimalacUslugas.Add(PU);
                    Clients.Caller.SendAsync("porukaModal", $"Uspešno ste unijeli podatke!");
                }
                catch (Exception ex)
                {
                    Clients.Caller.SendAsync("porukaModal", $"GREŠA!\n {ex.Message}");
                    //Console.WriteLine("Takvi podaci Već POSTOJE U BAZI PODATAKA!" + ex.Message);
                }

            }
            else
            //ukoliko postoji PruzalacUsluga sa tim ID-jem onda obriši postojeći i dodaj novi sa postojećim podacima
            //drugim riječima izmijeni postojeći
            {
                try
                {
                    db.PrimalacUslugas.Update(PU);
                    
                    //brisanje podataka stare adrese i dodavanje unete
                    //ovo radi samo pri relaciji jedan na jedan
                    //db.Adresas.Remove(UCur.Adresa);
                    //db.Adresas.Add(PU.Adresa);
                    
                    //PU.Adresa = db.Adresas.Find(PU.Adresa.ID);

                    Clients.Caller.SendAsync("porukaModal", $"Uspešno ste izmijenili podatke!");
                }
                catch (Exception ex)
                {
                    Clients.Caller.SendAsync("porukaModal", $"GREŠA!\n {ex.Message}");
                    //Console.WriteLine("Takvi podaci Već POSTOJE U BAZI PODATAKA!" + ex.Message);
                }

            }
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Clients.Caller.SendAsync("porukaModal", $"Takvi podaci Već POSTOJE U BAZI PODATAKA!\n {ex.Message}");
                //Console.WriteLine("Takvi podaci Već POSTOJE U BAZI PODATAKA!"+ ex.Message);
            }

        }

        public void updatePodataka(PrimalacUsluga PU) 
        {
            db.Update(PU);
            db.SaveChanges();
        }

        public async Task UcitajPrimalacUslugaP(string _pretraga)
        {
            db.Adresas.ToList();

            //probati metodu koju smo uradili u klasi
            await Clients.Caller.SendAsync("PrimalacUslugaCL", db.PrimalacUslugas.Where(p => p.Ime.ToLower().Contains(_pretraga.ToLower()) ||
                                                                                             p.Prezime.ToLower().Contains(_pretraga.ToLower())).ToList());
        }
    }
}
