using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballReset : MonoBehaviour {

    //public Vector3 origin = new Vector3(0,0,0);
    public Vector3 origin;

    // Use this for initializationint
    void Start () {
        //gameObject.transform.Translate(origin);
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        float z = gameObject.transform.position.z;

        origin = new Vector3(x, y, z);
    }
	
	// Update is called once per frame
	void Update () {

        float x = Mathf.Abs(gameObject.transform.position.x);
        float y = Mathf.Abs(gameObject.transform.position.y);
        float z = gameObject.transform.position.z;

        //print(x + "   " + y + "   " + z);

        if (x > 0.35 || y >  0.23 || z < -0.24 || z > 0.11 )
        {
            gameObject.transform.position = origin;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
	}
}
