using Moq;
using NUnit.Framework;
using TestDecluttering.Interfaces;

namespace TestDecluttering.Unit.Tests
{
    public class UserServiceTests
    {
        /// <summary>
        /// Use named parameters to only require needed dependencies for tests
        /// </summary>
        /// <param name="groupRepo"></param>
        /// <param name="historyRepo"></param>
        /// <param name="jobInfoRepo"></param>
        /// <param name="permissionsRepo"></param>
        /// <returns></returns>
        private static UserService CreateUserService(Mock<IGroupRepository> groupRepo = null,
            Mock<IHistoryRepository> historyRepo = null,
            Mock<IJobInfoRepository> jobInfoRepo = null,
            Mock<IPermissionsRepository> permissionsRepo = null)
        {
            groupRepo ??= new Mock<IGroupRepository>();
            historyRepo ??= new Mock<IHistoryRepository>();
            jobInfoRepo ??= new Mock<IJobInfoRepository>();
            permissionsRepo ??= new Mock<IPermissionsRepository>();

            return new UserService(groupRepo.Object,
                historyRepo.Object,
                jobInfoRepo.Object,
                permissionsRepo.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            // arrange
            var groupRepository = new Mock<IGroupRepository>();

            var userService = CreateUserService(groupRepo: groupRepository);

            // act

            // assert
            Assert.Pass();
        }
    }
}