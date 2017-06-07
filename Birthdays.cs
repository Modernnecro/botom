using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botom
{
  /// <summary>
  /// Birthdays
  /// </summary>
  public static partial class OtherBitsOfData
  {
    // A three-arg tuple contains three objects
    // (think like a row in a database, each element is a field!)
    // I did this because it is then easier to organise stuff for you. Each tuple is someones
    // birthday. Each tuple has a string (the person's name), a day and month, and an extra bit of
    // text to put on the end :)
    public static readonly Tuple<string /*name*/, int /*day*/, int /*month*/, string /*extra text*/>[] BIRTHDAYS =
    {
      new Tuple<string, int, int, string>("Mike", 7, 2, ":fireworks: :sparkles:"),
      new Tuple<string, int, int, string>("Rotom", 23, 3, ":pizza: :fireworks:"),
      new Tuple<string, int, int, string>("Undead Chiko", 10, 5, ":spaghetti: :fireworks: :cookie:"),
      new Tuple<string, int, int, string>("Bernon", 4, 7, ":pizza: :fireworks: :pizza:"),
    };
  }
}
