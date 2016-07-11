using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Model.Nomenclatures
{
    [Table("Level", Schema = "Nom")]
    public class Level : BaseNomEntity
    {
        
    }
}
