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

         /*StringBuilder text = new StringBuilder();
         string fileLocation = @"C:\Users\ajapo\Desktop\yeppers.txt";
         string[] lines = File.ReadAllLines(fileLocation);
         foreach(var element in lines)
             {
                text.AppendLine(element);
             }*/

    
        string input =  "(1 + 2 + 3 + 3 + 1 + 2 + 2 + 2)*2\n" + "(5 + 5) * 10\n" +
         "var a = 5*5\n     var b = a + 5\n     var c = a*b\n   c\n"; // Example input with multiple calculations

        //string input2 = "var a = 5\n var b = 3\n" + "if (a > b) { a - 1 \n} else{4+6\n}";

        AntlrInputStream inputStream = new AntlrInputStream(input);
        CalculatorLexer lexer = new CalculatorLexer(inputStream);
        CommonTokenStream tokenStream = new CommonTokenStream(lexer);
        CalculatorParser parser = new CalculatorParser(tokenStream);
        IParseTree tree = parser.input();
        Console.WriteLine("h");

        BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
        visitor.Visit(tree);

        



        /*string input = "if (6 > 5) {6 + 1\n} else { 6 - 1\n}";

        var inputStream = new AntlrInputStream(input);
        var lexer = new CalculatorLexer(inputStream);
        var tokenStream = new CommonTokenStream(lexer);
        var parser = new CalculatorParser(tokenStream);
        var tree = parser.input();

        var visitor = new YourLanguageToCSharpVisitor();
        var result = visitor.Visit(tree);
        Console.WriteLine(result);

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        // Specify the output file name and path on the desktop
        string outputFile = Path.Combine(desktopPath, "output.cs");

        // Write the transpiled C# code to the file
        File.WriteAllText(outputFile, result);

        Console.WriteLine("Transpilation completed. Output saved to: " + outputFile);*/

        }
    
    }

    
}