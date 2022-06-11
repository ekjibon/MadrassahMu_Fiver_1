using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Enums
{
    public enum WorkflowRoleEnum
    {
        FORGOT_PASSWORD_INITIATOR = 1,
        FORGOT_PASSWORD_USER = 2,

        SHARE_PROFILE_SCANNER = 7,
        SHARE_PROFILE_MANIPULATOR = 8,
        SHARE_COMPANY_SCANNER = 9,
        SHARE_COMPANY_MANIPULATOR = 10,
        REGISTER_TO_ENTITY_SCANNER = 11,
        REGISTER_TO_ENTITY_MANIPULATOR = 12,
        SHARE_FLIPBOOK_SCANNER = 13,
        SHARE_FLIPBOOK_MANIPULATOR = 14,
    }
}
