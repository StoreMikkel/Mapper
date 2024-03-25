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
        if (context.IDENTIFIER() != null)
            {
                string identifier = context.IDENTIFIER().GetText();
                if (variables.ContainsKey(identifier))
                {
                    return variables[identifier];
                }
                else
                {
                    throw new Exception("Variable " + identifier + " not defined.");
                }
            }else if (context.STRING_LITERAL() != null)
        {
            return context.STRING_LITERAL().GetText(); // Return the string literal
        }

    if (context.OPERATOR1() != null)
    {
        object left = Visit(context.expression());
        object right = Visit(context.term());
        if (left == null || right == null)
            throw new InvalidOperationException("Invalid expression: sub-expression is null.");

        string op = context.OPERATOR1().GetText();
        if (op == "+") return (double)left + (double)right;
        else if (op == "-") return (double)left - (double)right;
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
            case ">": return (double)left > (double)right;
            case "<": return (double)left < (double)right;
            case "==": return (double)left == (double)right;
            case "!=": return (double)left != (double)right;
            case ">=": return (double)left >= (double)right;
            case "<=": return (double)left <= (double)right;
            default:
                throw new InvalidOperationException("Invalid comparison operator: " + op);
        }
    }
    return Visit(context.term());
}

    public override object VisitTerm(CalculatorParser.TermContext context)
    {
        if (context.IDENTIFIER() != null)
            {
                string identifier = context.IDENTIFIER().GetText();
                if (variables.ContainsKey(identifier))
                {
                    return variables[identifier];
                }
                else
                {
                    throw new Exception("Variable " + identifier + " not defined.");
                }
            }else if (context.STRING_LITERAL() != null)
        {
            return context.STRING_LITERAL().GetText(); // Return the string literal
        }

        if (context.OPERATOR2() != null)
        {
            object left = Visit(context.term());
            object right = Visit(context.factor());
            string op = context.OPERATOR2().GetText();
            if (op == "*") return (double)left * (double)right;
            else if (op == "/") return (double)left / (double)right;
        }
        return Visit(context.factor());
    }

    public override object VisitFactor(CalculatorParser.FactorContext context)
    {
        if (context.IDENTIFIER() != null)
            {
                string identifier = context.IDENTIFIER().GetText();
                if (variables.ContainsKey(identifier))
                {
                    return variables[identifier];
                }
                else
                {
                    throw new Exception("Variable " + identifier + " not defined.");
                }
            }else if (context.STRING_LITERAL() != null)
        {
            return context.STRING_LITERAL().GetText(); // Return the string literal
        }
        if (context.number() != null)
        {
            return double.Parse(context.number().GetText());
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
    while ((double)Visit(context.condition()) != 0)
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

public override object VisitVariableDeclaration(CalculatorParser.VariableDeclarationContext context)
    {
        string identifier = context.IDENTIFIER().GetText();
        object value = Visit(context.expression());

        // Add type checking for variable declaration
        if (value is double && context.TYPE().GetText() == "int ")
        { // If the declared type is int but the value is double, convert it to int
            value = (int)(double)value;
        }else if(value is double && context.TYPE().GetText()=="string " || value is int && context.TYPE().GetText()=="string "){
            throw new Exception ("Type mismatch in variable declaration, value is double/int, declarations is string: " + identifier);
        }else if(value is string && context.TYPE().GetText()=="int " || value is string && context.TYPE().GetText()=="double "){
            throw new Exception ("Type mismatch in variable declaration, value is string, declarations is int/double: " + identifier);
        }

        variables[identifier] = value;
        return value;
    }

        public override object VisitVariableAssignment(CalculatorParser.VariableAssignmentContext context)
    {
        string identifier = context.IDENTIFIER().GetText();
        object value = Visit(context.expression());

        // Add type checking for variable assignment
        if (value is double && variables[identifier] is int)
        {
            // If the assigned value is double but the variable type is int, convert it to int
            variables[identifier] = (int)(double)value;
        }
        else if (value is int && variables[identifier] is double)
        {
            // If the assigned value is int but the variable type is double, convert it to double
            variables[identifier] = (double)(int)value;
        }
        else if (value.GetType() != variables[identifier].GetType())
        {
            // If the assigned value and variable type do not match, throw an exception
            throw new Exception("Type mismatch in variable assignment for variable " + identifier);
        }

        return value;
    }

    public override object VisitNumber(CalculatorParser.NumberContext context)
    {
        return double.Parse(context.NUMBER().GetText());
    }

}
}

