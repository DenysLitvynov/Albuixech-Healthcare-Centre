using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbuixechHealthcareCentre.models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string PIN { get; set; }
        public int? UserID { get; set; }


    }
}