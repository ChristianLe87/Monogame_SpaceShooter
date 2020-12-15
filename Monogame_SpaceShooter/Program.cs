using Shared;

namespace Monogame_SpaceShooter
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new Game1())
            {
                game.Run();
            }
        }
    }
}
