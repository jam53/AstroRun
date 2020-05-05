using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private Vector3 StartPosition;
    public Vector3 EndPosition;
    public float GaanSnelheid;
    public float TerugSnelheid;

    public float pauze;
    private bool StaStil;

    public AudioClip GeluidOpImpact;
    public AudioClip GeluidBijTerugGaan;



    private bool AanHetGaan = true; // Als het terug komt, gwn op false zetten
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, EndPosition) < 0.1f)
        {
            AanHetGaan = false;
            //geluid op impact hier
        }

        if (Vector3.Distance(this.transform.position, StartPosition) < 0.1f)
        {
            AanHetGaan = true;
            //float WatIsPauze = pauze;
            //while (pauze > 0)
            //{
            //    pauze -= Time.deltaTime;
            //}
            //pauze = WatIsPauze;

            
        }

        if (AanHetGaan)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, EndPosition, GaanSnelheid * Time.deltaTime); //Vector3.MoveTowards(this.transform.position, EndPosition, 0.000f);
        }

        if (!AanHetGaan)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, StartPosition, TerugSnelheid * Time.deltaTime);
        }

    }
}
