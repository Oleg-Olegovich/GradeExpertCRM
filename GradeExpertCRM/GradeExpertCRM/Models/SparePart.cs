using System.ComponentModel.DataAnnotations;

namespace GradeExpertCRM.Models
{
    public class SparePart
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}