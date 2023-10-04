using System.IO;

namespace QuizzGame;

class Program
{
    static void Main(string[] args)
    {
        /* Reads the file line by line */

        // string[] text = File.ReadAllLines("questions.txt");
        // for (int i = 0; i < text.Length; i++)
        // {
        //     Console.WriteLine(text[i]);
        // }

        string[] text = File.ReadAllLines("questions.txt");
        List<string> questions = new List<string>();
        List<string> answers = new List<string>();

        // Parse into text file and loop through it and store in Lists according to line number, where all questions are on the lines that are multiples of 4 
        for (int i = 0; i < text.Length; i++)
        {
            if (i % 4 == 0)
                questions.Add(text[i]);
            else
                answers.Add(text[i]);
        }

        int questionIndex = 0;
        int answerIndex = 0;
        int score = 0;

        // Loop runs until you run out of questions
        while (questionIndex < questions.Count)
        {
            Console.WriteLine(questions[questionIndex]);
            questionIndex++;

            int correctAnswer = 0;

            for (int i = 0; i < 3; i++)
            {
                if (answers[answerIndex].StartsWith(">"))
                    correctAnswer = i + 1;
                Console.WriteLine(i + 1 + "." + answers[answerIndex].Replace(">", ""));
                answerIndex++;
            }

            int answer = int.Parse(Console.ReadLine());

            if (answer == correctAnswer)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }
        }

        Console.WriteLine("End of quizz! Your score is " + score + " points!");
        Console.ReadKey();
    }
}
