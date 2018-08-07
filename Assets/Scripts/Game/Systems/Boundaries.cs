public struct Boundaries
{
    public float Height { get { return Top - Bottom; } }
    public float Width { get { return Right - Left; } }
    public float Top;
    public float Mid;
    public float Bottom;
    public float Left;
    public float Center;
    public float Right;

    public override string ToString()
    {
        return "Boundaries : {\n" +
            "    Left - Center - Right : " + Left + ", " + Center + ", " + Right + "\n" +
            "    Top - Mid - Bottom : " + Top + ", " + Mid + ", " + Bottom + "\n" +
            "}";
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() == typeof(Boundaries))
        {
            return AreSame((Boundaries)obj);
        }
        else return false;
    }

    public bool AreSame(Boundaries b)
    {
        return Top == b.Top
            && Mid == b.Mid
            && Bottom == b.Bottom
            && Left == b.Left
            && Center == b.Center
            && Right == b.Right;
    }

    public Boundaries (Boundaries original) {
        Top = original.Top;
        Mid = original.Mid;
        Bottom = original.Bottom;
        Left = original.Left;
        Center = original.Center;
        Right = original.Right;
    }
}
