using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs.Log
{
    public class LogsDto
    {
        public int? id { get; set; }
        public DateTime fecha { get; set; }

        public string nombreFuncion { get; set; }
        public string ip { get; set; }

        public string datos { get; set; }
        public string response { get; set; }
    }
}
