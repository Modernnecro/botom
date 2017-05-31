﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Audio;

namespace Botom
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        Random r;

        string[] randompoke;
        string[] randomKa;
        string[] randomJo;
        string[] randomHo;
        string[] randomSi;
        string[] randomUn;
        string[] randomKl;
        string[] randomAl;
        string[] items;
        string[] facts;
        string[] feedMike;
        string[] randomPics;
        string[] randomstart;
        string[] randomregion;
        string[,] dungeons;

        public MyBot()
        {
            r = new Random();

            #region Feed Mike
            feedMike = new string[]
            {
                "a can of tuna",
                ":fish:",
                ":pizza:",
                "a salmon fillet",
                "sashimi",
                "an indefinite amount of Pizza",
                "a bucket of ice cream",
                "a soft ice cream",
                "a chocolate bar",
                "a cup of hot chocolate",
                ":cookie:",
                "bananas",
                "fish and chips",
                "a deep fried piece of meat",
                "mystery meat",
                "meaty surprise (the surprise is: it's no meat)"
            };
            #endregion

            #region Random Pics
            randomPics = new string[]{
                "flareon.jpg",
                "fliteon.png",
                "furfrou-hearts.png",
                "littenF.png",
                "Meowstic.gif",
                "weavincineroar.png",
                "happylitten.png",
                "feedmore.png",
                "torrabox.png",
                "Mimikyuveelutions.png",
                "PockyTia.jpg",
                "skylitten.jpg",
                "eevee.jpg",
                "littencake.png"
            };
            #endregion

            #region Locations
            dungeons = new string[,]
            {
                { "Alberello Forest", "3" , "" },
                { "River Way", "7" , "B" },
                { "Water Front", "1" , "" },
                { "Alberello Field", "5" , "" },
                { "Foggy Valley", "4" , "" },
                { "Moonless Cavern", "5" , "B" },
                { "Breezy Hill", "3" , "" },
                { "Crystal Caves", "5" , "B" },
                { "Water Marsh", "6" , "" },
                { "Spirestone Canyon", "7" , "" },
                { "Berry Forest", "6" , "" },
                { "Desert Dune", "7" , "" },
                { "Desert Tomb", "5" , "B" },
                { "Root Cavern", "3" , "B" }

            };
            #endregion

            #region Facts
            facts = new string[]
            {
                "Did you know a pokémon with all 18 types would still be weak to Rock?",
                "In one of the episodes, Ash actually transforms in a Pikachu. A pokémon Witch transforms him so he can 'talk' to pokemon. He does keep on talking in human speak though.",
                "Did you know Doduo just runs really fast if it uses Fly? Pokémon Stadium is proof.",
                "Did you know Arcenine was a legendary at first? A remnant of this can be found in his description: 'The Legendary Pokémon'",
                "Did you know Munna was mentioned for the very first time in Pokémon Red? That's 4 generations in advance!",
                "Azurill is the only Pokémon that can change Genders when Evolving! One out of Four change gender when evolving.",
                "It is said no two Spinda have the same pattern. To ensure that the Game Devs made sure there are over 4 billion different spot-patterns!",
                "Hitmonchan and Hitmonlee are named after Jackie Chan and Bruce Lee respectively... No wonder they're good at martial arts.",
                "Splash is known as the most useless normal type move ever (until Z-moves where introduced), but did you know it was supposed to be called 'Hop'?",
                "Did you know Kangaskhan might have been an evolution to Cubone? This is hinted at on several occasions, but mostly in the fact you can catch a Kangaskhan by SOS battling a Cubone in Pokémon Sun and Moon!",
                "Did you know Ash would have been running around with a Clefairy if not for some change of heart?",
                "Clefable has a living shadow in Gengar, the silhouettes of both pokémon look quite alike, and Gengar is even known as the 'shadow pokémon'.",
                "The 'legend of the White Hand' is so prominent in the Pokémon Universe, that the game Pokémon Red, Green and Blue had it, and there's a reference to it in the Pokémon Anime.",
                "The only pokémon banned out of the episodes is 'Porygon'. However it is actually Pikachu that caused it to get banned. He used a lightning bolt on a rocket Team Rocket send to the main Characters, being the cause of many epileptic attacks in Japanese kids. After the episode 'Electric Soldier Porygon' he is never seen again.",
                "In the episode 'The Legend of Dratini' Ash meets a Dratini, and catches a whole herd of Tauros. These are mentioned over and over again in later episodes, but since 'The Legend of Dratini' is a banned episode, because of guns, it's unknown how he'd get the Tauros in the series.",
                "Jynx was a black colored pokémon until the episode 'Holiday Hi-Jynx', after this protests arose and Jynx changed from complete blackness to purple. "
            };
            #endregion

            #region Random Items
            items = new string[]
            {
                #region Pokéballs
                "a Beast Ball",
                "a Cherish Ball",
                "a Dive Ball",
                "a Dream Ball",
                "a Dusk Ball",
                "a Fast Ball",
                "a Friend Ball",
                "a Great Ball",
                "a Heal Ball",
                "a Heavy Ball",
                "a Level Ball",
                "a Love Ball",
                "a Lure Ball",
                "a Luxury Ball",
                "a Master Ball",
                "a Moon Ball",
                "a Nest Ball",
                "a Net Ball",
                "a Park Ball",
                "a Poké Ball",
                "a Premier Ball",
                "a Quick Ball",
                "a Repeat Ball",
                "a Safari Ball",
                "a Sport Ball",
                "a Timer Ball",
                "an Ultra Ball",
                #endregion
                #region Recovery
                "an Ability Capsule",
                "an Antidote",
                "an Awakening",
                "a Berry Juice",
                "a Big Malasada",
                "a Burn Heal",
                "a Casteliacone",
                "an Elixer",
                "an Energy Root",
                "an EnergyPowder",
                "an Ether",
                "Fresh Water",
                "a Full Heal",
                "a Full Restore",
                "Heal Powder",
                "a Hyper Potion",
                "an Ice Heal",
                "a Lava Cookie",
                "a Lemonade",
                "a Lumiose Galette",
                "a Max Elixer",
                "a Max Potion",
                "a Max Ether",
                "a Max Revive",
                "Moomoo Milk",
                "an Old Gateau",
                "a Paralyz Heal",
                "a Potion",
                "a Ragecandybar",
                "a Revival Herb",
                "a Revive",
                "Sacred Ash",
                "a Shalour Sable",
                "a Soda Pop",
                "a Super Potion",
                "a Sweat Heart",
                #endregion
                #region Hold Items
                "an Absorb Bulb",
                "an Adamant Orb",
                "an Adrenaline Orb",
                "an Air Balloon",
                "an Amulet Coin",
                "an Assault Vest",
                "a Berserk Gene",
                "a Big Root",
                "a Binding Band",
                "a Black Belt",
                "Black Sludge",
                "Black Glasses",
                "a Blue Scarf",
                "Bright Powder",
                "a Bug Gem",
                "a Bug Memory",
                "a Burn Drive",
                "a Cell Battery",
                "Charcoal",
                "a Chill Drive",
                "a Choice Band",
                "a Choice Scarf",
                "Choice Specs",
                "a Cleanse Tag",
                "a Damp Rock",
                "a Dark Gem",
                "a Dark Memory",
                "a Deep Sea Scale",
                "a Deep Sea Tooth",
                "a Destinty Knot",
                "a Douse Drive",
                "a Draco Plate",
                "a Dragon Fang",
                "a Dragon Gem",
                "a Dragon Memory",
                "a Dread Plate",
                "a Dubious Disc",
                "a Ground Gem",
                "an Earth Plate",
                "an Eject Button",
                "an Electrizer",
                "an Electric Gem",
                "an Electric Memory",
                "an Everstone",
                "an Eviolite",
                "an Exp. Share",
                "an Expert Belt",
                "a Fairy Memory",
                "a Fighting Gem",
                "a Fighting Memory",
                "a Fire Gem",
                "a Fire Memory",
                "a Fist Plate",
                "a Flame Orb",
                "a Flame Plate",
                "a Flying Gem",
                "a Flying Memory",
                "a Float Stone",
                "a Focus Band",
                "a Focus Sash",
                "a Full Incense",
                "a Ghost Gem",
                "a Ghost Memory",
                "a Grass Gem",
                "a Grass Memory",
                "a Grassy Seed",
                "a Green Scarf",
                "a Grip Claw",
                "a Griseous Orb",
                "a Ground Gem",
                "a Ground Memory",
                "a Hard Stone",
                "a Heat Rock",
                "an Ice Gem",
                "an Ice Memory",
                "an Icicle Plate",
                "an Icy Rock",
                "an Insect Plate",
                "an Iron Ball",
                "an Iron Plate",
                "a King's Rock",
                "a Lagging Tail",
                "a Lax Incense",
                "Leftovers",
                "a Life Orb",
                "a Light Ball",
                "Light Clay",
                "a Luck Incense",
                "a Lucky Egg",
                "a Lucky Punch",
                "Luminous Moss",
                "a Lustrous Orb",
                "a Macho Brace",
                "a Magmarizer",
                "a Magnet",
                "a Meadow Plate",
                "a Mental Herb",
                "a Metal Coat",
                "Metal Powder",
                "a Metronome",
                "a Mind Plate",
                "a Miracle Seed",
                "a Misty Seed",
                "a Muscle Band",
                "Mystic Water",
                "a Never-melt Ice",
                "a Normal Gem",
                "an Odd Incense",
                "a Pink Bow",
                "a Pink Scarf",
                "a Pixie Plate",
                "a Poison Barb",
                "a Poison Gem",
                "a Poison Memory",
                "a Polkadot Bow",
                "a Power Anklet",
                "a Power Band",
                "a Power Belt",
                "a Power Bracer",
                "a Power Herb",
                "a Power Lens",
                "a Power Weight",
                "a Protector",
                "Protective Pads",
                "a Psychic Gem",
                "a Psychic Memory",
                "a Psychic Seed",
                "a Pure Incense",
                "a Quick Claw",
                "Quick Powder",
                "a Razor Claw",
                "a Razor Fang",
                "a Reaper Cloth",
                "a Red Card",
                "a Red Scarf",
                "a Ring Target",
                "a Rock Incense",
                "a Rock Gem",
                "a Rock Memory",
                "a Rocky Helmet",
                "a Rose Incense",
                "Safety Goggles",
                "a Scope Lens",
                "a Sea Incense",
                "a Sharp Beak",
                "a Shed Shell",
                "a Shell Bell",
                "a Shock Drive",
                "a Silk Scarf",
                "Silver Powder",
                "a Sky Plate",
                "a Smoke Ball",
                "a Smooth Rock",
                "a Snowball",
                "Soft Sand",
                "a Soothe Bell",
                "a Soul Dew",
                "a Spell Tag",
                "a Splash Plate",
                "a Spooky Plate",
                "a Steel Gem",
                "a Steel Memory",
                "a Stick",
                "a Sticky Barb",
                "a Stone Plate",
                "a Terrain Extender",
                "a Thick Club",
                "a Toxic Orb",
                "a Toxic Plate",
                "a Twisted Spoon",
                "a Water Gem",
                "a Water Memory",
                "a Wave Incense",
                "a Weakness Policy",
                "a White Herb",
                "a Wide Lens",
                "Wise Glasses",
                "a Yellow Scarf",
                "a Zap Plate",
                "a Zoom Lens",
                "Aloraichium Z",
                "Buginium Z",
                "Darkinium Z",
                "Decidium Z",
                "Dragonium Z",
                "Eevium Z",
                "Electrium Z",
                "Fairium Z",
                "Fightinium Z",
                "Firium Z",
                "Flyinium Z",
                "Ghostium Z",
                "Grassium Z",
                "Groundium Z",
                "Icium Z",
                "Incinium Z",
                "Marshadium Z",
                "Mewnium Z",
                "Normalium Z",
                "Pikanium Z",
                "Pikashunium Z",
                "Poisonium Z",
                "Primarium Z",
                "Psychium Z",
                "Rockium Z",
                "Snorlium Z",
                "Steelium Z",
                "Tapunium Z",
                "Waterium Z",
                #endregion
                #region Evolutionary Items
                "a Dawn Stone",
                "a Dragon Scale",
                "a Dusk Stone",
                "a Fire Stone",
                "an Ice Stone",
                "a Leaf Stone",
                "a Metal Coat",
                "a Moon Stone",
                "an Oval Stone",
                "a Prism Scale",
                "a Sachet",
                "a Shiny Stone",
                "a Sun Stone",
                "a Thunderstone",
                "an Up-Grade",
                "a Water Stone",
                "a Whipped Dream",
                "an Abomasite",
                "an Absolite",
                "an Aerodactylite",
                "an Aggronite",
                "an Alakazite",
                "an Altarianite",
                "an Ampharosite",
                "an Audinite",
                "a Banettite",
                "a Beedrillite",
                "a Blastoisinite",
                "a Blazikenite",
                "a Blue Orb",
                "a Cameruptite",
                "a Charizardite X",
                "a Charizardite Y",
                "a Diancite",
                "a Galladite",
                "a Garchompite",
                "a Gardevoirite",
                "a Gengarite",
                "a Glalitite",
                "a Gyaradosite",
                "a Heracronite",
                "a Houndoominite",
                "a Kangaskhanite",
                "a Lopunnite",
                "a Lucarionite",
                "a Manectite",
                "a Mawilite",
                "a Medichamite",
                "a Metagrossite",
                "a Mewtwonite X",
                "a Mewtwonite Y",
                "a Pidgeotite",
                "a Pinsirite",
                "a Red Orb",
                "a Sablenite",
                "a Salamencite",
                "a Sceptilite",
                "a Scizorite",
                "a Sharpedonite",
                "a Slowbronite",
                "a Steelixite",
                "a Swampertite",
                "a Tyranitarite",
                "a Venusaurite",
                #endregion
                #region Key Items
                "an Acro Bike",
                "Adventure Rules",
                "an Apricorn Box",
                "an Aqua Suit",
                "an Aurora Ticket",
                "an Azure Flute",
                "a Basement Key",
                "Berry Pots",
                "a Berry Pouch",
                "a Bicycle",
                "a Bike Voucher",
                "a Blue Card",
                "a Card Key",
                "a Clear Bell",
                "a Coin Case",
                "a Colress MCHN",
                "a Contest Costume",
                "a Contest Pass",
                "a Coupon 1",
                "a Coupon 2",
                "a Coupon 3",
                "A Dark Stone",
                "Devon Goods",
                "Devon Parts",
                "Devon Scuba Gear",
                "a Devon Scope",
                "DNA Splicers",
                "a Dowsing Machine",
                "a Dowsing MCHN",
                "a Dragon Skull",
                "an Egg Card",
                "an Elevator Key",
                "an Enigma Stone",
                "an Enigmatic Card",
                "an Eon Flute",
                "an Eon Ticket",
                "an Explorer Kit",
                "a Fame Checker",
                "a Fashion Case",
                "a Festival Ticket",
                "a Fishing Rod",
                "a Forage Bag",
                "a Forgotten Item",
                "a Galactic Key",
                "GB Sounds",
                "a God Stone",
                "Go-Goggles",
                "a Gold Teeth",
                "a Good Rod",
                "a Gracidea",
                "a Gram 1",
                "a Gram 2",
                "a Gram 3",
                "a Grubby Hanky",
                "a GS Ball",
                "a Holo Caster",
                "an Honor of Kalos",
                "an Itemfinder",
                "an Intriguing Stone",
                "a Jade Orb",
                "a Journal",
                "a Key to Room 1",
                "a Key to Room 2",
                "a Key to Room 4",
                "a Key to Room 6",
                "a Lens Case",
                "a Letter",
                "a Liberty Pass",
                "a Lift Key",
                "a Light Stone",
                "a Lock Capsule",
                "a Looker Ticket",
                "a Loot Sack",
                "a Lost Item",
                "a Lunar Wing",
                "a Mach Bike",
                "a Machine Part",
                "a Magma Emblem",
                "a Magma Stone",
                "a Medal Box",
                "a Mega Bracelet",
                "a Mega Ring",
                "a Member Card",
                "a Meteorite",
                "a Meteorite Shard",
                "a Moon Flute",
                "a Mystery Egg",
                "a Mystic Ticket",
                "Oak's Letter",
                "Oak's Parcel",
                "an Old Charm",
                "an Old Rod",
                "an Old Sea Map",
                "an Oval Charm",
                "a Pair of Tickets",
                "a Pal Pad",
                "a Parcel",
                "a Pass",
                "a Permit",
                "a Photo Album",
                "a Plasma Card",
                "a Poffin Case",
                "a Point Card",
                "a Poké Radar",
                "a PokéBlock Case",
                "a PokéBlock Kit",
                "a Pokéflute",
                "a Powder Jar",
                "a Power Plant Pass",
                "a Prison Bottle",
                "Prof's Letter",
                "Professor's Mask",
                "a Prop Case",
                "a Rainbow Pass",
                "a Rainbow Wing",
                "a Red Chain",
                "a Red Scale",
                "a Reveal Glass",
                "a Ride Pager",
                "a Rm. 1 Key",
                "a Rm. 2 Key",
                "a Rm. 4 Key",
                "a Rm. 6 Key",
                "Roller Skates",
                "a Ruby",
                "a Rule Book",
                "an S.S. Ticket",
                "a Sapphire",
                "a Scanner",
                "a Seal Bag",
                "a Seal Case",
                "a Secret Key",
                "a Secret Potion",
                "a Shiny Charm",
                "a Silph Scope",
                "a Silver Wing",
                "a Slowpoketail",
                "a Soot Bag",
                "a Sparkling Stone",
                "a Sprayduck",
                "a Sprinklotad",
                "a Squirtbottle",
                "a Storage Key",
                "a Suite Key",
                "a Sun Flute",
                "a Super Rod",
                "Tea",
                "a Teacy TV",
                "a Tidal Bell",
                "a TM Case",
                "a TMV Pass",
                "an Unown Report",
                "a Vs. Recorder",
                "a Vs. Seeker",
                "a Wailmer Pail",
                "a Works Key",
                "an Xtransceiver",
                "a Z-ring",
                "a Zygarde Cube",

                #endregion
                #region Fossils and Others
                "an Armor Fossil",
                "a Claw Fossil",
                "a Cover Fossil",
                "a Dome Fossil",
                "a Helix Fossil",
                "an Old Amber",
                "a Plume Fossil",
                "a Root Fossil",
                "a Skull Fossil",
                "a Big Mushroom",
                "a Big Nugget",
                "a Big Pearl",
                "a Black Flute",
                "a Blk Apricron",
                "a Blu Apricorn",
                "a Blue Flute",
                "a Blue Shard",
                "a Bottle Cap",
                "a Brick Piece",
                "a Comet Shard",
                "Damp Mulch",
                "Data Card 1",
                "Data Card 10",
                "Data Card 11",
                "Data Card 12",
                "Data Card 13",
                "Data Card 14",
                "Data Card 15",
                "Data Card 16",
                "Data Card 17",
                "Data Card 18",
                "Data Card 19",
                "Data Card 2",
                "Data Card 20",
                "Data Card 21",
                "Data Card 22",
                "Data Card 23",
                "Data Card 24",
                "Data Card 25",
                "Data Card 26",
                "Data Card 27",
                "Data Card 3",
                "Data Card 4",
                "Data Card 5",
                "Data Card 6",
                "Data Card 7",
                "Data Card 8",
                "Data Card 9",
                "a Discount Coupon",
                "an Escape Rope",
                "an EXP. All",
                "a Fluffy Tail",
                "a Balm Mushroom",
                "a Gold Bottle Cap",
                "a Gold Leaf",
                "Gooey Mulch",
                "a Gorgeous Box",
                "a Green Shard",
                "a Grn Apricorn",
                "Growth Mulch",
                "a Heart Scale",
                "Honey",
                "a Max Repel",
                "a Normal Box",
                "a Nugget",
                "an Odd Keystone",
                "a Pass Orb",
                "a Pearl",
                "a Pearl String",
                "Pink Nectar",
                "a Pnk Apricorn",
                "a Poké Doll",
                "a Poké Toy",
                "a Pretty Wing",
                "Purple Nectar",
                "a Rare Bone",
                "a Red Apricorn",
                "a Red Flute",
                "Red Nectar",
                "a Red Shard",
                "a Relic Band",
                "Relic Copper",
                "a Relic Crown",
                "Relic Gold",
                "Relic Silver",
                "a Relic Statue",
                "a Relic Vase",
                "a Repel",
                "Shoal Salt",
                "a Shoal Shell",
                "a Silver Leaf",
                "Stable Mulch",
                "a Star Piece",
                "Stardust",
                "a Super Repel",
                "a Tiny Mushroom",
                "a White Flute",
                "a Wht Apricorn",
                "a Yellow Flute",
                "Yellow Nectar",
                "a Yellow Shard",
                "a Ylw Apricorn",

                #endregion
                #region Stat Items
                "a Dire Hit",
                "a Guard Spec.",
                "an X Accuracy",
                "an X Attack",
                "an X Defend",
                "an X Sp. Def",
                "an X Special",
                "an X Speed",
                "Calcium",
                "Carbos",
                "a Clever Wing",
                "a Health Wing",
                "an HP Up",
                "a Genius Wing",
                "Iron",
                "a Muscle Wing",
                "a PP Max",
                "a PP Up",
                "Protein",
                "a Rare Candy",
                "a Resist Wing",
                "a Swift Wing",
                "Zinc",
                #endregion
                #region Mail
                "Air Mail",
                "Bead Mail",
                "Bloom Mail",
                "BlueSky Mail",
                "Brick Mail",
                "BridgeMail D",
                "BridgeMail M",
                "BridgeMail S",
                "BridgeMail T",
                "Brigdemail V",
                "Bubble Mail",
                "Eon Mail",
                "Fab Mail",
                "Favor Mail",
                "Flame Mail",
                "Flower Mail",
                "Glitter Mail",
                "Grass Mail",
                "Greet Mail",
                "Harbor Mail",
                "Heart Mail",
                "Inquiry Mail",
                "Like Mail",
                "LiteBlue Mail",
                "Lovely Mail",
                "Mech Mail",
                "Mirage Mail",
                "Morph Mail",
                "Mosaic Mail",
                "Music Mail",
                "Portrait Mail",
                "Retro Mail",
                "Return Mail",
                "RSVP Mail",
                "Shadow Mail",
                "Snow Mail",
                "Space Mail",
                "Steel Mail",
                "Surf Mail",
                "Thanks Mail",
                "Tropic Mail",
                "Tunnel Mail",
                "Wave Mail",
                "Wood Mail",
                #endregion
                #region Berries
                "a Cheri Berry",
                "a Chesto Berry",
                "a Pecha Berry",
                "a Rawst Berry",
                "an Aspear Berry",
                "a Leppa Berry",
                "an Oran Berry",
                "a Persim Berry",
                "a Lum Berry",
                "a Sitrus Berry",
                "a Figy Berry",
                "a Wiki Berry",
                "a Mago Berry",
                "an Aguav Berry",
                "an Iappa Berry",
                "a Razz Berry",
                "a Bluk Berry",
                "a Nanab Berry",
                "a Wepear Berry",
                "a Pinap Berry",
                "a Pomeg Berry",
                "a Kelpsy Berry",
                "a Qualot Berry",
                "a Hondew Berry",
                "a Grepa Berry",
                "a Tamato Berry",
                "a Cornn Berry",
                "a Magost Berry",
                "a Rabuta Berry",
                "a Nomel Berry",
                "a Spelon Berry",
                "a Pamtre Berry",
                "a Watmel Berry",
                "a Durin Berry",
                "a Belue Berry",
                "an Occa Berry",
                "a Passho Berry",
                "a Wacan Berry",
                "a Rindo Berry",
                "a Yache Berry",
                "a Chople Berry",
                "a Kebia Berry",
                "a Shuca Berry",
                "a Coba Berry",
                "a Payapa Berry",
                "a Tanga Berry",
                "a Charti Berry",
                "a Kasib Berry",
                "a Haban Berry",
                "a Colbur Berry",
                "a Babiri Berry",
                "a Chilan Berry",
                "a Liechi Berry",
                "a Ganlon Berry",
                "a Salac Berry",
                "a Petaya Berry",
                "a Apicot Berry",
                "a Lansat Berry",
                "a Starf Berry",
                "an Enigma Berry",
                "a Micle Berry",
                "a Custap Berry",
                "a Jaboca Berry",
                "a Rowap Berry",
                "a Roseli Berry",
                "a Berry",
                "a Bitter Berry",
                "a Burnt Berry",
                "a Gold Berry",
                "an Ice Berry",
                "a Mint Berry",
                "a Miracle Berry",
                "a Mystery Berry",
                "a PrzCure Berry",
                "a PsnCure Berry",
                #endregion
                #region Decorations
                "an Azurill Doll",
                "a Baltoy Doll",
                "a Big Lapras",
                "a Big Onix",
                "a Big Snorlax",
                "a Blastoise Doll",
                "a Bonsly Doll",
                "a Buizel Doll",
                "a Bulbasaur Doll",
                "a Buneary Doll",
                "a Charizard Doll",
                "a Charmander Doll",
                "a Chatot Doll",
                "a Chikorita Doll",
                "a Chimchar Doll",
                "a Clefairy Doll",
                "a Cyndaquil Doll",
                "a Diglett Doll",
                "a Ditto Doll",
                "a Drifloon Doll",
                "a Duskull Doll",
                "a Gengar Doll",
                "a Geodude Doll",
                "a Glameow Doll",
                "a Grimer Doll",
                "a Gulpin Doll",
                "a Happiny Doll",
                "a Jigglypuff Doll",
                "a Kecleon Doll",
                "a Lapras Doll",
                "a Lotad Doll",
                "a Lucario Doll",
                "a Machop Doll",
                "a Magikarp Doll",
                "a Magnezone Doll",
                "a Manaphy Doll",
                "a Mantyke Doll",
                "a Marill Doll",
                "a Meowth Doll",
                "a Mime Jr. Doll",
                "a Minun Doll",
                "a Mudkip Doll",
                "a Munchlax Doll",
                "an Oddish Doll",
                "a Pachirisu Doll",
                "a Pichu Doll",
                "a Pikachu Doll",
                "a Piplup Doll",
                "a Plusle Doll",
                "a Poliwag Doll",
                "a Regice Doll",
                "a Regirock Doll",
                "a Registeel Doll",
                "a Rhydon Doll",
                "a Seedot Doll",
                "a Shellder Doll",
                "a Skitty Doll",
                "a Smoochum Doll",
                "a Snorlax Doll",
                "a Squirtle Doll",
                "a Staryu Doll",
                "a Surf Pikachu Doll",
                "a Swablu Doll",
                "a Tentacruel Doll",
                "a Togepi Doll",
                "a Torchic Doll",
                "a Totodile Doll",
                "a Treecko Doll",
                "a Turtwig Doll",
                "an Unown Doll",
                "a Venusaur Doll",
                "a Voltorb Doll",
                "a Wailmer Doll",
                "a Wailord Doll",
                "a Weavile Doll",
                "a Weedle Doll",
                "a Wobbuffet Doll",
                "a Wynaut Doll",
                "a Ball Cushion",
                "a Blue Cushion",
                "a Diamond Cusion",
                "a Fire Cushion",
                "a Grass Cushion",
                "a Kiss Cushion",
                "a Pika Cushion",
                "a Round Cushion",
                "a Spin Cushion",
                "a Water Cushion",
                "a Yellow Cushion",
                "a ZigZag Cusion",
                "a Big Bookshelf",
                "a Big Table",
                "a Brick Chair",
                "a Brick Desk",
                "a Champ Chair",
                "a Champ Desk",
                "a Comfort Chair",
                "a Comfort Desk",
                "a Cupboard",
                "a Display Shelf",
                "a Feathery Bed",
                "a Hard Chair",
                "a Hard Desk",
                "a Heavy Chair",
                "a Heavy Desk",
                "a Long Table",
                "a Pika Bed",
                "a Pink Bed",
                "a Pink Dresser",
                "a Plain Table",
                "a Poké Table",
                "a Pokémon Chair",
                "a Pokémon Desk",
                "a Polkadot Bed",
                "a Pretty Chair",
                "a Pretty Desk",
                "a Pretty Sink",
                "a Ragged Chair",
                "a Ragged Desk",
                "a Refrigerator",
                "a Research Shelf",
                "a Shop Shelf",
                "a Small Bookshelf",
                "a Small Chair",
                "a Small Table",
                "a Wide Sofa",
                "a Wide Table",
                "a Wood Dresser",
                "a Wooden Chair",
                "an A Note Mat",
                "an Attract Mat",
                "a B Note Mat",
                "a Blue Carpet",
                "a C High Note Mat",
                "a C Low Note Mat",
                "a D Note Mat",
                "an E Note Mat",
                "an F Note Mat",
                "a Fire Blast Mat",
                "a Fissure Mat",
                "a G Note Mat",
                "a Glitter Mat",
                "a Green Carpet",
                "a Jump Mat",
                "a Powder Snow Mat",
                "a Red Carpet",
                "a Spikes Mat",
                "a Spin Mat",
                "a Surf Mat",
                "a Thunder Mat",
                "a Yellow Carpet",
                "a Big Plant",
                "a Bonsai",
                "a Colorful Plant",
                "Dainty Flowers",
                "a Gorgeous Plant",
                "a Jumbo Plant",
                "Lavish Flowers",
                "Lovely Flowers",
                "a Magma Plant",
                "Poké Flowers",
                "a Potted Plant",
                "Pretty flowers",
                "a Red Plant",
                "a Tropic Plant",
                "a Tropical Plant",
                "a Ball Poster",
                "a Blue Poster",
                "a Clefairy Poster",
                "a Cute Poster",
                "a Green Poster",
                "a Jigglypuff Poster",
                "a Kiss Poster",
                "a Long Poster",
                "a Town Map",
                "a Pika Poster",
                "a Pikachu Poster",
                "a Red Poster",
                "a Sea Poster",
                "a Sky Poster",
                "Alert Tool 1",
                "Alert Tool 2",
                "Alert Tool 3",
                "Alert Tool 4",
                "a Big Smoke Tool",
                "a Bubble Tool",
                "an Ember Tool",
                "a Fire Tool",
                "a Flower Tool",
                "a Foam Tool",
                "a Hole Tool",
                "a Leaf Tool",
                "a Pit Tool",
                "a Rock Tool",
                "a Rockfall Tool",
                "a Smoke Tool",
                "a Beauty Cup",
                "a Bronze Trophy",
                "a Clever Cup",
                "a Cool Cup",
                "a Glass Ornament",
                "a Gold Shield",
                "a Gold Trophy",
                "a Great Trophy",
                "a Silver Shield",
                "a Silver Trophy",
                "a Tough Cup",
                "a Ball Ornament",
                "a Big Oil Drum",
                "a Bike Rack",
                "Binoculars",
                "a Blue Balloon",
                "a Blue Brick",
                "a Blue Crystal",
                "a Blue Tent",
                "a Breakable Door",
                "a Cardboard Box",
                "a Clear Ornament",
                "a Clear Tent",
                "a Container",
                "a Crate",
                "a Cute TV",
                "a Fence Length",
                "a Fence Width",
                "a Game System",
                "a Glitter Gem",
                "a Globe",
                "a Green Bike",
                "a Gym Statue",
                "a Healing Machine",
                "an Iron Bem",
                "a Lab Machine",
                "Maze Block 1",
                "Maze Block 2",
                "Maze Block 3",
                "Maze Block 4",
                "Maze Block 5",
                "a Mud Ball",
                "a Mystic Gem",
                "an NES",
                "a Nintendo 64",
                "an Oil Drum",
                "a Pink Drum",
                "a Pretty Gem",
                "a Red Balloon",
                "a Red Bike",
                "a Red Brick",
                "a Red Crystal",
                "a Red Tent",
                "a Round Ornament",
                "a Round TV",
                "a Sand Ornament",
                "a Shiny Gem",
                "a Slide",
                "a Solid Board",
                "a Stand",
                "a Super NES",
                "a Test Machine",
                "a Tire",
                "a Trash Can",
                "a TV",
                "a Vending Machine",
                "a Virtual Boy",
                "a Yellow Balloon",
                "a Yellow Brick",
                "a Yellow Crystal"
                #endregion
            };
            #endregion
        
            #region Random Arrays
            randompoke = new string[]
            {
                #region Kanto
                "Bulbasaur",
                "Ivysaur",
                "Venusaur",
                "Charmander",
                "Charmeleon",
                "Charizard",
                "Squirtle",
                "Wartortle",
                "Blastoise",
                "Caterpie",
                "Metapod",
                "Butterfree",
                "Weedle",
                "Kakuna",
                "Beedrill",
                "Pidgey",
                "Pidgeotto",
                "Pidgeot",
                "Rattata",
                "Raticate",
                "Spearow",
                "Fearow",
                "Ekans",
                "Arbok",
                "Pikachu",
                "Raichu",
                "Sandshrew",
                "Sandslash",
                "Nidoran (f)",
                "Nidorina",
                "Nidoqueen",
                "Nidoran (m)",
                "Nidorino",
                "Nidoking",
                "Clefairy",
                "Clefable",
                "Vulpix",
                "Ninetales",
                "Jigglypuff",
                "Wigglytuff",
                "Zubat",
                "Golbat",
                "Oddish",
                "Gloom",
                "Vileplume",
                "Paras",
                "Parasect",
                "Venonat",
                "Venomoth",
                "Diglett",
                "Dugtrio",
                "Meowth",
                "Persian",
                "Psyduck",
                "Golduck",
                "Mankey",
                "Primeape",
                "Growlithe",
                "Arcanine",
                "Poliwag",
                "Poliwhirl",
                "Poliwrath",
                "Abra",
                "Kadabra",
                "Alakazam",
                "Machop",
                "Machoke",
                "Machamp",
                "Bellsprout",
                "Weepinbell",
                "Victreebel",
                "Tentacool",
                "Tentacruel",
                "Geodude",
                "Graveler",
                "Golem",
                "Ponyta",
                "Rapidash",
                "Slowpoke",
                "Slowbro",
                "Magnemite",
                "Magneton",
                "Farfetch'd",
                "Doduo",
                "Dodrio",
                "Seel",
                "Dewgong",
                "Grimer",
                "Muk",
                "Shellder",
                "Cloyster",
                "Ghastly",
                "Haunter",
                "Gengar",
                "Onix",
                "Drowzee",
                "Hypno",
                "Krabby",
                "Kingler",
                "Voltorb",
                "Electrode",
                "Exeggcute",
                "Exeggutor",
                "Cubone",
                "Marowak",
                "Hitmonlee",
                "Hitmonchan",
                "Lickitung",
                "Koffing",
                "Weezing",
                "Rhyhorn",
                "Rhydon",
                "Chansey",
                "Tangela",
                "Kangaskhan",
                "Horsea",
                "Seadra",
                "Goldeen",
                "Seaking",
                "Staryu",
                "Starmie",
                "Mr. Mime",
                "Scyther",
                "Jynx",
                "Electabuzz",
                "Magmar",
                "Pinsir",
                "Tauros",
                "Magikarp",
                "Gyarados",
                "Lapras",
                "Ditto",
                "Eevee",
                "Vaporeon",
                "Jolteon",
                "Flareon",
                "Porygon",
                "Omanyte",
                "Omastar",
                "Kabuto",
                "Kabutops",
                "Aerodactyl",
                "Snorlax",
                "Articuno",
                "Zapdos",
                "Moltres",
                "Dratini",
                "Dragonair",
                "Dragonite",
                "Mewtwo",
                "Mew",
                #endregion
                #region Johto
                "Chikorita",
                "Bayleef",
                "Meganium",
                "Cyndaquil",
                "Quilava",
                "Typhlosion",
                "Totodile",
                "Croconaw",
                "Feraligatr",
                "Sentret",
                "Furret",
                "Hoothoot",
                "Noctowl",
                "Ledyba",
                "Ledian",
                "Spinarak",
                "Ariados",
                "Crobat",
                "Chinchou",
                "Lanturn",
                "Pichu",
                "Cleffa",
                "Igglybuff",
                "Togepi",
                "Togetic",
                "Natu",
                "Xatu",
                "Mareep",
                "Flaaffy",
                "Ampharos",
                "Bellossom",
                "Marill",
                "Azumarill",
                "Sudowoodo",
                "Politoed",
                "Hoppip",
                "Skiploom",
                "Jumpluff",
                "Sunkern",
                "Sunflora",
                "Yanma",
                "Wooper",
                "Quagsire",
                "Espeon",
                "Umbreon",
                "Murkrow",
                "Slowking",
                "Misdreavus",
                "Unown",
                "Wobbuffet",
                "Girafarig",
                "Pineco",
                "Forretress",
                "Dunsparce",
                "Gligar",
                "Steelix",
                "Snubbull",
                "Granbull",
                "Qwilfish",
                "Scizor",
                "Shuckle",
                "Heracross",
                "Sneasel",
                "Teddiursa",
                "Ursaring",
                "Slugma",
                "Magcargo",
                "Swinub",
                "Piloswine",
                "Corsola",
                "Remoraid",
                "Octillery",
                "Delibird",
                "Mantine",
                "Skarmory",
                "Houndour",
                "Houndoom",
                "Kingdra",
                "Phanpy",
                "Donphan",
                "Porygon2",
                "Stantler",
                "Smeargle",
                "Tyrogue",
                "Hitmontop",
                "Smoochum",
                "Elekid",
                "Magby",
                "Miltank",
                "Blissey",
                "Raikou",
                "Entei",
                "Suicune",
                "Larvitar",
                "Pupitar",
                "Tyranitar",
                "Lugia",
                "Ho-Oh",
                "Celebi",
                #endregion
                #region Hoenn
                "Treecko",
                "Grovyle",
                "Sceptile",
                "Torchic",
                "Combusken",
                "Blaziken",
                "Mudkip",
                "Marshtomp",
                "Swampert",
                "Poochyena",
                "Mightyena",
                "Zigzagoon",
                "Linoone",
                "Wurmple",
                "Silcoon",
                "Beautifly",
                "Cascoon",
                "Dustox",
                "Lotad",
                "Lombre",
                "Ludicolo",
                "Seedot",
                "Nuzleaf",
                "Shiftry",
                "Tailow",
                "Swellow",
                "Wingull",
                "Pelipper",
                "Ralts",
                "Kirlia",
                "Gardevoir",
                "Surskit",
                "Masquerain",
                "Shroomish",
                "Breloom",
                "Slakoth",
                "Vigoroth",
                "Slaking",
                "Nincada",
                "Ninjask",
                "Shedinja",
                "Whismur",
                "Loudred",
                "Exploud",
                "Makuhita",
                "Hariyama",
                "Azurill",
                "Nosepass",
                "Skitty",
                "Delcatty",
                "Sableye",
                "Mawile",
                "Aron",
                "Lairon",
                "Aggron",
                "Meditite",
                "Medicham",
                "Electrike",
                "Manectric",
                "Plusle",
                "Minun",
                "Volbeat",
                "Illumise",
                "Roselia",
                "Gulpin",
                "Swalot",
                "Carvanha",
                "Sharpedo",
                "Wailmer",
                "Wailord",
                "Numel",
                "Camerupt",
                "Torkoal",
                "Spoink",
                "Grumpig",
                "Spinda",
                "Trapinch",
                "Vibrava",
                "Flygon",
                "Cacnea",
                "Cacturne",
                "Swablu",
                "Altaria",
                "Zangoose",
                "Seviper",
                "Lunatone",
                "Solrock",
                "Barboach",
                "Whiscash",
                "Corphish",
                "Crawdaunt",
                "Baltoy",
                "Claydol",
                "Lileep",
                "Cradily",
                "Anorith",
                "Armaldo",
                "Feebas",
                "Milotic",
                "Castform",
                "Kecleon",
                "Shuppet",
                "Banette",
                "Duskull",
                "Dusclops",
                "Tropius",
                "Chimecho",
                "Absol",
                "Wynaut",
                "Snorunt",
                "Glalie",
                "Spheal",
                "Sealeo",
                "Walrein",
                "Clamperl",
                "Huntail",
                "Gorebyss",
                "Relicanth",
                "Luvdisc",
                "Bagon",
                "Shelgon",
                "Salamence",
                "Beldum",
                "Metang",
                "Metagross",
                "Regirock",
                "Regice",
                "Registeel",
                "Latias",
                "Latios",
                "Kyogre",
                "Groudon",
                "Rayquaza",
                "Jirachi",
                "Deoxys",
                #endregion
                #region Sinnoh
                "Turtwig",
                "Grotle",
                "Torterra",
                "Chimchar",
                "Monferno",
                "Infernape",
                "Piplup",
                "Prinplup",
                "Empoleon",
                "Starly",
                "Staravia",
                "Staraptor",
                "Bidoof",
                "Bibarel",
                "Kricketot",
                "Kricketune",
                "Shinx",
                "Luxio",
                "Luxray",
                "Budew",
                "Roserade",
                "Cranidos",
                "Rampardos",
                "Shieldon",
                "Bastiodon",
                "Burmy",
                "Wormadam",
                "Mothim",
                "Combee",
                "Vespiqueen",
                "Pachirisu",
                "Buizel",
                "Floatzel",
                "Cherubi",
                "Cherrim",
                "Shellos",
                "Gastrodon",
                "Ambipom",
                "Drifloon",
                "Drifblim",
                "Buneary",
                "Lopunny",
                "Mismagius",
                "Honchkrow",
                "Glameow",
                "Purugly",
                "Chingling",
                "Stunky",
                "Skuntank",
                "Bronzor",
                "Bronzong",
                "Bonsly",
                "Mime Jr.",
                "Happiny",
                "Chatot",
                "Spiritomb",
                "Gible",
                "Gabite",
                "Garchomp",
                "Munchlax",
                "Riolu",
                "Lucario",
                "Hippopotas",
                "Hippowdon",
                "Skorupi",
                "Drapion",
                "Croagunk",
                "Toxicroak",
                "Carvine",
                "Finneon",
                "Lumineon",
                "Mantyke",
                "Snover",
                "Amomasnow",
                "Weavile",
                "Magnezone",
                "Lickilicky",
                "Rhyperior",
                "Tangrowth",
                "Electivire",
                "Magmortar",
                "Togekiss",
                "Yanmega",
                "Leafeon",
                "Glaceon",
                "Gliscor",
                "Mamoswine",
                "Porygon-Z",
                "Gallade",
                "Probopass",
                "Dusknoir",
                "Froslass",
                "Rotom",
                "Uxie",
                "Mesprit",
                "Azelf",
                "Dialga",
                "Palkia",
                "Heatran",
                "Regigigas",
                "Giratina",
                "Cresselia",
                "Phione",
                "Manaphy",
                "Darkrai",
                "Shaymin",
                "Arceus",
                #endregion
                #region Unova
                "Victini",
                "Snivy",
                "Servine",
                "Serperior",
                "Tepig",
                "Pignite",
                "Emboar",
                "Oshawott",
                "Dewott",
                "Samurott",
                "Patrat",
                "Watchog",
                "Lillipup",
                "Herdier",
                "Stoutland",
                "Purrloin",
                "Liepard",
                "Pansage",
                "Simisage",
                "Pansear",
                "Simisear",
                "Panpour",
                "Simipour",
                "Munna",
                "Musharna",
                "Pidove",
                "Tranquill",
                "Unfezant",
                "Blitzle",
                "Zebstrika",
                "Roggenrola",
                "Boldore",
                "Gigalith",
                "Woobat",
                "Swoobat",
                "Drilbur",
                "Excadrill",
                "Audino",
                "Timburr",
                "Gurdurr",
                "Conkeldurr",
                "Tympole",
                "Palpitoad",
                "Seismitoad",
                "Throh",
                "Sawk",
                "Sewaddle",
                "Swadloon",
                "Leavanny",
                "Venipede",
                "Whirlipede",
                "Scolipede",
                "Cottonee",
                "Whimiscott",
                "Petilil",
                "Lilligant",
                "Basculin",
                "Sandile",
                "Krokorok",
                "Krookodile",
                "Darumaka",
                "Darmanitan",
                "Maractus",
                "Dwebble",
                "Crustle",
                "Scraggy",
                "Scrafty",
                "Sigilyph",
                "Yamask",
                "Confagrigus",
                "Tirtouga",
                "Carracosta",
                "Archen",
                "Archeops",
                "Trubbish",
                "Garbodor",
                "Zorua",
                "Zoroark",
                "Minccino",
                "Cinccino",
                "Gothita",
                "Gothorita",
                "Gothitelle",
                "Solosis",
                "Duosion",
                "Reuniclus",
                "Ducklett",
                "Swanna",
                "Vanillite",
                "Vanillish",
                "Vanilluxe",
                "Deerling",
                "Sawsbuck",
                "Emolga",
                "Karrablast",
                "Escavalier",
                "Foongus",
                "Amoonguss",
                "Frillish",
                "Jellicent",
                "Joltik",
                "Galvantula",
                "Ferroseed",
                "Ferrothorn",
                "Klink",
                "Klank",
                "Klinklang",
                "Tynamo",
                "Eelektrik",
                "Eelektross",
                "Elgyem",
                "Beheeyem",
                "Litwick",
                "Lampent",
                "Chandelure",
                "Axew",
                "Fraxure",
                "Haxorus",
                "Cubchoo",
                "Beartic",
                "Cryogonal",
                "Shelmet",
                "Accelgor",
                "Stunfisk",
                "Mienfoo",
                "Mienshao",
                "Druddigon",
                "Golett",
                "Golurk",
                "Pawniard",
                "Bisharp",
                "Bouffalant",
                "Rufflet",
                "Braviary",
                "Vullaby",
                "Mandibuzz",
                "Heatmor",
                "Durant",
                "Deino",
                "Zweilous",
                "Hydreigon",
                "Larvesta",
                "Volcarona",
                "Cobalion",
                "Terrakion",
                "Virizion",
                "Tornadus",
                "Thundurus",
                "Reshiram",
                "Zekrom",
                "Landorus",
                "Kyurem",
                "Keldeo",
                "Meloetta",
                "Genesect",
                #endregion
                #region Kalos
                "Chespin",
                "Quilladin",
                "Chesnaught",
                "Fennekin",
                "Braixen",
                "Delphox",
                "Froakie",
                "Frogadier",
                "Greninja",
                "Bunnelby",
                "Diggersby",
                "Fletchling",
                "Fletchinder",
                "Talonflame",
                "Scatterbug",
                "Spewpa",
                "Vivillon",
                "Litleo",
                "Pyroar",
                "Flabébé",
                "Floette",
                "Florges",
                "Skiddo",
                "Gogoat",
                "Pancham",
                "Pangoro",
                "Furfrou",
                "Espurr",
                "Meowstic",
                "Honedge",
                "Doublade",
                "Aegislash",
                "Spritzee",
                "Aromatisse",
                "Swirlix",
                "Slurpuff",
                "Inkay",
                "Malamar",
                "Binacle",
                "Barbaracle",
                "Skrelp",
                "Dragalge",
                "Clauncher",
                "Clawitzer",
                "Helioptile",
                "Heliolisk",
                "Tyrunt",
                "Tyrantrum",
                "Amaura",
                "Aurorus",
                "Sylveon",
                "Hawlucha",
                "Dedenne",
                "Carbink",
                "Goomy",
                "Sliggoo",
                "Goodra",
                "Klefki",
                "Phantump",
                "Trevenant",
                "Pumpkaboo",
                "Gourgeist",
                "Bergmite",
                "Avalugg",
                "Noibat",
                "Noivern",
                "Xerneas",
                "Yveltal",
                "Zygarde",
                "Diancie",
                "Hoopa",
                "Volcanion",
                #endregion
                #region Alola
                "Rowlet",
                "Dartrix",
                "Decidueye",
                "Litten",
                "Torracat",
                "Incineroar",
                "Popplio",
                "Brionne",
                "Primarina",
                "Pikipek",
                "Trumbeak",
                "Toucannon",
                "Yungoos",
                "Gumshoos",
                "Grubbin",
                "Charjabug",
                "Vikavolt",
                "Crabrawler",
                "Crabominable",
                "Oricorio",
                "Cutiefly",
                "Ribombee",
                "Rockruff",
                "Lycanroc",
                "Wishiwashi",
                "Mareanie",
                "Toxapex",
                "Mudbray",
                "Mudsdale",
                "Dewpider",
                "Araquanid",
                "Fomantis",
                "Lurantis",
                "Morelull",
                "Shiitonic",
                "Salandit",
                "Salazzle",
                "Stufful",
                "Bewear",
                "Bounsweet",
                "Steenee",
                "Tsareena",
                "Comfey",
                "Oranguru",
                "Passimian",
                "Wimpod",
                "Golisopod",
                "Sandygast",
                "Palossand",
                "Pyukumuku",
                "Type: Null",
                "Silvally",
                "Minior",
                "Komala",
                "Turtonator",
                "Togedemaru",
                "Mimikyu",
                "Bruxish",
                "Drampa",
                "Dhelmise",
                "Jangmo-o",
                "Hakamo-o",
                "Kommo-o",
                "Tapu Koko",
                "Tapu Lele",
                "Tapu Bulu",
                "Tapu Fini",
                "Cosmog",
                "Cosmoem",
                "Solgaleo",
                "Lunala",
                "Nihilego",
                "Buzzwole",
                "Pheromosa",
                "Xurkitree",
                "Celesteela",
                "Kartana",
                "Guzzlord",
                "Necrozma",
                "Magearna",
                "Marshadow"
                #endregion
            };

            #region Region
            randomregion = new string[]
            {
                "Kanto",
                "Johto",
                "Hoenn",
                "Sinnoh",
                "Unova",
                "Kalos",
                "Alola"
            };
            #endregion

            randomstart = new string[]
            {
                #region Starter
                "Bulbasaur",
                "Charmander",
                "Squirtle",
                "Chikorita",
                "Cyndaquil",
                "Totodile",
                "Treecko",
                "Torchic",
                "Mudkip",
                "Turtwig",
                "Chimchar",
                "Piplup",
                "Snivy",
                "Tepig",
                "Oshawott",
                "Chespin",
                "Fennekin",
                "Froakie",
                "Rowlet",
                "Litten",
                "Popplio"
                #endregion
            };
            randomKa = new string[]
            {
                #region Kanto
                "Bulbasaur",
                "Ivysaur",
                "Venusaur",
                "Charmander",
                "Charmeleon",
                "Charizard",
                "Squirtle",
                "Wartortle",
                "Blastoise",
                "Caterpie",
                "Metapod",
                "Butterfree",
                "Weedle",
                "Kakuna",
                "Beedrill",
                "Pidgey",
                "Pidgeotto",
                "Pidgeot",
                "Rattata",
                "Raticate",
                "Spearow",
                "Fearow",
                "Ekans",
                "Arbok",
                "Pikachu",
                "Raichu",
                "Sandshrew",
                "Sandslash",
                "Nidoran (f)",
                "Nidorina",
                "Nidoqueen",
                "Nidoran (m)",
                "Nidorino",
                "Nidoking",
                "Clefairy",
                "Clefable",
                "Vulpix",
                "Ninetales",
                "Jigglypuff",
                "Wigglytuff",
                "Zubat",
                "Golbat",
                "Oddish",
                "Gloom",
                "Vileplume",
                "Paras",
                "Parasect",
                "Venonat",
                "Venomoth",
                "Diglett",
                "Dugtrio",
                "Meowth",
                "Persian",
                "Psyduck",
                "Golduck",
                "Mankey",
                "Primeape",
                "Growlithe",
                "Arcanine",
                "Poliwag",
                "Poliwhirl",
                "Poliwrath",
                "Abra",
                "Kadabra",
                "Alakazam",
                "Machop",
                "Machoke",
                "Machamp",
                "Bellsprout",
                "Weepinbell",
                "Victreebel",
                "Tentacool",
                "Tentacruel",
                "Geodude",
                "Graveler",
                "Golem",
                "Ponyta",
                "Rapidash",
                "Slowpoke",
                "Slowbro",
                "Magnemite",
                "Magneton",
                "Farfetch'd",
                "Doduo",
                "Dodrio",
                "Seel",
                "Dewgong",
                "Grimer",
                "Muk",
                "Shellder",
                "Cloyster",
                "Ghastly",
                "Haunter",
                "Gengar",
                "Onix",
                "Drowzee",
                "Hypno",
                "Krabby",
                "Kingler",
                "Voltorb",
                "Electrode",
                "Exeggcute",
                "Exeggutor",
                "Cubone",
                "Marowak",
                "Hitmonlee",
                "Hitmonchan",
                "Lickitung",
                "Koffing",
                "Weezing",
                "Rhyhorn",
                "Rhydon",
                "Chansey",
                "Tangela",
                "Kangaskhan",
                "Horsea",
                "Seadra",
                "Goldeen",
                "Seaking",
                "Staryu",
                "Starmie",
                "Mr. Mime",
                "Scyther",
                "Jynx",
                "Electabuzz",
                "Magmar",
                "Pinsir",
                "Tauros",
                "Magikarp",
                "Gyarados",
                "Lapras",
                "Ditto",
                "Eevee",
                "Vaporeon",
                "Jolteon",
                "Flareon",
                "Porygon",
                "Omanyte",
                "Omastar",
                "Kabuto",
                "Kabutops",
                "Aerodactyl",
                "Snorlax",
                "Articuno",
                "Zapdos",
                "Moltres",
                "Dratini",
                "Dragonair",
                "Dragonite",
                "Mewtwo",
                "Mew"
                #endregion
            };

            randomJo = new string[]
            {
                #region Johto
                "Chikorita",
                "Bayleef",
                "Meganium",
                "Cyndaquil",
                "Quilava",
                "Typhlosion",
                "Totodile",
                "Croconaw",
                "Feraligatr",
                "Sentret",
                "Furret",
                "Hoothoot",
                "Noctowl",
                "Ledyba",
                "Ledian",
                "Spinarak",
                "Ariados",
                "Crobat",
                "Chinchou",
                "Lanturn",
                "Pichu",
                "Cleffa",
                "Igglybuff",
                "Togepi",
                "Togetic",
                "Natu",
                "Xatu",
                "Mareep",
                "Flaaffy",
                "Ampharos",
                "Bellossom",
                "Marill",
                "Azumarill",
                "Sudowoodo",
                "Politoed",
                "Hoppip",
                "Skiploom",
                "Jumpluff",
                "Sunkern",
                "Sunflora",
                "Yanma",
                "Wooper",
                "Quagsire",
                "Espeon",
                "Umbreon",
                "Murkrow",
                "Slowking",
                "Misdreavus",
                "Unown",
                "Wobbuffet",
                "Girafarig",
                "Pineco",
                "Forretress",
                "Dunsparce",
                "Gligar",
                "Steelix",
                "Snubbull",
                "Granbull",
                "Qwilfish",
                "Scizor",
                "Shuckle",
                "Heracross",
                "Sneasel",
                "Teddiursa",
                "Ursaring",
                "Slugma",
                "Magcargo",
                "Swinub",
                "Piloswine",
                "Corsola",
                "Remoraid",
                "Octillery",
                "Delibird",
                "Mantine",
                "Skarmory",
                "Houndour",
                "Houndoom",
                "Kingdra",
                "Phanpy",
                "Donphan",
                "Porygon2",
                "Stantler",
                "Smeargle",
                "Tyrogue",
                "Hitmontop",
                "Smoochum",
                "Elekid",
                "Magby",
                "Miltank",
                "Blissey",
                "Raikou",
                "Entei",
                "Suicune",
                "Larvitar",
                "Pupitar",
                "Tyranitar",
                "Lugia",
                "Ho-Oh",
                "Celebi"
                #endregion
            };

            randomHo = new string[]
            {
                #region Hoenn
                "Treecko",
                "Grovyle",
                "Sceptile",
                "Torchic",
                "Combusken",
                "Blaziken",
                "Mudkip",
                "Marshtomp",
                "Swampert",
                "Poochyena",
                "Mightyena",
                "Zigzagoon",
                "Linoone",
                "Wurmple",
                "Silcoon",
                "Beautifly",
                "Cascoon",
                "Dustox",
                "Lotad",
                "Lombre",
                "Ludicolo",
                "Seedot",
                "Nuzleaf",
                "Shiftry",
                "Tailow",
                "Swellow",
                "Wingull",
                "Pelipper",
                "Ralts",
                "Kirlia",
                "Gardevoir",
                "Surskit",
                "Masquerain",
                "Shroomish",
                "Breloom",
                "Slakoth",
                "Vigoroth",
                "Slaking",
                "Nincada",
                "Ninjask",
                "Shedinja",
                "Whismur",
                "Loudred",
                "Exploud",
                "Makuhita",
                "Hariyama",
                "Azurill",
                "Nosepass",
                "Skitty",
                "Delcatty",
                "Sableye",
                "Mawile",
                "Aron",
                "Lairon",
                "Aggron",
                "Meditite",
                "Medicham",
                "Electrike",
                "Manectric",
                "Plusle",
                "Minun",
                "Volbeat",
                "Illumise",
                "Roselia",
                "Gulpin",
                "Swalot",
                "Carvanha",
                "Sharpedo",
                "Wailmer",
                "Wailord",
                "Numel",
                "Camerupt",
                "Torkoal",
                "Spoink",
                "Grumpig",
                "Spinda",
                "Trapinch",
                "Vibrava",
                "Flygon",
                "Cacnea",
                "Cacturne",
                "Swablu",
                "Altaria",
                "Zangoose",
                "Seviper",
                "Lunatone",
                "Solrock",
                "Barboach",
                "Whiscash",
                "Corphish",
                "Crawdaunt",
                "Baltoy",
                "Claydol",
                "Lileep",
                "Cradily",
                "Anorith",
                "Armaldo",
                "Feebas",
                "Milotic",
                "Castform",
                "Kecleon",
                "Shuppet",
                "Banette",
                "Duskull",
                "Dusclops",
                "Tropius",
                "Chimecho",
                "Absol",
                "Wynaut",
                "Snorunt",
                "Glalie",
                "Spheal",
                "Sealeo",
                "Walrein",
                "Clamperl",
                "Huntail",
                "Gorebyss",
                "Relicanth",
                "Luvdisc",
                "Bagon",
                "Shelgon",
                "Salamence",
                "Beldum",
                "Metang",
                "Metagross",
                "Regirock",
                "Regice",
                "Registeel",
                "Latias",
                "Latios",
                "Kyogre",
                "Groudon",
                "Rayquaza",
                "Jirachi",
                "Deoxys"
                #endregion
            };

            randomSi = new string[]
            {
                #region Sinnoh
                "Turtwig",
                "Grotle",
                "Torterra",
                "Chimchar",
                "Monferno",
                "Infernape",
                "Piplup",
                "Prinplup",
                "Empoleon",
                "Starly",
                "Staravia",
                "Staraptor",
                "Bidoof",
                "Bibarel",
                "Kricketot",
                "Kricketune",
                "Shinx",
                "Luxio",
                "Luxray",
                "Budew",
                "Roserade",
                "Cranidos",
                "Rampardos",
                "Shieldon",
                "Bastiodon",
                "Burmy",
                "Wormadam",
                "Mothim",
                "Combee",
                "Vespiqueen",
                "Pachirisu",
                "Buizel",
                "Floatzel",
                "Cherubi",
                "Cherrim",
                "Shellos",
                "Gastrodon",
                "Ambipom",
                "Drifloon",
                "Drifblim",
                "Buneary",
                "Lopunny",
                "Mismagius",
                "Honchkrow",
                "Glameow",
                "Purugly",
                "Chingling",
                "Stunky",
                "Skuntank",
                "Bronzor",
                "Bronzong",
                "Bonsly",
                "Mime Jr.",
                "Happiny",
                "Chatot",
                "Spiritomb",
                "Gible",
                "Gabite",
                "Garchomp",
                "Munchlax",
                "Riolu",
                "Lucario",
                "Hippopotas",
                "Hippowdon",
                "Skorupi",
                "Drapion",
                "Croagunk",
                "Toxicroak",
                "Carvine",
                "Finneon",
                "Lumineon",
                "Mantyke",
                "Snover",
                "Amomasnow",
                "Weavile",
                "Magnezone",
                "Lickilicky",
                "Rhyperior",
                "Tangrowth",
                "Electivire",
                "Magmortar",
                "Togekiss",
                "Yanmega",
                "Leafeon",
                "Glaceon",
                "Gliscor",
                "Mamoswine",
                "Porygon-Z",
                "Gallade",
                "Probopass",
                "Dusknoir",
                "Froslass",
                "Rotom",
                "Uxie",
                "Mesprit",
                "Azelf",
                "Dialga",
                "Palkia",
                "Heatran",
                "Regigigas",
                "Giratina",
                "Cresselia",
                "Phione",
                "Manaphy",
                "Darkrai",
                "Shaymin",
                "Arceus",
                #endregion
            };

            randomUn = new string[]
            {
                #region Unova
                "Victini",
                "Snivy",
                "Servine",
                "Serperior",
                "Tepig",
                "Pignite",
                "Emboar",
                "Oshawott",
                "Dewott",
                "Samurott",
                "Patrat",
                "Watchog",
                "Lillipup",
                "Herdier",
                "Stoutland",
                "Purrloin",
                "Liepard",
                "Pansage",
                "Simisage",
                "Pansear",
                "Simisear",
                "Panpour",
                "Simipour",
                "Munna",
                "Musharna",
                "Pidove",
                "Tranquill",
                "Unfezant",
                "Blitzle",
                "Zebstrika",
                "Roggenrola",
                "Boldore",
                "Gigalith",
                "Woobat",
                "Swoobat",
                "Drilbur",
                "Excadrill",
                "Audino",
                "Timburr",
                "Gurdurr",
                "Conkeldurr",
                "Tympole",
                "Palpitoad",
                "Seismitoad",
                "Throh",
                "Sawk",
                "Sewaddle",
                "Swadloon",
                "Leavanny",
                "Venipede",
                "Whirlipede",
                "Scolipede",
                "Cottonee",
                "Whimiscott",
                "Petilil",
                "Lilligant",
                "Basculin",
                "Sandile",
                "Krokorok",
                "Krookodile",
                "Darumaka",
                "Darmanitan",
                "Maractus",
                "Dwebble",
                "Crustle",
                "Scraggy",
                "Scrafty",
                "Sigilyph",
                "Yamask",
                "Confagrigus",
                "Tirtouga",
                "Carracosta",
                "Archen",
                "Archeops",
                "Trubbish",
                "Garbodor",
                "Zorua",
                "Zoroark",
                "Minccino",
                "Cinccino",
                "Gothita",
                "Gothorita",
                "Gothitelle",
                "Solosis",
                "Duosion",
                "Reuniclus",
                "Ducklett",
                "Swanna",
                "Vanillite",
                "Vanillish",
                "Vanilluxe",
                "Deerling",
                "Sawsbuck",
                "Emolga",
                "Karrablast",
                "Escavalier",
                "Foongus",
                "Amoonguss",
                "Frillish",
                "Jellicent",
                "Joltik",
                "Galvantula",
                "Ferroseed",
                "Ferrothorn",
                "Klink",
                "Klank",
                "Klinklang",
                "Tynamo",
                "Eelektrik",
                "Eelektross",
                "Elgyem",
                "Beheeyem",
                "Litwick",
                "Lampent",
                "Chandelure",
                "Axew",
                "Fraxure",
                "Haxorus",
                "Cubchoo",
                "Beartic",
                "Cryogonal",
                "Shelmet",
                "Accelgor",
                "Stunfisk",
                "Mienfoo",
                "Mienshao",
                "Druddigon",
                "Golett",
                "Golurk",
                "Pawniard",
                "Bisharp",
                "Bouffalant",
                "Rufflet",
                "Braviary",
                "Vullaby",
                "Mandibuzz",
                "Heatmor",
                "Durant",
                "Deino",
                "Zweilous",
                "Hydreigon",
                "Larvesta",
                "Volcarona",
                "Cobalion",
                "Terrakion",
                "Virizion",
                "Tornadus",
                "Thundurus",
                "Reshiram",
                "Zekrom",
                "Landorus",
                "Kyurem",
                "Keldeo",
                "Meloetta",
                "Genesect",
                #endregion
            };

            randomKl = new string[]
            {
                #region Kalos
                "Chespin",
                "Quilladin",
                "Chesnaught",
                "Fennekin",
                "Braixen",
                "Delphox",
                "Froakie",
                "Frogadier",
                "Greninja",
                "Bunnelby",
                "Diggersby",
                "Fletchling",
                "Fletchinder",
                "Talonflame",
                "Scatterbug",
                "Spewpa",
                "Vivillon",
                "Litleo",
                "Pyroar",
                "Flabébé",
                "Floette",
                "Florges",
                "Skiddo",
                "Gogoat",
                "Pancham",
                "Pangoro",
                "Furfrou",
                "Espurr",
                "Meowstic",
                "Honedge",
                "Doublade",
                "Aegislash",
                "Spritzee",
                "Aromatisse",
                "Swirlix",
                "Slurpuff",
                "Inkay",
                "Malamar",
                "Binacle",
                "Barbaracle",
                "Skrelp",
                "Dragalge",
                "Clauncher",
                "Clawitzer",
                "Helioptile",
                "Heliolisk",
                "Tyrunt",
                "Tyrantrum",
                "Amaura",
                "Aurorus",
                "Sylveon",
                "Hawlucha",
                "Dedenne",
                "Carbink",
                "Goomy",
                "Sliggoo",
                "Goodra",
                "Klefki",
                "Phantump",
                "Trevenant",
                "Pumpkaboo",
                "Gourgeist",
                "Bergmite",
                "Avalugg",
                "Noibat",
                "Noivern",
                "Xerneas",
                "Yveltal",
                "Zygarde",
                "Diancie",
                "Hoopa",
                "Volcanion",
                #endregion
            };

            randomAl = new string[]
            {
                #region Alola
                "Rowlet",
                "Dartrix",
                "Decidueye",
                "Litten",
                "Torracat",
                "Incineroar",
                "Popplio",
                "Brionne",
                "Primarina",
                "Pikipek",
                "Trumbeak",
                "Toucannon",
                "Yungoos",
                "Gumshoos",
                "Grubbin",
                "Charjabug",
                "Vikavolt",
                "Crabrawler",
                "Crabominable",
                "Oricorio",
                "Cutiefly",
                "Ribombee",
                "Rockruff",
                "Lycanroc",
                "Wishiwashi",
                "Mareanie",
                "Toxapex",
                "Mudbray",
                "Mudsdale",
                "Dewpider",
                "Araquanid",
                "Fomantis",
                "Lurantis",
                "Morelull",
                "Shiitonic",
                "Salandit",
                "Salazzle",
                "Stufful",
                "Bewear",
                "Bounsweet",
                "Steenee",
                "Tsareena",
                "Comfey",
                "Oranguru",
                "Passimian",
                "Wimpod",
                "Golisopod",
                "Sandygast",
                "Palossand",
                "Pyukumuku",
                "Type: Null",
                "Silvally",
                "Minior",
                "Komala",
                "Turtonator",
                "Togedemaru",
                "Mimikyu",
                "Bruxish",
                "Drampa",
                "Dhelmise",
                "Jangmo-o",
                "Hakamo-o",
                "Kommo-o",
                "Tapu Koko",
                "Tapu Lele",
                "Tapu Bulu",
                "Tapu Fini",
                "Cosmog",
                "Cosmoem",
                "Solgaleo",
                "Lunala",
                "Nihilego",
                "Buzzwole",
                "Pheromosa",
                "Xurkitree",
                "Celesteela",
                "Kartana",
                "Guzzlord",
                "Necrozma",
                "Magearna",
                "Marshadow"
                #endregion
            };
            #endregion

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '-';
                x.AllowMentionPrefix = true;
            });



            commands = discord.GetService<CommandService>();

            commands.CreateCommand("hello")
                .Do(async (e) =>
            {
                await e.Channel.SendMessage("Hi!");
            });

            RandomPoke();
            Help();
            RandomKa();
            RandomJo();
            RandomHo();
            RandomSi();
            RandomKl();
            RandomUn();
            RandomAl();
            ThrowItem();
            //DeleteChat();
            Facts();
            MuffinTime();
            FeedMike();
            PostPic();
            Birthdays();
            Mention();
            OnJoin();
            OnLeave();
            Mission();

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("", TokenType.Bot);
            });
        }

        #region Random Classes
        private void RandomPoke()
        {
            commands.CreateCommand("randompoke")
                .Do(async (e) =>
                {
                    int rand = r.Next(randompoke.Length);
                    string randmon = randompoke[rand];
                    await e.Channel.SendMessage(randmon);
                    Console.WriteLine(randmon);
                });

            commands.CreateCommand("randomstart")
                .Alias("randomstarter", "randoms", "starter")
                .Do(async (e) =>
                {
                    int rand = r.Next(randomstart.Length);
                    string randmon = randomstart[rand];
                    await e.Channel.SendMessage(randmon);
                    Console.WriteLine(randmon);
                });

            commands.CreateCommand("randomregion")
                .Alias("randomreg", "randomr", "region")
                .Do(async (e) =>
                {
                    int rand = r.Next(randomregion.Length);
                    string randmon = randomregion[rand];
                    await e.Channel.SendMessage(randmon);
                    Console.WriteLine(randmon);
                });
        }

        private void RandomKa()
        {
            commands.CreateCommand("randomKa")
                .Do(async (e) =>
                {
                    int rand = r.Next(randomKa.Length);
                    string randmon = randomKa[rand];
                    await e.Channel.SendMessage(randmon);
                    Console.WriteLine(randmon);
                });
        }
        private void RandomJo()
        {
            commands.CreateCommand("randomJo")
                .Do(async (e) =>
                {
                    int rand = r.Next(randomJo.Length);
                    string randmon = randomJo[rand];
                    await e.Channel.SendMessage(randmon);
                    Console.WriteLine(randmon);
                });
        }
        private void RandomHo()
        {
            commands.CreateCommand("randomHo")
                .Do(async (e) =>
                {
                    int rand = r.Next(randomHo.Length);
                    string randmon = randomHo[rand];
                    await e.Channel.SendMessage(randmon);
                    Console.WriteLine(randmon);
                });
        }
        private void RandomSi()
        {
            commands.CreateCommand("randomSi")
                .Do(async (e) =>
                {
                    int rand = r.Next(randomSi.Length);
                    string randmon = randomSi[rand];
                    await e.Channel.SendMessage(randmon);
                    Console.WriteLine(randmon);
                });
        }
        private void RandomUn()
        {
            commands.CreateCommand("randomUn")
                .Do(async (e) =>
                {
                    int rand = r.Next(randomUn.Length);
                    string randmon = randomUn[rand];
                    await e.Channel.SendMessage(randmon);
                    Console.WriteLine(randmon);
                });
        }
        private void RandomKl()
        {
            commands.CreateCommand("randomKl")
                .Do(async (e) =>
                {
                    int rand = r.Next(randomKl.Length);
                    string randmon = randomKl[rand];
                    await e.Channel.SendMessage(randmon);
                    Console.WriteLine(randmon);
                });
        }
        private void RandomAl()
        {
            commands.CreateCommand("randomAl")
                .Do(async (e) =>
                {
                    int rand = r.Next(randomAl.Length);
                    string randmon = randomAl[rand];
                    await e.Channel.SendMessage(randmon);
                    Console.WriteLine(randmon);
                });
        }

        #endregion

        private void Birthdays()
        {
            commands.CreateCommand("bday")
            .Do(async (e) =>
            {
                DateTime mikeBday = new DateTime(DateTime.Now.Year, 7, 2, 23, 0, 0);
                DateTime mikeBday2 = new DateTime(DateTime.Now.Year, 8, 2, 22, 59, 59);
                DateTime rotomBday = new DateTime(DateTime.Now.Year, 23, 3, 0, 0, 0);
                DateTime rotomBday2 = new DateTime(DateTime.Now.Year, 23, 3, 23, 59, 59);
                DateTime chikoBday = new DateTime(DateTime.Now.Year, 10, 5, 0, 0, 0);
                DateTime chikoBday2 = new DateTime(DateTime.Now.Year, 10, 5, 23, 59, 59);
                DateTime umprespBday = new DateTime(DateTime.Now.Year, 4, 7, 0, 0, 0);
                DateTime umprespBday2 = new DateTime(DateTime.Now.Year, 4, 7, 23, 59, 59);
                DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

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
            });
        }

        private void ThrowItem()
        {
            commands.CreateCommand("throwItem")
                .Do(async (e) =>
                {
                    int rand = r.Next(items.Length);
                    string randmon = items[rand];
                    await e.Channel.SendMessage("*Throws " + randmon + ".*");
                    Console.WriteLine(randmon);
                });
        }

        private void Mission()
        {
            int y = dungeons.GetLength(0);

            commands.CreateCommand("quest")
                .Do(async e =>
                {
                    int rand = r.Next(y);
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
                    );
                    commands.CreateCommand("location")
                .Do(async (e) =>
                {
                    int rand = r.Next(y);
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
                });

                    commands.CreateCommand("mission")
                        .Do(async (e) =>
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
                        });
                }

        private void Mention()
        {
            commands.CreateCommand("mention")
                .Parameter("mention", ParameterType.Required)
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Hello " + e.GetArg("mention"));
                    Console.WriteLine(e.GetArg("mention"));
                });

            commands.CreateCommand("eh")
                .Alias(new string[] { "meh", "bleh", "neh" })
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Meh, meh, meh, meh, meh, meh, meh, meh, meh, meh, meh, meh, meh, DERP!!");
                });
        }

        private void FeedMike()
        {
            commands.CreateCommand("feedMe")
                .Do(async (e) =>
                {
                    int rand = r.Next(feedMike.Length);
                    string randmon = feedMike[rand];
                    await e.Channel.SendMessage("*Puts " + randmon + " in front of " + e.User.Mention +".*");
                    Console.WriteLine(randmon);
                });
        }

        private void Facts()
        {
            commands.CreateCommand("facts")
                .Alias(new string[] { "randomfact", "randomfacts", "fact" })
                .Do(async (e) =>
                {
                    int rand = r.Next(facts.Length);
                    string randmon = facts[rand];
                    await e.Channel.SendMessage("Captain Here.  " + randmon + "       *flies away* ");
                    Console.WriteLine(randmon);
                });
        }

        private void PostPic()
        {
            commands.CreateCommand("randompic")
                .Do(async (e) =>
                {
                    int rand = r.Next(randomPics.Length);
                    string randmon = randomPics[rand];
                    string stuff = "images/" + randmon;
                    await e.Channel.SendFile(stuff);
                    Console.WriteLine(randmon);
                });

            commands.CreateCommand("flareon")
                .Do(async (e) =>
                {
                    string stuff = "images/" + "flareon.jpg";
                    await e.Channel.SendFile(stuff);
                });

            commands.CreateCommand("3")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("ausCute.png");
                });


            commands.CreateCommand("eevee")
                .Do(async (e) =>
                {
                    string stuff = "images/" + "eevee.jpg";
                    await e.Channel.SendFile(stuff);
                });

            commands.CreateCommand("skylitten")
                .Do(async (e) =>
                {
                    string stuff = "images/" + "skylitten.jpg";
                    await e.Channel.SendFile(stuff);
                });

            commands.CreateCommand("Tia")
                .Alias("Pocky", "PockyTia")
                .Do(async (e) =>
                {
                    string stuff = "images/" + "PockyTia.jpg";
                    await e.Channel.SendFile(stuff);
                });

            commands.CreateCommand("torrabox")
                .Do(async (e) =>
                {
                    string stuff = "images/" + "torrabox.png";
                    await e.Channel.SendFile(stuff);
                });

            commands.CreateCommand("littencake")
                .Do(async (e) =>
                {
                    string stuff = "images/" + "littencake.png";
                    await e.Channel.SendFile(stuff);
                });

            commands.CreateCommand("Mimikyuveelutions")
                .Alias("Meeveelutions", "Meevee", "MimikyuEevee")
                .Do(async (e) =>
                {
                    string stuff = "images/" + "Mimikyuveelutions.png";
                    await e.Channel.SendFile(stuff);
                });

            commands.CreateCommand("feedmore")
                .Do(async (e) =>
                {
                    string stuff = "images/" + "feedmore.png";
                    await e.Channel.SendFile(stuff);
                });

            commands.CreateCommand("happylitten")
                .Do(async (e) =>
                {
                    string stuff = "images/" + "happylitten.png";
                    await e.Channel.SendFile(stuff);
                });

            commands.CreateCommand("flareonlitten")
                .Do(async (e) =>
                {
                    string stuff = "images/" + "fliteon.png";
                    await e.Channel.SendFile(stuff);
                });

            commands.CreateCommand("furfrouH")
                .Do(async (e) =>
                {
                    string stuff = "images/" + "furfrouhearts.png";
                    await e.Channel.SendFile(stuff);
                });

            commands.CreateCommand("torrafat")
                .Do(async (e) =>
                {
                    string stuff = "images/" + "littenF.png";
                    await e.Channel.SendFile(stuff);
                });

            commands.CreateCommand("meowstic")
                .Do(async (e) =>
                {
                    string stuff = "images/" + "Meowstic.gif";
                    await e.Channel.SendFile(stuff);
                });

            commands.CreateCommand("weaveroar")
                .Do(async (e) =>
                {
                    string stuff = "images/" + "weavincineroar.png";
                    await e.Channel.SendFile(stuff);
                });
        }

        private void MuffinTime()
        {
            commands.CreateCommand("muffin")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("It's muffintime!!");
                    await e.Channel.SendFile("images/muffin.png");
                });

            commands.CreateCommand("muffinG")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("It's muffintime!!");
                    await e.Channel.SendFile("images/muffin.gif");
                });
        }

        private void Help()
        {
            commands.CreateCommand("help")
                .Do(async (e) =>
                {
                    /*await e.Channel.SendMessage("These are the current codes: ");
                    await e.Channel.SendMessage("hello");
                    await e.Channel.SendMessage("randompoke");
                    await e.Channel.SendMessage("randomKa");
                    await e.Channel.SendMessage("randomJo");
                    await e.Channel.SendMessage("randomHo");
                    await e.Channel.SendMessage("randomSi");
                    await e.Channel.SendMessage("randomUn");
                    await e.Channel.SendMessage("randomKl");
                    await e.Channel.SendMessage("randomAl");
                    await e.Channel.SendMessage("throwItem");
                    await e.Channel.SendMessage("help");
                    await e.Channel.SendMessage("facts");
                    await e.Channel.SendMessage("feedMe");
                    await e.Channel.SendMessage("muffin");
                    await e.Channel.SendMessage("muffinG");
                    await e.Channel.SendMessage("delete (only for people with the 'Admin' role)");*/
                    await e.Channel.SendFile("images/help.png");
                });
        }

        private void DeleteChat()
        {
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

        private void OnJoin()
        {
            discord.UserJoined += async (s, e) =>
            {
                var channel = e.Server.FindChannels("general").FirstOrDefault();
                var user = e.User.Id;
                await channel.SendMessage(string.Format("Welcome to the server <@" + user + ">. Please read #rules first."));
            };
        }

        private void OnLeave()
        {
            discord.UserLeft += async (s, e) =>
            {
                var channel = e.Server.FindChannels("general").FirstOrDefault();
                var user = e.User.Id;
                await channel.SendMessage(string.Format("Oh no! <@" + user + "> has left!! :sob:"));
            };
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
