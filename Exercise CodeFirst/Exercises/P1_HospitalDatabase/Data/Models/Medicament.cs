using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        public Medicament()
        {
            Prescriptions = new HashSet<PatientMedicament>();
        }

        public int MedicamentId { get; set; }
        public string Name { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; }
        //Medicament:
        // MedicamentId
        // Name(up to 50 characters, unicode)
        // PatientMedicament – mapping class between Patients and Medicaments
    }
}
