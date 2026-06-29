public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var outside = new List<List<int>>();

        if(rows == 0)
            return new List<List<int>>();
        
        for(var i = 1; i <= rows; i++)
        {
            var inside = new List<int>();
            for(var j = 1; j <= i; j++)
            {
                inside.Add(1);
            }
            outside.Add(inside);
        }

        if(rows >= 3)
        {
            for (var i = 2; i < rows; i++)
            {
                for (var j = 1; j < outside[i].Count - 1; j++)
                {
                    outside[i][j] = outside[i - 1][j] + outside[i - 1][j - 1];
                }
            }
        }
        
        return outside;
    }

}