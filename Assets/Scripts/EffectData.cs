using Actors;
using Entities;

public abstract class EffectData : EntityData
{
    public float Duration { get; protected set; }
    
    public bool IsExpired => Duration <= 0f;

    public virtual void OnApply(Actor actor) { }
    
    public virtual void OnExpire(Actor actor) { }
    
    public virtual void Tick(Actor actor, float deltaTime)
    {
        Duration -= deltaTime;
    }
        
}