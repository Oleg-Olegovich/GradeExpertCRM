using System;

namespace GradeExpertCRM.Models
{
    public class Damage
    {
        public string DamageType { get; set; } = "ГРАД";

        public string InsuranceCompany{ get; set; }

        public string PolicyNumber { get; set; }

        public string LossNumber { get; set; }

        public int Franchise { get; set; }

        public DateTime InspectionDate { get; set; }

        public string Inspector { get; set; }
    }
}
