using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private GameObject bulletPrefab;
    // Cooldown system
    [SerializeField]
    private float fireRate = 0.3f;
    private float nextFire = 0f;

    private const float SCREEN_BOUNDS_X = 7.9f;
    private const float SCREEN_BOUNDS_Y = 4.2f;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
        CheckScreenBounds();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Vector3 position = new Vector3(
                this.transform.position.x, 
                this.transform.position.y + 0.6f,
                this.transform.position.z);

            Instantiate(bulletPrefab, position, this.transform.rotation);
        }
    }

    private void CheckScreenBounds()
    {
        // Check Horinzontal

        if (this.transform.position.x > SCREEN_BOUNDS_X)
        {
            this.transform.position = new Vector3(SCREEN_BOUNDS_X, this.transform.position.y, 0f);
        }

        if(this.transform.position.x < -SCREEN_BOUNDS_X)
        {
            this.transform.position = new Vector3(-SCREEN_BOUNDS_X, this.transform.position.y, 0f);
        }

        // Check Vertical

        // limite superior
        if(this.transform.position.y > SCREEN_BOUNDS_Y)
        {
            this.transform.position = new Vector3(this.transform.position.x, SCREEN_BOUNDS_Y, 0f);
        }

        // limite inferior
        if(this.transform.position.y < -SCREEN_BOUNDS_Y){
            this.transform.position = new Vector3(this.transform.position.x, -SCREEN_BOUNDS_Y, 0f);
        }
    }

    private void Move()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 position = new Vector3(inputHorizontal, inputVertical, 0f);

        this.transform.Translate(position * Time.deltaTime * speed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;

        if(other.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(other);
            GameManager.instance.GameOver();
        }
    }
}