using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class OpenIddictAuthorizations
    {
        public OpenIddictAuthorizations()
        {
            OpenIddictTokens = new HashSet<OpenIddictTokens>();
        }

        public string Id { get; set; }
        public string ApplicationId { get; set; }
        public string ConcurrencyToken { get; set; }
        public string Properties { get; set; }
        public string Scopes { get; set; }
        public string Status { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }

        public virtual OpenIddictApplications Application { get; set; }
        public virtual ICollection<OpenIddictTokens> OpenIddictTokens { get; set; }
    }
}
