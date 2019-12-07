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
            Camera.main.transform.position = target.transform.position - Vector3.forward;
        }
        else
        {
            return;
        }
    }
}
