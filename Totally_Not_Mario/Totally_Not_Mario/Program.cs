//using System.Drawing;
using System.Numerics;
using Raylib_cs;


namespace Totally_Not_Mario;

class Program
{

    static Character mario = new Character();

    internal class Totally_Not_Mario
    {
        const string title = "Totally Not Mario";
        const int width = 1280;
        const int height = 720;
        

        static void Main(string[] args)
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(60);

            Setup();

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RAYWHITE);

                
                Update();


                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }


        static void Setup()
        {

            
  

        }


        static void Update()
        {
            mario.Update();
            mario.Render();

        }


        /*static void DrawGround()
        {

            int posX = 100;
            int posY = 600;
            int sizeX = 1100;
            int sizeY = 20;

            Raylib.DrawRectangle(posX, posY, sizeX, sizeY, Color.BEIGE);

            float groundLeft = posX;
            float groundRight = posX + sizeX;
            float groundTop = posY;
            float groundBottom = posY + sizeY;

            




        }*/


        static void CheckCollison()
        {

           



        }



    }
}


/*Raylib.DrawTextureRec(mario, frameRec, position, Color.WHITE);

               

                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    marioVelocity.X = marioSpeed;
                }

                else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
{
    marioVelocity.X = -marioSpeed;
}

else
{
    marioVelocity.X = 0;
}





++frameDelayCounter;
if (frameDelayCounter > frameDelay)
{
    frameDelayCounter = 0.0f;

    if (marioMoving)
    {
        ++frameIndex;
        frameIndex %= numFrames;
        frameRec.X = (float)frameWidth * frameIndex;
    }
}

*/