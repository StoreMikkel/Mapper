namespace AntlrCSharpTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using AntlrCSharp;

[TestClass]
public class SemanticsTest1{
        
        [TestMethod]
        public void TestIntVariableDeclaration(){

            CustomParser parser = ParseInput("int x = 5");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            // Assert that the value of 'x' is 5
            Assert.AreEqual(5, visitor.VisitVariableDeclaration(context));
        }

        [TestMethod]
        public void TestDoubleVariableDeclaration(){

            CustomParser parser = ParseInput("double x = 5");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            // Assert that the value of 'x' is 5
            Assert.AreEqual(5.0, visitor.VisitVariableDeclaration(context));
        }

        [TestMethod]
        public void TestStringVariableDeclaration(){

            CustomParser parser = ParseInput("string x = \"abc\"");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            // Assert that the value of 'x' is 5
            Assert.AreEqual("\"abc\"", visitor.VisitVariableDeclaration(context));
        }

        [TestMethod]
        public void TestBoolVariableDeclaration(){

            CustomParser parser = ParseInput("boolean x = true");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            // Assert that the value of 'x' is 5
            Assert.AreEqual(true, visitor.VisitVariableDeclaration(context));
        }

        [TestMethod]
        public void TestCharVariableDeclaration(){

            CustomParser parser = ParseInput("char x = 'a'");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            // Assert that the value of 'x' is 5
            Assert.AreEqual('a', visitor.VisitVariableDeclaration(context));
        }


        [TestMethod]
        public void TestIfStatement(){

            CustomParser parser = ParseInput("if(5 < 6){20}else {1+1}");

            CustomParser.IfStatementContext context = parser.ifStatement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            // Assert that the value of 'x' is 5
            Assert.AreEqual(true, visitor.VisitIfStatement(context));
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        private CustomParser ParseInput(string input)
        {
            AntlrInputStream inputStream = new AntlrInputStream(input);
            CustomLexer lexer = new CustomLexer(inputStream);
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            CustomParser parser = new CustomParser(tokenStream);
            
            return parser;
        }
    }