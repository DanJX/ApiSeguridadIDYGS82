using ApplicationCore.DTOs.Log;
using ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Commands.Logs
{
    public class CreateLogsCommand : LogsDto, IRequest<Response<int>>
    {
    }
}
