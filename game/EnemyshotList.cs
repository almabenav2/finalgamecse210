
using System;

class enemyShotList : shotsList
{
    Random generator;

    public enemyShotList()
    {
        maxshots = 5;
        generator = new Random();
    }

    public new void tryAdd(int x, int y)
    {
        if ((DateTime.Now - instantLasthot).Milliseconds
                < millisecondsEntreshots)
            return;

        if (shots.Count >= maxshots)
            return;

        shotEnemy d = new shotEnemy();
        d.Active(x, y);
        shots.Add(d);
        instantLasthot = DateTime.Now;
    }

    public void Move(EnemyBlock be)
    {
        foreach (shot d in shots)
        {
            d.Move();
        }

        for (int i = 0; i < shots.Count; i++)
        {
            if (!shots[i].GetActivo())
            {
                shots.RemoveAt(i);
                i--;
            }
        }

        if (shots.Count < maxshots)
        {
            int numEnemy = generator.Next(24);

            Enemy Enemy = be.GetEnemy(numEnemy);
            if (Enemy.GetActivo())
            {
                tryAdd(Enemy.GetX() + 20,
                    Enemy.GetY() + 15);
            }
        }
    }

    public bool CollisionWith(Sprite s)
    {
        foreach (shot d in shots)
        {
            if (s.CollisionWith(d))
            {
                d.SetActivo(false);
                return true;
            }
        }
        return false;
    }

    public void empty()
    {
        shots.Clear();
    }
}
