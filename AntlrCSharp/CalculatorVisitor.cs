//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c://Users//Mikkel//Documents//UNI//4. Semester//CalculatorLanguage//AntlrCSharp//Calculator.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="CalculatorParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface ICalculatorVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.input"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInput([NotNull] CalculatorParser.InputContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] CalculatorParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStatement([NotNull] CalculatorParser.IfStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCondition([NotNull] CalculatorParser.ConditionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.calculation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCalculation([NotNull] CalculatorParser.CalculationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] CalculatorParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTerm([NotNull] CalculatorParser.TermContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFactor([NotNull] CalculatorParser.FactorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumber([NotNull] CalculatorParser.NumberContext context);
}
