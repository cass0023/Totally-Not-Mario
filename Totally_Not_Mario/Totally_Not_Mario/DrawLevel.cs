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
        //static Texture2D groundTexture = new Texture2D();
        //static Texture2D brickTexture = new Texture2D();
        public void LoadGround2D()
        {
            //loads ground texture to draw
            groundLevel = Raylib.LoadTexture($"../../../../../Assets/mariogroundlevel.png");
            //Image groundLevel = Raylib.LoadImage($"../../../../../Assets/mariogroundlevel.png");
            //Texture2D groundTexture = Raylib.LoadTextureFromImage(groundLevel);
            //return groundTexture;
        }
        static Texture2D LoadBrick2D()
        {
            //loads brick texture for platforms
            Image brickBlock = Raylib.LoadImage($"../../../../../Assets/mariobrick.png");
            Texture2D brickTexture = Raylib.LoadTextureFromImage(brickBlock);
            return brickTexture;
        }

        public void DrawGroundTexture()
        {
            //draws ground
            Raylib.DrawTexture(groundLevel, 200, 200, Color.WHITE);
        }
        //public void DrawBrickTexture()
        //{
        //    //draws brick
        //    Raylib.DrawTexture(groundLevel, 0, 200, Color.WHITE);
        //}
    }
}
