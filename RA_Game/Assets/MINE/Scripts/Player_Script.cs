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
    public ParticleSystem coinEffect;
    //UI
    public Text Score_Text;

    private RecipienteScript Recipient;

                                            
    void PlayFx(GameObject tempObject)
    {
        coinEffect.transform.position = tempObject.transform.position;
        
        ParticleSystem particleEffect = Instantiate(coinEffect) as ParticleSystem;

        particleEffect.Play();

        Destroy(particleEffect.gameObject, particleEffect.duration);       
    }

    void Start()
    {
        Single_Coin_Value = 1;
        Recipient = GameObject.Find("Recipient").GetComponent<RecipienteScript>();
    }

// Update is called once per frame
void Update()
    {
        Score_Text.text = "Score: " + Score_Value;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject tempObject = GetObjectToRay(Hitinfo, ObjectMask);
            
            if(tempObject != null)
            {
                PlayFx(tempObject);
                Destroy(tempObject, 0.15f);
                Score_Value += Single_Coin_Value;
                Recipient.CleanCoinsList();
            }
        }
        //if (Input.GetTouch(0).phase.Equals(TouchPhase.Began))
        //{
        //    GameObject tempObject = GetObjectToRay(Hitinfo, ObjectMask);

        //    if (tempObject != null)
        //    {
        //        PlayFx(tempObject);
        //        Score_Value += Single_Coin_Value;
        //        Recipient.CleanCoinsList();
        //    }
        //}

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
