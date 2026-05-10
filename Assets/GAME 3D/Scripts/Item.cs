using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class Item : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Renderer renderer;

    private Material basisMaterial;

    private void Awake()
    {
        basisMaterial = renderer.material;
    }
    public void DisableShadows()
    {

    }

    public void DisablePhysics()
    {
/*         rig.isKinematic = true;
        col.enabled = false; */
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<SphereCollider>().enabled = false;
    }

    public void Select(Material outlineMaterial)
    {
        renderer.materials = new Material[] { basisMaterial, outlineMaterial };
    }

    public void Deselect()
    {
        renderer.materials = new Material[] { basisMaterial };
    }
}