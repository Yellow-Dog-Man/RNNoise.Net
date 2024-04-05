using System;
using RNNoise.NET;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            DenoiseModel model = null;
            if (args.Length != 0)
            {
                model = new DenoiseModel(args[0]);
            }

            var r = new Random();

            using (var denoiser = new Denoiser(model))
            {
                float[] data = new float[(int)(Native.FRAME_SIZE * 3.2)];

                for (int i = 0; i < data.Length; i++)
                    data[i] = (float)Math.Sin(i * 0.001f);

                for (int i = 0; i < 160; i++)
                    Console.WriteLine(denoiser.Denoise(data.AsSpan(), false));
            }
            model?.Dispose();
        }
    }
}
