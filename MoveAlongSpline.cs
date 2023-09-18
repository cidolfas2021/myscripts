using UnityEngine;
using UnityEngine.Splines;
using System.Collections.Generic;



public class MoveAlongSpline : MonoBehaviour
{
    public SplineContainer spline;
    public GameObject treadPrefab;
    public int numberOfTreads = 50;
    public float speed = -1f;
    private float desiredSpacing = 2f; // Set your desired spacing here.

    private List<GameObject> treads = new List<GameObject>();
    private List<float> currentDistances = new List<float>();

    private float totalLength;
    public float spacing = 2f;
    //private Vector3 startingPosition = new Vector3(-26.58167f, 0.1005034f, -28.37873f);
    private float positionThreshold = 0.1f; // Adjust this threshold as needed.






    private void Start()
    {
        totalLength = spline.CalculateLength();
        RecalculateSpacing();

        for (int i = 0; i < numberOfTreads; i++)
        {
            float currentDistance = spacing * i;
            currentDistances.Add(currentDistance);

            Vector3 position = CalculatePositionOnSpline(currentDistance);
            Vector3 tangent = spline.EvaluateTangent(currentDistance);

            // Calculate the desired forward direction (negative z-axis) based on the tangent.
            Vector3 desiredForward = -tangent.normalized;

            // Calculate a rotation that aligns the forward direction with the tangent.
            Quaternion rotation = Quaternion.LookRotation(desiredForward, Vector3.up);

            // Adjust the rotation by 90 degrees around the up axis (y-axis).
            Quaternion finalRotation = rotation * Quaternion.Euler(0, 0, 0);

            GameObject tread = Instantiate(treadPrefab, position, finalRotation);
            treads.Add(tread);
            tread.transform.localScale = new Vector3(0.035f, 0.05f, 0.05f); // Adjust the scale as needed.
            tread.SetActive(false);

        }
    }

    // Calculate the position on the spline based on the distance.
    private Vector3 CalculatePositionOnSpline(float distance)
    {
        

        // Find the parameter (t) for the given distance along the spline.
        float t = distance / totalLength;

        // Evaluate the position on the spline using the parameter.
        return spline.EvaluatePosition(t);
        

    }

    private void Update()
    {
        // Check if desiredSpacing has changed and recalculate spacing if needed.
        if (spacing != desiredSpacing)
        {
            RecalculateSpacing();    
        }

        for (int i = 0; i < treads.Count; i++)
        {
            currentDistances[i] += speed * Time.deltaTime;
            if (currentDistances[i] > 0.1)
            {
                treads[i].gameObject.SetActive(true);
            }
            else if (currentDistances[i] <= 0)
            {
                treads[i].gameObject.SetActive(false);
            }
            if (currentDistances[i] > totalLength)
            {
                currentDistances[i] -= totalLength;
                // Recycle the tread to the beginning of the spline.
                Vector3 position = spline.EvaluatePosition(currentDistances[i]);
                treads[i].transform.position = position;
            }
            else
            {
                Vector3 position = spline.EvaluatePosition(currentDistances[i]);
                Vector3 tangent = spline.EvaluateTangent(currentDistances[i]);

                // Calculate a rotation that aligns the forward direction with the tangent.
                //Quaternion rotation = Quaternion.LookRotation(tangent, Vector3.up);

                // Rotate the object 90 degrees around its local right (x) axis.
                Vector3 normal = Vector3.Cross(tangent, Vector3.right).normalized;
                Quaternion rotation = Quaternion.LookRotation(tangent, normal);

                


             
                treads[i].transform.position = position;
                treads[i].transform.rotation = rotation;
                Vector3 rotationToAdd = new Vector3(90, 0, 0);
                treads[i].transform.Rotate(rotationToAdd);

                //float distanceToStart = Vector3.Distance(position, startingPosition);

                // Toggle visibility based on the distance threshold.
               // treads[i].SetActive(distanceToStart > positionThreshold);


            }

        }
    }

    public void SetTreadSpacing(float spacingValue)
    {
        desiredSpacing = spacingValue;
        RecalculateSpacing();
    }

    private void RecalculateSpacing()
    {
        // Recalculate the spacing based on the desiredSpacing.
        spacing = desiredSpacing * totalLength / (numberOfTreads - 1);
    }
}