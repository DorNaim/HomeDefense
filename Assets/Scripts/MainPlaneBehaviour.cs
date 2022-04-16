using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlaneBehaviour : MonoBehaviour
{

    public Material materialLvl1;
    public Material materialLvl2;
    public Material materialLvl3;
    public Material materialLvl4;
    public Material materialLvl5;
    public Material materialLvl6;
    public Material materialLvl7;
    public Material materialLvl8;
    public Material materialLvl9;
    public Material materialLvl10;

    // Start is called before the first frame update
    void Start()
    {
        SetMaterialByWave(1);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void SetMaterialByWave(int level)
    {
        switch(level)
            {
            case 1:
                { 
                GetComponent<Renderer>().material = materialLvl1;
                break;
                }

            default:
                { 
                Debug.Log("default case! should never happen");
                break;
                }
        }
    }

}
