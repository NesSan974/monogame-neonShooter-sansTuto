using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

namespace nonTuto
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        private int _width = 1500;
        private int _height = 900;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            _graphics.PreferredBackBufferWidth = _width;
            _graphics.PreferredBackBufferHeight = _height;

            _graphics.ApplyChanges();


            base.Initialize();

            EntityManager.Add(PlayerShip.Instance);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Asset.Load(Content);



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {


            EntityManager.Update(gameTime);
            Input.Update();
            EnnemySpawner.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // TODO: Add your drawing code here
            EntityManager.Draw(_spriteBatch);

            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
