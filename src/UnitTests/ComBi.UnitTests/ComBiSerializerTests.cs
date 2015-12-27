using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComBi.UnitTests.Setup;
using FluentAssertions;

namespace ComBi.UnitTests
{
  public class ComBiSerializerTests
  {
    public void ShouldOutputCorrectBytesInCorrectOrder()
    {
      var testData = CreateTestUser();

      var expectedBytes = BitConverter.GetBytes(testData.Id)
                                      .Concat(Encoding.ASCII.GetBytes(testData.FullName))
                                      .Concat(testData.PhoneNumbers.SelectMany(s => Encoding.ASCII.GetBytes(s)))
                                      .Concat(testData.Addresses.SelectMany(GetAddressBytes))
                                      .Concat(testData.CalculatedBytes ?? Enumerable.Empty<byte>())
                                      .Concat(Encoding.ASCII.GetBytes(testData.NickName))
                                      .Concat(GetAddressBytes(testData.ShippingAddresses));

      var bytes = ComBiSerializer.Serialize(testData);
      
      bytes.Should().Equal(expectedBytes);
    }

    private static User CreateTestUser()
    {
      return new User
             {
               Id = 1234,
               FirstName = "First",
               LastName = "Last",
               NickName = "NickName",
               PhoneNumbers = new[]
                              {
                                "555-555-5555",
                                "123-456-7890"
                              },
               Addresses = new[]
                           {
                             new Address
                             {
                               Street = "1234 Some Street",
                               City = "Somewhere",
                               State = "State",
                               ZipCode = 12345,
                             },
                             new Address
                             {
                               Street = "9876 Different Street",
                               City = "Different City",
                               State = "Same State",
                               ZipCode = 52653
                             }
                           },
               ShippingAddresses = new Address
               {
                 Street = "9876 Different Street",
                 City = "Different City",
                 State = "Same State",
                 ZipCode = 52653
               }
      };
    }

    private static IEnumerable<byte> GetAddressBytes(Address address)
    {
      if(address == null)
      {
        return Enumerable.Empty<byte>();
      }
      return Encoding.ASCII.GetBytes(address.Street)
                     .Concat(Encoding.ASCII.GetBytes(address.City))
                     .Concat(Encoding.ASCII.GetBytes(address.State))
                     .Concat(BitConverter.GetBytes(address.ZipCode));
    }
  }
}
