using System;
using RNNoise.NET;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();

            using(var denoiser = new Denoiser())
            {
                float[] data = new float[(int)(Native.FRAME_SIZE * 3.2)];

                for (int i = 0; i < data.Length; i++)
                    data[i] = (float)Math.Sin(i * 0.001f);

                for (int i = 0; i < 160; i++)
                    Console.WriteLine(denoiser.Denoise(data.AsSpan(), false));
            }
        }
    }
}
