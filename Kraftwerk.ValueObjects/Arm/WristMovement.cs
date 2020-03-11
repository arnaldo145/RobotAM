using System.ComponentModel;

namespace Kraftwerk.ValueObjects.Arm
{
    public enum WristMovement
    {
        [Description("Rotação para -90º")]
        RotateMinus90Degrees = 1,
        [Description("Rotação para -45º")]
        RotateMinus45Degrees = 2,
        [Description("Em repouso")]
        InRest = 3,
        [Description("Rotação para 45º")]
        Rotate45Degrees = 4,
        [Description("Rotação para 90º")]
        Rotate90Degrees = 5,
        [Description("Rotação para 135º")]
        Rotate135Degrees = 6,
        [Description("Rotação para 180º")]
        Rotate180Degrees = 7
    }
}
