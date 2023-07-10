using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI finalScoreText;
    void Start()
    {
        int score = PlayerPrefs.GetInt("Player Score");
        finalScoreText.text =string.Format("Score: {0}",score.ToString()) ;        
    }
}
