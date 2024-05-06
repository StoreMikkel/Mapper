using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using AntlrCSharp;
using static CalculatorParser;
using System.IO;

namespace AntlrCSharp
{
    public class BasicCalculatorVisitor : CalculatorBaseVisitor<object>
    {
        //Value table
        private Dictionary<string, object> variables = new Dictionary<string, object>();
        //List of write files
        private HashSet<string> writtenFiles = new HashSet<string>();

    public override object VisitInput(CalculatorParser.InputContext context)
    {
        return VisitChildren(context);
    }

    public override object VisitStatement(CalculatorParser.StatementContext context)
    {
        // Determine the type of statement and delegate to the appropriate method
        if (context.calculation() != null)
        {
            return VisitCalculation(context.calculation());
        }
        else if (context.ifStatement() != null)
        {
            return VisitIfStatement(context.ifStatement());
        }
        else if (context.whileStatement() != null)
        {
            return VisitWhileStatement(context.whileStatement());
        }
        else if (context.variableDeclaration() != null){
            return VisitVariableDeclaration(context.variableDeclaration());
        }
        else if (context.variableAssignment() != null){
            return VisitVariableAssignment(context.variableAssignment());
        }
        else if (context.forLoop() != null){
            return VisitForLoop(context.forLoop());
        }
        else if (context.crementer() != null){
            return VisitCrementer(context.crementer());
        }
        else if (context.arrayDeclaration() != null){
            return VisitArrayDeclaration(context.arrayDeclaration());
        }
        else if(context.arrayAccess() != null){
            return VisitArrayAccess(context.arrayAccess());
        }
        else if(context.arrayAssignement() != null){
            return VisitArrayAssignement(context.arrayAssignement());
        }
        else if(context.arrayDeclaration2d() != null){
            return VisitArrayDeclaration2d(context.arrayDeclaration2d());
        }
        else if(context.arrayAssignment2d() != null){
            return VisitArrayAssignment2d(context.arrayAssignment2d());
        }
        else if(context.arrayAccess2d() != null){
            return VisitArrayAccess2d(context.arrayAccess2d());
        }
        else if(context.breakStatement() != null){
            return VisitBreakStatement(context.breakStatement());
        }
        else if(context.fileWriteStatement() != null){
            return VisitFileWriteStatement(context.fileWriteStatement());
        }
        else if(context.fileWriteNewline() != null){
            return VisitFileWriteNewline(context.fileWriteNewline());
        }
        else{
            return "Unsupported Statement xdd";
        }
        
        
        

        
    }

    public override object VisitCalculation(CalculatorParser.CalculationContext context)
    {
        object result = Visit(context.expression());
        Console.WriteLine("Result: " + result);
        return result;
    }

    public override object VisitExpression(CalculatorParser.ExpressionContext context)
{
        if (context.IDENTIFIER() != null)
            {
                string identifier = context.IDENTIFIER().GetText();
                if (variables.ContainsKey(identifier))
                {
                    return variables[identifier];
                }
                else
                {
                    throw new Exception("Variable " + identifier + " not defined.");
                }
            }else if (context.STRING_LITERAL() != null)
        {
            return context.STRING_LITERAL().GetText(); // Return the string literal
        }

    if (context.OPERATOR1() != null)
    {
        object left = Visit(context.expression());
        object right = Visit(context.term());
        if (left == null || right == null)
            throw new InvalidOperationException("Invalid expression: sub-expression is null.");

        string op = context.OPERATOR1().GetText();
        if (op == "+") return (dynamic)left + (dynamic)right;
        else if (op == "-") return (dynamic)left - (dynamic)right;
    }
    else if (context.COMPARISON_OPERATOR() != null)
    {
        object left = Visit(context.expression());
        object right = Visit(context.term());
        if (left == null || right == null)
            throw new InvalidOperationException("Invalid expression: sub-expression is null.");

        string op = context.COMPARISON_OPERATOR().GetText();
        switch (op)
        {
            
            case ">": return (dynamic)left > (dynamic)right;
            case "<": return (dynamic)left < (dynamic)right;
            case "==": return (dynamic)left == (dynamic)right;
            case "!=": return (dynamic)left != (dynamic)right;
            case ">=": return (dynamic)left >= (dynamic)right;
            case "<=": return (dynamic)left <= (dynamic)right;
            default:
                throw new InvalidOperationException("Invalid comparison operator: " + op);
        }
    }
    else if(context.BOOLEAN_LITERAL() != null){
        return bool.Parse(context.BOOLEAN_LITERAL().GetText());
    }
    if(context.arrayAccess() != null){
        return Visit(context.arrayAccess());
    }
    if(context.arrayAccess2d() != null){
            return Visit(context.arrayAccess2d());
    }
    if(context.randomStatement() != null){
            return VisitRandomStatement(context.randomStatement());
    }
    return Visit(context.term());
}

    public override object VisitTerm(CalculatorParser.TermContext context)
    {

        if (context.IDENTIFIER() != null)
            {
                string identifier = context.IDENTIFIER().GetText();
                if (variables.ContainsKey(identifier))
                {
                    return variables[identifier];
                }
                else
                {
                    throw new Exception("Variable " + identifier + " not defined.");
                }
            }else if (context.STRING_LITERAL() != null)
        {
            return context.STRING_LITERAL().GetText(); // Return the string literal
        }
        if (context.OPERATOR2() != null)
        {
            object left = Visit(context.term());
            object right = Visit(context.factor());
            string op = context.OPERATOR2().GetText();
            if (op == "*") return (dynamic)left * (dynamic)right;
            else if (op == "/") return (dynamic)left / (dynamic)right;
        }
        else if(context.BOOLEAN_LITERAL() != null){
        return bool.Parse(context.BOOLEAN_LITERAL().GetText());
    }
        if(context.arrayAccess() != null){
            return Visit(context.arrayAccess());
        }
        if(context.arrayAccess2d() != null){
            return Visit(context.arrayAccess2d());
        }
        if(context.randomStatement() != null){
            return VisitRandomStatement(context.randomStatement());
    }
        return Visit(context.factor());
    }

    public override object VisitFactor(CalculatorParser.FactorContext context)
    {
        if (context.IDENTIFIER() != null)
            {
                string identifier = context.IDENTIFIER().GetText();
                if (variables.ContainsKey(identifier))
                {
                    return variables[identifier];
                }
                else
                {
                    throw new Exception("Variable " + identifier + " not defined.");
                }
            }else if (context.STRING_LITERAL() != null)
        {
            return context.STRING_LITERAL().GetText(); // Return the string literal
        }
        else if(context.BOOLEAN_LITERAL() != null){
            return bool.Parse(context.BOOLEAN_LITERAL().GetText());
        }
        if (context.number() != null)
        {
            return Visit(context.number());
        }
        if(context.arrayAccess() != null){
            return Visit(context.arrayAccess());
        }
        if(context.arrayAccess2d() != null){
            return Visit(context.arrayAccess2d());
        }
        if(context.randomStatement() != null){
            return VisitRandomStatement(context.randomStatement());
        }
        else
        {
            return Visit(context.expression());
        }
    }

    public override object VisitIfStatement(CalculatorParser.IfStatementContext context)
{
    //Initialize conditionvalue with first expression
    bool conditionValue = (bool)Visit(context.expression(0));
    
    //Iterate over any other expression and apply boolean operators
    for(int i = 1; i <context.expression().Length; i++){
        bool expressionValue = (bool)Visit(context.expression(i));
        conditionValue = ApplyBooleanOperator(conditionValue, expressionValue, context.BOOLEANOPERATORS(i-1).GetText());

    }

    int elseTokenIndex = context.ELSE()?.Symbol.TokenIndex ?? int.MaxValue;

    if (conditionValue)
    {
        foreach(var statement in context.statement()){
            if(statement.Stop.TokenIndex < elseTokenIndex){
                Visit(statement);
            }
        }
        
    }
    else if (context.ELSE() != null) // Check if 'else' block exists
    {
        foreach(var statement in context.statement()){
            if(statement.Stop.TokenIndex > elseTokenIndex){
                Visit(statement);
            }
        }
        
    }
    return false; // No 'else' block and condition evaluates to false
}

// Function to apply the boolean operator
bool ApplyBooleanOperator(bool operand1, bool operand2, string booleanOperator)
{
    switch (booleanOperator)
    {
        case "&&":
            return operand1 && operand2;
        case "||":
            return operand1 || operand2;
        // Add more cases for other operators if needed
        default:
            throw new ArgumentException("Invalid boolean operator");
    }
}

    public override object VisitWhileStatement(CalculatorParser.WhileStatementContext context)
{
    object result = null;
    bool breakflag = false;

    while ((dynamic)Visit(context.expression()) is true && breakflag is false){
        foreach (var statement in context.statement())
         {
             result = Visit(statement);
             //Check for breaks
             if(result == null){
                 breakflag = true;
            }
                
        }
    }
    
    return result;
}


public override object VisitVariableDeclaration(CalculatorParser.VariableDeclarationContext context)
    {
        string identifier = context.IDENTIFIER().GetText();
        object value = Visit(context.expression());

        if(value is int && context.TYPE().GetText() == "double " ){
            value = (double)(int)value;
        }

        else if(value is double && context.TYPE().GetText() != "double ") {
            throw new Exception("Type mismatch in variable declaration, value is double, declarations is " + context.TYPE().GetText());
        }else if (value is int && context.TYPE().GetText() != "int "){
            throw new Exception ("Type mismatch in variable declaration, value is int, declarations is " + context.TYPE().GetText());
        }else if (value is string && context.TYPE().GetText() != "string "){
            throw new Exception ("Type mismatch in variable declaration, value is string, declarations is " + context.TYPE().GetText());
        }else if (value is Boolean && context.TYPE().GetText() != "boolean "){
            throw new Exception ("Type mismatch in variable declaration, value is boolean, declarations is " + context.TYPE().GetText());
        }

        
        variables[identifier] = value;
        return value;
    }

        public override object VisitVariableAssignment(CalculatorParser.VariableAssignmentContext context)
    {
        string identifier = context.IDENTIFIER().GetText();
        object value = Visit(context.expression());

        // Add type checking for variable assignment
        if (value is double && variables[identifier] is int)
        {
            // If the assigned value is double but the variable type is int, convert it to int
            variables[identifier] = (int)(double)value;
        }
        else if (value is int && variables[identifier] is double)
        {
            // If the assigned value is int but the variable type is double, convert it to double
            variables[identifier] = (double)(int)value;
        }
        else if (value.GetType() != variables[identifier].GetType())
        {
            // If the assigned value and variable type do not match, throw an exception
            throw new Exception("Type mismatch in variable assignment for variable " + identifier);
        }

        variables[identifier] = value;
        return value;
    }

    public override object VisitNumber(CalculatorParser.NumberContext context)
    {
        string numberText = context.NUMBER().GetText();

        if(int.TryParse(numberText, out int intValue)){
            return intValue;
        }
        if(double.TryParse(numberText, out double doublevalue)){
            return doublevalue;
        }
        return 0;
    }

    public override object VisitCrementer(CalculatorParser.CrementerContext context){
        
        string identifier = context.IDENTIFIER().GetText();
        int currentValue = Convert.ToInt32(variables[identifier]);
       
        if (context.INCREMENTER() != null)
        {
            currentValue++;
            variables[identifier] = currentValue;
        }
        else if (context.DECREMENTER() != null)
        {
            currentValue--;
            variables[identifier] = currentValue;
        }
        return currentValue;
    }

    public override object VisitForLoop(CalculatorParser.ForLoopContext context){

       bool breakFlag = false;
       object result = null;
       Visit(context.variableDeclaration());
       while ((bool)Visit(context.compare()) && breakFlag == false){
            // Visit the statements inside the for loop
            foreach (var statement in context.statement())
            {
                result = Visit(statement);
                if(result == null){
                    breakFlag = true;
                }
            }
            // Visit the increment/decrement part of the for loop
            Visit(context.crementer());
        }
        return result;
    }

    public override object VisitCompare(CalculatorParser.CompareContext context){
        
        if (context.COMPARISON_OPERATOR() != null)
        {
            object left = Visit(context.expression());
            object right = Visit(context.term());
            if (left == null || right == null)
                throw new InvalidOperationException("Invalid expression: sub-expression is null.");

            string op = context.COMPARISON_OPERATOR().GetText();
            switch (op)
            {
                case ">": return (dynamic)left > (dynamic)right;
                case "<": return (dynamic)left < (dynamic)right;
                case "==": return (dynamic)left == (dynamic)right;
                case "!=": return (dynamic)left != (dynamic)right;
                case ">=": return (dynamic)left >= (dynamic)right;
                case "<=": return (dynamic)left <= (dynamic)right;
                default:
                    throw new InvalidOperationException("Invalid comparison operator: " + op);
            }
        }
        return 0;
    }

    public override object VisitArrayDeclaration(CalculatorParser.ArrayDeclarationContext context){
        Console.WriteLine("Visiting array");
        string identifier = context.IDENTIFIER().GetText();
        List<object> valuesFromArray = new List<object>();
        
        if(context.expression().Length > 0){
            Console.WriteLine("Expression is there " + context.expression().Length);
            
            foreach(var expression in context.expression()){
                object value = Visit(expression);

                if(value is int && context.TYPE().GetText() == "double " ){
                    value = (double)(int)value;
                }
                if(value is double && context.TYPE().GetText() != "double ") {
                    throw new Exception("Type mismatch in variable declaration, value is double, declarations is " + context.TYPE().GetText());
                }else if (value is int && context.TYPE().GetText() != "int "){
                    throw new Exception ("Type mismatch in variable declaration, value is int, declarations is " + context.TYPE().GetText());
                }else if (value is string && context.TYPE().GetText() != "string "){
                    throw new Exception ("Type mismatch in variable declaration, value is string, declarations is " + context.TYPE().GetText());
                }else if (value is Boolean && context.TYPE().GetText() != "boolean "){
                    throw new Exception ("Type mismatch in variable declaration, value is boolean, declarations is " + context.TYPE().GetText());
                }

                valuesFromArray.Add(value);
            }
            variables[identifier] = valuesFromArray.ToArray();
        }else{
            variables[identifier] = valuesFromArray.ToArray();
        }
                
        return valuesFromArray.ToArray();
    }
    public override object VisitArrayAccess(CalculatorParser.ArrayAccessContext context){
        string identifier = context.IDENTIFIER(0).GetText();
        object indexValue;
        if(context.IDENTIFIER(1) != null){
            indexValue = variables[context.IDENTIFIER(1).GetText()];
        }else {
            indexValue = Visit(context.number());
        }
        
        int index = (int)indexValue; 
        object[] array = (object[])variables[identifier];
        
    
        return array[index];
    }
    
    public override object VisitArrayAssignement(CalculatorParser.ArrayAssignementContext context){
        string identifier = context.IDENTIFIER(0).GetText();

        object[] array = (object[])variables[identifier];
        
        object value = Visit(context.expression());
        
        object indexValue;
        if(context.IDENTIFIER(1) != null){
            indexValue = variables[context.IDENTIFIER(1).GetText()];
        }else {
            indexValue = Visit(context.number());
        }
        int index = (int)indexValue;
        
        //Cast ints to doubles
        if (value.GetType() == typeof(int) && array[index].GetType() == typeof(double)){
            value = Convert.ToDouble(value);
            array[index] = value;
        }
        //Type checking
        if (value.GetType() != array[index].GetType())
        {
            throw new Exception("Type mismatch in variable assignment for variable " + identifier);
        }

        array[index] = value;  
        
        variables[identifier] = array;
        return value;
    }

    public override object VisitArrayDeclaration2d(CalculatorParser.ArrayDeclaration2dContext context){
        Console.WriteLine("Visiting 2darray");
        string identifier = context.IDENTIFIER(0).GetText();

        object rowIndex;
        if(context.IDENTIFIER(1) != null){
            rowIndex = variables[context.IDENTIFIER(1).GetText()];
        }else {
            rowIndex = Visit(context.number(0));
        }

        object columnIndex;
        if(context.IDENTIFIER(2) != null){
            columnIndex = variables[context.IDENTIFIER(2).GetText()];
        }else {
            columnIndex = Visit(context.number(1));
        }

        int rows = (int)rowIndex;
        int columns = (int)columnIndex;


        int bracketAmount = context.LEFTCURLYBRACKET().Length - 1;
        int expressionLength = context.expression().Length;
        
        
        object[,] array2d = new object[rows, columns];

        //If values are initialized, check if there is as many expressions as declared in '[,]'
        if(expressionLength > 0){
            if(rows != bracketAmount){
                throw new Exception("Bracket faggot, rows is " + rows + " rows declared " + bracketAmount);
            }
            if(columns != expressionLength/bracketAmount){
                throw new Exception("Bracket faggot columns is " + columns + " columns declared " + expressionLength/bracketAmount);
            }
            //Create array with declared values
            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    object value = Visit(context.expression(counter));
                    array2d[i,j] = value;
                    counter++;
                    
                }
            }
        }
        variables[identifier] = array2d;

        return array2d;
    }

        public override object VisitArrayAssignment2d(CalculatorParser.ArrayAssignment2dContext context)
        {
            string identifier = context.IDENTIFIER(0).GetText();
            object[,] array = (object[,])variables[identifier];
            
            object rowIndex;
            if(context.IDENTIFIER(1) != null){
                rowIndex = variables[context.IDENTIFIER(1).GetText()];
            }else {
                rowIndex = Visit(context.number(0));
            }

            object columnIndex;
            if(context.IDENTIFIER(2) != null){
                columnIndex = variables[context.IDENTIFIER(2).GetText()];
            }else {
                columnIndex = Visit(context.number(1));
            }

            int rows = (int)rowIndex;
            int columns = (int)columnIndex;
            
            object value = Visit(context.expression());
            array[rows, columns] = value;
            variables[identifier] = array;
            
            
            return value;
        }

        public override object VisitArrayAccess2d(CalculatorParser.ArrayAccess2dContext context)
        {
            string identifier = context.IDENTIFIER(0).GetText();
            
            object rowIndex;
            if(context.IDENTIFIER(1) != null){
                rowIndex = variables[context.IDENTIFIER(1).GetText()];
            }else {
                rowIndex = Visit(context.number(0));
            }

            object columnIndex;
            if(context.IDENTIFIER(2) != null){
                columnIndex = variables[context.IDENTIFIER(2).GetText()];
            }else {
                columnIndex = Visit(context.number(1));
            }

            int row = (int)rowIndex;
            int columns = (int)columnIndex;
            
                       
            object[,] array = (object[,])variables[identifier];
            return array[row, columns];
        }

        public override object VisitBreakStatement(CalculatorParser.BreakStatementContext context){
            //throw new Exception();
            return null;
        }

        public override object VisitRandomStatement(CalculatorParser.RandomStatementContext context)
        {
            Random number = new Random();
            string number1String;
            object number1;

            if(context.expression(0) != null && context.children[2].GetType() == context.expression(0).GetType()){
                number1 = Visit(context.expression(0));
                number1String = number1.ToString();
            }else{
                number1String = context.number(0).GetText();
            }
            
            object number2;
            string number2String;
            if(context.expression(0) != null && context.children[4].GetType() == context.expression(0).GetType() && context.children[2].GetType() != context.expression(0).GetType()){
                number2 = Visit(context.expression(0));
                number2String = number2.ToString();
            }else if(context.expression(0) != null && context.children[4].GetType() == context.expression(0).GetType() && context.children[2].GetType() == context.expression(0).GetType()){
                number2 = Visit(context.expression(1));
                number2String = number2.ToString();
            }
            else if(context.children[2].GetType() == context.expression().GetType()){
                number2String = context.number(0).GetText();
            }
            else{
                number2String = context.number(1).GetText();
            }
            
            int numberToUse1 = int.Parse(number1String);
            int numberToUse2 = int.Parse(number2String);
            

            int randomNumber = number.Next(numberToUse1, numberToUse2);

            //Console.WriteLine("Random number generated: " + randomNumber);
            return randomNumber;
        }

        public override object VisitFileWriteStatement(CalculatorParser.FileWriteStatementContext context){

            string textToWrite;
            string fileName;
            if(context.arrayAccess2d() != null){
                textToWrite = (string)Visit(context.arrayAccess2d());
                fileName = context.STRING_LITERAL(0).GetText();
            } else{
                textToWrite = context.STRING_LITERAL(0).GetText();            
                fileName = context.STRING_LITERAL(1).GetText();
            }
            

            fileName = fileName.Substring(1,fileName.Length - 2);
            textToWrite = textToWrite.Substring(1, textToWrite.Length - 2);


            try{
                using(StreamWriter writer = new StreamWriter(fileName, writtenFiles.Contains(fileName))){
                    writer.Write(textToWrite);
                }
                
                writtenFiles.Add(fileName);
            }catch(Exception ex){
                throw new Exception("Cant print to file, yep " + ex);
            }
            return true;
        }

        public override object VisitFileWriteNewline(CalculatorParser.FileWriteNewlineContext context){
            string fileName = context.STRING_LITERAL().GetText();
            fileName = fileName.Substring(1,fileName.Length - 2);
            try{
                using(StreamWriter writer = new StreamWriter(fileName, true)){
                    
                    writer.WriteLine();
                    
                }
                
                writtenFiles.Add(fileName);
            }catch(Exception ex){
                throw new Exception("Cant print to file, yep " + ex);
            }
            return true;

        }

        
        

    }

    
}

