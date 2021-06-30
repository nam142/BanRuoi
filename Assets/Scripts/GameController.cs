using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Tao ra enemy o vi tri ngau nhien
//Tang diem so khi nguoi choi ban chet enemy
//Kiem tra xem tro choi da ket thuc hay chua(enemy va cham voi DeathZone), neu ket thuc thi dung game
public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;

    float m_spawnTime;
    int m_score;
    bool m_isGameover;
    UiManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UiManager>();
        m_ui.SetScoreText("Score: " + m_score);
    }

    public void SpawnEnemy()
    {
        float ranXpos = Random.Range(-7.23f, 7.39f);
        Vector2 spawnPos = new Vector2(ranXpos, 7);

        if (enemy)
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameover)
        {
            spawnTime = 0;
            m_ui.ShowGameoverPanel(true);
            return;
        }

        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime <= 0)
        {
            SpawnEnemy();
            m_spawnTime = spawnTime;
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void Score(int value)
    {
        m_score = value;
    }
    public int GetScore()
    {
        return m_score;
    }
    public void ScoreIncrement()
    {
        if (m_isGameover)
        {
            return;
        }
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
    }
    public void SetGameoverState(bool state)
    {
        m_isGameover = state;
    }
    public bool IsGameover()
    {
        return m_isGameover;
    }
}
