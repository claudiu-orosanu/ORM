namespace EntityFrameworkDemo.Model
{
    public class Job
    {
        public long JobId { get; set; }

        public string JobTitle { get; set; }

        public decimal? MinSalary { get; set; }

        public decimal? MaxSalary { get; set; }
    }
}
