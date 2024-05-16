// Generated from c:/Users/ajapo/Documents/GitHub/CalculatorLanguage/AntlrCSharp/Calculator.g4 by ANTLR 4.13.1
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
	 * Enter a parse tree produced by {@link CalculatorParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterStatement(CalculatorParser.StatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitStatement(CalculatorParser.StatementContext ctx);
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
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void enterIfStatement(CalculatorParser.IfStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void exitIfStatement(CalculatorParser.IfStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#whileStatement}.
	 * @param ctx the parse tree
	 */
	void enterWhileStatement(CalculatorParser.WhileStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#whileStatement}.
	 * @param ctx the parse tree
	 */
	void exitWhileStatement(CalculatorParser.WhileStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#variableDeclaration}.
	 * @param ctx the parse tree
	 */
	void enterVariableDeclaration(CalculatorParser.VariableDeclarationContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#variableDeclaration}.
	 * @param ctx the parse tree
	 */
	void exitVariableDeclaration(CalculatorParser.VariableDeclarationContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#variableAssignment}.
	 * @param ctx the parse tree
	 */
	void enterVariableAssignment(CalculatorParser.VariableAssignmentContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#variableAssignment}.
	 * @param ctx the parse tree
	 */
	void exitVariableAssignment(CalculatorParser.VariableAssignmentContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#forLoop}.
	 * @param ctx the parse tree
	 */
	void enterForLoop(CalculatorParser.ForLoopContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#forLoop}.
	 * @param ctx the parse tree
	 */
	void exitForLoop(CalculatorParser.ForLoopContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#crementer}.
	 * @param ctx the parse tree
	 */
	void enterCrementer(CalculatorParser.CrementerContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#crementer}.
	 * @param ctx the parse tree
	 */
	void exitCrementer(CalculatorParser.CrementerContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#compare}.
	 * @param ctx the parse tree
	 */
	void enterCompare(CalculatorParser.CompareContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#compare}.
	 * @param ctx the parse tree
	 */
	void exitCompare(CalculatorParser.CompareContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#arrayDeclaration}.
	 * @param ctx the parse tree
	 */
	void enterArrayDeclaration(CalculatorParser.ArrayDeclarationContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#arrayDeclaration}.
	 * @param ctx the parse tree
	 */
	void exitArrayDeclaration(CalculatorParser.ArrayDeclarationContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#arrayAssignement}.
	 * @param ctx the parse tree
	 */
	void enterArrayAssignement(CalculatorParser.ArrayAssignementContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#arrayAssignement}.
	 * @param ctx the parse tree
	 */
	void exitArrayAssignement(CalculatorParser.ArrayAssignementContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#arrayAccess}.
	 * @param ctx the parse tree
	 */
	void enterArrayAccess(CalculatorParser.ArrayAccessContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#arrayAccess}.
	 * @param ctx the parse tree
	 */
	void exitArrayAccess(CalculatorParser.ArrayAccessContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#arrayDeclaration2d}.
	 * @param ctx the parse tree
	 */
	void enterArrayDeclaration2d(CalculatorParser.ArrayDeclaration2dContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#arrayDeclaration2d}.
	 * @param ctx the parse tree
	 */
	void exitArrayDeclaration2d(CalculatorParser.ArrayDeclaration2dContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#arrayAssignment2d}.
	 * @param ctx the parse tree
	 */
	void enterArrayAssignment2d(CalculatorParser.ArrayAssignment2dContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#arrayAssignment2d}.
	 * @param ctx the parse tree
	 */
	void exitArrayAssignment2d(CalculatorParser.ArrayAssignment2dContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#arrayAccess2d}.
	 * @param ctx the parse tree
	 */
	void enterArrayAccess2d(CalculatorParser.ArrayAccess2dContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#arrayAccess2d}.
	 * @param ctx the parse tree
	 */
	void exitArrayAccess2d(CalculatorParser.ArrayAccess2dContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#breakStatement}.
	 * @param ctx the parse tree
	 */
	void enterBreakStatement(CalculatorParser.BreakStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#breakStatement}.
	 * @param ctx the parse tree
	 */
	void exitBreakStatement(CalculatorParser.BreakStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#randomStatement}.
	 * @param ctx the parse tree
	 */
	void enterRandomStatement(CalculatorParser.RandomStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#randomStatement}.
	 * @param ctx the parse tree
	 */
	void exitRandomStatement(CalculatorParser.RandomStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#fileWriteStatement}.
	 * @param ctx the parse tree
	 */
	void enterFileWriteStatement(CalculatorParser.FileWriteStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#fileWriteStatement}.
	 * @param ctx the parse tree
	 */
	void exitFileWriteStatement(CalculatorParser.FileWriteStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#fileWriteNewline}.
	 * @param ctx the parse tree
	 */
	void enterFileWriteNewline(CalculatorParser.FileWriteNewlineContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#fileWriteNewline}.
	 * @param ctx the parse tree
	 */
	void exitFileWriteNewline(CalculatorParser.FileWriteNewlineContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#mapDeclaration}.
	 * @param ctx the parse tree
	 */
	void enterMapDeclaration(CalculatorParser.MapDeclarationContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#mapDeclaration}.
	 * @param ctx the parse tree
	 */
	void exitMapDeclaration(CalculatorParser.MapDeclarationContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#mapAccess}.
	 * @param ctx the parse tree
	 */
	void enterMapAccess(CalculatorParser.MapAccessContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#mapAccess}.
	 * @param ctx the parse tree
	 */
	void exitMapAccess(CalculatorParser.MapAccessContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#mapModification}.
	 * @param ctx the parse tree
	 */
	void enterMapModification(CalculatorParser.MapModificationContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#mapModification}.
	 * @param ctx the parse tree
	 */
	void exitMapModification(CalculatorParser.MapModificationContext ctx);
}