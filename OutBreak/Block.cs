using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OutBreak
{
    public class Block
    {
        private Texture2D theBlock;
        private Rectangle Blockrect;
        private Texture2D theBlockX;
        private Rectangle BlockRectX;
        private bool Destroy = false;
        Random rnd = new Random();

        public Block(Game theGame, int x, int y)
        {
            int RandomNum = rnd.Next(0, 4);
            if (RandomNum == 0)
            {
                theBlock = theGame.Content.Load<Texture2D>("GreenRect");
                theBlockX = theGame.Content.Load<Texture2D>("GreenRect");
            }
            else if (RandomNum == 1)
            {
                theBlock = theGame.Content.Load<Texture2D>("Orange");
                theBlockX = theGame.Content.Load<Texture2D>("Orange");
            }
            else if (RandomNum == 2)
            {
                theBlock = theGame.Content.Load<Texture2D>("Yellow");
                theBlockX = theGame.Content.Load<Texture2D>("Yellow");
            }
            else if (RandomNum == 3)
            {
                theBlock = theGame.Content.Load<Texture2D>("Rectangle");
                theBlockX = theGame.Content.Load<Texture2D>("Rectangle");
            }
            BlockRectX = new Rectangle(x, y, 5, 25);
            Blockrect = new Rectangle(x, y, 58, 25);
        }
        public Rectangle Getrect()
        {
            return Blockrect;
        }
        public Rectangle GetRectX()
        {
            return BlockRectX;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            if (!Destroy)
            {
                _spriteBatch.Draw(theBlock, Blockrect, Color.White);
                _spriteBatch.Draw(theBlockX, BlockRectX, Color.White);
            }
        }
        public bool CheckCollide(Ball theBall)
        {
            if (Blockrect.Intersects(theBall.GetRect()))
            {
                if (!Destroy)
                {
                    theBall.ReverseY();
                }
                Destroy = true;
                return true;
            }
            return false;

        }
        public bool CheckCollideX(Ball theBall)
        {
            if (BlockRectX.Intersects(theBall.GetRect()))
            {
                if (!Destroy)
                {
                    theBall.ReverseX();
                }
                Destroy = true;
                return true;
            }
            return false;
        }
        public bool getDestroy()
        {
            return Destroy;
        }
       

    }
}
