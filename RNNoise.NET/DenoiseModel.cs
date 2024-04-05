using System;
using System.IO;

namespace RNNoise.NET
{
    public sealed class DenoiseModel : IDisposable
    {
        public IntPtr NativeInstance { get; private set; }
        IntPtr file;

        public DenoiseModel(string targetFile)
        {
            targetFile = Path.GetFullPath(targetFile);
            if (!File.Exists(targetFile))
                throw new FileNotFoundException(targetFile);
            file = Native.rnnoise_system_open_file(targetFile, "r");
            if (file == IntPtr.Zero)
                throw new UnauthorizedAccessException("Failed to create c file for Path:" + targetFile);

            NativeInstance = Native.rnnoise_model_from_file(file);
        }

        public void Dispose()
        {
            if (NativeInstance != IntPtr.Zero)
            {
                Native.rnnoise_model_free(NativeInstance);
                NativeInstance = IntPtr.Zero;
            }
            if (file != IntPtr.Zero)
            {
                Native.rnnoise_system_close_file(file);
                file = IntPtr.Zero;
            }
        }
    }
}
