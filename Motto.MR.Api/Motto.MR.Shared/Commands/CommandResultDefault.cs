
namespace Motto.MR.Shared.Commands
{
    public class CommandResultDefault : ICommandResult
    {
        public CommandResultDefault() { }

        public CommandResultDefault(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public CommandResultDefault(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
