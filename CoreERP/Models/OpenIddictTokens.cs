using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class OpenIddictTokens
    {
        public string Id { get; set; }
        public string ApplicationId { get; set; }
        public string AuthorizationId { get; set; }
        public string ConcurrencyToken { get; set; }
        public DateTimeOffset? CreationDate { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }
        public string Payload { get; set; }
        public string Properties { get; set; }
        public string ReferenceId { get; set; }
        public string Status { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }

        public virtual OpenIddictApplications Application { get; set; }
        public virtual OpenIddictAuthorizations Authorization { get; set; }
    }
}
