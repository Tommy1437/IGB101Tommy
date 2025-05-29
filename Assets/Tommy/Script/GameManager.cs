using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;               
    public int currentPickups = 0;          
    public int maxPickups = 3;              
    public bool levelComplete = false;      

    public Text pickupCounter;             

    public AudioSource[] audioSources;      
    public float audioProximity = 10f;      

    void Update()
    {
        LevelCompleteCheck();               
        UpdateGUI();                        
        PlayAudioSamples();                 
    }

    
    void LevelCompleteCheck()
    {
        if (currentPickups >= maxPickups)
        {
            levelComplete = true;
        }
    }

    
    void UpdateGUI()
    {
        if (pickupCounter != null)
        {
            pickupCounter.text = "Pickups: " + currentPickups + "/" + maxPickups;
        }
    }

    
    void PlayAudioSamples()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            float distance = Vector3.Distance(player.transform.position, audioSources[i].transform.position);

            if (distance <= audioProximity)
            {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].Play();
                    Debug.Log("Playing audio from: " + audioSources[i].gameObject.name);
                }
            }
        }
    }
}
