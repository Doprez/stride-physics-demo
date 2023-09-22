using Stride.Engine;

namespace PhysicsPerfDemo
{
    class PhysicsPerfDemoApp
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
