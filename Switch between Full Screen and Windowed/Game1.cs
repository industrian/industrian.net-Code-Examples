using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExampleCode
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

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
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Press/Hold F1 to become a borderless window.
            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                ControlWindowedMode(true);
            }

            // Press/Hold F2 to become a normal window.
            if (Keyboard.GetState().IsKeyDown(Keys.F2))
            {
                ControlWindowedMode(false);
            }

            // Press/Hold F3 to enter fullscreen.
            if (Keyboard.GetState().IsKeyDown(Keys.F3))
            {
                ControlFullScreenMode(true);
            }

            // Press/Hold F4 to exit fullscreen.
            if (Keyboard.GetState().IsKeyDown(Keys.F4))
            {
                ControlFullScreenMode(false);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        /// <summary>Switches the windowed mode between borderless and bordered.</summary>
        /// <param name="becomeBorderless">If the window should become borderless.</param>
        void ControlWindowedMode(bool becomeBorderless)
        {
            Window.IsBorderless = becomeBorderless;
            _graphics.ApplyChanges();
        }

        /// <summary>Switches between windowed and full screen.</summary>
        /// <param name="becomeFullscreen">If the game should be displayed in full screen.</param>
        void ControlFullScreenMode(bool becomeFullscreen)
        {
            _graphics.IsFullScreen = becomeFullscreen;
            _graphics.ApplyChanges();
        }
    }
}