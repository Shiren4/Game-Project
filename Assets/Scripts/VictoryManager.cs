using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryManager : MonoBehaviour
{ 
    public int killCountToPause = 100;

    void Update()
    {
        if (PlayerStats.Instance.killCount >= killCountToPause)
        {            
            PlayerPrefs.SetInt("Player Score", PlayerStats.Instance.score);

            SceneManager.LoadScene(2);
        }
    }
}