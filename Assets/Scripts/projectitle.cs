using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectitle : MonoBehaviour
{
    AudioSource aus;
    public AudioClip hitSSound;
     GameController m_gc;
    public float speed;    
    Rigidbody2D m_rb;
    public GameObject hitVFX;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        m_rb = GetComponent<Rigidbody2D>();       
        aus = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.up * speed;
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            m_gc.ScoreIncrement();
            if (aus && hitSSound)
            {
                aus.PlayOneShot(hitSSound);
            }
            if (hitVFX)
            {
                Instantiate(hitVFX, col.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("SceneTitle"))
        {
            Destroy(gameObject);
        }
    }

}
