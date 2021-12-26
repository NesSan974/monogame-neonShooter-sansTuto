using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace nonTuto
{
    class Asset
    {
        public static Texture2D ship;
        public static Texture2D bullet;
        public static Texture2D shield;
        public static Texture2D wanderer;
        public static Texture2D seeker;



        public static void Load(ContentManager Content){
            ship = Content.Load<Texture2D>("Player");
            bullet = Content.Load<Texture2D>("Bullet");
            wanderer = Content.Load<Texture2D>("Wanderer");
            seeker = Content.Load<Texture2D>("seeker1");
            shield = Content.Load<Texture2D>("spr_shield");
        }
    }

}
