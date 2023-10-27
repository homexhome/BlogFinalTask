using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogFinalTask.Services.Helpers
{
    public class ClaimComparer : IEqualityComparer<Claim>
    {
        public bool Equals(Claim? x, Claim? y) {
            return x!.Type == y!.Type && x.Value == y.Value;
        }

        public int GetHashCode(Claim obj) {
            return (obj.Type + obj.Value).GetHashCode();
        }
    }
}
