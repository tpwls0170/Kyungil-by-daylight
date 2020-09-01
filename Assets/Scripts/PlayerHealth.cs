using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : LivingEntity
{
    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);

        playerAnimator.SetBool("isInjured", true);
    }

    public override void Die()
    {
        base.Die();

        playerAnimator.SetTrigger("isDie");
    }

}
