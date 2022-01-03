using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webcam : MonoBehaviour {
    // Use this for initialization
    public GameObject webcamplane;

	void Start ()
    {
        /*if(Application.isMobilePlatform)
         {
             GameObject cameraparent = new GameObject("camparent");
            cameraparent.transform.position = this.transform.position;           
             this.transform.parent = cameraparent.transform;            
             cameraparent.transform.Rotate(Vector3.right, 90);
         }*/
        //Input.gyro.enabled = true;
        WebCamTexture webcamtexture=new WebCamTexture();       
        webcamplane.GetComponent<MeshRenderer>().material.mainTexture = webcamtexture;
        webcamtexture.Play();
        
    }

    // Update is called once per frame
    void Update () {
        //Quaternion camerarotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        //this.transform.localRotation = camerarotation;
       
    }
   
   
}
