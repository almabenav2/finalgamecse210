class welcomeScreen
{
    public void Send()
    {
        bool welcomeFinished = false;
        Source fontType, fontTypeBig;
        fontType = new Source("data\\joystix.ttf", 18);
        fontTypeBig = new Source("data\\joystix.ttf", 48);


        do
        {
            Hardware.BorrarhiddenScreen();

            Hardware.WriteTextHidden("Martians Destroy",
                400, 150, // Coordenadas
                200, 200, 200, // colors
                fontTypeBig);
            Hardware.WriteTextHidden("Pulse J to play",
                500, 350, // Coordenadas
                180, 180, 180, // colors
                fontType);
            Hardware.WriteTextHidden("Pulse T to finish",
                500, 400, // Coordenadas
                160, 160, 160, // colors
                fontType);

            Hardware.displayHide();
            Hardware.Pause(20);

            if (Hardware.KeyPulsed(Hardware.KEY_T))
            {
                welcomeFinished = true;
            }
            if (Hardware.KeyPulsed(Hardware.KEY_J))
            {
                Start Start = new Start();
                Start.Send();
            }
        }
        while (!welcomeFinished);
    }
}
