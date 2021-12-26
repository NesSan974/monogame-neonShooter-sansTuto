using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;


namespace nonTuto
{
    class EnnemySpawner
    {

        private static int spawnChance = 300;
        private static Random rand = new Random();


        public static void Update()
        {
            if (EntityManager.entities.Count >= 200)
            {
                if (rand.Next(spawnChance) == 0)
                { // wanderer
                    var ennemy = Ennemy.CreateWanderer(new Vector2(rand.Next(1500), rand.Next(900)));
                    EntityManager.Add(ennemy);

                }

                if (rand.Next(spawnChance) == 0)
                { // seeker
                    var ennemy = Ennemy.CreateSeeker(new Vector2(rand.Next(1500), rand.Next(900)));
                    EntityManager.Add(ennemy);

                }
            }


        }
    }
}