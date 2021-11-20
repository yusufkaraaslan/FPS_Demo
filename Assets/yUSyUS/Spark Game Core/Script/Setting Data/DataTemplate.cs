using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public abstract class DataTemplate: ScriptableObject
{
#if UNITY_EDITOR
    protected SerializedObject myView;
#endif

    public static float elementSpace = 5;
    public static float sectionSpace = 20;

    public abstract void DrawTap();
}
