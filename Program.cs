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


const int LENGTH_OF_TICKET_NUMBER = 9;
const int NUMBER_SYSTEM = 13;

NumberSystem numberSystem = new(NUMBER_SYSTEM);
Console.WriteLine(numberSystem.ToInt(new[] { 1, 1, 0 }));


// Например для "половины" из 3 знаков десятеричной системы исчисления наименьшее возможное значение k равно 0 (для номера 000), а наибольшее — 27 (для номера 999)
// В общем случае счастливых билетов с суммой цифр, равной k в каждой «половинке», будет [N(k)^2].



int halfLength = LENGTH_OF_TICKET_NUMBER / 2;

int[] maxNumber = numberSystem.MaxNumber(halfLength);
int biggestSum = maxNumber.Sum();

ulong quantityOfLuckyTickets = 0;
for (int k = 0; k <= biggestSum; k++)
{
    quantityOfLuckyTickets += (ulong)Math.Pow(CountUniqueValuesFor(k, maxNumber), 2);
}

bool isOddNumber = LENGTH_OF_TICKET_NUMBER % 2 == 1;
if (isOddNumber)
{
    quantityOfLuckyTickets *= NUMBER_SYSTEM;
}

Console.WriteLine(quantityOfLuckyTickets);


int CountUniqueValuesFor(int k, int[] maxNumber)
{
    int result = 0;
    for (int i = 0; i <= numberSystem.ToInt(maxNumber); i++)
    {
        if (numberSystem.SumDigitsOf(i) == k)
            result++;
    }

    return result;
}


internal class NumberSystem
{
    private readonly int scale;
    private readonly int[] digits;

    internal NumberSystem(int scale)
    {
        this.scale = scale;
        digits = Enumerable.Range(0, scale).ToArray();
    }

    internal int[] MaxNumber(int lengthOfDigits) 
        => Enumerable.Repeat(digits.Length - 1, lengthOfDigits).ToArray();

    internal int ToInt(int[] number)
        => (int)number
            .Reverse()
            .Select((x, i) => x * Math.Pow(scale, i))
            .Sum();

    internal int SumDigitsOf(int n)
    {
        int sum = 0;
        while (n != 0)
        {
            sum += n % scale;
            n /= scale;
        }

        return sum;
    }
}
