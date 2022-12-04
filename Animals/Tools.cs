using static Tools;

class Tools
{
    private static Random random = new Random();

    public static double RandomDouble(double minNumber, double maxNumber)
    {
        return random.NextDouble() * (maxNumber - minNumber) + minNumber;
    }

    public static int RandomInt(int minNumber, int maxNumber)
    {
        return random.Next(minNumber, maxNumber);
    }

    public static bool RandBool()
    {
        // https://stackoverflow.com/questions/19191058/fastest-way-to-generate-a-random-boolean
        return random.Next() > (Int32.MaxValue / 2);
    }
}
