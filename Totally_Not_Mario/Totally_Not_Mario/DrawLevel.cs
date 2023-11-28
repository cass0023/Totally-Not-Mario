using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Totally_Not_Mario
{
    internal class DrawLevel
    {
        static Texture2D groundTexture;
        static Texture2D brickTexture;
        static Texture2D LoadGround2D()
        {
            //loads ground texture to draw
            Image groundLevel = Raylib.LoadImage($"../../../../Assets/mariogroundlevel.png/");
            Texture2D groundTexture = Raylib.LoadTextureFromImage(groundLevel);
            return groundTexture;
        }
        static Texture2D LoadBrick2D()
        {
            //loads brick texture for platforms
            Image brickBlock = Raylib.LoadImage($"../../../../Assets/mariobrick.png/");
            Texture2D brickTexture = Raylib.LoadTextureFromImage(brickBlock);
            return brickTexture;
        }

        public void DrawGroundTexture()
        {
            //draws ground
            Raylib.DrawTexture(groundTexture, 0, 0, Color.WHITE);
        }
        public void DrawBrickTexture()
        {
            //draws brick
            Raylib.DrawTexture(brickTexture, 0, 200, Color.WHITE);
        }
    }
}
