﻿using System;
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
                (int)SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_STREAMING,
                WindowWidth, WindowHeight);

            var softwareBuffer = new uint[WindowWidth * WindowHeight];

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
                        softwareBuffer[y * WindowWidth + x] = (x * 0x00000100) | ((y+_cnt) * 0x00010000);
                    }

                }

                // Software buffer to Texture
                fixed (uint* fixedSoftwareBuffer = softwareBuffer)
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
		        if(ticksDiff == 0)
			        continue;
                lastTicks = ticks;
		        var fps = 1000 / ticksDiff;
                Console.WriteLine($"Frames per second: {fps}");
            }

            SDL.SDL_Quit();
        }

        private static void HandleEvent(SDL.SDL_Event eventt)
        {
            switch (eventt.type) {
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