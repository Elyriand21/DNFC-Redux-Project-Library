# DNFC_Redux_Library

A lightweight shared utility library for **MelonLoader** mods targeting **Definitely Not Fried Chicken** (Unity / IL2CPP).

This library centralizes commonly used state flags and provides convenient access to GameObjecst, making it easier to build modular, maintainable DNFC mods.

---

## 🎯 Target Game

This library is built specifically for [Definitely Not Fried Chicken](https://store.steampowered.com/app/1036240/Definitely_Not_Fried_Chicken/)

## 📦 Purpose

When developing multiple mods or a modular system for DNFC, repeated logic can become duplicated or messy:

- Determining if the player is in-game or in the main menu
- Checking if your mod has initialized
- Finding and storing references to important GameObjects
  
`DNFC_Redux_Library` provides a shared static data layer (`SharedData`) and a clean API (`Library`) to standardize this behavior across mods.

## Install Instructions

<br>

> [!TIP]
> **Don't know how to install? Review the information below**

### MelonLoader
- Download [MelonLoader.Installer.exe](https://github.com/LavaGang/MelonLoader/releases/latest)
- Run MelonLoader.Installer.exe
- Click the **select** button.
- Select DNFC.exe in your Game's Installation Folder.
- Uncheck **Latest** and select version **v0.7.1** from the Drop-Down List.
- Once the installation is successful, open the game through Steam/Epic Games.
- Place **DNFC_Redux_Library.dll** into the newly created Mods folder inside the Game's Installation Folder.
## Usage
```cs
using DNFC_Redux_Library;
using MelonLoader;
using Mod_Example;

[assembly: MelonInfo(typeof(Mod), "MOD_NAME", "1.0.0", "MOD_AUTHOR")]
[assembly: MelonGame("Dope Games", "DNFC")]
namespace Mod_Example
{
    public class Mod : MelonMod
    {
        static Library DNFC_Lib = new Library();
    }
}
```

## Game Properties
<br>

> [!NOTE]
> **Functions that handle the in-game properties**

<br>

- **IsInGame()** > `bool`
  - Returns if the player is in the game
- **SetIsInGame(bool inGame)** > `void`
  - Sets if the player is in the game
- **IsInLoading()** > `bool`
  - Returns if the player is in the loading screen
- **SetIsInLoading(bool inLoading)** > `void`
  - Sets if the player is in the loading screen
- **IsInMainMenu()** > `bool`
  - Returns if the player is in the main menu
- **SetIsInMainMenu(bool inMainMenu)** > `void`
  - Sets if the plyaer is in the main menu
- **IsInitialized()** > `bool`
  - Returns if the mod has been intialized
- **SetIsInitialized(bool initialized)** > `void`
  - Sets if the mod has been initalized

## Game Objects
<br>

> [!NOTE]
> **Functions that handle the in-game objects**

<br>

- **FindSettingsManager()** > `void`
  - Finds and sets the SettingsManager GameObject
- **GetSettingsManager()** > `GameObject`
  - Returns the SettingsManager GameObject
 
## Debug
<br>

> [!NOTE]
> **Functions that handle debugging for developers**

<br>

- **GetActiveInHierarchy(GameObject obj)** > `bool`
  - Returns if `obj` is active in the scene, throws `Error` if provided `GameObject` is `null`
