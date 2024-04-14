using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FoodProjectile : MonoBehaviour
{
    public float life = 3;
    public VisualEffect ImpactVfx;

    void Awake()
    {
        Destroy(gameObject, life);
        if (ImpactVfx != null)
        {
            ImpactVfx.Stop();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit");
            return;
        }
        Debug.Log("Hit: " + collision.gameObject.tag);
        Destroy(gameObject);
    }
    void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.tag == "Untagged")
        {
            PlayImpactEffect();
        }

        Debug.Log("Hit: " + other.gameObject.tag);

        Destroy(gameObject);
    }

    private void PlayImpactEffect()
    {
        if (ImpactVfx != null)
        {
            Debug.Log("PlayImpactEffect");

            // Detach the VFX so it does not get destroyed with the GameObject
            ImpactVfx.transform.parent = null;
            ImpactVfx.transform.position.Set(transform.position.x, transform.position.y -1, transform.position.z);

            // Play the VFX
            ImpactVfx.Play();

            // Destroy the VFX after 1 second
            Destroy(ImpactVfx.gameObject, 1f);
        }
    }

}
