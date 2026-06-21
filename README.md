# Shadows Are Following (C# / .NET)

This repository contains my personal software architecture project in C#. I work on this project to create a new game with C#/Raylib.

The most important part of **Shadows Are Following** is my own **ECS (Entity Component System) library**. I built it from scratch so I can reuse it for different game ideas in the future.

---

## Project Structure

The project is split into three clean parts:

* **`EntityComponentSystem/` (Class Library):** My own little framework that keeps entities, components, and systems separate.
* **`Main/` (Console Application):** The actual game project. It uses the ECS library and `raylib-cs` to draw the game on the screen and run the game loop.
* **`Tests/` (NUnit Project):** Automated tests that check if the ECS and Main works correctly (for example: creating entities, adding components, and counting entities).

---

## Technical Highlights & Clean Code

To keep the code clean and test my own knowledge, I use these concepts:

* **Generics:** I use generic methods (like `GetComponent<T>()`) to easily find and get components from entities.
* **Modern C# Features:** I use Named Tuples to return multiple values from methods cleanly, and pattern matching to check object types.
* **Unit Testing:** I use the **AAA rule** (Arrange, Act, Assert) in NUnit to test my code and make sure it does not break when things go wrong.
* **Separation of Concerns:** I keep the engine logic, the game, and the tests completely separate from each other.
* **CustomList:** Created my own custom list from scratch to handle data efficiently and understand underlying data structures.


---

## How to Run the Project

The project uses the standard .NET-CLI, so you can run it on Windows, macOS, or Linux using Visual Studio Code.

### Requirements
* .NET 8.0 SDK (or higher)

### Start the Game
Go to the `Main` folder in your terminal and run this command:
```bash
cd Main
dotnet run
```