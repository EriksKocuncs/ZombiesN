using UnityEngine;
using UnityEngine.InputSystem;

public class MazeController : MonoBehaviour
{
    public GameObject maze;
    public float rotationSpeed = 0.8f;

    private InputAction rotateInput;
    void Start()
    {
        rotateInput = InputSystem.actions.FindAction("Player/Move");
    }
    
    void Update()
    {
        Vector2 rotation = rotateInput.ReadValue<Vector2>();
        Debug.Log("rotation x = " + rotation.x + " y = " + rotation.y);
        maze.transform.Rotate(
            -rotation.y * Time.deltaTime * rotationSpeed,
            0,
            rotation.x * Time.deltaTime * rotationSpeed);
    }
}
