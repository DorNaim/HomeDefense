using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMissileBehaviour : MonoBehaviour
{
    public float speed = 5f;
    public bool flying=true;
    public bool active = true;

    public float timeToLive = 30f;
    public GameObject explosionPrefab;


    // Start is called before the first frame update
    void Start()
    {
        //set this one on MainPlaneBehaviour as it is global
        //Input.simulateMouseWithTouches = true;
        Invoke("DestroySelf", timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void FixedUpdate()
    {
        if (flying)
        {
            transform.position += speed * Time.deltaTime * transform.forward;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Pressed on missile");
        if (active) {
            active = false;
            flying = false;
            OnTouchedParticles();
            DestroySelf();
        }
    }

    private void OnTouchedParticles()
    {
        Instantiate<GameObject>(explosionPrefab, transform.position, new Quaternion(0, 0, 0, 0));
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }


}
