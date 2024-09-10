using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motto.MR.Domain.Commands.Requests.Rent;
using Motto.MR.Domain.Handler;
using Motto.MR.Shared.Commands;
using Serilog;

namespace Motto.MR.Api.Controllers
{
    public class RentalController : ControllerBase
    {
        [HttpPost("create-rental")]
        [Authorize(Roles = "Admin,Delivery")]
        public async Task<IActionResult> CreateRental(
            [FromBody] CreateRentalRequest command,
            [FromServices] RentalHandler handler
        )
        {
            Log.Debug("CreateRental");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("CreateRental 8D893T {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("update-rental")]
        [Authorize(Roles = "Admin,Delivery")]
        public async Task<IActionResult> UpdateRental(
            [FromBody] UpdateRentalRequest command,
            [FromServices] RentalHandler handler
        )
        {
            Log.Debug("UpdateRental");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("UpdateRental MIUIM1 {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("delete-rental")]
        [Authorize(Roles = "Admin,Delivery")]
        public async Task<IActionResult> DeleteRental(
            [FromBody] DeleteRentalRequest command,
            [FromServices] RentalHandler handler
        )
        {
            Log.Debug("DeleteRental");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("DeleteRental V7PRR4 {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("getall-rentals")]
        [Authorize(Roles = "Admin,Delivery")]
        public async Task<IActionResult> GetAllRentals
        (
            [FromServices] RentalHandler handler
        )
        {
            Log.Debug("GetAllRentals");

            try
            {
                return Ok((CommandResultDefault)handler.Handle());
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("GetAllRentals IS01N1 {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("getbyid-rental")]
        [Authorize(Roles = "Admin,Delivery")]
        public async Task<IActionResult> GetByIdRental
        (
            [FromBody] GetByIdRentalRequest command,
            [FromServices] RentalHandler handler
        )
        {
            Log.Debug("GetByIdRental");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("GetByIdRental FLPN2R {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }
    }
}
