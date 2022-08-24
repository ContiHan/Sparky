//namespace Sparky
//{
//    [TestFixture]
//    public class GradingCalculatorXUnitTests
//    {
//        private GradingCalculator gradingCalculator;

//        [SetUp]
//        public void Setup()
//        {
//            gradingCalculator = new GradingCalculator();
//        }

//        [Test]
//        public void gradeChecker_InputScore95Attendance90_ReturnGradeA()
//        {
//            gradingCalculator.Score = 95;
//            gradingCalculator.AttendancePercentage = 90;
//            var gradeResult = gradingCalculator.GetGrade();

//            Assert.That(gradeResult, Is.EqualTo("A"));
//        }

//        [Test]
//        public void gradeChecker_InputScore85Attendance90_ReturnGradeB()
//        {
//            gradingCalculator.Score = 85;
//            gradingCalculator.AttendancePercentage = 90;
//            var gradeResult = gradingCalculator.GetGrade();

//            Assert.That(gradeResult, Is.EqualTo("B"));
//        }

//        [Test]
//        public void gradeChecker_InputScore65Attendance90_ReturnGradeC()
//        {
//            gradingCalculator.Score = 65;
//            gradingCalculator.AttendancePercentage = 90;
//            var gradeResult = gradingCalculator.GetGrade();

//            Assert.That(gradeResult, Is.EqualTo("C"));
//        }

//        [Test]
//        public void gradeChecker_InputScore95Attendance65_ReturnGradeB()
//        {
//            gradingCalculator.Score = 95;
//            gradingCalculator.AttendancePercentage = 65;
//            var gradeResult = gradingCalculator.GetGrade();

//            Assert.That(gradeResult, Is.EqualTo("B"));
//        }

//        [Test]
//        [TestCase(95, 55)]
//        [TestCase(65, 55)]
//        [TestCase(50, 90)]
//        public void gradeChecker_InputFailureScenario_ReturnGradeF(int score, int attendance)
//        {
//            gradingCalculator.Score = score;
//            gradingCalculator.AttendancePercentage = attendance;
//            var gradeResult = gradingCalculator.GetGrade();

//            Assert.That(gradeResult, Is.EqualTo("F"));
//        }

//        [Test]
//        [TestCase(95, 90, ExpectedResult = "A")]
//        [TestCase(85, 90, ExpectedResult = "B")]
//        [TestCase(65, 90, ExpectedResult = "C")]
//        [TestCase(95, 65, ExpectedResult = "B")]
//        [TestCase(95, 55, ExpectedResult = "F")]
//        [TestCase(65, 55, ExpectedResult = "F")]
//        [TestCase(50, 90, ExpectedResult = "F")]
//        public string gradeChecker_InputDifferentScenarios_ReturnExpectedGrade(int score, int attendance)
//        {
//            gradingCalculator.Score = score;
//            gradingCalculator.AttendancePercentage = attendance;

//            return gradingCalculator.GetGrade();
//        }
//    }
//}
