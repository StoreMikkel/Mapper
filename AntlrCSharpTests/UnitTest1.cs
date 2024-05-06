namespace AntlrCSharpTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antlr4.Runtime;

[TestClass]
public class UnitTest1
    {

        [TestMethod]
        public void TestValidDeclaration()
        {
            // Arrange
            string input = "int x = 5"; // Example valid input

            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidAssignment()
        {
            // Arrange
            string input = "int x = 5" + "x = 6"; // Example valid input

            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        
        
        [TestMethod]
        public void TestValidIf()
        {
            // Arrange
            string input = "int e = 3 int r = 5 if(e < r){10+10}"; // Example valid input

            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidAddition()
        {
            // Arrange
            string input = "int a = 2\n int b = 3\n a + b"; // Example valid input

            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidWhile()
        {
            // Arrange
            string input = "while (x < 10) { x + 1 }"; 
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidForLoop()
        {
            // Arrange
            string input = "for (int i = 0; i < 5; i++) { x = x + i }"; 
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidCrementer()
        {
            // Arrange
            string input = "x++"; 
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidArrayDeclaration()
        {
            // Arrange
            string input = "int array[] = {2,3,4,5}"; 
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidArrayAssignment()
        {
            // Arrange
            string input = "array[0] = 5"; 
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        public void TestValidArrayAccess()
        {
            // Arrange
            string input = "array[0]"; 
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        public void TestValidArray2dDeclaration()
        {
            // Arrange
            string input = "int array[2,2] = {2,3} {2,3}"; 
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        public void TestValidArray2dAssignment()
        {
            // Arrange
            string input = "array[2,2] = 5"; 
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        public void TestValid2dArrayAccess()
        {
            // Arrange
            string input = "array[2,2]"; 
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        public void TestValidBREAK()
        {
            // Arrange
            string input = "BREAK"; 
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        public void TestValidRandom()
        {
            // Arrange
            string input = "RANDOM(2,5)"; 
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        public void TestValidFileWrite()
        {
            // Arrange
            string input = "fileWrite(sArray[0,1],\"output.txt\")"; 
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        public void TestValidFileWriteNewline()
        {
            // Arrange
            string input = "fileWriteNewline(\"output.txt\")"; 
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsTrue(result);
        }

        



        // INVALID FROM HERE

        [TestMethod]
        public void TestInvalidDeclaration()
        {
            // Arrange
            string input = "int test * 2"; // Example invalid input
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsFalse(result);
        }
        public void TestInvalidAssignment()
        {
            // Arrange
            string input = "test = "; // Example invalid input
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestInvalidIf()
        {
            // Arrange
            string input = "if(e < r){}"; // Example invalid input
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsFalse(result);
        }

        

        [TestMethod]
        public void TestInvalidAddition()
        {
            // Arrange
            string input = "int a = 2\n int b = 3\n a +- b"; // Example invalid input
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestInvalidAddition2()
        {
            // Arrange
            string input = "int a = 2\n" + "int b = 3\n" + "int a + int b"; // Example invalid input
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestInvalidAddition3()
        {
            // Arrange
            string input = "int a = 2\n" + "int b = 3\n" + "a (+ b"; // Example invalid input
            // Act
            bool result = ParseInput(input);

            // Assert
            Assert.IsFalse(result);
        }

        // Helper method to parse input and return whether parsing was successful
        private bool ParseInput(string input)
        {
            AntlrInputStream inputStream = new AntlrInputStream(input);
            CalculatorLexer lexer = new CalculatorLexer(inputStream);
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            CustomParser parser = new CustomParser(tokenStream);
            


            try
            {
                // Attempt to parse the input
                parser.input(); 
                // If no parsing errors occurred, return true
                return true;  
            }
            catch (Exception ex){
                // If a parsing error occurs, handle it and display the line number
                Console.WriteLine($"Parsing error: {ex.Message}");
                
                return false;
            }
            
        }
}