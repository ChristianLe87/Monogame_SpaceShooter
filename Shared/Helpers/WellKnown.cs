namespace Shared
{
    public class WK
    {
        public class Default
        {
            public static readonly int CanvasWidth = 700;
            public static readonly int CanvasHeight = 700;

            public static readonly int FPS = 60;

            public static readonly char[,] FontCharacters = new char[,]
            {
                { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' },
                { ',', ':', ';', '?', '.', '!', ' ','\'','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' }
            };
    }

        public class Content
        {
            public static readonly string Spaceship = "Player_PNG_50x50";
            public static readonly string Target = "Target_PNG_300x300";
            public static readonly string Font_16 = "MyFont_PNG_260x56";
            public static readonly string Font_7 = "MyFont_PNG_130x28";
        }

        public class Scene
        {
            public static readonly string Menu = "Menu";
            public static readonly string GameScene = "GameScene";
            public static readonly string TestScene = "TestScene";
        }
    }
}