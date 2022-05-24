using System.IO;
using System.Text;
using Xunit;
using Moq;

// AAA RULE

// arrange  подготовка данных для какого-то кода 
// act исполнение кода
// assert проверяем результат отработки кода

//[Theory] позволяет несколько раз отработать тест
//[InLineData("аргумент", "аргумент")] Позволяет всталять разные аргументы (аргументом может быть желаемый результат)
////[InLineData("аргумент2", "аргумент2")] и так подставлять разные аргусменты до бесконечности



namespace BrainFuckTestProject
{
    public class DataOperationTest
    {

        //[Fact] атрибут утверждение, что должно отработать без ошибок

        [Theory]
        [InlineData(0)]
        [InlineData(69)]
        [InlineData(121)]
        public void NextCellTest(int newCurrent)
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var brainFuckFunction = new BrainFuckFunction(repository, inputOutput);

            var expectedCurrent1 = newCurrent + 1;
            repository.Current = newCurrent;

            // act
            brainFuckFunction.NextCell();
            var actual1 = repository.Current;


            // assert

            Assert.Equal(expectedCurrent1, actual1);

        }

        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(13121)]

        public void PreviusCellTest(int newCurrent)
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var brainFuckFunction = new BrainFuckFunction(repository, inputOutput);

            var expectedCurrent1 = newCurrent - 1;
            repository.Current = newCurrent;

            // act
            brainFuckFunction.PreviusCell();
            var actual1 = repository.Current;
            // assert

            Assert.Equal(expectedCurrent1, actual1);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]

        public void NextCharValueTest(int newCurrent)
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var brainFuckFunction = new BrainFuckFunction(repository, inputOutput);

            var expectedCurrent1 = (char)newCurrent + 1;
            repository.Memory[repository.Current] = (char)newCurrent;

            // act
            brainFuckFunction.NextCharValue();
            var actual1 = repository.Memory[repository.Current];

            // assert
            Assert.Equal(expectedCurrent1, actual1); // 1; 2

        }

        [Theory]
        [InlineData(33)]
        [InlineData(23)]
        [InlineData(44)]

        public void PreviousCharValueTest(int newCurrent)
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var brainFuckFunction = new BrainFuckFunction(repository, inputOutput);

            var expectedCurrent1 = (char)newCurrent - 1;
            repository.Memory[repository.Current] = (char)newCurrent;

            // act

            brainFuckFunction.PreviousCharValue();
            var actual1 = repository.Memory[repository.Current];

            // assert
            Assert.Equal(expectedCurrent1, actual1);
        }


        [Theory]
        [InlineData("[]", 1)]
        [InlineData("[++++[++++++[][][][][][][][][][][]][+++++++][][][][]][][][][][][][][]++]+++++]", 52)]
        [InlineData("[++++[++++++++]++++++++[++++[[[+++++++++++[+++++++]]]--------------]]++++]", 73)]
        public void IfZeroNextTest(string newCurrentProgram, int expectedCurrent)
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var brainFuckFunction = new BrainFuckFunction(repository, inputOutput);
            repository.Memory[repository.Current] = (char)0;
            repository.Program = newCurrentProgram;
            var expectedCurrent1 = expectedCurrent;
            var PositionNumber = 0;
            // act

            var actual1 = brainFuckFunction.IfZeroNext(PositionNumber, repository.Program);
            // assert
            Assert.Equal(expectedCurrent1, actual1);

        }

        [Theory]
        [InlineData("[++++[++++++++]+++++++]", 22)]
        [InlineData("[[[]]]", 5)]
        [InlineData("[++++[++++++++]++++++++[++++[[[+++++++++++[+++++++]]]--------------]]++++]", 73)]
        public void IfNoZeroBackTest(string newCurrentProgram, int newPositionNumber)
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var brainFuckFunction = new BrainFuckFunction(repository, inputOutput);
            repository.Memory[repository.Current] = (char)1;
            repository.Program = newCurrentProgram;
            var expectedCurrent1 = 0;
            var positionNumber = newPositionNumber;

            // act

            var actual1 = brainFuckFunction.IfNoZeroBack(newPositionNumber, repository.Program);

            // assert
            Assert.Equal(expectedCurrent1, actual1);
        }

        [Fact]
      
        public void DisplayCellValueTest()
        {
            // arrange
            var mockTextWriter = new Mock<TextWriter>();
            var called = false;
            mockTextWriter.Setup(x => x.Write("{")).Callback(() => called = true);

            var repository = new Repository();
            var testTextReader = new TestTextReader();

            var inputOutput = new InputOutput(testTextReader, mockTextWriter.Object);
            var brainFuckFunction = new BrainFuckFunction(repository, inputOutput);

            repository.Memory[0] = '{';

            // act
            brainFuckFunction.DisplayCellValue();


            // assert
            Assert.True(called);

        }

        [Fact]

        public void InputValueInCellTest()
        {
            // arrange

            var mockTextReader = new Mock<TextReader>();
            mockTextReader.Setup(x => x.ReadLine()).Returns("}");

            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var inputOutput = new InputOutput(mockTextReader.Object, testTextWriter);
            var brainFuckFunction = new BrainFuckFunction(repository, inputOutput);
            var expectedCurrent = '}';

            // act

            brainFuckFunction.InputValueInCell();
            var actual = repository.Memory[0];
            // assert

            Assert.Equal(expectedCurrent, actual);

        }
        
        [Theory]
        [InlineData("+", "NextCharValue")]
        [InlineData("-", "PreviousCharValue")]
        [InlineData(".", "DisplayCellValue")]
        [InlineData(">", "NextCell")]
        [InlineData("<", "PreviusCell")]
        [InlineData(",", "InputValueInCell")]
        [InlineData("[", "IfZeroNext")]
        [InlineData("]", "IfNoZeroBack")]
        public void enumСodeBrainFuckTest(string brainFuckCode, string nameExpected)
        {
            // arrange
            var brainFuckFunction = new TestBrainFuckFunction();
            var dataOperations = new DataOperations(brainFuckFunction);
            


            // act
            dataOperations.EnumСodeBrainFuck(brainFuckCode);
            var actual = brainFuckFunction.Result;
            var actualName = brainFuckFunction.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }


        // string a = nameof(EnumСodeBrainFuck); записывает наименование функции в переменную,
        // что позволяет в дальнейшем, при авто изменении переименновывать и тут, нежели просто "EnumСodeBrainFuck"
        public class TestBrainFuckFunction : IBrainFuckFunction
        {
            private bool _result;
            private string _name;

            public bool Result => _result;
            public string Name => _name;
            public TestBrainFuckFunction()
            {
                _result = false;
                _name = string.Empty;
            }
            public void NextCharValue()
            {
                _result = true;
                _name = "NextCharValue";
            }
            public void PreviousCharValue()
            {
                _result = true;
                _name = "PreviousCharValue";
            }
            public void DisplayCellValue()
            {
                _result = true;
                _name = "DisplayCellValue";
            }
            public void NextCell()
            {
                _result = true;
                _name = "NextCell";
            }
            public void PreviusCell()
            {
                _result = true;
                _name = "PreviusCell";
            }
            public void InputValueInCell()
            {
                _result = true;
                _name = "InputValueInCell";
            }
            public int IfZeroNext(int PositionNumber, string BrainFuckCode) 
            {
                _result = true;
                _name = "IfZeroNext";
                return 1;
            }
            public int IfNoZeroBack(int PositionNumber, string BrainFuckCode)
            {
                _result = true;
                _name = "IfNoZeroBack";
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