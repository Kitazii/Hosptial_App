using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Task1_Hosptial.Models
{
    public class HospitalDBContext: DbContext
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Surgeon> Surgeons { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public HospitalDBContext():base("HospitalDataConnection")
        {
            Database.SetInitializer<HospitalDBContext>(new DropCreateDatabaseIfModelChanges<HospitalDBContext>());
        }

        public System.Data.Entity.DbSet<Task1_Hosptial.Models.Doctor> Doctors { get; set; }
    }
}