using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnThePlatform : MonoBehaviour
{
    void Start()
    {
        BoxCollider hiddenBoxCollider = this.gameObject.AddComponent<BoxCollider>();
        hiddenBoxCollider.isTrigger = true;
        hiddenBoxCollider.center = new Vector3(0.0f, 0.3f, 0.0f);
        hiddenBoxCollider.size = new Vector3(0.8f, 1, 1);
    }


    private void OnTriggerEnter(Collider other) {
        
        if(other.transform.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        
        if(other.transform.tag == "Player")
        {
            other.transform.parent = null;
        }
    }



}
