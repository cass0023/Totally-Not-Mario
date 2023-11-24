using Raylib_cs;
namespace cass_level
{
    internal class Program
    {
        static Texture2D LoadTexture2D(string groundLevelName)
        {
            //loads ground texture to draw
            Image groundLevel = Raylib.LoadImage("../../../resources/{groundLevelName}");
            Texture2D groundTexture = Raylib.LoadTextureFromImage(groundLevel);
            return groundTexture;
        }
    }
}