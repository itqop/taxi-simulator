using UnityEngine;


//! ANIMATIA PED
public class AnimatorChar : MonoBehaviour
{
    public Animator _anim;
    // Update is called once per frame
    public void animHit()
    {
        _anim.SetInteger("legs", 36);
    }

    public void animWalk()
    {
        _anim.SetInteger("legs", 1);
    }
}
