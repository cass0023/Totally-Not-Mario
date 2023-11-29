using System;
using System.Numerics;
using Raylib_cs;


namespace Totally_Not_Mario
{


    public class Character
    {
        //texture
        Texture2D mario;
        Rectangle frameRec;
        public Vector2 position;
        public Vector2 cameraLocation;
        int frameWidth;
        Vector2 size = new Vector2(95, 78);

        //animation
        int numFrames;
        float frameDelay;
        float frameDelayCounter;
        int frameIndex;
        bool marioMoving;

        //moving/collison 
        int marioSpeed;
        bool isOnGround { get; set; }
        bool isPlayerBottom { get; set; }
        float playerBottom { get; set; }

        //screen dimensions
        int screenWidth = 1280;
        int screenHeight = 720;
        //screenHeight - groundHeight *need better way to do this
        int groundHeight = 630;

        //gravity
        float friction = 0.2f;
        Vector2 gravityVelocity { get; set; }
        Vector2 Gravity { get; set; } = new Vector2(0, 50); // positive Y is downward

        public Character()
        {
            //loads the texture 
            mario = Raylib.LoadTexture("../../../../../Assets/mario-sprite-smaller.png");
            //how many frames in the sprite
            numFrames = 4;
            //displays only part of the sprite 
            frameWidth = mario.Width / numFrames;
            frameRec = new Rectangle(20, 20, 95, 78);
            //where mario is on screen
            position = new Vector2(Raylib.GetScreenWidth() / 3, Raylib.GetScreenHeight() / 2);
            //how fast mario runs
            marioSpeed = 10;

            //changes the speed of the animation
            frameDelay = 2.0f;
            frameDelayCounter = 0.0f;
            frameIndex = 0;
        }
        public void GetPlayerLocation()
        {
            cameraLocation = position;
        }
        public void Update()
        {
            Move();
            SimGravity();
            PlayerCollison();
        }

        public void Move()
        {
            //checks if mario is on the ground (which is just the screen rightnow)
            if (playerBottom == groundHeight)
            {
                isOnGround = true;
            }

            //resets the velocity when not on the ground
            if (!isOnGround)
            {
                gravityVelocity = new Vector2(gravityVelocity.X, gravityVelocity.Y);
            }

            //if right key is pressed down mario moves right at the speed set
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) || Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                position.X += marioSpeed;
                marioMoving = true;
            }
            //if left key is pressed down mario moves left at the speed set 
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) || Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                position.X -= marioSpeed;
                marioMoving = true;
            }
            //if marios not moving the animation stops
            else
            {
                marioMoving = false;
            }

            //if spacece is pressed when mario is on the ground he will jump
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) & isOnGround)
            {
                isOnGround = false;

                //after pressing space the gravity reverses
                if (isOnGround == false)
                {
                    gravityVelocity = new Vector2(gravityVelocity.X, -20);
                }
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

            //keeps mario within the bounds of the window
            Vector2 maxPosition = new Vector2(4000, groundHeight) - size; //****
            position = Vector2.Clamp(position, Vector2.Zero, maxPosition);
        }

        public void PlayerCollison()
        {
            //finds the bottom of mario
            playerBottom = position.Y + frameRec.Height;
            //checks if mario is greater than the bottom of the screen
            isPlayerBottom = playerBottom > groundHeight;

            //applying friction to mario
            bool applyFriction = isPlayerBottom;
            if (applyFriction)
            {
                gravityVelocity *= friction;
            }
        }

        public void Render()
        {
            Raylib.DrawTextureRec(mario, frameRec, position, Color.WHITE);
        }
    }
}

