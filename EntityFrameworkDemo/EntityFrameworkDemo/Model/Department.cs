namespace EntityFrameworkDemo.Model
{
    public class Department
    {
        public long DepartmentId { get; set; }
        
        public string DepartmentName { get; set; }

        public long? LocationId { get; set; }
    }
}
