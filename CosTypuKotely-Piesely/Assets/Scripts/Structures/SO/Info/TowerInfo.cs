using UnityEngine;

[System.Serializable]
public class TowerInfo : StructureInfo
{
    [SerializeField]
    private float dmg;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float range;

    public float Dmg { get => dmg; set => dmg = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
    public float Range { get => range; set => range = value; }
public TowerInfo()
{
    
}
    public TowerInfo(TowerInfo info) : base(info)
    {
        Dmg = info.Dmg;
        FireRate = info.FireRate;
        Range = info.Range;
    }
}