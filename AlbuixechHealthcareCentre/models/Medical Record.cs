using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbuixechHealthcareCentre.models
{
    public class MedicalRecord
    {

        public int RecordID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
    }
}