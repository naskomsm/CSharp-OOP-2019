namespace Telephony
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            Smartphone phone = new Smartphone();

            foreach (var phoneNumber in phoneNumbers)
            {
                Console.WriteLine(phone.CallPhoneNumber(phoneNumber));
            }

            foreach (var url in urls)
            {
                Console.WriteLine(phone.BrowsePage(url));
            }

        }
    }
}
