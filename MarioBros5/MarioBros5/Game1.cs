using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MarioBros5
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, mario;
        Rectangle backgroundRect, marioRect, marioDestinationRect;
        KeyboardState ks;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            // Hier kun je je schermgrootte aanpassen
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;

            // Je kunt ook je scherm fullscreen instellen
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Dit maakt de muis zichtbaar in de game
            IsMouseVisible = true; 
           
            // Naam veranderen van je canvas
            Window.Title = "Super Mario beta 0.00.00.00.00.00.2";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>(@"Assets\super-mario-background");
            mario = Content.Load<Texture2D>(@"Assets\NewSuperMarioBrosSheet");
            backgroundRect = new Rectangle(0, 0, 640, 480);
            marioRect = new Rectangle(320, 395, 17, 21);
            marioDestinationRect = new Rectangle(152, 27, 17, 21);
        }

       
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
              this.Exit();
            ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Right))
            {
                marioRect.X += 1;
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                marioRect.X -= 1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);
            spriteBatch.Begin();
            spriteBatch.Draw(background, backgroundRect, Color.White);
            spriteBatch.Draw(mario, marioRect, marioDestinationRect, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
