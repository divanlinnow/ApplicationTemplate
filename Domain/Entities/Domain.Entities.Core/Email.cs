using Domain.Enums.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Core
{
    public class Email : EntityBase
    {
        #region Properties

        public virtual EmailType Type { get; set; }

        public virtual EmailAccountType AccountType { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public virtual string EmailAddress { get; set; }

        public virtual string IncomingMailServer { get; set; }

        public virtual string OutgoingMailServer { get; set; }

        public virtual int IncomingMailServerPort { get; set; }

        public virtual int OutgoingMailServerPort { get; set; }

        public virtual bool IncomingServerUseSSL { get; set; }

        public virtual bool OutgoingServerUseSSL { get; set; }

        public virtual short PriorityOrder { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual User ModifiedBy { get; set; }
        
        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}