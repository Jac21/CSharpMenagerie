using System.Threading.Tasks;

namespace MyCoyote
{
    public class AccountManager
    {
        private readonly IDbCollection _accountCollection;

        public AccountManager(IDbCollection accountCollection)
        {
            _accountCollection = accountCollection;
        }

        // Returns true if the account is created, else false.
        public async Task<bool> CreateAccount(string accountName, string accountPayload)
        {
            if (await _accountCollection.DoesRowExist(accountName))
            {
                return false;
            }

            return await _accountCollection.CreateRow(accountName, accountPayload);
        }

        // Returns the accountPayload if the account is found, else null.
        public async Task<string> GetAccount(string accountName)
        {
            if (await _accountCollection.DoesRowExist(accountName))
            {
                return string.Empty;
            }

            return await _accountCollection.GetRow(accountName);
        }

        // Returns true if the account is deleted, else false.
        public async Task<bool> DeleteAccount(string accountName)
        {
            if (await _accountCollection.DoesRowExist(accountName))
            {
                return false;
            }

            return await _accountCollection.DeleteRow(accountName);
        }
    }
}