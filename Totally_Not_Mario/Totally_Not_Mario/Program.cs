
using System.Numerics;
using Raylib_cs;


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


        static void Main(string[] args)
        {
            Raylib.InitWindow(screenWidth, screenHeight, title);
            Raylib.SetTargetFPS(60);

            Setup();

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.SKYBLUE);
                Raylib.BeginMode2D(camera);
                
                Camera2D();
                Update();
               
                Raylib.EndMode2D();
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }

        static void Setup()
        {
            level.LevelSetup();
        }
        static void Update()
        {
            level.LevelUpdate();
            mario.Update();
            mario.Render();
        }
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
    }
}

