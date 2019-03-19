using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : TileEffect
{
    [SerializeField]
    private float imageShowTime = 0.75f;

    public override EffectType Type => EffectType.Mine;

    public override IEnumerator Execute(Tile trigger)
    {
        uiHandler.SetPowerupImage(icon);
        trigger.Pawn.SetToSpawn();
        StartCoroutine(ResetImage());
        yield break;
        
    }

    private IEnumerator ResetImage(){
        yield return new WaitForSeconds(imageShowTime);
        uiHandler.ResetImage();
    }
}
