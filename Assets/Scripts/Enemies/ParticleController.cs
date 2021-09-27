using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem jumpGo;
    public ParticleSystem jumpGo2;
    public ParticleSystem fireAs;
    Animator _animator;


    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }
    public void JumpAnim() {

       if (jumpGo.isPlaying) jumpGo2.Play();
       else jumpGo.Play();
    }
    public void Update() {
        if (_animator.GetBool("rdyCharge"))        fireAs.Play();
        else fireAs.Stop();
    }
}
