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

        public SnowGen(bool infinite=true, double minChance=0.3, double maxChance=0.5, int rows = 99999, int interval=500)
        {
            this.infinite = infinite;
            this.rows = rows;
            this.interval = interval;
            this.minChance = minChance;
            this.maxChance = maxChance;
        }

        public char getFlake(double chance)
        {
            double randomDouble = random.NextDouble();

            if (randomDouble < chance)
            {
                return '*';
            }

            return ' ';
        }

        public String getRow(int characters)
        {
            double chance = random.NextDouble() * (maxChance - minChance) + minChance;
            String flakes = "";

            for (int i = 0; i < characters; i++)
            {
                flakes += getFlake(chance);
            }

            return flakes;
        }

        public void run()
        {
            int currentRow = 0;

            List<String> screen;
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            while (infinite || currentRow++ < rows)
            {
                screen
                printScreen(screen);
                System.Threading.Thread.Sleep(interval);
            }
        }
    }
}
