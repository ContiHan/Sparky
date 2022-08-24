using Xunit;

namespace Sparky
{
    public class GradingCalculatorXUnitTests
    {
        private readonly GradingCalculator gradingCalculator;

        public GradingCalculatorXUnitTests()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Fact]
        public void gradeChecker_InputScore95Attendance90_ReturnGradeA()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;
            var gradeResult = gradingCalculator.GetGrade();

            Assert.Equal("A", gradeResult);
        }

        [Fact]
        public void gradeChecker_InputScore85Attendance90_ReturnGradeB()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;
            var gradeResult = gradingCalculator.GetGrade();

            Assert.Equal("B", gradeResult);
        }

        [Fact]
        public void gradeChecker_InputScore65Attendance90_ReturnGradeC()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;
            var gradeResult = gradingCalculator.GetGrade();

            Assert.Equal("C", gradeResult);
        }

        [Fact]
        public void gradeChecker_InputScore95Attendance65_ReturnGradeB()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;
            var gradeResult = gradingCalculator.GetGrade();

            Assert.Equal("B", gradeResult);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void gradeChecker_InputFailureScenario_ReturnGradeF(int score, int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;
            var gradeResult = gradingCalculator.GetGrade();

            Assert.Equal("F", gradeResult);
        }

        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void gradeChecker_InputDifferentScenarios_ReturnExpectedGrade(int score, int attendance, string expectedResult)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            var actualResult = gradingCalculator.GetGrade();

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
