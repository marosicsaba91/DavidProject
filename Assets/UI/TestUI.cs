using System;
using UnityEngine;
using UnityEngine.UIElements;

public class TestUI : MonoBehaviour
{
    [SerializeField] UIDocument uiDocument;
    [SerializeField] UIDocument popup;
    [SerializeField] VisualTreeAsset rowPrototype;

    [SerializeField] RowData[] rows;

    void Start()
    {
        VisualElement container =
            uiDocument.rootVisualElement.Q<VisualElement>("Column");  // Oszlop

        container.Clear();   // Töröljük az összes gyermekét

        foreach (RowData rowData in rows)   // Végig megyünk az összes adaton
        {
            VisualElement rowVE = rowPrototype.Instantiate();  // Létrehozunk egy valódi sort
            Setup(rowData, rowVE);                             // Beállítjuk a sort
            container.Add(rowVE);                              // Hozzáadjuk az oszlophoz
        }
    }

    void Setup(RowData rowData, VisualElement rowVE)
    {
        rowVE.Q<Label>("Title").text = rowData.title;
        rowVE.Q<Label>("Description").text = rowData.description;
        Button b = rowVE.Q<Button>("Button");
        b.style.backgroundColor = rowData.color;

        b.clicked += () => OpenInfo(rowData);       // NEM VOLT!!!
    }

    void OpenInfo(RowData rowData)  // Gombnyomásra
    {
        Debug.Log($"OPEN: {rowData.title}   {rowData.description}");
    }
}
