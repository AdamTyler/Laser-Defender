using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private float damage = 100f;


    public float getDamage ()
    {
        return damage;
    }

    public void Hit ()
    {
        Destroy (gameObject);
    }
}
