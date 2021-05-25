using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    // Start is called before the first frame update
    private int Score_Value;

    private Ray Rayinfo;
    private RaycastHit Hitinfo;
    public LayerMask FloorMask, ObjectMask;

    //UI
    public Text Score_Text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score_Text.text = "Score: " + Score_Value;
        if (Input.GetMouseButtonDown(0))
        {
            GameObject TempObject = GetObjectToRay(Hitinfo, ObjectMask);
            
            if(TempObject != null)
            {
                Score_Value++;
                Destroy(TempObject);
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
