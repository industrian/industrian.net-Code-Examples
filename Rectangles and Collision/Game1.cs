using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExampleCode
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        /// <summary>A single-pixel texture.</summary>
        Texture2D pixel;

        /// <summary>A large rectangle.</summary>
        Rectangle bigRectangle;

        /// <summary>A small rectangle.</summary>
        Rectangle smallRectangle;

        /// <summary>The color of the small rectangle.</summary>
        Color smallRectangleColor;

        /// <summary>Controls the movement of the smallRectangle.</summary>
        bool smallRectangleMovesLeft;

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

            // Create the single-pixel texture.
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });

            // Create the rectangles.
            bigRectangle = new Rectangle(200, 100, 300, 150);
            smallRectangle = new Rectangle(600, 150, 50, 50);

            // Set a default color for the smallRectangle.
            smallRectangleColor = Color.White;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // If smallRectangleMovesLeft is true, then smallRectangle moves to the left.
            if (smallRectangleMovesLeft)
            {
                // If the smallRectangle hits the left edge of the screen then it should change to move right.
                if (smallRectangle.Left == 0)
                {
                    smallRectangleMovesLeft = false;
                }
                // Otherwise it should move two pixels to the left.
                else
                {
                    smallRectangle.X -= 2;
                }
            }
            else
            {
                // If the smallRectangle hits the right edge of the screen then it should change to move left.
                if (smallRectangle.Right == _graphics.PreferredBackBufferWidth)
                {
                    smallRectangleMovesLeft = true;
                }
                // Otherwise it should move two pixels to the right.
                else
                {
                    smallRectangle.X += 2;
                }
            }

            // If the bigRectangle contains the smallRectangle, the smallRectangle should turn red.
            if (bigRectangle.Contains(smallRectangle))
            {
                smallRectangleColor = Color.Red;
            }
            else
            {
                // If the bigRectangle does not contain the smallRectangle but intersects it, the smallRectangle should turn orange.
                if (bigRectangle.Intersects(smallRectangle))
                {
                    smallRectangleColor = Color.Orange;
                }
                // If the bigRectangle neither contains or intersects the smallRectangle, the smallRectangle should turn white.
                else
                {
                    smallRectangleColor = Color.White;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            // Draw the big black rectangle
            _spriteBatch.Draw(pixel, bigRectangle, Color.Black);

            // Draw the small rectangle that changes color on collision
            _spriteBatch.Draw(pixel, smallRectangle, smallRectangleColor);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}