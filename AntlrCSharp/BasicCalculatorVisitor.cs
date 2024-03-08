using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
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

        public override object VisitCalculation( CalculationContext context)
        {
            // Initialize the result with the value of the first term
            ExpressionContext expressionArr = context.expression();
            string result = context.expression().term().@operator().GetText();

            /*
            if(expressionArr.expression().@operator() != null){
                result = 1;
            }else{
                result = 2;
            }
            */

            
            /*
            // Evaluate the remaining terms and apply the corresponding operators
            for (int i = 1; i < terms.Length; i++)
            {
                int termInt = int.Parse(terms[i].GetText());
                string op = operators[i - 1];

                result = ApplyOperator(result, op, termInt);
            }
            */

            // Create a CalculatorLine object with the final result
            CalculatorLine line = new CalculatorLine() { Result = result };

            // Return the result or perform any other necessary actions
            return line;
        }
        
        // Helper method to apply the operator to the result
        private int ApplyOperator(int expressionResult, string op, int termInt)
        {
            switch (op)
            {
                case "+":
                    return expressionResult + termInt;
                case "-":
                    return expressionResult - termInt;
                case "/":
                    return expressionResult / termInt;
                case "*":
                    return expressionResult * termInt;
                default:
                    throw new InvalidOperationException("Invalid operator");
            }
        }
        
    }

}
