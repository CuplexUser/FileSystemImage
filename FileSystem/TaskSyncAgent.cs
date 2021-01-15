using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileSystemImage.FileSystem
{
    public class TaskSyncAgent : IDisposable
    {
        private Task mainTask;
        private Task updateTask;

        public TaskSyncAgent()
        {
            TokenSource = new CancellationTokenSource();
            AutoResetEvent = new AutoResetEvent(false);
            MainTask = null;
            UpdateTask = null;
            IsDisposed = false;
        }

        public Task MainTask
        {
            get => mainTask;
            set
            {
                if (mainTask != null)
                {
                    if (mainTask.Status>=TaskStatus.RanToCompletion)
                    {
                        mainTask.Dispose();
                    }
                    else
                    {
                        throw new InvalidOperationException(nameof(MainTask)+" cant be set when its already poitning to a runing or not started Task.");
                    }
                }
                mainTask = value;
            }
        }
        public Task UpdateTask { get => updateTask; set => updateTask = value; }
        public CancellationTokenSource TokenSource { get; private set; }

        public bool IsDisposed { get; private set; }

        public CancellationToken CancelToken
        {
            get
            {
                return TokenSource.Token;
            }
        }

        public AutoResetEvent AutoResetEvent { get; private set; }

        public void Dispose()
        {
            if (!IsDisposed)
            {


                TokenSource.Dispose();
                AutoResetEvent.Dispose();

                //MainTask?.Dispose();
                //UpdateTask?.Dispose();

                IsDisposed = true;
                UpdateTask = null;
                MainTask = null;
            }
        }
    }

}