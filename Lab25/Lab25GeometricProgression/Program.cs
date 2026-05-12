using System;
using System.Collections.Generic;

internal class Program
{
    private const double Epsilon = 0.000001;

    private static void Main()
    {
        List<double> progression = new() { 2, 6, 18, 54, 162 };
        Console.WriteLine("Список 1: " + string.Join(", ", progression));
        Console.WriteLine("Является геометрической прогрессией: " + IsGeometricProgression(progression));

        List<double> notProgression = new() { 2, 6, 18, 55, 162 };
        Console.WriteLine("\nСписок 2: " + string.Join(", ", notProgression));
        Console.WriteLine("Является геометрической прогрессией: " + IsGeometricProgression(notProgression));

        List<double> emptyList = new();
        Console.WriteLine("\nПустой список: " + IsGeometricProgression(emptyList));

        List<double> singleElement = new() { 5 };
        Console.WriteLine("Список с одним элементом: " + IsGeometricProgression(singleElement));

        List<double> twoElements = new() { 3, 12 };
        Console.WriteLine("Список с двумя элементами: " + IsGeometricProgression(twoElements));

        List<double> zeros = new() { 0, 0, 0 };
        Console.WriteLine("Нули: " + IsGeometricProgression(zeros));
    }

    private static bool IsGeometricProgression(List<double> numbers)
    {
        if (numbers is null || numbers.Count < 2)
        {
            return false;
        }

        if (Math.Abs(numbers[0]) <= Epsilon)
        {
            for (int i = 1; i < numbers.Count; i++)
            {
                if (Math.Abs(numbers[i]) > Epsilon)
                {
                    return false;
                }
            }

            return true;
        }

        double ratio = numbers[1] / numbers[0];

        for (int i = 1; i < numbers.Count - 1; i++)
        {
            if (Math.Abs(numbers[i]) <= Epsilon)
            {
                if (Math.Abs(numbers[i + 1]) > Epsilon)
                {
                    return false;
                }

                continue;
            }

            double currentRatio = numbers[i + 1] / numbers[i];
            if (Math.Abs(currentRatio - ratio) > Epsilon)
            {
                return false;
            }
        }

        return true;
    }
}

