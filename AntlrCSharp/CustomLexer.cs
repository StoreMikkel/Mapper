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

public class CustomLexer : CalculatorLexer
{
    public CustomLexer(ICharStream input) : base(input)
    {
        // Remove the default error listeners
        RemoveErrorListeners();
        // Add a custom error listener
        AddErrorListener(new CustomErrorListener());
    }
}