//using ApplicationCore.Commands.Users;
//using ApplicationCore.DTOs.User;
using ApplicationCore.Commands;
using ApplicationCore.Commands.Cliente;
using ApplicationCore.Commands.Logs;
using ApplicationCore.DTOs.Log;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using Infraestructure.EventHandlers.Cliente;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;
        private readonly IMediator _mediator;
        public DashboardController(IDashboardService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        // <summary>
        // Get de todos mis Usuarios
        // </summary>
        // <returns></returns>

        [Route("getData")]
        [HttpGet]

        public async Task<IActionResult> GetUsuarios()
        {
            var result = await _service.GetData();
            return Ok(result);
        }

        /// <summary>
        /// create
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]

        public async Task<ActionResult<Response<int>>> Create(CreateClienteCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }


        [HttpGet("GetIp")]
        public async Task<IActionResult> GetIp()
        {
            var result = await _service.GetIp();
            return Ok(result);
        }

        [Route("getPaginado")]
        [HttpGet]

        public async Task<IActionResult> GetPaginado()
        {
            var result = await _service.GetPaginado();
            return Ok(result);
        }

        [HttpPost("createLog")]
        public async Task<ActionResult<Response<int>>> CreateLog([FromBody] LogsDto request)
        {
            var result = await _service.CreateLog(request);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Response<int>>> UpdateCliente(UpdateClienteCommand request, int id)
        {
            request.id = id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("delete/{id}")]
        public async Task<ActionResult<Response<int>>> DeleteCliente(int id)
        {
            var command = new DeleteClienteCommand { id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
