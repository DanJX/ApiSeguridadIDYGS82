using ApplicationCore.Commands;
using ApplicationCore.Commands.Logs;
using ApplicationCore.Wrappers;
using AutoMapper;
using Infraestructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.EventHandlers.LogR
{
    public class CreateLogHandler : IRequestHandler<CreateLogsCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateLogHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Response<int>> Handle(CreateLogsCommand request, CancellationToken cancellationToken)
        {
            var l = new CreateLogsCommand();
            l.ip = request.ip;
            l.fecha = request.fecha;
            l.nombreFuncion     = request.nombreFuncion;
            l.response = request.response;
            l.datos = request.datos;


            var lo = _mapper.Map<Domain.Entities.logs>(l);

            await _context.AddAsync(lo);
            await _context.SaveChangesAsync();
            return new Response<int>(lo.id, "Registro Log Creado");

        }
    }
}
