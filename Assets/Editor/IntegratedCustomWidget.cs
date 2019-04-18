using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;

public class IntegratedCustomWidget : EditorWindow
{
    SankeyEditor sankeyEditor;
    //float baseSet = 0.0f;
    //float minOldx = -15;
    //float maxOldX = 48;
    //float minNewX = 0;
    //float maxNewX = 800;
    //float minOldY = 0;
    //float maxOldY = 10;
    //float minNewY = 200;
    //float maxNewY = 0;

    //float baseSet = 0.0f;
    //float minOldx = -14;
    //float maxOldX = 48;
    //float minNewX = 0;
    //float maxNewX = 800;
    //float minOldY = 0;
    //float maxOldY = 10;
    //float minNewY = 400;
    //float maxNewY = 200;

    private void OnGUI()
    {
        MiniatureParameters editorValues = new MiniatureParameters();
        sankeyEditor = GameObject.FindGameObjectWithTag("SKE").GetComponent<SankeyEditor>();

        Handles.BeginGUI();
        Handles.color = Color.blue;
        //Handles.DrawLine(new Vector3(0.0f, 200.0f), new Vector3(800f, 200.0f));
        // Handles.DrawLine(new Vector3(0.0f, 400.0f), new Vector3(800f, 400.0f));
        Handles.EndGUI();

        GUILayout.Space(170.0f);
        if (GUILayout.Button("Go to level 1"))
        {
            EditorSceneManager.OpenScene("Assets/Scenes/level_00.unity");
            sankeyEditor.ScanSurvivalData("TBD", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }


        GUILayout.Space(180.0f);
        if (GUILayout.Button("Go to level 2"))
        {
            EditorSceneManager.OpenScene("Assets/Scenes/level_01.unity");
            // sankeyEditor.ScanSurvivalData("TBD", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, false);
        }

        GUILayout.Space(230.0f);
        if (GUILayout.Button("Go to level 3"))
        {
            EditorSceneManager.OpenScene("Assets/Scenes/level_03.unity");
            // sankeyEditor.ScanSurvivalData("TBD", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, false);
        }
        GUILayout.Space(50.0f);
        if (GUILayout.Button("Generate Survival plots"))
        {
            sankeyEditor.ScanSurvivalDataIE("TBD", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        }
        if (GUILayout.Button("Generate Survival plot - level specific"))
        {
            //EditorSceneManager.OpenScene("Assets/Scenes/level_00.unity");
            sankeyEditor.ScanSurvivalData("TBD", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }



        //Draw Survival plot for each level on the Custom editor

        //Level 1
        if (sankeyEditor.cloneDeathLocationOnSceneIEL1.Count > 0)
        {
            float maxValueL1 = 100.0f;
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.blue;
            style.fontSize = 12;
            style.fontStyle = FontStyle.BoldAndItalic;


            float percentageL1 = (((sankeyEditor.cloneDeathLocationOnSceneIEL1.Count - 2) * 1.0f / sankeyEditor.level1CompCountIE * 1.0f) * 100.0f) / (sankeyEditor.cloneDeathLocationOnSceneIEL1.Count - 2) * 1.0f;
            editorValues.BaseSetL1 = 0.0f;

            if (sankeyEditor.level1CompCountIE != 0)
            {
                for (int i = 0; i < sankeyEditor.refinedDeathLocationOnSceneIEL1.Count - 1; i++)
                {

                    float newValueXL1 = ConvertRange(editorValues.MinOldxL1, editorValues.MaxOldXL1, editorValues.MinNewXL1, editorValues.MaxNewXL1, sankeyEditor.refinedDeathLocationOnSceneIEL1[i].x);
                    float newValueYL1 = ConvertRange(editorValues.MinOldYL1, editorValues.MaxOldYL1, editorValues.MinNewYL1, editorValues.MaxNewYL1, sankeyEditor.refinedDeathLocationOnSceneIEL1[i].y);
                    float newValueXP1L1 = ConvertRange(editorValues.MinOldxL1, editorValues.MaxOldXL1, editorValues.MinNewXL1, editorValues.MaxNewXL1, sankeyEditor.refinedDeathLocationOnSceneIEL1[i + 1].x);
                    float newValueYP1L1 = ConvertRange(editorValues.MinOldYL1, editorValues.MaxOldYL1, editorValues.MinNewYL1, editorValues.MaxNewYL1, sankeyEditor.refinedDeathLocationOnSceneIEL1[i + 1].y);

                    if (sankeyEditor.isL1CompletionNil && i == sankeyEditor.refinedDeathLocationOnSceneIEL1.Count - 3)
                    {
                        break;
                    }

                    Handles.DrawLine(new Vector3(newValueXL1, newValueYL1), new Vector3(newValueXP1L1, newValueYP1L1));

                    if (i % 2 == 0)
                    {
                        if (maxValueL1 - editorValues.BaseSetL1 > 1)
                        {
                            Handles.Label(new Vector3(newValueXL1, newValueYL1), Math.Round(maxValueL1 - editorValues.BaseSetL1, 2) + " %", style);

                            editorValues.BaseSetL1 += percentageL1;
                        }

                        if (maxValueL1 - editorValues.BaseSetL1 < 0 && !sankeyEditor.isL1CompletionNil)
                        {

                            Handles.Label(new Vector3(newValueXL1, newValueYL1), "< " + Math.Round(percentageL1, 2) + " %", style);
                        }

                    }
                }
            }
        }

        if (sankeyEditor.cloneDeathLocationOnSceneIEL2.Count > 0)
        {
            float maxValueL2 = 100;
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.blue;
            style.fontSize = 12;
            style.fontStyle = FontStyle.BoldAndItalic;


            float percentageL2 = (((sankeyEditor.cloneDeathLocationOnSceneIEL2.Count - 2) * 1.0f / sankeyEditor.level2CompCountIE * 1.0f) * 100.0f) / (sankeyEditor.cloneDeathLocationOnSceneIEL2.Count - 2) * 1.0f;
            editorValues.BaseSetL2 = 0.0f;

            if (sankeyEditor.level2CompCountIE != 0)
            {
                for (int i = 0; i < sankeyEditor.refinedDeathLocationOnSceneIEL2.Count - 1; i++)
                {

                    float newValueXL2 = ConvertRange(editorValues.MinOldxL2, editorValues.MaxOldXL2, editorValues.MinNewXL2, editorValues.MaxNewXL2, sankeyEditor.refinedDeathLocationOnSceneIEL2[i].x);
                    float newValueYL2 = ConvertRange(editorValues.MinOldYL2, editorValues.MaxOldYL2, editorValues.MinNewYL2, editorValues.MaxNewYL2, sankeyEditor.refinedDeathLocationOnSceneIEL2[i].y);
                    float newValueXP1L2 = ConvertRange(editorValues.MinOldxL2, editorValues.MaxOldXL2, editorValues.MinNewXL2, editorValues.MaxNewXL2, sankeyEditor.refinedDeathLocationOnSceneIEL2[i + 1].x);
                    float newValueYP1L2 = ConvertRange(editorValues.MinOldYL2, editorValues.MaxOldYL2, editorValues.MinNewYL2, editorValues.MaxNewYL2, sankeyEditor.refinedDeathLocationOnSceneIEL2[i + 1].y);
                    if (sankeyEditor.isL2CompletionNil && i == sankeyEditor.refinedDeathLocationOnSceneIEL2.Count - 3)
                    {
                        break;
                    }


                    Handles.DrawLine(new Vector3(newValueXL2, newValueYL2), new Vector3(newValueXP1L2, newValueYP1L2));

                    if (i % 2 == 0)
                    {
                        if (maxValueL2 - editorValues.BaseSetL2 > 1)
                        {
                            Handles.Label(new Vector3(newValueXL2, newValueYL2), Math.Round(maxValueL2 - editorValues.BaseSetL2, 2) + " %", style);

                            editorValues.BaseSetL2 += percentageL2;
                        }

                        if (maxValueL2 - editorValues.BaseSetL2 < 0 && !sankeyEditor.isL2CompletionNil)
                        {

                            Handles.Label(new Vector3(newValueXL2, newValueYL2), "< " + Math.Round(percentageL2, 2) + " %", style);
                        }

                    }
                }
            }
        }

        if (sankeyEditor.cloneDeathLocationOnSceneIEL3.Count > 0)
        {
            float maxValueL3 = 100;
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.blue;
            style.fontSize = 12;
            style.fontStyle = FontStyle.BoldAndItalic;


            float percentageL3 = (((sankeyEditor.cloneDeathLocationOnSceneIEL3.Count - 2) * 1.0f / sankeyEditor.level3CompCountIE * 1.0f) * 100.0f) / (sankeyEditor.cloneDeathLocationOnSceneIEL3.Count - 2) * 1.0f;
            editorValues.BaseSetL3 = 0.0f;

            if (sankeyEditor.level3CompCountIE != 0)
            {
                for (int i = 0; i < sankeyEditor.refinedDeathLocationOnSceneIEL3.Count - 1; i++)
                {

                    float newValueXL3 = ConvertRange(editorValues.MinOldxL3, editorValues.MaxOldXL3, editorValues.MinNewXL3, editorValues.MaxNewXL3, sankeyEditor.refinedDeathLocationOnSceneIEL3[i].x);
                    float newValueYL3 = ConvertRange(editorValues.MinOldYL3, editorValues.MaxOldYL3, editorValues.MinNewYL3, editorValues.MaxNewYL3, sankeyEditor.refinedDeathLocationOnSceneIEL3[i].y);
                    float newValueXP1L3 = ConvertRange(editorValues.MinOldxL3, editorValues.MaxOldXL3, editorValues.MinNewXL3, editorValues.MaxNewXL3, sankeyEditor.refinedDeathLocationOnSceneIEL3[i + 1].x);
                    float newValueYP1L3 = ConvertRange(editorValues.MinOldYL3, editorValues.MaxOldYL3, editorValues.MinNewYL3, editorValues.MaxNewYL3, sankeyEditor.refinedDeathLocationOnSceneIEL3[i + 1].y);

                    if (sankeyEditor.isL3CompletionNil && i == sankeyEditor.refinedDeathLocationOnSceneIEL3.Count - 3)
                    {
                        break;
                    }
                    Handles.DrawLine(new Vector3(newValueXL3, newValueYL3), new Vector3(newValueXP1L3, newValueYP1L3));

                    if (i % 2 == 0)
                    {
                        if (maxValueL3 - editorValues.BaseSetL3 > 1)
                        {
                            Handles.Label(new Vector3(newValueXL3, newValueYL3), Math.Round(maxValueL3 - editorValues.BaseSetL3, 2) + " %", style);

                            editorValues.BaseSetL3 += percentageL3;
                        }

                        if (maxValueL3 - editorValues.BaseSetL3 < 0 && !sankeyEditor.isL3CompletionNil)
                        {

                            Handles.Label(new Vector3(newValueXL3, newValueYL3), "< " + Math.Round(percentageL3, 2) + " %", style);
                        }

                    }
                }
            }
        }

    }


    public float ConvertRange(
        float originalStart, float originalEnd,
        float newStart, float newEnd,
        float value)
    {
        float scale = (newEnd - newStart) / (originalEnd - originalStart);
        return (int)(newStart + ((value - originalStart) * scale));
    }

    void TestMethod()
    {

    }

    [MenuItem("Window/IntegratedEditor")]
    public static void DisplayMyWindow()
    {
        GetWindow<IntegratedCustomWidget>();
    }
}
