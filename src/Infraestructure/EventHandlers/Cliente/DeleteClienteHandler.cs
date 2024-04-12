using ApplicationCore.Commands.Cliente;
using ApplicationCore.DTOs.Log;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Infraestructure.Persistence;
using Infraestructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infraestructure.EventHandlers.Cliente
{
    public class DeleteClienteHandler : IRequestHandler<DeleteClienteCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDashboardService _dashboardService;

        public DeleteClienteHandler(ApplicationDbContext context, IMapper mapper, IDashboardService dashboardService)
        {
            _context = context;
            _mapper = mapper;
            _dashboardService = dashboardService;
        }

        public async Task<Response<int>>Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = await _context.clientes.FindAsync(request.id);
                cliente.estatus = false;
                await _context.SaveChangesAsync();
                return new Response<int>(cliente.id, "Cliente Eliminado con éxito");
            }
            catch (Exception ex)
            {
                var logs = new LogsDto();
                logs.datos = JsonSerializer.Serialize(request);
                logs.fecha = DateTime.Now;
                logs.nombreFuncion = "DeleteCliente";
                logs.response = ex.Message;

                await _dashboardService.CreateLog(logs);
                throw;
            }
        }
    }
}
