
class program
{
    static void Main(string[] args)
    {
        Hardware.Initialize(1280, 720, 24);

        welcomeScreen welcome = new welcomeScreen();
        welcome.Send();
    }
}

