using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace RNNoise.NET
{
    public static partial class Native
    {
        public const string LIBRARY_NAME = "rnnoise";

        public const int FRAME_SIZE = 480;

        public const float SIGNAL_SCALE = short.MaxValue;
        public const float SIGNAL_SCALE_INV = 1f / short.MaxValue;

#if NETSTANDARD2_0_OR_GREATER
        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rnnoise_get_size();

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rnnoise_init(IntPtr state, IntPtr model);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr rnnoise_create(IntPtr model);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rnnoise_destroy(IntPtr state);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float rnnoise_process_frame(IntPtr state, float* dataOut, float* dataIn);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr rnnoise_system_open_file(string fileName, string mode);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rnnoise_system_close_file(IntPtr file);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr rnnoise_model_from_file(IntPtr file);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rnnoise_model_free(IntPtr model);
#elif NET7_0_OR_GREATER
        [LibraryImport(LIBRARY_NAME)]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        public static partial int rnnoise_get_size();

        [LibraryImport(LIBRARY_NAME)]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        public static partial int rnnoise_init(IntPtr state, IntPtr model);

        [LibraryImport(LIBRARY_NAME)]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        public static partial IntPtr rnnoise_create(IntPtr model);

        [LibraryImport(LIBRARY_NAME)]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        public static partial void rnnoise_destroy(IntPtr state);

        [LibraryImport(LIBRARY_NAME)]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        public static unsafe partial float rnnoise_process_frame(IntPtr state, float* dataOut, float* dataIn);
        
        [LibraryImport(LIBRARY_NAME, StringMarshalling = StringMarshalling.Utf8)]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        public static partial IntPtr rnnoise_system_open_file(string fileName, string mode);

        [LibraryImport(LIBRARY_NAME)]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        public static partial int rnnoise_system_close_file(IntPtr file);

        [LibraryImport(LIBRARY_NAME)]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        public static partial IntPtr rnnoise_model_from_file(IntPtr file);

        [LibraryImport(LIBRARY_NAME)]
        [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
        public static partial void rnnoise_model_free(IntPtr model);
#endif
    }
}
