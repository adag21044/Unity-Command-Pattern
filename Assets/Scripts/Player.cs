using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 endPosition;
    private Vector3 startPosition;
    private float desiredDuration = 1f; // Her bir birimlik hareket için süre
    private float elapsedTime;
    private bool isMoving = false; // Hareket halinde olup olmadığını takip etmek için

    [SerializeField]
    private AnimationCurve curve;

    private CommandManager commandManager;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition;
        commandManager = FindObjectOfType<CommandManager>();
    }

    void Update()
    {
        // Hareket halindeyse, yeni bir input almayı engelle
        if (isMoving || commandManager == null)
            return;

        // Inputları al
        if (Input.GetKeyDown(KeyCode.W))
        {
            commandManager.ExecuteCommand(new MoveUpCommand(this));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            commandManager.ExecuteCommand(new MoveLeftCommand(this));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            commandManager.ExecuteCommand(new MoveDownCommand(this));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            commandManager.ExecuteCommand(new MoveRightCommand(this));
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            commandManager.Undo();
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            commandManager.Redo();
        }
    }

    public void Move(Vector3 direction)
    {
        MoveToPosition(transform.position + direction);
    }

    public void MoveToPosition(Vector3 position)
    {
        startPosition = transform.position;
        endPosition = position;
        elapsedTime = 0f;
        isMoving = true;
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            elapsedTime += Time.fixedDeltaTime;
            float t = Mathf.Clamp01(elapsedTime / desiredDuration);
            transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(t));

            if (Vector3.Distance(transform.position, endPosition) < 0.01f)
            {
                transform.position = endPosition;
                startPosition = endPosition;
                isMoving = false;
            }
        }
    }
}
