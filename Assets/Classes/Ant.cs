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
        {
            isAlive = false;
            Destroy(gameObject);
        }

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

    public List<GameObject> GetNearEnemies(float distance)
    {

        List<GameObject> result = new List<GameObject>();

        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {

            Ant a = gameObj.GetComponent<Ant>();

            if (!a) continue;
            if (transform.position == gameObj.transform.position) continue;

            if (Vector3.Distance(transform.position, gameObj.transform.position) <= distance)
            {

                result.Add(gameObj);

            }

        }

        return result;

    }

    public enum Team
    {

        None,
        Red,
        Black

    }
    
    //
    public virtual void Start()
    {



    }

    //
    public virtual void FixedUpdate()
    {



    }

}
