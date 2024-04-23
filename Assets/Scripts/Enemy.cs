using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 6f;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    
        if(this.transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
