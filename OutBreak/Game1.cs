using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutBreak
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Color theColor;
        private readonly int maxX = 600;
        private readonly int maxY = 900;
        private Ball theBall;
        private Block theBlock;
        private Upgrade BallUp;
        private PlayerSect thePlayers;
        private bool BlockCollide;
        private bool BlockCollideX;
        private bool GameOver;
        public int Score = 0;
        private MultiBlock theBlocks;
        SpriteFont font;
        Random rnd = new Random();
        private int RandomNum;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = maxX;
            _graphics.PreferredBackBufferHeight = maxY;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            theColor = new Color();
            theColor = Color.CornflowerBlue;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            theBall = new Ball(this, 0, 600);
            theBlock = new Block(this, 30, 20);
            BallUp = new Upgrade(this, 30, 40);
            thePlayers = new PlayerSect(this);
            theBlocks = new MultiBlock(this);
            font = Content.Load<SpriteFont>("Algerian");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
           
            theBall.Move();
            BallUp.Move();
            thePlayers.Move();
            BlockCollideX = theBlocks.CollideX(theBall);
            BlockCollide = theBlocks.Collide(theBall);
            thePlayers.Collide(theBall);
            GameOver = theBall.GameOver();

            if (GameOver)
            {
                theColor = Color.Red;
            }  
            if (BlockCollide || BlockCollideX)
            {
                Score++;
                RandomNum = rnd.Next(0, 10);
            }


            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        public void ScoreUp()
        {
            Score++;
        }

        protected override void Draw(GameTime gameTime)
        {
            if (BlockCollide || BlockCollideX)
            {
                RandomNum = rnd.Next(0, 2);
            }
            if (Score == 10000)
            {
                theColor = Color.Green;
            }
            string Text = "Hello";
            Text = "Good Job!!!";
            Vector2 position = new Vector2(400, 700);
            Vector2 textMidPoint = font.MeasureString(Text) / 2;
            GraphicsDevice.Clear(theColor);
            _spriteBatch.Begin();
            if (Score == 100)
            {
                _spriteBatch.DrawString(font, Text, position, Color.Black, 0, textMidPoint, 2.0f, SpriteEffects.None, .5f);
            }
            thePlayers.Draw(_spriteBatch);
            BallUp.Draw(_spriteBatch);
            theBall.Draw(_spriteBatch);
            theBlocks.Draw(_spriteBatch);
            
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
