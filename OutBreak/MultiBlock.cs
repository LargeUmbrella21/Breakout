using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace OutBreak
{
    public class MultiBlock
    {
        //ArrayList BlockList = new ArrayList();
        Block[,] BlockArray = new Block[10, 10];
        private int Score;

        /**public MultiBlock(Game theGame, int numBlocks)
        {
            for (int i = 0; i < 5; i++) 
            {
                for (int j = 0; j < numBlocks; j++)
                {
                    Block theBlock = new Block(theGame, 60 * j + 60, 50);
                    //BlockList.Add(theBlock);

                }
            }
        }**/
        public MultiBlock(Game theGame)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    BlockArray[i, j] = new Block(theGame, 60 * j, 30 * i);
                    //BlockList.Add(theBlock);

                }
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    BlockArray[i, j].Draw(_spriteBatch);
                    //BlockList.Add(theBlock);

                }
            }
        }
        public bool Collide(Ball theBall)
        {
            foreach (Block theBlock in BlockArray)
            {
                if (theBlock.CheckCollide(theBall))
                {
                    Score++;
                    return true;
                }
            }
            return false;
        }
        public bool CollideX(Ball theBall)
        {
            foreach (Block theBlockX in BlockArray)
            {
                if (theBlockX.CheckCollideX(theBall))
                {
                    Score++;
                    return true;
                }
            }
            return false;
        }

    }
}
