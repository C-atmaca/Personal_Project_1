/*
    IMPLEMENTS OBJECT TYPE PATTERN
*/

public class BulletType
{
    private float _boundX;
    private float _boundY;
    private float _bulletSpeed;
    private BulletType _parent;

    public BulletType(BulletType parent, float boundX, float boundY, float bulletSpeed)
    {
        _boundX = boundX;
        _boundY = boundY;
        _bulletSpeed = bulletSpeed;
        _parent = null;
        
        if (parent != null)
        {
            _parent = parent;

            if (boundX != 0)
            {
                _boundX = parent.GetBoundX();
            }
            
            if (boundY != 0)
            {
                _boundY = parent.GetBoundY();
            }
            
            if (bulletSpeed != 0)
            {
                _bulletSpeed = parent.GetBulletSpeed();
            }
        }
    }

    public Bullet NewBullet()
    {
        return new Bullet(this);
    }

    public float GetBoundX()
    {
        return _boundX;
    }
    
    public float GetBoundY()
    {
        return _boundY;
    }
    
    public float GetBulletSpeed()
    {
        return _bulletSpeed;
    }
}
