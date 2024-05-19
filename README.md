# Modular Save
This is a save tool which works in Unity game engine.

## Setting Up Managers
1. Attach ServiceManager.cs to an game object

2. Attach SaveManager.cs to an game object and parent it to Service Manager object

3. Attach Save Manager object to manager list at ServiceManager.cs in Service Manager object

## Usage
-> Attach ISaveable interface to which class you want to save any data

-> Create a data class like ExampleSaveablaData in SaveData.cs

-> Implement ISaveable interface like ExampleSaveable.cs

## Details
-> It loads at the beginning of the game and saves when player exits from the game

## Planned Updates
-> Fixed multiple saves

-> Limitless multiple saves

-> Encryption-Decryption
