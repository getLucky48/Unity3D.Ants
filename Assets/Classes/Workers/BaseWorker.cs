using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWorker : Ant
{

    public int ResNum = 1;

    public virtual void Init(int health, int protection, int resourcesCount)
    {

        this.HP = health;
        this.Protection = protection;
        this.ResNum = resourcesCount;

    }

    public override void SetColor()
    {

        if (this.team == Team.Red)
            GetComponentInChildren<Renderer>().material = (Resources.Load("Materials/Red_Worker", typeof(Material)) as Material);

        if (this.team == Team.Black)
            GetComponentInChildren<Renderer>().material = (Resources.Load("Materials/Black_Worker", typeof(Material)) as Material);

    }

    public override void FixedUpdate()
    {

        if (targetNum < 0)
            return;

        if (targetPos.Count == 0)
            return;

        transform.position = Vector3.MoveTowards(transform.position, targetPos[targetNum].position, speed * Time.deltaTime);

        //todo: ходит жопой
        transform.LookAt(new Vector3(targetPos[targetNum].position.x, transform.position.y, targetPos[targetNum].position.z));

        if (Vector3.Distance(transform.position, targetPos[targetNum].position) < 4f)
        {

            if (targetNum == 0)
                targetNum = Random.Range(1, targetPos.Count);
            else
                targetNum = 0;

        }

    }

}
