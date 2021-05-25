using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager_Script : MonoBehaviour
{
    public GameObject UI_Panel;
    public bool Open;
    public Player_Script player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SlideUpPanel()
    {
        if(UI_Panel != null)
        {
            Animator animator = UI_Panel.GetComponent<Animator>();
            Open = animator.GetBool("Open");
            animator.SetBool("Open", !Open);
        }      
    }

    public void CreateBuild()
    {
        if(player.Score_Value <= 5)
        {

        }
    }
}
