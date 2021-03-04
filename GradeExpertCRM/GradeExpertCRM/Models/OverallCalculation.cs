using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradeExpertCRM.Models
{
    public class OverallCalculation
    {
        [Key]
        public int Id { get; set; }

        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public Car Car { get; set; }

        /// <summary>
        /// Overall price for preparing tools per automobile
        /// </summary>
        public double PreparingToolPrice { get; set; }

        /// <summary>
        /// Overall price for anti-corrosion processing per automobile
        /// </summary>
        public double AntiCorrosionPrice { get; set; }

        /// <summary>
        /// Overall price for final processing per automobile
        /// </summary>
        public double FinalProcessingPrice { get; set; }

        public int TaxPercent { get; set; }
    }
}
