using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    public float score;

    public AudioManager audioManager;
    public VFXManager vfxManager ;
    public ScoreManager scoreManager ;

    new private Renderer renderer;
    private Animator animator;
    public void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        renderer.material.color = color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolarig = bola.GetComponent<Rigidbody>();
            bolarig.velocity *= multiplier;

            //animation
            animator.SetTrigger("hit");

            audioManager.PlaySFX(collision.transform.position);

            vfxManager.PlayVFX(collision.transform.position);

            scoreManager.AddScore(score);
        }
    }
}
