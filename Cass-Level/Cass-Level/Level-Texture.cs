using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cass_Level
{
    internal class Level_Texture
    {

        static Texture2D LoadGround2D()
        {
            //loads ground texture to draw
            Image groundLevel = Raylib.LoadImage($"../../../resources/mariogroundlevel.png/");
            Texture2D groundTexture = Raylib.LoadTextureFromImage(groundLevel);
            return groundTexture;
        }
        static Texture2D LoadBrick2D()
        {
            //loads brick texture for platforms
            Image brickBlock = Raylib.LoadImage($"../../../resources/mariobrick.png/");
            Texture2D brickTexture = Raylib.LoadTextureFromImage(brickBlock);
            return brickTexture;
        }
    }
}
