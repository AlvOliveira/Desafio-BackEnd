using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motto.MR.Domain.Commands.Requests.Rent;
using Motto.MR.Domain.Handler;
using Motto.MR.Shared.Commands;
using Serilog;

namespace Motto.MR.Api.Controllers
{
    public class RentalPlanController : ControllerBase
    {
        [HttpPost("create-rentalplan")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRentalPlan(
            [FromBody] CreateRentalPlanRequest command,
            [FromServices] RentalPlanHandler handler
        )
        {
            Log.Debug("CreateRentalPlan");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("CreateRentalPlan 77793T {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("update-rentalplan")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRentalPlan(
            [FromBody] UpdateRentalPlanRequest command,
            [FromServices] RentalPlanHandler handler
        )
        {
            Log.Debug("UpdateRentalPlanRequest");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("UpdateRentalPlanRequest ZDSIM1 {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("delete-rentalPlan")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRentalPlan(
            [FromBody] DeleteRentalPlanRequest command,
            [FromServices] RentalPlanHandler handler
        )
        {
            Log.Debug("DeleteRentalPlan");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("DeleteRentalPlan SDARR4 {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("getall-rentalplans")]
        [Authorize(Roles = "Admin,Delivery")]
        public async Task<IActionResult> GetAllRentalPlans
        (
            [FromServices] RentalPlanHandler handler
        )
        {
            Log.Debug("GetAllRentalPlans");

            try
            {
                return Ok((CommandResultDefault)handler.Handle());
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("GetAllRentalPlans XZX2N2 {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("getbyid-rentalplan")]
        [Authorize(Roles = "Admin,Delivery")]
        public async Task<IActionResult> GetByIdRentalPlan
        (
            [FromBody] GetByIdRentalPlanRequest command,
            [FromServices] RentalPlanHandler handler
        )
        {
            Log.Debug("GetByIdRentalPlan");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("GetByIdRentalPlan YYKP2R {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }
    }
}
