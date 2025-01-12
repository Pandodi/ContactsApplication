using Business.Dtos;
using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{
    public bool AddContact(NewContactForm contactForm);
    public IEnumerable<Contact> GetAllContacts();
    public bool UpdateContact(Contact contact);
    public bool DeleteContact(Contact contact);
}
