using System;
using System.Collections.Generic;
using SDL2;


namespace SoftwareRenderer
{
    public class Program
    {
        private const int WindowWidth = 1024;
        private const int WindowHeight = 768;
        private static bool _running = true;
        private static uint _cnt = 0;

        static unsafe void Main(string[] args)
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) != 0)
            {
                Console.WriteLine("SDL_Init failed");
                return;
            }

            var sdlWindow = SDL.SDL_CreateWindow("My Game Window",
                SDL.SDL_WINDOWPOS_UNDEFINED,
                SDL.SDL_WINDOWPOS_UNDEFINED,
                WindowWidth, WindowHeight,
                //SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN | 
                SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL
            );

            var sdlRenderer = SDL.SDL_CreateRenderer(sdlWindow, -1, 0);

            var sdlTexture = SDL.SDL_CreateTexture(sdlRenderer,
                SDL.SDL_PIXELFORMAT_ARGB8888,
                (int)SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_STREAMING,
                WindowWidth, WindowHeight);

            var softwareBuffer = new SoftwareBuffer(WindowWidth, WindowHeight);
            var cube = new BoxGeometryGenerator(0.5f);
            var vertexBuffer = new Vector4[cube.Vertices.Length];

            // Scene
            var zeroCamera = new Camera(60f, (float)640 / 480, 0.3f, 1000f);
            zeroCamera.Transform.Position = Vector3.Zero;
            zeroCamera.Transform.Rotation = Vector3.Zero;
            zeroCamera.Transform.Scale = Vector3.One;

            var camera = new Camera(60f, (float)640 / 480, 0.3f, 1000f);
            camera.Transform.Position = new Vector3(2.5f, 1.5f, -3f);
            camera.Transform.Rotation = new Vector3(4f, 0, 0);
            camera.Transform.Scale = Vector3.One;

            float cubeRot = 0;
            var rotCube = new Transform
            {
                Position = new Vector3(0, 0, 4),
                Rotation = new Vector3(0, 0, 0)
            };
            var grandParent = new Transform
            {
                Position = new Vector3(2, 0.25f, 5),
                Rotation = new Vector3(0, 45f, 0),
                Scale = Vector3.One
            };
            var parent = new Transform
            {
                Position = new Vector3(2, 0, 0),
                Rotation = new Vector3(-45, 0, 0),
                Scale = Vector3.One
            };
            grandParent.AddChild(parent);
            var child = new Transform
            {
                Position = new Vector3(0, 0, 3),
                Rotation = Vector3.Zero,
                Scale = Vector3.One
            };
            parent.AddChild(child);

            var lastTicks = SDL.SDL_GetTicks();
            // loop until done
            while (_running)
            {
                // handle events
                while (SDL.SDL_PollEvent(out var @event) != 0)
                {
                    HandleEvent(@event);
                }

                //Software stuff here!
                //Temp gfx OR hack
                _cnt++;
                for (uint y = 0; y < WindowHeight; y++)
                {
                    for (uint x = 0; x < WindowWidth; x++)
                    {
                        softwareBuffer.Buffer[y * WindowWidth + x] = (x * 0x00000100) | ((y + _cnt) * 0x00010000);
                    }
                }

                //var u = new Vector3(190, 55, 0);
                //var v = new Vector3(45, -190, 0);
                //var dot = Vector3.Dot(u, v);
                //var lengthOfPontoQ = dot / u.Magnitude();
                ////Console.WriteLine($"lengthOfPontoQ: {lengthOfPontoQ}");
                //var proj = Vector3.Proj(u, v);
                //var theta = Math.Acos(dot / (u.Magnitude() * v.Magnitude())) * (180.0 / Math.PI);
                //Console.WriteLine($"theta: {theta}");
                ////var perp = Vector3.Perp(p, q);
                ////Console.WriteLine($"dot: {dot}");
                //softwareBuffer.DrawLine(
                //    softwareBuffer.Width / 2,
                //    softwareBuffer.Heigth / 2,
                //    (int)(softwareBuffer.Width / 2 + u.X),
                //    (int)(softwareBuffer.Heigth / 2 + u.Y),
                //    0x00ff0000);
                //softwareBuffer.DrawLine(
                //    softwareBuffer.Width / 2,
                //    softwareBuffer.Heigth / 2,
                //    (int)(softwareBuffer.Width / 2 + v.X),
                //    (int)(softwareBuffer.Heigth / 2 + v.Y),
                //    0x0000ff00);
                //softwareBuffer.DrawLine(
                //    softwareBuffer.Width / 2,
                //    softwareBuffer.Heigth / 2,
                //    (int)(softwareBuffer.Width / 2 + Vector3.Normalize(u).X * lengthOfPontoQ),
                //    (int)(softwareBuffer.Heigth / 2 + Vector3.Normalize(u).Y * lengthOfPontoQ),
                //    0x000000ff);

                rotCube.Rotation = new Vector3(0, cubeRot, 0);
                cubeRot += 1f;

                // Gizmo
                softwareBuffer.DrawLine(10, 10, 40, 10, 0x00ff0000);
                softwareBuffer.DrawLine(35, 5, 40, 10, 0x00ff0000);
                softwareBuffer.DrawLine(35, 15, 40, 10, 0x00ff0000);
                softwareBuffer.DrawLine(10, 10, 10, 40, 0x0000ff00);
                softwareBuffer.DrawLine(5, 35, 10, 40, 0x0000ff00);
                softwareBuffer.DrawLine(15, 35, 10, 40, 0x0000ff00);
                softwareBuffer.DrawLine(10, 10, 25, 25, 0x000000ff);
                softwareBuffer.DrawLine(20, 25, 25, 25, 0x000000ff);
                softwareBuffer.DrawLine(25, 20, 25, 25, 0x000000ff);


                // Render test
                var activeCamera = camera;
                var sceneObjects = new List<SceneObject>()
                {
                    new SceneObject
                    {
                        Vertices = cube.Vertices,
                        Indices = cube.Indices,
                        Transform = rotCube,
                        Color = 0x00ff00ff
                    },
                    new SceneObject
                    {
                        Vertices = cube.Vertices,
                        Indices = cube.Indices,
                        Transform = grandParent,
                        Color = 0x00ff0000
                    },
                    new SceneObject
                    {
                        Vertices = cube.Vertices,
                        Indices = cube.Indices,
                        Transform = parent,
                        Color = 0x0000ff00
                    },
                    new SceneObject
                    {
                        Vertices = cube.Vertices,
                        Indices = cube.Indices,
                        Transform = child,
                        Color = 0x000000ff
                    },
                };
                foreach (var sceneObject in sceneObjects)
                {

                    var modelViewTransform = activeCamera.Projection * activeCamera.WorldToCamera * sceneObject.Transform.LocalToWorldTransform;
                    var verticeCount = 0;
                    foreach (var vertex in sceneObject.Vertices)
                    {
                        var inClipSpace = modelViewTransform * vertex;

                        inClipSpace.X /= inClipSpace.W;
                        inClipSpace.Y /= inClipSpace.W;
                        inClipSpace.Z /= inClipSpace.W;
                        inClipSpace.X += 1f;
                        inClipSpace.Y += 1f;
                        inClipSpace.X *= 0.5f;
                        inClipSpace.Y *= 0.5f;
                        inClipSpace.X *= softwareBuffer.Width;
                        inClipSpace.Y *= softwareBuffer.Heigth;
                        inClipSpace.Z *= 0.5f;

                        vertexBuffer[verticeCount++] = inClipSpace;
                    }

                    for (int face = 0; face < sceneObject.Indices.Length / 3; face++)
                    {
                        var i1 = cube.Indices[face * 3 + 0];
                        var i2 = cube.Indices[face * 3 + 1];
                        var i3 = cube.Indices[face * 3 + 2];
                        var x1 = vertexBuffer[i1].X;
                        var y1 = vertexBuffer[i1].Y;
                        var x2 = vertexBuffer[i2].X;
                        var y2 = vertexBuffer[i2].Y;
                        var x3 = vertexBuffer[i3].X;
                        var y3 = vertexBuffer[i3].Y;
                        //softwareBuffer.DrawLine(
                        //    (int)(softwareBuffer.Width / 2 + x1),
                        //    (int)(softwareBuffer.Heigth / 2 + y1),
                        //    (int)(softwareBuffer.Width / 2 + x2),
                        //    (int)(softwareBuffer.Heigth / 2 + y2),
                        //    0x000000ff);
                        //softwareBuffer.DrawLine(
                        //    (int)(softwareBuffer.Width / 2 + x2),
                        //    (int)(softwareBuffer.Heigth / 2 + y2),
                        //    (int)(softwareBuffer.Width / 2 + x3),
                        //    (int)(softwareBuffer.Heigth / 2 + y3),
                        //    0x000000ff);
                        //softwareBuffer.DrawLine(
                        //    (int)(softwareBuffer.Width / 2 + x3),
                        //    (int)(softwareBuffer.Heigth / 2 + y3),
                        //    (int)(softwareBuffer.Width / 2 + x1),
                        //    (int)(softwareBuffer.Heigth / 2 + y1),
                        //    0x000000ff);
                        softwareBuffer.DrawLine(
                            (int) (x1),
                            (int) (y1),
                            (int) (x2),
                            (int) (y2),
                            sceneObject.Color);
                        softwareBuffer.DrawLine(
                            (int) (x2),
                            (int) (y2),
                            (int) (x3),
                            (int) (y3),
                            sceneObject.Color);
                        softwareBuffer.DrawLine(
                            (int) (x3),
                            (int) (y3),
                            (int) (x1),
                            (int) (y1),
                            sceneObject.Color);
                    }
                }

                // Software buffer to Texture
                fixed (uint* fixedSoftwareBuffer = softwareBuffer.Buffer)
                {
                    var myPixels = (IntPtr)fixedSoftwareBuffer;
                    SDL.SDL_UpdateTexture(sdlTexture, IntPtr.Zero, myPixels, WindowWidth * sizeof(uint));
                }

                // Present screen with Texture
                SDL.SDL_RenderClear(sdlRenderer);
                SDL.SDL_RenderCopy(sdlRenderer, sdlTexture, IntPtr.Zero, IntPtr.Zero);
                SDL.SDL_RenderPresent(sdlRenderer);

                // frames per second
                var ticks = SDL.SDL_GetTicks();
                var ticksDiff = ticks - lastTicks;
                if (ticksDiff == 0)
                    continue;
                lastTicks = ticks;
                var fps = 1000 / ticksDiff;
                Console.WriteLine($"Frames per second: {fps}");
                //Console.WriteLine($"cube0: {vertexBuffer[0].X},{vertexBuffer[0].Y},{vertexBuffer[0].Z}");
            }

            SDL.SDL_Quit();
        }

        private static void HandleEvent(SDL.SDL_Event eventt)
        {
            switch (eventt.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:
                    {
                        _running = false;
                        break;
                    }
                case SDL.SDL_EventType.SDL_KEYDOWN:
                    {
                        HandleKeyEvent(eventt);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private static void HandleKeyEvent(SDL.SDL_Event eventt)
        {
            switch (eventt.key.keysym.sym)
            {
                case SDL.SDL_Keycode.SDLK_ESCAPE:
                    _running = false;
                    break;
                default:
                    break;
            }
        }

    }

    public class SceneObject
    {
        public Vector3[] Vertices { get; set; }
        public uint[] Indices { get; set; }
        public Transform Transform { get; set; }
        public uint Color { get; set; }
    }
}