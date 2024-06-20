using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using AntlrCSharp;
using static MapperParser;
using System.IO;
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography;
using NUnit.Framework.Internal;

namespace AntlrCSharp
{
    public class BasicCalculatorVisitor : MapperBaseVisitor<object>
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
        public override object VisitInput(MapperParser.InputContext context){
            return VisitChildren(context);
        }

        public override object VisitStatement(MapperParser.StatementContext context){
            // Determine the type of statement and delegate to the appropriate visit method
            //if (context.calculation() != null){
            //    return VisitCalculation(context.calculation());
            //}
            if(context.expression() != null){
                object result = VisitExpression(context.expression());
                Console.WriteLine(result);
                return result;
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
            else if(context.mapPrint() != null){
                return VisitMapPrint(context.mapPrint());
            }
            else if(context.mapModification() != null){
                return VisitMapModification(context.mapModification());
            }
            else if(context.mapWrite() != null){
                return VisitMapWrite(context.mapWrite());
            }
            else if(context.mapBSP() != null){
                return VisitMapBSP(context.mapBSP());
            }
            else if(context.mapObject() != null){
                return VisitMapObject(context.mapObject());
            }
            else{
                return "Unsupported Statement ";
            }
        }

        public override object VisitExpression(MapperParser.ExpressionContext context){
            //If expression is IDENTIFIER, lookup in valuetable variables and return value
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

            //If expression is expression OPERATOR1 term, visit expression and term and apply operator on values returned
            if (context.OPERATOR1() != null){
                object left = Visit(context.expression());
                object right = Visit(context.term());
                if (left == null || right == null)
                {
                    throw new InvalidOperationException("Invalid expression: sub-expression is null.");
                }

                string op = context.OPERATOR1().GetText();
                if (op == "+") return (dynamic)left + (dynamic)right;
                else if (op == "-") return (dynamic)left - (dynamic)right;
            }
            //If expression is expression COMPARISON_OPERATOR term, visit expression adn term and apply comparison operator on values returned
            if (context.COMPARISON_OPERATOR() != null){
                object left = Visit(context.expression());
                object right = Visit(context.term());
                if (left == null || right == null)
                {
                    throw new InvalidOperationException("Invalid expression: sub-expression is null.");
                }

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
            if(context.BOOLEAN_LITERAL() != null){
                return bool.Parse(context.BOOLEAN_LITERAL().GetText());
            }
            if(context.DOUBLE_LITERAL() != null){
                return double.Parse(context.DOUBLE_LITERAL().GetText());
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
            if(context.mapPrint() != null){
                return VisitMapPrint(context.mapPrint());
            }
            return Visit(context.term());
        }

        public override object VisitTerm(MapperParser.TermContext context){
            if (context.IDENTIFIER() != null){
                string identifier = context.IDENTIFIER().GetText();
                
                //lookup identifier in valuetable
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
            else if(context.DOUBLE_LITERAL() != null){
                return double.Parse(context.DOUBLE_LITERAL().GetText());
            }
            else if(context.BOOLEAN_LITERAL() != null){
                return bool.Parse(context.BOOLEAN_LITERAL().GetText());
            }

            //If term is term OPERATOR2 factor, visit term and factor and apply operator on returned values
            if (context.OPERATOR2() != null){
                object left = Visit(context.term());
                object right = Visit(context.factor());
                string op = context.OPERATOR2().GetText();

                if (op == "*") return (dynamic)left * (dynamic)right;
                else if (op == "/") return (dynamic)left / (dynamic)right;

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
            if(context.mapPrint() != null){
                return VisitMapPrint(context.mapPrint());
            }
            //If term is none of the above, it is a factor
            return Visit(context.factor());
        }   

        public override object VisitFactor(MapperParser.FactorContext context){
            if (context.IDENTIFIER() != null){
                string identifier = context.IDENTIFIER().GetText();
                //lookup identifier in valuetable
                if (variables.ContainsKey(identifier)){
                    return variables[identifier];
                }else{
                    throw new Exception("Variable " + identifier + " not defined.");
                }
            }
            if (context.STRING_LITERAL() != null){
                return context.STRING_LITERAL().GetText(); // Return the string literal
            }
            if(context.BOOLEAN_LITERAL() != null){
                return bool.Parse(context.BOOLEAN_LITERAL().GetText());
            }
            if (context.CHARACTER_LITERAL() != null){
                string charLiteral = context.CHARACTER_LITERAL().GetText();
                char character = charLiteral[1]; // Extracting the character from the string
    
                return character;
            }
            if (context.DOUBLE_LITERAL() != null) {
                string stringDoubleLiteral = context.DOUBLE_LITERAL().GetText();
                //parse double from string
                if (double.TryParse(stringDoubleLiteral, NumberStyles.Any, CultureInfo.InvariantCulture, out double doubleValue)) 
                {
                    return doubleValue;
                } else 
                {
                    throw new Exception("Invalid double literal: " + stringDoubleLiteral);
                }
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
            if(context.mapPrint() != null){
                return VisitMapPrint(context.mapPrint());
            }
            else{
                return Visit(context.expression());
            }
        }

        public override object VisitIfStatement(MapperParser.IfStatementContext context){
            //Initialize conditionvalue with first expression
            bool conditionValue = (bool)Visit(context.expression(0));
    
            //Iterate over any other expression and apply boolean operators
            for(int i = 1; i <context.expression().Length; i++){
                bool expressionValue = (bool)Visit(context.expression(i));
                conditionValue = ApplyBooleanOperator(conditionValue, expressionValue, context.BOOLEANOPERATORS(i-1).GetText());
            }

            //Get ELSE token index if it exists, else set to int.MaxValue
            int elseTokenIndex = context.ELSE()?.Symbol.TokenIndex ?? int.MaxValue;

            //If condition is true visit statements before ELSE token
            //If ELSE token exists, visit statements after ELSE token
            if (conditionValue){
                foreach(var statement in context.statement()){
                    if(statement.Stop.TokenIndex < elseTokenIndex){
                        Visit(statement);
                    }
                }
                return true;
            } else if (context.ELSE() != null){
                foreach(var statement in context.statement()){
                    if(statement.Stop.TokenIndex > elseTokenIndex){
                        Visit(statement);
                    }
                }
            }
            return false; // No 'else' block and condition evaluates to false
        }

        //Helper function to apply the boolean operator
        bool ApplyBooleanOperator(bool operand1, bool operand2, string booleanOperator){
            switch (booleanOperator){
                case "&&":
                    return operand1 && operand2;
                case "||":
                    return operand1 || operand2;
            //Add more cases for other operators if needed
                default:
                    throw new ArgumentException("Invalid boolean operator");
            }
        }

        public override object VisitWhileStatement(MapperParser.WhileStatementContext context){
            object result = null;
            bool breakflag = false;

            //If expression is true and breaflag false, visit all statements
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

        public override object VisitVariableDeclaration(MapperParser.VariableDeclarationContext context){
            string identifier = context.IDENTIFIER().GetText();
            object value;
            string declaredTypeName = context.TYPE().GetText();
            Type declaredType = GetTypeFromName(declaredTypeName);

            if(context.expression() != null){
                value = Visit(context.expression());
                //Check type and cast type to double if value is int but declaredType is double
                CheckType(identifier, declaredType, value);
                if(value is int && declaredTypeName == "double " ){
                    value = (double)(int)value;
                }
                //Save type in typetable and value in valuetable
                variableTypes[identifier] = declaredType;
                variables[identifier] = value;
                return value;            
            }
            //If any mapTest function is called, type must be boolean
            if(context.mapTest() != null && declaredTypeName == "boolean "){
                value = Visit(context.mapTest());
                //Save type in typetable and value in valuetable
                variableTypes[identifier] = declaredType;
                variables[identifier] = value;
                return value;
            }
            return 0;
        }

        public override object VisitVariableAssignment(MapperParser.VariableAssignmentContext context){
            string identifier = context.IDENTIFIER().GetText();
            object value = Visit(context.expression());
            Type declaredType = variableTypes[identifier];

            //Check if the assigned value needs type conversion
            if (value is double && declaredType == typeof(int)){
                //If the assigned value is double but the variable type is int, convert it to int
                variables[identifier] = (int)(double)value;
            }
            else if (value is int && declaredType == typeof(double)){
                //If the assigned value is int but the variable type is double, convert it to double
                variables[identifier] = (double)(int)value;
            }

            //Check type and save in valuetable
            CheckType(identifier, declaredType, value);
            variables[identifier] = value;
            return value;
        }

        public override object VisitNumber(MapperParser.NumberContext context){
            string numberText = context.NUMBER().GetText();
            //Try to parse as int or double
            if(int.TryParse(numberText, out int intValue)){
                return intValue;
            }
            if(double.TryParse(numberText, out double doublevalue)){
                return doublevalue;
            }
            return 0;
        }

        public override object VisitCrementer(MapperParser.CrementerContext context){
            string identifier = context.IDENTIFIER().GetText();
            int currentValue = Convert.ToInt32(variables[identifier]);
        
            if (context.INCREMENTER() != null){
                currentValue++;
                //Save value in valuetable
                variables[identifier] = currentValue;
            }
            else if (context.DECREMENTER() != null){
                currentValue--;
                //Save value in valuetable
                variables[identifier] = currentValue;
            }
            return currentValue;
        }

        public override object VisitForLoop(MapperParser.ForLoopContext context){
            bool breakFlag = false;
            object result = null;
            Visit(context.variableDeclaration());

            while ((bool)Visit(context.compare()) && breakFlag == false){
                //Visit the statements inside the for loop
                foreach (var statement in context.statement()){
                    result = Visit(statement);
                    if(result == null){
                        breakFlag = true;
                    }
                }
                //Visit the increment/decrement part of the for loop
                Visit(context.crementer());
            }
            return result;
        }

        public override object VisitCompare(MapperParser.CompareContext context){
            if (context.COMPARISON_OPERATOR() != null){
                object left = Visit(context.expression());
                object right = Visit(context.term());
                if (left == null || right == null)
                {
                    throw new InvalidOperationException("Invalid expression: sub-expression is null.");
                }

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

        public override object VisitArrayDeclaration(MapperParser.ArrayDeclarationContext context){
            string identifier = context.IDENTIFIER(0).GetText();
            string declaredTypeName = context.TYPE().GetText();
            Type declaredType = GetTypeFromName(declaredTypeName);

            object lengthArray;
            //Get declared arraylength
            if(context.IDENTIFIER(1) != null){
                //lookup variable in valuetable
                lengthArray = variables[context.IDENTIFIER(1).GetText()];
            }else {
                lengthArray = Visit(context.number());
            }

            int length = (int)lengthArray;
            List<object> values = new List<object>();

            //Get number of expressions and iterate through them
            int expressionLength = context.expression().Length;
            if(expressionLength > 0){
                foreach (var expression in context.expression()){
                    object value = Visit(expression);
                    //If declared tpye is double, cast to double
                    if(value is int && declaredTypeName == "double " )
                    {
                        value = (double)(int)value;
                    }
                    CheckType(identifier, declaredType, value);
                    values.Add(value);
                }
            }
            
            //Convert list to array
            Array array = Array.CreateInstance(declaredType, length);
            for (int i = 0; i < values.Count; i++) {
                array.SetValue(values[i], i);
            }

            //Assign array to variable in valuetable and assign type to variable in typetable
            variableTypes[identifier] = declaredType;
            variables[identifier] = array;
            
            return array;
        }

        public override object VisitArrayAccess(MapperParser.ArrayAccessContext context){
            string identifier = context.IDENTIFIER(0).GetText();
            Type declaredType = variableTypes[identifier];

            object indexValue;

            //Get indexvalue
            if(context.IDENTIFIER(1) != null){
                //lookup variable in valuetable
                indexValue = variables[context.IDENTIFIER(1).GetText()];
            }else {
                indexValue = Visit(context.number());
            }
            
            int index = (int)indexValue; 

            if(declaredType == typeof(int)){
                int[] array = (int[])variables[identifier];
                return array[index];
            }
            else if (declaredType == typeof(char))
            {
                char[] array = (char[])variables[identifier];
                return array[index];
            }
            else if (declaredType == typeof(double))
            {
                double[] array = (double[])variables[identifier];
                return array[index];
            }
            else if (declaredType == typeof(string))
            {
                string[] array = (string[])variables[identifier];
                return array[index];
            }
            else{
                //Handle unsupported types or throw an exception
                throw new Exception($"Unsupported type: {declaredType}");
            }
        }
    
        public override object VisitArrayAssignement(MapperParser.ArrayAssignementContext context){
            string identifier = context.IDENTIFIER(0).GetText();
            
            //Get the declared type of the array
            Type declaredType = variableTypes[identifier];
            
            object indexValue;
            //Get indexvalue
            if(context.IDENTIFIER(1) != null){
                //lookup variable in valuetable
                indexValue = variables[context.IDENTIFIER(1).GetText()];
            }else {
                indexValue = Visit(context.number());
            }
            int index = (int)indexValue;

            object value = Visit(context.expression());
            //Cast ints to doubles
            if (value.GetType() == typeof(int) && declaredType == typeof(double)){
                value = Convert.ToDouble(value);
            }

            // Check if the assigned value matches the declared type
            CheckType(identifier, declaredType, value);
            object array = variables[identifier];

            if (declaredType == typeof(int)){
                int[] newArray = (int[])array;
                //Check if the index is within the bounds of the array
                if (index < 0 || index >= newArray.Length){
                    throw new IndexOutOfRangeException($"Index {index} is out of range for array {identifier}");
                }
                int intValue = (int)value;
                //Set index in array to value and save array in valuetable
                newArray[index] = intValue;
                variables[identifier] = array;
            }

            if (declaredType == typeof(char)){
                char[] newArray = (char[])array;
                //Check if the index is within the bounds of the array
                if (index < 0 || index >= newArray.Length){
                    throw new IndexOutOfRangeException($"Index {index} is out of range for array {identifier}");
                }
                //Set array at index to charValue and save in valuetable
                char charValue = (char)value;
                newArray[index] = charValue;
                variables[identifier] = array;
            }

            if (declaredType == typeof(double)){
                double[] newArray = (double[])array;
                // Check if the index is within the bounds of the array
                if (index < 0 || index >= newArray.Length){
                    throw new IndexOutOfRangeException($"Index {index} is out of range for array {identifier}");
                }
                //Set array at index to doubleValue and save in valuetable
                double doubleValue = (double)value;
                newArray[index] = doubleValue;
                variables[identifier] = array;
            }

            if (declaredType == typeof(string)){
                string[] newArray = (string[])array;
                // Check if the index is within the bounds of the array
                if (index < 0 || index >= newArray.Length){
                    throw new IndexOutOfRangeException($"Index {index} is out of range for array {identifier}");
                }
                //Set array at index to stringValue and save in valuetable
                string stringValue = (string)value;
                newArray[index] = stringValue;
                variables[identifier] = array;
            }
            return value;
        }

        public override object VisitArrayDeclaration2d(MapperParser.ArrayDeclaration2dContext context){
            Console.WriteLine("Visiting 2darray");
            string identifier = context.IDENTIFIER(0).GetText();
            string declaredTypeName = context.TYPE().GetText();
            Type declaredType = GetTypeFromName(declaredTypeName);
            

            object rowIndex;
            if(context.IDENTIFIER(1) != null){
                //lookup in valuetable
                rowIndex = variables[context.IDENTIFIER(1).GetText()];
            }else {
                rowIndex = Visit(context.number(0));
            }
            object columnIndex;
            if(context.IDENTIFIER(2) != null){
                //lookup in valuetable
                columnIndex = variables[context.IDENTIFIER(2).GetText()];
            }else {
                columnIndex = Visit(context.number(1));
            }

            int rows = (int)rowIndex;
            int columns = (int)columnIndex;

            int bracketAmount = context.LEFTCURLYBRACKET().Length - 1;
            int expressionLength = context.expression().Length;

            Array array2d;
            //Set array type and size
            if (declaredType == typeof(int)) {
                array2d = new int[rows, columns];
            } else if (declaredType == typeof(char)) {
                array2d = new char[rows, columns];
            } else if (declaredType == typeof(double)) {
                array2d = new double[rows, columns];
            }else if (declaredType == typeof(string)) {
                array2d = new string[rows, columns];
            } else {
                // Handle unsupported types or throw an exception
                throw new Exception($"Unsupported type: {declaredTypeName}");
            }

            if(expressionLength > 0){
                if(rows != bracketAmount){
                    throw new Exception("Error: Rows is " + rows + " rows declared " + bracketAmount);
                }
                if(columns != expressionLength/bracketAmount){
                    throw new Exception("Error: Columns is " + columns + " columns declared " + expressionLength/bracketAmount);
                }
                //Create array with declared values by iterating through each expression
                int counter = 0;
                for (int i = 0; i < rows; i++){
                    for (int j = 0; j < columns; j++){
                        //Visit expression and get value
                        object value = Visit(context.expression(counter));
                        //If declared type is double and value is int, cast to double
                        if(value is int && declaredTypeName == "double " ){
                            value = (double)(int)value;
                        }
                        CheckType(identifier, declaredType, value);
                        //Cast value to declaredType
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
            //Save type and value in typetable and valuetable
            variableTypes[identifier] = declaredType;
            variables[identifier] = array2d;
            return array2d;
        }

        public override object VisitArrayAssignment2d(MapperParser.ArrayAssignment2dContext context)
        {
            string identifier = context.IDENTIFIER(0).GetText();
            // Get the declared type of the array
            Type declaredType = variableTypes[identifier];
            
            object rowIndex;
            if(context.IDENTIFIER(1) != null){
                //lookup in valuetable
                rowIndex = variables[context.IDENTIFIER(1).GetText()];
            }else {
                rowIndex = Visit(context.number(0));
            }
            object columnIndex;
            if(context.IDENTIFIER(2) != null){
                //lookup in valuetable
                columnIndex = variables[context.IDENTIFIER(2).GetText()];
            }else {
                columnIndex = Visit(context.number(1));
            }

            int rows = (int)rowIndex;
            int columns = (int)columnIndex;

            object value = Visit(context.expression());
            //Cast value to double if array is double
            if (value is int && variableTypes[identifier] == typeof(double)){
                value = (double)(int)value;
            }

            CheckType(identifier,declaredType,value);
            //lookup array in valuetable
            object arrayObject = variables[identifier];

            if (declaredType == typeof(int)){
                int[,] array = (int[,])arrayObject;
                //Check if the indices are within bounds of the array
                if (rows < 0 || rows >= array.GetLength(0) || columns < 0 || columns >= array.GetLength(1)){
                    throw new Exception($"Index out of bounds for 2D array '{identifier}'");
                }
                //Assign value to array and save array in valuetable
                int intValue = (int)value;
                array[rows,columns] = intValue;
                variables[identifier] = array;
            }

            if (declaredType == typeof(char)){
                char[,] array = (char[,])arrayObject;
                // Check if the indices are within bounds of the array
                if (rows < 0 || rows >= array.GetLength(0) || columns < 0 || columns >= array.GetLength(1)){
                    throw new Exception($"Index out of bounds for 2D array '{identifier}'");
                }
                //Assign value to array and save array in valuetable
                char charValue = (char)value;
                array[rows,columns] = charValue;
                variables[identifier] = array;
            }

            if (declaredType == typeof(double)){
                double[,] array = (double[,])arrayObject;
                // Check if the indices are within bounds of the array
                if (rows < 0 || rows >= array.GetLength(0) || columns < 0 || columns >= array.GetLength(1)){
                    throw new Exception($"Index out of bounds for 2D array '{identifier}'");
                }
                //Assign value to array and save array in valuetable
                double doubleValue = (double)value;
                array[rows,columns] = doubleValue;
                variables[identifier] = array;
            }

            if (declaredType == typeof(string)){
                string[,] array = (string[,])arrayObject;
                // Check if the indices are within bounds of the array
                if (rows < 0 || rows >= array.GetLength(0) || columns < 0 || columns >= array.GetLength(1)){
                    throw new Exception($"Index out of bounds for 2D array '{identifier}'");
                }
                //Assign value to array and save array in valuetable
                string stringValue = (string)value;
                array[rows,columns] = stringValue;
                variables[identifier] = array;
            }
            return value;
        }

        public override object VisitArrayAccess2d(MapperParser.ArrayAccess2dContext context)
        {
            string identifier = context.IDENTIFIER(0).GetText();
            //Get array type
            Type declaredType = variableTypes[identifier];
            
            object rowIndex;
            if(context.IDENTIFIER(1) != null){
                //lookup in valuetable
                rowIndex = variables[context.IDENTIFIER(1).GetText()];
            }else {
                rowIndex = Visit(context.number(0));
            }
            object columnIndex;
            if(context.IDENTIFIER(2) != null){
                //lookup in valuetable
                columnIndex = variables[context.IDENTIFIER(2).GetText()];
            }else {
                columnIndex = Visit(context.number(1));
            }

            int row = (int)rowIndex;
            int columns = (int)columnIndex;   

            //Lookup array in valuetable and return array casted to correct type
            if (declaredType == typeof(int))
            {
                int[,] array = (int[,])variables[identifier];
                return array[row, columns];
            }
            else if (declaredType == typeof(char))
            {
                char[,] array = (char[,])variables[identifier];
                return array[row, columns];
            }
            else if (declaredType == typeof(double))
            {
                double[,] array = (double[,])variables[identifier];
                return array[row, columns];
            }
            else if (declaredType == typeof(string))
            {
                string[,] array = (string[,])variables[identifier];
                return array[row, columns];
            }
            else{
                // Handle unsupported types or throw an exception
                throw new Exception($"Unsupported type: {declaredType}");
            }
        }

        public override object VisitBreakStatement(MapperParser.BreakStatementContext context){
            return null;
        }

        public override object VisitRandomStatement(MapperParser.RandomStatementContext context)
        {
            Random number = new Random();
            
            string number1String;
            object number1;
            //Get lower bound
            if(context.expression(0) != null && context.children[2].GetType() == context.expression(0).GetType()){
                number1 = Visit(context.expression(0));
                number1String = number1.ToString();
            }else{
                number1String = context.number(0).GetText();
            }
            
            object number2;
            string number2String;
            //Get upper bound 
            //If lower bound is number and upper bound is expression
            if(context.expression(0) != null && context.children[4].GetType() == context.expression(0).GetType() && context.children[2].GetType() != context.expression(0).GetType()){
                number2 = Visit(context.expression(0));
                number2String = number2.ToString();
            }
            //If lower bound is expression and upper bound is expression
            if(context.expression(0) != null && context.children[4].GetType() == context.expression(0).GetType() && context.children[2].GetType() == context.expression(0).GetType()){
                number2 = Visit(context.expression(1));
                number2String = number2.ToString();
            }
            //If lowerbound is expression and upper bound is number
            if(context.children[2].GetType() == context.expression().GetType()){
                number2String = context.number(0).GetText();
            }
            //If lowerbound is number and upper bound is number
            else{
                number2String = context.number(1).GetText();
            }
            
            int numberToUse1 = int.Parse(number1String);
            int numberToUse2 = int.Parse(number2String);

            //Generate random number with lower and upper bounds
            int randomNumber = number.Next(numberToUse1, numberToUse2);
            return randomNumber;
        }

        public override object VisitFileWriteStatement(MapperParser.FileWriteStatementContext context){
            string fileName;
            string identifier = context.arrayAccess2d().IDENTIFIER(0).GetText();          

            //Lookup type of 2d array in typetable
            Type declaredType = variableTypes[identifier];
            
            //Only char arrays are allowed
            if(declaredType == typeof(char)){
                char charToWrite = (char)Visit(context.arrayAccess2d());
                fileName = context.STRING_LITERAL().GetText();
                //Remove '"'s from string
                fileName = fileName.Substring(1, fileName.Length - 2);
                try{
                    using(StreamWriter writer = new StreamWriter(fileName, writtenFiles.Contains(fileName))){
                        writer.Write(charToWrite);
                    }
                    writtenFiles.Add(fileName);
                    return true;     
                }catch(Exception exception){
                    throw new Exception("Cant print to file, " + exception);
                }
            }
            return false;
        }

        public override object VisitFileWriteNewline(MapperParser.FileWriteNewlineContext context){
            string fileName = context.STRING_LITERAL().GetText();
            //Remove '"'s from string
            fileName = fileName.Substring(1,fileName.Length - 2);
            try{
                using(StreamWriter writer = new StreamWriter(fileName, true)){
                    writer.WriteLine(); 
                }
                writtenFiles.Add(fileName);

            }catch(Exception exception){
                throw new Exception("Cant print to file, " + exception);
            }
            return true;
        }

        public override object VisitMapDeclaration(MapperParser.MapDeclarationContext context){
            string identifier = context.IDENTIFIER().GetText();
            int numKeyValuePairs = int.Parse(context.NUMBER(0).GetText());
            int rows = int.Parse(context.NUMBER(1).GetText());
            int columns = int.Parse(context.NUMBER(2).GetText());
            string declaredTypeName = context.TYPE().GetText();
            Type declaredType = GetTypeFromName(declaredTypeName);

            //Create list of keys by getting all STRING_LITERAL's
            List<string> keys = context.STRING_LITERAL().Select(x => x.GetText()).ToList();            

            Dictionary<string, char[,]> map = new Dictionary<string, char[,]>();

            for (int i = 0; i < numKeyValuePairs; i++){
                //Create the 2D char array for each key
                char[,] array = new char[rows, columns];

                //Fill the array with characters
                for (int r = 0; r < rows; r++){
                    for (int c = 0; c < columns; c++)
                    {
                        array[r, c] = ' ';
                    }
                }
                //Add the key-value pair to the map
                map.Add(keys[i], array);
            }
            //Set identifiers type to Map in typetable and set its value to the created map in valuetable
            variableTypes[identifier] = declaredType;
            variables[identifier] = map;
            return map;
        }

        public override object VisitMapPrint(MapperParser.MapPrintContext context){
            string identifier = context.IDENTIFIER().GetText();
            //Lookup map in valuetable
            Dictionary<string,char[,]> map = (Dictionary<string,char[,]>)variables[identifier]; 

            string key = context.STRING_LITERAL().GetText(); 
            if (map.ContainsKey(key)) {
                var array = map[key];
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


        public override object VisitMapModification(MapperParser.MapModificationContext context){
            string identifier = context.IDENTIFIER(0).GetText();
            string layerName = context.STRING_LITERAL().GetText();
            string arrayIdentifier = context.IDENTIFIER(1).GetText();
            
            //Check if variable is correct type
            if(variableTypes[identifier] != typeof(Dictionary<string,char[,]>)){
                throw new Exception($"Variable {identifier} is not of type 'map'.");
            }else if(variableTypes[arrayIdentifier] != typeof(char)){
                throw new Exception($"Variable {arrayIdentifier} is not of type 'char[,]'.");
            }

            Dictionary<string, char[,]> map = (Dictionary<string,char[,]>)variables[identifier];
            if(arrayIdentifier != null)
            {
                char[,] newArray = (char[,])variables[arrayIdentifier];
                //If layer exists, overwrite array
                if (map.ContainsKey(layerName)){
                    char[,] oldArray = map[layerName];
                    //Check if array dimensions match
                    if (oldArray.GetLength(0) != newArray.GetLength(0) || oldArray.GetLength(1) != newArray.GetLength(1)) {
                        throw new Exception($"New array dimensions do not match the dimensions of the existing array for key '{layerName}'.");
                    }
                    map[layerName] = newArray;
                }else{
                    throw new KeyNotFoundException($"Key '{layerName}' not found in the map '{identifier}'.");
                }
            }
            //Update map in valuetable
            variables[identifier] = map;
            return true;
        }

        public override object VisitMapWrite(MapperParser.MapWriteContext context){
            string identifier = context.IDENTIFIER().GetText();
            Type declaredType = variableTypes[identifier];

            if(declaredType == typeof(Dictionary<string,char[,]>)){
                //Get map from valuetable
                Dictionary<string, char[,]> map = (Dictionary<string, char[,]>)variables[identifier];

                //Define the path to the file on the desktop
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                //Write the contents of each 2D array to a separate file
                foreach (var entry in map)
                {
                    string key = entry.Key;
                    char[,] array2D = entry.Value;

                    //Remove double quotes for correct filepath
                    string keyForPrint = Path.GetFileNameWithoutExtension(entry.Key.Replace("\"", "")); 

                    //Generate a unique file name based on the key
                    string fileName = $"{keyForPrint}_output.txt";
                    string filePath = Path.Combine(desktopPath, fileName);

                    //Write the contents of the 2D array to the file
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        //Write the contents of the 2D array to the file
                        for (int i = 0; i < array2D.GetLength(0); i++)
                        {
                            for (int j = 0; j < array2D.GetLength(1); j++)
                            {
                                writer.Write(array2D[i, j]);
                            }
                            //Move to the next line after each row
                            writer.WriteLine(); 
                        }
                    }
                    Console.WriteLine($"Map layer '{key}' written to file: {filePath}");
                }
            }else{
                throw new Exception($"Variable {identifier} is not declared as a map type.");
            }
            return true;
        }
        public override object VisitMapBSP(MapperParser.MapBSPContext context)
        {
            string identifier = context.IDENTIFIER().GetText();
            string key = context.STRING_LITERAL().GetText();
            int maxAcceptedSize = int.Parse(context.NUMBER().GetText());
            //Get map from valuetable
            Dictionary<string,char[,]> map = (Dictionary<string,char[,]>)variables[identifier]; 
            if (map.ContainsKey(key)) {
                char[,] grid = map[key];
                BSP_rooms BSPrunner = new BSP_rooms();
                BSPrunner.run(maxAcceptedSize, grid);
                map[key] = grid;
            } else {
                throw new KeyNotFoundException($"Key '{key}' not found in the map.");
            }
            //Save updated map in valuetable
            variables[identifier] = map;
            return null;
        }

        public override object VisitMapObject(MapperParser.MapObjectContext context)
        {
            string identifier = context.IDENTIFIER().GetText();
            string layerName = context.STRING_LITERAL(0).GetText();
            string secondLayerName = context.STRING_LITERAL(1).GetText();
            
            //Get map from valuetable
            Dictionary<string, char[,]> map = (Dictionary<string,char[,]>)variables[identifier];

            if(context.NUMBER != null && secondLayerName != null && map.ContainsKey(layerName) && map.ContainsKey(secondLayerName))
            {
                char[,] firstLayer = map[layerName];
                char[,] secondLayer = map[secondLayerName];
                randomObjectPlacer randomObjectPlacer = new randomObjectPlacer();
                //Get char from string
                char objectChar = context.CHARACTER_LITERAL().GetText().Trim('\'')[0];
                int numberOfObjectsToPlace = int.Parse(context.NUMBER().GetText());
                randomObjectPlacer.run(firstLayer,secondLayer, numberOfObjectsToPlace, objectChar);
                //Update map with updated layer
                map[secondLayerName] = secondLayer;
            }
            //Update map in valuetable
            variables[identifier] = map;
            return base.VisitMapObject(context);
        }

        public override object VisitMapTest(MapperParser.MapTestContext context)
        {
            string identifier = context.IDENTIFIER().GetText();
            string layerName = context.STRING_LITERAL(0).GetText();
            string secondLayerName = context.STRING_LITERAL(1).GetText();

            //Get map from valuetable
            Dictionary<string, char[,]> map = (Dictionary<string,char[,]>)variables[identifier];

            char[,] firstLayer = map[layerName];
            char[,] secondLayer = map[secondLayerName];

            dijkstra dijkstra = new dijkstra();
            bool resultOfTest = dijkstra.run(firstLayer, secondLayer);
            return resultOfTest;
        }
    }
    

}

