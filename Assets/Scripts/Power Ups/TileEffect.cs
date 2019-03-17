using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileEffect : MonoBehaviour
{
    
    public abstract EffectType Type { get; }

    public abstract IEnumerator Execute(Tile trigger);

}
