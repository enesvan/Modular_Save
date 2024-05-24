# Modular Save
This is a save tool which works in Unity game engine.

## Setting Up Managers
1. Attach ServiceManager.cs to an game object

2. Attach SaveManager.cs to an game object and parent it to Service Manager object

3. Attach UIManager.cs to an game object and parent it to Service Manager object

4. Attach Save Manager and UI Manager objects to manager list at ServiceManager.cs in Service Manager object

## Usage
1. Attach ISaveable interface to which class you want to save any data

2. Create a data class like ExampleSaveablaData in SaveData.cs

3. Implement ISaveable interface like ExampleSaveable.cs

## Details
-> It loads and saves with several buttons which controls different save files

-> If developer wants to use encryption system, it's selectable from inspector on Save Manager object
