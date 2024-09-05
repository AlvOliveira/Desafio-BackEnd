using Microsoft.AspNetCore.Mvc;
using Motto.MR.Domain.Handler;
using Motto.MR.Shared.Commands;
using Motto.MR.Shared.Commands.Request;
using Serilog;

namespace Motto.MR.Api.Controllers
{
    public class MotorcycleRegisterLogController : ControllerBase
    {
        [HttpPost("getall-motorcycleregisterlogs")]
        public async Task<IActionResult> GetAllMotorcycleRegisterLogs
        (
            [FromBody] GetAllMotorcycleRegisterLogsRequest command,
            [FromServices] MotorcycleRegisterLogHandler handler
        )
        {
            Log.Debug("GetAllMotorcycleRegisterLogs");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("GetAllMotorcycleRegisterLogs 885208 {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }
    }
}
