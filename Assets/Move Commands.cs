using UnityEngine;

public interface ICommand
{
    void Execute();
    void Undo();
}

public abstract class MoveCommand : ICommand
{
    protected Player player;
    protected Vector3 previousPosition;
    protected Vector3 direction;

    public MoveCommand(Player player, Vector3 direction)
    {
        this.player = player;
        this.direction = direction;
    }

    public void Execute()
    {
        previousPosition = player.transform.position;
        player.Move(direction);
    }

    public void Undo()
    {
        player.MoveToPosition(previousPosition);
    }
}

public class MoveUpCommand : MoveCommand
{
    public MoveUpCommand(Player player) : base(player, new Vector3(0f, 0f, 1f)) { }
}

public class MoveDownCommand : MoveCommand
{
    public MoveDownCommand(Player player) : base(player, new Vector3(0f, 0f, -1f)) { }
}

public class MoveLeftCommand : MoveCommand
{
    public MoveLeftCommand(Player player) : base(player, new Vector3(-1f, 0f, 0f)) { }
}

public class MoveRightCommand : MoveCommand
{
    public MoveRightCommand(Player player) : base(player, new Vector3(1f, 0f, 0f)) { }
}