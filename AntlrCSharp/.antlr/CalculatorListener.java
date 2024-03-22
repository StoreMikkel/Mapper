// Generated from c://Users//limbo//Documents//SOFTWARE - UNI//P4//CalculatorLanguage//AntlrCSharp//Calculator.g4 by ANTLR 4.13.1
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
	 * Enter a parse tree produced by {@link CalculatorParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterExpression(CalculatorParser.ExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitExpression(CalculatorParser.ExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#term}.
	 * @param ctx the parse tree
	 */
	void enterTerm(CalculatorParser.TermContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#term}.
	 * @param ctx the parse tree
	 */
	void exitTerm(CalculatorParser.TermContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#factor}.
	 * @param ctx the parse tree
	 */
	void enterFactor(CalculatorParser.FactorContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#factor}.
	 * @param ctx the parse tree
	 */
	void exitFactor(CalculatorParser.FactorContext ctx);
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
}