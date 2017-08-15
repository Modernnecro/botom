#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Botom
{
  /// <summary>
  /// Defines a birthday data type that stores the month and day.
  /// Provides equality operator and inequality operator overloads for Birthday and
  /// DateTime objects for simple comparisons.
  /// </summary>
  public struct Birthday
  {
    private int day, month;

    /// <summary>
    /// The username of the person who's birthday it is.
    /// </summary>
    [JsonProperty("UserName")]
    public string UserName { get; set; }

    /// <summary>
    /// Provides access to the day, throws an ArgumentOutOfRangeException if an invalid day
    /// is input.
    /// </summary>
    [JsonProperty("Day")]
    public int Day
    {
      get => day;
      set
      {
        // Validate setting the value.
        if (value > 31 || value <= 0)
          throw new ArgumentOutOfRangeException("Day", "Cannot be > 31 or < 1");
        // Set.
        day = value;
      }
    }

    /// <summary>
    /// Provides access to the month, throws an ArgumentOutOfRangeException if an invalid month.
    /// </summary>
    [JsonProperty("Month")]
    public int Month
    {
      get => month;
      set
      {
        if (value > 12 || value <= 0)
          throw new ArgumentOutOfRangeException("Month", "Cannot be > 12 or < 1");
        // Set.
        month = value;
      }
    }

    /// <summary>
    /// Equality operator that compares two birthdays.
    /// </summary>
    /// <param name="a">Left oprand.</param>
    /// <param name="b">Right oprand.</param>
    /// <returns>True if equal, false otherwise.</returns>
    public static bool operator ==(Birthday a, Birthday b) =>
      a.day == b.day && a.month == b.month;

    /// <summary>
    /// Inequality operator that compares two birthdays. (Must be defined if we
    /// define the == operator overload).
    /// </summary>
    /// <param name="a">Left oprand.</param>
    /// <param name="b">Right oprand.</param>
    /// <returns>True if inequal, false otherwise.</returns>
    public static bool operator !=(Birthday a, Birthday b) =>
      !(a == b);

    /// <summary>
    /// Compares a birthday to a datetime object.
    /// </summary>
    /// <param name="a">The birthday</param>
    /// <param name="b">The date time</param>
    /// <returns>True if a == b</returns>
    public static bool operator ==(Birthday a, DateTime b) =>
      a.day == b.Day && a.month == b.Month;

    /// <summary>
    /// Compares a birthday to a datetime object.
    /// </summary>
    /// <param name="a">The birthday</param>
    /// <param name="b">The date time</param>
    /// <returns>True if a != b</returns>
    public static bool operator !=(Birthday a, DateTime b) =>
      !(a == b);

    /// <summary>
    /// Gets the birthday as a string.
    /// </summary>
    public override string ToString()
    {
      string monthStr;

      switch (Month)
      {
        case 1: monthStr = " January"; break;
        case 2: monthStr = " Febuary"; break;
        case 3: monthStr = " March"; break;
        case 4: monthStr = " April"; break;
        case 5: monthStr = " May"; break;
        case 6: monthStr = " June"; break;
        case 7: monthStr = " July"; break;
        case 8: monthStr = " August"; break;
        case 9: monthStr = " September"; break;
        case 10: monthStr = " October"; break;
        case 11: monthStr = " November"; break;
        case 12: monthStr = " December"; break;
        default:
          monthStr = " Januar...what? Pretty sure that isn't a month!";
          break;
      }

      return Day + monthStr;
    }
  }

  /// <summary>
  /// Provides methods to read and write birthdays from a JSON file.
  /// </summary>
  public static class BirthdayHandler
  {
    /// <summary>
    /// The JSON file to read and write birthday's to and from.
    /// </summary>
    private const string BIRTHDAY_JSON_FILE = "birthday.json";

    /// <summary>
    /// The serializer to use for serialization and deserialization bits.
    /// </summary>
    private static readonly JsonSerializer SERIALIZER = new JsonSerializer();

    /// <summary>
    /// Reads the birthday of the given user from file.
    /// </summary>
    /// <param name="userName">The username to look up.</param>
    /// <returns>The birthday.</returns>
    /// <exception cref="MissingFieldException">If the entry doesn't exist</exception>
    /// <exception cref="IOException">If we cannot read the file.</exception>
    public static Birthday ReadBirthday(string userName)
    {
      List<Birthday> birthdays = ReadBirthdays();

      var doesBirthdayExist = birthdays.Exists(
        //(birthday) => birthday.UserName.Equals(userName)
        (birthday) => {
          var equals = birthday.UserName.Equals(userName);
          Console.WriteLine("Comparing birthday {0} {1} to username {2}",
            birthday.UserName,
            birthday.ToString(),
            userName
          );
          return equals;
        }
      );

      if (doesBirthdayExist)
      {
        return birthdays.Find(
          (birthday) => birthday.UserName.Equals(userName)
        );
      }
      else
        throw new MissingFieldException("Birthday for " + userName + " was not stored!");
    }

    /// <summary>
    /// Reads all birthdays from the file and returns an iterable object across them.
    /// </summary>
    /// <exception cref="IOException">If we cannot read the file.</exception>
    public static List<Birthday> ReadBirthdays()
    {
      // Read the JSON file to string.
      var jsonContents = File.ReadAllText(BIRTHDAY_JSON_FILE);

      // Deserialize to an Array of Birthday objects
      return JsonConvert.DeserializeObject<List<Birthday>>(jsonContents);
    }

        /// <summary>
        /// Adds, or, if it already exists, updates the data for the birthday for the given
        /// user.
        /// </summary>
        /// <param name="newBirthday">The new birthday to add.</param>
        /// <exception cref="IOException">If we cannot read the file.</exception>
        /// <summary>
        /// Adds, or, if it already exists, updates the data for the birthday for the given
        /// user.
        /// </summary>
        /// <param name="newBirthday">The new birthday to add.</param>
        /// <exception cref="IOException">If we cannot read the file.</exception>
        public static void AddOrUpdateBirthday(Birthday newBirthday)
        {
            List<Birthday> existingData;

            // Write an empty list to the file if it doesn't exist.
            if (!File.Exists(BIRTHDAY_JSON_FILE))
            {
                Console.WriteLine("Creating a new birthday file.");
                using (FileStream fs = File.Create(BIRTHDAY_JSON_FILE))
                {
                    var writer = new StreamWriter(fs);
                    writer.WriteLine("[ ]");
                    writer.Close();
                }

                existingData = new List<Birthday>();
                existingData.Add(newBirthday);
            }
            else
            {

                // Read the existing data.
                existingData = ReadBirthdays();

                Console.WriteLine("Found {0} birthdays", existingData.Count);

                var doesBirthdayAlreadyExist = existingData.Exists(
                  (birthday) => birthday.UserName.Equals(newBirthday.UserName)
                );

                // If the user has already added their birthday, just update it.
                if (doesBirthdayAlreadyExist)
                {
                    existingData.RemoveAll((birthday) =>
                      birthday.UserName.Equals(newBirthday.UserName));


                }
                existingData.Add(newBirthday);
            }

            // Serialize back to file.
            using (var writer = new StreamWriter(File.OpenWrite(BIRTHDAY_JSON_FILE)))
            {
                SERIALIZER.Serialize(writer, existingData);
            }
        }
    }
  }

