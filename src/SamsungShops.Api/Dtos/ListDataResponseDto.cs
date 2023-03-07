namespace SamsungShops.Api.Dtos
{
    public class ListDataResponseDto<T> : DataResponseDto<T> where T : class
    {
        public int TotalDataCount { get; set; }
    }
}
