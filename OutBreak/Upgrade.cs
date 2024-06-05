using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OutBreak
{
    class Upgrade
    {
        private Texture2D theBallUp;
        private Rectangle BallUprect;
        public Upgrade(Game theGame, int x, int y)
        {
            theBallUp = theGame.Content.Load<Texture2D>("WhiteBall");
            BallUprect = new Rectangle(x, y, 10, 10);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            if (BallUprect.Y < 869)
            {
                _spriteBatch.Draw(theBallUp, BallUprect, Color.White);
            }
        }
        public bool CheckCollisionUp(Player thePlayer)
        {
            if (BallUprect.Intersects(thePlayer.GetRect()))
            {
                return true;
            }
            return false;
        }
        public void Move()
        {
            BallUprect.Y+=5;
        }
    }
 
}
