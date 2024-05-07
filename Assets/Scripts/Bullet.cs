using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 12f;
    [SerializeField]
    private GameObject powerUpPrefab;

    void Start()
    {
        Destroy(this.gameObject, 0.5f);
    }

    void Update()
    {
        this.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Enemy")
        {
            AudioManager.instance.Play(AudioManager.instance.explosion2);
            GameManager.instance.AddScore(10);

            int randomNumber = Random.Range(1, 11);
            if(randomNumber > 6)
            {
                Instantiate(
                    powerUpPrefab, 
                    other.transform.position,
                    other.transform.rotation
                );
            }

            Destroy(other);
            Destroy(this.gameObject);
        }
    }

    /*
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }*/
}
