using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using Common;
using Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Runner
{
    internal class App : IHostedService, IDisposable
    {
        private readonly ILogger<App> _logger;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IConfiguration _configuration;
        private readonly IIndex<Keys, ISolveable> _solutions;

        public App(ILogger<App> logger, IOptions<AppSettings> appSettings, IConfiguration configuration, IIndex<Keys, ISolveable> solutions)
        {
            _logger = logger;
            _appSettings = appSettings;
            _configuration = configuration;
            _solutions = solutions;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var solution = _solutions[Keys.SockMerchant];
            solution.Solve();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _logger.LogInformation("Disposing.");
        }
    }
}