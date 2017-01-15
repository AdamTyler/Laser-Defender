using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float health = 150f;
    public GameObject projectile;
    public float projectileSpeed = 1f;
    public float fireFreq = 0.6f;
    public int scoreValue = 120;

    private Score scoreKeeper;

    void Start() {
        scoreKeeper = GameObject.Find("Score").GetComponent<Score>();
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        Projectile missle = col.gameObject.GetComponent<Projectile> ();

        if (missle) {
            missle.Hit();
            health -= missle.getDamage ();
            if (health <= 0) {
                Debug.Log("DEAD");
                Destroy (gameObject);
                scoreKeeper.ScorePoints(scoreValue);
            }
            Debug.Log ("HIT FOR " + missle.getDamage());
        }

    }

    void Fire ()
    {
        GameObject beam = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D rbeam = beam.GetComponent<Rigidbody2D> ();
        rbeam.velocity = new Vector3(0, -projectileSpeed, 0);
    }
    
    // Update is called once per frame
    void Update ()
    {
        float propability = Time.deltaTime * fireFreq;
        if (Random.value < propability) {
            Fire ();
        }
    }
}
