
using Shipping.Models;
namespace Shipping.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> getall();
        Employee getbyid(string id);
        void update(Employee emp);
        void Save();
        void delete(string id);
    }
}
