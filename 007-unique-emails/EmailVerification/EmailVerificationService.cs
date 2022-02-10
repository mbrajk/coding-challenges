using System.Collections.Generic;
using System.Linq;

namespace EmailVerification
{
    public class EmailVerificationService
    {
        public int NumberOfUniqueEmails(string[] emails)
        {
            var emailList = new List<Email>();
            foreach (var email in emails)
            {
                var validEmail = new Email(email);
                emailList.Add(validEmail);
            }

            var distinctEmailCount = 0;
            var groupedEmails = emailList
                .GroupBy(e => e.Domain)
                .SelectMany(a => a.Select(b => b.LocalName).Distinct());
            
            // same logic in a foreach
            // foreach (var groupedEmail in groupedEmails)
            // {
            //     var distinctEmails = groupedEmail.Select(e => e.LocalName).Distinct();
            //     distinctEmailCount += distinctEmails.Count();
            // }

            return groupedEmails.Count();
        }
    }
}