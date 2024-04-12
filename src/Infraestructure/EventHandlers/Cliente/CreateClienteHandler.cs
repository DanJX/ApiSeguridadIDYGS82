using ApplicationCore.Wrappers;
using Infraestructure.Persistence;
using AutoMapper;
using MediatR;
using ApplicationCore.Commands;
using ApplicationCore.Interfaces;
using ApplicationCore.DTOs.Log;
using System.Text.Json;

namespace Infraestructure.EnventHandlers.Cliente
{
    public class CreateClienteHandler : IRequestHandler<CreateClienteCommand ,Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDashboardService _dashboardService;

        public CreateClienteHandler(ApplicationDbContext context, IMapper mapper, IDashboardService dashboardService)
        {
            _context = context;
            _mapper = mapper;
            _dashboardService = dashboardService;

        }

        public async Task<Response<int>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            try 
            {
                var u = new CreateClienteCommand();
                u.nombre            = request.nombre;
                u.apellidoPaterno   = request.apellidoPaterno;
                u.estatus           = true;
   
                var us = _mapper.Map<Domain.Entities.cliente>(u);
                await _context.clientes.AddAsync(us);
                await _context.SaveChangesAsync();
                    
                return new Response<int>(us.id, "Registro Creado");
         
            }
            catch (Exception ex)
            {
                var logs = new LogsDto();
                logs.datos = JsonSerializer.Serialize(request);
                logs.fecha = DateTime.Now;
                logs.nombreFuncion = "CreateCliente";
                logs.response = ex.Message;

                await _dashboardService.CreateLog(logs);
                throw;
            }

        }
    }
}