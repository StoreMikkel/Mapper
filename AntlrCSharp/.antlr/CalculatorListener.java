// Generated from c://Users//Mikkel//Documents//UNI//4. Semester//CalculatorLanguage//AntlrCSharp//Calculator.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link CalculatorParser}.
 */
public interface CalculatorListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#input}.
	 * @param ctx the parse tree
	 */
	void enterInput(CalculatorParser.InputContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#input}.
	 * @param ctx the parse tree
	 */
	void exitInput(CalculatorParser.InputContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#calculation}.
	 * @param ctx the parse tree
	 */
	void enterCalculation(CalculatorParser.CalculationContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#calculation}.
	 * @param ctx the parse tree
	 */
	void exitCalculation(CalculatorParser.CalculationContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#number}.
	 * @param ctx the parse tree
	 */
	void enterNumber(CalculatorParser.NumberContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#number}.
	 * @param ctx the parse tree
	 */
	void exitNumber(CalculatorParser.NumberContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#operator}.
	 * @param ctx the parse tree
	 */
	void enterOperator(CalculatorParser.OperatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#operator}.
	 * @param ctx the parse tree
	 */
	void exitOperator(CalculatorParser.OperatorContext ctx);
}