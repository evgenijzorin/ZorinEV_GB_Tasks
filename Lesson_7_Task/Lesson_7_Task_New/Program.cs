// Decompiled with JetBrains decompiler
// Type: Lesson_7_Task.Program
// Assembly: Lesson_7_Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B4A53922-6DCF-4DB4-8FBF-1EE7105CD20E
// Assembly location: C:\Users\Евгений Заря\Desktop\GB_Tasks\Lesson_7_Task\Lesson_7_Task\Lesson_7_Task\bin\Release\net5.0\Lesson_7_Task.dll

using System;

namespace Lesson_7_Task
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine("Программа вычислит расстояние между двумя точками по координатам.");
      Console.WriteLine("Введите координаты первой точки x y, разделитель - пробел, десятичный разделитель ',' ");
      string str1 = Console.ReadLine();
      Console.WriteLine("Введите координаты второй точки x y:");
      string str2 = Console.ReadLine();
      string[] strArray1 = str1.Split(' ');
      double num1 = Convert.ToDouble(strArray1[0]);
      double num2 = Convert.ToDouble(strArray1[1]);
      string[] strArray2 = str2.Split(' ');
      double num3 = Convert.ToDouble(strArray2[0]);
      double num4 = Convert.ToDouble(strArray2[1]);
      double num5 = Math.Sqrt(Math.Pow(num3 - num1, 2.0) + Math.Pow(num4 - num2, 2.0));
      Console.WriteLine(string.Format("расстояние между точками a[{0}, {1}] и b[{2}, {3}] = [{4}]", (object) num1, (object) num2, (object) num3, (object) num4, (object) num5));;
    }
  }
}
