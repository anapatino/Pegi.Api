using Data.Repositories;
using Entities;

namespace Services;

public class LocationsService
{
    private readonly CitiesRepository      _citiesRepository;
    private readonly CountriesRepository   _countriesRepository;
    private readonly DepartmentsRepository _departmentsRepository;


    public LocationsService(CitiesRepository citiesRepository,
        DepartmentsRepository departmentsRepository,
        CountriesRepository countriesRepository)
    {
        _citiesRepository      = citiesRepository;
        _departmentsRepository = departmentsRepository;
        _countriesRepository   = countriesRepository;
    }

    public List<Department> GetDepartments()
    {
        return _departmentsRepository.GetAll().ToList();
    }

    public List<Country> GetCountries()
    {
        return _countriesRepository.GetAll().ToList();
    }

    public List<City> GetCities(string department)
    {
        return _citiesRepository.Filter(city =>
            city.Department.Name == department);
    }
}
