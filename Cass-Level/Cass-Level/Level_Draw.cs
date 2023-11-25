using Raylib_cs;
using System.Reflection.Metadata.Ecma335;
//using static System.Net.Mime.MediaTypeNames;

namespace Cass_Level
{
    internal class Level_Draw
    {
        static Texture2D groundTexture;
        static Texture2D brickTexture;
        
        public void DrawGroundTexture()
        {
            Raylib.DrawTexture(groundTexture, 0, 750, Color.WHITE);
        }
        public void DrawBrickTexture()
        {
            Raylib.DrawTexture(brickTexture, 200, 200, Color.WHITE);
        }
    }
}

