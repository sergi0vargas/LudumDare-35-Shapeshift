using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform player;
    public float camSpeed = 5;
    Vector3 temp;

	// Use this for initialization
	void Start () {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent("Transform") as Transform;
        temp = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {

        temp = new Vector3(player.position.x, player.position.y, this.transform.position.z);

        transform.position = Vector3.Slerp(transform.position, temp, camSpeed * Time.deltaTime);
	}
}
