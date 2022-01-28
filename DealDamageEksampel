using UnityEngine;

public class DealDamageEksampel : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    protected GameObject owner;

    public void Setup(GameObject owner) => this.owner = owner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == owner)
            return;

        //Damage
        if (collision.gameObject.TryGetComponent(out IDamageable damageableObject))
            damageableObject.TakeDamage(damage);
    }
}
