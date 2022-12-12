using System;
using System.Collections.Generic;

class EnemyBlock
{
    List<Enemy> Enemys;
    int speedBlock;
    Sound SoundExplosion;
    Random azarGenerator;
    int posXenemysBlock;

    public EnemyBlock()
    {
        azarGenerator = new Random();
        SoundExplosion = new Sound("images\\explosionJ.mp3");
        speedBlock = 5;
        Enemys = new List<Enemy>();
        for (int fila = 0; fila < 4; fila++)
        {
            for (int column = 0; column < 6; column++)
            {
                Enemy e = new Enemy(azarGenerator);
                e.MoveA(column * 150 + 150, fila * 100 + 20);
                e.SetVelocidad(5, 0);
                Enemys.Add(e);
            }
        }
        posXenemysBlock = 0;
    }

    public void Draw()
    {
        foreach (Enemy e in Enemys)
        {
            e.Draw();
        }
    }

    public void Move()
    {
        foreach (Enemy e in Enemys)
        {
            e.Move();
        }

        posXenemysBlock += speedBlock;
        if (posXenemysBlock > 200)
        {
            speedBlock = -5;
        }
        else if (posXenemysBlock < 0)
        {
            speedBlock = 5;
        }


        /*
        foreach (Enemy e in Enemys)
        {
            if ((e.GetActivo()) && (e.GetX() > 1100))
                speedBlock = -5;

            if ((e.GetActivo()) && (e.GetX() < 100))
                speedBlock = 5;
        }*/

        foreach (Enemy e in Enemys)
        {
            e.SetVelocidad(speedBlock, 0);
        }

    }

    public bool CollisionWith(Sprite s)
    {
        foreach (Enemy e in Enemys)
        {
            if (s.CollisionWith(e))
            {
                e.SetActivo(false);
                e.ChangeDirection(Sprite.EXPLOITING);
                SoundExplosion.Reproducir1();
                return true;
            }
        }
        return false;
    }

    public Enemy GetEnemy(int n)
    {
        return Enemys[n];
    }
}
