using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuObjectIO : MonoBehaviour
{

    public GameObject[] MenuToActivate = new GameObject[1];
    public GameObject[] MenuToClose = new GameObject[1];
    private int ClosedMenus;
    private int ActiveMenus;


    // Start is called before the first frame update
    void Start()
    {
       ActiveMenus = MenuToActivate.Length;
       ClosedMenus = MenuToClose.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Enable()
    {
        for (int i = 0; i < ActiveMenus; i++)
        {
            MenuToActivate[i].SetActive(true);
        }

        for (int i = 0; i < ClosedMenus; i++)
        {
            MenuToClose[i].SetActive(false);
        }
    }
}


