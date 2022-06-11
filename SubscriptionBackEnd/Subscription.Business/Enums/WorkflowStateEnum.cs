using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Enums
{
    public enum WorkflowStateEnum
    {
        FORGOT_PASSWORD_GENERATED = 1,
        FORGOT_PASSWORD_USED = 2,
        MESSAGE_CREATED = 3,
        MESSAGE__ACKNOWLEDGED = 4,
        MESSAGE__REPLIED = 5,
        REVIEW_CREATED = 6,
        REVIEW_APPROVED = 7,
        SCANNED_PROFILE = 8,
        REMOVED_PROFILE = 9,
        SCANNED_COMPANY = 10,
        REMOVED_COMPANY = 11,
        REGISTERED_TO_ENTITY = 12,
        REMOVED_REGISTRATION = 13,
        SCANNED_FLIPBOOK = 14,
        REMOVED_FLIIPBOOK = 15,
    }
}
