using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExampleCode
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        /// <summary>Contains values for resolution widths.</summary>
        ushort[] widths;

        /// <summary>Contains values for resolution heights.</summary>
        ushort[] heights;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // These arrays contain resolution data. Use the same index on them to get a resolution.
            widths = new ushort[] { 3840, 2560, 2560, 1920, 1366, 1280, 1280 };
            heights = new ushort[] { 2160, 1440, 1080, 1080, 768, 1024, 720 };

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
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // This Keys[] array and for loop is a small input handler to reduce the number of if statements
            Keys[] FunctionKeys = new Keys[] { Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7 };

            // This for loop will check if one of the keys in the FunctionKeys array is pressed.
            for (byte i = 0; i < FunctionKeys.Length; i++)
            {
                // If one of the keys in FunctionKeys is pressed it will change the resolution based on the index of that key
                if (Keyboard.GetState().IsKeyDown(FunctionKeys[i]))
                {
                    ChangeResolution(i);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        void ChangeResolution(byte newResolution)
        {
            // Only change resolution if the newResolution is between 0 and the length of the widths array
            if (newResolution >= 0 && newResolution < widths.Length)
            {
                // Change the width and height to the new values in the array
                _graphics.PreferredBackBufferWidth = widths[newResolution];
                _graphics.PreferredBackBufferHeight = heights[newResolution];

                // Apply the changes
                _graphics.ApplyChanges();

                System.Diagnostics.Debug.WriteLine("New resolution: {0} x {1}", _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            }
        }
    }
}