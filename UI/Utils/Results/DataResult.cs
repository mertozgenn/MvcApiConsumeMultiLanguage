using Newtonsoft.Json;

namespace UI.Utils.Results
{
    public class DataResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        [JsonConstructor]
        public DataResult(T data, bool success, string message)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
