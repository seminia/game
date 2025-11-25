using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public Animator animator;
    public GameObject explosionEffect;
    public float explosionThreshold = 5f;

    private bool exploded = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (exploded) return;

        float force = collision.relativeVelocity.magnitude;

        if (force >= explosionThreshold)
        {
            exploded = true;
            animator.SetTrigger("Explode");

            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject, 0.5f); // задержка, чтобы анимация успела проиграться
        }
    }
}
