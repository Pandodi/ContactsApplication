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


    //This test is checking if the LoadListFromFIle is working correctly, by saving a list in var content,
    //saving it to a file and seraializing it to a list, then checking if the list is the same as the content

    [Fact]
    public void LoadListFromFile_ShouldLoadListFromAFile()
    {
        //Arrange
        var content = TestData.TwoContactsList;
        var fileName = "test.json";
        var directoryPath = "ContactsTest";
        var filePath = Path.Combine(directoryPath, fileName);

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        File.WriteAllText(Path.Combine(filePath), JsonSerializer.Serialize(content));

        IFileService fileService = new FileService(directoryPath, fileName);

        try
        {
            //Act
            var result = fileService.LoadListFromFile();

            //Assert
            Assert.Equal(content.Count, result.Count);
            Assert.Equal(content[0].Id, result[0].Id);
            Assert.Equal(content[1].Id, result[1].Id);
            Assert.Equal(content[0].FirstName, result[0].FirstName);
            Assert.Equal(content[1].FirstName, result[1].FirstName);
            Assert.Equal(content[0].LastName, result[0].LastName);
            Assert.Equal(content[1].LastName, result[1].LastName);
            Assert.Equal(content[0].Email, result[0].Email);
            Assert.Equal(content[1].Email, result[1].Email);
            Assert.Equal(content[0].Phone, result[0].Phone);
            Assert.Equal(content[1].Phone, result[1].Phone);
        }
        finally
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath);
            }

        }
    }
}
