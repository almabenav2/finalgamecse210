class scoreboard
{
    private int points;
    private int lives;
    private static Source fontType;

    public scoreboard()
    {
        fontType = new Source("data\\joystix.ttf", 18);
    }

    public void Setpoints(int points)
    {
        this.points = points;
    }

    public void Setlives(int lives)
    {
        this.lives = lives;
    }

    public void Draw()
    {
        Hardware.WriteTextHidden("points: " + points,
            10, 10, // Coordenadas
            200, 200, 200, // colors
            fontType);
        Hardware.WriteTextHidden("lives: " + lives,
            1150, 10, // Coordenadas
            200, 200, 200, // colors
            fontType);
    }



}
