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
            Splat.Locator.CurrentMutable.RegisterConstant<IRepository<Settings>>(new Repository<Settings>());
            Splat.Locator.CurrentMutable.RegisterConstant<IRepository<DetailsSettings>>(new Repository<DetailsSettings>());
            Splat.Locator.CurrentMutable.RegisterConstant<IRepository<Car>>(new Repository<Car>());
            Splat.Locator.CurrentMutable.RegisterLazySingleton<IRepository<Client>>(() => new Repository<Client>());
            Splat.Locator.CurrentMutable.RegisterLazySingleton<IRepository<Calculation>>(() => new Repository<Calculation>());
            Splat.Locator.CurrentMutable.RegisterLazySingleton<IRepository<Document>>(() => new Repository<Document>());
            Splat.Locator.CurrentMutable.RegisterLazySingleton<ICalculationRepository>(() => new CalculationRepository());
            Splat.Locator.CurrentMutable.RegisterLazySingleton<ICarRepository>(() => new CarRepository());
        }
    }
}
