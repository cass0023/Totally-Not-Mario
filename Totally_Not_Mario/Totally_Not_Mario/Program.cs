//using System.Drawing;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using Raylib_cs;
namespace Totally_Not_Mario;

class Program
{
    internal class Totally_Not_Mario
    {
        const string title = "Totally Not Mario";
        const int width = 1280;
        const int height = 720;

        static Texture2D goomba;
        static void Main(string[] args)
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(60);






            EnemySetup();

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RAYWHITE);

                Raylib.DrawTexture(goomba, 200, 200, Color.WHITE);





                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }

        public void Setup()
        {

        }
        static void EnemySetup()
        {
            goomba = LoadTexture2D("goombas.png");
        }

   
        public void Update()
        {
            Raylib.DrawTexture(goomba, 200, 200, Color.WHITE);
        }

        static Texture2D LoadTexture2D(string fileName)
        {
            Image image = Raylib.LoadImage($"../../../resources/goomba/{fileName}");
            Texture2D texture = Raylib.LoadTextureFromImage(image);
            return texture;
        }


    }
}
