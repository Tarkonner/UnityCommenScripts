using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 1;
    [SerializeField] private int currentHealth;
    private bool isDead = false;

    #region Properties
    public int MaxHealth { get { return maxHealth; } }
    public int CurrentHealth { get { return currentHealth; } }
    public bool IsDead { get { return isDead;} }
    #endregion

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int damageAmount)
    {
        currentHealth = Mathf.Max(currentHealth - damageAmount, 0);

        if (currentHealth <= 0)
            OnDies();
    }

    public virtual bool Healable(int healthAmount)
    {
        if(currentHealth < maxHealth)
        {
            currentHealth = Mathf.Min(currentHealth + healthAmount, maxHealth);
            return true;
        }
        else return false;
    }

    public virtual void AddToMaxHealth(int amount, bool increseCurrentHealth)
    {
        maxHealth += amount;

        if (increseCurrentHealth)
            currentHealth += amount;
    }

    public virtual void Revive(int reviedHealth = 0)
    {
        currentHealth = reviedHealth == 0 ? maxHealth : reviedHealth;

        isDead = false;
    }

    protected virtual void OnDies()
    {
        isDead = true;
        gameObject.gameObject.SetActive(false);
    }
}
