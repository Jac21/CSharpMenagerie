using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Coyote;
using Microsoft.Coyote.SystematicTesting;
using NUnit.Framework;

namespace MyCoyote.Unit.Test
{
    public class AccountManagerUnitTests
    {
        private static InMemoryDbCollection _dbCollection;
        private static AccountManager _accountManager;

        [OneTimeSetUp]
        public void Setup()
        {
            _dbCollection = new InMemoryDbCollection();

            _accountManager = new AccountManager(_dbCollection);
        }

        [NUnit.Framework.Test]
        public void RunCoyoteTest()
        {
            var config = Configuration.Create();

            var engine = TestingEngine.Create(config, AccountCreation_Async_NonAwaited_Success_Test);

            engine.Run();

            var report = engine.TestReport;
            Debug.WriteLine("Coyote found {0} bug.", report.NumOfFoundBugs);
            Assert.True(report.NumOfFoundBugs == 0, $"Coyote found {report.NumOfFoundBugs} bug(s).");
        }

        public static async Task AccountCreation_Async_Awaited_Success_Test()
        {
            // arrange
            const string accountName = "MyAccount";
            const string accountPayload = "payload";

            // act
            var result = await _accountManager.CreateAccount(accountName, accountPayload);

            // assert
            Assert.IsTrue(result);

            // act
            result = await _accountManager.CreateAccount(accountName, accountPayload);

            // assert
            Assert.IsFalse(result);
        }

        public static async Task AccountCreation_Async_NonAwaited_Success_Test()
        {
            // arrange
            const string accountName = "MyAccount";
            const string accountPayload = "payload";

            // act

            // Call CreateAccount twice without awaiting, which makes both methods run
            // asynchronously with each other.
            var task1 = _accountManager.CreateAccount(accountName, accountPayload);
            var task2 = _accountManager.CreateAccount(accountName, accountPayload);

            // Then wait both requests to complete.
            await Task.WhenAll(task1, task2);

            // assert

            // Finally, assert that only one of the two requests succeeded and the other
            // failed. Note that we do not know which one of the two succeeded as the
            // requests ran concurrently (this is why we use an exclusive OR).
            Assert.True(task1.Result ^ task2.Result);
        }
    }
}