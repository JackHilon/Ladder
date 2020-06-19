using System;

namespace Ladder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ladder
            // https://open.kattis.com/problems/ladder 
            // 
            // ----------------------------------------
            //                   /          |
            //        (Ladder)  /           |
            //                 /            |
            //                / (v angle)   | (h height)
            // -----------------------------------------

            var twoParameters = EnterLine();
            var length = LadderLength(twoParameters[0], twoParameters[1]);
            var roundedLength = RoundedUpToTheNearestInt(length);

            Console.WriteLine(roundedLength);

        }
        private static int RoundedUpToTheNearestInt(double a)
        {
            // int num = (int) Math.Round(a, MidpointRounding.ToPositiveInfinity);
            int num = (int) Math.Ceiling(a);
            return num;
        }

        private static double LadderLength(int height, int angleDeg)
        {
            double angleRad = (double)angleDeg;
            angleRad = (angleRad * Math.PI) / 180;
            return height / Math.Sin(angleRad);
        }

        private static int[] EnterLine()
        {
            var res = new int[2] { 0, 0 };
            var arr = new string[2] { "", "" };
            try
            {
                arr = Console.ReadLine().Split(' ', 2);
                for (int i = 0; i < arr.Length; i++)
                {
                    res[i] = int.Parse(arr[i]);
                }
                if (res[0] < 1 || res[0] > 10000 || res[1] < 1 || res[1] > 89)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterLine();
            }
            return res;
        }
    }
}
