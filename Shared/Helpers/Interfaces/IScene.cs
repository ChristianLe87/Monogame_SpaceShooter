using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IScene
    {
        void Initialize();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
