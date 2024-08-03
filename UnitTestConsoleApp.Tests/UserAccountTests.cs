namespace UnitTestConsoleApp.Tests;

public class UserAccountTests
{
    private UserAccount _userAccount;

    public UserAccountTests()
    {
        _userAccount = new UserAccount();
    }

    [Fact]
    public void SetEmail_ValidEmail_EmailIsSet()
    {
        // Arrange
        string email = "test@example.com";

        // Act
        _userAccount.SetEmail(email);

        // Assert
        Assert.Equal(email, _userAccount.GetEmail());
    }

    [Fact]
    public void SetEmail_EmptyEmail_ThrowsArgumentException()
    {
        // Arrange
        string emptyEmail = "";

        // Act and Assert
        var exception = Assert.Throws<ArgumentException>(() => _userAccount.SetEmail(emptyEmail));
    }

    [Fact]
    public void GetEmail_NoEmailSet_ReturnsNull()
    {
        // Act
        string email = _userAccount.GetEmail();

        // Assert
        Assert.Null(email);
    }

    [Theory]
    [InlineData("user@example.com")]
    [InlineData("admin@domain.com")]
    [InlineData("support@company.org")]
    public void SetEmails_ValidEmail_EmailIsSet(string email)
    {
        // Act
        _userAccount.SetEmail(email);

        // Assert
        Assert.Equal(email, _userAccount.GetEmail());
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void SetEmail_InvalidEmail_ThrowsArgumentException(string invalidEmail)
    {
        // Act and Assert
        var exception = Assert.Throws<ArgumentException>(() => _userAccount.SetEmail(invalidEmail));
        Assert.Equal("Email cannot be null or empty", exception.Message);
    }
}