using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs.User
{
    public class ClienteDto
    {
        public string nombre { get; set; }

        public string apellidoPaterno { get; set; }

        public bool estatus {  get; set; }
    }
}
