using System;
using System.Collections.Generic;
using System.IO;

namespace NAI_2
{
    public class MainProgram
    {
        private static string path = @"iris_training.txt";
        private static string path2 = @"iris_test.txt";

        public static void Main(string[] args)
        {
            Perceptorn2 perceptorn2 = new Perceptorn2(4);

            List<TestExample2> training = new List<TestExample2>();
            List<TestExample2> testing = new List<TestExample2>();

            DataReader reader = new DataReader();
            reader.ReadData(new FileInfo(path), training);
            reader.ReadData(new FileInfo(path2), testing);

            int count = 0;
            double precision = 0;
            double correctlyClassified = 0;

            while (precision < 1)
            {
                correctlyClassified = 0;
                count = 0;
                foreach (TestExample2 testExample2 in training)
                {
                    perceptorn2.train(testExample2.ExampleList, testExample2.Result);
                }

                foreach (var testExample2 in testing)
                {
                    int guess = perceptorn2.Guess(testExample2.ExampleList);

                    if (guess == testExample2.Result)
                    {

                        correctlyClassified++;
                        count++;
                    }
                    else
                    {

                        count++;
                    }
                }

                precision = (correctlyClassified / count);
            }

            Console.WriteLine("number of correctly classified samples: " + correctlyClassified + " out of 30");
            Console.WriteLine($"percentage correctness: { precision * 100}%");


            while (true)
            {
                Console.WriteLine("type \"finish\" to finish or \"example\" to give another example");
                string userInput = Console.ReadLine();
                if ("finish".Equals(userInput))
                {
                    break;
                }
                else if ("example".Equals(userInput))
                {


                    List<double> userInputList = new List<double>();

                    for (int i = 0; i < 4; i++)
                    {
                        Console.WriteLine($"input coefficient number: {i + 1} as a double example(2,5 or 0,3)");
                        userInputList.Add(Double.Parse(Console.ReadLine()));
                    }

                    int guess = perceptorn2.Guess(userInputList);
                    if (guess == 1)
                    {
                        Console.WriteLine("Iris-Setosa");
                    }
                    else
                    {
                        Console.WriteLine("Not Iris-Setosa");
                    }
                }
                else
                {
                    Console.WriteLine("wrong input, try again...");
                }

            }

        }
    }
}
