using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDemo.Model
{
    [Table("Department", Schema = "Hr")]
    public class Department : Entity
    {
        [Required]
        [MaxLength(30)]
        public virtual string DepartmentName { get; set; }


        public virtual long? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
