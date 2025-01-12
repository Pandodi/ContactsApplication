using Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests.Helpers;

public class UniqueIdentifierGenerator_Tests
{
    [Fact]
    public void GenerateShouldReturnUniqueGuidOf8Characters()
    {
        // Arrange

        // Act
        var result = UniqueIdentifierGenerator.Generate();
        // Assert
        Assert.False(string.IsNullOrWhiteSpace(result));
        Assert.Equal(8, result.Length);
    }
}
