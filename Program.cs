using System;

public class Imaginary_number
{
    public double actual_part;
    public double imaginary_part;

    public Imaginary_number()
    {
        actual_part = 0;
        imaginary_part = 0;
    }

    public Imaginary_number(double actual_part, double imaginary_part)
    {
        this.actual_part = actual_part;
        this.imaginary_part = imaginary_part;
    }

    public void Show_Imaginary_number()
    {
        Console.Write($"{actual_part} ");
        if (imaginary_part >= 0)
            Console.Write("+ ");
        Console.WriteLine($"{imaginary_part}i");
    }

    public static Imaginary_number operator + (Imaginary_number a, Imaginary_number b)
    {
        return new Imaginary_number (a.actual_part + b.actual_part, a.imaginary_part + b.imaginary_part);
    }

    public static Imaginary_number operator - (Imaginary_number a, Imaginary_number b)
    {
        return new Imaginary_number(a.actual_part - b.actual_part, a.imaginary_part - b.imaginary_part);
    }
    public static Imaginary_number operator * (Imaginary_number a, Imaginary_number b)
    {
        return new Imaginary_number(a.actual_part * b.actual_part - a.imaginary_part * b.imaginary_part, 
            a.actual_part *  b.imaginary_part + a.imaginary_part * b.actual_part);
    }


    




}
public static class Program
{
    public static Imaginary_number Pow(Imaginary_number a, double pow)
    {
        double module = Math.Sqrt(Math.Pow(a.actual_part, 2) + Math.Pow(a.imaginary_part, 2));
        double corner = Math.Atan(a.imaginary_part / a.actual_part);
        return new Imaginary_number(Math.Pow(module, pow) * Math.Cos(corner * pow), (Math.Pow(module, pow) * Math.Sin(corner * pow)));
    }

    public static Imaginary_number Ask_Imaginary_number()
    {
        Console.WriteLine("Введите коэффициенты мнимого числа:");
        string[] str = (Console.ReadLine() ?? "").Split();
        return new Imaginary_number(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]));
    }
    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Выберите дейстиие:");
            Console.WriteLine("1 - Выполнить сложение двух чисел");
            Console.WriteLine("2 - Выполнить вычитание двух чисел");
            Console.WriteLine("3 - Выполнить умножение двух чисел ");
            Console.WriteLine("4 - Возвести число в степень");
            Console.WriteLine("5 - Выход");

            int choise = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choise)
            {
                case 1:
                    Imaginary_number num1 = Ask_Imaginary_number();
                    Imaginary_number num2 = Ask_Imaginary_number();
                    (num1 + num2).Show_Imaginary_number();
                    break;
                case 2:
                    Imaginary_number num3 = Ask_Imaginary_number();
                    Imaginary_number num4 = Ask_Imaginary_number();
                    (num3 - num4).Show_Imaginary_number();
                    break;
                case 3:
                    Imaginary_number num5 = Ask_Imaginary_number();
                    Imaginary_number num6 = Ask_Imaginary_number();
                    (num5 * num6).Show_Imaginary_number();
                    break;
                case 4:
                    Imaginary_number num7 = Ask_Imaginary_number();
                    Console.WriteLine("Введите степень");
                    Pow(num7, Convert.ToInt32(Console.ReadLine())).Show_Imaginary_number();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;

            }
            Console.ReadKey();
        }
    }
}