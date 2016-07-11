using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class Entity
    {
        [Key]
        public virtual long Id { get; set; }

        [NotMapped]
        public bool Exists
        {
            get { return Id > 0; }
        }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
