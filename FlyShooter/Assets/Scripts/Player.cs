using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    public Transform shootingPoint;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    private void MoveShipHorizontalDirection()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        if (IsOutOfScreen(xDir))
        {
            return;
        }
        transform.position = transform.position + Vector3.right * moveSpeed * xDir * Time.deltaTime;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy(gameObject, 0.2f);
        }
    }
}
