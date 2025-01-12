using Business.Dtos;
using Business.Factories;
using Business.Models;

namespace Business.Tests.Factories;

public class ContactFactory_Tests
{
    [Fact]
    public void Create_Should_Return_NewContactForm()
    {
        // Arrange
        // Act
        var result = ContactFactory.Create();
        // Assert
        Assert.NotNull(result);
        Assert.IsType<NewContactForm>(result);
    }

    [Fact]
    public void Create_ShouldReturnContact()
    {
        // Arrange
        var contact = new NewContactForm()
        {
            FirstName = "Ridah",
            LastName = "Omran",
            Email = "ridah@omran.com",
            Phone = "123456789",
            Address = "123 Main St",
            PostalCode = "12345",
            City = "New York"
        };

        // Act
        var result = ContactFactory.Create(contact);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(8, result.Id.Length);
        Assert.Equal(contact.FirstName, result.FirstName);
        Assert.Equal(contact.LastName, result.LastName);
        Assert.Equal(contact.Email, result.Email);
        Assert.Equal(contact.Phone, result.Phone);
        Assert.Equal(contact.Address, result.Address);
        Assert.Equal(contact.PostalCode, result.PostalCode);
        Assert.Equal(contact.City, result.City);

        Assert.IsType<Contact>(result);

    }
}
