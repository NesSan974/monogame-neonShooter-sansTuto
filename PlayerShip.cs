using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;


namespace nonTuto
{
    class PlayerShip : Entity
    {

        private static PlayerShip instance;
        private static float speed = 5f;


        private static int cooldown = 10;
        private static int cooldownRemaining = 0;

        private static float bulletSpeed = 10f;

        private const float offsetOrientation = (float) -Math.PI / 2;




        public static PlayerShip Instance
        {
            get
            {
                if (instance == null)
                    instance = new PlayerShip();

                return instance;
            }
        }

        private bool IsDead;

        public PlayerShip()
        {
            Position = Vector2.Zero;
            image = Asset.ship;
            Scale = 0.5f;
            IsDead = false;
        }


        public override void Update(GameTime gt)
        {



            // speed *= (float)( gt.ElapsedGameTime.TotalMilliseconds / 16.6667f );


            

            var aimAngle = Input.GetAimDirection().ToAngle();

            Velocity = Input.GetMouvementDirection() * speed;

            Position += Velocity;


            Position = Vector2.Clamp(Position, Vector2.Zero + Size, new Vector2 (Game1._graphics.PreferredBackBufferWidth, Game1._graphics.PreferredBackBufferHeight) - Size);

            cooldownRemaining--;

            if (Input.GetAimDirection() != Vector2.Zero)
            {
                Orientation = aimAngle;
                Orientation += offsetOrientation ;
            }


            if (cooldownRemaining <= 0 && Input.GetAimDirection().LengthSquared() != 0)
            {
                cooldownRemaining = cooldown;

                var randomFire = rand.NextFloat(-0.05f, 0.05f);

                Quaternion quat = Quaternion.CreateFromYawPitchRoll(0,0, aimAngle );

                var offset = Vector2.Transform (new Vector2(image.Width * Scale -80 , image.Width * Scale / 6 ), quat );


                Vector2 _velocity = MathUtil.FromPolar(aimAngle + randomFire, bulletSpeed);
                // en fait si on fait getAim() * 10, quand tu tire en digonal ca va BEAUCOUP trop vite x)
                //d'ou le "FromPolar"


                EntityManager.Add(new Bullet(Position + offset, _velocity));

                offset = Vector2.Transform (new Vector2(image.Width * Scale - 80 , - image.Width * Scale / 6 ), quat );

                EntityManager.Add(new Bullet(Position + offset, _velocity));


            }
        }


        public override void Draw(SpriteBatch _spriteBatch)
        {
            if (!IsDead)
            {
                base.Draw(_spriteBatch);
            }
        }
    }
}