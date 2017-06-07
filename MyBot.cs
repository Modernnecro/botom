using System;
using System.Linq;
using Discord;
using Discord.Commands;
using System.Text;

// Injects each of the otherbitsofdata stuff with all your
// massive arrays in, into this namespace, so I don't have to alter
// any code.
// :hackerman:
using static Botom.OtherBitsOfData;
using System.IO;

namespace Botom
{
  /// <summary>
  /// Rotoms bot.
  /// 
  /// Will attempt to read a file called "token.txt" from the same directory
  /// as the executable, and uses that for Discord Authentication.
  /// </summary>
  public sealed class MyBot
  {
    /// <summary>
    /// The discord client object to use.
    /// </summary>
    private DiscordClient discord;

    /// <summary>
    /// The command service to handle commands.
    /// </summary>
    private CommandService commands;

    /// <summary>
    /// A RNG.
    /// </summary>
    private Random r;

    /// <summary>
    /// Initialises and runs the bot.
    /// </summary>
    public MyBot()
    {
      r = new Random();

      discord = new DiscordClient(x =>
      {
        x.LogLevel = LogSeverity.Verbose;
        x.LogHandler = Log;
      });

      discord.UsingCommands(x =>
      {
        x.PrefixChar = '-';
        x.AllowMentionPrefix = true;
        Console.WriteLine(x);
      });

      commands = discord.GetService<CommandService>();
      
      // Discord events
      discord.UserJoined += OnJoin;
      discord.UserLeft += OnLeave;

      RegisterCommands();

      AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

      // Prints any error we get. If we do get an error, then we will
      // just disconnect and reconnect.
      while (true)
      {
        try
        {
          Connect();

          // If we reach this line, we have died because a person told us to shut down, so
          // break out of the loop.
          break;
        }
        catch (Exception ex)
        {
          UnhandledExceptionHandler(ex);
        }
      }
    }


    /// <summary>
    /// Connects using the token.
    /// </summary>
    private void Connect()
    {
      const string FILENAME = "token.txt";

      string token = string.Empty;

      using (StreamReader sr = File.OpenText(FILENAME))
      {
        token = sr.ReadLine();
      }
      
      discord.ExecuteAndWait(async () =>
        await discord.Connect(token, TokenType.Bot)
      );
    }
  
    /// <summary>
    /// Registers commands, and their descriptions.
    /// </summary>
    private void RegisterCommands()
    {
      commands.CreateCommand("hello")
              .Description("Says hello to you!")
              .Do(async (e) =>
      {
        await e.Channel.SendMessage("Hi!");
      });

      // I moved your lambda expressions for each command to functions, as it
      // makes it a bit easier to follow, and you were calling functions to assign the
      // commands anyway, so I guess this is what you were aiming to do?

      // We cant just pass the RandomPoke method to do, as the way it is programmed
      // means we have ambiguity between two overloads, which is a pain.
      commands.CreateCommand("randompoke")
              .Alias("randompoké")
              .Description("Picks a random Pokémon")
              .Do(new Action<CommandEventArgs>(RandomPoke));

      commands.CreateCommand("randomstart")
              .Alias("randomstarter", "randoms", "starter")
              .Description("Picks a random starter Pokémon")
              .Do(new Action<CommandEventArgs>(RandomStarter));

      commands.CreateCommand("randomregion")
              .Alias("randomreg", "randomr", "region")
              .Description("Picks a random region from the Pokémon world")
              .Do(new Action<CommandEventArgs>(RandomRegion));

      commands.CreateCommand("randomKa")
              .Alias("randomkanto")
              .Description("Picks a random Kanto Pokémon")
              .Do(new Action<CommandEventArgs>(RandomKa));

      commands.CreateCommand("randomJo")
              .Alias("randomjohto")
              .Description("Picks a random Johto Pokémon")
              .Do(new Action<CommandEventArgs>(RandomJo));

      commands.CreateCommand("randomHo")
              .Alias("randomhoenn")
              .Description("Picks a random Hoenn Pokémon")
              .Do(new Action<CommandEventArgs>(RandomHo));

      commands.CreateCommand("randomSi")
              .Alias("randomsinnoh")
              .Description("Picks a random Sinnoh Pokémon")
              .Do(new Action<CommandEventArgs>(RandomSi));

      commands.CreateCommand("randomUn")
              .Alias("randomunova")
              .Description("Picks a random Unova Pokémon")
              .Do(new Action<CommandEventArgs>(RandomUn));

      commands.CreateCommand("randomKl")
              .Alias("randomkalos")
              .Description("Picks a random Kalos Pokémon")
              .Do(new Action<CommandEventArgs>(RandomKl));

      commands.CreateCommand("randomAl")
              .Alias("randomalola")
              .Description("Picks a random Alola Pokémon")
              .Do(new Action<CommandEventArgs>(RandomAl));

      commands.CreateCommand("bday")
              .Alias("birthday", "whosbirthday")
              .Description("Works out who's birthday it is today")
              .Do(new Action<CommandEventArgs>(Birthdays));

      commands.CreateCommand("help")
              .Alias("usage", "helpme", "what", "idontunderstand", "sos", "?", "commands", "cmds")
              .Description("Shows the available commands")
              .Do(new Action<CommandEventArgs>(GeneralHelp));

      commands.CreateCommand("help")
              .Alias("usage", "helpme", "what", "idontunderstand", "sos", "?", "commands", "cmds")
              .Parameter("command")
              .Description("Shows the help for the given command.")
              .Do(new Action<CommandEventArgs>(CommandHelp));

      commands.CreateCommand("throwItem")
              .Alias("throw", "throwitem")
              .Description("Throws a random item at you!")
              .Do(new Action<CommandEventArgs>(ThrowItem));

      commands.CreateCommand("facts")
              .Alias("randomfact", "randomfacts", "fact")
              .Description("Generates a random fact")
              .Do(new Action<CommandEventArgs>(Facts));

      commands.CreateCommand("feedMe")
              .Alias("feedme")
              .Description("Feeds you!")
              .Do(new Action<CommandEventArgs>(FeedMike));

      commands.CreateCommand("mention")
              .Parameter("mention", ParameterType.Required)
              .Description("Mentions a user")
              .Do(new Action<CommandEventArgs>(Mention));

      commands.CreateCommand("eh")
              .Alias("meh", "bleh", "neh")
              .Description("Who knows?")
              .Do(new Action<CommandEventArgs>(Eh));

      commands.CreateCommand("muffin")
              .Alias("muffinG")
              .Description("Mmmmm... foood...")
              .Do(new Action<CommandEventArgs>(MuffinTime));

      commands.CreateCommand("mission")
             .Description("Generates a random mission objective")
             .Do(new Action<CommandEventArgs>(Mission));

      commands.CreateCommand("location")
             .Description("Generates a random mission location")
             .Do(new Action<CommandEventArgs>(Location));

      commands.CreateCommand("quest")
             .Description("Generates a random quest")
             .Do(new Action<CommandEventArgs>(Quest));

      // These set groups of commands up, I couldn't really be bothered to add code
      // to stop this, and I kinda like the way you did this.
      RegisterPostPicCommands();
    }

    /// <summary>
    /// This "correctly" gets the channel name. The built in method is broken.
    /// </summary>
    /// <param name="s">server to get the channel for.</param>
    /// <param name="name">The name of the channel</param>
    /// <returns>The channel object we can send messages to.</returns>
    private Channel GetChannel(Server s, string name)
    {
      return s.TextChannels.FirstOrDefault(
        (c) => c.Name.ToLower().Equals(name)
      );
    }

    /// <summary>
    /// Picks a random pokemon
    /// </summary>
    /// <param name="e">Event arguments</param>
    private async void RandomPoke(CommandEventArgs e)
    {
      int rand = r.Next(randompoke.Length);
      string randmon = randompoke[rand];
      await e.Channel.SendMessage(randmon);
      Console.WriteLine(randmon);
    }

    /// <summary>
    /// Picks a random starter
    /// </summary>
    /// <param name="e">Event arguments</param>
    private async void RandomStarter(CommandEventArgs e)
    {
      int rand = r.Next(randomstart.Length);
      string randmon = randomstart[rand];
      await e.Channel.SendMessage(randmon);
      Console.WriteLine(randmon);
    }

    /// <summary>
    /// Picks a random region.
    /// </summary>
    /// <param name="e">Event arguments</param>
    private async void RandomRegion(CommandEventArgs e)
    {
      int rand = r.Next(randomregion.Length);
      string randmon = randomregion[rand];
      await e.Channel.SendMessage(randmon);
      Console.WriteLine(randmon);
    }

    /// <summary>
    /// Picks a random Kanto Pokemon
    /// </summary>
    /// <param name="e">Event arguments</param>
    private async void RandomKa(CommandEventArgs e)
    {
      int rand = r.Next(randomKa.Length);
      string randmon = randomKa[rand];
      await e.Channel.SendMessage(randmon);
      Console.WriteLine(randmon);
    }

    /// <summary>
    /// Picks a random Johto Pokemon
    /// </summary>
    /// <param name="e">Event arguments</param>
    private async void RandomJo(CommandEventArgs e)
    {

      int rand = r.Next(randomJo.Length);
      string randmon = randomJo[rand];
      await e.Channel.SendMessage(randmon);
      Console.WriteLine(randmon);

    }

    /// <summary>
    /// Picks a random Hoenn Pokemon
    /// </summary>
    /// <param name="e">Event arguments</param>
    private async void RandomHo(CommandEventArgs e)
    {
      int rand = r.Next(randomHo.Length);
      string randmon = randomHo[rand];
      await e.Channel.SendMessage(randmon);
      Console.WriteLine(randmon);

    }

    /// <summary>
    /// Picks a random Sinnoh Pokemon
    /// </summary>
    /// <param name="e">Event arguments</param>
    private async void RandomSi(CommandEventArgs e)
    {
      int rand = r.Next(randomSi.Length);
      string randmon = randomSi[rand];
      await e.Channel.SendMessage(randmon);
      Console.WriteLine(randmon);
    }

    /// <summary>
    /// Picks a random Unova Pokemon
    /// </summary>
    /// <param name="e">Event arguments</param>
    private async void RandomUn(CommandEventArgs e)
    {
      int rand = r.Next(randomUn.Length);
      string randmon = randomUn[rand];
      await e.Channel.SendMessage(randmon);
      Console.WriteLine(randmon);
    }

    /// <summary>
    /// Picks a random Kalos Pokemon
    /// </summary>
    /// <param name="e">Event arguments</param>
    private async void RandomKl(CommandEventArgs e)
    {
      int rand = r.Next(randomKl.Length);
      string randmon = randomKl[rand];
      await e.Channel.SendMessage(randmon);
      Console.WriteLine(randmon);
    }

    /// <summary>
    /// Picks a random Alolan Pokemon.
    /// </summary>
    /// <param name="e">Event arguments</param>
    private async void RandomAl(CommandEventArgs e)
    {
      int rand = r.Next(randomAl.Length);
      string randmon = randomAl[rand];
      await e.Channel.SendMessage(randmon);
      Console.WriteLine(randmon);
    }

    /// <summary>
    /// Prints out birthdays.
    /// </summary>
    /// <param name="e">Event arguments.</param>
    private async void Birthdays(CommandEventArgs e)
    {
      #region your old version of this
      /*
        var mikeBday = new DateTime(DateTime.Now.Year, 7, 2, 23, 0, 0);
        var mikeBday2 = new DateTime(DateTime.Now.Year, 8, 2, 22, 59, 59);
        var rotomBday = new DateTime(DateTime.Now.Year, 23, 3, 0, 0, 0);
        var rotomBday2 = new DateTime(DateTime.Now.Year, 23, 3, 23, 59, 59);
        var chikoBday = new DateTime(DateTime.Now.Year, 10, 5, 0, 0, 0);
        var chikoBday2 = new DateTime(DateTime.Now.Year, 10, 5, 23, 59, 59);
        var umprespBday = new DateTime(DateTime.Now.Year, 4, 7, 0, 0, 0);
        var umprespBday2 = new DateTime(DateTime.Now.Year, 4, 7, 23, 59, 59);
        var now = new DateTime(DateTime.Now.Year, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        if (mikeBday < now && now < mikeBday2)
        {
          await e.Channel.SendMessage("Happy Birthday Mike !!!!!!!!!!!!!!!!!!!!!!!! :fireworks: :sparkles:");
          Console.WriteLine(e.User.Id);
        }
        if (rotomBday < now && now < rotomBday2)
        {
          await e.Channel.SendMessage("Happy Birthday Rotom!!!!!!!!!!!!! :pizza: :fireworks:");
        }
        if (chikoBday < now && now < chikoBday2)
        {
          await e.Channel.SendMessage("Happy Birthday Undead Chiko!!!!!!!!!!!!! :spaghetti: :fireworks: :cookie:");
        }
        if (umprespBday < now && now < umprespBday2)
        {
          await e.Channel.SendMessage("Happy Birthday Bernon!!!!!!!!!!!!!! :pizza: :fireworks: :pizza:");
        }
      */
      #endregion 

      // Get today's day and month.
      var day = DateTime.Now.Day;
      var month = DateTime.Now.Month;

      // Find any matches and send the message.
      // (Question... you said there was only 5 simultaneous messages allowed...
      // what happens if it is more than 5 people's birthdays?)
      // This will fix that issue for you, by only sending one message, rather than spamming 
      // lots of them!
      var sb = new StringBuilder();

      foreach (var potentialBirthday in BIRTHDAYS)
      {
        if (potentialBirthday.Item2 /*day*/ == day && potentialBirthday.Item3 /*month*/ == month)
        {
          var greeting = string.Format("Happy Birthday {0}!!!!!!!!!!! {1}",
                potentialBirthday.Item1 /*name*/,
                potentialBirthday.Item4 /*the extra emojis at the end*/);

          sb.AppendLine(greeting);
        }
      }

      if (sb.Length > 0)
        await e.Channel.SendMessage(sb.ToString());
      else
        await e.Channel.SendMessage("It is no one's birthday :-(");

    }

    /// <summary>
    /// Throws an item
    /// </summary>
    /// <param name="e">Event arguments.</param>
    private async void ThrowItem(CommandEventArgs e)
    {
      int rand = r.Next(items.Length);
      string randmon = items[rand];
      await e.Channel.SendMessage("*Throws " + randmon + ".*");
      Console.WriteLine(randmon);
    }

    /// <summary>
    /// Gives a random quest.
    /// </summary>
    /// <param name="e">Event arguments.</param>
    private async void Quest(CommandEventArgs e)
    {
      int rand = r.Next(dungeons.GetLength(0));
      string loc = dungeons[rand, 0];
      string bf = dungeons[rand, 2];
      int maxlev = Convert.ToInt32(dungeons[rand, 1]);
      string poke = "";
      string item = "";
      string quest = "";
      int lev = r.Next(maxlev);


      if (lev == 0)
      {
        lev = 1;
      }

      int rand2 = r.Next(3) + 1;
      string mission = "";

      if (rand2 == 1)
      {
        mission = "Rescue ";
        int som = r.Next(items.Length);
        poke = randompoke[som];
        quest = "Mission in " + loc + " at level " + bf + lev + ".  " + mission + poke + ".";
      }
      else if (rand2 == 2)
      {
        mission = "Get ";
        int som = r.Next(items.Length);
        item = items[som];
        quest = "Mission in " + loc + " at level " + bf + lev + ".  " + mission + item + ".";
      }
      else if (rand2 == 3)
      {
        mission = "Fight ";
        int som = r.Next(items.Length);
        poke = randompoke[som];
        quest = "Mission in " + loc + " at level " + bf + lev + ".  " + mission + poke + ".";
      }

      await e.Channel.SendMessage(quest);
      Console.WriteLine(quest);
    }

    /// <summary>
    /// Shows a random location.
    /// </summary>
    /// <param name="e">Event arguments.</param>
    private async void Location(CommandEventArgs e)
    {
      int rand = r.Next(dungeons.GetLength(0));
      string loc = dungeons[rand, 0];
      string bf = dungeons[rand, 2];
      int maxlev = Convert.ToInt32(dungeons[rand, 1]);
      int lev = r.Next(maxlev);
      if (lev == 0)
      {
        lev = 1;
      }
      await e.Channel.SendMessage("Mission in " + loc + " at level " + bf + lev + ".");
      Console.WriteLine("Mission in " + loc + " at level " + bf + lev + ".");
    }

    /// <summary>
    /// Registers the mission commands
    /// </summary>
    /// <param name="e">Event arguments</param>
    private async void Mission(CommandEventArgs e)
    {
      int rand3 = r.Next(3) + 1;
      string mission = "";

      if (rand3 == 1)
      {
        mission = "Rescue ";
        int som = r.Next(items.Length);
        string randmon = randompoke[som];
        await e.Channel.SendMessage(mission + randmon + ".");

      }
      else if (rand3 == 2)
      {
        mission = "Get ";
        int som = r.Next(items.Length);
        string randmon = items[som];
        await e.Channel.SendMessage(mission + randmon + ".");
      }
      else if (rand3 == 3)
      {
        mission = "Fight ";
        int som = r.Next(items.Length);
        string randmon = randompoke[som];
        await e.Channel.SendMessage(mission + randmon + ".");
      }
    }

    /// <summary>
    /// Feeds mike?
    /// </summary>
    /// <param name="e">Event arguments.</param>
    private async void FeedMike(CommandEventArgs e)
    {
      int rand = r.Next(feedMike.Length);
      string randmon = feedMike[rand];
      await e.Channel.SendMessage("*Puts " + randmon + " in front of " + e.User.Mention + ".*");
      Console.WriteLine(randmon);
    }

    /// <summary>
    /// Prints a random fact.
    /// </summary>
    /// <param name="e">Event arguments.</param>
    private async void Facts(CommandEventArgs e)
    {
      int rand = r.Next(facts.Length);
      string randmon = facts[rand];
      await e.Channel.SendMessage("Captain Here.  " + randmon + "       *flies away* ");
      Console.WriteLine(randmon);
    }

    /// <summary>
    /// Says hello to a user.
    /// </summary>
    /// <param name="e">Event arguments.</param>
    private async void Mention(CommandEventArgs e)
    {
      await e.Channel.SendMessage("Hello " + e.GetArg("mention"));
      Console.WriteLine(e.GetArg("mention"));
    }

    /// <summary>
    /// Sends "eh" or something?
    /// </summary>
    /// <param name="e">Event arguments.</param>
    private async void Eh(CommandEventArgs e)
    {
      await e.Channel.SendMessage("Meh, meh, meh, meh, meh, meh, meh, meh, meh, meh, meh, meh, meh, DERP!!");
    }

    // I didn't bother changing this one, since it is a nice idea to keep it like this for now.
    private void RegisterPostPicCommands()
    {
      /*
      commands.CreateCommand("randompic")
          .Description("Picks a random picture")
          .Do(async (e) =>
          {
            int rand = r.Next(randomPics.Length);
            string randmon = randomPics[rand];
            string stuff = "images/" + randmon;
            await e.Channel.SendFile(stuff);
            Console.WriteLine(randmon);
          });

      commands.CreateCommand("flareon")
          .Description("Finds a picture of flareon")
          .Do(async (e) =>
          {
            string stuff = "images/" + "flareon.jpg";
            await e.Channel.SendFile(stuff);
          });

      commands.CreateCommand("3")
          .Description("???")
          .Do(async (e) =>
          {
            await e.Channel.SendFile("ausCute.png");
          });


      commands.CreateCommand("eevee")
          .Description("Shows us an Eevee")
          .Do(async (e) =>
          {
            string stuff = "images/" + "eevee.jpg";
            await e.Channel.SendFile(stuff);
          });

      commands.CreateCommand("skylitten")
          .Description("Shows us a \"Sky Litten\"(?)")
          .Do(async (e) =>
          {
            string stuff = "images/" + "skylitten.jpg";
            await e.Channel.SendFile(stuff);
          });

      commands.CreateCommand("Tia")
          .Description("Pocky. :3")
          .Alias("Pocky", "PockyTia")
          .Do(async (e) =>
          {
            string stuff = "images/" + "PockyTia.jpg";
            await e.Channel.SendFile(stuff);
          });

      commands.CreateCommand("torrabox")
          .Description("Shows us a torrabox")
          .Do(async (e) =>
          {
            string stuff = "images/" + "torrabox.png";
            await e.Channel.SendFile(stuff);
          });

      commands.CreateCommand("littencake")
          .Description("Shows us a litten cake")
          .Do(async (e) =>
          {
            string stuff = "images/" + "littencake.png";
            await e.Channel.SendFile(stuff);
          });

      commands.CreateCommand("Mimikyuveelutions")
          .Description("Mimikyu cosplaying as the Eeveelutions, perhaps?")
          .Alias("Meeveelutions", "Meevee", "MimikyuEevee")
          .Do(async (e) =>
          {
            string stuff = "images/" + "Mimikyuveelutions.png";
            await e.Channel.SendFile(stuff);
          });

      commands.CreateCommand("feedmore")
          .Description("MOAAARRRR FOOOOD!")
          .Do(async (e) =>
          {
            string stuff = "images/" + "feedmore.png";
            await e.Channel.SendFile(stuff);
          });

      commands.CreateCommand("happylitten")
          .Description("Shows a happy litten")
          .Do(async (e) =>
          {
            string stuff = "images/" + "happylitten.png";
            await e.Channel.SendFile(stuff);
          });

      commands.CreateCommand("flareonlitten")
          .Description("Shows a Flareon and Litten")
          .Do(async (e) =>
          {
            string stuff = "images/" + "fliteon.png";
            await e.Channel.SendFile(stuff);
          });

      commands.CreateCommand("furfrouH")
          .Description("Shows a Furfrou with hearts")
          .Do(async (e) =>
          {
            string stuff = "images/" + "furfrouhearts.png";
            await e.Channel.SendFile(stuff);
          });

      commands.CreateCommand("torrafat")
          .Description("Fat litten")
          .Do(async (e) =>
          {
            string stuff = "images/" + "littenF.png";
            await e.Channel.SendFile(stuff);
          });

      commands.CreateCommand("meowstic")
          .Description("Meowstic")
          .Do(async (e) =>
          {
            string stuff = "images/" + "Meowstic.gif";
            await e.Channel.SendFile(stuff);
          });

      commands.CreateCommand("weaveroar")
          .Description("Weaveroar!")
          .Do(async (e) =>
          {
            string stuff = "images/" + "weavincineroar.png";
            await e.Channel.SendFile(stuff);
          });
      */
    }

    /// <summary>
    /// Prints stuff about muffins? :P
    /// </summary>
    private async void MuffinTime(CommandEventArgs e)
    {
      await e.Channel.SendMessage("It's muffintime!!");
      if (e.Command.Text.EndsWith("G"))
        await e.Channel.SendFile("images/muffin.gif");
      else
        await e.Channel.SendFile("images/muffin.png");
    }

   

    /// <summary>
    /// Shows general help.
    /// </summary>
    /// <param name="e">Command arguments</param>
    private async void GeneralHelp(CommandEventArgs e)
    {
      await commands.ShowGeneralHelp(e.User, e.Channel);
    }

    /// <summary>
    /// Gives help for a specific command.
    /// </summary>
    /// <param name="e">Command arguments</param>
    private async void CommandHelp(CommandEventArgs e)
    {
      try
      {
        Command nextCmd = commands.AllCommands.First((cmd) => cmd.Text.Equals(e.GetArg(0)));
        await commands.ShowCommandHelp(nextCmd, e.User, e.Channel);
      }
      catch
      {
        await e.Channel.SendMessage(string.Format("<@{0}>, that command doesn't exist :-(", e.User));
      }
    }

    /// <summary>
    /// Registers commands for deleting messages.
    /// </summary>
    private void DeleteChat()
    {
      // Deletes a single message.
      commands.CreateCommand("delete")
          .Do(async (e) =>
          {
            if (e.User.HasRole(e.Server.FindRoles("Admin").FirstOrDefault()))
            {
              Message[] messagesToDelete;

              messagesToDelete = await e.Channel.DownloadMessages(2);

              await e.Channel.DeleteMessages(messagesToDelete);
            }
          });

      // Deletes 10 messages
      commands.CreateCommand("delete10")
          .Do(async (e) =>
          {
            if (e.User.HasRole(e.Server.FindRoles("Admin").FirstOrDefault()))
            {
              Message[] messagesToDelete;

              messagesToDelete = await e.Channel.DownloadMessages(11);

              await e.Channel.DeleteMessages(messagesToDelete);
            }
          });

      // Deletes 100 messages
      commands.CreateCommand("delete100")
          .Do(async (e) =>
          {
            if (e.User.HasRole(e.Server.FindRoles("Admin").FirstOrDefault()))
            {
              Message[] messagesToDelete;

              messagesToDelete = await e.Channel.DownloadMessages(100);

              await e.Channel.DeleteMessages(messagesToDelete);
            }
          });
    }

    /// <summary>
    /// Event for when a user joins the server.
    /// </summary>
    /// <param name="sender">Sender of the event.</param>
    /// <param name="e">Event arguments</param>
    private async void OnJoin(object sender, UserEventArgs e)
    {
      Console.WriteLine(e);

      Channel channel = GetChannel(e.Server, "general");
      var user = e.User.Id;
      Message m = await channel.SendMessage(string.Format("Welcome to the server <@{0}>. Please read #rules first.", user));

    }

    /// <summary>
    /// Event for when a user leaves the server.
    /// </summary>
    /// <param name="sender">Sender of the event.</param>
    /// <param name="e">Event arguments</param>
    private async void OnLeave(object sender, UserEventArgs e)
    {
      Channel channel = GetChannel(e.Server, "general");
      var user = e.User.Id;
      await channel.SendMessage(string.Format("Oh no! <@{0}> has left!! :sob:", user));
    }
    
    /// <summary>
    /// Logs info to the console. The colour stuff and all the writelines are
    /// just to dump out info about what caused the message, what the message was, the
    /// exception if there was an error, etc. It does it in colour to make it easier to
    /// read.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Log(object sender, LogMessageEventArgs e)
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("Source: {0}", e.Source);
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("Message: {0}", e.Message);
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine("Exception: {0}", e.Exception);
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("Severity: {0}", e.Severity);
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Call Stack (first 10 lines, or whatever)");
      for (var i = 0; i < Math.Min(10, Environment.StackTrace.Count((c) => c == '\n')); ++i)
      {
        Console.WriteLine("{0}", Environment.StackTrace.Split('\n')[i]);
      }
      Console.WriteLine();

      Console.ResetColor();
    }

    /// <summary>
    /// Handles an unhandled exception.
    /// </summary>
    /// <param name="ex">The exception thrown.</param>
    private void UnhandledExceptionHandler(Exception ex)
    {
      Console.WriteLine(ex.StackTrace);

      // If we have a valid connection, dump the error to the
      // chat too so we know something has borked
      if (discord.State == ConnectionState.Disconnected)
      {
        Connect();
      }

      // Error to the friendcave server
      Server friendCaveServer = discord.Servers.First((ser) => ser.Name.Equals("Friend Cave"));
      Channel errorChannel = GetChannel(friendCaveServer, "coding_channel");

      var sb = new StringBuilder();
      sb.AppendLine("An exception occurred :-( ...");
      sb.AppendFormat("Exception was of type {0}\n", ex.GetType());
      sb.AppendFormat("Exception had message {0}\n", ex.Message);
      sb.AppendFormat("Exception had source {0}\n", ex.Source);
      sb.AppendFormat("The first few lines of stacktrace are:\n");
      string[] stacktrace = ex.StackTrace.Split('\n');

      sb.AppendLine("```");
      for (var i = 0; i < Math.Max(stacktrace.Length, 10); ++i)
      {
        sb.AppendLine(stacktrace[i]);
      }
      sb.AppendLine("```");

      errorChannel.SendMessage(sb.ToString());
      return;
    }

    /// <summary>
    /// Wrapper for the App Domain exception handler. This allows us to stop the app
    /// dieing if another thread dies.
    /// </summary>
    /// <param name="sender">Sender of the event</param>
    /// <param name="ueva">Event arguments</param>
    private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs ueva)
    {
      UnhandledExceptionHandler(ueva.ExceptionObject as Exception);
    }
  }
}
