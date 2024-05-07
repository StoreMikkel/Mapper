using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;


public class CustomParser : CalculatorParser
{
    public CustomParser(ITokenStream input) : base(input)
    {
        ErrorHandler = new CustomErrorStrategy();
    }
}