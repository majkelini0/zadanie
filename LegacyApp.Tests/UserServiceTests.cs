namespace LegacyApp.tests;

public class UserServiceTests
{
    // AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail OK
    // AddUser_ReturnsFalseWhenYoungerThen21YearsOld OK
    // AddUser_ReturnsTrueWhenVeryImportantClient OK
    // AddUser_ReturnsTrueWhenImportantClient OK
    // AddUser_ReturnsTrueWhenNormalClient OK
    // AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit FAILED
    // AddUser_ThrowsExceptionWhenUserDoesNotExist FAILED
    // AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser FAILED
    
    [Fact] // FAILED
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        // Arrange
        string firstName = "John";
        string lastName = "Doe";
        string email = "johndoe@gmail.com";
        DateTime dateOfBirth = new DateTime(1980, 1, 1);
        int clientId = 1;
        var userService = new UserService();

        // Act
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        // Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        // Arrange
        string firstName = "John";
        string lastName = "Doe";
        string email = "johndoe@gmail.com";
        DateTime dateOfBirth = new DateTime(1980, 1, 1);
        int clientId = 1;
        var userService = new UserService();

        // Act
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        // Assert
        Assert.Equal(true, result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        // Arrange
        string firstName = "John";
        string lastName = "Doe";
        string email = "johndoe@gmail.com";
        DateTime dateOfBirth = new DateTime(1980, 1, 1);
        int clientId = 3;
        var userService = new UserService();

        // Act
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        // Assert
        Assert.Equal(true, result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        // Arrange
        string firstName = "John";
        string lastName = "Doe";
        string email = "johndoe@gmail.com";
        DateTime dateOfBirth = new DateTime(1980, 1, 1);
        int clientId = 2;
        var userService = new UserService();

        // Act
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        // Assert
        Assert.Equal(true, result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        // Arrange
        string firstName = "John";
        string lastName = "Doe";
        string email = "johndoe@gmail.com";
        DateTime dateOfBirth = new DateTime(2020, 1, 1);
        int clientId = 1;
        var userService = new UserService();

        // Act
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        // Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        // Arrange
        string firstName = "John";
        string lastName = "Doe";
        string email = "johndoegmailcom";
        DateTime dateOfBirth = new DateTime(1980, 1, 1);
        int clientId = 1;
        var userService = new UserService();

        // Act
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        // Assert
        Assert.Equal(false, result);
    }
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            null, 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        // Assert.Equal(false, result);
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            -1
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact] // FAILED
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            -1
        );

        // Assert
        Assert.Throws<Exception>(action);
    }

    [Fact] // FAILED
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            -1
        );

        // Assert
        Assert.Throws<Exception>(action);
    }
}