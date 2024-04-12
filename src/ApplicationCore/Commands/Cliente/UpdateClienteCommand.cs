using ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Commands.Cliente
{
    public class UpdateClienteCommand : IRequest<Response<int>>
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public string apellidoPaterno { get; set; }

        public bool estatus { get; set; }
    }
}
