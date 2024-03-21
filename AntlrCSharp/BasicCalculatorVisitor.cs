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
        object left = Visit(context.term()); // Default to empty string if null
        if (context.OPERATOR1() != null)
        {
            string op = context.OPERATOR1().GetText();
            object right = Visit(context.expression()); // Pass the correct number of arguments to term
            // Perform operation based on the operator
            switch (op)
            {
                case "+":
                    return (dynamic)left + (dynamic)right;
                case "-":
                    return (dynamic)left - (dynamic)right;
            }
        }
        return left;
    }

    public override object VisitTerm(CalculatorParser.TermContext context)
    {
        object left = Visit(context.factor());
        if (context.OPERATOR2() != null)
        {
            string op = context.OPERATOR2().GetText();
            object right = Visit(context.term()); // Pass the correct number of arguments to factor
            // Perform operation based on the operator
            switch (op)
            {
                case "*":
                    return (dynamic)left * (dynamic)right;
                case "/":
                    return (dynamic)left / (dynamic)right;
            }
        }
        return left;
    }
    public override object VisitFactor(CalculatorParser.FactorContext context)
    {
        if (context.number() != null)
        {
            return Visit(context.number());
        }
        else if (context.expression() != null)
        {
            return Visit(context.expression());
        }
        else
        {
            // Handle other cases (e.g., unary operators)
            return null;
        }
    }

}
}

