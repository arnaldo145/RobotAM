using System.ComponentModel;

namespace Kraftwerk.ValueObjects.Head
{
    public enum HeadInclination
    {
        [Description("Para cima")]
        Up = 1,
        [Description("Em repouso")]
        InRest = 2,
        [Description("Para baixo")]
        Down = 3
    }
}
