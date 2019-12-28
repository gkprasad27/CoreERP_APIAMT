using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class OpenIddictApplications
    {
        public OpenIddictApplications()
        {
            OpenIddictAuthorizations = new HashSet<OpenIddictAuthorizations>();
            OpenIddictTokens = new HashSet<OpenIddictTokens>();
        }

        public string Id { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ConcurrencyToken { get; set; }
        public string ConsentType { get; set; }
        public string DisplayName { get; set; }
        public string Permissions { get; set; }
        public string PostLogoutRedirectUris { get; set; }
        public string Properties { get; set; }
        public string RedirectUris { get; set; }
        public string Type { get; set; }

        public virtual ICollection<OpenIddictAuthorizations> OpenIddictAuthorizations { get; set; }
        public virtual ICollection<OpenIddictTokens> OpenIddictTokens { get; set; }
    }
}
