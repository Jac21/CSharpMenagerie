using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonadicComprehension
{
    public class PaymentProcessor
    {
        // List of registered users and their IBANs
        private readonly Dictionary<string, string> _userIbans = new Dictionary<string, string>
        {
            ["levi@gmail.com"] = "NL18INGB9971485915",
            ["olena@hotmail.com"] = "UA131174395738584578471957518"
        };

        // Try to get IBAN by registered user's email
        public async Task<Option<string>> GetIbanAsync(string userEmail)
        {
            // Pretend that we are talking to some external server or database here
            await Task.Delay(1000);

            if (_userIbans.TryGetValue(userEmail, out var iban))
                return Option<string>.Some(iban);

            return Option<string>.None();
        }

        // Try to send a payment from IBAN to IBAN
        public async Task<Option<Guid>> SendPaymentAsync(
            string ibanFrom,
            string ibanTo,
            decimal amount)
        {
            // Make sure IBANs exist
            if (!_userIbans.ContainsValue(ibanFrom) || !_userIbans.ContainsValue(ibanTo))
                return Option<Guid>.None();

            // Send the payment through a very real gateway
            await Task.Delay(1000);

            // Return the payment ID
            return Option<Guid>.Some(Guid.NewGuid());
        }
    }
}