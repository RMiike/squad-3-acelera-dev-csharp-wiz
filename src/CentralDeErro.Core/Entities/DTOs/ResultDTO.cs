namespace CentralDeErro.Core.Entities.DTOs
{
    public class ResultDTO
    {
        public ResultDTO(bool success, string message, object data)
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
