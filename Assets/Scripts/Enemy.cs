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
    }
}
