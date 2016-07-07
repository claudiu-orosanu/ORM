namespace EntityFrameworkDemo.Model
{
    using System;

    public class Employee
    {
        public long EmployeeId { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }

        public decimal Salary { get; set; }

        public decimal? CommisionPercent { get; set; }

        public DateTime HireDate { get; set; }
        
        public long? JobId { get; set; }

        public long? ManagerId { get; set; }

        public long? DepartamentId { get; set; }
    }
}
