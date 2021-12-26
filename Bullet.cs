using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace nonTuto
{
    class Bullet : Entity
    {



        public Bullet(Vector2 _pos, Vector2 _vel)
        {
            image = Asset.bullet;
            Position = _pos;
            Velocity = _vel;
            Orientation = Velocity.ToAngle();

        }

        public override void Update(GameTime gt)
        {

            if (Velocity.LengthSquared() > 0)
                Orientation = Velocity.ToAngle();


            Position += Velocity;

               if  (!Game1._graphics.GraphicsDevice.Viewport.Bounds.Contains(Position.ToPoint()))
               {
                   IsEnable = false;
               }
        }
    }
}