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
        int marioSpeed;
        int marioJumpSpeed;


        public Character()
		{
            //loads the texture 
            mario = Raylib.LoadTexture("../../../../../Assets/mario-sprite-smaller.png");
            //how many frames in the sprite
            numFrames = 4;
            //displays only part of the sprite 
            frameWidth = mario.Width / numFrames;
            frameRec = new Rectangle(0, 0, frameWidth, mario.Height);
            //where mario is on screen
            position = new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
            //how fast mario runs
            marioSpeed = 10;
            

            frameDelay = 2.0f;
            frameDelayCounter = 0.0f;
            frameIndex = 0;


        }


        public void Move()
        {
            //if right key is pressed down mario moves right
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                position.X += marioSpeed;
                marioMoving = true;
            }
            //if left key is pressed down mario moves left 
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                position.X -= marioSpeed;
                marioMoving = true;
            }
            //if nothing is pressed mario stays in place
            else
            {
                marioMoving = false;
            }

            ++frameDelayCounter;
            //resets after 4 frames (the number in the sprite)
            if (frameDelayCounter > frameDelay)
            {
                //if mario is moving the program cylces through all 4 pictures in the sprite to simulate running
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

