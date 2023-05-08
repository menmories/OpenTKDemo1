using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;

namespace OpenTKDemo1
{
    internal class OpenGLShader
    {
        public const string DefaultVertexShader = "#version 330 core\n" + 
            "layout (location = 0) in vec3 aPos;\n" +
            "out vec4 vertexColor;\n" +
            "void main()\n"+
            "{\n"+
            "    gl_Position = vec4(aPos, 1.0);\n" +
            "    vertexColor = vec4(0.5, 0.0, 0.0, 1.0);\n" +
            "}";

        public const string DefaultFragmentShader = "#version 330 core\n" +
            "layout (location = 0) in vec3 aPos;\n" +
            "out vec4 FragColor;\n" +
            "in vec4 vertexColor;\n" +
            "void main()\n" +
            "{\n" +
            "    FragColor = vertexColor;\n" +
            "}";

        private int Handle;

        private int VertexShader;

        private int FragmentShader;
        public OpenGLShader(string vertexShaderSource, string fragmentShaderSource)
        {
            //生成我们的shader
            VertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(VertexShader, vertexShaderSource);

            FragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(FragmentShader, fragmentShaderSource);

            int success = 0;
            //编译shader并检查错误
            GL.CompileShader(VertexShader);
            GL.GetShader(VertexShader, ShaderParameter.CompileStatus, out success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(VertexShader);
                Console.WriteLine(infoLog);
            }

            GL.CompileShader(FragmentShader);

            GL.GetShader(FragmentShader, ShaderParameter.CompileStatus, out success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(FragmentShader);
                Console.WriteLine(infoLog);
            }

            //Link program to shader
            Handle = GL.CreateProgram();
            GL.AttachShader(Handle, VertexShader);
            GL.AttachShader(Handle, FragmentShader);
            GL.LinkProgram(Handle);
            GL.LinkProgram(Handle);
            GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out success);
            if(success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(Handle);
                Console.WriteLine(infoLog);
            }
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        public void Destroy()
        {
            GL.DetachShader(Handle, VertexShader);
            GL.DetachShader(Handle, FragmentShader);
            GL.DeleteShader(FragmentShader);
            GL.DeleteShader(VertexShader);
        }
    }
}
