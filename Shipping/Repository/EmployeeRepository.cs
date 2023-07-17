
using Microsoft.EntityFrameworkCore;
using Shipping.Data;
using Shipping.Models;
namespace Shipping.Repository

{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ShippingContext _shippingContext;
        public EmployeeRepository(ShippingContext shippingContext)
        {
            this._shippingContext = shippingContext;
        }

        public void delete(string id)
        {
            var employee = _shippingContext.Employees.FirstOrDefault(e => e.Id == id);

            employee.IsDeleted = true;
            update(employee);
        }

        public List<Employee> getall()
        {
            return _shippingContext.Employees.Where(n => n.IsDeleted== false).Include(m=>m.branches).ToList();
        }

        public Employee getbyid(string id)
        {
            return _shippingContext.Employees.Where(n=>n.Id==id).Include(n=>n.branches).FirstOrDefault();
        }

        public void Save()
        {
            _shippingContext.SaveChanges();
        }

        public void update(Employee employee)
        {
            var existingEmployee = _shippingContext.Employees.Find(employee.Id);

            if (existingEmployee != null)
            {
                // Update the properties of the existing employee with the new values
                existingEmployee.UserName = employee.UserName;
                existingEmployee.Email = employee.Email;
                existingEmployee.PhoneNumber = employee.PhoneNumber;
                existingEmployee.Address = employee.Address;
                existingEmployee.Id_Branch = employee.Id_Branch;

                // Save the changes to the database
                _shippingContext.SaveChanges();
            }
           
        }
    }
}
