using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motto.MR.Domain.Commands.Requests.Motor;
using Motto.MR.Domain.Handler;
using Motto.MR.Shared.Commands;
using Serilog;

namespace Motto.MR.Api.Controllers
{
    public class MotorcycleController : ControllerBase
    {
        [HttpPost("create-motorcycle")]
        //[Authorize(Policy = "AdminPolicy")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateMotorcycle(
            [FromBody] CreateMotorcycleRequest command,
            [FromServices] MotorcycleHandler handler
        )
        {
            Log.Debug("CreateMotorcycle");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("CreateMotorcycle 997418 {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("update-motorcycle")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateMotorcycle(
            [FromBody] UpdateMotorcycleRequest command,
            [FromServices] MotorcycleHandler handler
        )
        {
            Log.Debug("UpdateMotorcycle");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("UpdateMotorcycle 5207418 {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("delete-motorcycle")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMotorcycle(
            [FromBody] DeleteMotorcycleRequest command,
            [FromServices] MotorcycleHandler handler
        )
        {
            Log.Debug("DeleteMotorcycle");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("DeleteMotorcycle 8807418 {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("getall-motorcycles")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllMotorcycles
        (
            [FromServices] MotorcycleHandler handler
        )
        {
            Log.Debug("GetAllMotorcycles");

            try
            {
                return Ok((CommandResultDefault)handler.Handle());
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("GetAllMotorcycles 007418 {error}", e.Message);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("getbyid-motorcycle")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdMotorcycle
        (
            [FromBody] GetByIdMotorcycleRequest command,
            [FromServices] MotorcycleHandler handler
        )
        {
            Log.Debug("GetByIdMotorcycle");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("GetByIdMotorcycle 337418 {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("getbylicenseplate-motorcycle")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByLicensePlateMotorcycle
        (
            [FromBody] GetByLicensePlateMotorcycleRequest command,
            [FromServices] MotorcycleHandler handler
        )
        {
            Log.Debug("GetByLicensePlateMotorcycle");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("GetByLicensePlateMotorcycle QT7778 {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }
    }
}
