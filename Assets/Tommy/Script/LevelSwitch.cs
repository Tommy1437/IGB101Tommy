using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    public string nextLevel;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.CompareTag("Player") && gameManager.levelComplete)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
