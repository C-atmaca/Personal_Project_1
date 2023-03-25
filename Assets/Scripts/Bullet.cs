/*
    IMPLEMENTS OBJECT TYPE PATTERN
*/

public class Bullet
{
    private float boundX;
    private float boundY;
    private float bulletSpeed;
    private BulletType _bulletType;

    public Bullet(BulletType bulletType)
    {
        _bulletType = bulletType;
        boundX = bulletType.GetBoundX();
        boundY = bulletType.GetBoundY();
        bulletSpeed = bulletType.GetBulletSpeed();
    }
    
    public float GetBoundX()
    {
        return boundX;
    }
    
    public float GetBoundY()
    {
        return boundY;
    }
    
    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }
}
