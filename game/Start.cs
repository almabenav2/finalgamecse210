class Start
{
    bool StartFinished;
    player nave;
    EnemyBlock Enemys;
    shotsList shots;
    enemyShotList shotsE;
    int points;
    int lives;
    private int framesTillDisappear;
    scoreboard scoreboard;
    ImageBackground background1;
    starsBackground background2;

    public Start()
    {
        StartFinished = false;
        nave = new player();
        Enemys = new EnemyBlock();
        shots = new shotsList();
        shotsE = new enemyShotList();
        scoreboard = new scoreboard();
        background1 = new ImageBackground();
        background2 = new starsBackground();
        points = 0;
        lives = 3;
        framesTillDisappear = 50;
    }

    public void Send()
    {
        while (!StartFinished)
        {
            DrawScreen();
            CheckLoginUser();
            AnimateElements();
            CheckGameStatus();
            PPauseUntilEndOfPhotogram();
        }
    }

    

    private void DrawScreen()
    {
        Hardware.BorrarhiddenScreen();
        background1.Draw();
        background2.Draw();
        scoreboard.Draw();
        Enemys.Draw();
        nave.Draw();
        shots.Draw();
        shotsE.Draw();
        Hardware.displayHide();
    }

    private void CheckLoginUser()
    {
        if (Hardware.KeyPulsed(Hardware.KEY_DER))
            nave.MoveRIGHT();
        if (Hardware.KeyPulsed(Hardware.KEY_IZQ))
            nave.MoveLEFT();
        if (Hardware.KeyPulsed(Hardware.KEY_ESP))
            shots.tryAdd(nave.GetX()+20, nave.GetY()-15);

        if (Hardware.KeyPulsed(Hardware.KEY_ESC))
            StartFinished = true;
    }

    private void AnimateElements()
    {
        background1.Move();
        background2.Move();
        Enemys.Move();
        nave.Move();
        shots.Move(Enemys, this);
        shotsE.Move(Enemys);

        if (nave.Getdirection() == Sprite.EXPLOITING)
        {
            framesTillDisappear--;
            if (framesTillDisappear <= 0)
            {
                shotsE.empty();
                nave.MoveA(640, 600);
                if (lives <= 0)
                    StartFinished = true;
                nave.SetActivo(true);
                nave.ChangeDirection(Sprite.RIGHT);
                framesTillDisappear = 50;
            }
        }

    }

    private void CheckGameStatus()
    {
        if (Enemys.CollisionWith(nave))
            PerderVida();

        if (shotsE.CollisionWith(nave))
            PerderVida();
    }

    private static void PPauseUntilEndOfPhotogram()
    {
        Hardware.Pause(20);
    }

    public void Increasepoints(int points)
    {
        this.points += points;
        scoreboard.Setpoints(this.points);
    }

    private void PerderVida()
    {
        lives--;
        scoreboard.Setlives(lives);
        nave.ChangeDirection(Sprite.EXPLOITING);
        nave.SetActivo(false);
    }
}
