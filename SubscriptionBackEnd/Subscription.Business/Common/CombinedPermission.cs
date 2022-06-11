namespace Subscription.Business.Common
{
    public class CombinedPermission
    {
        public string PermissionName { get; set; }
        public long PermissionCode { get; set; }
        public bool View { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public long IdPermission { get; set; }
    }
}
