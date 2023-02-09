using Raylib_cs;

namespace AIE03_Asteroids
{
    public static class Assets
    {
        public static Texture2D ship;

        public static void Load()
        {
            ship = Raylib.LoadTexture("./Assets/ship.png");
        }

        public static void Unload()
        {
            Raylib.UnloadTexture(ship);
        }
    }
}
