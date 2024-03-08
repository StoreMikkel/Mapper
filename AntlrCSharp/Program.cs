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
        string input =  "1 + 2 + 3 + 3 + 1 + 2 + 2 + 2\n" +
                        "4 / 2 - 1\n"; // Example input with multiple calculations
        AntlrInputStream inputStream = new AntlrInputStream(input);
        CalculatorLexer lexer = new CalculatorLexer(inputStream);
        CommonTokenStream tokenStream = new CommonTokenStream(lexer);
        CalculatorParser parser = new CalculatorParser(tokenStream);
        IParseTree tree = parser.input();

        BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
        visitor.Visit(tree);
    }
    }
}