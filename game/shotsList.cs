using System;
using System.Collections.Generic;

class shotsList
{
    protected List<shot> shots;
    protected int maxshots;
    protected DateTime instantLasthot;
    protected float millisecondsEntreshots;

    public shotsList()
    {
        shots = new List<shot>();
        maxshots = 3;
        instantLasthot = DateTime.Now;
        millisecondsEntreshots = 200;
    }

    public void tryAdd(int x, int y)
    {
        if ((DateTime.Now - instantLasthot).Milliseconds 
                < millisecondsEntreshots)
            return;

        if (shots.Count >= maxshots)
            return;

        shot d = new shot();
        d.Active(x, y);
        shots.Add(d);
        instantLasthot = DateTime.Now;
    }

    public void Draw()
    {
        foreach (shot e in shots)
        {
            e.Draw();
        }
    }

    public virtual void Move(EnemyBlock be, Start Start)
    {
        foreach (shot d in shots)
        {
            d.Move();
            if (be.CollisionWith(d))
            {
                d.SetActivo(false);
                Start.Increasepoints(10);
            }
        }

        for (int i = 0; i < shots.Count; i++)
        {
            if (! shots[i].GetActivo() )
            {
                shots.RemoveAt(i);
                i--;
            }
        }
    }
}
