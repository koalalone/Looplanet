

using Unity.VisualScripting;

public class HealthSystem
{
    private int health;
    private int maxHealth;
    public HealthSystem(int health)
    {
        this.health = health;
        this.maxHealth = health;
    }
        
    public int GetHealth()
    {
        return health;
    }

    public float GetHealthPercentage()
    {
        return (float) health/maxHealth;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0) {
            health = 0;
        }
        
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    


}
