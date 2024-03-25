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
        private Dictionary<string, object> variables = new Dictionary<string, object>();

    public override object VisitInput(CalculatorParser.InputContext context)
    {
        return VisitChildren(context);
    }

    public override object VisitCalculation(CalculatorParser.CalculationContext context)
    {
        object result = Visit(context.expression());
        Console.WriteLine("Result: " + result);
        return result;
    }

    public override object VisitExpression(CalculatorParser.ExpressionContext context)
{
    if (context.OPERATOR1() != null)
    {
        object left = Visit(context.expression());
        object right = Visit(context.term());
        if (left == null || right == null)
            throw new InvalidOperationException("Invalid expression: sub-expression is null.");

        string op = context.OPERATOR1().GetText();
        if (op == "+") return (int)left + (int)right;
        else if (op == "-") return (int)left - (int)right;
    }
    else if (context.COMPARISON_OPERATOR() != null)
    {
        object left = Visit(context.expression());
        object right = Visit(context.term());
        if (left == null || right == null)
            throw new InvalidOperationException("Invalid expression: sub-expression is null.");

        string op = context.COMPARISON_OPERATOR().GetText();
        switch (op)
        {
            case ">": return (int)left > (int)right;
            case "<": return (int)left < (int)right;
            case "==": return (int)left == (int)right;
            case "!=": return (int)left != (int)right;
            case ">=": return (int)left >= (int)right;
            case "<=": return (int)left <= (int)right;
            default:
                throw new InvalidOperationException("Invalid comparison operator: " + op);
        }
    }
    return Visit(context.term());
}

    public override object VisitTerm(CalculatorParser.TermContext context)
    {
        if (context.OPERATOR2() != null)
        {
            object left = Visit(context.term());
            object right = Visit(context.factor());
            string op = context.OPERATOR2().GetText();
            if (op == "*") return (int)left * (int)right;
            else if (op == "/") return (int)left / (int)right;
        }
        return Visit(context.factor());
    }

    public override object VisitFactor(CalculatorParser.FactorContext context)
    {
        if (context.number() != null)
        {
            return int.Parse(context.number().GetText());
        }
        else
        {
            return Visit(context.expression());
        }
    }

    public override object VisitIfStatement(CalculatorParser.IfStatementContext context)
{
    bool conditionValue = (bool)Visit(context.GetChild(2)); // Assuming the condition is the third child
    if (conditionValue)
    {
        return Visit(context.statement(0)); // Visit the 'if' block
    }
    else if (context.ChildCount > 4) // Check if 'else' block exists
    {
        return Visit(context.statement(1)); // Visit the 'else' block
    }
    return null; // No 'else' block and condition evaluates to false
}

    public override object VisitWhileStatement(CalculatorParser.WhileStatementContext context)
{
    object result = null;
    while ((int)Visit(context.condition()) != 0)
    {
        foreach (var statement in context.statement())
        {
            result = Visit(statement);
            if (result != null) // Assuming null means "break" or "return" in this context
                return result;
        }
    }
    return result;
}

    public override object VisitNumber(CalculatorParser.NumberContext context)
    {
        return int.Parse(context.NUMBER().GetText());
    }

}
}

