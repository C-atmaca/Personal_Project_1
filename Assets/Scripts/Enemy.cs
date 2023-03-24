using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void TakeDamage();

    public Enemy Clone()
    {
        return (Enemy)MemberwiseClone();
    }
}
