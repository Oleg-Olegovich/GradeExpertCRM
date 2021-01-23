using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradeExpertCRM.Models
{
    public class DismantlingWork
    {
        [Key]
        public int Id { get; set; }

        public int CalculationId { get; set; }

        [ForeignKey(nameof(CalculationId))]
        public Calculation Calculation { get; set; }

        public bool IsApplied { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double WorkingHours { get; set; }

        public string WorkName { get; set; }
    }
}