using UnityEngine;
using System.Collections;

public class PezBalaScript : MonoBehaviour
{

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipX)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<ConstantForce2D>().force *= -1;
        }
        else{
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(this.gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("GoodFish"))
            Destroy(other.gameObject);
        if (other.gameObject.tag.Equals("Boss"))
        {
            if (other.gameObject.GetComponent<Boss>().numberOfShots > 3)
                Destroy(other.gameObject);
            else
                other.gameObject.GetComponent<Boss>().numberOfShots++;
        }
    }
}
