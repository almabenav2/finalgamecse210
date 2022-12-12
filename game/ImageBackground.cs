
class ImageBackground : Sprite
{
    public ImageBackground() : base("images\\backgroundLargo.png")
    {
        y = -600;
        width = 960;
        height = 1200;
    }

    public override void Move()
    {
        y += 2;
        if (y >= 0)
        {
            y = -600;
        }
    }
}
