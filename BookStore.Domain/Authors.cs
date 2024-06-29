using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public class Authors
    {
        public string Id { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; } = new DateTime();

        public string Nationality { get; set; } = string.Empty;

        public List<string> SpokenLanguages { get; set; } = new List<string>();
    }
}
