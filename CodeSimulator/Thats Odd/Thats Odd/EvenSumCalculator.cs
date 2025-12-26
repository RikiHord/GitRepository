namespace Thats_Odd
{
    public class EvenSumCalculator
    {
        public static int SumEvenNumbers(List<int> numbers)
        {
            int sum = 0;

            foreach (var num in numbers)
            {
                if (num % 2 == 0)
                {
                    sum += num;
                }
            }

            return sum;
        }
    }
}
