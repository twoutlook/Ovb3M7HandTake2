
using System;
using System.Collections.Generic;

namespace Ovb3M7Db.Server.Models
{
    public class ApplicationClaim
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public partial class ApplicationAuthenticationState
    {
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }
        public IEnumerable<ApplicationClaim> Claims { get; set; }
    }
}