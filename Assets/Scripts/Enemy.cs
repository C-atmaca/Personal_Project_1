using UnityEngine;

/*
    IMPLEMENTS PROTOTYPE PATTERN TO CLONE ENEMY OBJECTS
*/

public abstract class Enemy : MonoBehaviour
{
    public abstract void TakeDamage();

    public Enemy Clone()
    {
        return (Enemy)MemberwiseClone();
    }
}
