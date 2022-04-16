using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float destroyDelay = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", destroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
