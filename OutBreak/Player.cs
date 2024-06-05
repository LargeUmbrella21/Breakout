using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace OutBreak
{
    public class Player
    {
        private Texture2D thePlayer;
        private Rectangle PlayerRect;

        public Player(Game theGame, int x, int y)
        {
            thePlayer = theGame.Content.Load<Texture2D>("Rectangle");
            PlayerRect = new Rectangle(x, y, 20, 30);
        }
        public Rectangle GetRect()
        {
            return PlayerRect;
        }
        public bool CheckCollision(Ball theBall)
        {
            if (PlayerRect.Intersects(theBall.GetRect()))
            {
                return true;
            }
            return false;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(thePlayer, PlayerRect, Color.White);
        }
        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D) && PlayerRect.X < 570)
            {
                PlayerRect.X += 9;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && PlayerRect.X > 0)
            {
                PlayerRect.X -= 9;
            }
        }
    }
}
