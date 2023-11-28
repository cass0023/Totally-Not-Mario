﻿
using System.Numerics;
using Raylib_cs;


namespace Totally_Not_Mario;

class Program
{
    static Character mario = new Character();
    static DrawLevel level = new DrawLevel();

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
                Raylib.ClearBackground(Color.SKYBLUE);

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
            level.DrawGroundTexture();
            mario.Update();
            mario.Render();
        }
    }
}

