namespace Use_Case_.Net_Nazarii_Ivasyshyn.Tests
{
  public class StudentTests
  {
    private StudentConverter _converter;

    public StudentTests()
    {
      _converter = new StudentConverter();
    }

    [Theory]
    [InlineData(21, 91)]
    [InlineData(30, 95)]
    public void HighAchiever(int age, int grade)
    {
      // Arrange
      Student student = new Student
      {
        Age = age,
        Grade = grade
      };
      List<Student> students = new List<Student> { student };

      // Act
      var result = _converter.ConvertStudents(students);

      // Assert
      Assert.NotNull(result);
      Assert.Equal(true, result.FirstOrDefault().HonorRoll);
    }

    [Fact]
    public void Exception_Young_HighAchiever()
    {
      // Arrange
      Student student = new Student
      {
        Age = 20,
        Grade = 91
      };
      List<Student> students = new List<Student> { student };

      // Act
      var result = _converter.ConvertStudents(students);

      // Assert
      Assert.NotNull(result);
      Assert.Equal(true, result.FirstOrDefault().Exceptional);
    }

    [Theory]
    [InlineData(71)]
    [InlineData(80)]
    [InlineData(90)]
    public void Passed_Student(int grade)
    {
      // Arrange
      Student student = new Student
      {
        Age = 20,
        Grade = grade
      };
      List<Student> students = new List<Student> { student };

      // Act
      var result = _converter.ConvertStudents(students);

      // Assert
      Assert.NotNull(result);
      Assert.Equal(true, result.FirstOrDefault().Passed);
    }

    [Theory]
    [InlineData(70)]
    [InlineData(65)]
    public void Failed_Student(int grade)
    {
      // Arrange
      Student student = new Student
      {
        Age = 20,
        Grade = grade
      };
      List<Student> students = new List<Student> { student };

      // Act
      var result = _converter.ConvertStudents(students);

      // Assert
      Assert.NotNull(result);
      Assert.Equal(false, result.FirstOrDefault().Passed);
    }

    [Fact]
    public void Empty_Array()
    {
      // Arrange
      List<Student> students = new List<Student> { };

      // Act
      var result = _converter.ConvertStudents(students);

      // Assert
      Assert.NotNull(result);
      Assert.Equal(0, result.Count);
      Assert.IsType<List<Student>>(result);
    }

    [Fact]
    public void Not_An_Array()
    {
      //Act, Assert
      ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => _converter.ConvertStudents(null));
    }
  }
}