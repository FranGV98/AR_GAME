using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingScript : MonoBehaviour
{
    public int Price;
    public string Name;
    public int Level;

    public Text Build_info;
    private Player_Script player;
    public GameObject Building;
    public GameObject Placer;
    void Start()
    {
        player = GameObject.Find("ARCamera").GetComponent<Player_Script>();
    }

    void Update()
    {
        Build_info.text = (Name + "  Lvl: " + Level + " Price: " + Price);
    }

    public void OnBuyBuilding()
    {
        if(player.Score_Value >= Price)
        {
            Building.SetActive(true);
            Placer.SetActive(false);
            player.Score_Value -= Price;
        }
    }
}
