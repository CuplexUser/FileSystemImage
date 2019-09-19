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
            _asyncThreadExecutionMethod = asyncThreadExecutionMethod;
            _workerThread = new Thread(ThMain);
        }

        public void Start()
        {
            _workerThread?.Start();
        }

        private void ThMain()
        {
            _asyncThreadExecutionMethod?.Invoke();
            _workerThread = null;
        }
    }
}