using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralToolkitLib.Converters;
using FileSystemImage.DataModels;
using Serilog;

namespace FileSystemImage.Utils
{
    static class MemoryHandler
    {
        public static void RunGarbageCollect()
        {
            GC.Collect(0, GCCollectionMode.Forced, true);
            long memAlloc = GC.GetTotalMemory(true);
#if DEBUG
            Log.Debug("Current Allocated Memory Is: " + memAlloc / 1024 + " kb");
#endif
        }

        internal static List<Form> _formList;
        private static object lockObj = new object();

        internal static void DealocateObjectStructure<T>(ref T current)
        {
            if (typeof(T) == typeof(FileSystemDrive))
            {
                long memoryAlloc = GC.GetTotalMemory(false);
                var fileSystemDrive = current as FileSystemDrive;


                if (fileSystemDrive == null)
                {
                    Log.Error("Unable to type convert FileSystemDrive in <DealocateObjectStructure<T>(ref T current)>, obj type is {Name} ", current?.GetType().Name);
                    return;
                }

                string name = fileSystemDrive.VolumeLabel;
                int generation = GC.GetGeneration(fileSystemDrive);

                foreach (var dir in fileSystemDrive.DirectoryList)
                {
                    dir.DirectoryList?.Clear();
                    dir.FileList?.Clear();
                    dir.DirectoryList = null;
                    dir.FileList = null;
                }

                fileSystemDrive.RootFileList?.Clear();
                fileSystemDrive.DirectoryList?.Clear();
                fileSystemDrive.RootFileList = null;
                fileSystemDrive.DirectoryList = null;
                fileSystemDrive = null;
                Task.Delay(10);
                
                long memoryAlloc2 = GC.GetTotalMemory(true);
                GC.Collect(generation, GCCollectionMode.Forced);
                Log.Debug("Function <DealocateObjectStructure> freed {Memory} kB of allocated memory from {Name}", MemFreed.Get((memoryAlloc - memoryAlloc2) / 1024), name);

            }
        }

        private struct MemFreed
        {
            private static MemFreed sharedInstance = new MemFreed(0);

            public long Memory;
            public override string ToString()
            {
                return GeneralConverters.FormatFileSizeToString(Memory, 0);
            }

            public MemFreed(long memory)
            {
                Memory = memory;
            }

            public static MemFreed Get(long memory)
            {
                sharedInstance.Memory = memory;
                return sharedInstance;
            }
        }

        internal static async Task DisposeAnyActiveForm()
        {
            if (_formList != null)
            {
                var formArray = _formList.ToArray();
                for(int i=0; i < formArray.Length; i++)
                {
                    formArray[i].Close();
                }

                formArray = null;                

                var closeFormtask = Task.Factory.StartNew(() =>
                 {
                     Task.Delay(10);
                     if (_formList.Count == 0)
                     {
                         return;
                     }

                     Stack<Form> formStack = new Stack<Form>(_formList);
                     while (_formList != null && formStack.Count > 0)
                     {
                         Task.Delay(25);
                         if (formStack.Peek().IsDisposed)
                         {
                             var form = formStack.Pop();
                             if (_formList.Contains(form))
                             {
                                 _formList.Remove(form);
                             }
                         }
                         else
                         {
                             formStack.Peek().Dispose();
                             Task.Delay(20);
                         }

                     }
                 });
                await closeFormtask;
                //closeFormtask.Wait(TimeSpan.FromMinutes(1));
                _formList = null;
            }
        }

        internal static T GetForm<T>() where T : Form
        {
            if (typeof(T).BaseType != typeof(Form))
            {
                throw new ArgumentException("Provided type was not a Form. Type was: " + typeof(T).Name);
            }

            T form = (T)Activator.CreateInstance(typeof(T));

            if (_formList == null)
            {
                _formList = new List<Form>();
            }

            _formList.Add(form);

            form.FormClosed += Form_FormClosed;
            return form;
        }
        internal static T GetForm<T>(params object[] constructorParams) where T : Form
        {
            object[] p = constructorParams.ToArray();
            T form = (T)Activator.CreateInstance(typeof(T),p);

            if (_formList == null)
            {
                _formList = new List<Form>();
            }

            _formList.Add(form);
            form.FormClosed += Form_FormClosed;
            return form;
        }

        private static void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            lock (lockObj)
            {
                var form = sender as Form;
                form.Dispose();
                _formList.Remove(form);
            }

        }
    }
}
