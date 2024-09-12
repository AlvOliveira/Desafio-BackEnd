using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motto.MR.Domain.Commands.Requests.Delivery;
using Motto.MR.Domain.Handler;
using Motto.MR.Shared.Commands;
using Motto.MR.Shared.Enum;
using Serilog;

namespace Motto.MR.Api.Controllers
{
    public class DeliveryPersonController : ControllerBase
    {
        [HttpPost("create-deliveryperson")]
        [Authorize(Roles = "Admin,Delivery")]
        public async Task<IActionResult> CreateDeliveryPerson(
            [FromBody] CreateDeliveryPersonRequest command,
            [FromServices] DeliveryPersonHandler handler
        )
        {
            Log.Debug("CreateDeliveryPerson");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("CreateDeliveryPerson 9EUOVC {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("update-deliveryperson")]
        [Authorize(Roles = "Admin,Delivery")]
        public async Task<IActionResult> UpdateDeliveryPerson(
            [FromBody] UpdateDeliveryPersonRequest command,
            [FromServices] DeliveryPersonHandler handler
        )
        {
            Log.Debug("UpdateDeliveryPerson");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("UpdateDeliveryPerson HJKH9Y {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("delete-deliveryperson")]
        [Authorize(Roles = "Admin,Delivery")]
        public async Task<IActionResult> DeleteDeliveryPerson(
            [FromBody] DeleteDeliveryPersonRequest command,
            [FromServices] DeliveryPersonHandler handler
        )
        {
            Log.Debug("DeleteDeliveryPerson");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("DeleteDeliveryPerson YLGG39 {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("getall-deliverypersons")]
        [Authorize(Roles = "Admin,Delivery")]
        public async Task<IActionResult> GetAllDeliveryPersons
        (
            [FromServices] DeliveryPersonHandler handler
        )
        {
            Log.Debug("GetAllDeliveryPersons");

            try
            {
                return Ok((CommandResultDefault)handler.Handle());
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("GetAllDeliveryPersons GVTYHQ {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpPost("getbyid-deliveryperson")]
        [Authorize(Roles = "Admin,Delivery")]
        public async Task<IActionResult> GetByIdDeliveryPerson
        (
            [FromBody] GetByIdDeliveryPersonRequest command,
            [FromServices] DeliveryPersonHandler handler
        )
        {
            Log.Debug("GetByIdDeliveryPerson");

            try
            {
                return Ok((CommandResultDefault)handler.Handle(command));
            }
            catch (Exception e)
            {
                var info = e.InnerException != null ? e.InnerException.Message : e.Message;
                Log.Error("GetByIdDeliveryPerson YWDQWT {error}", info);
                return Ok(new CommandResultDefault { Success = false, Message = info });
            }
        }

        [HttpGet("getall-licensecategories")]
        public IActionResult GetAllLicenseCategories()
        {
            var categories = Enum.GetNames(typeof(MotorcycleLicenseCategory)).ToList();

            return Ok(categories);
        }
    }
}
