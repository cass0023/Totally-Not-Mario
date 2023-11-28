using Raylib_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Totally_Not_Mario
{
    public class DrawLevel
    {
        Texture2D groundTexture;
        Texture2D brickBlock;
        int groundHeight;

        //screen dimensions
        int screenWidth = 1280;
        int screenHeight = 720;
       
        //send to main program
        public void LevelUpdate()
        {
            DrawBrickTexture();
            DrawGroundTexture();
        }
        public void LevelSetup()
        {
            LoadBrick2D();
            LoadGround2D();
        }
       
        // load textures
        public void LoadGround2D()
        {
            groundTexture = Raylib.LoadTexture($"../../../../../Assets/mariogroundlevel.png");
            
            groundHeight = screenHeight - groundTexture.Height;
        }
        public void LoadBrick2D()
        {
            brickBlock = Raylib.LoadTexture($"../../../../../Assets/mariobrick.png");
        }
        
        //draw textures
        public void DrawGroundTexture()
        {
            Raylib.DrawTexture(groundTexture, screenWidth * 0, screenHeight - 90, Color.LIGHTGRAY);    
        }
        public void DrawBrickTexture()
        {
            Raylib.DrawTexture(brickBlock, 200, 200, Color.GRAY);
        }
    }
}
