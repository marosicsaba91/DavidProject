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

        container.Clear();   // T�r�lj�k az �sszes gyermek�t

        foreach (RowData rowData in rows)   // V�gig megy�nk az �sszes adaton
        {
            VisualElement rowVE = rowPrototype.Instantiate();  // L�trehozunk egy val�di sort
            Setup(rowData, rowVE);                             // Be�ll�tjuk a sort
            container.Add(rowVE);                              // Hozz�adjuk az oszlophoz
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

    void OpenInfo(RowData rowData)  // Gombnyom�sra
    {
        Debug.Log($"OPEN: {rowData.title}   {rowData.description}");
    }
}
