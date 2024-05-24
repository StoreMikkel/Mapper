using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace AntlrCSharp
{
    class Program
    {
        public static void Main(string[] args){
            //Read lines from input text file
            StringBuilder text = new StringBuilder();
            string fileLocation = @"C:\Users\Mikkel\Documents\calcLangTest.txt";
            string[] lines = File.ReadAllLines(fileLocation);
            foreach(var element in lines)
            {
                text.AppendLine(element);
            }
            try{
                AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
                CustomLexer lexer = new CustomLexer(inputStream);
                CommonTokenStream tokenStream = new CommonTokenStream(lexer);
                CustomParser parser = new CustomParser (tokenStream);
                IParseTree tree = parser.input();
                BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
                visitor.Visit(tree);
            }catch (Exception ex)
            {
                if (ex is ParseCanceledException)
                {
                    Console.WriteLine("Parsing was canceled.");
                    Console.WriteLine($"Error occurred while parsing with message: {ex.Message}");
                    Console.WriteLine($"StackTrace: {ex.StackTrace}");
                }
                else
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.WriteLine($"Stack trace: {ex.StackTrace}");
                }
            }
        }  
    }   
}