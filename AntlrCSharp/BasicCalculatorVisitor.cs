using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
using AntlrCSharp;
using static CalculatorParser;

namespace AntlrCSharp
{
    public class BasicCalculatorVisitor : CalculatorBaseVisitor<object>
    {
        //List of Lines to visit
        public override object VisitCalculation(CalculatorParser.CalculationContext context)
    {
        object result = Visit(context.expression());
        Console.WriteLine("Result: " + result);
        return result;
    }

    public override object VisitNumber(CalculatorParser.NumberContext context)
    {
        // Assuming your object has appropriate parsing method
        return int.Parse(context.NUMBER().GetText());
    }

    public override object VisitExpression(CalculatorParser.ExpressionContext context)
    {
        return Visit(context.term());
    }

    public override object VisitTerm(CalculatorParser.TermContext context)
    {
        object left = Visit(context.GetChild(0));
        if (context.OPERATOR() != null)
        {
            string op = context.OPERATOR().GetText();
            object right = Visit(context.GetChild(2));
            switch (op)
            {
                case "+":
                    return (dynamic)left + (dynamic)right;
                case "-":
                    return (dynamic)left - (dynamic)right;
                case "*":
                    return (dynamic)left * (dynamic)right;
                case "/":
                    if (Equals(right, default(object)) || right.Equals(0))
                        throw new DivideByZeroException();
                    return (dynamic)left / (dynamic)right;
            }
        }
        return left;
    }
    }

}
