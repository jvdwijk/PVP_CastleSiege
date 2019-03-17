using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    [SerializeField]
    private List<Tile> connectedTiles;
    
    [SerializeField]
    private List<EffectType> effects = new List<EffectType>();
    
    public abstract Pawn Pawn { get; }

    public Vector3 Location => transform.position;
    public List<EffectType> Effects => effects;
    public Tile[] ConnectedTiles => connectedTiles.ToArray();

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(Location, 0.8f);


        Gizmos.color = Color.red;
        foreach (var tile in ConnectedTiles)
        {
            if (!tile)
                continue;

            Gizmos.DrawLine(Location, tile.Location);
        }
    }

    public abstract void PawnEnter(Pawn pawn);
    public virtual void PawnLeave(Pawn pawn){

    }

    public void AddConnection(Tile tile){
        if (connectedTiles.Contains(tile))
            return;

        connectedTiles.Add(tile);
    }

    public void RemoveTile(Tile tile){
        if (!connectedTiles.Contains(tile))
            return;
            
        connectedTiles.Remove(tile);
    }

    public void RemoveAllTiles(){
        connectedTiles.Clear();
    }

    public void AddEffect(EffectType effect){
        if (effects.Contains(effect))
            return;
        
        effects.Add(effect);
    }

    public void RemoveEffect(EffectType effect){
        if (!effects.Contains(effect))
            return;
        
        effects.Remove(effect);
    }

    protected IEnumerator RunEffects(){
        foreach (var effect in effects)
        {
            yield return EffectHandler.Instance.ExecuteEffect(effect, this);
        }
    }

}
