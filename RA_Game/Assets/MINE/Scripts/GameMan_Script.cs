using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan_Script : MonoBehaviour
{
    public float SpawnTimer;
    public float SpawnTime;
    public GameObject Cookie_Prefab;
    public GameObject obj_reference;

    public List<AudioClip> Coin_SFX;
    public Vector3 SpawnArea;

    void Start()
    {
        SpawnTimer = 0;
    }

    void Update()
    {
        if(obj_reference.GetComponent<MeshRenderer>().isVisible)
        {
            SpawnTimer += Time.deltaTime;
            if (SpawnTimer >= SpawnTime)
            {
                SpawnCookies();
                SpawnTimer = 0;
            }
        }
    }

    public void SpawnCookies()
    {
        Vector3 SpawnPoint = gameObject.transform.position + new Vector3(Random.Range(-SpawnArea.x / 2, SpawnArea.x / 2), Random.Range(-SpawnArea.y / 2, SpawnArea.y / 2), Random.Range(-SpawnArea.z / 2, SpawnArea.z / 2));
        GameObject newCookie = Instantiate(Cookie_Prefab, SpawnPoint, Quaternion.identity);
        newCookie.transform.parent = gameObject.transform;
        newCookie.GetComponent<Rigidbody>().AddTorque(new Vector3(50, 50, 50), ForceMode.Impulse);
        newCookie.GetComponent<AudioSource>().clip = Coin_SFX[Random.Range(0,2)];
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.5f, 0, 0.5f, 0.3f);
        Gizmos.DrawCube(gameObject.transform.position, SpawnArea);
    }
}
