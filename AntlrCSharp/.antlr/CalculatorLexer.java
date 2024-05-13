// Generated from c://Users//Mikkel//Documents//UNI//4. Semester//CalculatorLanguage//AntlrCSharp//Calculator.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue", "this-escape"})
public class CalculatorLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.13.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, NUMBER=12, OPERATOR1=13, OPERATOR2=14, BOOLEANOPERATORS=15, 
		COMPARISON_OPERATOR=16, BOOLEAN_LITERAL=17, BREAK=18, RANDOM=19, EQUALS=20, 
		LEFTARRAYBRACKET=21, RIGHTARRAYBRACKET=22, LEFTCURLYBRACKET=23, RIGHTCURLYBRACKET=24, 
		IDENTIFIER=25, INCREMENTER=26, DECREMENTER=27, WHITESPACE=28, NEWLINE=29, 
		CHARACTER_LITERAL=30, STRING_LITERAL=31, TYPE=32, ELSE=33;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
			"T__9", "T__10", "NUMBER", "OPERATOR1", "OPERATOR2", "BOOLEANOPERATORS", 
			"COMPARISON_OPERATOR", "BOOLEAN_LITERAL", "BREAK", "RANDOM", "EQUALS", 
			"LEFTARRAYBRACKET", "RIGHTARRAYBRACKET", "LEFTCURLYBRACKET", "RIGHTCURLYBRACKET", 
			"IDENTIFIER", "INCREMENTER", "DECREMENTER", "WHITESPACE", "NEWLINE", 
			"CHARACTER_LITERAL", "STRING_LITERAL", "TYPE", "ELSE"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'('", "')'", "'if'", "'while'", "'for'", "';'", "','", "'fileWrite'", 
			"'fileWriteNewline'", "'access'", "'modify'", null, null, null, null, 
			null, null, "'BREAK'", "'RANDOM'", "'='", "'['", "']'", "'{'", "'}'", 
			null, "'++'", "'--'", null, null, null, null, null, "'else '"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			"NUMBER", "OPERATOR1", "OPERATOR2", "BOOLEANOPERATORS", "COMPARISON_OPERATOR", 
			"BOOLEAN_LITERAL", "BREAK", "RANDOM", "EQUALS", "LEFTARRAYBRACKET", "RIGHTARRAYBRACKET", 
			"LEFTCURLYBRACKET", "RIGHTCURLYBRACKET", "IDENTIFIER", "INCREMENTER", 
			"DECREMENTER", "WHITESPACE", "NEWLINE", "CHARACTER_LITERAL", "STRING_LITERAL", 
			"TYPE", "ELSE"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}


	public CalculatorLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "Calculator.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\u0004\u0000!\u0112\u0006\uffff\uffff\u0002\u0000\u0007\u0000\u0002\u0001"+
		"\u0007\u0001\u0002\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004"+
		"\u0007\u0004\u0002\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007"+
		"\u0007\u0007\u0002\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b"+
		"\u0007\u000b\u0002\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002"+
		"\u000f\u0007\u000f\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0002"+
		"\u0012\u0007\u0012\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014\u0002"+
		"\u0015\u0007\u0015\u0002\u0016\u0007\u0016\u0002\u0017\u0007\u0017\u0002"+
		"\u0018\u0007\u0018\u0002\u0019\u0007\u0019\u0002\u001a\u0007\u001a\u0002"+
		"\u001b\u0007\u001b\u0002\u001c\u0007\u001c\u0002\u001d\u0007\u001d\u0002"+
		"\u001e\u0007\u001e\u0002\u001f\u0007\u001f\u0002 \u0007 \u0001\u0000\u0001"+
		"\u0000\u0001\u0001\u0001\u0001\u0001\u0002\u0001\u0002\u0001\u0002\u0001"+
		"\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0001"+
		"\u0004\u0001\u0004\u0001\u0004\u0001\u0004\u0001\u0005\u0001\u0005\u0001"+
		"\u0006\u0001\u0006\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001"+
		"\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001"+
		"\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001"+
		"\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\t\u0001"+
		"\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001\n\u0001\n\u0001\n\u0001"+
		"\n\u0001\n\u0001\n\u0001\n\u0001\u000b\u0004\u000b\u0083\b\u000b\u000b"+
		"\u000b\f\u000b\u0084\u0001\f\u0001\f\u0001\r\u0001\r\u0001\u000e\u0001"+
		"\u000e\u0001\u000e\u0001\u000e\u0003\u000e\u008f\b\u000e\u0001\u000f\u0001"+
		"\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001"+
		"\u000f\u0001\u000f\u0003\u000f\u009a\b\u000f\u0001\u0010\u0001\u0010\u0001"+
		"\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001"+
		"\u0010\u0003\u0010\u00a5\b\u0010\u0001\u0011\u0001\u0011\u0001\u0011\u0001"+
		"\u0011\u0001\u0011\u0001\u0011\u0001\u0012\u0001\u0012\u0001\u0012\u0001"+
		"\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0013\u0001\u0013\u0001"+
		"\u0014\u0001\u0014\u0001\u0015\u0001\u0015\u0001\u0016\u0001\u0016\u0001"+
		"\u0017\u0001\u0017\u0001\u0018\u0001\u0018\u0005\u0018\u00c0\b\u0018\n"+
		"\u0018\f\u0018\u00c3\t\u0018\u0001\u0019\u0001\u0019\u0001\u0019\u0001"+
		"\u001a\u0001\u001a\u0001\u001a\u0001\u001b\u0004\u001b\u00cc\b\u001b\u000b"+
		"\u001b\f\u001b\u00cd\u0001\u001b\u0001\u001b\u0001\u001c\u0004\u001c\u00d3"+
		"\b\u001c\u000b\u001c\f\u001c\u00d4\u0001\u001c\u0001\u001c\u0001\u001d"+
		"\u0001\u001d\u0001\u001d\u0001\u001d\u0001\u001e\u0001\u001e\u0001\u001e"+
		"\u0001\u001e\u0005\u001e\u00e1\b\u001e\n\u001e\f\u001e\u00e4\t\u001e\u0001"+
		"\u001e\u0001\u001e\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001"+
		"\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001"+
		"\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001"+
		"\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001"+
		"\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001"+
		"\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001"+
		"\u001f\u0003\u001f\u010b\b\u001f\u0001 \u0001 \u0001 \u0001 \u0001 \u0001"+
		" \u0000\u0000!\u0001\u0001\u0003\u0002\u0005\u0003\u0007\u0004\t\u0005"+
		"\u000b\u0006\r\u0007\u000f\b\u0011\t\u0013\n\u0015\u000b\u0017\f\u0019"+
		"\r\u001b\u000e\u001d\u000f\u001f\u0010!\u0011#\u0012%\u0013\'\u0014)\u0015"+
		"+\u0016-\u0017/\u00181\u00193\u001a5\u001b7\u001c9\u001d;\u001e=\u001f"+
		"? A!\u0001\u0000\t\u0001\u000009\u0002\u0000++--\u0002\u0000**//\u0002"+
		"\u0000<<>>\u0002\u0000AZaz\u0003\u000009AZaz\u0002\u0000\t\t  \u0002\u0000"+
		"\n\n\r\r\u0004\u0000\n\n\r\r\"\"\\\\\u0122\u0000\u0001\u0001\u0000\u0000"+
		"\u0000\u0000\u0003\u0001\u0000\u0000\u0000\u0000\u0005\u0001\u0000\u0000"+
		"\u0000\u0000\u0007\u0001\u0000\u0000\u0000\u0000\t\u0001\u0000\u0000\u0000"+
		"\u0000\u000b\u0001\u0000\u0000\u0000\u0000\r\u0001\u0000\u0000\u0000\u0000"+
		"\u000f\u0001\u0000\u0000\u0000\u0000\u0011\u0001\u0000\u0000\u0000\u0000"+
		"\u0013\u0001\u0000\u0000\u0000\u0000\u0015\u0001\u0000\u0000\u0000\u0000"+
		"\u0017\u0001\u0000\u0000\u0000\u0000\u0019\u0001\u0000\u0000\u0000\u0000"+
		"\u001b\u0001\u0000\u0000\u0000\u0000\u001d\u0001\u0000\u0000\u0000\u0000"+
		"\u001f\u0001\u0000\u0000\u0000\u0000!\u0001\u0000\u0000\u0000\u0000#\u0001"+
		"\u0000\u0000\u0000\u0000%\u0001\u0000\u0000\u0000\u0000\'\u0001\u0000"+
		"\u0000\u0000\u0000)\u0001\u0000\u0000\u0000\u0000+\u0001\u0000\u0000\u0000"+
		"\u0000-\u0001\u0000\u0000\u0000\u0000/\u0001\u0000\u0000\u0000\u00001"+
		"\u0001\u0000\u0000\u0000\u00003\u0001\u0000\u0000\u0000\u00005\u0001\u0000"+
		"\u0000\u0000\u00007\u0001\u0000\u0000\u0000\u00009\u0001\u0000\u0000\u0000"+
		"\u0000;\u0001\u0000\u0000\u0000\u0000=\u0001\u0000\u0000\u0000\u0000?"+
		"\u0001\u0000\u0000\u0000\u0000A\u0001\u0000\u0000\u0000\u0001C\u0001\u0000"+
		"\u0000\u0000\u0003E\u0001\u0000\u0000\u0000\u0005G\u0001\u0000\u0000\u0000"+
		"\u0007J\u0001\u0000\u0000\u0000\tP\u0001\u0000\u0000\u0000\u000bT\u0001"+
		"\u0000\u0000\u0000\rV\u0001\u0000\u0000\u0000\u000fX\u0001\u0000\u0000"+
		"\u0000\u0011b\u0001\u0000\u0000\u0000\u0013s\u0001\u0000\u0000\u0000\u0015"+
		"z\u0001\u0000\u0000\u0000\u0017\u0082\u0001\u0000\u0000\u0000\u0019\u0086"+
		"\u0001\u0000\u0000\u0000\u001b\u0088\u0001\u0000\u0000\u0000\u001d\u008e"+
		"\u0001\u0000\u0000\u0000\u001f\u0099\u0001\u0000\u0000\u0000!\u00a4\u0001"+
		"\u0000\u0000\u0000#\u00a6\u0001\u0000\u0000\u0000%\u00ac\u0001\u0000\u0000"+
		"\u0000\'\u00b3\u0001\u0000\u0000\u0000)\u00b5\u0001\u0000\u0000\u0000"+
		"+\u00b7\u0001\u0000\u0000\u0000-\u00b9\u0001\u0000\u0000\u0000/\u00bb"+
		"\u0001\u0000\u0000\u00001\u00bd\u0001\u0000\u0000\u00003\u00c4\u0001\u0000"+
		"\u0000\u00005\u00c7\u0001\u0000\u0000\u00007\u00cb\u0001\u0000\u0000\u0000"+
		"9\u00d2\u0001\u0000\u0000\u0000;\u00d8\u0001\u0000\u0000\u0000=\u00dc"+
		"\u0001\u0000\u0000\u0000?\u010a\u0001\u0000\u0000\u0000A\u010c\u0001\u0000"+
		"\u0000\u0000CD\u0005(\u0000\u0000D\u0002\u0001\u0000\u0000\u0000EF\u0005"+
		")\u0000\u0000F\u0004\u0001\u0000\u0000\u0000GH\u0005i\u0000\u0000HI\u0005"+
		"f\u0000\u0000I\u0006\u0001\u0000\u0000\u0000JK\u0005w\u0000\u0000KL\u0005"+
		"h\u0000\u0000LM\u0005i\u0000\u0000MN\u0005l\u0000\u0000NO\u0005e\u0000"+
		"\u0000O\b\u0001\u0000\u0000\u0000PQ\u0005f\u0000\u0000QR\u0005o\u0000"+
		"\u0000RS\u0005r\u0000\u0000S\n\u0001\u0000\u0000\u0000TU\u0005;\u0000"+
		"\u0000U\f\u0001\u0000\u0000\u0000VW\u0005,\u0000\u0000W\u000e\u0001\u0000"+
		"\u0000\u0000XY\u0005f\u0000\u0000YZ\u0005i\u0000\u0000Z[\u0005l\u0000"+
		"\u0000[\\\u0005e\u0000\u0000\\]\u0005W\u0000\u0000]^\u0005r\u0000\u0000"+
		"^_\u0005i\u0000\u0000_`\u0005t\u0000\u0000`a\u0005e\u0000\u0000a\u0010"+
		"\u0001\u0000\u0000\u0000bc\u0005f\u0000\u0000cd\u0005i\u0000\u0000de\u0005"+
		"l\u0000\u0000ef\u0005e\u0000\u0000fg\u0005W\u0000\u0000gh\u0005r\u0000"+
		"\u0000hi\u0005i\u0000\u0000ij\u0005t\u0000\u0000jk\u0005e\u0000\u0000"+
		"kl\u0005N\u0000\u0000lm\u0005e\u0000\u0000mn\u0005w\u0000\u0000no\u0005"+
		"l\u0000\u0000op\u0005i\u0000\u0000pq\u0005n\u0000\u0000qr\u0005e\u0000"+
		"\u0000r\u0012\u0001\u0000\u0000\u0000st\u0005a\u0000\u0000tu\u0005c\u0000"+
		"\u0000uv\u0005c\u0000\u0000vw\u0005e\u0000\u0000wx\u0005s\u0000\u0000"+
		"xy\u0005s\u0000\u0000y\u0014\u0001\u0000\u0000\u0000z{\u0005m\u0000\u0000"+
		"{|\u0005o\u0000\u0000|}\u0005d\u0000\u0000}~\u0005i\u0000\u0000~\u007f"+
		"\u0005f\u0000\u0000\u007f\u0080\u0005y\u0000\u0000\u0080\u0016\u0001\u0000"+
		"\u0000\u0000\u0081\u0083\u0007\u0000\u0000\u0000\u0082\u0081\u0001\u0000"+
		"\u0000\u0000\u0083\u0084\u0001\u0000\u0000\u0000\u0084\u0082\u0001\u0000"+
		"\u0000\u0000\u0084\u0085\u0001\u0000\u0000\u0000\u0085\u0018\u0001\u0000"+
		"\u0000\u0000\u0086\u0087\u0007\u0001\u0000\u0000\u0087\u001a\u0001\u0000"+
		"\u0000\u0000\u0088\u0089\u0007\u0002\u0000\u0000\u0089\u001c\u0001\u0000"+
		"\u0000\u0000\u008a\u008b\u0005|\u0000\u0000\u008b\u008f\u0005|\u0000\u0000"+
		"\u008c\u008d\u0005&\u0000\u0000\u008d\u008f\u0005&\u0000\u0000\u008e\u008a"+
		"\u0001\u0000\u0000\u0000\u008e\u008c\u0001\u0000\u0000\u0000\u008f\u001e"+
		"\u0001\u0000\u0000\u0000\u0090\u009a\u0007\u0003\u0000\u0000\u0091\u0092"+
		"\u0005=\u0000\u0000\u0092\u009a\u0005=\u0000\u0000\u0093\u0094\u0005!"+
		"\u0000\u0000\u0094\u009a\u0005=\u0000\u0000\u0095\u0096\u0005>\u0000\u0000"+
		"\u0096\u009a\u0005=\u0000\u0000\u0097\u0098\u0005<\u0000\u0000\u0098\u009a"+
		"\u0005=\u0000\u0000\u0099\u0090\u0001\u0000\u0000\u0000\u0099\u0091\u0001"+
		"\u0000\u0000\u0000\u0099\u0093\u0001\u0000\u0000\u0000\u0099\u0095\u0001"+
		"\u0000\u0000\u0000\u0099\u0097\u0001\u0000\u0000\u0000\u009a \u0001\u0000"+
		"\u0000\u0000\u009b\u009c\u0005t\u0000\u0000\u009c\u009d\u0005r\u0000\u0000"+
		"\u009d\u009e\u0005u\u0000\u0000\u009e\u00a5\u0005e\u0000\u0000\u009f\u00a0"+
		"\u0005f\u0000\u0000\u00a0\u00a1\u0005a\u0000\u0000\u00a1\u00a2\u0005l"+
		"\u0000\u0000\u00a2\u00a3\u0005s\u0000\u0000\u00a3\u00a5\u0005e\u0000\u0000"+
		"\u00a4\u009b\u0001\u0000\u0000\u0000\u00a4\u009f\u0001\u0000\u0000\u0000"+
		"\u00a5\"\u0001\u0000\u0000\u0000\u00a6\u00a7\u0005B\u0000\u0000\u00a7"+
		"\u00a8\u0005R\u0000\u0000\u00a8\u00a9\u0005E\u0000\u0000\u00a9\u00aa\u0005"+
		"A\u0000\u0000\u00aa\u00ab\u0005K\u0000\u0000\u00ab$\u0001\u0000\u0000"+
		"\u0000\u00ac\u00ad\u0005R\u0000\u0000\u00ad\u00ae\u0005A\u0000\u0000\u00ae"+
		"\u00af\u0005N\u0000\u0000\u00af\u00b0\u0005D\u0000\u0000\u00b0\u00b1\u0005"+
		"O\u0000\u0000\u00b1\u00b2\u0005M\u0000\u0000\u00b2&\u0001\u0000\u0000"+
		"\u0000\u00b3\u00b4\u0005=\u0000\u0000\u00b4(\u0001\u0000\u0000\u0000\u00b5"+
		"\u00b6\u0005[\u0000\u0000\u00b6*\u0001\u0000\u0000\u0000\u00b7\u00b8\u0005"+
		"]\u0000\u0000\u00b8,\u0001\u0000\u0000\u0000\u00b9\u00ba\u0005{\u0000"+
		"\u0000\u00ba.\u0001\u0000\u0000\u0000\u00bb\u00bc\u0005}\u0000\u0000\u00bc"+
		"0\u0001\u0000\u0000\u0000\u00bd\u00c1\u0007\u0004\u0000\u0000\u00be\u00c0"+
		"\u0007\u0005\u0000\u0000\u00bf\u00be\u0001\u0000\u0000\u0000\u00c0\u00c3"+
		"\u0001\u0000\u0000\u0000\u00c1\u00bf\u0001\u0000\u0000\u0000\u00c1\u00c2"+
		"\u0001\u0000\u0000\u0000\u00c22\u0001\u0000\u0000\u0000\u00c3\u00c1\u0001"+
		"\u0000\u0000\u0000\u00c4\u00c5\u0005+\u0000\u0000\u00c5\u00c6\u0005+\u0000"+
		"\u0000\u00c64\u0001\u0000\u0000\u0000\u00c7\u00c8\u0005-\u0000\u0000\u00c8"+
		"\u00c9\u0005-\u0000\u0000\u00c96\u0001\u0000\u0000\u0000\u00ca\u00cc\u0007"+
		"\u0006\u0000\u0000\u00cb\u00ca\u0001\u0000\u0000\u0000\u00cc\u00cd\u0001"+
		"\u0000\u0000\u0000\u00cd\u00cb\u0001\u0000\u0000\u0000\u00cd\u00ce\u0001"+
		"\u0000\u0000\u0000\u00ce\u00cf\u0001\u0000\u0000\u0000\u00cf\u00d0\u0006"+
		"\u001b\u0000\u0000\u00d08\u0001\u0000\u0000\u0000\u00d1\u00d3\u0007\u0007"+
		"\u0000\u0000\u00d2\u00d1\u0001\u0000\u0000\u0000\u00d3\u00d4\u0001\u0000"+
		"\u0000\u0000\u00d4\u00d2\u0001\u0000\u0000\u0000\u00d4\u00d5\u0001\u0000"+
		"\u0000\u0000\u00d5\u00d6\u0001\u0000\u0000\u0000\u00d6\u00d7\u0006\u001c"+
		"\u0000\u0000\u00d7:\u0001\u0000\u0000\u0000\u00d8\u00d9\u0005\'\u0000"+
		"\u0000\u00d9\u00da\t\u0000\u0000\u0000\u00da\u00db\u0005\'\u0000\u0000"+
		"\u00db<\u0001\u0000\u0000\u0000\u00dc\u00e2\u0005\"\u0000\u0000\u00dd"+
		"\u00e1\b\b\u0000\u0000\u00de\u00df\u0005\\\u0000\u0000\u00df\u00e1\t\u0000"+
		"\u0000\u0000\u00e0\u00dd\u0001\u0000\u0000\u0000\u00e0\u00de\u0001\u0000"+
		"\u0000\u0000\u00e1\u00e4\u0001\u0000\u0000\u0000\u00e2\u00e0\u0001\u0000"+
		"\u0000\u0000\u00e2\u00e3\u0001\u0000\u0000\u0000\u00e3\u00e5\u0001\u0000"+
		"\u0000\u0000\u00e4\u00e2\u0001\u0000\u0000\u0000\u00e5\u00e6\u0005\"\u0000"+
		"\u0000\u00e6>\u0001\u0000\u0000\u0000\u00e7\u00e8\u0005i\u0000\u0000\u00e8"+
		"\u00e9\u0005n\u0000\u0000\u00e9\u00ea\u0005t\u0000\u0000\u00ea\u010b\u0005"+
		" \u0000\u0000\u00eb\u00ec\u0005d\u0000\u0000\u00ec\u00ed\u0005o\u0000"+
		"\u0000\u00ed\u00ee\u0005u\u0000\u0000\u00ee\u00ef\u0005b\u0000\u0000\u00ef"+
		"\u00f0\u0005l\u0000\u0000\u00f0\u00f1\u0005e\u0000\u0000\u00f1\u010b\u0005"+
		" \u0000\u0000\u00f2\u00f3\u0005s\u0000\u0000\u00f3\u00f4\u0005t\u0000"+
		"\u0000\u00f4\u00f5\u0005r\u0000\u0000\u00f5\u00f6\u0005i\u0000\u0000\u00f6"+
		"\u00f7\u0005n\u0000\u0000\u00f7\u00f8\u0005g\u0000\u0000\u00f8\u010b\u0005"+
		" \u0000\u0000\u00f9\u00fa\u0005b\u0000\u0000\u00fa\u00fb\u0005o\u0000"+
		"\u0000\u00fb\u00fc\u0005o\u0000\u0000\u00fc\u00fd\u0005l\u0000\u0000\u00fd"+
		"\u00fe\u0005e\u0000\u0000\u00fe\u00ff\u0005a\u0000\u0000\u00ff\u0100\u0005"+
		"n\u0000\u0000\u0100\u010b\u0005 \u0000\u0000\u0101\u0102\u0005c\u0000"+
		"\u0000\u0102\u0103\u0005h\u0000\u0000\u0103\u0104\u0005a\u0000\u0000\u0104"+
		"\u0105\u0005r\u0000\u0000\u0105\u010b\u0005 \u0000\u0000\u0106\u0107\u0005"+
		"m\u0000\u0000\u0107\u0108\u0005a\u0000\u0000\u0108\u0109\u0005p\u0000"+
		"\u0000\u0109\u010b\u0005 \u0000\u0000\u010a\u00e7\u0001\u0000\u0000\u0000"+
		"\u010a\u00eb\u0001\u0000\u0000\u0000\u010a\u00f2\u0001\u0000\u0000\u0000"+
		"\u010a\u00f9\u0001\u0000\u0000\u0000\u010a\u0101\u0001\u0000\u0000\u0000"+
		"\u010a\u0106\u0001\u0000\u0000\u0000\u010b@\u0001\u0000\u0000\u0000\u010c"+
		"\u010d\u0005e\u0000\u0000\u010d\u010e\u0005l\u0000\u0000\u010e\u010f\u0005"+
		"s\u0000\u0000\u010f\u0110\u0005e\u0000\u0000\u0110\u0111\u0005 \u0000"+
		"\u0000\u0111B\u0001\u0000\u0000\u0000\u000b\u0000\u0084\u008e\u0099\u00a4"+
		"\u00c1\u00cd\u00d4\u00e0\u00e2\u010a\u0001\u0006\u0000\u0000";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}