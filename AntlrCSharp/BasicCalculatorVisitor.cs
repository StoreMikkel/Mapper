using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<CalculatorLine> Lines = new List<CalculatorLine>();

        public override object VisitCalculation(CalculatorParser.CalculationContext context)
        {            
            NumberContext[] number = context.number();
            OperatorContext tegn = context.@operator();

            CalculatorLine line = new CalculatorLine() { Number1 = number[0].GetText().Trim('"'), Operator = tegn.GetText().Trim('"'), Number2 = number[1].GetText().Trim('"') };
            Lines.Add(line);

            return line;
        }
    }

}
