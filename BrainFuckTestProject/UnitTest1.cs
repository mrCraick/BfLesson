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
        public DataOperationTest()
        {
            Repository repository = new Repository();
            TestTextWriter testTextWriter = new TestTextWriter();
            TestTextReader testTextReader = new TestTextReader();
            InputOutput inputOutput = new InputOutput(testTextReader, testTextWriter);
            DataOperations dataOperations = new DataOperations(repository, inputOutput);
        }
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
            var testTextReader = new TestTextReader("H");
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);
            repository.Memory[0] = '}';
            var expectedCurrent = "}";

            // act

            dataOperations.InputValueInCell();
            //var actual = testTextReader.InputHeh;
            var actual = repository.Memory[0];
            // assert

            Assert.Equal(expectedCurrent[0], actual);

        }

        public void enumСodeBrainFuckTest()
        {
            // arrange
            
        var repository = new Repository();
        var testTextWriter = new TestTextWriter();
        var testTextReader = new TestTextReader();
        var inputOutput = new InputOutput(testTextReader, testTextWriter);
        var dataOperations = new DataOperations(repository, inputOutput);
        var testDataOperations = new TestDataOperations(Repository repository, InputOutput inputOutput);
        var brainFuckCode = "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.";
        var expectedCurrent1 = 1;
        var expectedCurrent2 = 1;
        var expectedCurrent3 = 1;
        var expectedCurrent4 = 1;
        var expectedCurrent5 = 1;
        var expectedCurrent6 = 1;
        var expectedCurrent7 = 1;
        var expectedCurrent8 = 1;

            // act
        dataOperations.enumСodeBrainFuck(brainFuckCode);
        var actual = testTextWriter.OutputHeh;

        // assert
        Assert.Equal(expectedCurrent, actual);
        }




    public class TestDataOperations : DataOperations
        {
            private string _result = 1;
            
            public string Result => _result;


            public TestDataOperations(Repository dataFromRepository,
        InputOutput inputOutput)
                :base(dataFromRepository, inputOutput)
            {
                
            }
            public override void NextCharValue()
            {
                
            }
            public override void PreviousCharValue()
            {

            }
            public override void DisplayCellValue()
            {

            }
            public override void NextCell()
            {

            }
            public override void PreviusCell()
            {

            }
            public override void InputValueInCell()
            {

            }
            public override int IfZeroNext(int PositionNumber, string BrainFuckCode)
            {
                return 1;
            }
            public override int IfNoZeroBack(int PositionNumber, string BrainFuckCode)
            {

                return 1;
            }


        }

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
            public override string ReadLine()
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
            public TestTextWriter() // конструктор, который позволяет создать экземпляр класса без агрумента
            {

            }
            public override Encoding Encoding => Encoding.UTF8; //позволяет врайтеру понять что написать

            public override void Write(string output)
            {
                _output = output;
            }
        }

    }
    
}
       // тест на ввод и тест на ENUM (на енвм 6 тестов)