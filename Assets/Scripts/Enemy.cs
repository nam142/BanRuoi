using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float acceleration;
    public float moveSpeed;
    Rigidbody2D m_rb;
    GameController m_gc;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreaseSpeed", 10f, 10f);
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.down * moveSpeed;
        
    }
    public void IncreaseSpeed()
    {
        moveSpeed += acceleration;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeathZone"))
        {

            m_gc.SetGameoverState(true);
            Destroy(gameObject);

            
            Debug.Log("Game over");
        }
        
    }
}
