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

            // TODO: Add your update logic here

            // Set the minimum and maximum values
            int minimum = 0;
            int maximum = 1000;

            #region Random numbers

            // Get the random number
            int randomNumber = RandomNumber.RandomInt(minimum, maximum);

            // Display the random number
            System.Diagnostics.Debug.WriteLine("A random number between {0} and {1}: {2}", minimum, maximum, randomNumber);

            #endregion

            #region Random names

            // An array of names
            string[] names = new string[] { "James", "John", "David", "Murray", "Ibrahim", "Dae-Hyun", "Esteban", "Connor", "Luke", "Cain", "Francois", "Herman", "Joseph", "Ivan", "Lloyd", "Michael", "Diego" };

            // An array of greetings
            string[] greetings = new string[] { "Hello", "Goodbye", "Good morning", "Good afternoon", "Good night", "Please", "Thank you", "Sorry", "Excuse me" };

            // Get a random name
            string randomName = names[RandomNumber.RandomInt(0, names.Length)];

            // Get a random greeting
            string randomGreeting = greetings[RandomNumber.RandomInt(0, greetings.Length)];

            // Output a sentence based on a randomly-selected name and greeting
            System.Diagnostics.Debug.WriteLine("{0} says \"{1}\"", randomName, randomGreeting);

            #endregion

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}