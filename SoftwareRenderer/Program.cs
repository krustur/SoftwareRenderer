using System;
using SDL2;


namespace SoftwareRenderer
{
    class Program
    {
        private const int WindowWidth = 640;
        private const int WindowHeight = 480;
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
                (int) SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_STREAMING,
                WindowWidth, WindowHeight);

            var softwareBuffer = new SoftwareBuffer(WindowWidth, WindowHeight);
            var cube = new BoxGeometryGenerator(0.5f);
            float cubeRot = 0;
            var vertexBuffer = new Vector3[cube.Vertices.Length];
            var i = 0;

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

                // Cube
                var scale = Matrix4X4.CreateScale(new Vector3(1, 1, 1));
                //var translation = Matrix4X4.CreateTranslation(new Vector3(1, 1, 1));
                var translation = Matrix4X4.CreateTranslation(new Vector3(0, -0.1f, 5));
                var rotationX = Matrix4X4.CreateRotationX(0);
                var rotationY = Matrix4X4.CreateRotationY(cubeRot);
                var rotationZ = Matrix4X4.CreateRotationZ(0);
                var cubeTransform = scale * rotationX * rotationY * rotationZ * translation;
                cubeRot += 0.003f;

                // Camera
                scale = Matrix4X4.CreateScale(new Vector3(1, 1, 1));
                translation = Matrix4X4.CreateTranslation(new Vector3(0, 0, 0));
                rotationX = Matrix4X4.CreateRotationX(0);
                rotationY = Matrix4X4.CreateRotationY(0);
                rotationZ = Matrix4X4.CreateRotationZ(0);
                var camTransform = scale * rotationX * rotationY * rotationZ * translation;
                var camTransformInv = camTransform.Inverse();

                // Render test
                var world = Matrix4X4.Identity;
                var proj = Matrix4X4.CreatePerspectiveFieldOfView(1.0472f * 2, (float) softwareBuffer.Heigth / softwareBuffer.Width, 5f, 500);
                var view = cubeTransform * camTransform;//Matrix4X4.Identity;
                var worldViewProj = world * view * proj;



                var verticeCount = 0;
                foreach (var cubeVertex in cube.Vertices)
                {
                    vertexBuffer[verticeCount++] = Vector3.Transform(cubeVertex, worldViewProj);
                }

                for (int face = 0; face < cube.Indices.Length / 3; face++)
                {
                    var pixScale = 5f;
                    var i1 = cube.Indices[face * 3 + 0];
                    var i2 = cube.Indices[face * 3 + 1];
                    var i3 = cube.Indices[face * 3 + 2];
                    var x1 = vertexBuffer[i1].X * pixScale;
                    var y1 = vertexBuffer[i1].Y * pixScale;
                    var x2 = vertexBuffer[i2].X * pixScale;
                    var y2 = vertexBuffer[i2].Y * pixScale;
                    var x3 = vertexBuffer[i3].X * pixScale;
                    var y3 = vertexBuffer[i3].Y * pixScale;
                    softwareBuffer.DrawLine(
                        (int) (softwareBuffer.Width / 2 + x1),
                        (int) (softwareBuffer.Heigth / 2 + y1),
                        (int) (softwareBuffer.Width / 2 + x2),
                        (int) (softwareBuffer.Heigth / 2 + y2),
                        0x000000ff);
                    softwareBuffer.DrawLine(
                        (int) (softwareBuffer.Width / 2 + x2),
                        (int) (softwareBuffer.Heigth / 2 + y2),
                        (int) (softwareBuffer.Width / 2 + x3),
                        (int) (softwareBuffer.Heigth / 2 + y3),
                        0x000000ff);
                    softwareBuffer.DrawLine(
                        (int) (softwareBuffer.Width / 2 + x3),
                        (int) (softwareBuffer.Heigth / 2 + y3),
                        (int) (softwareBuffer.Width / 2 + x1),
                        (int) (softwareBuffer.Heigth / 2 + y1),
                        0x000000ff);
                }
                //cube.Vertices
                //DirectX::XMMATRIX P = DirectX::XMMatrixPerspectiveFovLH(1.0472f, _renderer->GetAspectRatio(), 0.3f, 1000.0f);
                //XMStoreFloat4x4(&_projectionMatrix, P);
                //DirectX::XMMATRIX view = XMLoadFloat4x4(&_cube1ViewMatrix);
                //DirectX::XMMATRIX worldViewProj = world*view*proj;

                //_meshRenderer.RenderMesh(_cube1Mesh, &worldViewProj);

                // Software buffer to Texture
                fixed (uint* fixedSoftwareBuffer = softwareBuffer.Buffer)
                {
                    var myPixels = (IntPtr) fixedSoftwareBuffer;
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
}