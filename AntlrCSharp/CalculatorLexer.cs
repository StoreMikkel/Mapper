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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class CalculatorLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		NUMBER=1, OPERATOR1=2, OPERATOR2=3, LOGOPERATOR=4, WHITESPACE=5, NEWLINE=6, 
		LPAREN=7, RPAREN=8, IF=9, ELSE=10, TAB=11, ID=12, ASSIGN=13, TYPE=14;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"NUMBER", "OPERATOR1", "OPERATOR2", "LOGOPERATOR", "WHITESPACE", "NEWLINE", 
		"LPAREN", "RPAREN", "IF", "ELSE", "TAB", "ID", "ASSIGN", "TYPE"
	};


	public CalculatorLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public CalculatorLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, null, null, null, null, null, null, "'('", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "NUMBER", "OPERATOR1", "OPERATOR2", "LOGOPERATOR", "WHITESPACE", 
		"NEWLINE", "LPAREN", "RPAREN", "IF", "ELSE", "TAB", "ID", "ASSIGN", "TYPE"
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

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static CalculatorLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,14,97,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,
		2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,1,0,4,
		0,31,8,0,11,0,12,0,32,1,1,1,1,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,
		1,3,3,3,48,8,3,1,4,4,4,51,8,4,11,4,12,4,52,1,4,1,4,1,5,3,5,58,8,5,1,5,
		1,5,4,5,62,8,5,11,5,12,5,63,1,6,1,6,1,7,1,7,1,8,1,8,1,8,1,9,1,9,1,9,1,
		9,1,9,1,10,1,10,1,11,4,11,81,8,11,11,11,12,11,82,1,12,1,12,1,13,1,13,1,
		13,1,13,1,13,1,13,1,13,1,13,1,13,3,13,96,8,13,0,0,14,1,1,3,2,5,3,7,4,9,
		5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,1,0,5,1,0,48,57,2,
		0,43,43,45,45,2,0,42,42,47,47,2,0,60,60,62,62,1,0,65,90,107,0,1,1,0,0,
		0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,
		0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,
		0,25,1,0,0,0,0,27,1,0,0,0,1,30,1,0,0,0,3,34,1,0,0,0,5,36,1,0,0,0,7,47,
		1,0,0,0,9,50,1,0,0,0,11,61,1,0,0,0,13,65,1,0,0,0,15,67,1,0,0,0,17,69,1,
		0,0,0,19,72,1,0,0,0,21,77,1,0,0,0,23,80,1,0,0,0,25,84,1,0,0,0,27,95,1,
		0,0,0,29,31,7,0,0,0,30,29,1,0,0,0,31,32,1,0,0,0,32,30,1,0,0,0,32,33,1,
		0,0,0,33,2,1,0,0,0,34,35,7,1,0,0,35,4,1,0,0,0,36,37,7,2,0,0,37,6,1,0,0,
		0,38,39,5,61,0,0,39,48,5,61,0,0,40,41,5,62,0,0,41,48,5,61,0,0,42,43,5,
		60,0,0,43,48,5,61,0,0,44,45,5,33,0,0,45,48,5,61,0,0,46,48,7,3,0,0,47,38,
		1,0,0,0,47,40,1,0,0,0,47,42,1,0,0,0,47,44,1,0,0,0,47,46,1,0,0,0,48,8,1,
		0,0,0,49,51,5,32,0,0,50,49,1,0,0,0,51,52,1,0,0,0,52,50,1,0,0,0,52,53,1,
		0,0,0,53,54,1,0,0,0,54,55,6,4,0,0,55,10,1,0,0,0,56,58,5,13,0,0,57,56,1,
		0,0,0,57,58,1,0,0,0,58,59,1,0,0,0,59,62,5,10,0,0,60,62,5,13,0,0,61,57,
		1,0,0,0,61,60,1,0,0,0,62,63,1,0,0,0,63,61,1,0,0,0,63,64,1,0,0,0,64,12,
		1,0,0,0,65,66,5,40,0,0,66,14,1,0,0,0,67,68,5,41,0,0,68,16,1,0,0,0,69,70,
		5,105,0,0,70,71,5,102,0,0,71,18,1,0,0,0,72,73,5,101,0,0,73,74,5,108,0,
		0,74,75,5,115,0,0,75,76,5,101,0,0,76,20,1,0,0,0,77,78,5,9,0,0,78,22,1,
		0,0,0,79,81,7,4,0,0,80,79,1,0,0,0,81,82,1,0,0,0,82,80,1,0,0,0,82,83,1,
		0,0,0,83,24,1,0,0,0,84,85,5,61,0,0,85,26,1,0,0,0,86,87,5,105,0,0,87,88,
		5,110,0,0,88,96,5,116,0,0,89,90,5,100,0,0,90,91,5,111,0,0,91,92,5,117,
		0,0,92,93,5,98,0,0,93,94,5,108,0,0,94,96,5,101,0,0,95,86,1,0,0,0,95,89,
		1,0,0,0,96,28,1,0,0,0,9,0,32,47,52,57,61,63,82,95,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
