using EntityFrameworkDemo.Model;
using System;
using System.Linq;

namespace EntityFrameworkDemo
{
    using System;
    using System.Linq;

    public class Program
    {
        class EmployeeModel
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
        }

        static void Main(string[] args)
        {
            using (var ctx = new HrContext.HrContext())
            {
                var results = ctx.Database.SqlQuery<EmployeeModel>
                    ("SELECT * FROM HR.Employee WHERE HireDate >= '2016-01-01'").ToList<EmployeeModel>();

                var results2 = ctx.Employee.Where(x => x.HireDate >= new DateTime(2016, 1, 1)).ToList();

                var results3 = from employee in ctx.Employee
                               where employee.HireDate.Year == 2016
                               select employee;

                var results4 = ctx.Employee.GroupBy(x => x.Department.DepartmentName).Select(y => new
                {
                    DepartmentName = y.Key,
                    Salarii = y.Sum(t => t.Salary)
                });

                var results5 = (from emp in ctx.Employee
                                group emp by emp.Department.DepartmentName into gEmp
                                let sumaSalarii = gEmp.Sum(x => x.Salary)
                                select new
                                {
                                    DepartmentName = gEmp.Key,
                                    Salarii = sumaSalarii
                                }).ToList();

                foreach (var item in results5)
                {
                    System.Console.WriteLine(item.DepartmentName + " " + item.Salarii);
                }
                Console.ReadKey();
            }
        }
    }
}
