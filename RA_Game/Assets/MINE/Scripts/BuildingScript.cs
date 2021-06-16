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
    private GameMan_Script manager;
    public GameObject Building;
    public GameObject Placer;
    public Button Building_Button;
    public Text Buy_text;

    public int Building_ID;
    public bool Functional;
    private float Timer, GetCoinTime;
    public GameObject Coin_Prefab, coin_spawnpoint;
    public List<GameObject> Building_evolutions;
    public AudioSource Audio_Emitter;
    public AudioClip SFX_build, SFX_upgrade;

    private RecipienteScript Recipient;
    
    void Start()
    {
        player = GameObject.Find("ARCamera(PLAYER)").GetComponent<Player_Script>();
        manager = GameObject.Find("CoinSpawner").GetComponent<GameMan_Script>();
        Recipient = GameObject.Find("Recipient").GetComponent<RecipienteScript>();
        Audio_Emitter = gameObject.GetComponent<AudioSource>();
        Audio_Emitter.clip = SFX_build;
        Base_Price = Price;
        GetCoinTime = 1.0f;
    }

    void Update()
    {
        Build_info.text = (Name + " - Lvl: " + Level + "    Price: " + Price);
        Build_Description.text = Description;

        if (player.Score_Value <= Price)
        {
            Building_Button.GetComponent<Image>().color = new Vector4(0.5f, 0.5f, 0.5f, 0.5f);
        }
        else
        {
            Building_Button.GetComponent<Image>().color = new Vector4(1, 0.7f, 0.15f, 1);
        }




        if (Functional)
        {
            switch (Building_ID)
            {
                case 1:                             //TOWER
                    TowerBehaviour();
                    break;
                case 2:                             //TREASURY
                    TreasureBehaviour();
                    break;     
                case 4:
                    ChurchBehaviour();              //CHURCH
                    break;
                case 3:
                    UniversityBehaviour();          //UNIVERSITY
                    break;
            }
        }       
    }

    public void OnBuyBuilding()
    {
        if(player.Score_Value >= Price)
        {
            Audio_Emitter.Play();
            Building.SetActive(true);
            Placer.SetActive(false);
            player.Score_Value -= Price;
            Functional = true;
            Level++;
            Price =  (int)(Base_Price * Mathf.Pow(1.15f,Level));

            if (Level == 2)
            {
                Buy_text.text = "Upgrade";
                Audio_Emitter.clip = SFX_upgrade;
            }

            switch (Level)
            {
                case 4:
                    Building_evolutions[0].SetActive(false);
                    Building_evolutions[1].SetActive(true);
                    break;

                case 8:
                    Building_evolutions[1].SetActive(false);
                    Building_evolutions[2].SetActive(true);
                    break;
            }
        }
    }

    void TowerBehaviour()
    {
        Timer += Time.deltaTime;

        if (Timer >= GetCoinTime * (5.0f/(float)Level))
        {
            player.Score_Value++;
            Building.GetComponent<Animator>().SetTrigger("coin");
            Building.GetComponent<Animator>().SetFloat("speed", Level/2);
            GameObject newCookie = Instantiate(Coin_Prefab, coin_spawnpoint.transform.position, Quaternion.identity);
            newCookie.transform.parent = Building.transform;
            Destroy(newCookie, 1f);
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
            player.Score_Value = (int)(player.Score_Value * (1.0f + 0.01f*Level));
            Timer = 0;
        }
    }

    void ChurchBehaviour()
    {
        Timer += Time.deltaTime;

        if (Timer >= (GetCoinTime * (10.0f / (float)Level)))
        {
            Recipient.RecolectCoins();
            Timer = 0;
        }
        //manager.SpawnTime = (2f / (float)Level /2f);
    }
}
