using System;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

public class CustomErrorListener : BaseErrorListener, IAntlrErrorListener<int>
{
    public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
    {
        // Print error message
        output.WriteLine($"SYNTAX ERROR at line {line}, column {charPositionInLine}: {msg}");
        
        // Throw an exception
        throw new InputMismatchException((Parser)recognizer);
    }
}