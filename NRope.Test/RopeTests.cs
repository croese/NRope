

using System.Linq;
using Xunit;

namespace NRope.Test
{
  public class RopeTests
  {
    [Theory]
    [InlineData("")]
    [InlineData("hello")]
    public void RopeHasALength(string str)
    {
      var r = new Rope(str);
      Assert.Equal(str.Length, r.Length);
    }

    [Theory]
    [InlineData("hello", " world!", "hello world!")]
    [InlineData("t", "otally", "e", "fficient", "totallyefficient")]
    public void RopesCanBeJoined(params string[] ss)
    {
      var expected = ss.Last();
      var first = ss.First();
      var args = ss.Skip(1).Take(ss.Length - 2);

      var r = args.Aggregate(new Rope(first),
                             (accum, cur) => accum.Join(new Rope(cur)));
      Assert.Equal(expected.Length, r.Length);
      Assert.Equal(expected, r.ToString());
    }
  }
}
