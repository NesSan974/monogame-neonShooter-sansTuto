using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace nonTuto
{
    class Ennemy : Entity
    {


        public static Ennemy CreateSeeker(Vector2 _pos)
        {
            


            return new Ennemy(Asset.seeker, _pos);


        }

        public static Ennemy CreateWanderer(Vector2 _pos)
        {
            return new Ennemy(Asset.wanderer, _pos);
            

        }


        internal Ennemy(Texture2D _image, Vector2 _pos)
        {
            image = _image;
            Position = _pos;

        }




        public override void Update(GameTime gt)
        {
            
        }
    }
}