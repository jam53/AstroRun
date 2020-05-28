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
    private float GaanSnelheidBackup;
    public float TerugSnelheid;
    private float TerugSnelheidBackup;

    public float pauze;
    private float pauzeBackup;
    private bool StaStil;

    public AudioClip GeluidOpImpact;
    public AudioClip GeluidBijTerugGaan;



    private bool AanHetGaan = true; // Als het terug komt, gwn op false zetten
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = this.transform.position;

        pauzeBackup = pauze;
        pauze = 0;

        GaanSnelheidBackup = GaanSnelheid;
        TerugSnelheidBackup = TerugSnelheid;
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
            GaanSnelheid = 0;
            TerugSnelheid = 0;
            //float WatIsPauze = pauze;
            //while (pauze > 0)
            //{
            //    pauze -= Time.deltaTime;
            //}
            //pauze = WatIsPauze;


        }

        if (pauze > 0)
        {
            pauze -= Time.deltaTime;
        }

        if (pauze <= 0)
        {
            GaanSnelheid = GaanSnelheidBackup;
            TerugSnelheid = TerugSnelheidBackup;
            pauze = pauzeBackup;
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
