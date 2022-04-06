using UnityEngine;
using UnityEditor;

public class PlacementGenerator : MonoBehaviour
{

    [SerializeField] GameObject prefab;
    [Header("Raycast Settings")]
    [SerializeField] int density;
    [Space]
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;
    [SerializeField] Vector2 xRange;
    [SerializeField] Vector2 zRange;
    [Header("Prefab Variation Settings")]
    [SerializeField, Range (0, 1)] float rotateTowardsNormal;
    [SerializeField] Vector2 rotationRange;
    [SerializeField] Vector3 minScale;
    [SerializeField] Vector3 maxScale;

    public void Generate() {
        Clear();
        for (int i = 0; i < density; i++) {
            float sampleX = Random.Range(transform.position.x + xRange.x, transform.position.x + xRange.y);
            float sampleY = Random. Range(transform.position.z + zRange.x, transform.position.z + zRange.y);
            Vector3 raystart = new Vector3(sampleX, maxHeight, sampleY);

            if (!Physics.Raycast (raystart, Vector3.down, out RaycastHit hit, Mathf.Infinity))
                continue;

            if (hit.point.y < minHeight)
                continue;


            GameObject instantiatedPrefab = (GameObject)PrefabUtility.InstantiatePrefab(this.prefab, transform);

            instantiatedPrefab.transform.position = hit.point;
            instantiatedPrefab.transform.Rotate(Vector3.up, Random.Range(rotationRange.x, rotationRange.y), Space.Self);
            instantiatedPrefab.transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion. FromToRotation(instantiatedPrefab. transform.up, hit.normal), rotateTowardsNormal);

        }

    }

    public void Clear() {
        while (transform.childCount != 0) {
        DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}