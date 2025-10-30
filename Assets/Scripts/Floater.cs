/*using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rb;

    public float depthBefSub;

    public float displacementAmount;

    public int floaters;

    public float waterDrag;
    public float waterAngularDrag;

    public WaterSurface water;

    WaterSearchParameters search;//Holds parameters for water search

    WaterSearchResult SearchResult; //stores the result of the water search

    private void FixedUpdate()
    {
        rb.AddForceAtPosition(Physics.gravity / floaters, transform.position, ForceMode.Acceleration);
        search.startPositionWS = transform.position;

        water.ProjectPointOnWaterSurface(search, out SearchResult);

        if(transform.position.y < SearchResult.projectedPositionWS.y)
        {
            float displacementMulti = Mathf.Clamp01((SearchResult.projectedPositionWS.y - transform.position.y) / depthBefSub) * displacementAmount;

            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMulti, 0f), transform.position, ForceMode.Acceleration);

            rb.AddForce(displacementMulti * -rb.linearVelocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/

using UnityEngine;
using UnityEngine.Rendering.HighDefinition;


public class Floater : MonoBehaviour
{
    public Rigidbody rb;
    public float depthBefSub = 1f;
    public float displacementAmount = 3f;
    public int floaters = 1;
    public float waterDrag = 1f;
    public float waterAngularDrag = 1f;
    public WaterSurface water;

    private WaterSearchParameters search;
    private WaterSearchResult searchResult;

    void Start()
    {
        // Initialize search parameters
        search = new WaterSearchParameters();
    }

    private void FixedUpdate()
    {
        if (water == null || rb == null) return;

        // Apply gravity force distributed among floaters
        rb.AddForceAtPosition(Physics.gravity / floaters, transform.position, ForceMode.Acceleration);

        // Update search position
        search.startPositionWS = transform.position;

        // Get water surface height
        water.ProjectPointOnWaterSurface(search, out searchResult);

        float waterLevel = searchResult.projectedPositionWS.y;
        float objectHeight = transform.position.y;

        if (objectHeight < waterLevel)
        {
            // Calculate submersion factor (0 to 1)
            float submersion = Mathf.Clamp01((waterLevel - objectHeight) / depthBefSub);
            float displacementForce = submersion * displacementAmount;

            // Apply buoyancy force
            rb.AddForceAtPosition(
                new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementForce, 0f),
                transform.position,
                ForceMode.Acceleration
            );

            // Apply water drag
            rb.AddForce(
                displacementForce * -rb.linearVelocity * waterDrag * Time.fixedDeltaTime,
                ForceMode.VelocityChange
            );

            // Apply angular drag
            rb.angularVelocity *= 1f - (waterAngularDrag * submersion * Time.fixedDeltaTime);
        }
    }
}
