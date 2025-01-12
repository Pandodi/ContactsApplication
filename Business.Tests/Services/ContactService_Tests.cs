using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Moq;

namespace Business.Tests.Services;

public class ContactService_Tests
{
    private readonly Mock<IContactService> _contactServiceMock;
    private readonly IContactService _contactService;

    public ContactService_Tests()
    {
        _contactServiceMock = new Mock<IContactService>();
        _contactService = _contactServiceMock.Object;
    }

    [Fact]
    public void AddContact_WhenCalled_ReturnsTrue()
    {
        // Arrange
        var contactForm = new NewContactForm
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "ridah@omran.com",
            Phone = "1234567890",
            Address = "1234 Elm St",
            PostalCode = "12345",
            City = "Springfield"
        };
        _contactServiceMock
            .Setup(cs => cs.AddContact(contactForm))
            .Returns(true);

        // Act
        var result = _contactService.AddContact(contactForm);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetAllContacts_WhenCalled_ReturnsAllContacts()
    {
        // Arrange
        var contacts = TestData.TwoContactsList;

        _contactServiceMock
            .Setup(cs => cs.GetAllContacts())
            .Returns(contacts);

        //Act
        var result = _contactService.GetAllContacts();

        //Assert
        Assert.NotEmpty(result);
        Assert.Equal(contacts.Count, result.Count());
    }

    [Fact]
    public void UpdateContact_WhenCalled_ReturnsTrue()
    {
        // Arrange
        var contact = new Contact
        {
            Id = "49f7b1b1",
            FirstName = "John",
            LastName = "Doe",
            Email = "john@ec.se",
            Phone = "1234567890",
            Address = "1234 Elm St",
            PostalCode = "12345",
            City = "Springfield"
        };
        _contactServiceMock
            .Setup(cs => cs.UpdateContact(contact))
            .Returns(true);

        // Act
        var result = _contactService.UpdateContact(contact);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void DeleteContact_WhenCalled_ReturnsTrue()
    {
        // Arrange
        var contact = new Contact
        {
            Id = "49f7b1b1",
            FirstName = "John",
            LastName = "Doe",
            Email = "john@ec.se",
            Phone = "1234567890",
            Address = "1234 Elm St",
            PostalCode = "12345",
            City = "Springfield"
        };
        _contactServiceMock
            .Setup(cs => cs.DeleteContact(contact))
            .Returns(true);

        // Act
        var result = _contactService.DeleteContact(contact);

        // Assert
        Assert.True(result);
    }

    //auto generated test by GitHub Copilot 
    [Fact]
    public void DeleteContact_WhenContactDoesNotExist_ReturnsFalse()
    {
        // Arrange
        var contact = new Contact
        {
            Id = "49f7b1b1",
            FirstName = "John",
            LastName = "Doe",
            Email = "ridah@gmail.com",
            Phone = "1234567890",
            Address = "1234 Elm St",
            PostalCode = "12345",
            City = "Springfield"
        };
        _contactServiceMock
            .Setup(cs => cs.DeleteContact(contact))
            .Returns(false);

        // Act
        var result = _contactService.DeleteContact(contact);

        // Assert
        Assert.False(result);
    }
}





