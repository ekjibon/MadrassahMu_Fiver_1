namespace Subscription.Business.Enums
{
    public enum RequestStatusEnum
    {
        SUCCESS = 10,
        FAILURE = 11,
        SERVERERROR = 12,
        AUTHERROR = 13,
        TOKENEXPIRED = 15,
        TOKENINVALID = 16,
        VALIDATION_ERROR = 17
    }
}