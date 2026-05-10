using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public static Action<Item> itemClicked;

    [Header("Settings")]
    [SerializeField] private Material outlineMaterial;
    private Item currentItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleDrag();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            HandleMouseUp();
        }
    }

    private void HandleDrag()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100);

        if (hit.collider == null)
        {
            if (currentItem != null)
                currentItem.Deselect();
            currentItem = null;
            return;
        }
        if (!hit.collider.TryGetComponent(out Item item))
        {
            if (currentItem != null)
                currentItem.Deselect();
            currentItem = null;
            return;
        }
        Debug.Log("clicked: " + hit.collider.name);
        currentItem = item;
        currentItem.Select(outlineMaterial);
    }

    private void HandleMouseUp()
    {
        if (currentItem == null)
            return;

        currentItem.Deselect();
        itemClicked?.Invoke(currentItem);
        currentItem = null;
    }
}
