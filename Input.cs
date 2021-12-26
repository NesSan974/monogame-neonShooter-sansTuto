using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using System.Linq;


namespace nonTuto
{
    class Input
    {
        private static KeyboardState keyboardState, lastkeyboardstate;
        private static MouseState mouseState, lastmousestate;
        private static GamePadState gamepadState, lastgamepadstate;

        private static bool isAimingWithMouse = false;

        public static void Update()
        {
            lastmousestate = mouseState;
            lastkeyboardstate = keyboardState;
            lastgamepadstate = gamepadState;

            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            gamepadState = GamePad.GetState(PlayerIndex.One);

            if (new[] { Keys.Up, Keys.Down, Keys.Left, Keys.Right }.Any(x => keyboardState.IsKeyDown(x) || gamepadState.ThumbSticks.Right != Vector2.Zero))
            {
                isAimingWithMouse = false;
            }
            else if (mouseState.Position != lastmousestate.Position)
            {
                isAimingWithMouse = true;
            }




        }


        public static bool IsKeyJustPress(Keys key)
        {
            return lastkeyboardstate.IsKeyUp(key) && keyboardState.IsKeyDown(key);
        }

        public static bool IsButtonJustPress(Buttons btn)
        {
            return lastgamepadstate.IsButtonUp(btn) && gamepadState.IsButtonDown(btn);
        }

        public static Vector2 GetMouvementDirection()
        {


            Vector2 vel = gamepadState.ThumbSticks.Left;
            vel.Y *= -1;

            if (keyboardState.IsKeyDown(Keys.Q))
            {
                vel.X -= 1;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                vel.X += 1;
            }
            if (keyboardState.IsKeyDown(Keys.Z))
            {
                vel.Y -= 1;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                vel.Y += 1;
            }

            if (vel.LengthSquared() > 1f)
            {
                vel.Normalize();
            }

            return vel;

        }


        public static Vector2 GetAimDirection()
        {

            if (isAimingWithMouse)
            {
                Vector2 mouseaim = mouseState.Position.ToVector2() - PlayerShip.Instance.Position;
                if (mouseaim == Vector2.Zero)
                {
                    return Vector2.Zero;
                }
                else
                {
                    return Vector2.Normalize(mouseaim);
                }
            }

            Vector2 aim = gamepadState.ThumbSticks.Right;
            aim.Y *= -1;

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                aim.X -= 1;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                aim.X += 1;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                aim.Y -= 1;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                aim.Y += 1;
            }





            return aim;
        }


    }
}