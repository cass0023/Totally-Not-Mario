
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
            float cameraSpeed = 1.0f;
            camera.Target = mario.position / 1.6f;
            camera.Offset = new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
            camera.Rotation = 0.0f;
            camera.Zoom = 1.0f;
            
            for (int i = 0; i < 4000; i++)
            {
                mario.cameraLocation = new Vector2(cameraSpeed, Raylib.GetScreenHeight());
            }
        }
    }
}

