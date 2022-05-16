using System.IO;
using System.Text;
using Xunit;
// AAA RULE

// arrange  подготовка данных для какого-то кода 
// act исполнение кода
// assert проверяем результат отработки кода
namespace BrainFuckTestProject
{
    public class DataOperationTest
    {
        [Fact] //атрибут утверждение, что должно отработать без ошибок


        public void NextCellTest()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);

            var expectedCurrent1 = repository.Current + 1;
            var newCurrent = 69;
            var expectedCurrent2 = 70;

            // act
            dataOperations.NextCell();
            var actual1 = repository.Current;

            repository.Current = newCurrent;
            dataOperations.NextCell();
            var actual2 = repository.Current;
            // assert

            Assert.Equal(expectedCurrent1, actual1);
            Assert.Equal(expectedCurrent2, actual2);
        }

        [Fact]

        public void PreviusCellTest()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);

            var expectedCurrent1 = repository.Current;
            var newCurrent = 11;
            var expectedCurrent2 = 10;

            // act
            dataOperations.PreviusCell();
            var actual1 = repository.Current;

            repository.Current = newCurrent;
            dataOperations.PreviusCell();
            var actual2 = repository.Current;
            // assert

            Assert.Equal(expectedCurrent1, actual1);
            Assert.Equal(expectedCurrent2, actual2);
        }

        [Fact]

        public void NextCharValueTest()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);

            var expectedCurrent1 = (char)1;

            // act
            dataOperations.NextCharValue();
            var actual1 = repository.Memory[repository.Current];

            // assert
            Assert.Equal(expectedCurrent1, actual1); // 1; 2
         
        }

        [Fact]

        public void PreviousCharValueTest()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);

            repository.Memory[repository.Current] = (char)(repository.Memory[repository.Current] + 1); 
            var expectedCurrent1 = (char)0;

            // act
           
            dataOperations.PreviousCharValue();
            var actual1 = repository.Memory[repository.Current];

            // assert
            Assert.Equal(expectedCurrent1, actual1); 
        }
        
        
        [Fact]
        public void IfZeroNextTest()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);
            repository.Memory[repository.Current] = (char)0;
            repository.Program = "[++++[++++++++]+++++++]";
            var expectedCurrent1 = 22;
            var PositionNumber = 0;
            // act
            
            var actual1 = dataOperations.IfZeroNext(PositionNumber, repository.Program);
            // assert
            Assert.Equal(expectedCurrent1, actual1);

        }

        [Fact]
        public void IfNoZeroBackTest()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);
            repository.Memory[repository.Current] = (char)1;
            repository.Program = "[++++[++++++++]+++++++]";
            var expectedCurrent1 = 0;
            var PositionNumber = 22;

            // act
            
            var actual1 = dataOperations.IfNoZeroBack(PositionNumber, repository.Program);

            // assert
            Assert.Equal(expectedCurrent1, actual1);
        }

        [Fact]

        public void DisplayCellValueTest()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository,inputOutput);

            repository.Memory[0] = '{';
            var expectedCurrent = "{";
            // act
            dataOperations.DisplayCellValue();
            var actual = testTextWriter.OutputHeh;

            // assert
            Assert.Equal(expectedCurrent, actual);

        }

        [Fact]

        public void InputValueInCellTest()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);
            repository.Memory[0] = '}';
            var expectedCurrent = "}";

            // act

            dataOperations.InputValueInCell();
            var actual = testTextReader.InputHeh;
            // assert
            Assert.Equal(expectedCurrent, actual);

        }

        //public void enumСodeBrainFuckTest()

        //{
        //    // arrange
        //    var repository = new Repository();
        //    var testTextWriter = new TestTextWriter();
        //    var testTextReader = new TestTextReader();
        //    var inputOutput = new InputOutput(testTextReader, testTextWriter);
        //    var dataOperations = new DataOperations(repository, inputOutput);
        //    var brainFuckCode = "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.";
        //    var expectedCurrent = "Hello World!";

        //    // act
        //    dataOperations.enumСodeBrainFuck(brainFuckCode);
        //    var actual = testTextWriter.OutputHeh;

        //    // assert
        //    Assert.Equal(expectedCurrent, actual);
        //}




        public class TestTextReader : TextReader
        {
            private string _input;

            public string InputHeh => _input;

            public TestTextReader(string input)
            {
                _input = input;
            }
            public TestTextReader()
            { 
            }
            public string Read()
            {
                return _input;
            }
        }

        public class TestTextWriter : TextWriter
        {
            private string _output;

            public string OutputHeh => _output;
            
            public TestTextWriter(string output)
            {
                _output = output;

            }
            public TestTextWriter()
            {

            }
            public override Encoding Encoding => Encoding.UTF8;

            public override void Write(string output)
            {
                _output = output;
            }
        }

    }
    
}
       // тест на ввод и тест на ENUM (на енвм 6 тестов)