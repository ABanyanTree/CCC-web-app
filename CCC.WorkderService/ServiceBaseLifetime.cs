﻿using System;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace CCC.WorkderService
{
    public class ServiceBaseLifetime : ServiceBase, IHostLifetime
    {
        private readonly TaskCompletionSource<object> _delayStart = new TaskCompletionSource<object>();
        private IHostApplicationLifetime ApplicationLifetime { get; }
        public ServiceBaseLifetime(IHostApplicationLifetime applicationLifetime)
        {
            ApplicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            Stop();
            return Task.CompletedTask;
        }

        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            cancellationToken.Register(() => _delayStart.TrySetCanceled());
            ApplicationLifetime.ApplicationStopping.Register(Stop);

            new Thread(Run).Start(); // Otherwise this would block and prevent IHost.StartAsync from finishing.
            return _delayStart.Task;
        }

        private void Run()
        {
            try
            {
                Run(this); // This blocks until the service is stopped.
                _delayStart.TrySetException(new InvalidOperationException("Stopped without starting"));
            }
            catch (Exception ex)
            {
                _delayStart.TrySetException(ex);
            }
        }
        // Called by base.Run when the service is ready to start.
        protected override void OnStart(string[] args)
        {
            _delayStart.TrySetResult(null);
            base.OnStart(args);
        }

        // Called by base.Stop. This may be called multiple times by service Stop, ApplicationStopping, and StopAsync.
        // That's OK because StopApplication uses a CancellationTokenSource and prevents any recursion.
        protected override void OnStop()
        {
            ApplicationLifetime.StopApplication();
            base.OnStop();
        }
    }
}
