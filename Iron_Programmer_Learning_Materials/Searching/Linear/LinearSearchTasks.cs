using System;

namespace Linear
{
    public class LinearSearchTasks
    {
        /// <summary>
        /// Напишите программу, которая определяет, сколько раз встречается заданное число x в данном массиве.
        /// </summary>
        public void Task1()
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var array = new int[n];

            var line = Console.ReadLine();
            var splitString = line.Split(' ');
            for (var i = 0; i < n; i++)
            {
                var number = Convert.ToInt32(splitString[i]);
                array[i] = number;
            }

            var x = Convert.ToInt32(Console.ReadLine());
            var countX = 0;
            for (var i = 0; i < n; i++)
            {
                if (array[i] == x)
                {
                    countX++;
                }
            }

            Console.WriteLine(countX);
        }

        /// <summary>
        /// Напишите программу, которая определяет, встречается ли заданное число x в последовательности чисел.
        /// </summary>
        public void Task2()
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var array = new int[n];

            var line = Console.ReadLine();
            var splitString = line.Split(' ');
            for (var i = 0; i < n; i++)
            {
                var number = Convert.ToInt32(splitString[i]);
                array[i] = number;
            }

            var x = Convert.ToInt32(Console.ReadLine());
            var countX = 0;
            for (var i = 0; i < n; i++)
            {
                if (array[i] == x)
                {
                    countX++;
                }
            }


            Console.WriteLine(countX > 0 ? "YES" : "NO");
        }

        /// <summary>
        /// Напишите программу, которая находит в последовательности элемент, самый близкий по величине к данному числу.
        /// </summary>
        public void Task3()
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var array = new int[n];

            var line = Console.ReadLine();
            var splitString = line.Split(' ');
            for (var i = 0; i < n; i++)
            {
                var number = Convert.ToInt32(splitString[i]);
                array[i] = number;
            }

            var x = Convert.ToInt32(Console.ReadLine());
            var minAbs = 20001;
            var nearElement = 0;
            for (var i = 0; i < n; i++)
            {
                var element = array[i];
                var currentAbs = Math.Abs(element - x);
                if (currentAbs <= minAbs)
                {
                    if (currentAbs == minAbs)
                    {
                        nearElement = Math.Max(nearElement, element);
                    }
                    else
                    {
                        nearElement = element;
                    }

                    minAbs = currentAbs;
                }
            }

            Console.WriteLine(nearElement);
        }
    }
}