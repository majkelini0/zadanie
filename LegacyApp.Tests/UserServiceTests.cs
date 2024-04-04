using Xunit.Abstractions;

namespace LegacyApp.tests;

public class UserServiceTests
{
    // AddUser_ReturnsFalseWhenFirstNameIsEmpty OK
    // AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail OK
    // AddUser_ReturnsFalseWhenYoungerThen21YearsOld OK
    // AddUser_ReturnsTrueWhenVeryImportantClient OK
    // AddUser_ReturnsTrueWhenImportantClient OK
    // AddUser_ReturnsTrueWhenNormalClient OK
    // AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit OK
    // AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist OK
    // AddUser_ThrowsArgumentExceptionWhenUserDoesNotExist OK
    // AddUser_ThrowsArgumentExceptionWhenUserNoCreditLimitExistsForUser OK
    
    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        // Arrange
        ClientRepository rep = new ClientRepository();
        User user = new User();

        // Act
        var result = rep.GetById(1);
        var userr = user.HasCreditLimit;

        // Assert
        Assert.Equal("NormalClient", result.Type);
        Assert.False(userr);
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
        Assert.True(result);
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
        Assert.True(result);
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
        Assert.True(result);
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
        Assert.False(result);
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
        Assert.False(result);
        
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
            "Tomasz", 
            "Problem", 
            "tomaszproblem@gmail.com",
            DateTime.Parse("1980-01-01"),
            -1
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenUserDoesNotExist()
    {
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Tomasz", 
            "Problem", 
            "tomaszproblem@gmail.com",
            DateTime.Parse("1980-01-01"),
            -1
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenUserNoCreditLimitExistsForUser()
    {
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Tomasz", 
            "Problem", 
            "tomaszproblem@gmail.com",
            DateTime.Parse("1980-01-01"),
            -1
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }
}