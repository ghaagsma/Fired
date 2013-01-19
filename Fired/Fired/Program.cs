using System;

namespace Fired
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Fired game = new Fired())
            {
                game.Run();
            }
        }
    }
#endif
}

