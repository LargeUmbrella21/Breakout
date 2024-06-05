using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OutBreak
{
    public class Ball
    {
        private Texture2D theBall;
        private Rectangle Ballrect;
        private int BallSpeed = 4;
        private int BallSpeedX = 2;
        private int reflectSpeed = 2;

        public Ball(Game theGame, int x, int y)
        {
            theBall = theGame.Content.Load<Texture2D>("WhiteBall");
            Ballrect = new Rectangle(x, y, 10, 10);
        }
        public Rectangle GetRect()
        {
            return (Ballrect);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            if (Ballrect.Y < 869)
            {
                _spriteBatch.Draw(theBall, Ballrect, Color.White);
            }
        }
        public bool CheckCollision(Player thePlayer)
        {
            if (Ballrect.Intersects(thePlayer.GetRect()))
            {
                return true;
            }
            return false;
        }
        public void ReverseY()
        {
            BallSpeed = -BallSpeed;
        }
        public void ReverseX()
        {
            BallSpeedX = -BallSpeedX;
        }
        private void SpeedUp()
        {
            BallSpeed = BallSpeed++;
            BallSpeedX = BallSpeedX++;
            reflectSpeed = reflectSpeed++;
        }
        public void PlayerHit0()
        {
            BallSpeedX = -2 * reflectSpeed;
            BallSpeed = -BallSpeed;
        }
        public void PlayerHit1()
        {
            BallSpeedX = -1 * reflectSpeed;
            BallSpeed = -BallSpeed;
        }
        public void PlayerHit2()
        {
            BallSpeedX = 0;
            BallSpeed = -BallSpeed;
        }
        public void PlayerHit3()
        {
            BallSpeedX = reflectSpeed;
            BallSpeed = -BallSpeed;
        }
        public void PlayerHit4()
        {
            BallSpeedX = 2 * reflectSpeed;
            BallSpeed = -BallSpeed;
        }
        public void Move()
        {
            Ballrect.Y += BallSpeed;
            Ballrect.X += BallSpeedX;
            if (Ballrect.Y < 0)
            {
                BallSpeed = -BallSpeed;
            }
            if (Ballrect.X < 0)
            {
                BallSpeedX = -BallSpeedX;
            }
            if (Ballrect.X > 595)
            {
                BallSpeedX = -BallSpeedX;
            }
        }
        public bool GameOver()
        {
            if (Ballrect.Y > 900)
            {
                return true;
            }
            return false;
        }


    }
}
