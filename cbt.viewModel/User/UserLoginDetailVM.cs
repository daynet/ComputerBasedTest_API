using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.viewModel.User
{
   public class UserLoginDetailVM
    {
        public int userLoginActivityId { get; set; }

        public string userName { get; set; }

        public string firstName { get; set; }

        public string lastNme { get; set; }

        public string gender { get; set; }

        public string email { get; set; }

        public bool? isEmailConfirmed { get; set; }

        public string emailConfirmationCode { get; set; }

        public byte[] passwordHash { get; set; }

        public byte[] passwordSalt { get; set; }

        public bool? isFirstLoggingAttempt { get; set; }

        public bool isLockoutEnabled { get; set; }

        public bool isLocked { get; set; }

        public int? failedLoginAttempt { get; set; }

        public bool isActive { get; set; }

        public DateTime? deactivationDate { get; set; }

        public DateTime? lastLoginDate { get; set; }

        public DateTime? lastLogoutDate { get; set; }

        public int tenantId { get; set; }

        public DateTime creationDate { get; set; }

        public int createrUserId { get; set; }

        public string createdFrom { get; set; }

        public bool isModefied { get; set; }

        public DateTime modificationDate { get; set; }

        public int modifierUserId { get; set; }

        public string modifiedFrom { get; set; }

        public bool isDeleted { get; set; }

        public DateTime deletionDate { get; set; }

        public int deleterUserId { get; set; }

        public string deletedFrom { get; set; }

        public bool isApproved { get; set; }

        public DateTime approveDate { get; set; }

        public int approverUserId { get; set; }

        public string approvedFrom { get; set; }

        public int statusId { get; set; }

        public int userStateId { get; set; }

        public string comment { get; set; }
        public string password { get; set; }
        public string lastName { get; set; }
        public string registrationNumber { get; set; }
    }
}
