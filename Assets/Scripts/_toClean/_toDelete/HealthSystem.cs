using UnityEngine;
using Sirenix.OdinInspector;

public class HealthSystem : SerializedMonoBehaviour, IDamageable
{
    public int StartHP;
    public int CurrentHP;
    public IDamageFeedback DamageFeedback;
    public IDestructionFeedback DestructionFeedback;
    

    public void Start()
    {
        CurrentHP = StartHP;
    }

    public void CollisionDamage(GameObject pGameObject)
    {
        var doDamage = pGameObject.GetComponent<DoDamageOnCollision>();
        if (doDamage != null)
        {
            TookDamage = true;
            DamageCount = doDamage.Damage;
        }
    }

    private bool TookDamage;
    private int DamageCount;

    public void Tick()
    {
        if (TookDamage)
        {
            ApplyDamage();
            TookDamage = false;
            DamageCount = 0;
        }
    }

    private void ApplyDamage()
    {
        CurrentHP -= DamageCount;

        if (CurrentHP <= 0)
        {
            Die();
            return;
        }
        DamageFeedback.Trigger(0);
    }

    private void Die()
    {
        DestructionFeedback.Trigger();
        Destroy(gameObject);
    }
}
