public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }

    public override bool Equals(object obj)
    {
        if(obj is not Coord other) return false;
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);
}

public struct Plot
{
    public Plot(Coord corner1, Coord corner2, Coord corner3, Coord corner4)
    {
        Corner1 = corner1;
        Corner2 = corner2;
        Corner3 = corner3;
        Corner4 = corner4;
    }

    public Coord Corner1 { get; }
    public Coord Corner2 { get; }
    public Coord Corner3 { get; }
    public Coord Corner4 { get; }

    public int MaxSideLength()
    {
        var corners = new[] { Corner1, Corner2, Corner3, Corner4 };
        int? vertical = null;
        int? horizontal = null;
        
        for (int i = 1; i < corners.Length; i++)
        {
            if (corners[i].X == corners[0].X) vertical = i;
            if (corners[i].Y == corners[0].Y) horizontal = i;
        }
        
        int vLength = Math.Abs(corners[(int)vertical].Y - corners[0].Y);
        int hLength = Math.Abs(corners[(int)horizontal].X - corners[0].X);
        
        return Math.Max(vLength, hLength);
    }
    
    public override bool Equals(object obj)
    {
        if(obj is not Plot other) return false;
        return Corner1.Equals(other.Corner1)
            && Corner2.Equals(other.Corner2)
            && Corner3.Equals(other.Corner3)
            && Corner4.Equals(other.Corner4);
    }

    public override int GetHashCode() => HashCode.Combine(Corner1, Corner2, Corner3, Corner4);
}


public class ClaimsHandler
{
    private HashSet<Plot> Claims = new HashSet<Plot>();
    private Plot? LastClaimedPlot = null;
    
    public void StakeClaim(Plot plot)
    {
        Claims.Add(plot);
        LastClaimedPlot = plot;
    }

    public bool IsClaimStaked(Plot plot) => Claims.Contains(plot);

    public bool IsLastClaim(Plot plot) => LastClaimedPlot.HasValue && LastClaimedPlot.Equals(plot);
    
    public Plot GetClaimWithLongestSide()
    {
        var maxLength = -1;
        Plot outputPlot = default;
        
        foreach (var plot in Claims)
        {
            int currentLength = plot.MaxSideLength();
            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                outputPlot = plot;
            }
        }
        return outputPlot;
    }

}
