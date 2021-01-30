using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace GradeExpertCRM.Models.Data.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public int SelectedCarId { get; set; }

        public Car CarWithCalculations(int id)
        {
            return dbContext_.Cars.Include(x => x.Calculations).FirstOrDefault(x => x.Id == id);
        }
    }
}
