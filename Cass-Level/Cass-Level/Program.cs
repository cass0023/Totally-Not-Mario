using Raylib_cs;
using static System.Net.Mime.MediaTypeNames;

namespace Cass_Level
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        static Texture2D LoadTexture2D(string groundLevelName)
        {
            //loads ground texture to draw
            Raylib_cs.Image groundLevel = Raylib.LoadImage("../../../resources/{groundLevelName}");
            Texture2D groundTexture = Raylib.LoadTextureFromImage(groundLevel);
            return groundTexture;
        }

    }
}

