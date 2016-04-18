using UnityEngine;
using System.Collections;

public class FishController : MonoBehaviour
{

    Transform bossPosition;

    void Start()
    {
        bossPosition = GameObject.FindGameObjectWithTag("Boss").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(bossPosition!= null)
            other.gameObject.transform.position = bossPosition.position;
    }
}
