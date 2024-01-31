using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK.Graphics;

namespace stamate
{
    internal class Window3D : GameWindow
    {
        const float rotation_speed = 180.0f;
        float angle;
        bool showCube = true;
        KeyboardState lastKeyPress;
        int red = 1;
        int blue = 1;
        int green = 1;
        KeyboardState keyboard = OpenTK.Input.Keyboard.GetState();
        MouseState mouse = OpenTK.Input.Mouse.GetState();

        // Constructor.
        public Window3D() : base(800, 600)
        {
            VSync = VSyncMode.On;
        }

        /**Setare mediu OpenGL și încarcarea resurselor (dacă e necesar) - de exemplu culoarea de
           fundal a ferestrei 3D.
           Atenție! Acest cod se execută înainte de desenarea efectivă a scenei 3D. */
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);
        }

        /**Inițierea afișării și setarea viewport-ului grafic. Metoda este invocată la redimensionarea
           ferestrei. Va fi invocată o dată și imediat după metoda ONLOAD()!
           Viewport-ul va fi dimensionat conform mărimii ferestrei active (cele 2 obiecte pot avea și mărimi 
           diferite). */
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }

        /** Secțiunea pentru "game logic"/"business logic". Tot ce se execută în această secțiune va fi randat
            automat pe ecran în pasul următor - control utilizator, actualizarea poziției obiectelor, etc. */
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

           

            // Se utilizeaza mecanismul de control input oferit de OpenTK (include perifcerice multiple, mai ales pentru gaming - gamepads, joysticks, etc.).
            if (keyboard[OpenTK.Input.Key.Escape])
            {
                Exit();
                return;
            }
            else if (keyboard[OpenTK.Input.Key.P] && !keyboard.Equals(lastKeyPress))
            {
                // Ascundere comandată, prin apăsarea unei taste - cu verificare de remanență! Timpul de reacțieuman << calculator.
                if (showCube == true)
                {
                    showCube = false;
                }
                else
                {
                    showCube = true;
                }
            }
           
            else if (keyboard[OpenTK.Input.Key.R] && !keyboard.Equals(lastKeyPress) && red <= 255) {
                red++;
            }
            else if (keyboard[Key.B] && !keyboard.Equals(lastKeyPress) && blue <= 255)
            {
                blue++;
            }
            else if (keyboard[Key.G] && !keyboard.Equals(lastKeyPress) && green <= 255)
            {
                green++;
            }
            lastKeyPress = keyboard;


            if (mouse[OpenTK.Input.MouseButton.Left])
            {
                // Ascundere comandată, prin clic de mouse - fără testare remanență.
                if (showCube == true)
                {
                    showCube = false;
                }
                else
                {
                    showCube = true;
                }
            }
        }

        /** Secțiunea pentru randarea scenei 3D. Controlată de modulul logic din metoda ONUPDATEFRAME().
            Parametrul de intrare "e" conține informatii de timing pentru randare. */
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 lookat = Matrix4.LookAt(15, 50, 15, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            //angle += rotation_speed * (float)e.Time;
            //GL.Rotate(angle, 0.0f, 1.0f, 0.0f);

            // Exportăm controlul randării obiectelor către o metodă externă (modularizare).
            if (showCube == true)
            {
                DrawAxes_OLD();
                DrawTriangle();
            }

            SwapBuffers();
            //Thread.Sleep(1);
        }

        private void DrawAxes_OLD()
        {
            GL.Begin(PrimitiveType.Lines);


            // X
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(50, 0, 0);

            // Y
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 50, 0);

            // Z
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 50);


            GL.End();
        }

        // Utilizăm modul imediat!!!

        private void DrawTriangle()
        {
            Color4 color = new Color4(red, green, blue, 0);
            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(color);
            GL.Vertex3(9, 3, 0);
            GL.Vertex3(20, -3, 0);
            GL.Vertex3(15, 5, 0);
            GL.End();
        }
    }
}

