using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
using AntlrCSharp;
using static CalculatorParser;



/*public class YourLanguageToCSharpVisitor : CalculatorBaseVisitor<string> {
    public override string VisitInput(CalculatorParser.InputContext context) {
        string result = "";
        result += "using System.Collections;\n" + "using System.Collections.Generic;\n" + "using UnityEngine;\n"
        + "using System.IO;\n";

        result += "public class output : MonoBehaviour{" + "\n" + "void Start(){\n";
        foreach(var statementContext in context.statement()) {
            result += Visit(statementContext) + "\n";
        }
        result += "}" + "\n" + "}";

        return result;
    }

    public override string VisitCalculation(CalculatorParser.CalculationContext context) {
        return Visit(context.expression());
    }

    public override string VisitExpression(CalculatorParser.ExpressionContext context) {
       if (context.COMPARISON_OPERATOR() != null) {
        string left = Visit(context.expression());
        string op = context.COMPARISON_OPERATOR().GetText();
        string right = Visit(context.term());
        return $"{left} {op} {right}";
    } else if (context.OPERATOR1() != null) {
        string left = Visit(context.expression());
        string op = context.OPERATOR1().GetText();
        string right = Visit(context.term());
        return $"{left} {op} {right};";
    } else {
        return Visit(context.term()); // <-- Adjusted this line
    }
    }

    public override string VisitTerm(CalculatorParser.TermContext context) {
        if (context.OPERATOR2() != null) {
            string left = Visit(context.term());
            string op = context.OPERATOR2().GetText();
            string right = Visit(context.factor());
            return $"{left} {op} {right}";
        } else {
            return Visit(context.factor());
        }
    }

    public override string VisitFactor(CalculatorParser.FactorContext context) {
        if (context.expression() != null) {
            return $"({Visit(context.expression())})";
        } else {
            return context.number().GetText();
        }
    }

    public override string VisitIfStatement(CalculatorParser.IfStatementContext context) {
        string condition = Visit(context.expression()); // Corrected access to the condition
        string ifBlock = Visit(context.statement()[0]);
        string elseBlock = context.statement().Length > 1 ? Visit(context.statement()[1]) : null;

        string result = $"if ({condition}) {{\n{ifBlock}\n}}";
        if (elseBlock != null) {
            result += $" else {{\n{elseBlock}\n}}";
        }
        return result;
    }

    public override string VisitCondition(CalculatorParser.ConditionContext context) {
        return Visit(context.expression());
    }

    public override string VisitWhileStatement(CalculatorParser.WhileStatementContext context) {
        string condition = Visit(context.condition());
        string statements = "";
        foreach (var statement in context.statement()) {
            statements += Visit(statement) + ";\n";
        }
        return $"while ({condition}) {{\n{statements}\n}}";
    }
}*/