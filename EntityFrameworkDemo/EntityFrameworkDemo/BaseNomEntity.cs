using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Model.Nomenclatures
{
    public class BaseNomEntity
    {
        [Key]
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
    }
}
