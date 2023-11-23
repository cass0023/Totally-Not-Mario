using System;
using System.Numerics;
using Raylib_cs;


namespace Totally_Not_Mario
{


    public class Character
	{
        Texture2D mario;
        int numFrames;
        int frameWidth;
        Rectangle frameRec;
        Vector2 position;
        float frameDelay;
        float frameDelayCounter;
        int frameIndex;
        bool marioMoving;
        Vector2 marioVelocity;
        int marioSpeed;
        Vector2 marioPosition;


        public Character()
		{

            mario = Raylib.LoadTexture("../../../../../Assets/mario-sprite-smaller.png");
            numFrames = 4;
            frameWidth = mario.Width / numFrames;
            frameRec = new Rectangle(0, 0, frameWidth, mario.Height);
            position = new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
            marioSpeed = 10;


            
  

            frameDelay = 2.0f;
            frameDelayCounter = 0.0f;
            frameIndex = 0;


        }


        public void Move()
        {

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                position.X += marioSpeed;
                marioMoving = true;
            }

            else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                position.X -= marioSpeed;
                marioMoving = true;
                
            }

            else
            {

                marioMoving =false;
            }

            ++frameDelayCounter;
            
            if (frameDelayCounter > frameDelay)
            {
                if (marioMoving)
                {
                    frameDelayCounter = 0.0f;
                    ++frameIndex;
                    frameIndex %= numFrames;
                    frameRec.X = (float)frameWidth * frameIndex;
                }
                
                
            }

        }


        public void Update()
        {

            Move();

        }



        public void Render()
        {

            Raylib.DrawTextureRec(mario, frameRec, position, Color.WHITE);


        }



    }


    
}

