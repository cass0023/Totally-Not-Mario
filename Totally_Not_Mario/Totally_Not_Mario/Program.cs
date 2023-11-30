
using Raylib_cs;
using System.Numerics;

namespace Totally_Not_Mario;
class Program
{
    static Character mario = new Character();
    static DrawLevel level = new DrawLevel();
    static Camera2D camera = new Camera2D();
  
    internal class Totally_Not_Mario
    {
        
        const string title = "Totally Not Mario";
        const int screenWidth = 1280;
        const int screenHeight = 720;

        //Goomba properties
        static Texture2D goomba;
        static int textureWidth = 175;
        static int textureHeight = 145;

        //Position of the Goomba outside the window
        static float goombaPosX = 1280 + 100;

        //Threshold to reset the Goomba's position
        static float resetGoomba = -textureWidth;

        //Variables for the flipping animation
        static bool flipX = false;       
        static int flipCounter = 0;      //Set at 0 for consistent animation
        static int flipFrequency = 10;   

        static void Main(string[] args)
        {
            Raylib.InitWindow(screenWidth, screenHeight, title);
            Raylib.SetTargetFPS(60);
          
          Setup();

            while (!Raylib.WindowShouldClose())
            {
                Raylib.ClearBackground(Color.SKYBLUE);
                Raylib.BeginMode2D(camera);
                
                Camera2D();
                Update();
                Draw();                 
                UpdateGoombaPosition();
               
                Raylib.EndMode2D();
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }

            static void Setup()
        {
            level.LevelSetup();
        }                     
                 
        //Loading Goomba texture
        static void EnemySetup()
        {
            goomba = LoadTexture2D("goomba.gif");
        }

        //Update Goomba's position to move left
        static void UpdateGoombaPosition()
        {
            goombaPosX -= 2;  //Move Goomba horizontally (left)

            //Reset Goomba's position when it goes beyond the window
            if (goombaPosX < resetGoomba)
            {
                goombaPosX = screenWidth; //Resets at the right edge of the window
            }
        }

        //Draw Goomba with flipping (walking animaton)
        static void Draw()
        {
            flipCounter++;

            //Use of flip counter, toggles flipping
            if (flipCounter >= flipFrequency)
            {
                flipX = !flipX;
                flipCounter = 0;
            }

            
            Rectangle sourceRect = flipX ? new Rectangle(goomba.Width, 0, -goomba.Width, goomba.Height) : new Rectangle(0, 0, goomba.Width, goomba.Height);

            //Draw Goomba at the updated X position (with flipping)
            Raylib.DrawTexturePro(goomba,
                sourceRect,new Rectangle(goombaPosX, 250, textureWidth, textureHeight),new Vector2(0, 0),0f,Color.WHITE);
        }

        static void Update()
        {
            level.LevelUpdate();
            mario.Update();
            mario.Render();
        }
        
        //controls player camera
        static void Camera2D()
        {
            float startPoint = screenWidth / 2/3;
            float cameraSpeed = 1000;
            camera.Target = mario.position / 1.8f;
            camera.Offset = new Vector2(Raylib.GetScreenWidth() / 8, Raylib.GetScreenHeight() / 2);
            camera.Rotation = 0.0f;
            camera.Zoom = 1.0f;

            if ((Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) || Raylib.IsKeyDown(KeyboardKey.KEY_D)))
            {
                for (int i = 0; i < screenWidth; i++)
                {
                    mario.cameraLocation = new Vector2(startPoint, Raylib.GetScreenHeight()) + new Vector2(cameraSpeed, 0);
                }
            }
        }
            
       
        //Loading the goomba texture (from file)
        static Texture2D LoadTexture2D(string fileName)
        {
            Image goomba = Raylib.LoadImage($"../../../resources/goomba/{fileName}");
            Texture2D texture = Raylib.LoadTextureFromImage(goomba);
            return texture;
        }
    }
}
