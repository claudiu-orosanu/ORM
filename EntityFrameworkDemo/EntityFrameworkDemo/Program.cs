using EntityFrameworkDemo.Model;
using System;
using System.Linq;

namespace EntityFrameworkDemo
{
    using System;
    using System.Collections;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;
    using System.Linq;

    public class Program
    {
        public static object Ienumerable { get; private set; }

        class EmployeeModel
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
        }

        static void Main(string[] args)
        {
            //using (var ctx = new HrContext.HrContext())
            //{
            //    var results = ctx.Database.SqlQuery<EmployeeModel>
            //        ("SELECT * FROM HR.Employee WHERE HireDate >= '2016-01-01'").ToList<EmployeeModel>();

            //    var results2 = ctx.Employee.Where(x => x.HireDate >= new DateTime(2016, 1, 1)).ToList();

            //    var results3 = from employee in ctx.Employee
            //                   where employee.HireDate.Year == 2016
            //                   select employee;

            //    var results4 = ctx.Employee.GroupBy(x => x.Department.DepartmentName).Select(y => new
            //    {
            //        DepartmentName = y.Key,
            //        Salarii = y.Sum(t => t.Salary)
            //    });

            //    var results5 = (from emp in ctx.Employee
            //                    group emp by emp.Department.DepartmentName into gEmp
            //                    let sumaSalarii = gEmp.Sum(x => x.Salary)
            //                    select new
            //                    {
            //                        DepartmentName = gEmp.Key,
            //                        Salarii = sumaSalarii
            //                    }).ToList();

            //    foreach (var item in results3)
            //    {
            //        System.Console.WriteLine(item.FirstName + " " + item.LastName);
            //    }
            //    Console.ReadKey();
            //}

            using (var ctx = new HrContext.HrContext())
            {
                //var dep = ctx.Department.Where(x => x.DepartmentName == "IT").FirstOrDefault();
                //var dep = ctx.Department.FirstOrDefault(x => x.DepartmentName == "IT

                //if (dep != null)
                //{
                //    var employees = dep.Employees;
                //    foreach (var item in employees)
                //    {
                //        Console.WriteLine(item.GetFullName);
                //    }
                //}


                //update phonenumber
                //var empls = ctx.Employee.ToList();
                //foreach (var emp in empls)
                //{
                //    emp.PhoneNumber = "0000";
                //    ctx.Employee.AddOrUpdate(emp);
                //}
                //ctx.SaveChanges();


                //var employeeToDelete = ctx.Employee.Where(x => x.Id > 12).ToList();
                //if(employeeToDelete.Any())
                //{
                //    ctx.Employee.RemoveRange(employeeToDelete);
                //    ctx.SaveChanges();
                //}

                //Include se foloseste cu eager loading ca sa includem noi proprietatile cand dorim
                //Lazy loading -> in hrContext lazy = true si proxy = true + prop virtual
                //Eager loading -> in hrContext lazy = false si proxy = false (si dam include)

                //lazy loading -> nu sunt in memorie pana le accesam (sunt referite prin proxy-uri)
                //eager ->datele sunt bagate in memorie (se baga cu include)
                //var employee = ctx.Employee.Include(x => x.Department).Include(x => x.Job).First();


                //nu se foloseste in practica
                //var employee2 = ctx.Employee.First();
                //ctx.Entry(employee2).Reference(s => s.Department).Load();


                //var job = ctx.Jobs.FirstOrDefault(x => x.JobTitle == "Internship");
                //if(job != null)
                //{
                //    job.MinSalary = 3;
                //    ctx.Jobs.AddOrUpdate(job);
                //    ctx.SaveChanges();
                //}


                var newManager = ctx.Employee.Where(x => x.FirstName == "Raluca" && x.LastName == "Ionescu").FirstOrDefault();
                var newManagerId = new SqlParameter("@NewManagerId", newManager.Id);

                var employees = ctx.Database.SqlQuery<Employee>("exec Hr.ChangeManager @NewManagerId",newManagerId).ToList();
                foreach (var item in employees)
                {
                    Console.WriteLine("Employee: {0} {1}, Manager: {2}",item.FirstName, item.LastName,item.ManagerId ?? null);
                }


                /*Tema : FOTBAL minim 3 tabele/clase
                    CodeFirst
                    diagrama pe foaie
                    prima migrare conventii tabele
                    a dou
                 
                 */
                Console.ReadKey();
            }
                

        }
    }
}
