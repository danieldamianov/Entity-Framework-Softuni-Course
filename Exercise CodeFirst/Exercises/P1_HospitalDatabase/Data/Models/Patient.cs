using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            Diagnoses = new HashSet<Diagnose>();
            Visitations = new HashSet<Visitation>();
            Prescriptions = new HashSet<PatientMedicament>();
        }

        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool HasInsurance { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; }
        public ICollection<Visitation> Visitations { get; set; }
        public ICollection<PatientMedicament> Prescriptions { get; set; }
        //Patient:
        // PatientId

        //© Software University Foundation.This work is licensed under the CC-BY-NC-SA license.
        //Follow us: Page 2 of 4

        // FirstName (up to 50 characters, unicode)
        // LastName(up to 50 characters, unicode)
        // Address(up to 250 characters, unicode)
        // Email(up to 80 characters, not unicode)
        // HasInsurance
    }
}
