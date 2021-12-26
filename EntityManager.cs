using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Linq;
using System;


namespace nonTuto
{
    class EntityManager
    {
        public static List<Entity> entities = new List<Entity>();
        static List<Entity> addedentities = new List<Entity>();

        static bool isUpdating = false;


        public static void Add(Entity _entity)
        {
            if (!isUpdating)
            {
                entities.Add(_entity);
            }
            else
            {
                addedentities.Add(_entity);
            }
        }

        public static void Update(GameTime gt)
        {

            isUpdating = true;

            

            foreach (var entity in entities)
            {
                entity.Update(gt);
            }

            isUpdating = false;

            

            if (addedentities.Count > 0)
            {
                foreach (var entity in addedentities)
                {
                    entities.Add(entity);
                }
                addedentities.Clear();
            }

            entities = entities.Where(x => (x.IsEnable) ).ToList();



        }

        public static void Draw(SpriteBatch _spriteBatch)
        {
            foreach (Entity entity in entities)
            {
                entity.Draw(_spriteBatch);
            }
        }
    }
}