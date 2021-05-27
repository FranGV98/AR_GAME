using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipienteScript : MonoBehaviour
{
    public List<GameObject> Coins_List;
    private Player_Script player;

    private void Start()
    {
        player = GameObject.Find("ARCamera(PLAYER)").GetComponent<Player_Script>();
    }
    public void CleanCoinsList()
    {
        for (int i = 0; i < (int)(Coins_List.Count); i++)
        {
            if (Coins_List[i] == null)
                Coins_List.Remove(Coins_List[i]);
        }
    }
    public void RecolectCoins()
    {
        player.Score_Value += (int)(Coins_List.Count * 0.7f * player.Single_Coin_Value);

        for (int i = 0; i < (int)(Coins_List.Count * 0.7f); i++)
        {
            Destroy(Coins_List[i]);
            Coins_List.Remove(Coins_List[i]);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Cookie")
        {
            Coins_List.Add(col.gameObject);
        }
    }


}
