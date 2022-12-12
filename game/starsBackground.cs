
using System;

class starsBackground
{
    Sprite[] stars;
    const int NUM_stars = 20;

    public starsBackground()
    {
        Random r = new Random();
        stars = new Sprite[NUM_stars];
        for (int i = 0; i < NUM_stars; i++)
        {
            stars[i] = new Sprite("images\\estrella.png");
            stars[i].MoveA(r.Next(960), r.Next(600));
        }
    }

    public void Draw()
    {
        for (int i = 0; i < NUM_stars; i++)
        {
            stars[i].Draw();
        }
    }

    public void Move()
    {
        for (int i = 0; i < NUM_stars; i++)
        {
            int x = stars[i].GetX();
            int y = stars[i].GetY();
            y += 3;
            if (y >= 600)
                y = 0;
            stars[i].MoveA(x, y);
        }
    }
}

