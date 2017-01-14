using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    public float width = 10f;
    public float height = 5f;

    string dir = "left";

    public float speed = 5.0f;
    public float padding;

    float xMin;
    float xMax;

	// Use this for initialization
	void Start ()
    {
        padding = width / 2;
        float zDist = transform.position.z - Camera.main.transform.position.z;
        xMin = Camera.main.ViewportToWorldPoint (new Vector3(0,0,zDist)).x + padding;
        xMax = Camera.main.ViewportToWorldPoint (new Vector3(1,0,zDist)).x - padding;

        speed = width/ 10;

        foreach (Transform child in transform) {

            GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
        
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (dir == "left") {
            transform.position += Vector3.left * speed * Time.deltaTime;
        } else {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if(transform.position.x >= xMax) {
            dir = "left";
        } else if (transform.position.x <= xMin) {
            dir = "right";
        }
	
	}

    void OnDrawGizmos ()
    {
        Gizmos.DrawWireCube (transform.position, new Vector3(width, height));
    }
}
