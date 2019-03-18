using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHandler : MonoBehaviour
{

    [SerializeField]
    private List<TileEffect> effects;

    private Dictionary<EffectType, TileEffect> effectDict = new Dictionary<EffectType, TileEffect>();

    private static EffectHandler instance;
    public static EffectHandler Instance => instance;

    private void Awake() {        
        foreach (var effect in effects)
        {
            EffectType type = effect.Type;
            if (effectDict.ContainsKey(type))
                continue;

            effectDict.Add(type, effect);
        }

        if (instance == null){
            instance = this;
            return;
        }

        Destroy(this);
    }

    public Coroutine ExecuteEffect(EffectType type, Tile trigger){
        if (!effectDict.ContainsKey(type))
            return null;

        var effect = effectDict[type];
        return StartCoroutine(effect.Execute(trigger));
    }
}
