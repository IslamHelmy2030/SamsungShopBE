namespace SamsungShops.Api.Dtos
{
    public class DataResponseDto<T> where T : class
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; } = false;
        public string? Message { get; set; }
    }
}
