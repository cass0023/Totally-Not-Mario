using Raylib_cs;
using System.Numerics;

class Program
{
    internal class Totally_Not_Mario
    {
        
        const string title = "Totally Not Mario";
        const int width = 1280;
        const int height = 720;

        //Goomba properties
        static Texture2D goomba;
        static int textureWidth = 100;
        static int textureHeight = 80;

        //Position of the Goomba outside the window
        static float goombaPosX = 1280 + 100;

        //Threshold to reset the Goomba's position
        static float resetGoomba = -textureWidth;

        //Variables for the flipping
        static bool flipX = false;       
        static int flipCounter = 0;      //Set at 0 for consistent animation
        static int flipFrequency = 10;   //Frequency of flipping

        static void Main(string[] args)
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(60);

            EnemySetup();   

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RAYWHITE);

                Draw();                 
                UpdateGoombaPosition(); 

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }

        //Loading Goomba texture
        static void EnemySetup()
        {
            goomba = LoadTexture2D("goomba.gif");
        }

        //Update Goomba's position to move left
        static void UpdateGoombaPosition()
        {
            goombaPosX -= 2;  //Move Goomba horizontally

            //Reset Goomba's position when it goes beyond the window
            if (goombaPosX < resetGoomba)
            {
                goombaPosX = width; //Resets at the right edge of the window
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

            
            Rectangle sourceRect = flipX ? new Rectangle(goomba.Width, 0, -goomba.Width, goomba.Height) :
                                           new Rectangle(0, 0, goomba.Width, goomba.Height);

            // Draw Goomba at the updated X position (with flipping)
            Raylib.DrawTexturePro(goomba,
                sourceRect,
                new Rectangle(goombaPosX, 100, textureWidth, textureHeight),
                new Vector2(0, 0),
                0f,
                Color.WHITE);
        }

        
        public void Update()
        {
            
        }

        // Loading the texture (from file)
        static Texture2D LoadTexture2D(string fileName)
        {
            Image image = Raylib.LoadImage($"../../../resources/goomba/{fileName}");
            Texture2D texture = Raylib.LoadTextureFromImage(image);
            return texture;
        }
    }
}