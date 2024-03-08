using System;
using System.Collections.Generic;
using System.Linq;
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
        //List of Lines to visit
        public List<CalculatorLine> Lines = new List<CalculatorLine>();


        /*public override object VisitOperator(OperatorContext context)
        {
            return base.VisitOperator(context);
        }*/

        public override object VisitExpression( ExpressionContext context)
        {
            TermContext str = context.term();
            string op = context.OPERATOR().GetText();

            NumberContext[] expressionNumbers = context.expression().term().number();
            OperatorContext expressionOperator = context.expression().term().@operator();
            int expressionResult = 0;
            int NumberExpression1 = int.Parse(expressionNumbers[0].GetText());
            int NumberExpression2 = int.Parse(expressionNumbers[1].GetText());
            switch(expressionOperator.GetText()){
                case "+":
                    expressionResult = NumberExpression1 + NumberExpression2;
                    break;
                case "-":
                    expressionResult = NumberExpression1 - NumberExpression2;
                    break;
                case "/":
                    expressionResult = NumberExpression1 / NumberExpression2;
                    break;
                case "*":
                    expressionResult = NumberExpression1 * NumberExpression2;
                    break;
            }

            int result = 0;
            int termInt = int.Parse(str.GetText());
            switch(op){
                case "+":
                    result = expressionResult + termInt;
                    break;
                case "-":
                    result = expressionResult - termInt;
                    break;
                case "/":
                    result = expressionResult / termInt;
                    break;
                case "*":
                    result = expressionResult * termInt;
                    break;
            }


            CalculatorLine line = new CalculatorLine() {Result = result};
            Lines.Add(line);

            return line;
        }
        
    }

}
