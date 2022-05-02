using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{

    public AudioSource AudioSource;
    public SpriteRenderer spriteRender;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        spriteRender = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter(Collider other)
    {
         ThirdPersonMovement controller = other.GetComponent<ThirdPersonMovement>();

        if (controller != null)
        {
            if(controller.health  < controller.maxHealth)
            {
                // AudioSource.Play();
                controller.ChangeHealth(1);
                // Destroy(gameObject);
                StartCoroutine(waitbeforDisable());
            }
        }
    }

    private IEnumerator waitbeforDisable()
    {
        AudioSource.Play();
        spriteRender.enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
