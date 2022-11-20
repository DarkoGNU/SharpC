namespace SnowApp
{
    class SnowGen
    {
        static Random random = new Random();

        bool infinite;
        int rows;
        int interval;
        double minChance;
        double maxChance;

        public SnowGen(bool infinite = true, double minChance = 0.3, double maxChance = 0.5, int rows = 99999, int interval = 500)
        {
            this.infinite = infinite;
            this.rows = rows;
            this.interval = interval;
            this.minChance = minChance;
            this.maxChance = maxChance;
        }

        public char GetFlake(double chance)
        {
            double randomDouble = random.NextDouble();

            if (randomDouble < chance)
            {
                return '*';
            }

            return ' ';
        }

        public string GetRow(int characters)
        {
            double chance = random.NextDouble() * (maxChance - minChance) + minChance;
            string flakes = "";

            for (int i = 0; i < characters; i++)
            {
                flakes += GetFlake(chance);
            }

            return flakes;
        }

        void PrintScreen(List<String> screen)
        {
            string wholeScreen = string.Join('\n', screen);
            Console.SetCursorPosition(0, 0);
            Console.Write(wholeScreen);
        }

        public void Run()
        {
            int currentRow = 0;

            List<string> screen = new List<string>();
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            while (infinite || currentRow++ < rows)
            {
                if (screen.Count > height)
                {
                    screen.RemoveAt(screen.Count - 1);

                }

                screen.Insert(0, GetRow(width));
                PrintScreen(screen);

                Thread.Sleep(interval);
            }
        }
    }
}
