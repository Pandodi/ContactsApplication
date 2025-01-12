using System.ComponentModel.DataAnnotations;
using Business.Dtos;
using Business.Interfaces;
using ContactsApp.Interfaces;

namespace ContactsApp.Services;

public class MenuDialogs(IContactService contactService) : IMenuDialogs
{
    private readonly IContactService _contactService = contactService;

    public void ShowMainMenu()
    {
        var runMenu = true;

        do
        {
            Console.Clear();
            Console.WriteLine("1. Add contact to list");
            Console.WriteLine("2. View all current contacts");            
            Console.WriteLine("3. Quit app");
            Console.WriteLine("______________________________");
            Console.WriteLine("Enter option: ");

            var option = Console.ReadLine()!;

            switch (option.ToLower())
            {
                case "1":
                    AddContactOption();
                    break;

                case "2":
                    ViewContactListOption();
                    break;

                case "3":
                    runMenu = false;
                    break;

                default:
                    break;
            }
        } while (runMenu);
    }

    public void ViewContactListOption()
    {
        var contacts = _contactService.GetAllContacts();

        Console.Clear();
        Console.WriteLine("------Viewing all contacts------");

        foreach (var contact in contacts)
        {
            Console.WriteLine("____________________________________");
            Console.WriteLine($"First Name: {contact.FirstName}");
            Console.WriteLine($"Last Name: {contact.LastName}");
            Console.WriteLine($"Email Address: {contact.Email}");
            Console.WriteLine($"Phone Number: {contact.Phone}");
            Console.WriteLine($"Address: {contact.Address}");
            Console.WriteLine($"Postal Code: {contact.PostalCode}");
            Console.WriteLine($"City: {contact.City}");
            Console.WriteLine("____________________________________");
        }

        if (contacts.Count() == 0)
        {
            Console.WriteLine("No contacts available. Press any key to return.");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }

    }

    public void AddContactOption()
    {
        var contact = new NewContactForm();

        Console.Clear();
        Console.WriteLine("---Adding new contact---");
        Console.WriteLine("Type 'Quit' at anytime if you'd like to cancel adding new contact");

        try
        {
            contact.FirstName = PromptAndValidate("First Name: ", nameof(contact.FirstName));
            contact.LastName = PromptAndValidate("Last Name: ", nameof(contact.LastName));
            contact.Email = PromptAndValidate("Email Address: ", nameof(contact.Email));
            contact.Phone = PromptAndValidate("Phone Number: ", nameof(contact.Phone));
            contact.Address = PromptAndValidate("Address: ", nameof(contact.Address));
            contact.PostalCode = PromptAndValidate("Postal Code: ", nameof(contact.PostalCode));
            contact.City = PromptAndValidate("City: ", nameof(contact.City));

            _contactService.AddContact(contact);

            Console.WriteLine("Added contact to list successfully. Press any key to return.");
            Console.ReadKey();
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Adding contact canceled... Returning to main menu. Press any key to continue.");
            Console.ReadKey();
        }
    }

    public string PromptAndValidate(string prompt, string propertyName)
    {
        while (true)
        {
            Console.WriteLine();
            Console.Write(prompt);
            var input = Console.ReadLine() ?? string.Empty;

            if (input.ToLower() == "quit")
            {
                throw new OperationCanceledException("You chose to quit adding a contact.");
            }


            var results = new List<ValidationResult>();
            var context = new ValidationContext(new NewContactForm()) { MemberName = propertyName };

            if (Validator.TryValidateProperty(input, context, results))
                return input;

            Console.WriteLine($"{results[0].ErrorMessage}. Please try again.");

        }
    }
}
