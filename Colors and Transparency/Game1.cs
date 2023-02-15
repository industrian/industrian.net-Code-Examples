using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExampleCode
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        /// <summary>The Texture2D of the charaset.</summary>
        Texture2D charaset;

        /// <summary>The position to draw the charaset.</summary>
        Vector2 position;

        /// <summary>The color to display the charaset.</summary>
        Color displayColor;

        /// <summary>The transparency to display the charaset.</summary>
        float displayTransparency;

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

            // Load the charaset.
            charaset = Content.Load<Texture2D>("charaset");

            // Set the draw position.
            position = new Vector2(100, 100);

            // Set the initial display color to have no tint.
            displayColor = Color.White;

            // Set the initial transparency to 50%.
            displayTransparency = 0.5f;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Press/Hold the Page Up key to increase opacity.
            if (Keyboard.GetState().IsKeyDown(Keys.PageUp))
            {
                // Only increase opacity if it is not already at maximum.
                if (displayTransparency < 1)
                {
                    displayTransparency += 0.01f;
                    System.Diagnostics.Debug.WriteLine("New transparency value: {0}", displayTransparency);
                }
            }

            // Press/Hold the Page Down key to increase transparency.
            if (Keyboard.GetState().IsKeyDown(Keys.PageDown))
            {
                // Only increase transparency if it is not already at maximum.
                if (displayTransparency > 0.02f)
                {
                    displayTransparency -= 0.01f;
                    System.Diagnostics.Debug.WriteLine("New transparency value: {0}", displayTransparency);
                }
            }

            // Change the color to Color.White.
            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                displayColor = Color.White;
                System.Diagnostics.Debug.WriteLine("New display color: {0}", displayColor);
            }

            // Change the color to Color.Red.
            if (Keyboard.GetState().IsKeyDown(Keys.F2))
            {
                displayColor = Color.Red;
                System.Diagnostics.Debug.WriteLine("New display color: {0}", displayColor);
            }

            // Change the color to Color.Green.
            if (Keyboard.GetState().IsKeyDown(Keys.F3))
            {
                displayColor = Color.Green;
                System.Diagnostics.Debug.WriteLine("New display color: {0}", displayColor);
            }

            // Change the color to Color.Blue.
            if (Keyboard.GetState().IsKeyDown(Keys.F4))
            {
                displayColor = Color.Blue;
                System.Diagnostics.Debug.WriteLine("New display color: {0}", displayColor);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            // Draw the charaset with a defined displayColor and displayTransparency
            _spriteBatch.Draw(charaset, new Vector2(100, 100), displayColor * displayTransparency);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}