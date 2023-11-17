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
            float timer = 0.0f;
            int frame = 0;
            int maxFrames = ((int)(mario.Width / (int)frameWidth));
            frame = frame % maxFrames;
            mario = Raylib.LoadTexture("../../../../../Assets/mario-sprite-small.png");
            frameWidth = (float)(mario.Width / 5);
            source = new Rectangle(frameWidth * frame, 0, frameWidth, mario.Height);
            position = new Vector2(20, 20);

            

            timer += Raylib.GetFrameTime();

            if(timer >= 0.2f)
            {
                timer = 0.0f;
                frame += 1;
            }

            
        }

        public void Render()
        {
       
            Raylib.DrawTextureRec(mario,source, position, Color.WHITE);

            
        }



    }


    
}

