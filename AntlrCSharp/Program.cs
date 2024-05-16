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

         StringBuilder text = new StringBuilder();
         string fileLocation = @"C:\Users\ajapo\Desktop\yeppers.txt";
         string[] lines = File.ReadAllLines(fileLocation);
         foreach(var element in lines)
             {
                text.AppendLine(element);
             }
        
        try{
            AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
            CustomLexer lexer = new CustomLexer(inputStream);
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            CustomParser parser = new CustomParser(tokenStream);

            IParseTree tree = parser.input();

        /*tokenStream.Fill();
            foreach (var token in tokenStream.GetTokens())
            {
                Console.WriteLine($"Token Type: {token.Type}, Text: {token.Text}, Start Index: {token.StartIndex}, Stop Index: {token.StopIndex}");
            }*/
        
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(tree);
        }catch (Exception ex)
            {
                if (ex is ParseCanceledException)
                {
                    
                     Console.WriteLine("Parsing was canceled." + ex.Message);
                
                }
                else
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        
        }
    
    }

    
}