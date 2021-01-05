using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabrication : MonoBehaviour
{
    private Transform fabricationTransform;
    private Rigidbody2D fabricationRigid2D;
    private BoxCollider2D fabricationBoxCollider2D;

    private int SpawnCount = 0;
    private bool canSpawn = false;
    private float fabricationHP = 100.0f;

    public GameObject fabricationSpawnedRumor;

    // Start is called before the first frame update
    void Start()
    {
        fabricationTransform = GetComponent<Transform>();
        fabricationRigid2D = GetComponent<Rigidbody2D>();
        fabricationBoxCollider2D = GetComponent<BoxCollider2D>();

        fabricationTransform.localScale = new Vector3(2,2,2);
        fabricationBoxCollider2D.size = new Vector2(4.0f,6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpawn == true && SpawnCount <= 2)
        {
            StartCoroutine(SpawnRumorDelay());
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canSpawn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canSpawn = false;
        }
    }
    IEnumerator SpawnRumorDelay()
    {
        canSpawn = false;
        GameObject spawningRumor = Instantiate(fabricationSpawnedRumor,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        SpawnCount ++;
        canSpawn = true;
    }
}
