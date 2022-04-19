using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWarrior : Ant
{
 
    public int Damage = 1;
    public int EnemiesNumber = 1;

    public virtual void Init(int health, int damage, int protection, int enemiesnum)
    {

        this.HP = health;
        this.Damage = damage;
        this.Protection = protection;
        this.EnemiesNumber = enemiesnum;

    }

    public virtual void GiveDamage(Ant target)
    {
        
        target.GetDamage(this.Damage);

    }

}