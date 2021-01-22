using System.ComponentModel.DataAnnotations;

namespace GradeExpertCRM.Models
{
    public class DismantlingWork
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double WorkingHours { get; set; }

        public string WorkName { get; set; }
    }
}