using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon: AssetItem
{
    [SerializeField] private WeaponType _weaponType;
    
    public enum WeaponType
        {
            TwoHands,
            OneHands,
            Ranged,
            Shield
        }
}