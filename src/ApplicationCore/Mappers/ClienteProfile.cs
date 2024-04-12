using ApplicationCore.Commands;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Mappers
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile() 
        {
            CreateMap<CreateClienteCommand, cliente>()
                .ForMember(x => x.id, y => y.Ignore());
        }
    }
}
