using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.Common;
using Subscription.Business.Enums;

namespace Subscription.Business
{
    public class UserWithoutConfidentialInfo
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long IdUser { get; set; }
        public long? IdPerson { get; set; }
        public string ProfilePicture { get; set; }
        public AuthenticationTypeEnum IdLoginProvider { get; set; }
        public List<Role> Roles { get; set; }
        public List<CombinedPermission> CombinedPermission { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None).ToString();
        }
    }


    public static class TransactionalItems
    {

        public static List<long> IdActiveListOfWorkflowStateToConsider = new List<long>()
        {
            (long)WorkflowStateEnum.REGISTERED_TO_ENTITY,
            (long)WorkflowStateEnum.SCANNED_COMPANY,
            (long)WorkflowStateEnum.SCANNED_PROFILE,
            (long)WorkflowStateEnum.SCANNED_FLIPBOOK,
        };

        public static List<long> IdWorkflowForCode = new List<long>()
        {
            (long) WorkflowEnum.REGISTER_TO_ENTITY,
            (long) WorkflowEnum.SHARE_COMPANY,
            (long) WorkflowEnum.SHARE_PROFILE,
            (long) WorkflowEnum.SHARE_FLIPBOOK
        };

        public static List<long> IdWorkflowForRequest = new List<long>()
        {
            (long) WorkflowEnum.FORGOT_PASSWORD,
        };

        public static List<long> ImageFileType = new List<long>()
        {
            (long)FileTypeEnum.JPG,
            (long)FileTypeEnum.GIF,
            (long)FileTypeEnum.PNG
        };
        public static List<string> ImageFileExtension = new List<string>()
        {
            ".gif",".jpg",".png"
        };
    }

    public class ClaimsItem
    {
        public AuthenticationTypeEnum LoginProvider { get; set; }
        public List<CombinedPermission> CombinedPermission { get; set; }
        public List<Business.Role> RolesForUserLogged { get; set; }
        public Business.Identity.User UserLogged { get; set; }
        public Business.User UserLoggedWithDetail { get; set; }
        public static String Bundle { get { return "Bundle"; } }
    }

    public class SessionStorageItem
    {
        public static string LoginProvider { get { return "LoginProvider"; } }
        public static string CombinedPermission { get { return "CombinedPermission"; } }
        public static string RolesForUserLogged { get { return "RolesForUserLogged"; } }
        public static string PasswordUnlockCode { get { return "PasswordUnlockCode"; } }
        public static string UserLogged { get { return "UserLogged"; } }
        public static string UserLoggedWithDetail { get { return "UserLoggedWithDetail"; } }
        public static string ResetToken { get { return "ResetToken"; } }
        public static string UserPermissionCodes { get { return "UserPermissionCodes"; } }
        public static string ShouldSignInAfterRegistration { get { return "ShouldSignInAfterRegistration"; } }
        public static string IdHostedDomain { get { return "IdHostedDomain"; } }
        public static string AreaEnum { get { return "AreaEnum"; } }
        public static string SignalRUrl { get { return "SignalRUrl"; } }
    }



}
