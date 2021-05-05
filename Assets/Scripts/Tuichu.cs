using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuichu : MonoBehaviour
{
    public void Getout(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
