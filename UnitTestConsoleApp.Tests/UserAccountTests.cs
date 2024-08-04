using Moq;

namespace UnitTestConsoleApp.Tests;

public class UserAccountTests
{
    private UserAccount _userAccount;
    private Mock<IEmailService> _mockEmailService;

    public UserAccountTests()
    {
        _mockEmailService = new Mock<IEmailService>();
        _userAccount = new UserAccount(_mockEmailService.Object);
    }

    [Fact]
    public void SetEmail_ValidEmail_SendsWelcomeEmail_ReturnsTrue()
    {
        // Arrange
         string testEmail = "test@example.com";
         _mockEmailService.Setup(service => 
                service.SendEmail(testEmail, "Welcome", "Thank you for registering."))
                .Returns(true);

        // Act
        bool result = _userAccount.SetEmail(testEmail);

        // Assert
        Assert.True(result);
         _mockEmailService.Verify(service => 
                service.SendEmail(testEmail, "Welcome", "Thank you for registering."), Times.Once);
    }

    [Fact]
    public void SetEmailWithAttachment_ValidEmailAndAttachment_SendsEmailWithAttachment_ReturnsFalse()
    {
        // Arrange
        string testEmail = "test@example.com";
        string attachmentPath = "path/to/attachment"; 
        _mockEmailService.Setup(service =>
                service.SendEmailWithAttachment(testEmail, "Welcome", "Thank you for registering.", attachmentPath))
                .Returns(false);

        // Act
        bool result = _userAccount.SetEmailWithAttachment(testEmail, "Welcome", "Thank you for registering.", attachmentPath);

        // Assert
        Assert.False(result); 
        _mockEmailService.Verify(service =>
                service.SendEmailWithAttachment(testEmail, "Welcome", "Thank you for registering.", attachmentPath), Times.Once);
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