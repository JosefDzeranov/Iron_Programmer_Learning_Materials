using System;

namespace IdiotGenius
{
    class Program
    {
        static void Main(string[] args)
        {
            int countQuestions = 5;
            string[] questions = new string[countQuestions];
            questions[0] = "Сколько будет два плюс два  умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10  частей, сколько надо сделать  распилов?";
            questions[2] = "На двух руках 10 пальцев сколько пальцев на 5 руках ?";
            questions[3] = "Укол делают каждые полчаса,  сколько нужно минут для трех  уколов?";
            questions[4] = "Пять свечей горело, две  потухли. Сколько свечей  осталось?";

            int[] answers = new int[countQuestions];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;

            int numberCorrectAnswers = 0;

            for (int question = 0; question < countQuestions; question++)
            {
                Console.WriteLine("Вопрос №" + (question + 1));
                Console.WriteLine(questions[question]);
                int userAnswer = Convert.ToInt32(Console.ReadLine());
                if (userAnswer == answers[question])
                {
                    numberCorrectAnswers++;
                }
            }

            Console.WriteLine("Количество правильных ответов: " + numberCorrectAnswers);
            string[] diagnoses = new string[countQuestions + 1];
            diagnoses[0] = "Идиот";
            diagnoses[1] = "Кретин";
            diagnoses[2] = "Дурак";
            diagnoses[3] = "Нормальный";
            diagnoses[4] = "Талант";
            diagnoses[5] = "Гений";

            Console.WriteLine("Ваш диагноз: " + diagnoses[numberCorrectAnswers]);
        }
    }
}
