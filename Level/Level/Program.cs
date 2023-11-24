using Raylib_cs;

namespace Level
{
    internal class Program
    {
        
        static Texture2D LoadTexture2D(string groundLevelName)
        {
            //pulls groundlevel png and creates funtion to draw
            Image groundLevel = new  Image($"../../../../../resources/{groundLevelName}");
            Texture2D groundTexture = Raylib.LoadTextureFromImage(groundLevel);
            return groundTexture;
        }
    }
}