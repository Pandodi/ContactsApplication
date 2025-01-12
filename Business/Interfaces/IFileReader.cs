using Business.Models;

namespace Business.Interfaces;

public interface IFileReader
{
    public List<Contact> LoadListFromFile();
}
