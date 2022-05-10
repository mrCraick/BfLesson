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
            var inputOutput = new InputOutput();
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
            var inputOutput = new InputOutput();
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
            var inputOutput = new InputOutput();
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
            var inputOutput = new InputOutput();
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
            var inputOutput = new InputOutput();
            var dataOperations = new DataOperations(repository, inputOutput);
            repository.Memory[repository.Current] = (char)0;
            repository.Program = "[++++[++++++++]+++++++]";
            var expectedCurrent1 = 23;
            var PositionNumber = 0;
            // act
            dataOperations.IfZeroNext(PositionNumber, repository.Program);
            var actual1 = PositionNumber;
            // assert
            Assert.Equal(expectedCurrent1, actual1);

        }

        [Fact]
        public void IfNoZeroBackTest()
        {
            // arrange
            var repository = new Repository();
            var inputOutput = new InputOutput();
            var dataOperations = new DataOperations(repository, inputOutput);
            repository.Memory[repository.Current] = (char)1;
            repository.Program = "[++++[++++++++]+++++++]";
            var expectedCurrent1 = 0;
            var PositionNumber = 22;

            // act
            dataOperations.IfNoZeroBack(PositionNumber, repository.Program);
            var actual1 = PositionNumber;

            // assert
            Assert.Equal(expectedCurrent1, actual1);
        }

    }

}
    // написать тест на каждую функцию в этом DataOperations
    // придумать как затестить InputOutput
//}