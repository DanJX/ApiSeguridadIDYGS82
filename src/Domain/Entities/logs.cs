using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("logs")]
    public class logs
    {
        [Key]
        public int id { get; set; }
        public DateTime fecha { get; set; }

        public string nombreFuncion { get; set; }
        public string ip { get; set; }

        public string datos { get; set; }
        public string response { get; set; }
    }
}
