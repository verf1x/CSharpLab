namespace CSLab.Modules;

/// <summary>
/// Class that contains the shapes of the tetrominos
/// </summary>
internal static class TetrominoShapes
{
    /// <summary>
    /// Represents the O shape
    /// </summary>
    internal static readonly int[,,] OShape = new int[,,]
    {
        {
            {0,0},{1,0},{0,1},{1,1}
        }
    };

    /// <summary>
    /// Represents the I shape
    /// </summary>
    internal static readonly int[,,] IShape = new int[,,]
    {
        {
            {0,1},{1,1},{2,1},{3,1}
        },
        {
            {2,0},{2,1},{2,2},{2,3}
        }
    };

    /// <summary>
    /// Represents the T shape
    /// </summary>
    internal static readonly int[,,] TShape = new int[,,]
    {
        {
            {1,0},{0,1},{1,1},{2,1}
        },
        {
            {1,0},{1,1},{1,2},{2,1}
        },
        {
            {0,1},{1,1},{2,1},{1,2}
        },
        {
            {1,0},{0,1},{1,1},{1,2}
        }
    };

    /// <summary>
    /// Represents the S shape
    /// </summary>
    internal static readonly int[,,] SShape = new int[,,]
    {
        {
            {1,0},{2,0},{0,1},{1,1}
        },
        {
            {1,0},{1,1},{2,1},{2,2}
        }
    };

    /// <summary>
    /// Represents the Z shape
    /// </summary>
    internal static readonly int[,,] ZShape = new int[,,]
    {
        {
            {0,0},{1,0},{1,1},{2,1}
        },
        {
            {2,0},{1,1},{2,1},{1,2}
        }
    };

    /// <summary>
    /// Represents the J shape
    /// </summary>
    internal static readonly int[,,] JShape = new int[,,]
    {
        {
            {0,0},{0,1},{1,1},{2,1}
        },
        {
            {1,0},{1,1},{1,2},{0,2}
        },
        {
            {0,1},{1,1},{2,1},{2,2}
        },
        {
            {1,0},{2,0},{1,1},{1,2}
        }
    };

    /// <summary>
    /// Represents the L shape
    /// </summary>
    internal static readonly int[,,] LShape = new int[,,]
    {
        {
            {2,0},{0,1},{1,1},{2,1}
        },
        {
            {1,0},{1,1},{1,2},{2,2}
        },
        {
            {0,1},{1,1},{2,1},{0,2}
        },
        {
            {0,0},{1,0},{1,1},{1,2}
        }
    };
}