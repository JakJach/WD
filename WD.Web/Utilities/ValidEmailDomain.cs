using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WD.Web.Utilities
{
    public class ValidEmailDomain : ValidationAttribute
    {
        private string[] _domains;

        public ValidEmailDomain(string domain)
        {
            _domains = new string[] { domain };
        }
        public ValidEmailDomain(params string[] domains)
        {
            _domains = domains;
        }

        public override bool IsValid(object value)
        {
            var toCheck = value.ToString().Split('@').Last();
            return _domains.Contains(toCheck);
        }
    }
}
