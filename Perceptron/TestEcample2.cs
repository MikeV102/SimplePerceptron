using System;
using System.Collections.Generic;

namespace NAI_2
{
    public class TestExample2
    {
        public TestExample2()
        {
        }

        public TestExample2(List<double> exampleList , string result)
        {
            this.ExampleList = exampleList ?? throw new ArgumentNullException(nameof(exampleList));
            if ("Iris-setosa".Equals(result))
            {
                this.Result = 1;
            }
            else
            {
                this.Result = -1;
            }
        }

        public List<double> ExampleList  = new List<double>();
        public int Result { get; set; }

        public override string ToString()
        {
            string returned = "";
            foreach (var example in ExampleList)
            {
                returned = returned + " " + example;
            }

            returned = returned + " result " + Result;

            return returned;
        }
    }
    
    
}