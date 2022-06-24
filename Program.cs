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



const int LENGTH_OF_TICKET_NUMBER = 7;
const int NUMBER_SYSTEM = 13;

// В общем случае счастливых билетов с суммой цифр, равной k в каждой «половинке», будет [N(k)^2].
// Например для "половины" из 3 знаков десятеричной системы исчисления наименьшее возможное значение k равно 0 (для номера 000), а наибольшее — 27 (для номера 999)


int halfLength = LENGTH_OF_TICKET_NUMBER / 2;

NumberSystem numberSystem = new(NUMBER_SYSTEM);
int[] maxNumber = numberSystem.CalcMaxNumberFor(halfLength);
int biggestSum = maxNumber.Sum();

int quantityOfLuckyTickets = 0;

for (int k = 0; k <= biggestSum; k++)
{
    int uniqueValues = CountUniqueValuesFor(k, maxNumber.Length);
    quantityOfLuckyTickets += (int)Math.Pow(uniqueValues, 2);
}

int CountUniqueValuesFor(int k, int digitCount)
{
    if (digitCount <= 1)
        return k < NUMBER_SYSTEM ? 1 : 0;

    return Enumerable.Range(0, NUMBER_SYSTEM)
        .Select(l => (l > k) ? 0 : CountUniqueValuesFor(k - l, digitCount - 1))
        .Sum();
}

bool isOddNumber = LENGTH_OF_TICKET_NUMBER % 2 == 1;
if (isOddNumber)
{
    quantityOfLuckyTickets *= NUMBER_SYSTEM;
}

Console.WriteLine(quantityOfLuckyTickets);




class NumberSystem
{
    private readonly int[] digits;

    internal NumberSystem(int scale) 
        => digits = Enumerable.Range(0, scale).ToArray();

    internal int[] CalcMaxNumberFor(int lengthOfDigits) 
        => Enumerable.Repeat(digits.Length - 1, lengthOfDigits).ToArray();
}
