using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCam : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
             // Camera.main.transform.position = target.transform.position - Vector3.forward; <-follow target
             Camera.main.transform.position = new Vector3(0,2,-10); // <- fix the position
        }
        else
        {
            return;
        }
    }
}
