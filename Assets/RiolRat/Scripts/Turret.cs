using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject ShootSpawnpoint;
    public GameObject ProjectilePrefab;

    public float ProjectileSpeed;
    public float ShootRate;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(Shoot());
        //dus je kan kiezen welke sprite je afschiet, en om de hoeveel tijd er een wordt afgeschoten
        //    turret.looktowards, ook zo een optie om de gun heel de tijd naar de player te laten rotaten
        //    en vector.moveotwards. ge hebt nu zo een spawnpoint voor het projectile, ook een eindpunt, en daar naar toe laten gaan
        //    je kan de firerate kiezen
    }

    //IEnumerator Shoot()
    //{
    //    //yield return new WaitForSeconds(ShootRate);
    //    //Instantiate(ProjectilePrefab, ShootSpawnpoint.transform.position, ShootSpawnpoint.transform.rotation)
    //}
}
