for as bad as the documentation is, the "getting started" from the stardew wiki actually does get you started
https://stardewvalleywiki.com/Modding:Modder_Guide/Get_Started#Requirements

Make sure that you have dotnet 6.0 as your compile target and that the pathoschild nuget is installed, or else nothing works right. .csproj provided for reference purposes.

ModEntry.cs is the driver for the mod. 
hungySave.cs is the save file creator/updater. It's not really intuitive, but it works.

In order to have any items that heal hunger and thirst you'll need to update the values in healList/Edibles.cs to be anything other than 0.

READMA BALLS
