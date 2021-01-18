using System.Collections.Generic;

namespace GradeExpertCRM.Models
{
    public class Calculation
    {
        public string ComponentName { get; set; }

        public bool IsGrandExpert { get; set; }

        public bool IsFixPrice { get; set; }

        public int Price { get; set; }

        public int DentCount { get; set; }

        public int DentDiameter { get; set; }

        /// <summary>
        /// Type of repair. Default value: WithoutPainting
        /// </summary>
        public RepairType RepairType { get; set; }

        /// <summary>
        /// Material type. Default value: false - "Steel"
        /// </summary>
        public bool IsAluminum { get; set; }

        /// <summary>
        /// Is "Glue Technique" applied. Default value: false
        /// </summary>
        public bool IsGlueTechnique { get; set; }

        public int PaintingPrice { get; set; }

        public List<AssemblyWork> AssemblyWorks { get; set; }

        public List<SparePart> SpareParts { get; set; }
    }

    public enum RepairType
    {
        WithoutPainting,
        WithPainting,
        Replacing
    }

    public class SparePart
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
    }

    public class AssemblyWork
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public double WorkingHours { get; set; }

        public string WorkName { get; set; }
    }
}
