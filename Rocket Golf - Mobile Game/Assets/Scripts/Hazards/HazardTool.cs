using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class HazardTool : MonoBehaviour
{
    public bool rightSide = true;
    public bool leftSide = false;
    public bool generate = false;

    [SerializeField] private GameObject hazardPrefab;
    [SerializeField] private Transform[] cornerPts;

    List<GameObject> hazardObjects = new List<GameObject>();
    void Update()
    {
        if (Application.isEditor && !Application.isPlaying && generate)
            generateHazards();
    }

    private void generateHazards()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Hazard")
                DestroyImmediate(child.gameObject);
        }

        foreach (GameObject hazardObject in hazardObjects)
        {
            DestroyImmediate(hazardObject);
        }

        for (int cornerPtIndex = 0; cornerPtIndex < cornerPts.Length - 1; cornerPtIndex++)
        {
            Vector2 direction = cornerPts[cornerPtIndex + 1].position - cornerPts[cornerPtIndex].position;
            float hazardWidth = hazardPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
            float numHazards = (direction.magnitude / hazardWidth);

            Vector2 hazardVector = direction / numHazards;

            for (int i = 0; i <= numHazards; i++)
            {
                if (rightSide)
                {
                    GameObject newHazardObject = Instantiate(hazardPrefab, (Vector2)cornerPts[cornerPtIndex].position + (i * hazardVector), transform.rotation);
                    newHazardObject.transform.up = Vector2.Perpendicular(direction);

                    newHazardObject.transform.parent = gameObject.transform;
                    hazardObjects.Add(newHazardObject);
                }
                if (leftSide)
                {
                    GameObject newHazardObject = Instantiate(hazardPrefab, (Vector2)cornerPts[cornerPtIndex].position + (i * hazardVector), transform.rotation);
                    newHazardObject.transform.up = -Vector2.Perpendicular(direction);

                    newHazardObject.transform.parent = gameObject.transform;
                    hazardObjects.Add(newHazardObject);
                }
            }
        }
        
    }
}
