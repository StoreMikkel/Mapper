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
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography;

namespace AntlrCSharp
{
    public class BasicCalculatorVisitor : CalculatorBaseVisitor<object>
    {
        //Value table
        private Dictionary<string, object> variables = new Dictionary<string, object>();
        //Type table
        private Dictionary<string, Type> variableTypes = new Dictionary<string, Type>();
        //List of write files
        private HashSet<string> writtenFiles = new HashSet<string>();
        //Helper function
        private void CheckType(string identifier, Type declaredType, object value){
            Type actualType = value.GetType();

            if (declaredType != actualType){
                throw new Exception($"Type mismatch: variable {identifier} declared as {declaredType.Name} but assigned value is {actualType.Name}");
            }
        }
        //Helper function
        private Type GetTypeFromName(string typeName){
            switch (typeName.ToLower()){
                case "int ":
                    return typeof(int);
                case "double ":
                    return typeof(double);
                case "string ":
                    return typeof(string);
                case "boolean ":
                    return typeof(bool);
                case "char ":
                    return typeof(char);
                case "map ":
                    return typeof(Dictionary<string,char[,]>);
                default:
                    throw new Exception($"Invalid type, what you doin rat: {typeName}");
            }
        }
        //Start of visitor
        public override object VisitInput(CalculatorParser.InputContext context){
            return VisitChildren(context);
        }

        public override object VisitStatement(CalculatorParser.StatementContext context){
            // Determine the type of statement and delegate to the appropriate method
            if (context.calculation() != null){
                return VisitCalculation(context.calculation());
            }
            else if (context.ifStatement() != null){
                return VisitIfStatement(context.ifStatement());
            }
            else if (context.whileStatement() != null){
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
            else if(context.mapDeclaration() != null){
                return VisitMapDeclaration(context.mapDeclaration());
            }
            else if(context.mapAccess() != null){
                return VisitMapAccess(context.mapAccess());
            }
            else if(context.mapModification() != null){
                return VisitMapModification(context.mapModification());
            }
            else if(context.mapBSP() != null){
                return VisitMapBSP(context.mapBSP());
            }
            else if(context.mapObject() != null){
                return VisitMapObject(context.mapObject());
            }
            else{
                return "Unsupported Statement xdd";
            }
        }

        public override object VisitCalculation(CalculatorParser.CalculationContext context){
            object result = Visit(context.expression());
            Console.WriteLine("Result: " + result);
            return result;
        }

        public override object VisitExpression(CalculatorParser.ExpressionContext context){
            if (context.IDENTIFIER() != null){
                string identifier = context.IDENTIFIER().GetText();
                if (variables.ContainsKey(identifier)){
                    return variables[identifier];
                }else{
                    throw new Exception("Variable " + identifier + " not defined.");
                }
            }else if (context.STRING_LITERAL() != null){
                return context.STRING_LITERAL().GetText(); // Return the string literal
            }else if (context.CHARACTER_LITERAL() != null){
                string charLiteral = context.CHARACTER_LITERAL().GetText();
                char character = charLiteral[1]; // Extracting the character from the string
    
                return character;
            }

            if (context.OPERATOR1() != null){
                object left = Visit(context.expression());
                object right = Visit(context.term());
                if (left == null || right == null)
                    throw new InvalidOperationException("Invalid expression: sub-expression is null.");

                string op = context.OPERATOR1().GetText();
                if (op == "+") return (dynamic)left + (dynamic)right;
                else if (op == "-") return (dynamic)left - (dynamic)right;
            }
            else if (context.COMPARISON_OPERATOR() != null){
                object left = Visit(context.expression());
                object right = Visit(context.term());
                if (left == null || right == null)
                    throw new InvalidOperationException("Invalid expression: sub-expression is null.");

                string op = context.COMPARISON_OPERATOR().GetText();
                switch (op){
                    case ">": 
                        return (dynamic)left > (dynamic)right;
                    case "<": 
                        return (dynamic)left < (dynamic)right;
                    case "==": 
                        return (dynamic)left == (dynamic)right;
                    case "!=": 
                        return (dynamic)left != (dynamic)right;
                    case ">=": 
                        return (dynamic)left >= (dynamic)right;
                    case "<=": 
                        return (dynamic)left <= (dynamic)right;
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
            if(context.mapAccess() != null){
                return VisitMapAccess(context.mapAccess());
            }
            return Visit(context.term());
        }

        public override object VisitTerm(CalculatorParser.TermContext context){
            if (context.IDENTIFIER() != null){
                string identifier = context.IDENTIFIER().GetText();
                if (variables.ContainsKey(identifier)){
                    return variables[identifier];
                }
                else{
                    throw new Exception("Variable " + identifier + " not defined.");
                }
            }else if (context.STRING_LITERAL() != null){
                return context.STRING_LITERAL().GetText(); // Return the string literal
            }else if (context.CHARACTER_LITERAL() != null){
                string charLiteral = context.CHARACTER_LITERAL().GetText();
                char character = charLiteral[1]; // Extracting the character from the string
    
                return character;
            }

            if (context.OPERATOR2() != null){
                object left = Visit(context.term());
                object right = Visit(context.factor());
                string op = context.OPERATOR2().GetText();

                if (op == "*") return (dynamic)left * (dynamic)right;
                else if (op == "/") return (dynamic)left / (dynamic)right;

            }else if(context.BOOLEAN_LITERAL() != null){
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
            if(context.mapAccess() != null){
                return VisitMapAccess(context.mapAccess());
            }

            return Visit(context.factor());
        }   

        public override object VisitFactor(CalculatorParser.FactorContext context){
            if (context.IDENTIFIER() != null){
                string identifier = context.IDENTIFIER().GetText();
                if (variables.ContainsKey(identifier)){
                    return variables[identifier];
                }else{
                    throw new Exception("Variable " + identifier + " not defined.");
                }
            }else if (context.STRING_LITERAL() != null){
                return context.STRING_LITERAL().GetText(); // Return the string literal
            }else if(context.BOOLEAN_LITERAL() != null){
                return bool.Parse(context.BOOLEAN_LITERAL().GetText());
            }else if (context.CHARACTER_LITERAL() != null){
                string charLiteral = context.CHARACTER_LITERAL().GetText();
                char character = charLiteral[1]; // Extracting the character from the string
    
                return character;
            }

            if (context.number() != null){
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
            if(context.mapAccess() != null){
                return VisitMapAccess(context.mapAccess());
            }
            else{
                return Visit(context.expression());
            }
        }

        public override object VisitIfStatement(CalculatorParser.IfStatementContext context){
            //Initialize conditionvalue with first expression
            bool conditionValue = (bool)Visit(context.expression(0));
    
            //Iterate over any other expression and apply boolean operators
            for(int i = 1; i <context.expression().Length; i++){
                bool expressionValue = (bool)Visit(context.expression(i));
                conditionValue = ApplyBooleanOperator(conditionValue, expressionValue, context.BOOLEANOPERATORS(i-1).GetText());
                }

            int elseTokenIndex = context.ELSE()?.Symbol.TokenIndex ?? int.MaxValue;

            if (conditionValue){
                foreach(var statement in context.statement()){
                    if(statement.Stop.TokenIndex < elseTokenIndex){
                        Visit(statement);
                    }
                }
            }

            else if (context.ELSE() != null){
                foreach(var statement in context.statement()){
                    if(statement.Stop.TokenIndex > elseTokenIndex){
                        Visit(statement);
                    }
                }
            }
            return false; // No 'else' block and condition evaluates to false
        }

        // Function to apply the boolean operator
        bool ApplyBooleanOperator(bool operand1, bool operand2, string booleanOperator){
            switch (booleanOperator){
                case "&&":
                    return operand1 && operand2;
                case "||":
                    return operand1 || operand2;
            // Add more cases for other operators if needed
                default:
                    throw new ArgumentException("Invalid boolean operator");
            }
        }

        public override object VisitWhileStatement(CalculatorParser.WhileStatementContext context){
            object result = null;
            bool breakflag = false;

            while ((dynamic)Visit(context.expression()) is true && breakflag is false){
                foreach (var statement in context.statement()){
                    result = Visit(statement);
                    //Check for breaks
                    if(result == null){
                        breakflag = true;
                    }
                
                }
            }
    
            return result;
        }


        public override object VisitVariableDeclaration(CalculatorParser.VariableDeclarationContext context){
            string identifier = context.IDENTIFIER().GetText();
            object value;
            string declaredTypeName = context.TYPE().GetText();
            Type declaredType = GetTypeFromName(declaredTypeName);

            if(context.expression() != null){
                value = Visit(context.expression());

                CheckType(identifier, declaredType, value);
                if(value is int && declaredTypeName == "double " ){
                    value = (double)(int)value;
                }

                variableTypes[identifier] = declaredType;
                variables[identifier] = value;
                return value;            
            }else if(context.mapTest() != null && declaredTypeName == "boolean "){
                value = Visit(context.mapTest());
                variableTypes[identifier] = declaredType;
                variables[identifier] = value;
                return value;
            }
            
            /*if (variableTypes.ContainsKey(identifier)){
                throw new Exception($"Variable {identifier} has already been declared, {identifier} is of type {declaredType}");
            }*/

            return 0;
        }

        public override object VisitVariableAssignment(CalculatorParser.VariableAssignmentContext context){
            string identifier = context.IDENTIFIER().GetText();
            object value = Visit(context.expression());
            Type declaredType = variableTypes[identifier];

            // Check if the assigned value needs type conversion
            if (value is double && declaredType == typeof(int)){
                // If the assigned value is double but the variable type is int, convert it to int
                variables[identifier] = (int)(double)value;
            }
            else if (value is int && declaredType == typeof(double)){
                // If the assigned value is int but the variable type is double, convert it to double
                variables[identifier] = (double)(int)value;
            }
        
            CheckType(identifier, declaredType, value);

            variables[identifier] = value;
            return value;
        }

        public override object VisitNumber(CalculatorParser.NumberContext context){
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
        
            if (context.INCREMENTER() != null){
                currentValue++;
                variables[identifier] = currentValue;
            }
            else if (context.DECREMENTER() != null){
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
                foreach (var statement in context.statement()){
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
        
            if (context.COMPARISON_OPERATOR() != null){
                object left = Visit(context.expression());
                object right = Visit(context.term());
                if (left == null || right == null)
                    throw new InvalidOperationException("Invalid expression: sub-expression is null.");

                string op = context.COMPARISON_OPERATOR().GetText();

                switch (op){
                    case ">": 
                        return (dynamic)left > (dynamic)right;
                    case "<": 
                        return (dynamic)left < (dynamic)right;
                    case "==": 
                        return (dynamic)left == (dynamic)right;
                    case "!=": 
                        return (dynamic)left != (dynamic)right;
                    case ">=": 
                        return (dynamic)left >= (dynamic)right;
                    case "<=": 
                        return (dynamic)left <= (dynamic)right;
                    default:
                        throw new InvalidOperationException("Invalid comparison operator: " + op);
                }
            }
            return 0;
        }

        public override object VisitArrayDeclaration(CalculatorParser.ArrayDeclarationContext context){
    
            string identifier = context.IDENTIFIER().GetText();
            List<object> valuesFromArray = new List<object>();
            string declaredTypeName = context.TYPE().GetText();

            Type declaredType = GetTypeFromName(declaredTypeName);
            
            
            foreach (var expression in context.expression()){
                object value = Visit(expression);

                if(value is int && declaredTypeName == "double " ){
                    value = (double)(int)value;
                }

                CheckType(identifier, declaredType, value);

                valuesFromArray.Add(value);
            }
            // Convert list to array
            object[] arrayValues = valuesFromArray.ToArray();

            // Assign array to variable
            variableTypes[identifier] = declaredType;
            variables[identifier] = arrayValues;
            
            return arrayValues;
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

            // Get the declared type of the array
            Type declaredType = variableTypes[identifier];
            
            object indexValue;
            if(context.IDENTIFIER(1) != null){
                indexValue = variables[context.IDENTIFIER(1).GetText()];
            }else {
                indexValue = Visit(context.number());
            }
            int index = (int)indexValue;

            // Check if the index is within the bounds of the array
            if (index < 0 || index >= array.Length){
                throw new IndexOutOfRangeException($"Index {index} is out of range for array {identifier}");
            }
            //Cast ints to doubles
            if (value.GetType() == typeof(int) && declaredType == typeof(double)){
                value = Convert.ToDouble(value);
                array[index] = value;
            }

            // Check if the assigned value matches the declared type
            CheckType(identifier, declaredType, value);

            array[index] = value;  

            variables[identifier] = array;

            return value;
        }

        public override object VisitArrayDeclaration2d(CalculatorParser.ArrayDeclaration2dContext context){
            Console.WriteLine("Visiting 2darray");
            string identifier = context.IDENTIFIER(0).GetText();
            string declaredTypeName = context.TYPE().GetText();
            Type declaredType = GetTypeFromName(declaredTypeName);
            

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
            
            
            //object[,] array2d = new object[rows, columns];

            Array array2d;

            if (declaredType == typeof(char)) {
                array2d = new char[rows, columns];
            } else if (declaredType == typeof(int)) {
                array2d = new int[rows, columns];
            } else if (declaredType == typeof(double)) {
                array2d = new double[rows, columns];
            }else if (declaredType == typeof(string)) {
                array2d = new string[rows, columns];
            } else {
                // Handle unsupported types or throw an exception
                throw new Exception($"Unsupported type: {declaredTypeName}");
            }

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
                for (int i = 0; i < rows; i++){
                    for (int j = 0; j < columns; j++){
                        object value = Visit(context.expression(counter));


                        if(value is int && declaredTypeName == "double " ){
                            value = (double)(int)value;
                        }

                        CheckType(identifier, declaredType, value);
                        if (declaredType == typeof(char)) {
                            ((char[,])array2d)[i, j] = (char)value;
                        } else if (declaredType == typeof(int)) {
                            ((int[,])array2d)[i, j] = (int)value;
                        } else if (declaredType == typeof(double)){
                            ((double[,])array2d)[i, j] = (double)value;
                        }else if (declaredType == typeof(string)){
                            ((string[,])array2d)[i, j] = (string)value;
                        }
                        counter++;
                        
                    }
                }
            }
            variableTypes[identifier] = declaredType;
            variables[identifier] = array2d;

            return array2d;
        }

        public override object VisitArrayAssignment2d(CalculatorParser.ArrayAssignment2dContext context)
        {
            string identifier = context.IDENTIFIER(0).GetText();
            object[,] array = (object[,])variables[identifier];

            // Get the declared type of the array
            Type declaredType = variableTypes[identifier];
            
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
            // Check if the indices are within bounds of the array
            if (rows < 0 || rows >= array.GetLength(0) || columns < 0 || columns >= array.GetLength(1)){
                throw new Exception($"Index out of bounds for 2D array '{identifier}'");
            }
            
            object value = Visit(context.expression());

            if(value is int && declaredType == typeof(double)){
                value = (double)(int)value;
            }

            CheckType(identifier,declaredType,value);

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

            string fileName;
            string identifier = context.arrayAccess2d().IDENTIFIER(0).GetText();          

            Type declaredType = variableTypes[identifier];

            if(declaredType == typeof(char)){
                char charToWrite = (char)Visit(context.arrayAccess2d());
                fileName = context.STRING_LITERAL().GetText();
                fileName = fileName.Substring(1, fileName.Length - 2);

                try{
                using(StreamWriter writer = new StreamWriter(fileName, writtenFiles.Contains(fileName))){
                    writer.Write(charToWrite);
                }
                
                    writtenFiles.Add(fileName);
                    return true;
                    
                }catch(Exception ex){
                    throw new Exception("Cant print to file, yep " + ex);
                }
            }
            return false;
            
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

        public override object VisitMapDeclaration(CalculatorParser.MapDeclarationContext context){

            string identifier = context.IDENTIFIER().GetText();
            int numKeyValuePairs = int.Parse(context.NUMBER(0).GetText());
            int rows = int.Parse(context.NUMBER(1).GetText());
            int columns = int.Parse(context.NUMBER(2).GetText());

            string declaredTypeName = context.TYPE().GetText();
            Type declaredType = GetTypeFromName(declaredTypeName);

            List<string> keys = context.STRING_LITERAL().Select(x => x.GetText()).ToList();            

            Dictionary<string, char[,]> map = new Dictionary<string, char[,]>();

            for (int i = 0; i < numKeyValuePairs; i++){
                // Create the 2D char array for each key
                char[,] array = new char[rows, columns];

                // Fill the array with characters
                for (int r = 0; r < rows; r++){
                    for (int c = 0; c < columns; c++)
                    {
                        array[r, c] = 'Q'; // Fill with space character, currently Q for testing purposes
                    }
                }

                // Add the key-value pair to the map
                map.Add(keys[i], array);
            }

            variableTypes[identifier] = declaredType;
            variables[identifier] = map;
            return map;
        }

        public override object VisitMapAccess(CalculatorParser.MapAccessContext context){

            string identifier = context.IDENTIFIER().GetText();
            

            Dictionary<string,char[,]> map = (Dictionary<string,char[,]>)variables[identifier]; 

            string key = context.STRING_LITERAL().GetText(); 
            
            if (map.ContainsKey(key)) {
                var array = map[key];

                //FOR TESTING PURPOSES
                for (int i = array.GetLength(0) - 1; i >= 0; i--) {
                    for (int j = 0; j < array.GetLength(1); j++) {
                        Console.Write(array[i, j] + " ");
                    }
                    Console.WriteLine();
                }


                return array;
            } else {
                throw new KeyNotFoundException($"Key '{key}' not found in the map.");
            }
        }


        public override object VisitMapModification(CalculatorParser.MapModificationContext context){
            
            string identifier = context.IDENTIFIER(0).GetText();
            string layerName = context.STRING_LITERAL().GetText();
            string arrayIdentifier = context.IDENTIFIER(1).GetText();

            if(variableTypes[identifier] != typeof(Dictionary<string,char[,]>)){
                throw new Exception($"Variable {identifier} is not of type 'map'.");
            }else if(variableTypes[arrayIdentifier] != typeof(char)){
                throw new Exception($"Variable {arrayIdentifier} is not of type 'char[,]'.");
            }

            Dictionary<string, char[,]> map = (Dictionary<string,char[,]>)variables[identifier];

            if(arrayIdentifier != null)
            {
                char[,] newArray = (char[,])variables[arrayIdentifier];

                if (map.ContainsKey(layerName)){

                    char[,] oldArray = map[layerName];
                    if (oldArray.GetLength(0) != newArray.GetLength(0) || oldArray.GetLength(1) != newArray.GetLength(1)) {
                        throw new Exception($"New array dimensions do not match the dimensions of the existing array for key '{layerName}'.");
                    }
                    map[layerName] = newArray;
                }else{
                    throw new KeyNotFoundException($"Key '{layerName}' not found in the map '{identifier}'.");
                }
            }
            variables[identifier] = map;
            
            return true;
        }

        public override object VisitMapBSP(CalculatorParser.MapBSPContext context)
        {
            string identifier = context.IDENTIFIER().GetText();
            string key = context.STRING_LITERAL().GetText();
            int maxAcceptedSize = int.Parse(context.NUMBER().GetText());

            Dictionary<string,char[,]> map = (Dictionary<string,char[,]>)variables[identifier]; 
            if (map.ContainsKey(key)) {
                char[,] grid = map[key];
                BSPNode root = new BSPNode(0);
                Subset gridSubset = new Subset((0, grid.GetLength(0)-1), (grid.GetLength(1)-1, 0));
                root.SetSubset(gridSubset);
                List<BSPNode> nodeList = new List<BSPNode>();
                BSP_rooms BSPrunner = new BSP_rooms();
                BSPrunner.run(root, maxAcceptedSize, nodeList, grid);
                map[key] = grid;
            } else {
                throw new KeyNotFoundException($"Key '{key}' not found in the map.");
            }
            variables[identifier] = map;
            return null;
        }

        public override object VisitMapObject(CalculatorParser.MapObjectContext context)
        {
            string identifier = context.IDENTIFIER().GetText();
            string layerName = context.STRING_LITERAL(0).GetText();
            string secondLayerName = context.STRING_LITERAL(1).GetText();

            Dictionary<string, char[,]> map = (Dictionary<string,char[,]>)variables[identifier];

            if(context.NUMBER != null && secondLayerName != null && map.ContainsKey(layerName) && map.ContainsKey(secondLayerName))
            {
                char[,] firstLayer = map[layerName];
                char[,] secondLayer = map[secondLayerName];
                randomObjectPlacer randomObjectPlacer = new randomObjectPlacer();
                char objectChar = context.CHARACTER_LITERAL().GetText().Trim('\'')[0];
                int numberOfObjectsToPlace = int.Parse(context.NUMBER().GetText());
                randomObjectPlacer.run(firstLayer,secondLayer, numberOfObjectsToPlace, objectChar);
                map[secondLayerName] = secondLayer;
            }
            variables[identifier] = map;

            return base.VisitMapObject(context);
        }

        public override object VisitMapTest(CalculatorParser.MapTestContext context)
        {
            Console.WriteLine("Visiting maptesting");
            string identifier = context.IDENTIFIER().GetText();
            string layerName = context.STRING_LITERAL(0).GetText();
            string secondLayerName = context.STRING_LITERAL(1).GetText();

            Dictionary<string, char[,]> map = (Dictionary<string,char[,]>)variables[identifier];

            char[,] firstLayer = map[layerName];
            char[,] secondLayer = map[secondLayerName];

            dijkstra dijkstra = new dijkstra();
            bool resultOfTest = dijkstra.run(firstLayer, secondLayer);
            return resultOfTest;
        }
    }
    

}

