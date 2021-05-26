using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GuarruScript : MonoBehaviour
{
    public AnchorInputListenerBehaviour anchorbehaviour;
    public GameObject Floor;
    void Start()
    {
       anchorbehaviour = gameObject.GetComponent<AnchorInputListenerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Floor.gameObject.GetComponent<MeshRenderer>().enabled == true)
        {
            anchorbehaviour.enabled = false;
        }
        else
        {
            anchorbehaviour.enabled = true;
        }
    }
}
