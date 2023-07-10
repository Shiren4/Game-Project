using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{ 
    public int killCountToPause = 25;
    void Update()
    {
        if (PlayerStats.Instance.killCount >= killCountToPause)
        {
            int finalScore = (int) (PlayerStats.Instance.score * 100 * (1 / Time.timeSinceLevelLoad));
            PlayerPrefs.SetInt("Player Score", finalScore);
            SceneManager.LoadScene(2);
        }
    }
}