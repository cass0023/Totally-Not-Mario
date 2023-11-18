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
            Texture2D mario = Raylib.LoadTexture("../../../../../Assets/mario-sprite.png");
            int numFrames = 4;
            int frameWidth = mario.Width / numFrames;
            Rectangle frameRec = new Rectangle(0, 0, frameWidth, mario.Height);
            Vector2 position = new Vector2(20, 20);


            float frameDelay = 10.0f;
            float frameDelayCounter = 0.0f;
            int frameIndex = 0;

            
            



            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RAYWHITE);

                Raylib.DrawTextureRec(mario, frameRec, position, Color.WHITE);


                ++frameDelayCounter;
                if(frameDelayCounter > frameDelay)
                {
                    frameDelayCounter = 0.0f;
                    ++frameIndex;
                    frameIndex %= numFrames;
                    frameRec.X = (float)frameWidth * frameIndex;
                }
                



                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }


        static void Setup()
        {
            

  

        }


        static void Update()
        {

            mario.Move();
            mario.Render();

        }




    }
}
