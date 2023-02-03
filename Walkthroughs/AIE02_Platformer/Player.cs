using Raylib_cs;
using System.Numerics;

namespace Platformer
{
    public class Player : GameObject
    {
        private const float GRAVITY = -9.1f;
        private const float EPSILON = 0.001f;

        private KeyboardKey leftKey;
        private KeyboardKey rightKey;
        private KeyboardKey jumpKey;

        private float speed;
        private Texture2D texture;

        private bool onGround;
        private float yVelocity;
        private float groundHeight;
        private float jumpPower;

        private float defaultGroundHeight;

        public Player(float _groundHeight) : base(Vector2.Zero, Vector2.Zero, Color.WHITE)
        {
            leftKey = KeyboardKey.KEY_A;
            rightKey = KeyboardKey.KEY_D;
            jumpKey = KeyboardKey.KEY_SPACE;

            groundHeight = _groundHeight;
            defaultGroundHeight = groundHeight;

            speed = 100;
            jumpPower = 15;

            size.X = 50;
            size.Y = 50;

            position.X = size.X;
            position.Y = groundHeight;

            texture = Raylib.LoadTexture("Assets/mario.png");
        }

        public override void Update(float _deltaTime)
        {
            if (Raylib.IsKeyDown(leftKey))
                position.X -= speed * _deltaTime;

            if (Raylib.IsKeyDown(rightKey))
                position.X += speed * _deltaTime;

            HandleJump(_deltaTime);
            CheckGrounded();
        }

        public bool TryCollideWith(GameObject _other)
        {
            Rectangle rect = Rectangle;
            rect.height += 1;

            if(Raylib.CheckCollisionRecs(rect, _other.Rectangle))
            {
                if(_other.Rectangle.y - (rect.y + rect.height) < -10)
                {
                    return false;
                }

                // Some collision happened
                Color = Color.RED;
                groundHeight = _other.Rectangle.y - _other.Rectangle.height;
                return true;
            }
            else
            {
                Color = Color.WHITE;
                groundHeight = 100000;
                return false;
            }
        }

        public override void Draw()
        {
            RaylibExt.DrawTexture(texture, Position.X, Position.Y, Size.X, Size.Y, Color);
        }

        private void CheckGrounded()
        {
            if(groundHeight - position.Y < EPSILON && groundHeight - position.Y > -EPSILON)
            {
                onGround = true;
            }
            else
            {
                onGround = false;
            }
        }

        private void HandleJump(float _deltaTime)
        {
            if(Raylib.IsKeyPressed(jumpKey) && onGround)
            {
                Jump();
            }
            else if(!onGround)
            {
                yVelocity += GRAVITY * _deltaTime * 4;
            }
            else if(onGround && yVelocity != 0)
            {
                yVelocity = 0;
            }

            position.Y -= yVelocity;

            if(position.Y > groundHeight)
            {
                position.Y = groundHeight;
            }
        }

        private void Jump()
        {
            yVelocity = jumpPower;
        }
    }
}
