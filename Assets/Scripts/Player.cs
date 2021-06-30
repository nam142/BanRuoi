using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    public GameObject projectile;

    public Transform shootingPoint;

    GameController m_gc;

    public AudioSource aus;
    public AudioClip shootingSound;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.IsGameover())
        {
            return;
        }
        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");
        if ((xDir < 0 && transform.position.x <= -8.23) || (yDir < 0 && transform.position.y <= -3.5) || xDir > 0 && transform.position.x >= 6.69 || (yDir < 0 && transform.position.x >= 4))
            return;
        transform.position += Vector3.right * moveSpeed * xDir * Time.deltaTime;
        transform.position += Vector3.up * moveSpeed * yDir * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if(projectile && shootingPoint)
        {
            if(aus && shootingSound) 
            {
                aus.PlayOneShot(shootingSound);                  
            }
            Instantiate(projectile, shootingPoint.position, Quaternion.identity);
        }
    }
  
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            m_gc.SetGameoverState(true);
            Destroy(col.gameObject);
            Debug.Log("Da va cham");
        }
    }
}
