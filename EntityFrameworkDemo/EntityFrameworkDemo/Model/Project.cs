using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Model
{
    [Table("Project", Schema = "Hr")]
    public class Project : Entity
    {
        [Required]
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
