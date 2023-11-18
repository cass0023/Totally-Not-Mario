using System;
using System.Numerics;
using Raylib_cs;


namespace Totally_Not_Mario
{


    public class Character
	{



        Texture2D mario;
        Rectangle source;
        Vector2 position;

        float frameWidth { get; }

        

        public Character()
		{
           
            mario = Raylib.LoadTexture("../../../../../Assets/mario-sprite-small.png");
            frameWidth = (float)(mario.Width / 5);
            source = new Rectangle(0, 0, frameWidth, mario.Height);
            position = new Vector2(20, 20);

            //Vector2 marioPosition = (Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
            
            

        

            
        }


        public void Move()
        {
            float x = 32.0f, y = 32.0f;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                x += Raylib.GetFrameTime() * 1000.0f;
            }



        }


        public void Render()
        {
       
            Raylib.DrawTextureRec(mario,source, position, Color.WHITE);

            
        }



    }


    
}

