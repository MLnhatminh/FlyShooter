using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject hitVFX;

    public AudioSource aus;

    public AudioClip deathSound;

    Animator m_animator;

    GameController m_gameController;

    public float bulletSpeed;

    public float timeToDestroy;

    Rigidbody2D m_rigid;

    // Start is called before the first frame update
    void Start()
    {
        m_rigid = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeToDestroy);
        m_gameController = FindObjectOfType<GameController>();
        m_animator = FindObjectOfType<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        m_rigid.velocity = Vector2.up * bulletSpeed;
    }

    GameObject NewHitVFXInstance(Vector3 position)
    {
        GameObject hitVFXInstance = Instantiate(hitVFX, position, Quaternion.identity);
        return hitVFXInstance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (aus && deathSound) 
            {
                aus.PlayOneShot(deathSound);
            }

            if (hitVFX)
            {
                GameObject hit = NewHitVFXInstance(collision.transform.position);
                Destroy(hit, 0.2f);
            }
            //m_animator.SetTrigger("Destroy");
            Destroy(collision.gameObject, 0.1f);
            Destroy(gameObject, 0.05f);
            m_gameController.ScoreIncrement();
        }
    }
}
