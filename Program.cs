// Тестовое задание.
// В данной задаче будут рассматриваться 13-ти значные числа в тринадцатиричной системе исчисления(цифры 0,1,2,3,4,5,6,7,8,9, A, B, C) с ведущими нулями.
// Например, ABA98859978C0, 6789110551234, 0000007000000
// Назовем число красивым, если сумма его первых шести цифр равна сумме шести последних цифр.
// Пример:
// Число 0055237050A00 - красивое, так как 0+0+5+5+2+3 = 0+5+0+A+0+0
// Число 1234AB988BABA - некрасивое, так как 1+2+3+4+A+B != 8+8+B+A+B+A​
// Задача:
// написать программу на С# печатающую в стандартный вывод количество 13-ти значных красивых чисел с ведущими нулями в тринадцатиричной системе исчисления.
// В качестве решения должен быть предоставлено:
// 1) ответ - количество таких чисел.Ответ должен быть представлен в десятичной системе исчисления.
// 2) исходный код программы.
// Пож-та, кроме кода, напишите ответ числом в теле письма.


namespace TestAssignmentApp;

public class Program
{
    const int LENGTH_OF_TICKET_NUMBER = 13;
    const int NUMBER_SYSTEM = 13;


    public static void Main()
    {
        Console.WriteLine("Counting in progress...");
        Console.WriteLine($"Amount of the beautiful ticket numbers: {CountLuckyNumbers()}");
    }


    /// <summary>
    /// Optimized version of algorithm for counting lucky numbers.
    /// </summary>
    /// <returns>Quantity Of lucky tickets.</returns> 
    public static ulong CountLuckyNumbers()
    {
        checked
        {              
            // First of all we need to take the half of ticket number length.

            int halfLength = LENGTH_OF_TICKET_NUMBER / 2;


            // And then find the number of combinations for each sum of digits
            // between 0 and max possible.

            NumberSystem numberSystem = new(NUMBER_SYSTEM);
            int[] maxNumber = numberSystem.CalcMaxNumberFor(halfLength);
            int biggestSum = maxNumber.Sum();

            IEnumerable<int> combinationAmounts = Enumerable.Range(0, biggestSum + 1)
                .Select(possibleSum => CountCombinationsFor(possibleSum, maxNumber.Length));


            // Total quantity for tickets with even count of digits in a number
            // is count for half to the power of two.

            ulong quantityOfEvenLuckyTickets = 0;
            foreach (var amount in combinationAmounts)
                quantityOfEvenLuckyTickets += (ulong)Math.Pow(amount, 2);


            // For odd ones, the number of combinations increases by NUMBER SYSTEM times.

            bool isOddNumber = LENGTH_OF_TICKET_NUMBER % 2 == 1;
            ulong quantityOfLuckyTickets = isOddNumber ? quantityOfEvenLuckyTickets *= NUMBER_SYSTEM : quantityOfEvenLuckyTickets;


            // Finaly.

            return quantityOfLuckyTickets;
        }
    }


    /// <summary>
    /// The function looks for the number of combinations for specific sum of digits
    /// Based on following recursive formula:
    ///          d
    /// Nn(k) =  ∑  Nn–1(k – l);
    ///         l=0 
    /// </summary>
    public static int CountCombinationsFor(int sumOfDigits, int digitsCount)
    {
        if (digitsCount <= 1)
            return sumOfDigits < NUMBER_SYSTEM ? 1 : 0;

        return Enumerable.Range(0, NUMBER_SYSTEM)
            .Select(digit => digit > sumOfDigits ? 0 : CountCombinationsFor(sumOfDigits - digit, digitsCount - 1))
            .Sum();
    }


    /// <summary>
    /// Provides conversion tools between decimal number system and custom one.
    /// </summary>
    private class NumberSystem
    {
        private readonly int[] digits;

        internal NumberSystem(int scale)
            => digits = Enumerable.Range(0, scale).ToArray();

        internal int[] CalcMaxNumberFor(int lengthOfDigits)
            => Enumerable.Repeat(digits.Length - 1, lengthOfDigits).ToArray();
    }

}
