using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private float health = 150f;

    void OnTriggerEnter2D (Collider2D col)
    {
        Projectile missle = col.gameObject.GetComponent<Projectile> ();

        if (missle) {
            missle.Hit();
            health -= missle.getDamage ();
            if (health <= 0) {
                Debug.Log("DEAD");
                Destroy (gameObject);
            }
            Debug.Log ("HIT FOR " + missle.getDamage());
        }

    }
}
