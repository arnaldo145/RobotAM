using System.ComponentModel;

namespace Kraftwerk.ValueObjects.Head
{
    public enum HeadRotation
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
        Rotate90Degrees = 5
    }
}
