using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private List<Bullet> bullets;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public int CurrentWeaponLevel { get; private set; } = 0;

    public void UpgradeWeapon()
    {
        CurrentWeaponLevel++;
    }

    public void Shoot(Vector2 direction)
    {
        Bullet createdBullet = Instantiate(bullets[CurrentWeaponLevel], transform.position, Quaternion.identity);//todo pooling
        createdBullet.Init(direction);
    }
}
