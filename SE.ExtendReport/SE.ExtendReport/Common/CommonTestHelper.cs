using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SE.ExtendReport.Common
{
    public class CommonTestHelper
    {
        public static List<string> GetTestData(string fileName)
        {
            var methodName = MethodBase.GetCurrentMethod();
            var abc = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            abc += "\\" + fileName;
            string[] files = Directory.GetFiles(abc, "*.txt", SearchOption.AllDirectories);
            return ReadTextFile(files[0]);
        }


        public static List<string> ReadTextFile(String fileName)
        {
            List<string> inputs = new List<string>();
            try
            {
                using (StreamReader reader = File.OpenText(fileName))
                {
                    string line;
                    // Read and display lines from the file until the end of  
                    // the file is reached. 
                    while ((line = reader.ReadLine()) != null)
                    {
                        //Append each line to the String Builder
                        inputs.Add(line);
                    }
                }
                return inputs;
            }
            catch (Exception e)
            {
                // Display information about what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return null;
        }

    }
}
