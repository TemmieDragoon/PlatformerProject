using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q) && transform.localScale.x > 0)
        {
            transform.localScale -= new Vector3(0.1F, 0, 0);
            transform.position -= new Vector3(0.208F, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.E) && transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(0.1F, 0, 0);
            transform.position += new Vector3(0.208F, 0, 0);
        }

	}
}
