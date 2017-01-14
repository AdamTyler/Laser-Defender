using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 15.0f;
    public float padding;

    float xMin;
    float xMax;

	// Use this for initialization
	void Start () {
        padding = this.GetComponent<Renderer>().bounds.size.x / 2;
        float zDist = transform.position.z - Camera.main.transform.position.z;
        xMin = Camera.main.ViewportToWorldPoint (new Vector3(0,0,zDist)).x + padding;
        xMax = Camera.main.ViewportToWorldPoint (new Vector3(1,0,zDist)).x - padding;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey (KeyCode.LeftArrow)) {

            transform.position += Vector3.left * speed * Time.deltaTime;

        } else if (Input.GetKey (KeyCode.RightArrow)) {

            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float newX = Mathf.Clamp (transform.position.x, xMin, xMax);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	
	}
}
