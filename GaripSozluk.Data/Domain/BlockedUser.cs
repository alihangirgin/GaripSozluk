using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Domain
{
    public class BlockedUser : BaseEntity
    {

        /// <summary>
        /// Engelleyen kullanıcı id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Engellenen Kullanıcı Id
        /// </summary>
        public int BlockedUserId { get; set; }

        public User User { get; set; }
        //public User BlockedUserEntity { get; set; }
    }
}
