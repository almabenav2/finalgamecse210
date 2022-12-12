using System;

class Sprite
{
    // ----- Attributes -----
    protected int x;
    protected int y;
    protected int velocX;
    protected int velocY;
    protected int height;
    protected int width;
    protected bool activo;
    protected bool visible;

    protected int xOriginal;  // To bring to its initial position
    protected int yOriginal;

    // The image to be displayed on the screen, if static
    protected image myimage;

    // The sequence of images, if animated
    protected image[][] sequence;
    protected byte actualFotogram;
    protected byte direction;
    public const byte DOWN = 0;
    public const byte UP = 1;
    public const byte RIGHT = 2;
    public const byte LEFT = 3;
    public const byte EXPLOITING = 4;

    bool containsImage;        // If it does not contain image, it will not be possible to draw.
    bool contienesequence;     // The alternative: multiple images

    int restantsFrames;
    int framesByPhotogram = 10;



    // ----- Operations -----

    /// Constructor: Load the image that will represent this graphic element
    public Sprite(string name)
    {
        loadImage(name);
        direction = DOWN;
        activo = true;
        actualFotogram = 0;
        containsImage = true;
        contienesequence = false;
        sequence = new image[12][];
        activo = true;
        visible = true;
        // Default values for width and height
        width = 32;
        height = 32;
        restantsFrames = framesByPhotogram;
    }

    /// Moves the graphic element to another position
    public void MoveA(int newX, int newY)
    {
        x = newX;
        y = newY;
        if ((xOriginal == 0) && (yOriginal == 0))
        {
            xOriginal = newX;
            yOriginal = newY;
        }
    }

    /// CThe speed (incrX and incrY) of a single element
    public void SetVelocidad(int vX, int vY)
    {
        velocX = vX;
        velocY = vY;
    }


    /// Load the image that will represent this graphic element
    public void loadImage(string name)
    {
        myimage = new image();
        myimage.Charge(name);
        containsImage = true;
        contienesequence = false;
    }


    /// Loads a sequence of images for an animated element
    public void LoadSequence(byte direcc, string[] names)
    {
        containsImage = true;
        contienesequence = true;
        byte size = (byte)names.Length;
        sequence[direcc] = new image[size];
        for (byte i = 0; i < names.Length; i++)
        {
            sequence[direcc][i] = new image(names[i]);
        }
        // Default values for width and height
        width = 32;
        height = 32;
    }

    /// Moves the graphic element to another position
    public void ChangeDirection(byte newDir)
    {
        if (direction != newDir)
        {
            direction = newDir;
            actualFotogram = 0;
        }
    }

    /// Returns the character to its initial position.
    public void Restart()
    {
        x = xOriginal;
        y = yOriginal;
    }


    /// Draw the graphic element in its current position.
    public void Draw()
    {
        if (visible == false) return;
        if (contienesequence)
            sequence[direction][actualFotogram].Draw(x, y, width, height);
        else if (containsImage)
            myimage.Draw(x, y, width, height);
        else
            Hardware.ErrorFatal("An attempt was made to draw an image that was not loaded!");
    }

    /// Draws the graphic element in any position
    public void Draw(int newX, int newY)
    {
        MoveA(newX, newY);
        Draw();
    }

    /// Checks if it has collided with another graphic element
    public bool CollisionWith(Sprite otroElem)
    {
        if ((activo == false) || (otroElem.activo == false))
            return false;
        if ((otroElem.x + otroElem.width > x)
            && (otroElem.y + otroElem.height > y)
            && (x + width > otroElem.x)
            && (y + height > otroElem.y))
            return true;
        else
            return false;
    }

    public bool CollisionWith(int xIni, int yIni, int xFin, int yFin)
    {
        if (activo == false)
            return false;
        if ((x < xFin)
            && (x + width > xIni)
            && (y < yFin)
            && (y + height > yIni))
            return true;
        else
            return false;
    }

    /// Prepare the next frame, to animate the movement of a character.
    /// a character
    public void nextPhotogram()
    {
        restantsFrames--;
        if (restantsFrames > 0)
            return;

        restantsFrames = framesByPhotogram;

        if (actualFotogram < sequence[direction].Length - 1)
            actualFotogram++;
        else
            actualFotogram = 0;
    }

    public virtual void Move()
    {
        // To be redefined in "child" classes.
    }

    /// Returns x value
    public int GetX()
    {
        return x;
    }

    /// Returns y value
    public int GetY()
    {
        return y;
    }

    /// Change width and height
    public void Setwidthheight(int an, int al)
    {
        height = al;
        width = an;
    }

    /// Returns if active
    public bool GetActivo()
    {
        return activo;
    }

    /// Changes whether active (bumpable) or not
    public void SetActivo(bool a)
    {
        activo = a;
    }

    /// Change whether it is visible or not
    public void SetVisible(bool v)
    {
        visible = v;
    }

    public void SetFramesByPhotogram(int frames)
    {
        framesByPhotogram = frames;
    }

    public int Getdirection()
    {
        return direction;
    }

}
