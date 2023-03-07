namespace SamsungShops.Api.Dtos
{
    public class HandlerResponseDto<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public Exception? Exception { get; set; }
    }
}
