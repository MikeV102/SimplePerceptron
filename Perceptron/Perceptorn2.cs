using System;
using System.Collections.Generic;

namespace NAI_2
{
    
    public class Perceptorn2
    {
        List<double> weights = new List<double>();
        private int numberOfInputs;
        private double lr = 0.1d;
        public Perceptorn2(int numberOfInputs)
        {
            this.numberOfInputs = numberOfInputs;
            Random rand = new Random();

            for (int i = 0; i < numberOfInputs; i++)
            {
                weights.Add(rand.Next(-3,3));
            } 
        }

        public int Guess(List<double> inputs)
        {
            double sum = 0;
            for (int i = 0; i < weights.Count; i++)
            {
                sum += inputs[i] * weights[i];
            }
            
            int output = Sign(sum);
            return output;
        }

        public void train(List<double> inputs, int target)
        {
            int guess = Guess(inputs);
            int error = target - guess;

            for (int i = 0; i < weights.Count; i++)
            {
                weights[i] += error * inputs[i] * lr;
            }
        }
        
        int Sign(double n)
        {
            if (n >= 0)
                return 1;
            else
            {
                return -1;
            }
        }
    }
}