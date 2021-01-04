using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabrication : MonoBehaviour
{
    private Transform fabricationTransform;
    private Rigidbody2D fabricationRigid2D;
    private int SpawnCount = 0;
    private float fabricationHP = 100.0f;


    // Start is called before the first frame update
    void Start()
    {
        fabricationTransform = GetComponent<Transform>();
        fabricationRigid2D = GetComponent<Rigidbody2D>();

        fabricationTransform.localScale = new Vector3(2,2,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRumor()
    {
        if(SpawnCount < 4)
        {
            // spawn Rumor
            SpawnCount +=1;
        }
    }
}
