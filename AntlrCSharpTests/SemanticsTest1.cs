namespace AntlrCSharpTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using AntlrCSharp;
using Antlr4.Runtime.Misc;

[TestClass]
public class SemanticsTest1{
        
        [TestMethod]
        public void TestIntVariableDeclaration(){

            CustomParser parser = ParseInput("int x = 5");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            Assert.AreEqual(5, visitor.VisitVariableDeclaration(context));
        }

        [TestMethod]
        public void TestDoubleVariableDeclaration(){

            CustomParser parser = ParseInput("double x = 5");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            Assert.AreEqual(5.0, visitor.VisitVariableDeclaration(context));
        }

        [TestMethod]
        public void TestStringVariableDeclaration(){

            CustomParser parser = ParseInput("string x = \"abc\"");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            Assert.AreEqual("\"abc\"", visitor.VisitVariableDeclaration(context));
        }

        [TestMethod]
        public void TestBoolVariableDeclaration(){

            CustomParser parser = ParseInput("boolean x = true");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            Assert.AreEqual(true, visitor.VisitVariableDeclaration(context));
        }

        [TestMethod]
        public void TestCharVariableDeclaration(){

            CustomParser parser = ParseInput("char x = 'a'");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            Assert.AreEqual('a', visitor.VisitVariableDeclaration(context));
        }

        [TestMethod]
        public void TestIntVariableAssignment(){

            CustomParser parser = ParseInput("int x = 3");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("x = 5");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);

            Assert.AreEqual(5, visitor.VisitStatement(context2));
        }

        [TestMethod]
        public void TestStringVariableAssignment(){

            CustomParser parser = ParseInput("string x = \"abc\"");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("x = \"ab\"");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);

            Assert.AreEqual("\"ab\"", visitor.VisitStatement(context2));
        }

        [TestMethod]
        public void TestBooleanVariableAssignment(){

            CustomParser parser = ParseInput("boolean x = true");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("x = false");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);

            Assert.AreEqual(false, visitor.VisitStatement(context2));
        }

        [TestMethod]
        public void TestCharVariableAssignment(){

            CustomParser parser = ParseInput("char x = 'a'");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("x = 'b'");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);

            Assert.AreEqual('b', visitor.VisitStatement(context2));
        }


        [TestMethod]
        public void TestIfStatement(){

            CustomParser parser = ParseInput("if(5 < 6){20}else {1+1}");

            CustomParser.IfStatementContext context = parser.ifStatement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            Assert.AreEqual(true, visitor.VisitIfStatement(context));
        }

        [TestMethod]
        public void TestForLoop(){

            CustomParser parser = ParseInput("for(int a = 4;a < 6;a++){true}");

            CustomParser.StatementContext context = parser.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            Assert.AreEqual(true, visitor.VisitStatement(context));
        }

        [TestMethod]
        public void TestInt2dArrayDeclaration(){

            CustomParser parser = ParseInput("int array2d[2,2]");

            CustomParser.StatementContext context = parser.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            Assert.AreEqual(typeof(int[,]).FullName, visitor.VisitStatement(context).GetType().FullName);
        }

        [TestMethod]
        public void TestString2dArrayDeclaration(){

            CustomParser parser = ParseInput("string array2d[2,2]");

            CustomParser.StatementContext context = parser.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            Assert.AreEqual(typeof(string[,]).FullName, visitor.VisitStatement(context).GetType().FullName);
        }

        [TestMethod]
        public void TestChar2dArrayDeclaration(){

            CustomParser parser = ParseInput("char array2d[2,2]");

            CustomParser.StatementContext context = parser.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);

            Assert.AreEqual(typeof(char[,]).FullName, visitor.VisitStatement(context).GetType().FullName);
        }

        [TestMethod]
        public void TestInt2dArrayAssignment(){

            CustomParser parser = ParseInput("int array2d[2,2]");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("array2d[0,0] = 5");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);

            Assert.AreEqual(5, visitor.VisitStatement(context2));
        }

        [TestMethod]
        public void TestString2dArrayAssignment(){

            CustomParser parser = ParseInput("string array2d[2,2]");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("array2d[0,0] = \"yes\"");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);

            Assert.AreEqual("\"yes\"", visitor.VisitStatement(context2));
        }

        [TestMethod]
        public void TestChar2dArrayAssignment(){

            CustomParser parser = ParseInput("char array2d[2,2]");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("array2d[0,0] = 'a'");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);

            Assert.AreEqual('a', visitor.VisitStatement(context2));
        }

        [TestMethod]
        public void TestInt2dArrayAccess(){

            CustomParser parser = ParseInput("int array2d[2,2] = {{1,2},{3,4}}");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("array2d[0,0]");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);

            Assert.AreEqual(1, visitor.VisitStatement(context2));
        }

        [TestMethod]
        public void TestString2dArrayAccess(){

            CustomParser parser = ParseInput("string array2d[2,2] = {{\"1\",\"2\"},{\"3\",\"4\"}}");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("array2d[0,0]");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);

            Assert.AreEqual("\"1\"", visitor.VisitStatement(context2));
        }

        [TestMethod]
        public void TestChar2dArrayAccess(){

            CustomParser parser = ParseInput("char array2d[2,2] = {{'1','2'},{'3','4'}}");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("array2d[0,0]");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);

            Assert.AreEqual('1', visitor.VisitStatement(context2));
        }

        [TestMethod]
        public void TestMapDeclaration(){

            CustomParser parser = ParseInput("map test(3)(50)(50) = \"lag1\" , \"lag2\", \"lag3\"");

            CustomParser.StatementContext context = parser.statement();


            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            
            Assert.AreEqual(typeof(Dictionary<string,char[,]>), visitor.VisitStatement(context).GetType());
        }

        [TestMethod]
        public void TestMapAccess(){

            CustomParser parser = ParseInput("map test(3)(50)(50) = \"lag1\" , \"lag2\", \"lag3\"");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("access test(\"lag2\")");

            CustomParser.StatementContext context2 = parser2.statement();


            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);
            
            Assert.AreEqual(typeof(char[,]), visitor.VisitStatement(context2).GetType());

        }

        [TestMethod]
        public void TestMapModification(){

            CustomParser parser = ParseInput("map test(3)(50)(50) = \"lag1\" , \"lag2\", \"lag3\"");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("char nyTest1[50,50]");

            CustomParser.StatementContext context2 = parser2.statement();

            CustomParser parser3 = ParseInput("modify test(\"lag2\") = nyTest1");

            CustomParser.StatementContext context3 = parser3.statement();


            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);
            visitor.Visit(context3);
            
            Assert.AreEqual(true, visitor.VisitStatement(context3));

        }


        // INVALID TESTS FROM HERE

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidIntVariableDeclaration(){

            CustomParser parser = ParseInput("int x = '5' ");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidDoubleVariableDeclaration(){

            CustomParser parser = ParseInput("double x = '5' ");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidStringVariableDeclaration(){

            CustomParser parser = ParseInput("string x = '5' ");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidBooleanVariableDeclaration(){

            CustomParser parser = ParseInput("boolean x = '5' ");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidCharVariableDeclaration(){

            CustomParser parser = ParseInput("char x = 5 ");

            CustomParser.VariableDeclarationContext context = parser.variableDeclaration();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidIntVariableAssignment(){

            CustomParser parser = ParseInput("int x = 3");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("x = '5'");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidStringVariableAssignment(){

            CustomParser parser = ParseInput("string x = \"abc\"");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("x = '5'");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidBooleanVariableAssignment(){

            CustomParser parser = ParseInput("boolean x = true");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("x = '5'");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidCharVariableAssignment(){

            CustomParser parser = ParseInput("char x = 'a'");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("x = 5");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidInt2dArrayDeclaration(){

            CustomParser parser = ParseInput("int array2d[2,2] = {{'1',2},{3,4}}");

            CustomParser.StatementContext context = parser.statement();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
      
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidString2dArrayDeclaration(){

            CustomParser parser = ParseInput("string array2d[2,2] = {{'1',\"2\"},{\"3\",\"4\"}}");

            CustomParser.StatementContext context = parser.statement();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
      
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidChar2dArrayDeclaration(){

            CustomParser parser = ParseInput("char array2d[2,2] = {{'1',\"2\"},{\"3\",\"4\"}}");

            CustomParser.StatementContext context = parser.statement();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
      
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidInt2dArrayAssignment(){

            CustomParser parser = ParseInput("int array2d[2,2]");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("array2d[0,0] = '5'");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidString2dArrayAssignment(){

            CustomParser parser = ParseInput("string array2d[2,2]");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("array2d[0,0] = '5'");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidChar2dArrayAssignment(){

            CustomParser parser = ParseInput("char array2d[2,2]");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("array2d[0,0] = 5");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);
        }

        [TestMethod]
        [ExpectedException(typeof(ParseCanceledException))]
        public void TestInvalidMapDeclaration(){

            CustomParser parser = ParseInput("map test(3)(50)(50) = 5 , \"lag2\", \"lag3\"");

            CustomParser.StatementContext context = parser.statement();


            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
        }

        [TestMethod]
        [ExpectedException(typeof(ParseCanceledException))]
        public void TestInvalidMapAccess(){

            CustomParser parser = ParseInput("map test(3)(50)(50) = \"lag1\" , \"lag2\", \"lag3\"");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("access test(5)");

            CustomParser.StatementContext context2 = parser2.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);
            
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidMapModification(){

            CustomParser parser = ParseInput("map test(3)(50)(50) = \"lag1\" , \"lag2\", \"lag3\"");

            CustomParser.StatementContext context = parser.statement();

            CustomParser parser2 = ParseInput("int nyTest1[50,50]");

            CustomParser.StatementContext context2 = parser2.statement();

            CustomParser parser3 = ParseInput("modify test(\"lag2\") = nyTest1");

            CustomParser.StatementContext context3 = parser3.statement();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            visitor.Visit(context);
            visitor.Visit(context2);
            visitor.Visit(context3);
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