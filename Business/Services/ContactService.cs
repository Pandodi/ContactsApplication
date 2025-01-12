using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class ContactService(IFileService fileService) : IContactService
{
    private List<Contact> _contacts = [];
    private readonly IFileService _fileService = fileService;

    public bool AddContact(NewContactForm contactForm)
    {
        try
        {
            var contact = ContactFactory.Create(contactForm);
            _contacts.Add(contact!);
            _fileService.SaveListToFile(_contacts);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public bool UpdateContact (Contact contact)
    {
        var contactToUpdate = _contacts.FirstOrDefault(c => c.Id == contact.Id);

        if (contactToUpdate == null)
        {
            return false;
        }

        contactToUpdate.FirstName = contact.FirstName;
        contactToUpdate.LastName = contact.LastName;
        contactToUpdate.Email = contact.Email;
        contactToUpdate.Phone = contact.Phone;
        contactToUpdate.Address = contact.Address;
        contactToUpdate.PostalCode = contact.PostalCode;
        contactToUpdate.City = contact.City;

        _fileService.SaveListToFile(_contacts);

        return true;
    }

    //This method was genereated by GitHub Copilot, with the exception of some minor critical changes.
    public bool DeleteContact(Contact contact)
    {
        var contactToDelete = _contacts.FirstOrDefault(c => c.Id == contact.Id);

        if (contactToDelete == null)
        {
            return false;
        }
        _contacts.Remove(contactToDelete);
        _fileService.SaveListToFile(_contacts);
        return true;
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        _contacts = _fileService.LoadListFromFile();
        return _contacts;
    }
}
