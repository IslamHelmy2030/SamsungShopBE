namespace SamsungShops.Api.Dtos
{
    public class HotDealResponseCommandDto<T> where T : class
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public Exception? Exception { get; set; }

    }
}
