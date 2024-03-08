﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace AntlrCSharp
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                string input = "";
                StringBuilder text = new StringBuilder();
                Console.WriteLine("Input the calculation.");

                string fileLocation = @"C:\Users\Mikkel\Documents\calcLangTest.txt";
                string[] lines = File.ReadAllLines(fileLocation);
            
                foreach(var element in lines)
                {
                    text.AppendLine(element);
                }

                // to type the EOF character and end the input: use CTRL+D, then press <enter>
                //while ((input = Console.ReadLine()) != "=")
                //{
                //    text.AppendLine(input);
                //}
                
                
                AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
                CalculatorLexer calculatorLexer = new CalculatorLexer(inputStream);
                CommonTokenStream commonTokenStream = new CommonTokenStream(calculatorLexer);
                CalculatorParser calculatorParser = new CalculatorParser(commonTokenStream);

                CalculatorParser.InputContext inputContext = calculatorParser.input();                
                BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();                
                visitor.Visit(inputContext);                
                Console.WriteLine("{0}", visitor.Lines.Count);
                foreach(var line in visitor.Lines)
                {
                    Console.WriteLine("New line");
                    Console.WriteLine("Expression: {0}", line.Result);
                   
                    
                    /*
                    int number1 = int.Parse(line.expression);
                    int number2 = int.Parse(line.Numbers);
                    int result = 0;
                    switch(line.Operators){
                        case "+":
                            result = number1 + number2;
                            break;
                        case "-":
                            result = number1 - number2;
                            break;
                        case "/":
                            result = number1 / number2;
                            break;
                        case "*":
                            result = number1 * number2;
                            break;
                    }
                    Console.WriteLine("Result is: {0}", result);
                    */
                }
                
            }
            catch (Exception ex)
            {                
                Console.WriteLine("Error: " + ex);                
            }
        }
    }
}