using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ZTestEditor : MonoBehaviour {

    // Create a new drop-down menu in Editor named "Examples" and a new option called "Open Scene"
    [MenuItem("Examples/Open Scene")]
    static void OpenScene()
    {
        //Open the Scene in the Editor (do not enter Play Mode)
        EditorSceneManager.OpenScene("Assets/Scenes/level_03.unity");
    }
}
