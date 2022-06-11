using Subscription.Business.Enums;

namespace Subscription.Business.ReturnType
{
    public class BaseReturnType<T>
    {
        public T Result { get; set; }
        public RequestStatusEnum Status { get; set; }
        public string ErrorMessage { get; set; }
        public string Id { get; set; }
    }
}