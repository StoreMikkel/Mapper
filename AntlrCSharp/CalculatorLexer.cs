//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:/Users/ajapo/Documents/GitHub/CalculatorLanguage/AntlrCSharp/Calculator.g4 by ANTLR 4.13.1

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
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, NUMBER=13, OPERATOR1=14, OPERATOR2=15, BOOLEANOPERATORS=16, 
		COMPARISON_OPERATOR=17, BOOLEAN_LITERAL=18, BREAK=19, RANDOM=20, EQUALS=21, 
		LEFTARRAYBRACKET=22, RIGHTARRAYBRACKET=23, LEFTCURLYBRACKET=24, RIGHTCURLYBRACKET=25, 
		IDENTIFIER=26, DOUBLE_LITERAL=27, INCREMENTER=28, DECREMENTER=29, WHITESPACE=30, 
		NEWLINE=31, CHARACTER_LITERAL=32, STRING_LITERAL=33, TYPE=34, ELSE=35;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "NUMBER", "OPERATOR1", "OPERATOR2", "BOOLEANOPERATORS", 
		"COMPARISON_OPERATOR", "BOOLEAN_LITERAL", "BREAK", "RANDOM", "EQUALS", 
		"LEFTARRAYBRACKET", "RIGHTARRAYBRACKET", "LEFTCURLYBRACKET", "RIGHTCURLYBRACKET", 
		"IDENTIFIER", "DOUBLE_LITERAL", "INCREMENTER", "DECREMENTER", "WHITESPACE", 
		"NEWLINE", "CHARACTER_LITERAL", "STRING_LITERAL", "TYPE", "ELSE"
	};


	public CalculatorLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public CalculatorLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "'if'", "'while'", "'for'", "';'", "','", "'fileWrite'", 
		"'fileWriteNewline'", "'access'", "'modify'", "'print'", null, null, null, 
		null, null, null, "'BREAK'", "'RANDOM'", "'='", "'['", "']'", "'{'", "'}'", 
		null, null, "'++'", "'--'", null, null, null, null, null, "'else '"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, "NUMBER", "OPERATOR1", "OPERATOR2", "BOOLEANOPERATORS", "COMPARISON_OPERATOR", 
		"BOOLEAN_LITERAL", "BREAK", "RANDOM", "EQUALS", "LEFTARRAYBRACKET", "RIGHTARRAYBRACKET", 
		"LEFTCURLYBRACKET", "RIGHTCURLYBRACKET", "IDENTIFIER", "DOUBLE_LITERAL", 
		"INCREMENTER", "DECREMENTER", "WHITESPACE", "NEWLINE", "CHARACTER_LITERAL", 
		"STRING_LITERAL", "TYPE", "ELSE"
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
		4,0,35,295,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,1,0,1,
		0,1,1,1,1,1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,4,1,4,1,5,1,5,
		1,6,1,6,1,7,1,7,1,7,1,7,1,7,1,7,1,7,1,7,1,7,1,7,1,8,1,8,1,8,1,8,1,8,1,
		8,1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,9,1,9,1,9,1,9,1,9,1,9,
		1,9,1,10,1,10,1,10,1,10,1,10,1,10,1,10,1,11,1,11,1,11,1,11,1,11,1,11,1,
		12,4,12,141,8,12,11,12,12,12,142,1,13,1,13,1,14,1,14,1,15,1,15,1,15,1,
		15,3,15,153,8,15,1,16,1,16,1,16,1,16,1,16,1,16,1,16,1,16,1,16,3,16,164,
		8,16,1,17,1,17,1,17,1,17,1,17,1,17,1,17,1,17,1,17,3,17,175,8,17,1,18,1,
		18,1,18,1,18,1,18,1,18,1,19,1,19,1,19,1,19,1,19,1,19,1,19,1,20,1,20,1,
		21,1,21,1,22,1,22,1,23,1,23,1,24,1,24,1,25,1,25,5,25,202,8,25,10,25,12,
		25,205,9,25,1,26,4,26,208,8,26,11,26,12,26,209,1,26,1,26,4,26,214,8,26,
		11,26,12,26,215,1,27,1,27,1,27,1,28,1,28,1,28,1,29,4,29,225,8,29,11,29,
		12,29,226,1,29,1,29,1,30,4,30,232,8,30,11,30,12,30,233,1,30,1,30,1,31,
		1,31,1,31,1,31,1,32,1,32,1,32,1,32,5,32,246,8,32,10,32,12,32,249,9,32,
		1,32,1,32,1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,
		1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,
		1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,3,33,288,8,33,1,34,1,34,1,
		34,1,34,1,34,1,34,0,0,35,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,
		21,11,23,12,25,13,27,14,29,15,31,16,33,17,35,18,37,19,39,20,41,21,43,22,
		45,23,47,24,49,25,51,26,53,27,55,28,57,29,59,30,61,31,63,32,65,33,67,34,
		69,35,1,0,9,1,0,48,57,2,0,43,43,45,45,2,0,42,42,47,47,2,0,60,60,62,62,
		2,0,65,90,97,122,3,0,48,57,65,90,97,122,2,0,9,9,32,32,2,0,10,10,13,13,
		4,0,10,10,13,13,34,34,92,92,313,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,
		7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,
		0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,
		29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,1,
		0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,0,0,49,1,0,0,0,
		0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,1,0,0,0,0,59,1,0,0,0,0,61,
		1,0,0,0,0,63,1,0,0,0,0,65,1,0,0,0,0,67,1,0,0,0,0,69,1,0,0,0,1,71,1,0,0,
		0,3,73,1,0,0,0,5,75,1,0,0,0,7,78,1,0,0,0,9,84,1,0,0,0,11,88,1,0,0,0,13,
		90,1,0,0,0,15,92,1,0,0,0,17,102,1,0,0,0,19,119,1,0,0,0,21,126,1,0,0,0,
		23,133,1,0,0,0,25,140,1,0,0,0,27,144,1,0,0,0,29,146,1,0,0,0,31,152,1,0,
		0,0,33,163,1,0,0,0,35,174,1,0,0,0,37,176,1,0,0,0,39,182,1,0,0,0,41,189,
		1,0,0,0,43,191,1,0,0,0,45,193,1,0,0,0,47,195,1,0,0,0,49,197,1,0,0,0,51,
		199,1,0,0,0,53,207,1,0,0,0,55,217,1,0,0,0,57,220,1,0,0,0,59,224,1,0,0,
		0,61,231,1,0,0,0,63,237,1,0,0,0,65,241,1,0,0,0,67,287,1,0,0,0,69,289,1,
		0,0,0,71,72,5,40,0,0,72,2,1,0,0,0,73,74,5,41,0,0,74,4,1,0,0,0,75,76,5,
		105,0,0,76,77,5,102,0,0,77,6,1,0,0,0,78,79,5,119,0,0,79,80,5,104,0,0,80,
		81,5,105,0,0,81,82,5,108,0,0,82,83,5,101,0,0,83,8,1,0,0,0,84,85,5,102,
		0,0,85,86,5,111,0,0,86,87,5,114,0,0,87,10,1,0,0,0,88,89,5,59,0,0,89,12,
		1,0,0,0,90,91,5,44,0,0,91,14,1,0,0,0,92,93,5,102,0,0,93,94,5,105,0,0,94,
		95,5,108,0,0,95,96,5,101,0,0,96,97,5,87,0,0,97,98,5,114,0,0,98,99,5,105,
		0,0,99,100,5,116,0,0,100,101,5,101,0,0,101,16,1,0,0,0,102,103,5,102,0,
		0,103,104,5,105,0,0,104,105,5,108,0,0,105,106,5,101,0,0,106,107,5,87,0,
		0,107,108,5,114,0,0,108,109,5,105,0,0,109,110,5,116,0,0,110,111,5,101,
		0,0,111,112,5,78,0,0,112,113,5,101,0,0,113,114,5,119,0,0,114,115,5,108,
		0,0,115,116,5,105,0,0,116,117,5,110,0,0,117,118,5,101,0,0,118,18,1,0,0,
		0,119,120,5,97,0,0,120,121,5,99,0,0,121,122,5,99,0,0,122,123,5,101,0,0,
		123,124,5,115,0,0,124,125,5,115,0,0,125,20,1,0,0,0,126,127,5,109,0,0,127,
		128,5,111,0,0,128,129,5,100,0,0,129,130,5,105,0,0,130,131,5,102,0,0,131,
		132,5,121,0,0,132,22,1,0,0,0,133,134,5,112,0,0,134,135,5,114,0,0,135,136,
		5,105,0,0,136,137,5,110,0,0,137,138,5,116,0,0,138,24,1,0,0,0,139,141,7,
		0,0,0,140,139,1,0,0,0,141,142,1,0,0,0,142,140,1,0,0,0,142,143,1,0,0,0,
		143,26,1,0,0,0,144,145,7,1,0,0,145,28,1,0,0,0,146,147,7,2,0,0,147,30,1,
		0,0,0,148,149,5,124,0,0,149,153,5,124,0,0,150,151,5,38,0,0,151,153,5,38,
		0,0,152,148,1,0,0,0,152,150,1,0,0,0,153,32,1,0,0,0,154,164,7,3,0,0,155,
		156,5,61,0,0,156,164,5,61,0,0,157,158,5,33,0,0,158,164,5,61,0,0,159,160,
		5,62,0,0,160,164,5,61,0,0,161,162,5,60,0,0,162,164,5,61,0,0,163,154,1,
		0,0,0,163,155,1,0,0,0,163,157,1,0,0,0,163,159,1,0,0,0,163,161,1,0,0,0,
		164,34,1,0,0,0,165,166,5,116,0,0,166,167,5,114,0,0,167,168,5,117,0,0,168,
		175,5,101,0,0,169,170,5,102,0,0,170,171,5,97,0,0,171,172,5,108,0,0,172,
		173,5,115,0,0,173,175,5,101,0,0,174,165,1,0,0,0,174,169,1,0,0,0,175,36,
		1,0,0,0,176,177,5,66,0,0,177,178,5,82,0,0,178,179,5,69,0,0,179,180,5,65,
		0,0,180,181,5,75,0,0,181,38,1,0,0,0,182,183,5,82,0,0,183,184,5,65,0,0,
		184,185,5,78,0,0,185,186,5,68,0,0,186,187,5,79,0,0,187,188,5,77,0,0,188,
		40,1,0,0,0,189,190,5,61,0,0,190,42,1,0,0,0,191,192,5,91,0,0,192,44,1,0,
		0,0,193,194,5,93,0,0,194,46,1,0,0,0,195,196,5,123,0,0,196,48,1,0,0,0,197,
		198,5,125,0,0,198,50,1,0,0,0,199,203,7,4,0,0,200,202,7,5,0,0,201,200,1,
		0,0,0,202,205,1,0,0,0,203,201,1,0,0,0,203,204,1,0,0,0,204,52,1,0,0,0,205,
		203,1,0,0,0,206,208,7,0,0,0,207,206,1,0,0,0,208,209,1,0,0,0,209,207,1,
		0,0,0,209,210,1,0,0,0,210,211,1,0,0,0,211,213,5,46,0,0,212,214,7,0,0,0,
		213,212,1,0,0,0,214,215,1,0,0,0,215,213,1,0,0,0,215,216,1,0,0,0,216,54,
		1,0,0,0,217,218,5,43,0,0,218,219,5,43,0,0,219,56,1,0,0,0,220,221,5,45,
		0,0,221,222,5,45,0,0,222,58,1,0,0,0,223,225,7,6,0,0,224,223,1,0,0,0,225,
		226,1,0,0,0,226,224,1,0,0,0,226,227,1,0,0,0,227,228,1,0,0,0,228,229,6,
		29,0,0,229,60,1,0,0,0,230,232,7,7,0,0,231,230,1,0,0,0,232,233,1,0,0,0,
		233,231,1,0,0,0,233,234,1,0,0,0,234,235,1,0,0,0,235,236,6,30,0,0,236,62,
		1,0,0,0,237,238,5,39,0,0,238,239,9,0,0,0,239,240,5,39,0,0,240,64,1,0,0,
		0,241,247,5,34,0,0,242,246,8,8,0,0,243,244,5,92,0,0,244,246,9,0,0,0,245,
		242,1,0,0,0,245,243,1,0,0,0,246,249,1,0,0,0,247,245,1,0,0,0,247,248,1,
		0,0,0,248,250,1,0,0,0,249,247,1,0,0,0,250,251,5,34,0,0,251,66,1,0,0,0,
		252,253,5,105,0,0,253,254,5,110,0,0,254,255,5,116,0,0,255,288,5,32,0,0,
		256,257,5,100,0,0,257,258,5,111,0,0,258,259,5,117,0,0,259,260,5,98,0,0,
		260,261,5,108,0,0,261,262,5,101,0,0,262,288,5,32,0,0,263,264,5,115,0,0,
		264,265,5,116,0,0,265,266,5,114,0,0,266,267,5,105,0,0,267,268,5,110,0,
		0,268,269,5,103,0,0,269,288,5,32,0,0,270,271,5,98,0,0,271,272,5,111,0,
		0,272,273,5,111,0,0,273,274,5,108,0,0,274,275,5,101,0,0,275,276,5,97,0,
		0,276,277,5,110,0,0,277,288,5,32,0,0,278,279,5,99,0,0,279,280,5,104,0,
		0,280,281,5,97,0,0,281,282,5,114,0,0,282,288,5,32,0,0,283,284,5,109,0,
		0,284,285,5,97,0,0,285,286,5,112,0,0,286,288,5,32,0,0,287,252,1,0,0,0,
		287,256,1,0,0,0,287,263,1,0,0,0,287,270,1,0,0,0,287,278,1,0,0,0,287,283,
		1,0,0,0,288,68,1,0,0,0,289,290,5,101,0,0,290,291,5,108,0,0,291,292,5,115,
		0,0,292,293,5,101,0,0,293,294,5,32,0,0,294,70,1,0,0,0,13,0,142,152,163,
		174,203,209,215,226,233,245,247,287,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
