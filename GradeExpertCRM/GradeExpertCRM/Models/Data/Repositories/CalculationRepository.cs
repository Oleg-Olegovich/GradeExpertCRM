using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeExpertCRM.Models.Data.Repositories
{
    public class CalculationRepository : Repository<Calculation>, ICalculationRepository
    {
        public CalculationRepository(AppDbContext dbContext = null) : base(dbContext) { }
        public int SelectedCarId { get; set; }
    }
}
