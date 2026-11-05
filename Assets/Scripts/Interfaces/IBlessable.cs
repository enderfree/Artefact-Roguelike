using System.Collections.Generic;
using UnityEngine;

public interface IBlessable
{
    /// <summary>
    /// First list represents a dice face
    /// Inner list contains all BlessingEffects that trigger on this face
    /// </summary>
    public List<List<BlessingEffect>> BlessingEffects { get; }
    public float MaxHP { get; set; }
    public float HP { get; set; }
}
