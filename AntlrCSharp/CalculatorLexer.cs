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
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, NUMBER=13, OPERATOR1=14, OPERATOR2=15, BOOLEANOPERATORS=16, 
		COMPARISON_OPERATOR=17, BOOLEAN_LITERAL=18, BREAK=19, RANDOM=20, EQUALS=21, 
		LEFTARRAYBRACKET=22, RIGHTARRAYBRACKET=23, LEFTCURLYBRACKET=24, RIGHTCURLYBRACKET=25, 
		IDENTIFIER=26, INCREMENTER=27, DECREMENTER=28, WHITESPACE=29, NEWLINE=30, 
		CHARACTER_LITERAL=31, STRING_LITERAL=32, TYPE=33, ELSE=34;
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
		"IDENTIFIER", "INCREMENTER", "DECREMENTER", "WHITESPACE", "NEWLINE", "CHARACTER_LITERAL", 
		"STRING_LITERAL", "TYPE", "ELSE"
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
		"'fileWriteNewline'", "'access'", "'modify'", "'bsp'", null, null, null, 
		null, null, null, "'BREAK'", "'RANDOM'", "'='", "'['", "']'", "'{'", "'}'", 
		null, "'++'", "'--'", null, null, null, null, null, "'else '"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, "NUMBER", "OPERATOR1", "OPERATOR2", "BOOLEANOPERATORS", "COMPARISON_OPERATOR", 
		"BOOLEAN_LITERAL", "BREAK", "RANDOM", "EQUALS", "LEFTARRAYBRACKET", "RIGHTARRAYBRACKET", 
		"LEFTCURLYBRACKET", "RIGHTCURLYBRACKET", "IDENTIFIER", "INCREMENTER", 
		"DECREMENTER", "WHITESPACE", "NEWLINE", "CHARACTER_LITERAL", "STRING_LITERAL", 
		"TYPE", "ELSE"
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
		4,0,34,280,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,1,0,1,0,1,1,1,1,
		1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,4,1,4,1,5,1,5,1,6,1,6,1,
		7,1,7,1,7,1,7,1,7,1,7,1,7,1,7,1,7,1,7,1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,8,
		1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,9,1,9,1,9,1,9,1,9,1,9,1,9,1,10,1,
		10,1,10,1,10,1,10,1,10,1,10,1,11,1,11,1,11,1,11,1,12,4,12,137,8,12,11,
		12,12,12,138,1,13,1,13,1,14,1,14,1,15,1,15,1,15,1,15,3,15,149,8,15,1,16,
		1,16,1,16,1,16,1,16,1,16,1,16,1,16,1,16,3,16,160,8,16,1,17,1,17,1,17,1,
		17,1,17,1,17,1,17,1,17,1,17,3,17,171,8,17,1,18,1,18,1,18,1,18,1,18,1,18,
		1,19,1,19,1,19,1,19,1,19,1,19,1,19,1,20,1,20,1,21,1,21,1,22,1,22,1,23,
		1,23,1,24,1,24,1,25,1,25,5,25,198,8,25,10,25,12,25,201,9,25,1,26,1,26,
		1,26,1,27,1,27,1,27,1,28,4,28,210,8,28,11,28,12,28,211,1,28,1,28,1,29,
		4,29,217,8,29,11,29,12,29,218,1,29,1,29,1,30,1,30,1,30,1,30,1,31,1,31,
		1,31,1,31,5,31,231,8,31,10,31,12,31,234,9,31,1,31,1,31,1,32,1,32,1,32,
		1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,
		1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,
		1,32,1,32,1,32,1,32,3,32,273,8,32,1,33,1,33,1,33,1,33,1,33,1,33,0,0,34,
		1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,
		29,15,31,16,33,17,35,18,37,19,39,20,41,21,43,22,45,23,47,24,49,25,51,26,
		53,27,55,28,57,29,59,30,61,31,63,32,65,33,67,34,1,0,9,1,0,48,57,2,0,43,
		43,45,45,2,0,42,42,47,47,2,0,60,60,62,62,2,0,65,90,97,122,3,0,48,57,65,
		90,97,122,2,0,9,9,32,32,2,0,10,10,13,13,4,0,10,10,13,13,34,34,92,92,296,
		0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,
		0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,
		1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,
		0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,
		1,0,0,0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,
		0,0,57,1,0,0,0,0,59,1,0,0,0,0,61,1,0,0,0,0,63,1,0,0,0,0,65,1,0,0,0,0,67,
		1,0,0,0,1,69,1,0,0,0,3,71,1,0,0,0,5,73,1,0,0,0,7,76,1,0,0,0,9,82,1,0,0,
		0,11,86,1,0,0,0,13,88,1,0,0,0,15,90,1,0,0,0,17,100,1,0,0,0,19,117,1,0,
		0,0,21,124,1,0,0,0,23,131,1,0,0,0,25,136,1,0,0,0,27,140,1,0,0,0,29,142,
		1,0,0,0,31,148,1,0,0,0,33,159,1,0,0,0,35,170,1,0,0,0,37,172,1,0,0,0,39,
		178,1,0,0,0,41,185,1,0,0,0,43,187,1,0,0,0,45,189,1,0,0,0,47,191,1,0,0,
		0,49,193,1,0,0,0,51,195,1,0,0,0,53,202,1,0,0,0,55,205,1,0,0,0,57,209,1,
		0,0,0,59,216,1,0,0,0,61,222,1,0,0,0,63,226,1,0,0,0,65,272,1,0,0,0,67,274,
		1,0,0,0,69,70,5,40,0,0,70,2,1,0,0,0,71,72,5,41,0,0,72,4,1,0,0,0,73,74,
		5,105,0,0,74,75,5,102,0,0,75,6,1,0,0,0,76,77,5,119,0,0,77,78,5,104,0,0,
		78,79,5,105,0,0,79,80,5,108,0,0,80,81,5,101,0,0,81,8,1,0,0,0,82,83,5,102,
		0,0,83,84,5,111,0,0,84,85,5,114,0,0,85,10,1,0,0,0,86,87,5,59,0,0,87,12,
		1,0,0,0,88,89,5,44,0,0,89,14,1,0,0,0,90,91,5,102,0,0,91,92,5,105,0,0,92,
		93,5,108,0,0,93,94,5,101,0,0,94,95,5,87,0,0,95,96,5,114,0,0,96,97,5,105,
		0,0,97,98,5,116,0,0,98,99,5,101,0,0,99,16,1,0,0,0,100,101,5,102,0,0,101,
		102,5,105,0,0,102,103,5,108,0,0,103,104,5,101,0,0,104,105,5,87,0,0,105,
		106,5,114,0,0,106,107,5,105,0,0,107,108,5,116,0,0,108,109,5,101,0,0,109,
		110,5,78,0,0,110,111,5,101,0,0,111,112,5,119,0,0,112,113,5,108,0,0,113,
		114,5,105,0,0,114,115,5,110,0,0,115,116,5,101,0,0,116,18,1,0,0,0,117,118,
		5,97,0,0,118,119,5,99,0,0,119,120,5,99,0,0,120,121,5,101,0,0,121,122,5,
		115,0,0,122,123,5,115,0,0,123,20,1,0,0,0,124,125,5,109,0,0,125,126,5,111,
		0,0,126,127,5,100,0,0,127,128,5,105,0,0,128,129,5,102,0,0,129,130,5,121,
		0,0,130,22,1,0,0,0,131,132,5,98,0,0,132,133,5,115,0,0,133,134,5,112,0,
		0,134,24,1,0,0,0,135,137,7,0,0,0,136,135,1,0,0,0,137,138,1,0,0,0,138,136,
		1,0,0,0,138,139,1,0,0,0,139,26,1,0,0,0,140,141,7,1,0,0,141,28,1,0,0,0,
		142,143,7,2,0,0,143,30,1,0,0,0,144,145,5,124,0,0,145,149,5,124,0,0,146,
		147,5,38,0,0,147,149,5,38,0,0,148,144,1,0,0,0,148,146,1,0,0,0,149,32,1,
		0,0,0,150,160,7,3,0,0,151,152,5,61,0,0,152,160,5,61,0,0,153,154,5,33,0,
		0,154,160,5,61,0,0,155,156,5,62,0,0,156,160,5,61,0,0,157,158,5,60,0,0,
		158,160,5,61,0,0,159,150,1,0,0,0,159,151,1,0,0,0,159,153,1,0,0,0,159,155,
		1,0,0,0,159,157,1,0,0,0,160,34,1,0,0,0,161,162,5,116,0,0,162,163,5,114,
		0,0,163,164,5,117,0,0,164,171,5,101,0,0,165,166,5,102,0,0,166,167,5,97,
		0,0,167,168,5,108,0,0,168,169,5,115,0,0,169,171,5,101,0,0,170,161,1,0,
		0,0,170,165,1,0,0,0,171,36,1,0,0,0,172,173,5,66,0,0,173,174,5,82,0,0,174,
		175,5,69,0,0,175,176,5,65,0,0,176,177,5,75,0,0,177,38,1,0,0,0,178,179,
		5,82,0,0,179,180,5,65,0,0,180,181,5,78,0,0,181,182,5,68,0,0,182,183,5,
		79,0,0,183,184,5,77,0,0,184,40,1,0,0,0,185,186,5,61,0,0,186,42,1,0,0,0,
		187,188,5,91,0,0,188,44,1,0,0,0,189,190,5,93,0,0,190,46,1,0,0,0,191,192,
		5,123,0,0,192,48,1,0,0,0,193,194,5,125,0,0,194,50,1,0,0,0,195,199,7,4,
		0,0,196,198,7,5,0,0,197,196,1,0,0,0,198,201,1,0,0,0,199,197,1,0,0,0,199,
		200,1,0,0,0,200,52,1,0,0,0,201,199,1,0,0,0,202,203,5,43,0,0,203,204,5,
		43,0,0,204,54,1,0,0,0,205,206,5,45,0,0,206,207,5,45,0,0,207,56,1,0,0,0,
		208,210,7,6,0,0,209,208,1,0,0,0,210,211,1,0,0,0,211,209,1,0,0,0,211,212,
		1,0,0,0,212,213,1,0,0,0,213,214,6,28,0,0,214,58,1,0,0,0,215,217,7,7,0,
		0,216,215,1,0,0,0,217,218,1,0,0,0,218,216,1,0,0,0,218,219,1,0,0,0,219,
		220,1,0,0,0,220,221,6,29,0,0,221,60,1,0,0,0,222,223,5,39,0,0,223,224,9,
		0,0,0,224,225,5,39,0,0,225,62,1,0,0,0,226,232,5,34,0,0,227,231,8,8,0,0,
		228,229,5,92,0,0,229,231,9,0,0,0,230,227,1,0,0,0,230,228,1,0,0,0,231,234,
		1,0,0,0,232,230,1,0,0,0,232,233,1,0,0,0,233,235,1,0,0,0,234,232,1,0,0,
		0,235,236,5,34,0,0,236,64,1,0,0,0,237,238,5,105,0,0,238,239,5,110,0,0,
		239,240,5,116,0,0,240,273,5,32,0,0,241,242,5,100,0,0,242,243,5,111,0,0,
		243,244,5,117,0,0,244,245,5,98,0,0,245,246,5,108,0,0,246,247,5,101,0,0,
		247,273,5,32,0,0,248,249,5,115,0,0,249,250,5,116,0,0,250,251,5,114,0,0,
		251,252,5,105,0,0,252,253,5,110,0,0,253,254,5,103,0,0,254,273,5,32,0,0,
		255,256,5,98,0,0,256,257,5,111,0,0,257,258,5,111,0,0,258,259,5,108,0,0,
		259,260,5,101,0,0,260,261,5,97,0,0,261,262,5,110,0,0,262,273,5,32,0,0,
		263,264,5,99,0,0,264,265,5,104,0,0,265,266,5,97,0,0,266,267,5,114,0,0,
		267,273,5,32,0,0,268,269,5,109,0,0,269,270,5,97,0,0,270,271,5,112,0,0,
		271,273,5,32,0,0,272,237,1,0,0,0,272,241,1,0,0,0,272,248,1,0,0,0,272,255,
		1,0,0,0,272,263,1,0,0,0,272,268,1,0,0,0,273,66,1,0,0,0,274,275,5,101,0,
		0,275,276,5,108,0,0,276,277,5,115,0,0,277,278,5,101,0,0,278,279,5,32,0,
		0,279,68,1,0,0,0,11,0,138,148,159,170,199,211,218,230,232,272,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
