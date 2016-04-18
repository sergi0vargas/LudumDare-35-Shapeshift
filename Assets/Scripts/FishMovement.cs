using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour {

    float maxSpeed = 2, minSpeed = 6, speed;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.left * speed * Time.deltaTime);
	}
}
