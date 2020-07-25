using System;
using Serilog;

namespace FileSystemImage.Utils
{
    static class MemoryHandler
    {
        public static void RunGarbageCollect()
        {
            GC.Collect();
            long memAlloc = GC.GetTotalMemory(true);
#if DEBUG
            Log.Debug("Current Allocated Memory Is: " + memAlloc/1024 + " kb");
#endif
        }
    }
}
