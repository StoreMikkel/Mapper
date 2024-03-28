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
        if (op == "+") return (dynamic)left + (dynamic)right;
        else if (op == "-") return (dynamic)left - (dynamic)right;
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
            case ">": return (dynamic)left > (dynamic)right;
            case "<": return (dynamic)left < (dynamic)right;
            case "==": return (dynamic)left == (dynamic)right;
            case "!=": return (dynamic)left != (dynamic)right;
            case ">=": return (dynamic)left >= (dynamic)right;
            case "<=": return (dynamic)left <= (dynamic)right;
            default:
                throw new InvalidOperationException("Invalid comparison operator: " + op);
        }
    }
    else if(context.BOOLEAN_LITERAL() != null){
        return bool.Parse(context.BOOLEAN_LITERAL().GetText());
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
            if (op == "*") return (dynamic)left * (dynamic)right;
            else if (op == "/") return (dynamic)left / (dynamic)right;
        }
        else if(context.BOOLEAN_LITERAL() != null){
        return bool.Parse(context.BOOLEAN_LITERAL().GetText());
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
        else if(context.BOOLEAN_LITERAL() != null){
            return bool.Parse(context.BOOLEAN_LITERAL().GetText());
        }
        if (context.number() != null)
        {
            return Visit(context.number());
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
    else if (context.ELSE() != null) // Check if 'else' block exists
    {
        return Visit(context.statement(1)); // Visit the 'else' block
    }
    return null; // No 'else' block and condition evaluates to false
}

    public override object VisitWhileStatement(CalculatorParser.WhileStatementContext context)
{
    object result = null;
    while ((dynamic)Visit(context.condition()) != 0)
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

        if(value is int && context.TYPE().GetText() == "double " ){
            value = (double)(int)value;
        }

        else if(value is double && context.TYPE().GetText() != "double ") {
            throw new Exception("Type mismatch in variable declaration, value is double, declarations is " + context.TYPE().GetText());
        }else if (value is int && context.TYPE().GetText() != "int "){
            throw new Exception ("Type mismatch in variable declaration, value is int, declarations is " + context.TYPE().GetText());
        }else if (value is string && context.TYPE().GetText() != "string "){
            throw new Exception ("Type mismatch in variable declaration, value is string, declarations is " + context.TYPE().GetText());
        }else if (value is Boolean && context.TYPE().GetText() != "boolean "){
            throw new Exception ("Type mismatch in variable declaration, value is boolean, declarations is " + context.TYPE().GetText());
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

        variables[identifier] = value;
        return value;
    }

    public override object VisitNumber(CalculatorParser.NumberContext context)
    {
        string numberText = context.NUMBER().GetText();

        if(int.TryParse(numberText, out int intValue)){
            return intValue;
        }
        if(double.TryParse(numberText, out double doublevalue)){
            return doublevalue;
        }
        return 0;
    }

    public override object VisitCrementer(CalculatorParser.CrementerContext context){
        
        string identifier = context.IDENTIFIER().GetText();
        int currentValue = Convert.ToInt32(variables[identifier]);
       
        if (context.INCREMENTER() != null)
        {
            currentValue++;
            variables[identifier] = currentValue;
        }
        else if (context.DECREMENTER() != null)
        {
            currentValue--;
            variables[identifier] = currentValue;
        }
        return currentValue;
    }

    public override object VisitForLoop(CalculatorParser.ForLoopContext context){

       
        Visit(context.children[2]);
        while ((bool)Visit(context.compare())){
            // Visit the statements inside the for loop
            foreach (var statement in context.statement())
            {
                Visit(statement);
            }
            // Visit the increment/decrement part of the for loop
            Visit(context.crementer());
        }
        return null;
    }

    public override object VisitCompare(CalculatorParser.CompareContext context){
        
        if (context.COMPARISON_OPERATOR() != null)
        {
            object left = Visit(context.expression());
            object right = Visit(context.term());
            if (left == null || right == null)
                throw new InvalidOperationException("Invalid expression: sub-expression is null.");

            string op = context.COMPARISON_OPERATOR().GetText();
            switch (op)
            {
                case ">": return (dynamic)left > (dynamic)right;
                case "<": return (dynamic)left < (dynamic)right;
                case "==": return (dynamic)left == (dynamic)right;
                case "!=": return (dynamic)left != (dynamic)right;
                case ">=": return (dynamic)left >= (dynamic)right;
                case "<=": return (dynamic)left <= (dynamic)right;
                default:
                    throw new InvalidOperationException("Invalid comparison operator: " + op);
            }
        }
        return 0;
    }
    

}
}

