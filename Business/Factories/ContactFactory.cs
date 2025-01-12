
using Business.Dtos;
using Business.Helpers;
using Business.Models;
using System.Diagnostics;

namespace Business.Factories;

public static class ContactFactory
{
    public static NewContactForm Create()
    {
        return new NewContactForm();
    }

    public static Contact? Create(NewContactForm newContactForm)
    {
        try
        {
            return new Contact
            {
                Id = UniqueIdentifierGenerator.Generate(),
                FirstName = newContactForm.FirstName,
                LastName = newContactForm.LastName,
                Email = newContactForm.Email,
                Phone = newContactForm.Phone,
                Address = newContactForm.Address,
                PostalCode = newContactForm.PostalCode,
                City = newContactForm.City
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error adding contact: {ex.Message}");
            return null;
        }

    }
}
