using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class TestScene : IScene
    {
        string testMoveTowards = "TestMoveTowards";

        Dictionary<string, IScene> testScene;
        string actualTest;


        public TestScene()
        {
            Initialize();
        }

        public void Initialize()
        {
            testScene = new Dictionary<string, IScene>()
            {
                {testMoveTowards, new TestMoveTowards() }
            };

            actualTest = testMoveTowards;

        }

        public void Update()
        {
            testScene[actualTest].Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            testScene[actualTest].Draw(spriteBatch);
        }
    }
}
