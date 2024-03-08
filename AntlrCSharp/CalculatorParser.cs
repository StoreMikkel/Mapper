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

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class CalculatorParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		NUMBER=1, OPERATOR=2, WHITESPACE=3, NEWLINE=4;
	public const int
		RULE_input = 0, RULE_calculation = 1, RULE_expression = 2, RULE_term = 3, 
		RULE_number = 4, RULE_operator = 5;
	public static readonly string[] ruleNames = {
		"input", "calculation", "expression", "term", "number", "operator"
	};

	private static readonly string[] _LiteralNames = {
	};
	private static readonly string[] _SymbolicNames = {
		null, "NUMBER", "OPERATOR", "WHITESPACE", "NEWLINE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Calculator.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static CalculatorParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public CalculatorParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public CalculatorParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class InputContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public CalculationContext calculation() {
			return GetRuleContext<CalculationContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode Eof() { return GetToken(CalculatorParser.Eof, 0); }
		public InputContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_input; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICalculatorVisitor<TResult> typedVisitor = visitor as ICalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitInput(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public InputContext input() {
		InputContext _localctx = new InputContext(Context, State);
		EnterRule(_localctx, 0, RULE_input);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 12;
			calculation();
			State = 13;
			Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CalculationContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE() { return GetToken(CalculatorParser.NEWLINE, 0); }
		public CalculationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_calculation; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICalculatorVisitor<TResult> typedVisitor = visitor as ICalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCalculation(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CalculationContext calculation() {
		CalculationContext _localctx = new CalculationContext(Context, State);
		EnterRule(_localctx, 2, RULE_calculation);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 15;
			expression(0);
			State = 16;
			Match(NEWLINE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public TermContext term() {
			return GetRuleContext<TermContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public OperatorContext @operator() {
			return GetRuleContext<OperatorContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public NumberContext number() {
			return GetRuleContext<NumberContext>(0);
		}
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICalculatorVisitor<TResult> typedVisitor = visitor as ICalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpression(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		return expression(0);
	}

	private ExpressionContext expression(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ExpressionContext _localctx = new ExpressionContext(Context, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 4;
		EnterRecursionRule(_localctx, 4, RULE_expression, _p);
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			{
			State = 19;
			term(0);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 27;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,0,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new ExpressionContext(_parentctx, _parentState);
					PushNewRecursionContext(_localctx, _startState, RULE_expression);
					State = 21;
					if (!(Precpred(Context, 1))) throw new FailedPredicateException(this, "Precpred(Context, 1)");
					State = 22;
					@operator();
					State = 23;
					number();
					}
					} 
				}
				State = 29;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,0,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public partial class TermContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public NumberContext number() {
			return GetRuleContext<NumberContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public TermContext term() {
			return GetRuleContext<TermContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public OperatorContext @operator() {
			return GetRuleContext<OperatorContext>(0);
		}
		public TermContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_term; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICalculatorVisitor<TResult> typedVisitor = visitor as ICalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitTerm(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TermContext term() {
		return term(0);
	}

	private TermContext term(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		TermContext _localctx = new TermContext(Context, _parentState);
		TermContext _prevctx = _localctx;
		int _startState = 6;
		EnterRecursionRule(_localctx, 6, RULE_term, _p);
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			{
			State = 31;
			number();
			}
			Context.Stop = TokenStream.LT(-1);
			State = 39;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,1,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new TermContext(_parentctx, _parentState);
					PushNewRecursionContext(_localctx, _startState, RULE_term);
					State = 33;
					if (!(Precpred(Context, 2))) throw new FailedPredicateException(this, "Precpred(Context, 2)");
					State = 34;
					@operator();
					State = 35;
					number();
					}
					} 
				}
				State = 41;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,1,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public partial class NumberContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NUMBER() { return GetToken(CalculatorParser.NUMBER, 0); }
		public NumberContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_number; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICalculatorVisitor<TResult> typedVisitor = visitor as ICalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNumber(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public NumberContext number() {
		NumberContext _localctx = new NumberContext(Context, State);
		EnterRule(_localctx, 8, RULE_number);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 42;
			Match(NUMBER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class OperatorContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode OPERATOR() { return GetToken(CalculatorParser.OPERATOR, 0); }
		public OperatorContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_operator; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICalculatorVisitor<TResult> typedVisitor = visitor as ICalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitOperator(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public OperatorContext @operator() {
		OperatorContext _localctx = new OperatorContext(Context, State);
		EnterRule(_localctx, 10, RULE_operator);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 44;
			Match(OPERATOR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 2: return expression_sempred((ExpressionContext)_localctx, predIndex);
		case 3: return term_sempred((TermContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 1);
		}
		return true;
	}
	private bool term_sempred(TermContext _localctx, int predIndex) {
		switch (predIndex) {
		case 1: return Precpred(Context, 2);
		}
		return true;
	}

	private static int[] _serializedATN = {
		4,1,4,47,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,1,0,1,0,1,0,1,
		1,1,1,1,1,1,2,1,2,1,2,1,2,1,2,1,2,1,2,5,2,26,8,2,10,2,12,2,29,9,2,1,3,
		1,3,1,3,1,3,1,3,1,3,1,3,5,3,38,8,3,10,3,12,3,41,9,3,1,4,1,4,1,5,1,5,1,
		5,0,2,4,6,6,0,2,4,6,8,10,0,0,42,0,12,1,0,0,0,2,15,1,0,0,0,4,18,1,0,0,0,
		6,30,1,0,0,0,8,42,1,0,0,0,10,44,1,0,0,0,12,13,3,2,1,0,13,14,5,0,0,1,14,
		1,1,0,0,0,15,16,3,4,2,0,16,17,5,4,0,0,17,3,1,0,0,0,18,19,6,2,-1,0,19,20,
		3,6,3,0,20,27,1,0,0,0,21,22,10,1,0,0,22,23,3,10,5,0,23,24,3,8,4,0,24,26,
		1,0,0,0,25,21,1,0,0,0,26,29,1,0,0,0,27,25,1,0,0,0,27,28,1,0,0,0,28,5,1,
		0,0,0,29,27,1,0,0,0,30,31,6,3,-1,0,31,32,3,8,4,0,32,39,1,0,0,0,33,34,10,
		2,0,0,34,35,3,10,5,0,35,36,3,8,4,0,36,38,1,0,0,0,37,33,1,0,0,0,38,41,1,
		0,0,0,39,37,1,0,0,0,39,40,1,0,0,0,40,7,1,0,0,0,41,39,1,0,0,0,42,43,5,1,
		0,0,43,9,1,0,0,0,44,45,5,2,0,0,45,11,1,0,0,0,2,27,39
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
