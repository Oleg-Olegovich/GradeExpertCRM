using System;
using System.Collections.Generic;
using System.Text;

namespace GradeExpertCRM.Models
{
    public class Damage
    {
        public string DamageType { get; set; } = "ГРАД";

        public string InsuranceCompany{ get; set; }

        public string PolicyNumber { get; set; }

        public string LossNumber { get; set; }

        public double Franchise { get; set; } //TODO int or double

        public string InspectionDate { get; set; } //TODO Can be DateTime?

        public string Inspector { get; set; }
    }
}
