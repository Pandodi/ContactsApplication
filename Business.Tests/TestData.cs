using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests;

public static class TestData
{
    public static List<Contact> TwoContactsList { get; set; } = 
    [

        new()
        {
            Id = "49f7b1b1",
            FirstName = "John",
            LastName = "Doe",
            Email = "ridah@omran.com",
            Phone = "1234567890",
            Address = "1234 Elm St",
            PostalCode = "12345",
            City = "Springfield"
        },
        new()
        {
            Id = "49f7b1b2",
            FirstName = "Jane",
            LastName = "Doe",
            Email = "omran@ridah.com",
            Phone = "0987654321",
            Address = "4321 Oak St",
            PostalCode = "54321",
            City = "Shelbyville"
        }
    ];     
}
