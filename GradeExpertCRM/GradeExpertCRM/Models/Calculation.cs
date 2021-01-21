using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GradeExpertCRM.Models
{
    public class Calculation
    {
        public string ComponentName { get; set; }

        public bool IsFixPrice { get; set; }

        public double Price { get; set; }

        public int DentQuantity { get; set; }

        public int DentDiameter { get; set; }

        public double NHours { get; set; } //TODO check is this property necessary

        public double DentPrice { get; set; }

        /// <summary>
        /// Material type. Default value: false - "Steel"
        /// </summary>
        public bool IsAluminum { get; set; }

        /// <summary>
        /// Is "Adhesive" applied. Default value: false
        /// </summary>
        public bool IsAdhesive { get; set; }

        /// <summary>
        /// Type of repair. Default value: WithoutPainting
        /// </summary>
        public TypeOfRepair TypeOfRepair { get; set; }

        public double PriceOfPainting { get; set; }

        public List<DismantlingWorks> DismantlingWorks { get; set; }

        public List<SparePart> SpareParts { get; set; }
    }

    public enum TypeOfRepair
    {
        WithoutPainting,
        UnderPainting,
        Replacement
    }

    public class SparePart
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }

    public class DismantlingWorks
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double WorkingHours { get; set; }

        public string WorkName { get; set; }
    }
}
