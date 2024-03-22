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
        public static void Main(string[] args)
    {
        StringBuilder text = new StringBuilder();
        string fileLocation = @"C:\Users\Mikkel\Documents\calcLangTest.txt";
                string[] lines = File.ReadAllLines(fileLocation);
            
                foreach(var element in lines)
                {
                    text.AppendLine(element);
                }
        AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
        CalculatorLexer lexer = new CalculatorLexer(inputStream);
        CommonTokenStream tokenStream = new CommonTokenStream(lexer);
        CalculatorParser parser = new CalculatorParser(tokenStream);
        IParseTree tree = parser.input();
        Console.WriteLine("h");

        BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
        visitor.Visit(tree);
    }
    }
}