using System;
using System.Collections.Generic;
using System.Text;

namespace GradeExpertCRM.Models.Data.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        public int SelectedCarId { get; set; }

        public Car CarWithCalculations(int id);
    }
}
