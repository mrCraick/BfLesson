using System.IO;
using System.Text;
using Xunit;
// AAA RULE

// arrange  ïîäãîòîâêà äàííûõ äëÿ êàêîãî-òî êîäà 
// act èñïîëíåíèå êîäà
// assert ïğîâåğÿåì ğåçóëüòàò îòğàáîòêè êîäà
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
        [Fact] //àòğèáóò óòâåğæäåíèå, ÷òî äîëæíî îòğàáîòàòü áåç îøèáîê


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
            var testTextReader = new TestTextReader("}");
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);
            var expectedCurrent = '}';

            // act

            dataOperations.InputValueInCell();
            var actual = repository.Memory[0];
            // assert

            Assert.Equal(expectedCurrent, actual);

        }

        [Fact]

        public void enumÑodeBrainFuckTest1()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = "+";
            string nameExpected = nameof(testDataOperations.NextCharValue);


            // act
            testDataOperations.EnumÑodeBrainFuck(brainFuckCode); 
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }

        [Fact]
        public void enumÑodeBrainFuckTest2()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = "-";
            string nameExpected = nameof(testDataOperations.PreviousCharValue);


            // act
            testDataOperations.EnumÑodeBrainFuck(brainFuckCode);
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }
        [Fact]
        public void enumÑodeBrainFuckTest3()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = ".";
            string nameExpected = nameof(testDataOperations.DisplayCellValue);


            // act
            testDataOperations.EnumÑodeBrainFuck(brainFuckCode);
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }

        [Fact]
        public void enumÑodeBrainFuckTest4()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = ">";
            string nameExpected = nameof(testDataOperations.NextCell);


            // act
            testDataOperations.EnumÑodeBrainFuck(brainFuckCode);
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }

        [Fact]
        public void enumÑodeBrainFuckTest5()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = "<";
            string nameExpected = nameof(testDataOperations.PreviusCell);


            // act
            testDataOperations.EnumÑodeBrainFuck(brainFuckCode);
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }

        [Fact]
        public void enumÑodeBrainFuckTest6()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = ",";
            string nameExpected = nameof(testDataOperations.InputValueInCell);


            // act
            testDataOperations.EnumÑodeBrainFuck(brainFuckCode);
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }

        [Fact]
        public void enumÑodeBrainFuckTest7()
         {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = "[";
            string nameExpected = nameof(testDataOperations.IfZeroNext);


            // act
            testDataOperations.EnumÑodeBrainFuck(brainFuckCode);
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }

        [Fact]
        public void enumÑodeBrainFuckTest8()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = "]";
            string nameExpected = nameof(testDataOperations.IfNoZeroBack);


            // act
            testDataOperations.EnumÑodeBrainFuck(brainFuckCode);
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }
        // string a = nameof(EnumÑodeBrainFuck); çàïèñûâàåò íàèìåíîâàíèå ôóíêöèè â ïåğåìåííóş,
        // ÷òî ïîçâîëÿåò â äàëüíåéøåì, ïğè àâòî èçìåíåíèè ïåğåèìåííîâûâàòü è òóò, íåæåëè ïğîñòî "EnumÑodeBrainFuck"
        public class TestDataOperations : DataOperations
        {
            private bool _result;
            private string _name;
            
            public bool Result => _result;
            public string Name => _name;
            public TestDataOperations(Repository dataFromRepository,
        InputOutput inputOutput)
                :base(dataFromRepository, inputOutput)
            {
                _result = false;
            }
            public override void NextCharValue()
            {
                _result = true;
                _name = nameof(NextCharValue);
            }
            public override void PreviousCharValue()
            {
                _result = true;
                _name = nameof(PreviousCharValue);
            }
            public override void DisplayCellValue()
            {
                _result = true;
                _name = nameof(DisplayCellValue);
            }
            public override void NextCell()
            {
                _result = true;
                _name = nameof(NextCell);
            }
            public override void PreviusCell()
            {
                _result = true;
                _name = nameof(PreviusCell);
            }
            public override void InputValueInCell()
            {
                _result = true;
                _name = nameof(InputValueInCell);
            }
            public override int IfZeroNext(int PositionNumber, string BrainFuckCode) 
            {
                _result = true;
                _name = nameof(IfZeroNext);
                return 1;
            }
            public override int IfNoZeroBack(int PositionNumber, string BrainFuckCode)
            {
                _result = true;
                _name = nameof(IfNoZeroBack);
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
            public TestTextWriter() // êîíñòğóêòîğ, êîòîğûé ïîçâîëÿåò ñîçäàòü ıêçåìïëÿğ êëàññà áåç àãğóìåíòà
            {

            }
            public override Encoding Encoding => Encoding.UTF8; //ïîçâîëÿåò âğàéòåğó ïîíÿòü ÷òî íàïèñàòü

            public override void Write(string output)
            {
                _output = output;
            }
        }

    }
    
}
       // òåñò íà ââîä è òåñò íà ENUM (íà åíâì 6 òåñòîâ)