using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Trampoline : MonoBehaviour
{
    public int speed;

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }

}