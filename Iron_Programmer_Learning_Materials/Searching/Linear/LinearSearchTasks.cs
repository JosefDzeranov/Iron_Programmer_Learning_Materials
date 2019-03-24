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

        /// <summary>
        /// номер максимального элемента в массиве. Если в массиве несколько максимальных элементов, выведите максимальный номер.
        /// </summary>
        public void Task4()
        {
            string line = Console.ReadLine();
            string[] splits = line.Split(' ');
            int max = 0;
            int indexMax = 0;
            for (int index = 0; index < splits.Length; index++)
            {
                int element = Convert.ToInt32(splits[index]);
                if (element >= max)
                {
                    max = element;
                    indexMax = index;
                }
            }

            Console.WriteLine(indexMax);
        }

        /// <summary>
        /// Напишите программу, которая выводит номера элементов последовательности, равных данному числу.
        /// </summary>
        public void Task5()
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var line = Console.ReadLine();
            var splitString = line.Split(' ');
            var x = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var number = Convert.ToInt32(splitString[i]);
                if (number == x)
                {
                    Console.Write(i + 1 + " ");
                }
            }
        }

        /// <summary>
        /// Напишите программу, которая выводит номер элемента последовательности, равный данному числу. 
        /// Если таких элементов несколько, выведите номер первого из них. 
        /// </summary>
        public void Task6()
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var line = Console.ReadLine();
            var splitString = line.Split(' ');
            var x = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var number = Convert.ToInt32(splitString[i]);
                if (number == x)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }

        /// <summary>
        /// Напишите программу, которая выводит номер элемента последовательности, равный данному числу. 
        /// Если таких элементов несколько, выведите номер последнего из них. 
        /// </summary>
        public void Task7()
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var line = Console.ReadLine();
            var splitString = line.Split(' ');
            var x = Convert.ToInt32(Console.ReadLine());

            for (var i = n - 1; i >= 0; i--)
            {
                var number = Convert.ToInt32(splitString[i]);
                if (number == x)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }

        /// <summary>
        /// Школьник Витя получил доступ к онлайн журналу на ДНЕВНИК.РУ и хочет заменить все свои минимальные оценки на максимальные. 
        /// Помогите Вите, напишите программу, которая заменяет его минимальные оценки на максимальные.
        /// </summary>
        public void Task8()
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var line = Console.ReadLine();
            var array = GetIntArray(line);

            var max = 2;
            var min = 5;
            for (int i = 0; i < n; i++)
            {
                var number = array[i];
                if (number > max)
                {
                    max = number;
                }
                if (number < min)
                {
                    min = number;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (array[i] == min)
                {
                    array[i] = max;
                }
            }

            Print(array);
        }

        private int[] GetIntArray(string line)
        {
            var splitString = line.Split(' ');
            int length = splitString.Length;
            var array = new int[length];

            for (var i = 0; i < length; i++)
            {
                var number = Convert.ToInt32(splitString[i]);
                array[i] = number;
            }

            return array;
        }

        private void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}