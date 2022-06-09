using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public Animator animator;
    public AnimatorOverrideController[] animatorOverrideControllers; //The index corresponds to a specific skin. See Assets/RiolRat/Other/SkinsIDs.md
    
    // Start is called before the first frame update
    void Start()
    {
        animator.runtimeAnimatorController = animatorOverrideControllers[SaveLoadManager.slm.astroRunData.selectedSkin];
    }
}
