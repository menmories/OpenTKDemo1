



using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
namespace OpenTKDemo1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to opengl application.");
            try
            {
                var nativeWindowSettings = new NativeWindowSettings()
                {
                    Size = new OpenTK.Mathematics.Vector2i(1000, 620),
                    Title = "OpenGL",
                };

                OpenGLWindow window = new OpenGLWindow(GameWindowSettings.Default, nativeWindowSettings);
                window.Run();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error:" + exp.Message);
            }
            
        }
    }
}

