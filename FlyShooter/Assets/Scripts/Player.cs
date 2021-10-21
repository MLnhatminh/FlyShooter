using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public AudioSource aus;

    public AudioClip shootingSound;

    Animator m_animator;

    GameController m_gameController;

    public float moveSpeed;

    public Transform shootingPoint;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        m_gameController = FindObjectOfType<GameController>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveShipHorizontalDirection();
        //// Debug.Log(shootingPoint.position);
        if (SpaceButtonTap())
        {
            Shoot();
        }
        AnimatePlayer();
    }

    private void AnimatePlayer()
    {
        float xDir = GetDirection();
        if (xDir < 0)
        {
            // Turn left
            m_animator.SetBool("TurnLeft", true);
        }
        else if (xDir > 0)
        {
            // Turn right
            m_animator.SetBool("TurnRight", true);
        }
        else 
        {
            m_animator.SetBool("TurnLeft", false);
            m_animator.SetBool("TurnRight", false);
        }
    }

    private void MoveShipHorizontalDirection()
    {
        float xDir = GetDirection();
        if (IsOutOfScreen(xDir))
        {
            return;
        }
        transform.position = transform.position + Vector3.right * moveSpeed * xDir * Time.deltaTime;
    }

    private float GetDirection()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        return xDir;
    }

    private bool IsOutOfScreen(float xDir)
    {
        if ((xDir < 0 && transform.position.x <= -8.4) || (xDir > 0 && transform.position.x > 8.4))
        {
            return true;
        }
        return false;
    }

    public void Shoot()
    {
        if (projectile && shootingPoint)
        {
            if (aus && shootingSound)
            {
                aus.PlayOneShot(shootingSound);
            }
            Instantiate(projectile, shootingPoint.position, Quaternion.identity);
        }
    }

    private bool SpaceButtonTap()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject, 0.2f);
            m_gameController.SetGameOverState(true);
        }
    }
}
