using System;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using NUnit.Framework.Interfaces;



public class CustomErrorListener : DefaultErrorStrategy
{
     public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e){
        Console.WriteLine($"Syntax error at line {line}, column {charPositionInLine}: {msg}");
    }
}

