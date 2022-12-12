class shot : Sprite
{
    public shot()
    : base("images\\shot.png")
    {
        width = 6;
        height = 15;
        velocX = 0;
        velocY = -5;
        activo = false;
    }

    public void Active(int x, int y)
    {
        this.x = x;
        this.y = y;
        activo = true;
    }

    public override void Move()
    {
        y += velocY;

        if ((y <= 0) || (y >= 720))
            activo = false;
    }
}
