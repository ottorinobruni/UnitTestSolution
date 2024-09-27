using FluentAssertions;

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
        _userAccount.GetEmail().Should().Be(email);
    }

    [Fact]
    public void SetEmail_EmptyEmail_ThrowsArgumentException()
    {
        // Arrange
        string emptyEmail = "";

        // Act and Assert
        Action act = () => _userAccount.SetEmail(emptyEmail);
        act.Should().Throw<ArgumentException>()
                .WithMessage("Email cannot be null or empty");
    }

    [Fact]
    public void GetEmail_NoEmailSet_ReturnsNull()
    {
        // Act
        string email = _userAccount.GetEmail();

        // Assert
        email.Should().BeNull();
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
        _userAccount.GetEmail().Should().Be(email);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void SetEmail_InvalidEmail_ThrowsArgumentException(string invalidEmail)
    {
        // Act
        Action act = () => _userAccount.SetEmail(invalidEmail);

        // Assert using FluentAssertions
        act.Should().Throw<ArgumentException>()
        .WithMessage("Email cannot be null or empty");
    }
}