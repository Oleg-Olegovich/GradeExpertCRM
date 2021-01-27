using System;
using System.Collections.Generic;
using System.Text;

namespace GradeExpertCRM.Models.Data.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        public IEnumerable<Calculation> GetCalculationsByCarId(int id);
    }
}
