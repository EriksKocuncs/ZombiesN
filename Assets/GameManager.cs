using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject selectedZombie;
    public GameObject[] zombies;
    
    void Start()
    {
        selectedZombie = zombies[0];
        Debug.Log("selected: " + selectedZombie.name);
    }
    
    void Update()
    {
        
    }
}
