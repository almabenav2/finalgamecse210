using System;
using System.Threading;
using ReTao.Sdl;

class Hardware
{
    // Atributes

    static IntPtr hiddenScreen;
    static int width, height;

    // Operaciones

    /// Initializes the graphic mode to a certain width, height and color depth, ex. 640, 480, 24 bit.
    public static void Initialize(int an, int al, int colors)
    {
        //System.Console.Write("Initialize...");
        width = an;
        height = al;

        int flags = (Sdl.SDL_HWSURFACE | Sdl.SDL_DOUBLEBUF | Sdl.SDL_ANYFORMAT);
        Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
        hiddenScreen = Sdl.SDL_SetVideoMode(
            width,
            height,
            colors,
            flags);

        Sdl.SDL_Rect rect2 =
            new Sdl.SDL_Rect(0, 0, (short)width, (short)height);
        Sdl.SDL_SetClipRect(hiddenScreen, ref rect2);

        SdlTtf.TTF_Init();

        if (SdlMixer.Mix_OpenAudio(22050,
          unchecked(Sdl.AUDIO_S16LSB), 2, 1024) == -1)
            ErrorFatal("Sound could not be Initialized");

    }

    /// Draw an image on a hidden screen, at certain coordinates
    public static void BorrarhiddenScreen()
    {
        Sdl.SDL_Rect origin = new Sdl.SDL_Rect(0, 0, (short)width, (short)height);
        Sdl.SDL_FillRect(hiddenScreen, ref origin, 0);
    }

    /// Draw an image on a hidden screen, at certain coordinates
    public static void drawHideImage(IntPtr image, int x, int y, int width, int height)
    {
        Sdl.SDL_Rect origen = new Sdl.SDL_Rect(0, 0, (short)width, (short)height);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)width, (short)height);
        Sdl.SDL_BlitSurface(image, ref origen, hiddenScreen, ref dest);
    }

    /// Draw an image on a hidden screen, at certain coordinates
    public static void drawHideImage(image image, int x, int y, int width, int height)
    {
        drawHideImage(image.GetPointer(), x, y, width, height);
    }

    /// Display the hidden screen
    public static void displayHide()
    {
        Sdl.SDL_Flip(hiddenScreen);
    }


    public static IntPtr loadImage(string file)
    {
        IntPtr image;
        image = SdlImage.IMG_Load(file);
        if (image == IntPtr.Zero)
        {
            System.Console.WriteLine("nonexistent image: {0}", file);
            Environment.Exit(4);
        }
        return image;
    }

    public static void WriteTextHidden(string text,
        int x, int y, byte r, byte g, byte b, Source f)
    {
        WriteTextHidden(text, x, y, r, g, b, f.ReadPointer());
    }

    public static void WriteTextHidden(string text,
        int x, int y, byte r, byte g, byte b, IntPtr Source)
    {
        Sdl.SDL_Color color = new Sdl.SDL_Color(r, g, b);
        IntPtr textAsImage = SdlTtf.TTF_RenderText_Solid(
            Source, text, color);
        if (textAsImage == IntPtr.Zero)
            Environment.Exit(5);

        Sdl.SDL_Rect origen = new Sdl.SDL_Rect(0, 0, (short)width, (short)height);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)width, (short)height);

        Sdl.SDL_BlitSurface(textAsImage, ref origen,
            hiddenScreen, ref dest);
        Sdl.SDL_FreeSurface(textAsImage);
    }

    public static IntPtr ChargeSource(string file, int size)
    {
        IntPtr Source = SdlTtf.TTF_OpenFont(file, size);
        if (Source == IntPtr.Zero)
        {
            System.Console.WriteLine("Inexistent source : {0}", file);
            Environment.Exit(6);
        }
        return Source;
    }

    public static bool KeyPulsed(int c)
    {
        bool pulsed = false;
        Sdl.SDL_PumpEvents();
        Sdl.SDL_Event sucess;
        Sdl.SDL_PollEvent(out sucess);
        int numkeys;
        byte[] KEYs = Tao.Sdl.Sdl.SDL_GetKeyState(out numkeys);
        if (KEYs[c] == 1)
            pulsed = true;
        return pulsed;
    }

    public static void Pause(int milliseconds)
    {
        Thread.Sleep(milliseconds);
    }

    /// Returns the width of the screen, in pixels.
    public static int Getwidth()
    {
        return width;
    }

    /// Returns the height of the screen, in pixels.
    public static int Getheight()
    {
        return height;
    }

    /// Quits the program, displaying a certain error message.
    public static void ErrorFatal(string text)
    {
        System.Console.WriteLine(text);
        Environment.Exit(1);
    }


    // Key definitions
    public static int KEY_ESC = Sdl.SDLK_ESCAPE;
    public static int KEY_ESP = Sdl.SDLK_SPACE;
    public static int KEY_A = Sdl.SDLK_a;
    public static int KEY_B = Sdl.SDLK_b;
    public static int KEY_C = Sdl.SDLK_c;
    public static int KEY_D = Sdl.SDLK_d;
    public static int KEY_E = Sdl.SDLK_e;
    public static int KEY_F = Sdl.SDLK_f;
    public static int KEY_G = Sdl.SDLK_g;
    public static int KEY_H = Sdl.SDLK_h;
    public static int KEY_I = Sdl.SDLK_i;
    public static int KEY_J = Sdl.SDLK_j;
    public static int KEY_K = Sdl.SDLK_k;
    public static int KEY_L = Sdl.SDLK_l;
    public static int KEY_M = Sdl.SDLK_m;
    public static int KEY_N = Sdl.SDLK_n;
    public static int KEY_O = Sdl.SDLK_o;
    public static int KEY_P = Sdl.SDLK_p;
    public static int KEY_Q = Sdl.SDLK_q;
    public static int KEY_R = Sdl.SDLK_r;
    public static int KEY_S = Sdl.SDLK_s;
    public static int KEY_T = Sdl.SDLK_t;
    public static int KEY_U = Sdl.SDLK_u;
    public static int KEY_V = Sdl.SDLK_v;
    public static int KEY_W = Sdl.SDLK_w;
    public static int KEY_X = Sdl.SDLK_x;
    public static int KEY_Y = Sdl.SDLK_y;
    public static int KEY_Z = Sdl.SDLK_z;
    public static int KEY_1 = Sdl.SDLK_1;
    public static int KEY_2 = Sdl.SDLK_2;
    public static int KEY_3 = Sdl.SDLK_3;
    public static int KEY_4 = Sdl.SDLK_4;
    public static int KEY_5 = Sdl.SDLK_5;
    public static int KEY_6 = Sdl.SDLK_6;
    public static int KEY_7 = Sdl.SDLK_7;
    public static int KEY_8 = Sdl.SDLK_8;
    public static int KEY_9 = Sdl.SDLK_9;
    public static int KEY_0 = Sdl.SDLK_0;
    public static int KEY_ARR = Sdl.SDLK_UP;
    public static int KEY_ABA = Sdl.SDLK_DOWN;
    public static int KEY_DER = Sdl.SDLK_RIGHT;
    public static int KEY_IZQ = Sdl.SDLK_LEFT;
}

