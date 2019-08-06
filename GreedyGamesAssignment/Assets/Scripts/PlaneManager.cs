using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneManager : MonoBehaviour
{
    #region Input Variables
    public Material M1;
    public Material M2;
    public Material M3;
    public Material M4;
    public Text VisiblePercent;
    #endregion

    #region Unity Methods

    void Start()
    {
        PlaneGenerator.Render(M1, M2, M3, M4);
    } 

    #endregion

    #region Calling Functions
    public void FlipPlanes()
    {
        PlaneGenerator.FlipPlanes();
    }

    public void ZoomIn()
    {
        PlaneGenerator.ZoomIn();
        UpdateVisibleText();
    }

    public void ZoomOut()
    {
        PlaneGenerator.ZoomOut();
        UpdateVisibleText();
    }

    void UpdateVisibleText()
    {
        VisiblePercent.gameObject.SetActive(true);
        VisiblePercent.text = PlaneGenerator.GetVisiblePercent();
        Invoke("InactiveVisibleText", 2);
    }

    void InactiveVisibleText()
    {
        VisiblePercent.gameObject.SetActive(false);
    }

    public void StartAnimations()
    {
        TopHalfPlaneAnim();
    }

    public void TopHalfPlaneAnim()
    {
        PlaneGenerator.PlayTopHalfPlaneAnim();
        Invoke("BottomRPlaneAnim", 3);
    }

    public void BottomRPlaneAnim()
    {
        PlaneGenerator.PlayBottomRPlaneAnim();
        Invoke("BottomLPlaneAnim", 3);
    }

    public void BottomLPlaneAnim()
    {
        PlaneGenerator.PlayBottomLPlaneAnim();
    }

    #endregion
}
