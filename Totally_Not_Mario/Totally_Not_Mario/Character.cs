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

        int screenWidth = 1280;
        int screenHeight = 720;
        Vector2 size = new Vector2(95, 78);

        float keyboardForce = 5;
        Vector2 velocity;
        
        Vector2 gravityVelocity { get; set; }
        Vector2 Gravity { get; } = new Vector2(0, 10); // positive Y is downward

        public Character()
		{
            //loads the texture 
            mario = Raylib.LoadTexture("../../../../../Assets/mario-sprite-smaller.png");
            //how many frames in the sprite
            numFrames = 4;
            //displays only part of the sprite 
            frameWidth = mario.Width / numFrames;
            frameRec = new Rectangle(25, 20, 95, 78);
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


            float deltaTime = Raylib.GetFrameTime();
            float force = keyboardForce * deltaTime; 



            //if right key is pressed down mario moves right at the speed set
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                position.X += marioSpeed;
                marioMoving = true;
            }
            //if left key is pressed down mario moves left at the speed set 
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                position.X -= marioSpeed;
                marioMoving = true;
                
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                position.Y -= force ;
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
            SimGravity();
            //PlayerCollison();
        }



        public void SimGravity()
        {

            // How much time has elapsed in the last frame
            float deltaTime = Raylib.GetFrameTime();
            // Calculate that much time's worth of gravitational force
            Vector2 gravityForce = deltaTime * Gravity;
            // Apply force to velocity
            gravityVelocity += gravityForce;
            // Apply velocity to position
            position += gravityVelocity;



            Vector2 maxPosition = new Vector2 (screenWidth, screenHeight) - size;
            position = Vector2.Clamp(position, Vector2.Zero, maxPosition);


        }


        public void PlayerCollison()
        {

            int posX = 100;
            int posY = 600;
            int sizeX = 1100;
            int sizeY = 20;

            Raylib.DrawRectangle(posX, posY, sizeX, sizeY, Color.BEIGE);

            //ground
            float groundLeft = posX;
            float groundRight = posX + sizeX;
            float groundTop = posY;
            float groundBottom = posY + sizeY;

            //player 
            float playerLeft = frameRec.X;
            float playerRight = frameRec.X + frameWidth;
            float playerTop = position.Y;
            float playerBottom = position.Y + frameRec.Height;

            bool isPlayerBottom = playerBottom >= groundTop;
            bool isPlayerTop = playerTop <= groundTop;
            bool isPlayerLeft = playerLeft >= groundLeft;
            bool isPlayerRight = playerRight <= groundRight;

            if (isPlayerBottom && isPlayerTop)
            {
                //gravityVelocity = new Vector2(gravityVelocity.X, gravityVelocity.Y);
            }


        }











        public void Render()
        {

            Raylib.DrawTextureRec(mario, frameRec, position, Color.WHITE);


        }



    }


    
}

