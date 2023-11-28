using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Totally_Not_Mario
{
    public class DrawLevel
    {
        public Texture2D groundLevel;
        public Texture2D brickBlock;
        //screen dimensions
        int screenWidth = 1280;
        int screenHeight = 720;
        //static Texture2D groundTexture = new Texture2D();
        //static Texture2D brickTexture = new Texture2D();
        public void LoadGround2D()
        {
            //loads ground texture to draw
            groundLevel = Raylib.LoadTexture($"../../../../../Assets/mariogroundlevel.png");
        }
        public void LoadBrick2D()
        {
            //loads brick texture for platforms
            brickBlock = Raylib.LoadTexture($"../../../../../Assets/mariobrick.png");
        }
        public void DrawGroundTexture()
        {
            //draws ground 
            Raylib.DrawTexture(groundLevel, screenWidth * 0, screenHeight - 90, Color.LIGHTGRAY);
        }
        public void DrawBrickTexture()
        {
            //draws brick
            Raylib.DrawTexture(brickBlock, 200, 200, Color.WHITE);
        }
    }
}
