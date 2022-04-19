using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWorker : Ant
{
    
    public int ResNum = 1;
    public BaseWorker(int health, int protection, int resourcesCount)
    {

        this.HP = health;
        this.Protection = protection;
        this.ResNum = resourcesCount;

    }

}
