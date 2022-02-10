using System;

namespace EmailVerification
{
    public class Email
    {
        public string LocalName { get; }
        public string ExtendyBoi { get; }
        public string Domain { get; }
        
        public Email(string email)
        {
            var localNameAndDomain = email.Split('@');
            if (localNameAndDomain.Length != 2)
            {
                throw new Exception();
            }

            var localName = localNameAndDomain[0].Replace(".", "");
            var plussyBoi = localName.Split('+');

            ExtendyBoi = plussyBoi.Length == 2 ? plussyBoi[1] : "";

            LocalName = plussyBoi[0];
            Domain = localNameAndDomain[1];
        }
    }
}