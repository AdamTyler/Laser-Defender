using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 15.0f;
    public float padding;
    public GameObject projectile;
    public float projectileSpeed;
    public float fireRate = 0.5f;
    public float health = 250f;

    public AudioClip fireSound;
    public AudioClip deadSound;

    float xMin;
    float xMax;

	// Use this for initialization
	void Start () {
        padding = this.GetComponent<Renderer>().bounds.size.x / 2;
        float zDist = transform.position.z - Camera.main.transform.position.z;
        xMin = Camera.main.ViewportToWorldPoint (new Vector3(0,0,zDist)).x + padding;
        xMax = Camera.main.ViewportToWorldPoint (new Vector3(1,0,zDist)).x - padding;
	}

    void Fire ()
    {
        // Create shot
        GameObject beam = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D rbeam = beam.GetComponent<Rigidbody2D> ();
        rbeam.velocity = new Vector3(0, projectileSpeed, 0);
        // Play sound
        AudioSource.PlayClipAtPoint (fireSound, transform.position);
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown (KeyCode.Space)) {
            InvokeRepeating ("Fire", 0.000001f, fireRate);
        }

        if (Input.GetKeyUp (KeyCode.Space)) {
            CancelInvoke ("Fire");
        } 

        if (Input.GetKey (KeyCode.LeftArrow)) {

            transform.position += Vector3.left * speed * Time.deltaTime;

        } else if (Input.GetKey (KeyCode.RightArrow)) {

            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float newX = Mathf.Clamp (transform.position.x, xMin, xMax);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        Projectile missle = col.gameObject.GetComponent<Projectile> ();

        if (missle) {
            missle.Hit();
            health -= missle.getDamage ();
            if (health <= 0) {
                Debug.Log("DEAD");
                AudioSource.PlayClipAtPoint (deadSound, transform.position);
                Destroy (gameObject);
            }
            Debug.Log ("HIT FOR " + missle.getDamage());
        }

    }
}
