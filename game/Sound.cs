using System;
using ReTao.Sdl;

public class Sound
{
    // Attributes
    IntPtr PointerInternal;

    // Operations

    // Constructor from a file name
    public Sound(string namefile)
    {
        PointerInternal = SdlMixer.Mix _LoadMUS(namefile);
    }

    // Play once
    public void Reproducir1()
    {
        SdlMixer.Mix_PlayMusic(PointerInternal, 1);
    }

    // Continuous playback (background music)
    public void Reproducirbackground()
    {
        SdlMixer.Mix_PlayMusic(PointerInternal, -1);
    }

    // Interrupt all Sound playback
    public void Interrump()
    {
        SdlMixer.Mix_HaltMusic();
    }

}
