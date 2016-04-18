using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float playerSpeed = 1.2f;
    public float fuerzaEmpujon = 50;
    public int actualSize = 0;
    public int fishesEaten = 0;
    public Vector3 lastCheckPoint, initialPoint;

    public Text textLevel, textFishesEaten;
    public Toggle toggleCanShoot;

    public Transform bullet;
    bool canShoot = false;
    Animator anim;

	void Start () {

        initialPoint = transform.position;
        lastCheckPoint = transform.position;
        anim = GetComponent<Animator>();
    }
	
	void Update ()
    {
        float direccion = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * fuerzaEmpujon * direccion*0.1f);
        if (direccion > 0)
            GetComponent<SpriteRenderer>().flipX = false;
        if (direccion < 0 && transform.localScale.x > 0)
            GetComponent<SpriteRenderer>().flipX = true;
        if (DetectUpInput())
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzaEmpujon);

        anim.SetInteger("nivel", actualSize);
        CheckLevel();

        textLevel.text = "Level:" + actualSize;
        textFishesEaten.text = "Fishes Eaten:" + fishesEaten;

        if (canShoot)
        {
            toggleCanShoot.isOn = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bullet, transform.position, transform.rotation);
            }
        }
        else
        {
            toggleCanShoot.isOn = false;
        }

	}

    void CheckLevel()
    {
        if(fishesEaten >= 10)
        {
            actualSize = 5;
            canShoot = true;
        }
        else if (fishesEaten >= 8)
        {
            actualSize = 4;
            canShoot = true;
        }
        else if (fishesEaten >= 6)
        {
            actualSize = 3;
            canShoot = true;
        }
        else if (fishesEaten >= 4)
        {
            actualSize = 2;
            canShoot = false;
        }
        else if (fishesEaten >= 2)
        {
            actualSize = 1;
            canShoot = false;
        }
        else if (fishesEaten >= 0)
        {
            actualSize = 0;
            canShoot = false;
        }
    }

    bool DetectUpInput()
    {
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
        }
        if (other.gameObject.tag.Equals("GoodFish"))
        {
            if(fishesEaten> 0)
                fishesEaten--;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("BadFish"))
        {
            fishesEaten+=2;
            Destroy(other.gameObject);
        }
    }
}
