using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDemo.Model
{
    [Table("Location", Schema = "Hr")]
    public class Location : Entity
    {
        public virtual string StreetAddress { get; set; }

        //[ConcurrencyCheck] atribut pentru concurenta pt fiecare camp explicit
        public virtual string PostalCode { get; set; }

        [Required]
        [MaxLength(30)]
        public virtual string City { get; set; }

        public virtual string StateProvince { get; set; }
    }
}
