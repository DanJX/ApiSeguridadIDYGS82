using ApplicationCore.Commands.Cliente;
using ApplicationCore.DTOs.Log;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Infraestructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infraestructure.EventHandlers.Cliente
{
    public class UpdateClienteHandler : IRequestHandler<UpdateClienteCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDashboardService _dashboardService;

        public UpdateClienteHandler (ApplicationDbContext context, IMapper mapper, IDashboardService dashboardService)
        {
            _context = context;
            _mapper = mapper;
            _dashboardService = dashboardService;
        }

        public async Task<Response<int>>Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = await _context.clientes.FindAsync(request.id);
                
                cliente.nombre          = request.nombre;
                cliente.apellidoPaterno = request.apellidoPaterno;
                cliente.estatus         = request.estatus;  

                await _context.SaveChangesAsync();
                return new Response<int>(cliente.id, "Cliente Actualizado con éxito");
            }
            catch(Exception ex) 
            {
                var logs = new LogsDto();
                logs.datos = JsonSerializer.Serialize(request);
                logs.fecha = DateTime.Now;
                logs.nombreFuncion = "UpdateCiente";
                logs.response = ex.Message;

                await _dashboardService.CreateLog(logs);
                throw;
            }
        }
    }
}
