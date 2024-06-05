using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OutBreak
{
    class PlayerSect
    {
        Player[] PlayerArray = new Player[5];
        
        public PlayerSect(Game theGame)
        {
            for (int i = 0; i < 5; i++)
            {
                    PlayerArray[i] = new Player(theGame, 20*i , 800);
            }
        }
        public void Move()
        {
            foreach (Player thePlayer in PlayerArray)
            {
                thePlayer.Move();
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (Player thePlayer in PlayerArray)
            {
                thePlayer.Draw(_spriteBatch);
            }
        }
        public void Collide(Ball theBall)
        {
            if (PlayerArray[0].CheckCollision(theBall))
            {
                theBall.PlayerHit0();
            }
            else if (PlayerArray[1].CheckCollision(theBall))
            {
                theBall.PlayerHit1();
            }
            else if (PlayerArray[2].CheckCollision(theBall))
            {
                theBall.PlayerHit2();
            }
            else if (PlayerArray[3].CheckCollision(theBall))
            {
                theBall.PlayerHit3();
            }
            else if (PlayerArray[4].CheckCollision(theBall))
            {
                theBall.PlayerHit4();
            }

            /*foreach (Player thePlayer in PlayerArray)
            {
                if (thePlayer.CheckCollision(theBall))
                {
                    return true;
                }
            }
            return false;*/
        }
    }
}
