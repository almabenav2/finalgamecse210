using System;

class Source
{
    // Attributes

    IntPtr PointerInternal;

    // Operaciones

    /// Constructor from a file name and a file size
    public Source(string namefile, short size)
    {
        Charge(namefile, size);
    }

    public void Charge(string namefile, short size)
    {
        PointerInternal = Hardware.ChargeSource(namefile, size);
        if (PointerInternal == IntPtr.Zero)
            Hardware.ErrorFatal("Source inexistente: " + namefile);
    }

    public IntPtr ReadPointer()
    {
        return PointerInternal;
    }

}
