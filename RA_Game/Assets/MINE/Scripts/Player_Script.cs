using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public int Score_Value;
    [HideInInspector]public int Single_Coin_Value;

    private Ray Rayinfo;
    private RaycastHit Hitinfo;
    public LayerMask FloorMask, ObjectMask;
    private float timeOffset = 0.0f;
    private GameObject TempObject;
    //UI
    public Text Score_Text;

    private RecipienteScript Recipient;
    void Start()
    {
        Single_Coin_Value = 1;
        Recipient = GameObject.Find("Recipient").GetComponent<RecipienteScript>();
    }

// Update is called once per frame
void Update()
    {
        Score_Text.text = "Score: " + Score_Value;

        if (TempObject != null)
        {
            timeOffset += Time.deltaTime;

            if (timeOffset >= 0.3f)
            {
               if (!TempObject.GetComponent<ParticleSystem>().isPlaying)
                    Destroy(TempObject);
               else
                    TempObject.GetComponent<MeshRenderer>().forceRenderingOff = true;
                          
                timeOffset = 0.0f;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            TempObject = GetObjectToRay(Hitinfo, ObjectMask);
            
            if(TempObject != null)
            {
                TempObject.GetComponent<ParticleSystem>().Play();
                Score_Value += Single_Coin_Value;
                Recipient.CleanCoinsList();
            }
        }
    }

        private Vector3 GetPointToRay(RaycastHit Hit, LayerMask TempMask)
    {
        Rayinfo = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(Rayinfo, out Hit, Mathf.Infinity, TempMask))
        {
            return Hit.point;
        }

        return Vector3.zero;
    }

    private GameObject GetObjectToRay(RaycastHit Hit, LayerMask TempMask)
    {
        Rayinfo = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(Rayinfo, out Hit, Mathf.Infinity, TempMask))
        {
            return Hit.collider.gameObject;
        }

        return null;
    }
}
