using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorRPUA.Shared
{
    public class PrimalacUsluga
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KontaktTel { get; set; }
        public string Email { get; set; }
        public Adresa Adresa { get; set; }
    }

}
