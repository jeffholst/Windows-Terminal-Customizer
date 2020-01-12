using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Terminal_Customizer
{
    public class Settings
    {
        public bool alwaysShowTabs { get; set; }
        public bool copyOnSelect { get; set; }
        public string defaultProfile { get; set; }
        public string initialCols { get; set; }
        public string initialRows { get; set; }
        public string requestedTheme { get; set; }
        public bool showTerminalTitleInTitlebar { get; set; }
        public bool showTabsInTitlebar { get; set; }
        public string wordDelimters { get; set; }


        public List<Profile> profiles { get; set; }
        public List<Scheme> schemes { get; set; }
        public List<KeyBinding> keybindings { get; set; }

    }

    public class Profile
    {
        public string guid { get; set; }
        public string name { get; set; }
        public string source { get; set; }
        public string colorScheme { get; set; }
        public double? acrylicOpacity { get; set; } = null;
        public string background { get; set; }
        public string backgroundImage { get; set; }
        public string backgroundImageAlignment { get; set; }
        public double? backgroundImageOpacity { get; set; } = null;
        public string backgroundImageStretchMode { get; set; }
        public string closeOnExit { get; set; }
        public List<string> colorTable { get; set; }
        [JsonProperty(PropertyName = "commandline")]
        public string commandLine { get; set; }
        public string cursorColor { get; set; }
        public string cursorHeight { get; set; }
        public string cursorShape { get; set; }
        public string fontFace { get; set; }
        public string fontSize { get; set; }
        public string foreground { get; set; }
        public bool hidden { get; set; } = false;
        public string historySize { get; set; }
        public string icon { get; set; }
        public string padding { get; set; }
        public string scrollbarState { get; set; }
        public string selectionBackground { get; set; }
        public bool snapOnInput { get; set; } = true;
        public string startingDirectory { get; set; } = ".";
        public bool suppressApplicationTitle { get; set; } = false;
        public string tabTitle { get; set; }
        public bool useAcrylic { get; set; } = false;

        [JsonProperty(PropertyName = "experimental.retroTerminalEffect")]
        public bool experimentalRetroTerminalEffect { get; set; } = false;

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }

    public class Scheme
    {
        /*
              ___                     _            _   _ 
             |_ _|_ __  _ __  ___ _ _| |_ __ _ _ _| |_| |
              | || '  \| '_ \/ _ \ '_|  _/ _` | ' \  _|_|
             |___|_|_|_| .__/\___/_|  \__\__,_|_||_\__(_)
                       |_|                               

            If a property is modified here, be sure to reflect the change in Update() and IsEqual() methods below
        */

        public string name { get; set; }
        public string black { get; set; }
        public string red { get; set; }
        public string green { get; set; }
        public string yellow { get; set; }
        public string blue { get; set; }
        public string purple { get; set; }
        public string cyan { get; set; }
        public string white { get; set; }
        public string brightBlack { get; set; }
        public string brightRed { get; set; }
        public string brightGreen { get; set; }
        public string brightYellow { get; set; }
        public string brightBlue { get; set; }
        public string brightPurple { get; set; }
        public string brightCyan { get; set; }
        public string brightWhite { get; set; }
        public string background { get; set; }
        public string foreground { get; set; }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public void Update(Scheme newScheme)
        {
            // Copies all values from the new newScheme into current Scheme

            name = newScheme.name;
            black = newScheme.black;
            red = newScheme.red;
            green = newScheme.green;
            yellow = newScheme.yellow;
            blue = newScheme.blue;
            purple = newScheme.purple;
            cyan = newScheme.cyan;
            white = newScheme.white;
            brightBlack = newScheme.brightBlack;
            brightRed = newScheme.brightRed;
            brightGreen = newScheme.brightGreen;
            brightYellow = newScheme.brightYellow;
            brightBlue = newScheme.brightBlue;
            brightPurple = newScheme.brightPurple;
            brightCyan = newScheme.brightCyan;
            brightWhite = newScheme.brightWhite;
            background = newScheme.background;
            foreground = newScheme.foreground;
        }

        public bool IsEqual(Scheme compareScheme)
        {
            // Checks to see if compareScheme matches current Scheme

            bool isEqual;

            isEqual = string.Compare(black, compareScheme.black, true) == 0;

            if (isEqual) isEqual = string.Compare(red, compareScheme.red, true) == 0;
            if (isEqual) isEqual = string.Compare(green, compareScheme.green) == 0;
            if (isEqual) isEqual = string.Compare(yellow, compareScheme.yellow) == 0;
            if (isEqual) isEqual = string.Compare(blue, compareScheme.blue) == 0;
            if (isEqual) isEqual = string.Compare(purple, compareScheme.purple) == 0;
            if (isEqual) isEqual = string.Compare(cyan, compareScheme.cyan) == 0;
            if (isEqual) isEqual = string.Compare(white, compareScheme.white) == 0;
            if (isEqual) isEqual = string.Compare(brightBlack, compareScheme.brightBlack) == 0;
            if (isEqual) isEqual = string.Compare(brightRed, compareScheme.brightRed) == 0;
            if (isEqual) isEqual = string.Compare(brightGreen, compareScheme.brightGreen) == 0;
            if (isEqual) isEqual = string.Compare(brightYellow, compareScheme.brightYellow) == 0;
            if (isEqual) isEqual = string.Compare(brightBlue, compareScheme.brightBlue) == 0;
            if (isEqual) isEqual = string.Compare(brightPurple, compareScheme.brightPurple) == 0;
            if (isEqual) isEqual = string.Compare(brightCyan, compareScheme.brightCyan) == 0;
            if (isEqual) isEqual = string.Compare(brightWhite, compareScheme.brightWhite) == 0;
            if (isEqual) isEqual = string.Compare(background, compareScheme.background) == 0;
            if (isEqual) isEqual = string.Compare(foreground, compareScheme.foreground) == 0;

            return isEqual;
        }
    }

    public class KeyBinding
    {
        public string command { get; set; }
        public List<string> keys { get; set; }
    }
}
