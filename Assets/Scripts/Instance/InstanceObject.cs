using UnityEngine;

public class InstanceObject : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform point;

    private void Update()
    {
        ObjectInstance();
    }

    public void ObjectInstance()
    {
        if(point != null)
        {
            Instantiate(prefab, point.position, point.rotation);
        }
        else
        {
            Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }
    }
}
