namespace SamsungShops.Application.Models
{
    public class ListHandlerResponse<T> : HandlerResponse<T> where T : class
    {
        public int TotalDataCount { get; set; }
    }
}
