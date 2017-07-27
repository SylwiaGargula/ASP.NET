using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace gadzeciak.Models
{
    public class gadzeciakContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
       
        public gadzeciakContext() : base("name=gadzeciakContext")
        {
        }

        public System.Data.Entity.DbSet<gadzeciak.Models.Produkt> Produkts { get; set; }

        public System.Data.Entity.DbSet<gadzeciak.Models.Uzytkownik> Uzytkowniks { get; set; }

        public System.Data.Entity.DbSet<gadzeciak.Models.Kategoria> Kategorias { get; set; }
        public System.Data.Entity.DbSet<gadzeciak.Models.ElementKoszyka> ElementKoszykas { get; set; }

        public System.Data.Entity.DbSet<gadzeciak.Models.DaneDoKoszyka> DaneDoKoszykas { get; set; }

        public System.Data.Entity.DbSet<gadzeciak.Models.Roles> Roles { get; set; }
        public System.Data.Entity.DbSet<gadzeciak.Models.UserRoles> UserRoles { get; set; }

        public System.Data.Entity.DbSet<gadzeciak.Models.Zamowienie> Zamowienies { get; set; }

        public System.Data.Entity.DbSet<gadzeciak.Models.PozycjaZamowienia> PozycjaZamowienias { get; set; }

    }
}
