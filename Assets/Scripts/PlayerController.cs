using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float playerSpeed = 5;
    public float fuerzaEmpujon = 5;
    public float actualSize = 1;
    public int fishesEaten = 0;
    public Vector3 lastCheckPoint, initialPoint;

    public Sprite actualSprite;

	void Start () {

        initialPoint = transform.position;
        lastCheckPoint = transform.position;
	}
	
	void Update () {

        //Movimiento Horizontal
        transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);

        //Input
        if (DetectInput())
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzaEmpujon * Time.deltaTime);
	}

    bool DetectInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            return true;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            return true;
        if (Input.GetMouseButtonDown(0))
            return true;
        if (Input.GetTouch(0).phase == TouchPhase.Began)
            return true;

        return false;
    }

    void ResetAll()
    {
        Debug.Log("Toco el nivel");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Level"))
            ResetAll();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("CheckPoint"))
        {

        }
    }
}
