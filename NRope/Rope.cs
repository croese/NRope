using System;
using System.Text;

namespace NRope
{
  public class Rope
  {
    readonly string _data;
    readonly Rope _left;
    readonly Rope _right;

    public Rope(string s)
    {
      _data = s;
      Length = s.Length;
    }

    Rope(Rope left, Rope right)
    {
      _left = left;
      _right = right;
      Length = left.Length + right.Length;
    }

    public int Length { get; }

    public Rope Join(Rope other)
    {
      return new Rope(this, other);
    }

    void ToString(StringBuilder builder)
    {
      if (_data != null)
      {
        builder.Append(_data);
      }

      if (_left != null)
      {
        _left.ToString(builder);
      }

      if (_right != null)
      {
        _right.ToString(builder);
      }
    }

    public override string ToString()
    {
      var sb = new StringBuilder(Length);
      ToString(sb);
      return sb.ToString();
    }
  }
}
