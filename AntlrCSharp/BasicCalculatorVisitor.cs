using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using AntlrCSharp;
using static CalculatorParser;

namespace AntlrCSharp
{
    public class BasicCalculatorVisitor : CalculatorBaseVisitor<object>
    {
        Hashtable symbol_table = new Hashtable();
        //List of Lines to visit
        public override object VisitCalculation(CalculatorParser.CalculationContext context)
        {
            object result = Visit(context.expression());
            Console.WriteLine("Result: " + result);
            return result;
        }

        public override object VisitIfStatement(IfStatementContext context)
        {
            object condition = Visit(context.condition());
            if((dynamic)condition == true){
                return Visit(context.statement(0));
            }else if(context.ELSE() != null){
                return Visit(context.statement(1));
            }
            return 0;
        }

        public override object VisitCondition(CalculatorParser.ConditionContext context)
        {
            bool result = false;
            object left = Visit(context.expression(0));
            object right = Visit(context.expression(1));
            switch(context.LOGOPERATOR().GetText()){
                case "==" :
                    return (dynamic)left == (dynamic)right;
                case ">=":
                    return (dynamic)left >= (dynamic)right;
                case "<=":
                    return (dynamic)left <= (dynamic)right;
                case "!=":
                    return (dynamic)left != (dynamic)right;
                case "<":
                    return (dynamic)left < (dynamic)right;
                case ">":
                    return (dynamic)left > (dynamic)right;
            }
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
            else if(context.id() != null)
            {
                return Visit(context.id());
            }
            else
            {
                // Handle other cases (e.g., unary operators)
                return null;
            }
        }

        public override object VisitAssignment(CalculatorParser.AssignmentContext context)
        {
            object value = Visit(context.expression());
            string type = context.TYPE().GetText();

            // Check if type of expression is same as type declared
            if (type == "int" && value.GetType() == typeof(int))
            {
                var assignmentTuple = Tuple.Create(context.ID().GetText(), value);
                symbol_table.Add(context.ID().GetText(), assignmentTuple);
                Console.WriteLine("Added " + context.ID().GetText() + " = " + (dynamic)value);
            }
            else if (type == "double" && value.GetType() == typeof(double))
            {
                var assignmentTuple = Tuple.Create(context.ID().GetText(), value);
                symbol_table.Add(context.ID().GetText(), assignmentTuple);
                Console.WriteLine("Added " + context.ID().GetText() + " = " + (dynamic)value);
            }
            else
            {
                Console.WriteLine("Type mismatch: " + type + " != " + value.GetType().ToString());
            }
            return 0;
        }

        public override object VisitId(CalculatorParser.IdContext context)
        {
            //Lookup value in table
            var value = symbol_table[context.ID().GetText()];
            if(value is Tuple<string, int> tuple)
            {
                return tuple.Item2;
            }
            return 0;
        }
    }
}

