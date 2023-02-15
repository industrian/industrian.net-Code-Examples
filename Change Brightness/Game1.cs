using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExampleCode
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        /// <summary>A single-pixel texture that will be stretched to cover the screen.</summary>
        Texture2D pixel;

        /// <summary>A value for the player to control brightness.</summary>
        byte brightnessValue;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // Create a 1x1 Texture.
            pixel = new Texture2D(GraphicsDevice, 1, 1);

            // Set the color data to the 1x1 Texture.
            pixel.SetData<Color>(new Color[] { Color.White });

            // Set a default brightnessValue of 100 (full brightness).
            brightnessValue = 100;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Press/Hold the Page Up key to increase the brightness.
            if (Keyboard.GetState().IsKeyDown(Keys.PageUp))
            {
                IncreaseBrightness();
            }

            // Press/Hold the Page Down key to increase the brightness.
            if (Keyboard.GetState().IsKeyDown(Keys.PageDown))
            {
                DecreaseBrightness();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            // brightnessMultiplier will contain a percentage value of transparency.
            float brightnessMultiplier;

            // Remove the current brightnessValue from 100 and divide it by 100 to get a value between 0 and 1.00.
            brightnessMultiplier = 100 - brightnessValue;
            brightnessMultiplier /= 100;

            // Stretch the single-pixel texture to cover the screen. The color black is rendered using brightnessMultiplier as its transparency value.
            _spriteBatch.Draw(pixel, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.Black * brightnessMultiplier);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        void IncreaseBrightness()
        {
            // Brightness can only be increased if it is under 100.
            if (brightnessValue < 100)
            {
                brightnessValue++;
                System.Diagnostics.Debug.WriteLine("Brightness: {0} %", brightnessValue);
            }
        }
        void DecreaseBrightness()
        {
            // Brightness can only be decreased if it is above 0.
            if (brightnessValue > 0)
            {
                brightnessValue--;
                System.Diagnostics.Debug.WriteLine("Brightness: {0} %", brightnessValue);
            }
        }
    }
}