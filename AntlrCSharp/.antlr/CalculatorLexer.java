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
		NUMBER=1, OPERATOR1=2, OPERATOR2=3, LOGOPERATOR=4, WHITESPACE=5, NEWLINE=6, 
		LPAREN=7, RPAREN=8, IF=9, ELSE=10, TAB=11;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"NUMBER", "OPERATOR1", "OPERATOR2", "LOGOPERATOR", "WHITESPACE", "NEWLINE", 
			"LPAREN", "RPAREN", "IF", "ELSE", "TAB"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, null, null, null, "'('", "')'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "NUMBER", "OPERATOR1", "OPERATOR2", "LOGOPERATOR", "WHITESPACE", 
			"NEWLINE", "LPAREN", "RPAREN", "IF", "ELSE", "TAB"
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
		"\u0004\u0000\u000bI\u0006\uffff\uffff\u0002\u0000\u0007\u0000\u0002\u0001"+
		"\u0007\u0001\u0002\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004"+
		"\u0007\u0004\u0002\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007"+
		"\u0007\u0007\u0002\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0001\u0000"+
		"\u0004\u0000\u0019\b\u0000\u000b\u0000\f\u0000\u001a\u0001\u0001\u0001"+
		"\u0001\u0001\u0002\u0001\u0002\u0001\u0003\u0001\u0003\u0001\u0003\u0001"+
		"\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0003"+
		"\u0003*\b\u0003\u0001\u0004\u0004\u0004-\b\u0004\u000b\u0004\f\u0004."+
		"\u0001\u0004\u0001\u0004\u0001\u0005\u0003\u00054\b\u0005\u0001\u0005"+
		"\u0001\u0005\u0004\u00058\b\u0005\u000b\u0005\f\u00059\u0001\u0006\u0001"+
		"\u0006\u0001\u0007\u0001\u0007\u0001\b\u0001\b\u0001\b\u0001\t\u0001\t"+
		"\u0001\t\u0001\t\u0001\t\u0001\n\u0001\n\u0000\u0000\u000b\u0001\u0001"+
		"\u0003\u0002\u0005\u0003\u0007\u0004\t\u0005\u000b\u0006\r\u0007\u000f"+
		"\b\u0011\t\u0013\n\u0015\u000b\u0001\u0000\u0004\u0001\u000009\u0002\u0000"+
		"++--\u0002\u0000**//\u0002\u0000<<>>Q\u0000\u0001\u0001\u0000\u0000\u0000"+
		"\u0000\u0003\u0001\u0000\u0000\u0000\u0000\u0005\u0001\u0000\u0000\u0000"+
		"\u0000\u0007\u0001\u0000\u0000\u0000\u0000\t\u0001\u0000\u0000\u0000\u0000"+
		"\u000b\u0001\u0000\u0000\u0000\u0000\r\u0001\u0000\u0000\u0000\u0000\u000f"+
		"\u0001\u0000\u0000\u0000\u0000\u0011\u0001\u0000\u0000\u0000\u0000\u0013"+
		"\u0001\u0000\u0000\u0000\u0000\u0015\u0001\u0000\u0000\u0000\u0001\u0018"+
		"\u0001\u0000\u0000\u0000\u0003\u001c\u0001\u0000\u0000\u0000\u0005\u001e"+
		"\u0001\u0000\u0000\u0000\u0007)\u0001\u0000\u0000\u0000\t,\u0001\u0000"+
		"\u0000\u0000\u000b7\u0001\u0000\u0000\u0000\r;\u0001\u0000\u0000\u0000"+
		"\u000f=\u0001\u0000\u0000\u0000\u0011?\u0001\u0000\u0000\u0000\u0013B"+
		"\u0001\u0000\u0000\u0000\u0015G\u0001\u0000\u0000\u0000\u0017\u0019\u0007"+
		"\u0000\u0000\u0000\u0018\u0017\u0001\u0000\u0000\u0000\u0019\u001a\u0001"+
		"\u0000\u0000\u0000\u001a\u0018\u0001\u0000\u0000\u0000\u001a\u001b\u0001"+
		"\u0000\u0000\u0000\u001b\u0002\u0001\u0000\u0000\u0000\u001c\u001d\u0007"+
		"\u0001\u0000\u0000\u001d\u0004\u0001\u0000\u0000\u0000\u001e\u001f\u0007"+
		"\u0002\u0000\u0000\u001f\u0006\u0001\u0000\u0000\u0000 !\u0005=\u0000"+
		"\u0000!*\u0005=\u0000\u0000\"#\u0005>\u0000\u0000#*\u0005=\u0000\u0000"+
		"$%\u0005<\u0000\u0000%*\u0005=\u0000\u0000&\'\u0005!\u0000\u0000\'*\u0005"+
		"=\u0000\u0000(*\u0007\u0003\u0000\u0000) \u0001\u0000\u0000\u0000)\"\u0001"+
		"\u0000\u0000\u0000)$\u0001\u0000\u0000\u0000)&\u0001\u0000\u0000\u0000"+
		")(\u0001\u0000\u0000\u0000*\b\u0001\u0000\u0000\u0000+-\u0005 \u0000\u0000"+
		",+\u0001\u0000\u0000\u0000-.\u0001\u0000\u0000\u0000.,\u0001\u0000\u0000"+
		"\u0000./\u0001\u0000\u0000\u0000/0\u0001\u0000\u0000\u000001\u0006\u0004"+
		"\u0000\u00001\n\u0001\u0000\u0000\u000024\u0005\r\u0000\u000032\u0001"+
		"\u0000\u0000\u000034\u0001\u0000\u0000\u000045\u0001\u0000\u0000\u0000"+
		"58\u0005\n\u0000\u000068\u0005\r\u0000\u000073\u0001\u0000\u0000\u0000"+
		"76\u0001\u0000\u0000\u000089\u0001\u0000\u0000\u000097\u0001\u0000\u0000"+
		"\u00009:\u0001\u0000\u0000\u0000:\f\u0001\u0000\u0000\u0000;<\u0005(\u0000"+
		"\u0000<\u000e\u0001\u0000\u0000\u0000=>\u0005)\u0000\u0000>\u0010\u0001"+
		"\u0000\u0000\u0000?@\u0005i\u0000\u0000@A\u0005f\u0000\u0000A\u0012\u0001"+
		"\u0000\u0000\u0000BC\u0005e\u0000\u0000CD\u0005l\u0000\u0000DE\u0005s"+
		"\u0000\u0000EF\u0005e\u0000\u0000F\u0014\u0001\u0000\u0000\u0000GH\u0005"+
		"\t\u0000\u0000H\u0016\u0001\u0000\u0000\u0000\u0007\u0000\u001a).379\u0001"+
		"\u0006\u0000\u0000";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}