using Business.Models;

namespace Business.Interfaces;

public interface IFileWriter
{
    public void SaveListToFile(List<Contact> list);
}
