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

            var lastTicks = SDL.SDL_GetTicks();

            // loop until done
            while (_running)
            {
                // handle events
                while (SDL.SDL_PollEvent(out var @event) != 0)
                {
                    HandleEvent(@event);
                }

                // Software stuff here!
                // Temp gfx OR hack
                _cnt++;
                for (uint y = 0; y < WindowHeight; y++)
                {
                    for (uint x = 0; x < WindowWidth; x++)
                    {
                        softwareBuffer.Buffer[y * WindowWidth + x] = (x * 0x00000100) | ((y + _cnt) * 0x00010000);
                    }
                }

                //var p = new Vector3(150, 0, 0);
                //var q = new Vector3(5, -80, 0);
                //var dot = Vector3.Dot(p, q);
                //var lengthOfPontoQ = dot / q.Length();
                //Console.WriteLine($"lengthOfPontoQ: {lengthOfPontoQ}");
                //var proj = Vector3.Proj(p, q);
                //var perp = Vector3.Perp(p, q);
                ////Console.WriteLine($"dot: {dot}");
                //softwareBuffer.DrawLine(
                //    softwareBuffer.Width / 2,
                //    softwareBuffer.Heigth / 2, 
                //    (int) (softwareBuffer.Width / 2 + p.X), 
                //    (int) (softwareBuffer.Heigth / 2 + p.Y),
                //    0x00ff0000);
                //softwareBuffer.DrawLine(
                //    softwareBuffer.Width / 2,
                //    softwareBuffer.Heigth / 2,
                //    (int)(softwareBuffer.Width / 2 + q.X),
                //    (int)(softwareBuffer.Heigth / 2 + q.Y),
                //    0x0000ff00);

                ////softwareBuffer.DrawLine(
                ////    softwareBuffer.Width / 2,
                ////    softwareBuffer.Heigth / 2,
                ////    (int)(softwareBuffer.Width / 2 + (perp.X * p.Length())),
                ////    (int)(softwareBuffer.Heigth / 2 + (perp.Y * p.Length())),
                ////    0x000000ff);
                //softwareBuffer.DrawLine(
                //    (int)(softwareBuffer.Width / 2 + q.X),
                //    (int)(softwareBuffer.Heigth / 2 + q.Y),
                //    (int)(softwareBuffer.Width / 2 + Vector3.Normilize(q).X * lengthOfPontoQ),
                //    (int)(softwareBuffer.Heigth / 2 + Vector3.Normilize(q).Y * lengthOfPontoQ),
                //    0x000000ff);

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
                //Console.WriteLine($"Frames per second: {fps}");
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