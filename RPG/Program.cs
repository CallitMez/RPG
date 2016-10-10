namespace RPG
{
    public static class Program
    {
        static void Main()
        {
            using (var game = new RPGGame())
                game.Run();
        }
    }
}
