namespace Kwik.Services
{
    public class DBInitHostedService : IHostedService
    {
        //private readonly IAccountRepository<Account> _Accountrepository;
        private Timer _timer = null;
        //public DBInitHostedService(IServiceScopeFactory serviceScopeFactory, IAccountRepository<Account> accountRepository)
        //{
        //    _Accountrepository = accountRepository;
        //}

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;

        }

        private void DoWork(object state)
        {
            //_Accountrepository.LoadJson();
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
