using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GuarruScript : MonoBehaviour
{
    public AnchorInputListenerBehaviour anchorbehaviour;
    public GameObject Floor;
    public Text Unlock;
    public bool unlockTerrain;
    void Start()
    {
       anchorbehaviour = gameObject.GetComponent<AnchorInputListenerBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
        if(unlockTerrain)
        {
            anchorbehaviour.enabled = true;
            Unlock.text = "Lock";
        }
        else if (Floor.gameObject.GetComponent<MeshRenderer>().enabled == true)
        {
            anchorbehaviour.enabled = false;
            if (!unlockTerrain)
            {
                Unlock.text = "Unlock";
            }
        }
    }

    public void SwapUnlockTerrain()
    {
        unlockTerrain = !unlockTerrain;
    }
}
