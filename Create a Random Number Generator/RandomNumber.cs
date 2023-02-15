using System;

class RandomNumber
{
    static Random rnd = new Random();

    public static int RandomInt(int min, int max)
    {
        // Switch around numbers if min is higher than max. Your game will crash if min is higher than max.
        if (max < min)
        {
            return rnd.Next(max, min);
        }

        return rnd.Next(min, max);
    }
}