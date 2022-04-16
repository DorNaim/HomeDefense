using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMissileBehaviour : MonoBehaviour
{
    public float speed = 8f;
    public bool flying=true;
    public bool active = true;

    public float timeToLive = 15f;
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
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Construct a ray from the current touch coordinates
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
     
            if (Physics.Raycast(ray,out hit))
            {
                Debug.Log("Collidier" + hit.collider.name);
                if (hit.collider.gameObject == gameObject)
                {
                    onTouched();
                }
            }
        }

    }

    private void OnMouseDown()
    {
        onTouched();
    }

    private void onTouched()
    {
        Debug.Log("Pressed on missile");
        if (active)
        {
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
