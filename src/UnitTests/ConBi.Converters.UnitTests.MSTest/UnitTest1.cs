using System;
using System.Collections.Generic;
using ComBi.Converters;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConBi.Converters.UnitTests.MSTest
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      const int value = -4321;
      IEnumerable<byte> expectedBytes = new byte[] {0xFF, 0xFF, 0xEF, 0x1F};

      var converter = new IntDataConverter();

      converter.ConvertToBytes(value).ShouldAllBeEquivalentTo(expectedBytes);
    }
  }
}
