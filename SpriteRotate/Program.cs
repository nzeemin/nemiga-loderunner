using System;
using System.Collections.Generic;
using System.Globalization;

namespace SpriteRotate
{
	class Program
	{
		static string ConvertOneNumber(string inputStr)
		{
			int input = Convert.ToInt32(inputStr, 8);
		    int input1 = input & 0xff;
		    int input2 = input >> 8;
			int output = 0;
			for (int i = 0; i < 4; i++)
			{
                output = output << 1;
                output |= ((input1 & 1));
                output |= ((input2 & 1) << 8);
                output = output << 1;
				output |= ((input1 & 1));
				output |= ((input2 & 1) << 8);
                input1 = input1 >> 1;
                input2 = input2 >> 1;
            }
            string a0 = Convert.ToString(output, 2);
            while (a0.Length < 16) a0 = "0" + a0;
            System.Console.Out.Write(a0.Replace('0', '.'));
            string a = Convert.ToString(output, 8);
            while (a.Length < 6) a = "0" + a;
            output = 0;
            for (int i = 4; i < 8; i++)
            {
                output = output << 1;
                output |= ((input1 & 1));
                output |= ((input2 & 1) << 8);
                output = output << 1;
                output |= ((input1 & 1));
                output |= ((input2 & 1) << 8);
                input1 = input1 >> 1;
                input2 = input2 >> 1;
            }
            string b0 = Convert.ToString(output, 2);
            while (b0.Length < 16) b0 = "0" + b0;
            System.Console.Out.WriteLine(b0.Replace('0', '.'));
            string b = Convert.ToString(output, 8);
            while (b.Length < 6) b = "0" + b;

		    return string.Concat(a, ",", b);
		}

		[STAThread]
		static void Main(string[] args)
		{
			while(true)
			{
				string input = System.Console.In.ReadLine();
				string[] inputs = input.Split(',');
                string[] outputs = new string[5];

                for (int index = 0; index < 5; index++)
				{
					string inputStr = inputs[index];
					string outputStr = ConvertOneNumber(inputStr);
                    outputs[index] = outputStr;
                }
                string output1 = string.Join(",", outputs);

                for (int index = 0; index < 5; index++)
                {
                    string inputStr = inputs[index + 5];
                    string outputStr = ConvertOneNumber(inputStr);
                    outputs[index] = outputStr;
                }
                string output2 = string.Join(",", outputs);

                System.Console.Out.Write("\t.WORD\t");
                System.Console.Out.WriteLine(output1);
                System.Console.Out.Write("\t.WORD\t");
                System.Console.Out.WriteLine(output2);

            }
		}
	}
}
