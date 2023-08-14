using LUMAApp.Entities;
using LUMAApp.Models;

namespace LUMAApp.Services;


public interface IRegisterService
{

    void Register(RegisterRequest request);
}

public class RegisterService: IRegisterService
{
    private Context _context;

    public RegisterService(Context context)
    {
        _context = context;
    }
    public void Register(RegisterRequest registerRequest)
    {
        if(_context.Employees.Any(x=>x.EMail == registerRequest.Email)){
            throw new Exception("Email already registered");
        } else
        {
            var employee = new Employee();
            employee.EMail = registerRequest.Email;
            employee.EmployeeName = registerRequest.Name;
            employee.PasswordHashed = registerRequest.Password;

            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
    }
}

