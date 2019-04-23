using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    private float speed = 60f;
    public GameObject[] points;
    public Transform enemy;
    public Transform wayPointA;
    public Transform wayPointB;

    private Rigidbody2D rb;

    //private double attack = 2;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();

        Debug.Log("Systems online");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Vector2.Distance(wayPointA.transform.position, this.transform.position) >= 0f)
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime, 0);
        }
        else if(Vector2.Distance(wayPointA.transform.position, this.transform.position) == 0f)
        {
            rb.velocity = new Vector2(-speed * 0 * Time.deltaTime, 0);
        }

        if(Vector2.Distance(wayPointB.transform.position, this.transform.position) >= 8.9f)
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, 0);
        }
        else if (Vector2.Distance(wayPointB.transform.position, this.transform.position) == 8.9f)
        {
            rb.velocity = new Vector2(speed * 0 * Time.deltaTime, 0);
        }



    }

}
