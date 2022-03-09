#nullable disable
namespace Service.Services.Utils
{
    public class ResultHandler
    {

        public string Message;
        public bool Success;
    }

    public class ResultHandler<T> : ResultHandler
    {
        public T Value;
    }
}
