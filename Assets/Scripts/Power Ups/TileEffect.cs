using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileEffect : MonoBehaviour
{
    
    [SerializeField]
    protected PowerUpUI uiHandler;
    [SerializeField]
    protected Sprite icon;

    public abstract EffectType Type { get; }

    public abstract IEnumerator Execute(Tile trigger);

}
