using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWarrior : Ant
{

    public Transform basePos;
    public List<Transform> targetPos = new List<Transform>();
    public float speed = 14.0f;
    public int Damage = 1;
    public int EnemiesNumber = 1;
    public int targetNum = -1;

    public bool damageGiven = false;

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

    public void SetBase(Transform target)
    {

        this.basePos = target;

    }

    public void SetTargets(List<Transform> targets)
    {

        this.targetNum = Random.Range(1, targetPos.Count);

        this.targetPos = targets;

        if (this.basePos != null)
            this.targetPos.Insert(0, this.basePos);

    }

    public override void FixedUpdate()
    {

        List<GameObject> enemies = GetNearEnemies(10.0f);

        try
        {

            enemies = enemies.GetRange(0, EnemiesNumber - 1);

        }
        catch (System.ArgumentException e) {

            

        }

        if (enemies.Count != 0 && !damageGiven)
        {

            foreach(GameObject enemy in enemies)
            {

                enemy.GetComponent<Ant>().GetDamage(Damage);

            }

            damageGiven = !damageGiven;

        }
        else
        {

            if (targetPos.Count == 0)
                return;

            transform.position = Vector3.MoveTowards(transform.position, targetPos[targetNum].position, speed * Time.deltaTime);

            transform.LookAt(new Vector3(targetPos[targetNum].position.x, 2000, targetPos[targetNum].position.z));

            if (Vector3.Distance(transform.position, targetPos[targetNum].position) < 4f)
            {

                if (targetNum == 0)
                    targetNum = Random.Range(1, targetPos.Count);

                else
                    targetNum = 0;

            }

        }

    }

}