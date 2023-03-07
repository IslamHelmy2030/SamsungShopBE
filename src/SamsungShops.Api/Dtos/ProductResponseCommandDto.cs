namespace SamsungShops.Api.Dtos
{
    public class ProductResponseCommandDto<T> where T : class
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public Exception? Exception { get; set; }
    }
}
