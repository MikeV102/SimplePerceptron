using System;
using System.Collections.Generic;
using System.IO;

namespace NAI_2
{
    public class DataReader
    {
        public void ReadData(FileInfo fileInfo, List<TestExample2> list)
        {
            using (var streamTraining = new StreamReader(fileInfo.OpenRead())) //TODO: reading file
            {
                string trainingLine = null;    
                while ((trainingLine = streamTraining.ReadLine()) != null)
                {
                    //TODO: handling document spacing
                    string[] trainingColumns = trainingLine.Split("   \t", StringSplitOptions.RemoveEmptyEntries);
                    TestExample2 example = new TestExample2();
                    for (int i = 0; i < trainingColumns.Length - 1; i++)
                    {
                        example.ExampleList.Add(Double.Parse(trainingColumns[i]));
                    }

                   if("Iris-setosa".Equals(trainingColumns[trainingColumns.Length - 1].Trim()))
                   {
                       example.Result = 1;
                   }
                   else
                   {
                       example.Result = -1;
                   }

                    list.Add(example);
                }
            }
        }
    }
}