using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Bullet bullet;

    public void Shoot(Vector2 direction)
    {
        Bullet b = Instantiate(bullet, transform.position, Quaternion.identity);//TODO pooling
        b.Init(direction);
    }
}