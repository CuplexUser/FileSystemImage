using System.Threading;
using FileSystemImage.Utils.Delegates;

namespace FileSystemImage.Utils
{
    public class AsyncThreadExecution
    {
        private readonly AsyncThreadExecutionMethod _asyncThreadExecutionMethod;
        private Thread _workerThread;

        public AsyncThreadExecution(AsyncThreadExecutionMethod asyncThreadExecutionMethod)
        {
            this._asyncThreadExecutionMethod = asyncThreadExecutionMethod;
            this._workerThread = new Thread(this.ThMain);
        }

        public void Start()
        {
            if(this._workerThread != null)
                this._workerThread.Start();
        }

        private void ThMain()
        {
            if(this._asyncThreadExecutionMethod != null)
                this._asyncThreadExecutionMethod.Invoke();
            this._workerThread = null;
        }
    }
}