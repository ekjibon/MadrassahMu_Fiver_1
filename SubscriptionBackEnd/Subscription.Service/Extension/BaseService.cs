using Subscription.Business.ReturnType;

namespace Subscription.Service
{
    public partial class BaseService
    {
        private static BaseService instance;
        public AuthenticationReturnType User { get; set; }

        public BaseService()
        {

        }
        public static BaseService Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaseService();
                return instance;
            }
        }
    }
}
