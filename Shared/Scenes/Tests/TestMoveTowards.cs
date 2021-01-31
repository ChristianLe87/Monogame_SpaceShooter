using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class TestMoveTowards : IScene
    {
        Bullet bullet_1;
        Bullet bullet_2;
        Bullet bullet_3;
        Bullet bullet_4;

        public TestMoveTowards()
        {
            Initialize();
        }

        public void Initialize()
        {
            bullet_1 = new Bullet(startPoint: new Vector2(0, 0), targetPoint: new Vector2(700, 300));
            bullet_2 = new Bullet(startPoint: new Vector2(0, 300), targetPoint: new Vector2(700, 0));
            bullet_3 = new Bullet(startPoint: new Vector2(700, 300), targetPoint: new Vector2(0, 0));
            bullet_4 = new Bullet(startPoint: new Vector2(700, 0), targetPoint: new Vector2(0, 300));
        }

        public void Update()
        {
            //bullet_1.Update();
            bullet_2.Update();
            //bullet_3.Update();
            //bullet_4.Update();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            //bullet_1.Draw(spriteBatch);
            bullet_2.Draw(spriteBatch);
            //bullet_3.Draw(spriteBatch);
            //bullet_4.Draw(spriteBatch);
        }
    }
}
