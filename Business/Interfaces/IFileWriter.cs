using Business.Models;

namespace Business.Interfaces;

public interface IFileWriter
{
    public bool SaveListToFile(List<Contact> list);
}
