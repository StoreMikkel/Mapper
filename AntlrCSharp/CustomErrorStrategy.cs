using Antlr4.Runtime;
using System;

public class CustomErrorStrategy : BailErrorStrategy
{
    
    public override void ReportError(Parser recognizer, RecognitionException e)
    {

        Console.WriteLine("SYNTAX ERROR at line " + e.OffendingToken.Line + ", column " + e.OffendingToken.Column + ": " + e.Message);

        base.ReportError(recognizer, e);

    }

    public override void Recover(Parser recognizer, RecognitionException e)
    {
        // Customize error recovery logic as needed
        // For example:
        Console.WriteLine($"Recovery from error at line {e.OffendingToken.Line}");

        base.Recover(recognizer, e);
    }

    public override IToken RecoverInline(Parser recognizer)
    {
        // Customize inline error recovery logic as needed
        return base.RecoverInline(recognizer);
    }

    public override void Sync(Parser recognizer)
    {
        // Customize sync error recovery logic as needed
        base.Sync(recognizer);
    }
}
 