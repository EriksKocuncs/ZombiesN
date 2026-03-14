using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject selectedZombie;
    public GameObject[] zombies;
    private int selectedZombieID;
    public Vector3 selectedScale;
    private Rigidbody rb;
    public Vector3 pushForce;
    
    private InputAction next, previous, push;
    
    void Start()
    {
        next = InputSystem.actions.FindAction("Player/Next");
        previous = InputSystem.actions.FindAction("Player/Previous");
        push = InputSystem.actions.FindAction("Player/Push");
        SelectZombie(0);
        selectedZombie = zombies[0];
        Debug.Log("selected: " + selectedZombie.name);
    }
    
    void Update()
    {
        if (next.WasPressedThisFrame())
        {
            selectedZombieID++;
            if (selectedZombieID >= zombies.Length)
                selectedZombieID = 0;
            SelectZombie(selectedZombieID);
            Debug.Log("selected next zombie");
        }

        if (previous.WasPressedThisFrame())
        {
            selectedZombieID--;
            if (selectedZombieID < 0)
                selectedZombieID = zombies.Length - 1;
            SelectZombie(selectedZombieID);
            Debug.Log("selected previous zombie");
        }

        if (push.WasPressedThisFrame())
        {
            rb = selectedZombie.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddForce(pushForce, ForceMode.Impulse);
            Debug.Log("pushed");
        }
    }

    private void SelectZombie(int id)
    {
        selectedZombieID = id;
        if (selectedZombie != null)
            selectedZombie.transform.localScale = Vector3.one;
        selectedZombie = zombies[id];
        selectedZombie.transform.localScale = selectedScale;
        Debug.Log("selected: " + selectedZombie.name);
    }
}
