using ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.DTOs.User;

namespace ApplicationCore.Commands
{
    public class CreateClienteCommand : ClienteDto, IRequest<Response<int>>
    {
    }
}
