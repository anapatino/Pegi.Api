using Data.Repository;
using Entities;

namespace Services;

public class LocationsService
{
    private readonly CitiesRepository _citiesRepository;
    private readonly DepartmentsRepository _departmentsRepository;

    public LocationsService(CitiesRepository citiesRepository, DepartmentsRepository departmentsRepository)
    {
        _citiesRepository = citiesRepository;
        _departmentsRepository = departmentsRepository;
    }

    public List<Department> GetDepartments()
    {
        return _departmentsRepository.GetAll();
    }

    public List<City> GetCities(string department)
    {
        return _citiesRepository.Filter(city =>
            city.Department != null && city.Department.Name == department);
    }

    public Department GetDepartmentByCityCode(string cityCode)
    {
        City city = _citiesRepository.Find(d => d.Id == cityCode);
        if (city != null)
        {
            return _departmentsRepository.Find(d => d.Id == city.DepartmentCode);
        }
        return null;
    }
}
