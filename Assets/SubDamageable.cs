using System;
using UnityEngine; 
using UnityEngine.UIElements;

class SubDamageable : MonoBehaviour
{
    [SerializeField] int damage = 10;

    void OnMouseDown()
    {
        Damageable d = GetComponentInParent<Damageable>();
        d.CurrentHp = d.CurrentHp - damage;
    }
}