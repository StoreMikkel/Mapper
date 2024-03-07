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
            NumberContext[] number = context.number();

            
            List<string> list = new List<string>();
        
            foreach (var element in number)
            {
             list.Add(element.GetText().Trim('"'));
            }
            String[] str = list.ToArray();
            string op = context.OPERATOR().GetText();

            string[] operatorArr = [op];
            CalculatorLine line = new CalculatorLine() {Numbers = str, Operators = operatorArr };


            /*
            string[] strArr = [number.GetText()];
            CalculatorLine line = new CalculatorLine() {Numbers = strArr };
            */
            Lines.Add(line);

            return line;
        }
        
    }

}
