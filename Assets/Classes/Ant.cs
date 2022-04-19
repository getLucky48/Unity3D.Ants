using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ant : MonoBehaviour
{

    public int HP = 1;
    public int Protection = 1;
    public bool isAlive = true;
    public Team team;


    //todo: для королевы переопределить метод через public override void GetDamage(int damage)
    public virtual void GetDamage(int damage)
    {
        
        if(isAlive)
            this.HP -= damage - this.Protection;

        if(this.HP <= 0)
            isAlive = false;

    }

    public void Death(GameObject obj)
    {

        if (!isAlive)
            Destroy(obj);

    }

    public void SetTeam(Team team)
    {

        this.team = team;

    }

    public enum Team
    {

        None,
        Red,
        Blue

    }


}
