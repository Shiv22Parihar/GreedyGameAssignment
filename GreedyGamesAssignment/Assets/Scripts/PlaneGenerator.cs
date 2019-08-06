using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class PlaneGenerator
{
    #region Global Variables
    public static GameObject planeGroup;
    public static GameObject containerPlane;
    public static GameObject topHalfPlane;
    public static GameObject bottomRPlane;
    public static GameObject bottomLPlane;
    public static int VisiblePercent = 100; 
    #endregion

    #region Problem Statement 1: Layout
    public static GameObject Render(Material M1, Material M2, Material M3, Material M4)
    {
        planeGroup = new GameObject("Planes");
        containerPlane = GetPlane(new Vector3(0, 0, 0), 10, 10, 1, "ContainerPlane", M1);
        topHalfPlane = GetPlane(new Vector3(0.5f, 5.5f, 0), 9, 4, 0.2f, "TopHalfPlane", M2);
        bottomRPlane = GetPlane(new Vector3(0.5f, 0.5f, 0), 4, 4, 0.4f, "BottomRPlane", M3);
        bottomLPlane = GetPlane(new Vector3(5.5f, 0.5f, 0), 4, 4, 0.6f, "BottomLPlane", M4);
        containerPlane.transform.parent = planeGroup.transform;
        topHalfPlane.transform.parent = planeGroup.transform;
        bottomLPlane.transform.parent = planeGroup.transform;
        bottomRPlane.transform.parent = planeGroup.transform;
        planeGroup.transform.Rotate(0, 180, 0, Space.World);
        // Scale Parent gameobject according to screen size
        ScaleToScreenSize(planeGroup);
        return planeGroup;
    }

    /// <summary>
    /// Scale Parent gameobject according to screen size
    /// </summary>
    private static void ScaleToScreenSize(GameObject planeGroup)
    {
        Camera.main.orthographicSize = (20.0f / Screen.width * Screen.height / 2.0f);
    }

    //Function returns a single Plane
    public static GameObject GetPlane(Vector3 origin, int width, int height, float uvIndex, string name, Material Mat)
    {
        GameObject plane = new GameObject(name);
        MeshFilter mshFilter = plane.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mshRenderer = plane.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        //mshRenderer.material.SetTexture("_Texture", T);

        Mesh m = new Mesh();

        m.vertices = new Vector3[]
            {
                origin,
                new Vector3(width,0,0) + origin,
                new Vector3(width,height,0) + origin,
                new Vector3(0,height,0) + origin
            };

        m.uv = new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0)
        };
        m.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
        mshFilter.mesh = m;
        m.RecalculateBounds();
        m.RecalculateNormals();
        plane.GetComponent<MeshRenderer>().material = Mat;
        return plane;
    }

    #endregion

    #region Problem Statement 2: Animations
    
    public static void PlayTopHalfPlaneAnim()
    {
        Animation anim = topHalfPlane.GetComponent<Animation>();

        if (anim == null)
        {
            anim = topHalfPlane.AddComponent(typeof(Animation)) as Animation; 
        }
        AnimationCurve curve;

        // create a new AnimationClip
        AnimationClip clip = new AnimationClip();
        clip.legacy = true;

        // create a curve to move the GameObject and assign to the clip
        Keyframe[] keys;
        keys = new Keyframe[4];
        keys[0] = new Keyframe(0.0f, 1);
        keys[1] = new Keyframe(0.5f, 1.035f);
        keys[2] = new Keyframe(1.5f, 0.965f);
        keys[3] = new Keyframe(2.0f, 1f);
        curve = new AnimationCurve(keys);
        clip.SetCurve("", typeof(Transform), "localScale.x", curve);
        clip.SetCurve("", typeof(Transform), "localScale.y", curve);
        clip.SetCurve("", typeof(Transform), "localScale.z", curve);

        // now animate the GameObject
        anim.AddClip(clip, clip.name);
        anim.Play(clip.name);
    }
    
    public static void PlayBottomLPlaneAnim()
    {
        int offSet = 0;
        if(bottomLPlane.transform.localPosition != Vector3.zero)
        {
            offSet = 5;
        }

        Animation anim = bottomLPlane.GetComponent<Animation>();

        if (anim == null)
        {
            anim = bottomLPlane.AddComponent(typeof(Animation)) as Animation;
        }
        AnimationCurve curve;

        // create a new AnimationClip
        AnimationClip clip = new AnimationClip();
        clip.legacy = true;

        // create a curve to move the GameObject and assign to the clip
        Keyframe[] keys;
        keys = new Keyframe[6];
        keys[0] = new Keyframe(0.0f, 0f);
        keys[1] = new Keyframe(0.5f, -0.5f);
        keys[2] = new Keyframe(1.0f, -0.5f);
        keys[3] = new Keyframe(1.5f, 0.5f);
        keys[4] = new Keyframe(2.0f, 0.5f);
        keys[5] = new Keyframe(2.5f, 0f);
        curve = new AnimationCurve(keys);
        clip.SetCurve("", typeof(Transform), "localPosition.x", curve);

        Keyframe[] newKeys;
        newKeys = new Keyframe[6];
        newKeys[0] = new Keyframe(0.0f, 0f + offSet);
        newKeys[1] = new Keyframe(0.5f, -0.5f + offSet);
        newKeys[2] = new Keyframe(1.0f, 0.5f + offSet);
        newKeys[3] = new Keyframe(1.5f, 0.5f + offSet);
        newKeys[4] = new Keyframe(2.0f, -0.5f + offSet);
        newKeys[5] = new Keyframe(2.5f, 0f + offSet);
        curve = new AnimationCurve(newKeys);
        clip.SetCurve("", typeof(Transform), "localPosition.y", curve);

        // now animate the GameObject
        anim.AddClip(clip, clip.name);
        anim.Play(clip.name);
    }

    public static void PlayBottomRPlaneAnim()
    {
        Animation anim = bottomRPlane.GetComponent<Animation>();
        if (anim == null)
        {
            anim = bottomRPlane.AddComponent(typeof(Animation)) as Animation;
        }
        AnimationCurve curve;

        // create a new AnimationClip
        AnimationClip clip = new AnimationClip();
        clip.legacy = true;

        // create a curve to move the GameObject and assign to the clip
        Keyframe[] keys;
        keys = new Keyframe[3];
        keys[0] = new Keyframe(0.0f, 0.0f);
        keys[1] = new Keyframe(1.0f, 180f);
        keys[2] = new Keyframe(2.0f, 0f);
        curve = new AnimationCurve(keys);
        
        // update the clip to a change the red color
        //curve = AnimationCurve.Linear(0.0f, 1.0f, 2.0f, 0.0f);
        clip.SetCurve("", typeof(Transform), "localEulerAnglesBaked.z", curve);

        // now animate the GameObject
        anim.AddClip(clip, clip.name);
        anim.Play(clip.name);
    }

    #endregion

    #region Problem Statement 3: Screen Visibility
    public static void ZoomIn()
    {
        if (planeGroup.transform.localScale != Vector3.zero)
        {
            planeGroup.transform.localScale = planeGroup.transform.localScale - new Vector3(0.1f, 0.1f, 0.1f);
            VisiblePercent -= 10;
        }
    }

    public static void ZoomOut()
    {
        if (planeGroup.transform.localScale != Vector3.one)
        {
            planeGroup.transform.localScale = planeGroup.transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);
            VisiblePercent += 10;
        }
    }

    public static string GetVisiblePercent()
    {
        return VisiblePercent.ToString() + "% Visible";
    }
    #endregion

    #region Problem Statement 4: Switching Plane
    /// <summary>
    /// This function switches plane top half and bottom half , also flips other way round when clicked again
    /// </summary>
    public static void FlipPlanes()
    {
        if (topHalfPlane.transform.localPosition == Vector3.zero)
        {
            topHalfPlane.transform.localPosition = new Vector3(0, -5, 0);
            bottomRPlane.transform.localPosition = new Vector3(0, 5, 0);
            bottomLPlane.transform.localPosition = new Vector3(0, 5, 0); 
        }
        else
        {
            topHalfPlane.transform.localPosition = new Vector3(0, 0, 0);
            bottomRPlane.transform.localPosition = new Vector3(0, 0, 0);
            bottomLPlane.transform.localPosition = new Vector3(0, 0, 0);
        }
    } 
    #endregion

}
