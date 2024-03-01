using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        off,
        on,
        Blink
    }


    public Collider bola;
    public Material offmaterial;
    public Material onmaterial;

    public ScoreManager scoreManager;
    public float score;

    public VFXManager vfxManager;

    public AudioManager audioManager;

    private SwitchState state;
    new private Renderer renderer; 

    private void Start()
    {
        renderer = GetComponent<Renderer>();

        Set(false);
        StartCoroutine (BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            toggle();
            vfxManager.PlayVFX(other.transform.position);
            audioManager.PlaySFX(other.transform.position);
        }
    }

    private void Set(bool active)
    {
        if(active == true)
        {
            state = SwitchState.on;
            renderer.material= onmaterial;
            StopAllCoroutines();

        }
        else
        {
            state=SwitchState.off;
            renderer.material= offmaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void toggle()
    {
        if(state == SwitchState.on)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
        scoreManager.AddScore(score);
    }
    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for(int i = 0; i < times ; i++)
        {
            renderer.material= onmaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offmaterial;
            yield return new WaitForSeconds(0.5f);
        }
        state = SwitchState.off;
        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
