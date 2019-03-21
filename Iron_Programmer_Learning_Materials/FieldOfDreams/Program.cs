using System;

namespace FieldOfDreams
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberAttempts = 0;
            var word = MakeWord(); // загадали слово
            var template = CreateTemplate(word); // создали шаблон

            while (numberAttempts < 10 && !GuessWord(template))
            {
                Console.WriteLine(template);
                var letter = Convert.ToChar(Console.ReadLine()); // вводим букву
                if (IsLetterInWord(word, letter)) // если буква есть в слове 
                {
                    template = ChangeTemplate(letter, word, template); // изменить шаблон
                }
                else
                {
                    numberAttempts++; // увеличили кол-во попыток
                }
            }

            if (numberAttempts == 10)
            {
                Console.WriteLine("Вы превысили кол-во попыток!");
            }
            else
            {
                Console.WriteLine("Молодец! Вы угадали!");
            }
        }

        static bool GuessWord(string template)
        {
            for (int i = 0; i < template.Length; i++)
            {
                if (template[i] == '*')
                {
                    return false;
                }
            }

            return true;
        }

        static string ChangeTemplate(char letter, string word, string template)
        {
            var changedTemplate = "";
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == letter)
                {
                    changedTemplate = changedTemplate + letter;
                }
                else
                {
                    changedTemplate = changedTemplate + template[i];
                }
            }

            return changedTemplate;
        }

        static bool IsLetterInWord(string word, char letter)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (letter == word[i])
                {
                    return true;
                }
            }

            return false;
        }

        static string CreateTemplate(string word)
        {
            var template = "";
            for (int i = 0; i < word.Length; i++)
            {
                template = template + '*';
            }

            return template;
        }

        static string MakeWord()
        {
            return "Февраль";
        }
    }
}
