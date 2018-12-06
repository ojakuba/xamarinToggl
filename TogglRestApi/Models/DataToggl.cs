namespace TogglRestApi.Models
{
    public class DataToggl<T>
    {
        public string since { get; set; }
        public T data { get; set; }
    }
}
