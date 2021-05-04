using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOutliner : MonoBehaviour
{
    public float AnimationSpeed = 0.35f;
    public float MaxThickness;


    private float AnimationState;

    private Material SpriteOutline;
    private Color MaterialColor;

    private float MaterialMinimumThickness;


    // Start is called before the first frame update
    void Start()
    {
        MaterialMinimumThickness = 0f;

        SpriteOutline = GetComponent<Renderer>().material; //Get the SpringOutline material on the object

        //Get it's values
        MaterialColor = SpriteOutline.GetColor("_Color");

        SpriteOutline.SetFloat("Enable", 0);//Disable the shader

    }

    // Update is called once per frame
    void Update()
    {
        SpriteOutline.SetFloat("Thickness", Mathf.Lerp(MaterialMinimumThickness, MaxThickness, AnimationState));

        AnimationState += AnimationSpeed * Time.deltaTime;

        if (AnimationState > 1.0f)
        {
            float temp = MaxThickness;
            MaxThickness = MaterialMinimumThickness;
            MaterialMinimumThickness = temp;
            AnimationState = 0.0f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")//If the player touches this object, which kills the player. Enable the outline,
            //.........................This way it's easier for the player to see, to what they died
        {
            SpriteOutline.SetFloat("Enable", 1);//Enable the shader
        }
    }
}
