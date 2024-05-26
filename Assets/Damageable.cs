using System;
using UnityEngine;

class Damageable : MonoBehaviour
{
    [SerializeField] int maxHp;

    // public int CurrentHp { get; private set; }  // Auto Property

    int currentHp;  // Field

    public int CurrentHp  // Property
    {
        get { return currentHp; }
        set
        {
            if (currentHp == value) return;

            currentHp = value;
            OnHPChange();
        }
    }


    // --------------------


    void Start()
    {
        currentHp = maxHp;
    }

    void OnHPChange()
    {
        // Hangeffekt
    }

    public float GetHPRate() => (float)currentHp / maxHp;
    //public float GetHPRate()   // Ekvivalens
    //{
    //    return (float)currentHp / maxHp;
    //}

    /*
    public void Damage(int amount)
    {
        currentHp = currentHp - amount;
        OnHPChange();
    }

    public int GetCurrentHP()   // Method
    {
        return currentHp;
    }
    public void SetCurrentHP(int newValue)   // Method
    {
        currentHp = newValue;
        OnHPChange();
    }
    */
}
