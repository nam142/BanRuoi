using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Hien thi diem so nguoi choi
//Khi nguoi choi chet
public class UiManager : MonoBehaviour
{
    public Text scoreText;

    public GameObject gameoverPanel;

    public void SetScoreText(string txt)
    {
        if (scoreText)
        {
            scoreText.text = txt; 
        }
    }
    public void ShowGameoverPanel(bool isShow)
    {
        if (gameoverPanel)
        {
            gameoverPanel.SetActive(isShow);
        }
    }
}
