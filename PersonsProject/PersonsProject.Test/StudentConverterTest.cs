using PersonsProject.Converters;
using PersonsProject.Models;
using PersonsProject.Test.DataGenerators;
using Xunit;

namespace PersonsProject.Test
{
    /// <summary>
    /// Tests for <see cref="StudentConverter"/>.
    /// </summary>
    public class StudentConverterTest
    {
        private const int OLD_HIGH_ACHIEVER_AGE = 22;
        private const int YOUNG_HIGH_ACHIEVER_AGE = 18;
        private const int HIGH_GRADE = 91;
        private const int MEDIAN_GRADE = 81;
        private const int lOW_GRADE = 61;

        private readonly StudentGenerator _studentGenerator;
        private readonly StudentConverter _sut;

        /// <summary>
        /// Setup.
        /// </summary>
        public StudentConverterTest()
        {
            _studentGenerator = new StudentGenerator();
            _sut = new StudentConverter();
        }

        /// <summary>
        /// ConvertStudents method should return a list with the same count of elements as the input list.
        /// </summary>
        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(7)]
        [InlineData(12)]
        public void ConvertStudents_ListCountVerification_HasCorrectCount(int inputCount)
        {
            // Arrange
            var studentsList = _studentGenerator.CreateStudents(inputCount);

            // Act
            var result = _sut.ConvertStudents(studentsList);

            // Assert
            Assert.Equal(inputCount, result.Count);
        }

        /// <summary>
        /// ConvertStudents method on giving an empty array, should return an empty array.
        /// </summary>
        [Fact]
        public void ConvertStudents_EmptyArrayInput_ReturnsEmptyArray()
        {
            // Arrange
            var emptyStudentsList = new List<Student>();

            // Act
            var result = _sut.ConvertStudents(emptyStudentsList);

            // Assert
            Assert.Empty(result);
        }

        /// <summary>
        /// ConvertStudents method on giving a null as an input, should throw an exception.
        /// </summary>
        [Fact]
        public void ConvertStudents_NullInput_ThrowsException()
        {
            // Arrange / Act / Assert
            _ = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = _sut.ConvertStudents(null);
            });
        }

        /// <summary>
        /// ConvertStudents method on giving an array with a student object of age 21 or above and grade 
        /// above 90, should return an object with the additional field HonorRoll set to true.
        /// </summary>
        [Fact]
        public void ConvertStudents_OldHighAchieverFlow_HasTrueHonorRollParam()
        {
            // Arrange
            var testStudent = _studentGenerator.CreateStudent();
            testStudent.Age = OLD_HIGH_ACHIEVER_AGE;
            testStudent.Grade = HIGH_GRADE;

            var studentsList = new List<Student>
            {
                testStudent
            };

            // Act
            var result = _sut.ConvertStudents(studentsList);
            var resultStudent = result.First();

            // Assert
            Assert.True(resultStudent.HonorRoll);
        }

        /// <summary>
        /// ConvertStudents method on giving an array with a student object of age less than 21 and grade 
        /// above 90, should return an object with the additional field Exceptional set to true. 
        /// </summary>
        [Fact]
        public void ConvertStudents_YoungHighAchieverFlow_HasTrueExceptionalParam()
        {
            // Arrange
            var testStudent = _studentGenerator.CreateStudent();
            testStudent.Age = YOUNG_HIGH_ACHIEVER_AGE;
            testStudent.Grade = HIGH_GRADE;

            var studentsList = new List<Student>
            {
                testStudent
            };

            // Act
            var result = _sut.ConvertStudents(studentsList);
            var resultStudent = result.First();

            // Assert
            Assert.True(resultStudent.Exceptional);
        }

        /// <summary>
        /// ConvertStudents method on giving an array with a student object of grade between 71 and 90, 
        /// should return an object with the additional field Passed set to true. 
        /// </summary>
        [Fact]
        public void ConvertStudents_PassedStudentFlow_HasTruePassedParam()
        {
            // Arrange
            var testStudent = _studentGenerator.CreateStudent();
            testStudent.Grade = MEDIAN_GRADE;

            var studentsList = new List<Student>
            {
                testStudent
            };

            // Act
            var result = _sut.ConvertStudents(studentsList);
            var resultStudent = result.First();

            // Assert
            Assert.True(resultStudent.Passed);
        }

        /// <summary>
        /// ConvertStudents method on giving an array with a student object of grade 70 or less, 
        /// should return an object with the additional field Passed set to false. 
        /// </summary>
        [Fact]
        public void ConvertStudents_FailedStudentFlow_HasFalsePassedParam()
        {
            // Arrange
            var testStudent = _studentGenerator.CreateStudent();
            testStudent.Grade = lOW_GRADE;

            var studentsList = new List<Student>
            {
                testStudent
            };

            // Act
            var result = _sut.ConvertStudents(studentsList);
            var resultStudent = result.First();

            // Assert
            Assert.False(resultStudent.Passed);
        }
    }
}