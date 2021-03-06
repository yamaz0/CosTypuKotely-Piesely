using System.Collections;
using UnityEngine;

public class TowerStructure : StructureBase
{
    public Enemy Enemy { get; private set; }
    WaitForSeconds rotateWaitTime = new WaitForSeconds(.1f);
    [SerializeField]
    private LayerMask mask;

    public float CacheTime { get; private set; }

    private void FixedUpdate()
    {
        // Rotate();
        TryShoot();
    }

    public void Rotate()
    {
        if (Enemy == null)
        {
            return;
        }

        Rotation.QuaternionSlerp(transform, Enemy.transform, 0.1f);
    }

    public void TryShoot()
    {
        //Search Enemy
        SearchEnemy();

        if (Enemy == null)
        {
            return;
        }

        if (CacheTime + ((TowerInfo)Info).FireRate <= Time.unscaledTime)
        {
            //Shoot
            CacheTime = Time.unscaledTime;
            Enemy.TakeDamage(((TowerInfo)Info).Dmg);
        }
    }

    private void SearchEnemy()
    {
        Collider2D hitinfo = Physics2D.OverlapCircle(transform.position, ((TowerInfo)Info).Range, mask);
        Enemy = hitinfo?.gameObject.GetComponent<Enemy>();
    }

}
