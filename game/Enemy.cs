using System;

class Enemy : Sprite
{
    private int framesTillDisappear;
    private int framesTillAttack;
    static Random azarGenerator;
    private bool attacking;
    private int[] horizontalDisplacementAttack;
    int positionSequenceAttack;
    int xReturn, yReturn;

    public Enemy(Random generator)
        : base("images\\Enemy1a.png")
    {
        x = 640;
        y = 100;
        velocX = 5;
        velocY = 0;
        framesTillDisappear = 50;
        

        LoadSequence(Sprite.RIGHT,
            new string[] { "images\\Enemy1a.png",
                "images\\Enemy1b.png" });
        ChangeDirection(Sprite.RIGHT);
        LoadSequence(Sprite.EXPLOITING,
            new string[] { "images\\EnemyE1.png",
                "images\\EnemyE2.png" });

        width = 48;
        height = 24;

        SetFramesByPhotogram(12);

        azarGenerator = generator;
        framesTillAttack = azarGenerator.Next(200, 2000);
        attacking = false;

        horizontalDisplacementAttack = new int[600];
        for (int i = 0; i < 600; i++)
        {
            if (i < 200)
                horizontalDisplacementAttack[i] = 2;
            else
                horizontalDisplacementAttack[i] = -2;
        }
        positionSequenceAttack = 0;
    }

    public override void Move()
    {
        nextPhotogram();

        if (direction == Sprite.EXPLOITING)
        {
            framesTillDisappear--;
            if (framesTillDisappear <= 0)
            {
                visible = false;
            }
        }
        if (!activo)
            return;

        framesTillAttack--;
        if (framesTillAttack <= 0)
        {
            attacking = true;
            xReturn = x;
            yReturn = y;
            framesTillAttack = azarGenerator.Next(300, 500);
        }

        if (!attacking)
        {
            x += velocX;
            y += velocY;
        }
        else
        {
            xReturn += velocX;

            y += 2;
            x += horizontalDisplacementAttack[positionSequenceAttack];
            positionSequenceAttack++;

            if ((y > 720) || (positionSequenceAttack > 600))
            {
                attacking = false;
                positionSequenceAttack = 0;
                x = xReturn;
                y = yReturn;
            }
        }

        

        /*
        if ((x <= 100) || (x >= 1100))
            velocX = -velocX;

        if ((y <= 20) || (y >= 680))
            velocY = -velocY;
        */
    }
}
