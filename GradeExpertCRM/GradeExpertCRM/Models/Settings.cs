using System.ComponentModel.DataAnnotations;

namespace GradeExpertCRM.Models
{
    public class Settings
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double RemoveDentsPrice { get; set; }
        //[Required]
        public double DismantlingPrice { get; set; }
        //[Required]
        public double FinishingProcessingPrice { get; set; }
        //[Required]
        public double AntiCorrosionPrice { get; set; }
        //[Required]
        public double PreparingToolPrice { get; set; }
        //[Required]
        public double FinishProcessingNHours { get; set; }
        //[Required]
        [Range(0, 100)]
        public int AluminumPercent { get; set; }
        //[Required]
        [Range(0, 100)]
        public int GlueTechniquePercent { get; set; }
        //[Required]
        [Range(0, 100)]
        public int UnderPantingPercent { get; set; }
        //[Required]
        [Range(0, 100)]
        public int? TaxPercent { get; set; }
        public string Language { get; set; } = "Russian";
    }
}
