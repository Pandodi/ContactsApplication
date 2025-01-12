using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;
using System.Text.Json;

namespace Business.Tests.Services;

public class FileService_Tests
{

    [Fact]
    public void SaveListToFile_ShouldSaveListToAFile()
    {
        //Arrange
        var content = TestData.TwoContactsList;
        var fileName = "test.json";

        IFileService fileService = new FileService("ContactsTest", fileName);

        try
        {
            //Act
            var result = fileService.SaveListToFile(content);
            //Assert
            Assert.True(result);
        }
        finally
        {
            if(File.Exists(Path.Combine("ContactsTest", fileName)))
            {
                File.Delete(Path.Combine("ContactsTest", fileName));
            }

        }
    }

    [Fact]
    public void LoadListFromFile_ShouldLoadListFromAFile()
    {
        //Arrange
        var content = TestData.TwoContactsList;
        var fileName = "test.json";
        File.WriteAllText(Path.Combine("ContactsTest", fileName), JsonSerializer.Serialize(content));


        IFileService fileService = new FileService("ContactsTest", fileName);
        fileService.SaveListToFile(content);

        try
        {
            //Act
            var result = fileService.LoadListFromFile();

            //Assert
            Assert.Equal(content, result);
        }
        finally
        {
            if (File.Exists(Path.Combine("ContactsTest", fileName)))
            {
                File.Delete(Path.Combine("ContactsTest", fileName));
            }
        }

    }
}
