using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Task1_Hosptial.Models
{
    public class Hospital
    {
        [Key]
        public int HospitalId { get; set; }
        [Display(Name = "Hospital Name:")]
        public string HospitalName { get; set; }

        //One to many
        public List<Ward> Wards { get; set; }
        public List<Surgeon> Surgeons { get; set; }
        public List<Doctor> Doctors { get; set; }

        //many to many
        public List <Patient> Patients { get; set; }
    }

    public class Ward
    {
        [Key]
        public int WardId { get; set; }

        [Display(Name = "Ward Name:")]
        public string WardName { get; set; }

        [Display(Name = "No Bed:")]
        public int NoBed;

        //one to many
        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }

    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Display(Name = "Patient Name:")]
        public string PatientName { get; set; }

        //many to many
        public List<Hospital> Hospitals { get; set; }
    }

    public class Surgeon
    {
        [Key]
        public int SurgeonId { get; set; }
        public string Firstname { get; set; }

        [Display(Name = "surname:")]
        public string Lastname { get; set; }
        public bool Qualifications { get; set; }

        //one to many
        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }

    public class Doctor
    {
        [Key]
        public int DoctorId { get; set;}

        [Display(Name = "Doctor Name:")]
        public string DoctorName { get; set; }

        //one to many
        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

    }
}