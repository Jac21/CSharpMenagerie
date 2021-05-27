using TestDecluttering.Interfaces;

namespace TestDecluttering
{
    public class UserService
    {
        private readonly IGroupRepository _groupRepo;
        private readonly IHistoryRepository _historyRepo;
        private readonly IJobInfoRepository _jobInfoRepo;

        private readonly IPermissionsRepository _permissionsRepo;
        //...

        public UserService(IGroupRepository groupRepo,
            IHistoryRepository historyRepo,
            IJobInfoRepository jobInfoRepo,
            IPermissionsRepository permissionsRepo
            /*...*/)
        {
            _groupRepo = groupRepo;
            _historyRepo = historyRepo;
            _jobInfoRepo = jobInfoRepo;
            _permissionsRepo = permissionsRepo;
            //...
        }
    }
}