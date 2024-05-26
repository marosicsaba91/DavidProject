using UnityEngine;
using UnityEngine.UIElements; 

class UITreeTester : MonoBehaviour
{
    [SerializeField] UIDocument doc;
    void Start()
    {
        VisualElement root = doc.rootVisualElement;
        ListVisualElements(root, 0);
    }

    void ListVisualElements(VisualElement root, int level)
    {
        Debug.Log($"{new string(' ', level * 2)}{root.name}");

        Button b;

        foreach (VisualElement child in root.Children())   
            ListVisualElements(child, level + 1);
    }
}
