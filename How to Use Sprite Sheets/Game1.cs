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

        /// <summary>Stores milliseconds that pass in the game.</summary>
        float timer;

        /// <summary>An int that is the threshold for the timer.</summary>
        int threshold;

        /// <summary>A Rectangle array that stores sourceRectangles for animations.</summary>
        Rectangle[] sourceRectangles;

        /// <summary>This is the index of the previous sourceRectangle to display.</summary>
        byte previousSourceRectangle;

        /// <summary>This is the index of the current sourceRectangle to display.</summary>
        byte currentSourceRectangle;

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

            // Set a default timer value.
            timer = 0;

            // Set an initial threshold of 250ms, you can change this to alter the speed of the animation (lower number = faster animation).

            threshold = 250;

            // Three sourceRectangles contain the coordinates of Alex's three down-facing sprites on the charaset.
            sourceRectangles = new Rectangle[3];
            sourceRectangles[0] = new Rectangle(0, 128, 48, 64);
            sourceRectangles[1] = new Rectangle(48, 128, 48, 64);
            sourceRectangles[2] = new Rectangle(96, 128, 48, 64);

            // This tells the animation to start on the left-side sprite.
            previousSourceRectangle = 2;
            currentSourceRectangle = 1;

            // Set the draw position.
            position = new Vector2(100, 100);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Check if the timer has exceeded the threshold.
            if (timer > threshold)
            {
                // If Alex is in the middle sprite of the animation.
                if (currentSourceRectangle == 1)
                {
                    // If the previous animation was the left-side sprite, then the next animation should be the right-side sprite.
                    if (previousSourceRectangle == 0)
                    {
                        currentSourceRectangle = 2;
                    }
                    else
                    // If not, then the next animation should be the left-side sprite.
                    {
                        currentSourceRectangle = 0;
                    }

                    // Track the animation.
                    previousSourceRectangle = currentSourceRectangle;
                }
                // If Alex was not in the middle sprite of the animation, he should return to the middle sprite.
                else
                {
                    currentSourceRectangle = 1;
                }

                // Reset the timer.
                timer = 0;
            }
            // If the timer has not reached the threshold, then add the milliseconds that have past since the last Update() to the timer.
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            // Draw the sprite based on the sourceRectangle and currentSourceRectangle .
            _spriteBatch.Draw(charaset, new Vector2(100, 100), sourceRectangles[currentSourceRectangle], Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}