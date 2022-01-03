using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
   

    // Update is called once per frame
    void Update ()
    {
        gameObject.transform.position -= new Vector3(0f, 0f, 0.2f);
        if (gameObject.transform.position.z <= -5)
            Destroy(gameObject);
    }


}
