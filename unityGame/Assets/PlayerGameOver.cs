using UnityEngine;

public class PlayerGameOver : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        //TODO LR: implement 'Game Over' screen
        Application.Quit();
    }
}
