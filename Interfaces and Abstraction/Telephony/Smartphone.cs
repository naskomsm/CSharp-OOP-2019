namespace Telephony
{
    using System;
    using System.Linq;

    public class Smartphone : IBrowseble, ICallable
    {

        public string CallPhoneNumber(string phoneNumber)
        {
            return PhoneNumberValidator(phoneNumber);
        }

        public string BrowsePage(string page)
        {
           return PageValidator(page);
        }

        private string PhoneNumberValidator(string phoneNumber)
        {
            if (phoneNumber.Any(x => !char.IsDigit(x)))
            {
                return "Invalid number!";
            }
            return $"Calling... {phoneNumber}";
        }

        private string PageValidator(string page)
        {
            if (page.Any(x => char.IsDigit(x)))
            {
                return "Invalid URL!";
            }
            return $"Browsing: {page}!";
        }
    }
}
