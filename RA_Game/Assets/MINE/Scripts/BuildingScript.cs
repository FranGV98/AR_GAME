using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingScript : MonoBehaviour
{
    public int Base_Price;
    public int Price;
    public string Name;
    public string Description;
    public int Level;

    public Text Build_info;
    public Text Build_Description;
    private Player_Script player;
    public GameObject Building;

    public int Building_ID;
    public bool Functional;
    private float Timer, GetCoinTime;

    private RecipienteScript Recipient;
    
    void Start()
    {
        player = GameObject.Find("ARCamera(PLAYER)").GetComponent<Player_Script>();
        Recipient = GameObject.Find("Recipient").GetComponent<RecipienteScript>();
        Base_Price = Price;
        GetCoinTime = 1.0f;
    }

    void Update()
    {
        Build_info.text = (Name + "  Lvl: " + Level + " Price: " + Price);
        Build_Description.text = "Description:" + Description;

        if(Functional)
        {
            switch (Building_ID)
            {
                case 1:                             //TOWER
                    TowerBehaviour();
                    break;
                case 2:                             //TREASURY
                    TreasureBehaviour();
                    break;
                case 3:
                    UniversityBehaviour();          //UNIVERSITY
                    break;
                case 4:
                    ChurchBehaviour();              //CHURCH
                    break;
            }
        }       
    }

    public void OnBuyBuilding()
    {
        if(player.Score_Value >= Price)
        {
            Building.SetActive(true);
            player.Score_Value -= Price;
            Functional = true;
            Level++;
            Price =  (int)(Base_Price * Mathf.Pow(1.15f,Level));
        }
    }

    void TowerBehaviour()
    {
        Timer += Time.deltaTime;

        if (Timer >= GetCoinTime * (5.0f/(float)Level))
        {
            player.Score_Value++;
            Timer = 0;
        }
    }

    void UniversityBehaviour()
    {
        player.Single_Coin_Value = Level;
    }

    void TreasureBehaviour()
    {
        Timer += Time.deltaTime;

        if (Timer >= GetCoinTime * 5)
        {
            player.Score_Value = (int)(player.Score_Value * 1.05f);
            Timer = 0;
        }
    }

    void ChurchBehaviour()
    {
        Timer += Time.deltaTime;

        if (Timer >= GetCoinTime * (100.0f / (float)Level))
        {
            Recipient.RecolectCoins();
        }
    }
}
