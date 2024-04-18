using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField]
    private Text textTitle;
    [SerializeField]
    private Text textStartMessage;
    [SerializeField]
    private Text textScore;

    private void Awake()
    {
        instance = this;
    }

    public void ShowMenuUI()
    {
        textTitle.enabled = true;
        textStartMessage.enabled = true;
        textScore.enabled = false;
        UpdateScore(0);
    }

    public void ShowGameUI()
    {
        textTitle.enabled = false;
        textStartMessage.enabled = false;
        textScore.enabled = true;
    }

    public void UpdateScore(int score)
    {
        textScore.text = "Score: " + score.ToString();
    }
}
