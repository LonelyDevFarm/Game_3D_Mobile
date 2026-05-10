using UnityEngine;

public class ItemSpotsManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform itemSpot;

    [Header("Settings")]
    [SerializeField] private Vector3 itemLocalPositionOnSpot;
    [SerializeField] private Vector3 itemLocalScaleOnSpot;

    private void Awake()
    {
        InputManager.itemClicked += OnItemClicked;
    }
    private void OnDestroy()
    {
        InputManager.itemClicked -= OnItemClicked;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnItemClicked(Item item)
    {
        item.transform.SetParent(itemSpot);
        item.transform.localPosition = itemLocalPositionOnSpot;
        item.transform.localScale = itemLocalScaleOnSpot;
        item.DisableShadows();
        item.DisablePhysics();
    }
}
