using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class GetUserDetailForSessionReturnType
    {
        public UserDetailForSessionUserDetail UserDetailForSessionUserDetail { get; set; }
        public List<UserDetailForSessionPermission> UserDetailForSessionPermission { get; set; }
        public List<UserDetailForSessionRole> UserDetailForSessionRole { get; set; }
    }

    public class UserDetailForSessionUserDetail
    {
        public long? IdUser { get; set; }
        public long? IdPerson { get; set; }
        public bool? NeedPasswordChange { get; set; }
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool? LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public bool? IsDeactivated { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Othername { get; set; }
        public long? IdProfilePic { get; set; }
        public string Headline { get; set; }
        public DateTime? Dob { get; set; }
        public long? IdCoverPic { get; set; }
        public long? IdHostedDomain { get; set; }
        public long? IdDocument { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string PhysicalFilePath { get; set; }
        public long? IdDocumentType { get; set; }
        public long? IdParameterBaseServerUrl { get; set; }
        public string ServerFilePath { get; set; }
        public long? IdParameter { get; set; }
        public string ParamaterValue { get; set; }
    }

    public class UserDetailForSessionPermission
    {
        public string PermissionName { get; set; }
        public long IdPermission { get; set; }
    }

    public class UserDetailForSessionRole
    {
        public string Name { get; set; }
        public long IdRole { get; set; }
        public long IdUser { get; set; }
    }
}
