using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turret : MonoBehaviour
{
    public GameObject ShootSpawnpoint;
    public GameObject Projectile;

    public float ProjectileSpeed;
    public float FireRate;

    public float LiveTimeProjectile;

    private float nextTimeToFire = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / FireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject gameObject = Instantiate(Projectile, ShootSpawnpoint.transform.position, ShootSpawnpoint.transform.rotation);
        gameObject.GetComponent<Rigidbody2D>().velocity = ShootSpawnpoint.transform.right * -1 * ProjectileSpeed;
        Destroy(gameObject, LiveTimeProjectile);
    }
}
