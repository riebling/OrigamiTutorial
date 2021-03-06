﻿using UnityEngine;

public struct LineDrawer
{
    public LineRenderer lineRenderer;
    private float lineSize;

    public LineDrawer(float lineSize = 0.1f)
    {
        GameObject lineObj = new GameObject("LineObj");
        lineRenderer = lineObj.AddComponent<LineRenderer>();

        // but turn it off right away
        lineRenderer.enabled = false;

        //Still confusing how Materials and Resources and Shaders and Textures interact
        lineRenderer.material = new Material(Shader.Find("Particles/Standard Unlit"));

        // these get overwritten, so unnecessary(?)
        lineRenderer.startWidth = lineSize;
        lineRenderer.endWidth = lineSize;
        lineRenderer.startColor = Color.black;

        // This for some strange reason initializes a 2 element 'empty' line
        // but we want to start empty and add our own, so:
        lineRenderer.positionCount = 1; // an endpoint connected to nothing

        this.lineSize = lineSize;
    }


    private void init(float lineSize = 0.1f)
    {
        if (lineRenderer == null)
        {
            GameObject lineObj = new GameObject("LineObj");
            lineRenderer = lineObj.AddComponent<LineRenderer>();

            // but turn it off right away
            lineRenderer.enabled = false;

            // huh?
            lineRenderer.material = new Material(Shader.Find("Particles/Standard Unlit"));

            // these get overwritten, so unnecessary(?)
            lineRenderer.startWidth = lineSize;
            lineRenderer.endWidth = lineSize;
            lineRenderer.startColor = Color.black;

            // This for some strange reason initializes a 2 element 'empty' line
            // but we want to start empty and add our own, so:
            lineRenderer.positionCount = 1; // an endpoint connected to nothing

            this.lineSize = lineSize;
        }
    }

    public void AddLine(Vector3 start, Vector3 end, Color color)
    {
        if (lineRenderer == null)
        {
            init(0.2f);
        }

        //Set color
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;

        //Set width
        lineRenderer.startWidth = lineSize;
        lineRenderer.endWidth = lineSize;

        //Increment vertex count
        int count = lineRenderer.positionCount; // initially 1
        lineRenderer.positionCount = count + 1; // increment

        // There's already a default (black) line from vertex 0 to 1
        // so our first line will be from vertex 1 to 2

        //Set the postion of both two lines
        lineRenderer.SetPosition(count-1, start);
        lineRenderer.SetPosition(count, end);

        // fewer line segments; looks like a spider spinning a web
        //lineRenderer.Simplify(0.002f);
        lineRenderer.enabled = true;
    }

    public void Destroy()
    {
        if (lineRenderer != null)
        {
            UnityEngine.Object.Destroy(lineRenderer.gameObject);
        }
    }
}
