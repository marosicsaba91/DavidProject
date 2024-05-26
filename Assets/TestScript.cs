using System;
using UnityEngine;

class Dog
{
    public string name;    // null
    public int age;         // 0
    public float speed;     // 0
    public bool isGoodBoy;  // false

    public Dog()  // Konstruktor
    {
        this.name = "NUNAMED";
        isGoodBoy = true;
    }

    public Dog(string name)  // Konstruktor
    {
        isGoodBoy = true;
        this.name = name;
    }

    public Dog(int age)  // Konstruktor
    {
        this.name = "NUNAMED";
        this.age = age;
        isGoodBoy = true;
    }

    public void Bark()
    {
        Debug.Log($"Vau! I'm {name}");
    }

    public void Bark(string sound)
    {
        Debug.Log($"{sound}! I'm {name}");
    }
}


public class TestScript : MonoBehaviour
{
    [SerializeField] GameObject target;

    void Start()
    {
        Damageable[] damageables = FindObjectsOfType<Damageable>();
        Damageable d2 = GetComponent<Damageable>();  // ???
        Damageable[] d3 = GetComponents<Damageable>();  // ???

        Damageable[] d4 = GetComponentsInChildren<Damageable>();
        Damageable[] d5 = GetComponentsInParent<Damageable>();

        // --------------------------------------------------------

        BoxCollider bc = target.GetComponent<BoxCollider>();
        bc.enabled = false;

        //---------------------------------------------------------


        if (d2 != null)
            Debug.Log(d2.CurrentHp);

        Debug.Log(damageables.Length);
        foreach (Damageable d in damageables)
        {
            d.CurrentHp -= 10;
        }
    }
}
