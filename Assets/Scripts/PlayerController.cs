using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float playerSpeed = 2;
    public float fuerzaEmpujon = 80;
    public int actualSize = 0;
    public int fishesEaten = 0;
    public Vector3 lastCheckPoint, initialPoint;

    bool lateralMovement = false;
    Animator anim;

	void Start () {

        initialPoint = transform.position;
        lastCheckPoint = transform.position;
        anim = GetComponent<Animator>();
    }
	
	void Update () {

        //Movimiento Horizontal
        if (!lateralMovement)
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        else
        {
            float direccion = Input.GetAxis("Horizontal");
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * fuerzaEmpujon * direccion*0.1f);
            if (direccion > 0)
                GetComponent<SpriteRenderer>().flipX = false;
            if (direccion < 0 && transform.localScale.x > 0)
                GetComponent<SpriteRenderer>().flipX = true;
        }

        //Input
        if (DetectUpInput())
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzaEmpujon);

        anim.SetInteger("nivel", actualSize);
        CheckLevel();

	}

    void CheckLevel()
    {
        switch (fishesEaten)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            default:
                break;
        }
    }

    bool DetectUpInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            return true;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            return true;
        if (Input.GetMouseButtonDown(0))
            return true;
        if (Input.touchCount > 0)
            if (Input.GetTouch(1).phase == TouchPhase.Began)
                return true;

        return false;
    }

    void ResetLastPoint()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        GetComponent<Rigidbody2D>().rotation = 0;
        transform.position = lastCheckPoint;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void ResetAll()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        GetComponent<Rigidbody2D>().rotation = 0;
        fishesEaten = 0;
        actualSize = 1;
        transform.position = initialPoint;
        transform.rotation = Quaternion.Euler(0,0,0);
        lateralMovement = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Level"))
            ResetLastPoint();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("CheckPoint"))
        {
            lastCheckPoint = transform.position;
            if(other.gameObject.name.Equals("CheckPointFinal"))
                lateralMovement = true;
        }
    }
}
