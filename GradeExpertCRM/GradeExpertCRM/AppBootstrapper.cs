using GradeExpertCRM.Models;
using GradeExpertCRM.Models.Data;
using GradeExpertCRM.Models.Data.Repositories;
using Splat;

namespace GradeExpertCRM
{
    /// <summary>
    /// For Dependency Injection
    /// </summary>
    public class AppBootstrapper
    {
        public AppBootstrapper()
        {   // Registreted services
            Splat.Locator.CurrentMutable.RegisterConstant(new AppDbContext());
            Splat.Locator.CurrentMutable.RegisterConstant(new Repository<Client>(), typeof(IRepository<Client>));
            Splat.Locator.CurrentMutable.RegisterConstant(new Repository<Car>(), typeof(IRepository<Car>));
            Splat.Locator.CurrentMutable.RegisterConstant(new Repository<Calculation>(), typeof(IRepository<Calculation>));
        }
    }
}
