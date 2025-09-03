public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var result = new int[size, size];
        int top = 0;
        int left = 0;
        int bottom = size - 1;
        int right = size - 1;
        int value = 1;

        while(top <= bottom && left <= right)
        {
            // Left to Right
            for(int col = left; col <= right; col++)
                result[top, col] = value++;
            top++;

            // Top to Bottom
            for(int row = top; row <= bottom; row++)
                result[row, right] = value++;
            right--;

            // Right to Left
            for(int col = right; col >= left; col--)
                result[bottom, col] = value++;
            bottom--;

            // Bottom to Top
            for(int row = bottom; row >= top; row--)
                result[row, left] = value++;
            left++;
        }
        
        return result;
    }
}
