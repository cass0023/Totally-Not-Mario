
<<<<<<< HEAD
=======
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
    }
}
>>>>>>> 81cdf005a92a9eae13b43203a8ef2d2b829d9227
