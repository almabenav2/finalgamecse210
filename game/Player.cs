
class player : Sprite
{

    public player()
        : base("datos//player.png")
    {
        x = 640;
        y = 600;
        velocX = 5;

        LoadSequence(Sprite.EXPLOITING,
            new string[] { "images\\playerE1.png",
                "images\\playerE2.png" });
        LoadSequence(Sprite.RIGHT,
            new string[] { "images\\player.png",
                "images\\player2.png" });
        ChangeDirection(Sprite.RIGHT);

        width = 54;
        height = 57;

        SetFramesByPhotogram(20);
    }

    public void MoveRIGHT()
    {
        x += velocX;
        nextPhotogram();
    }

    public void MoveLEFT()
    {
        x -= velocX;
        nextPhotogram();
    }

    public override void Move()
    {
        if (direction == Sprite.EXPLOITING)
        {
            nextPhotogram();
        }
    }

}

