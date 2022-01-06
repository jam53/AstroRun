using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadLayoutGroup : MonoBehaviour
{
    public LayoutGroup layoutGroup;


    private void OnEnable()
    {
        StartCoroutine(reloadLayout());
    }

    IEnumerator reloadLayout()
    {
        layoutGroup.enabled = false;
        yield return new WaitForEndOfFrame();
        layoutGroup.enabled = true;
    }
}
