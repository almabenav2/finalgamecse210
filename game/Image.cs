using System;

class image
{
    // Atributtes
    private IntPtr PointerInternal;

    // Operaciones    
    public image()  // Constructor
    {
        PointerInternal = IntPtr.Zero;  
    }

    public image(string namefile)  // Constructor
    {
        Charge(namefile);
    }

    /// Loads an image from a file name
    public void Charge(string namefile)
    {
        PointerInternal = Hardware.loadImage(namefile);
        if (PointerInternal == IntPtr.Zero)
            Hardware.ErrorFatal("inexistent image: " + namefile);
    }

    /// Draws an image at coordinates (supported by Hardware)
    public void Draw(int x, int y, int width, int height)
    {
        Hardware.drawHideImage(PointerInternal, x, y,
            width, height);
    }

    /// Returns the SDL Pointer (should never need to be used).
    public IntPtr GetPointer()
    {
        return PointerInternal;
    }
}

