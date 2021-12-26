using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;


using System;


namespace nonTuto {
    abstract class Entity
    {
        public Vector2 Position, Velocity;

        public float Scale = 1f;
        public float Orientation;

        public bool IsEnable = true;

        protected Texture2D image;
        protected Color _color = Color.White;

        public static Random rand = new Random();


        public Vector2 Size
        {
            get
            {
                return image == null ? Vector2.Zero : new Vector2(image.Width, image.Height);
            }
        }

        public abstract void Update(GameTime gt);
        

        public virtual void Draw(SpriteBatch _spriteBatch){

            var s = Scale;

            if (this is Ennemy)
                s = 0.5f;


            _spriteBatch.Draw(image, Position, null, _color, Orientation, Size / 2f, s, 0, 0);
        }


    }
}