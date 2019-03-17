using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : TileEffect
{
    public override EffectType Type => EffectType.Mine;

    public override IEnumerator Execute(Tile trigger)
    {
        trigger.Pawn.SetToSpawn();
        yield break;
    }
}
