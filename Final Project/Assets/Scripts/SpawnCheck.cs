using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCheck : MonoBehaviour
{
    //PREVENTS OBSTACLES FROM BEING SPAWNED ON TOP OF THINGS
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacles")
        {
            Destroy(other.gameObject);
        }
    }
}
