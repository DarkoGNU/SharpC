namespace SnowApp
{
    class SnowGen
    {
        static Random random = new Random();

        ConsoleColor[] colors;
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
            this.colors = new ConsoleColor[] { ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.Cyan, ConsoleColor.DarkBlue };
        }

        public ConsoleColor GetColor()
        {
            return colors[random.Next(0, colors.Length)];
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

            return flakes += '\n';
        }

        void PrintScreen(List<Tuple<string, ConsoleColor>> screen)
        {
            Console.SetCursorPosition(0, 0);
            foreach (Tuple<string, ConsoleColor> pair in screen)
            {
                Console.ForegroundColor = pair.Item2;
                Console.Write(pair.Item1);
            }
        }

        public void Run()
        {
            int currentRow = 0;

            List<Tuple<string, ConsoleColor>> screen = new List<Tuple<string, ConsoleColor>>();
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            while (infinite || currentRow++ < rows)
            {
                if (screen.Count > height)
                {
                    screen.RemoveAt(screen.Count - 1);

                }

                screen.Insert(0, new Tuple<string, ConsoleColor>(GetRow(width), GetColor()));
                PrintScreen(screen);

                Thread.Sleep(interval);
            }
        }
    }
}
