using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using Dapper;
using Infraestructure.Persistence;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Net;
using ApplicationCore.DTOs.Log;
using ApplicationCore.Commands.Logs;
using AutoMapper;

namespace Infraestructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public DashboardService(ApplicationDbContext dbContext, ICurrentUserService currentUserService, IMapper mapper)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<Response<object>> GetData()
        {
            object list = new object();
            list = await _dbContext.clientes.Where(c=>c.estatus == true).ToListAsync();    
            return new Response<object>(list);
        }

        public async Task<Response<string>> GetIp()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress IpAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            var ip = IpAddress?.ToString() ?? "No se puede obtener la ip";
            return new Response<string>(ip);
        }

        public async Task<Response<int>> CreateLog(LogsDto request)
        {
            var ipAdress = await GetIp();
            var db = ipAdress.Message.ToString();
            var l = new LogsDto();

            l.ip = db;
            l.fecha = request.fecha;
            l.nombreFuncion = request.nombreFuncion;
            l.response = request.response;
            l.datos = request.datos;

            var lo = _mapper.Map<Domain.Entities.logs>(l);

            await _dbContext.AddAsync(lo);
            await _dbContext.SaveChangesAsync();
            return new Response<int>(1, "Registro Log Creado");
        }
   
        public async Task<Response<object>> GetPaginado()
        {
            object list = new object();

            int pageNumber = 1;
            int pageSize = 10;

            list = await _dbContext.clientes.OrderBy(x => x.id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new Response<object>(list);
        }
    }
}
