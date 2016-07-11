using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Model.Nomenclatures
{
    [Table("Gender", Schema = "Nom")]
    public class Gender : BaseNomEntity
    {

    }
}
