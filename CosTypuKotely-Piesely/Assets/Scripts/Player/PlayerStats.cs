using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    [SerializeField]
    private Float hp = new Float(50);
    [SerializeField]
    private Float maxHp = new Float(100);
    [SerializeField]
    private Float armor = new Float(0);
    [SerializeField]
    private Float speed = new Float(500);
    [SerializeField]
    private Float fireRate = new Float(100);
    [SerializeField]
    private Float gold = new Float(0);

    public Float Hp { get => hp; set => hp = value; }
    public Float MaxHp { get => maxHp; set => maxHp = value; }
    public Float Armor { get => armor; set => armor = value; }
    public Float Speed { get => speed; set => speed = value; }
    public Float Gold { get => gold; set => gold = value; }
    public Float FireRateBonus { get => fireRate; set => fireRate = value; }

    public Float GetStat(string statName)
    {
        return statName switch
        {
            "Hp" => Hp,
            "MaxHp" => MaxHp,
            "Armor" => Armor,
            "Speed" => Speed,
            "Gold" => Gold,
            _ => null
        };
    }
}
