# Unity Command Pattern
# Command Pattern Movement System in Unity

This project demonstrates a movement system in Unity that utilizes the Command Pattern, allowing for executing, undoing, and redoing player movement commands.

## Project Structure

1. **CommandManager.cs**: Manages the execution, undo, and redo of commands.
2. **ICommand.cs**: Interface for commands.
3. **MoveCommand.cs**: Abstract class for movement commands.
4. **MoveUpCommand.cs**: Command for moving the player up.
5. **MoveDownCommand.cs**: Command for moving the player down.
6. **MoveLeftCommand.cs**: Command for moving the player left.
7. **MoveRightCommand.cs**: Command for moving the player right.
8. **Player.cs**: Handles player movement and command execution.

## CommandManager.cs

### CommandManager
Manages the execution, undo, and redo stacks for commands.
- **ExecuteCommand(ICommand command)**: Executes a command and adds it to the history stack.
- **Undo()**: Undoes the last executed command.
- **Redo()**: Redoes the last undone command.

## ICommand.cs

### ICommand
Defines the methods for commands.
- **Execute()**: Executes the command.
- **Undo()**: Undoes the command.

## MoveCommand.cs

### MoveCommand
Abstract class for movement commands, implementing the ICommand interface.
- **Execute()**: Saves the player's current position and moves the player in the specified direction.
- **Undo()**: Moves the player back to the previous position.

## MoveUpCommand.cs, MoveDownCommand.cs, MoveLeftCommand.cs, MoveRightCommand.cs

### Move Commands
Concrete implementations of `MoveCommand` for moving the player in different directions.
- **MoveUpCommand**: Moves the player up.
- **MoveDownCommand**: Moves the player down.
- **MoveLeftCommand**: Moves the player left.
- **MoveRightCommand**: Moves the player right.

## Player.cs

### Player
Handles player movement, input detection, and command execution.
- **Move(Vector3 direction)**: Moves the player in the specified direction.
- **MoveToPosition(Vector3 position)**: Moves the player to the specified position.
- **IsMoving()**: Returns whether the player is currently moving.
