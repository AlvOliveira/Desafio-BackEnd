using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motto.MR.Domain.Handler;
using Motto.MR.Shared.Commands;
using Serilog;

namespace Motto.MR.Api.Controllers
{
    public class MotorcycleEventRegisterMQController : ControllerBase
    {
        [HttpPost("getall-motorcycleeventregistermq")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllMotorcycleEventRegisterMQ
        (
            [FromServices] MotorcycleRegisterLogHandler handler
        )
        {
            Log.Debug("GetAllMotorcycleEventRegisterMQ");

            try
            {
                return Ok((CommandResultDefault)handler.Handle());
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("GetAllMotorcycleEventRegisterMQ 885208 {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }
    }
}
