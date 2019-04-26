using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System;
using System.Timers;
using System.Collections;
using System.Linq;
using System.Globalization;
using BayatGames.SaveGamePro.Examples;
using UnityEditor.SceneManagement;

public class ControlWidget : EditorWindow
{
    int tempVal = 0;
    int tempMarker = 0;
    int tempCounter = 0;
    int selectedTab = 0;
    bool readOnce;
    bool startQuery = false;
    string requiredAssignments;
    int maximumAssignments;
    int completedAssignments;
    public string[] toolbarStrings = new string[] { "User Tests", "Damage Proportions", "Player Trajectories", "Game Status", "Milestones Mapper", "Test History", "Playtest Log", "Save Game", "Level Management" };

    public static bool playTestOption = false;
    SankeyEditor sankeyEditor;
    EditorHeatMapGenerator editorPlayerTrajectoryGenrator;
    bool loadDataFromDB = false;

    Timer timer;

    string line;
    string file = "HITsData.txt";
    string readTestSerialFile = "readTestSerialIds.txt";
    string readHITsFile = "ApproveCurrentHIT.txt";
    string readCurrentHitStatus = "CurrentHITStatus.txt";
    //Local paths
    string createHITspath = @"C:\Users\Pratheep\Desktop\nodedoc.bat";
    string approveHITspath = @"C:\Users\Pratheep\Desktop\nodeApprove.bat";
    string statusHITspath = @"C:\Users\Pratheep\Desktop\nodeHITstatus.bat";
    string deleteHITspath = @"C:\Users\Pratheep\Desktop\nodeHITdelete.bat";

    int parseIndexHits = 5;
    int parseMaxAssignmentsIndex = 1;
    int parseAvailableAssignmentsIndex = 3;
    int parseHITStatusIndex = 4;
    string hitStatuspath = "";
    string hitCurrentStatus;
    string[] lines;

    float progressPercentage = 0.0f;
    float gameCompletionProgress = 0.0f;
    int testIdVisualization;


    List<string> myFileData = new List<string>();

    //Progress Gauge Values
    int maximumAssignmentsProvided;
    int AssignmentsAvailableNow;

    bool isTestInProgress = false;
    bool genMapValues = false;

    string statusMessage = "";

    //Variables for visualization module
    float sawDamage = 0.0f;
    float acidDamage = 0.0f;
    float dangerousSubstancesDamage = 0.0f;
    float spikesDamage = 0.0f;
    float electricArcDamage = 0.0f;

    DynamoDB.Dynode dynode;
    DynamoDB.DDBHTTP httpCalls;
    int testIdDB = 0;
    string HITId;
    public string key;
    public string secret;

    //Toggle management
    int currentIndex;
    int totalRunIdsCount;

    //Toggle management for testhistory;

    int testHistoryCurrentIndex;
    int testHistoryTotalTestIds;
    int totalTestIdsCount;

    int testHistoryCurrentRunIdIndex;
    int testHistoryTotalRunIds;

    SaveGameObject sgo;
    AWSBucket awsBucket;

    void OnGUI()
    {

        sankeyEditor = GameObject.FindGameObjectWithTag("SKE").GetComponent<SankeyEditor>();
        editorPlayerTrajectoryGenrator = GameObject.FindGameObjectWithTag("HEM").GetComponent<EditorHeatMapGenerator>();
        selectedTab = GUILayout.Toolbar(selectedTab, toolbarStrings);
        sgo = GameObject.FindGameObjectWithTag("SGO").GetComponent<SaveGameObject>();
        awsBucket = GameObject.FindGameObjectWithTag("AWS").GetComponent<AWSBucket>();

        //############# Tab 1 USER TESTS ############################

        if (selectedTab == 0)
        {
            if (GUILayout.Button("Survival Plot"))
            {
                Debug.Log(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
             //   sankeyEditor.ScanSurvivalData("TBD", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
          
            }

            GUILayout.Label("User Test Options", EditorStyles.boldLabel);
            //
            GUILayout.Space(20f);
            requiredAssignments = EditorGUILayout.TextField("Required assignments", requiredAssignments);
            //GUILayout.Space(10f);
            //maximumAssignments = EditorGUILayout.TextField("Maximum assignments", maximumAssignments);
            GUILayout.Space(10f);
            if (GUILayout.Button("Launch Test"))
            {
                if (!isTestInProgress)
                {
                    isTestInProgress = true;
                    readOnce = true;


                    // Load the test serialID from disk
                    // Store it as params to HIT creation log

                    ReadWriteTestSerialIds();
                    progressPercentage = 0;


                    ////Post HIT
                    Debug.Log("Test Launched");

                    ////Query AWS SDK and Post the HIT to MTurk 
                    ExecuteHITCreationScript(createHITspath);


                    //// Write the details of created HIT - Specifically HIT-ID
                    WriteHITDetails();


                    //Initial DynamoDB Gameobject for Http calls
                    InitDynamoDB();
                    if (dynode == null)
                        Debug.Log("dynode is null");

                    ////Trigger the HIT details to DynamoDB - Mturk Test Details table
                    dynode.SendMturkTestDetails(testIdDB.ToString(), requiredAssignments, maximumAssignments.ToString(), HITId, httpCalls);

                    ////Enable this block while testing
                    //dynode.SendMturkTestDetails(testIdDB.ToString(), requiredAssignments, maximumAssignments.ToString(), "TBC", httpCalls);

                    //Start auto-updaters
                    InitiateTimers();
                }
            }


            GUILayout.Space(20f);

            if (GUILayout.Button("Approve HITs"))
            {
                ExecuteHITCreationScript(approveHITspath);
                statusMessage = "HITs Approved";
                Debug.Log("HITs Approved");
                //Write a function to Approve a HIT
            }

            GUILayout.Space(20f);

            //if (GUILayout.Button("Cancel Test"))
            //{
            //    ExecuteHITCreationScript(deleteHITspath);
            //    Debug.Log("Deleted current HIT");
            //}

            GUILayout.Space(20f);

            if (GUILayout.Button("Reset Values"))
            {
                if (timer != null)
                    timer.Stop();

                sankeyEditor.deathLocationsClear();
                sankeyEditor.collectedTrapTraces.Clear();
                completedAssignments = 0;
                progressPercentage = 0;
                requiredAssignments = "0";
                maximumAssignments = 0;
                isTestInProgress = false;
                statusMessage = "";
                sankeyEditor.gameStatusCount = 0;
            }

            GUILayout.Space(20f);

            // progressPercentage = AssignmentsProgressCalculator();

            //Debug.Log(progressPercentage);
            if (float.IsNaN(progressPercentage) || progressPercentage == 0)
            {
                EditorGUI.ProgressBar(new Rect(3, 300, position.width - 6, 20), 0.0f, " Test Progress - " + 0 + " %"
                    + "    " + "Completed (" + "0" + "/" + requiredAssignments + ")");
            }
            else
            {
                if (completedAssignments <= Int32.Parse(requiredAssignments))
                {
                    EditorGUI.ProgressBar(new Rect(3, 300, position.width - 6, 20), progressPercentage / 100.0f, " Test Progress - " + Math.Round(progressPercentage) + " %"
                        + "    " + "Completed (" + completedAssignments + "/" + requiredAssignments + ")");
                }
            }


            GUILayout.Space(30.0f);

            //EditorGUILayout.TextField("Total Test Participants", "10");


            GUILayout.Space(70.0f);


            EditorGUILayout.TextField("Status", statusMessage);

        }

        //############# Tab 2 DAMAGE PROPORTIONS ############################

        if (selectedTab == 1)
        {

            GUILayout.Label("Damage Proportions", EditorStyles.boldLabel);
            GUILayout.Space(10.0f);

            //Button 1 - Load data
            if (GUILayout.Button("Generate Damage Proportions - (View on scene)"))
            {

                loadDataFromDB = true;
                if (loadDataFromDB)
                {
                    loadDataFromDB = false;
                    sankeyEditor.cloneCollectedTrapTraces.Clear();
                    sankeyEditor.emptyListForDeathMarkers();
                    //Debug.Log("Loading data...");
                    sankeyEditor.ScanByTrap(testIdVisualization.ToString());
                    sankeyEditor.ScanByProportions(testIdVisualization.ToString());
                    // ResetValues();  
                }
            }


            GUILayout.Space(10.0f);
            //Button 2 - Generate Map
            if (GUILayout.Button("Generate Death Markers - (View on scene)"))
            {

                sankeyEditor.emptyListForTrapTraces();
                sankeyEditor.ScanGameStatus(testIdVisualization.ToString(), true);
                ComputeDeathTrapsProportion();
                // sankeyEditor.ZtempDeathMarkers();
            }

            GUILayout.Space(10.0f);

            if (GUILayout.Button("Generate Damage Flow - (View on scene)"))
            {
                sankeyEditor.emptyListForTrapTraces();

                //Uncomment this line
                // sankeyEditor.ScanDamageFlow(testIdVisualization.ToString());
            }

            GUILayout.Space(20.0f);


            GUILayout.Label("Death Traps Damage Proportions", EditorStyles.boldLabel);
            DamageProportionsConditionalCheckGUI();

            GUILayout.Space(140.0f);

            if (GUILayout.Button("Reset Values"))
            {
                ResetValues();
                sankeyEditor.emptyList();
            }

            GUILayout.Space(20.0f);

            EditorGUILayout.TextField("TestID", testIdVisualization.ToString(), GUILayout.Width(300));

            GUILayout.Space(20.0f);


            if (GUILayout.Button("Load testID"))
            {
                testIdVisualization = CountLines(readTestSerialFile);
                tempVal = testIdVisualization;

            }
            GUILayout.Space(10.0f);
            GUILayout.BeginHorizontal("box");
            if (GUILayout.Button("< Load Previous", GUILayout.Width(200)))
            {
                if (testIdVisualization <= tempVal)
                {
                    testIdVisualization -= 1;
                    tempMarker = testIdVisualization;
                }
            }

            if (GUILayout.Button("Load Next >", GUILayout.Width(200)))
            {
                if (testIdVisualization < tempVal)
                {
                    testIdVisualization += 1;
                    tempMarker = testIdVisualization;
                }
            }

            if (GUILayout.Button("Set", GUILayout.Width(200)))
            {
                testIdVisualization = tempMarker;
            }
            GUILayout.EndHorizontal();
        }

        //############# Tab 3 PLAYER TRAJEcTORIES ############################

        if (selectedTab == 2)
        {
            string visualsUpdateStatus;
            string totalRunIdsStatus;
            GUILayout.Space(20.0f);

            if (GUILayout.Button("Load Data", GUILayout.Width(100)))
            {
                editorPlayerTrajectoryGenrator.runIDs.Clear();
                editorPlayerTrajectoryGenrator.ScanGameStatusTable(testIdVisualization.ToString());
            }

            GUILayout.Space(20.0f);

            if (GUILayout.Button("View Trajectory", GUILayout.Width(100)))
            {
                editorPlayerTrajectoryGenrator.playerTraces.Clear();
                totalRunIdsCount = editorPlayerTrajectoryGenrator.runIDs.Count();


                if (totalRunIdsCount != 0)
                    editorPlayerTrajectoryGenrator.ScanByRunId(editorPlayerTrajectoryGenrator.runIDs[totalRunIdsCount - totalRunIdsCount]);
            }

            GUILayout.Space(20.0f);

            GUILayout.Label("Total player trajectories collected in this test", EditorStyles.boldLabel);

            GUILayout.Space(20.0f);

            if (totalRunIdsCount > 0)
            {

                visualsUpdateStatus = (currentIndex + 1).ToString() + "/" + totalRunIdsCount.ToString();
                totalRunIdsStatus = totalRunIdsCount.ToString();
            }

            else
            {
                visualsUpdateStatus = "";
                totalRunIdsStatus = "";
            }

            EditorGUILayout.TextField(totalRunIdsStatus, GUILayout.Width(200));

            GUILayout.Space(20.0f);


            EditorGUILayout.TextField("You are viewing", visualsUpdateStatus);

            GUILayout.Space(20.0f);

            GUILayout.Label("View player trajectories on scene", EditorStyles.boldLabel);

            GUILayout.Space(10.0f);

            GUILayout.BeginHorizontal("box");

            if (GUILayout.Button("< View Previous", GUILayout.Width(200)))
            {
                editorPlayerTrajectoryGenrator.emptyList();
                //sankeyEditor.generateDamageProportion = true;
                if (currentIndex <= 0)
                    currentIndex = 0;
                else
                    currentIndex -= 1;

                //Debug.Log("current index value " + currentIndex);
                editorPlayerTrajectoryGenrator.ScanByRunId(editorPlayerTrajectoryGenrator.runIDs[currentIndex]);
            }

            if (GUILayout.Button("View Next >", GUILayout.Width(200)))
            {

                editorPlayerTrajectoryGenrator.emptyList();
                //sankeyEditor.generateDamageProportion = true;
                if (currentIndex >= totalRunIdsCount - 1)
                    currentIndex = 0;
                else
                    currentIndex += 1;

                editorPlayerTrajectoryGenrator.ScanByRunId(editorPlayerTrajectoryGenrator.runIDs[currentIndex]);
            }

            GUILayout.EndHorizontal();

            GUILayout.Space(20.0f);

            if (GUILayout.Button("View consolidated player trajectories"))
            {
                //editorPlayerTrajectoryGenrator.playerTrajectoriesDict.Clear();
                //editorPlayerTrajectoryGenrator.playerTrajectories.Clear();
                //editorPlayerTrajectoryGenrator.individualTelemetry.Clear();
                //editorPlayerTrajectoryGenrator.individualTelemetryFinal.Clear();
                //editorPlayerTrajectoryGenrator.runIDs.Clear();
                Debug.Log("Test ID visualization " + testIdVisualization.ToString());
                sankeyEditor.ScanGameStatus(testIdVisualization.ToString(), true);
                //Scan the death traps here as well
                editorPlayerTrajectoryGenrator.ScanAllRunIdsByTestSerialId(testIdVisualization.ToString());

            }
            GUILayout.Space(20.0f);
            if (GUILayout.Button("Clear Data"))
            {
                sankeyEditor.deathLocationsClear();
                sankeyEditor.deathLocationOnScene.Clear();
                editorPlayerTrajectoryGenrator.emptyList();
                currentIndex = 0;
                totalRunIdsCount = 0;
            }
        }



        //############# Tab 4 GAME STATUS ############################

        if (selectedTab == 3)
        {
            GUILayout.Space(10.0f);
            if (GUILayout.Button("Load Data"))
            {
                sankeyEditor.emptyList();
                sankeyEditor.ScanGameStatusBasedOnTestSerialId(testIdVisualization.ToString(), true);
            }


            GUILayout.Space(10.0f);
            GUILayout.Label("Game Completion Ratio", EditorStyles.boldLabel);


            if (float.IsNaN(ComputeGameCompletionRatio()) || ComputeGameCompletionRatio() == 0)
                EditorGUI.ProgressBar(new Rect(3, 90, position.width - 6, 20), 0.0f, 0 + " %");
            else
                EditorGUI.ProgressBar(new Rect(3, 90, position.width - 6, 20), ComputeGameCompletionRatio(), Mathf.RoundToInt(ComputeGameCompletionRatio() * 100.0f) + " %");

            GUILayout.Space(50.0f);

            if (float.IsNaN(ComputeLevelProgression()) || ComputeLevelProgression() == 0)
                EditorGUILayout.TextField("Average Level Progress", "");
            else
                EditorGUILayout.TextField("Average Level Progress", ComputeLevelProgression().ToString("n2"));

            GUILayout.Space(20.0f);

            if (float.IsNaN(ComputeAverageGameplayDuration()) || ComputeAverageGameplayDuration() == 0)
                EditorGUILayout.TextField("Average Gameplay Duration", "");
            else
                EditorGUILayout.TextField("Average Gameplay Duration", Mathf.RoundToInt(ComputeAverageGameplayDuration()) + " Seconds");


            GUILayout.Space(90.0f);



            if (GUILayout.Button("Reset Values"))
            {
                sankeyEditor.emptyList();
            }

        }

        //############# Tab 5 MILESTONES MANAGER ############################

        if (selectedTab == 4)
        {
            GUILayout.Space(20.0f);

            if (GUILayout.Button("load values"))
            {
                editorPlayerTrajectoryGenrator.milestonesStatus.Clear();
                editorPlayerTrajectoryGenrator.clearMilestonesRatio();

                editorPlayerTrajectoryGenrator.ScanMilestonesStatusBasedOnTestSerialId(testIdVisualization.ToString());

            }

            if (float.IsNaN(editorPlayerTrajectoryGenrator.m1) || editorPlayerTrajectoryGenrator.m1 == 0)
                EditorGUI.ProgressBar(new Rect(3, 90, position.width - 6, 20), 0.0f, 0 + " %");
            else
                EditorGUI.ProgressBar(new Rect(3, 90, position.width - 6, 20), editorPlayerTrajectoryGenrator.m1 / 100.0f, "Milestone 1 - " + Mathf.RoundToInt(editorPlayerTrajectoryGenrator.m1) + " %");

            if (float.IsNaN(editorPlayerTrajectoryGenrator.m2) || editorPlayerTrajectoryGenrator.m2 == 0)
                EditorGUI.ProgressBar(new Rect(3, 120, position.width - 6, 20), 0.0f, 0 + " %");
            else
                EditorGUI.ProgressBar(new Rect(3, 120, position.width - 6, 20), editorPlayerTrajectoryGenrator.m2 / 100.0f, "Milestone 2 - " + Mathf.RoundToInt(editorPlayerTrajectoryGenrator.m2) + " %");

            GUILayout.Space(200.0f);
            if (GUILayout.Button("Reset values"))
            {
                editorPlayerTrajectoryGenrator.milestonesStatus.Clear();
                editorPlayerTrajectoryGenrator.clearMilestonesRatio();


            }

        }

        //############# Tab 6 TEST HISTORY ############################


        if (selectedTab == 5)
        {
            GUILayout.Space(10.0f);

            if (GUILayout.Button("Load Data"))
            {
                sankeyEditor.totalTestIDs.Clear();
                sankeyEditor.ScanMTurkTestIDs();

            }
            totalTestIdsCount = sankeyEditor.totalTestIDs.Count;
            GUILayout.Space(10.0f);

            EditorGUILayout.TextField("Total tests conducted", totalTestIdsCount.ToString());

            GUILayout.Space(10.0f);

            string visualUpdateTestIds;
            // string totalIdsStatus;
            if (totalTestIdsCount > 0)
            {

                visualUpdateTestIds = (testHistoryCurrentIndex + 1).ToString() + "/" + totalTestIdsCount.ToString();
                //totalIdsStatus = totalRunIdsCount.ToString();
            }

            else
            {
                visualUpdateTestIds = "";
                //totalIdsStatus = "";
            }


            EditorGUILayout.TextField("You are viewing", visualUpdateTestIds);

            GUILayout.Space(10.0f);

            GUILayout.BeginHorizontal("box");

            if (GUILayout.Button("< View Previous", GUILayout.Width(200)))
            {
                if (testHistoryCurrentIndex <= 0)
                    testHistoryCurrentIndex = 0;
                else
                    testHistoryCurrentIndex -= 1;

                editorPlayerTrajectoryGenrator.runIDs.Clear();
                editorPlayerTrajectoryGenrator.ScanGameStatusTable(sankeyEditor.totalTestIDs[testHistoryCurrentIndex]);


            }

            if (GUILayout.Button("View Next >", GUILayout.Width(200)))
            {
                if (testHistoryCurrentIndex >= totalTestIdsCount - 1)
                    testHistoryCurrentIndex = 0;
                else
                    testHistoryCurrentIndex += 1;

                editorPlayerTrajectoryGenrator.runIDs.Clear();
                editorPlayerTrajectoryGenrator.ScanGameStatusTable(sankeyEditor.totalTestIDs[testHistoryCurrentIndex]);

            }

            if (GUILayout.Button("Load", GUILayout.Width(200)))
            {
                testHistoryTotalRunIds = editorPlayerTrajectoryGenrator.runIDs.Count();
            }



            GUILayout.EndHorizontal();

            GUILayout.Space(10.0f);

            // EditorGUILayout.TextField("Total Test participants", "20");

            GUILayout.Space(10.0f);

            if (GUILayout.Button("View Damage Proportions"))
            {
                loadDataFromDB = true;
                if (loadDataFromDB)
                {
                    loadDataFromDB = false;
                    sankeyEditor.emptyListForTrapTraces();
                    sankeyEditor.cloneCollectedTrapTraces.Clear();
                    sankeyEditor.emptyListForDeathMarkers();
                    Debug.Log("Loading data...");
                    sankeyEditor.ScanByTrap(sankeyEditor.totalTestIDs[testHistoryCurrentIndex]);
                    sankeyEditor.ScanByProportions(sankeyEditor.totalTestIDs[testHistoryCurrentIndex]);
                    // ResetValues();  
                }
            }

            GUILayout.Space(10.0f);

            if (GUILayout.Button("View Death Markers"))
            {
                sankeyEditor.emptyListForDeathMarkers();
                sankeyEditor.emptyListForTrapTraces();
                sankeyEditor.ScanGameStatus(sankeyEditor.totalTestIDs[testHistoryCurrentIndex], true);

            }

            GUILayout.Space(10.0f);

            GUILayout.Label("Individual Gameplay Details", EditorStyles.boldLabel);

            GUILayout.Space(10.0f);



            GUILayout.Label("Total Player Trajectories recorded", EditorStyles.boldLabel);

            GUILayout.Space(5.0f);

            EditorGUILayout.TextField(testHistoryTotalRunIds.ToString());

            GUILayout.Space(10.0f);

            string testHistoryRunIdVisualStatus = "";

            if (testHistoryTotalRunIds > 0)
            {

                testHistoryRunIdVisualStatus = (testHistoryCurrentRunIdIndex + 1).ToString() + "/" + testHistoryTotalRunIds.ToString();
            }

            else
            {
                testHistoryRunIdVisualStatus = "";

            }



            EditorGUILayout.TextField("You are viewing", testHistoryRunIdVisualStatus);

            GUILayout.Space(10.0f);

            GUILayout.BeginHorizontal("box");

            if (GUILayout.Button("< View Previous", GUILayout.Width(200)))
            {
                editorPlayerTrajectoryGenrator.emptyList();
                //sankeyEditor.generateDamageProportion = true;
                if (testHistoryCurrentRunIdIndex <= 0)
                    testHistoryCurrentRunIdIndex = 0;
                else
                    testHistoryCurrentRunIdIndex -= 1;

                //Debug.Log("current index value " + currentIndex);
                editorPlayerTrajectoryGenrator.ScanByRunId(editorPlayerTrajectoryGenrator.runIDs[testHistoryCurrentRunIdIndex]);

            }

            if (GUILayout.Button("View Next >", GUILayout.Width(200)))
            {
                editorPlayerTrajectoryGenrator.emptyList();
                //sankeyEditor.generateDamageProportion = true;
                if (testHistoryCurrentRunIdIndex >= testHistoryTotalRunIds - 1)
                    testHistoryCurrentRunIdIndex = 0;
                else
                    testHistoryCurrentRunIdIndex += 1;

                editorPlayerTrajectoryGenrator.ScanByRunId(editorPlayerTrajectoryGenrator.runIDs[testHistoryCurrentRunIdIndex]);

            }

            GUILayout.EndHorizontal();

            GUILayout.Space(10.0f);

            if (GUILayout.Button("Clear Data"))
            {
                testHistoryCurrentIndex = 0;
                testHistoryTotalTestIds = 0;
                sankeyEditor.totalTestIDs.Clear();
                testHistoryTotalRunIds = 0;
                testHistoryCurrentRunIdIndex = 0;
                editorPlayerTrajectoryGenrator.emptyList();
            }

        }
        ////############# Tab 6 TEST HISTORY ############################

        GUILayout.Space(10.0f);
        if (selectedTab == 6)
        {

            if (GUILayout.Button("Generate Data"))
            {
                editorPlayerTrajectoryGenrator.runIDs.Clear();
                editorPlayerTrajectoryGenrator.discontinuedGameplays.Clear();
                editorPlayerTrajectoryGenrator.ScanGameStatusTable(testIdVisualization.ToString());
                editorPlayerTrajectoryGenrator.clearEntryLog();
                editorPlayerTrajectoryGenrator.ScanEntryLog(testIdVisualization.ToString());
            }

            GUILayout.Space(10.0f);

            GUILayout.Label("Discontinued gameplays - (run IDs)", EditorStyles.boldLabel);
            GUILayout.Space(10.0f);

            if (editorPlayerTrajectoryGenrator.discontinuedGameplays.Count > 0)
            {
                for (int i = 0; i < editorPlayerTrajectoryGenrator.discontinuedGameplays.Count; i++)
                {
                    GUILayout.Label(editorPlayerTrajectoryGenrator.discontinuedGameplays[i], EditorStyles.label);
                    GUILayout.Space(10.0f);
                }
            }

            else
            {
                GUILayout.Label("No entries found", EditorStyles.label);
            }

            GUILayout.Space(10.0f);

            if (GUILayout.Button("Reset"))
            {
                editorPlayerTrajectoryGenrator.discontinuedGameplays.Clear();//.clearEntryLog();


            }
        }
        ////############# Tab 7 TEST HISTORY ############################


        if (selectedTab == 7)
        {
            playTestOption = true;
            GUILayout.Space(10.0f);

            if (GUILayout.Button("Save Data"))
            {

                sgo.Save();
                awsBucket.PostFileToS3Bucket();
                //Debug.Log("Data posted to s3!");
            }
        }

        ////############# Tab 8 Level Management ############################
        if (selectedTab == 8)
        {
            GUILayout.Space(40.0f);

            if (GUILayout.Button("Go to level 1"))
            {
                Handles.BeginGUI();
                // Handles.DrawRectangle();//.DrawWireCube(new Vector3(1,1,1),new Vector3(3,3,3));//.DrawLine(new Vector3(0.0f, 0.0f),new Vector3(6.0f,6.0f));
                Handles.EndGUI();
                EditorSceneManager.OpenScene("Assets/Scenes/level_00.unity");
                Debug.Log(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            }

            GUILayout.Space(40.0f);
            if (GUILayout.Button("Go to level 2"))
            {
                EditorSceneManager.OpenScene("Assets/Scenes/level_01.unity");
            }

            GUILayout.Space(40.0f);
            if (GUILayout.Button("Go to level 3"))
            {
                EditorSceneManager.OpenScene("Assets/Scenes/level_03.unity");
            }
        }
    }


    float ComputeGameCompletionRatio()
    {
        // Gather the total 
        float testVal = 0;

        for (int i = 0; i < sankeyEditor.gameStatusDetails.Count; i++)
        {
            if (sankeyEditor.gameStatusDetails[i].CompletionRatio == "Complete")
            {
                testVal += 1;
            }
        }
        return testVal / (sankeyEditor.gameStatusDetails.Count * 1.0f);
    }

    float ComputeLevelProgression()
    {
        float tempVal = 0;

        for (int i = 0; i < sankeyEditor.gameStatusDetails.Count; i++)
        {
            tempVal += float.Parse(sankeyEditor.gameStatusDetails[i].LevelProgression, CultureInfo.InvariantCulture);
        }

        return tempVal / sankeyEditor.gameStatusDetails.Count;
    }

    float ComputeAverageGameplayDuration()
    {
        float tempVar = 0;

        for (int i = 0; i < sankeyEditor.gameStatusDetails.Count; i++)
        {
            tempVar += float.Parse(sankeyEditor.gameStatusDetails[i].GameplayDuration, CultureInfo.InvariantCulture);
        }

        return tempVar / sankeyEditor.gameStatusDetails.Count;
    }


    void DamageProportionsConditionalCheckGUI()
    {
        if (float.IsNaN(sawDamage) || sawDamage == 0)
            EditorGUI.ProgressBar(new Rect(3, 180, position.width - 6, 17), 0, "Saw - " + 0 + " %");
        else
            EditorGUI.ProgressBar(new Rect(3, 180, position.width - 6, 17), sawDamage, "Saw - " + Math.Round(sawDamage * 100.0f, 2) + " %");

        if (float.IsNaN(spikesDamage) || spikesDamage == 0)
            EditorGUI.ProgressBar(new Rect(3, 210, position.width - 6, 17), spikesDamage, "Spikes - " + 0 + " %");
        else
            EditorGUI.ProgressBar(new Rect(3, 210, position.width - 6, 17), spikesDamage, "Spikes - " + Math.Round(spikesDamage * 100.0f, 2) + " %");

        if (float.IsNaN(acidDamage) || acidDamage == 0)
            EditorGUI.ProgressBar(new Rect(3, 240, position.width - 6, 17), acidDamage, "Acid - " + 0 + " %");
        else
            EditorGUI.ProgressBar(new Rect(3, 240, position.width - 6, 17), acidDamage, "Acid - " + Math.Round(acidDamage * 100.0f, 2) + " %");
    }

    void ResetValues()
    {
        sawDamage = 0.0f;
        acidDamage = 0.0f;
        dangerousSubstancesDamage = 0.0f;
        spikesDamage = 0.0f;
        electricArcDamage = 0.0f;
    }


    void ComputeDeathTrapsProportion()
    {
        float tSaw = 0.0f;
        float tSpikes = 0.0f;
        float tAcid = 0.0f;
        float tDs = 0.0f;
        float tElectric = 0.0f;

        int totalCount = sankeyEditor.cloneCollectedTrapTraces.Count;

        for (int i = 0; i < totalCount; i++)
        {

            switch (sankeyEditor.cloneCollectedTrapTraces[i].TrapName)
            {
                case "Saw":
                    tSaw += 1;
                    break;

                case "Spikes":
                    tSpikes += 1;
                    break;

                case "Acid":
                    tAcid += 1;
                    break;

                case "DangerousSubstances":
                    tDs += 1;
                    break;

                case "ElectricArc":
                    tElectric += 1;
                    break;
            }
        }

        sawDamage = tSaw / (totalCount * 1.0f);
        spikesDamage = tSpikes / (totalCount * 1.0f);
        acidDamage = tAcid / (totalCount * 1.0f);
        dangerousSubstancesDamage = tDs / (totalCount * 1.0f);
        electricArcDamage = tElectric / (totalCount * 1.0f);

    }



    void WriteHITDetails()
    {
        myFileData.Clear();
        ReadFromTXTFile(file);

        using (StreamWriter writetext = new StreamWriter("ApproveCurrentHIT.txt"))
        {
            HITId = myFileData[myFileData.Count - 1];
            writetext.Write(myFileData[myFileData.Count - 1]);
        }
    }


    void ReadFromTXTFile(string readFromFile)
    {
        //Debug.Log("Read from TXT started..");
        StreamReader sr = new StreamReader(readFromFile);
        while (sr.EndOfStream == false)
        {
            line = sr.ReadLine();
            lines = line.Split(' ');
            //Debug.Log(lines[5]);
            myFileData.Add(lines[parseIndexHits]);
        }
        sr.Close();
    }

    void ReadFromFileHITStatus(string filename)
    {
        // Debug.Log("Entered HIT status Part in Read from TXT file");
        StreamReader sr = new StreamReader(filename);
        while (sr.EndOfStream == false)
        {
            line = sr.ReadLine();
            lines = line.Split(' ');
            maximumAssignmentsProvided = Int32.Parse(lines[parseMaxAssignmentsIndex]);
            AssignmentsAvailableNow = Int32.Parse(lines[parseAvailableAssignmentsIndex]);
            hitCurrentStatus = lines[parseHITStatusIndex];

            // insert a condition to check if assignmentsavailable == 0 
            Debug.Log("Max Assignments " + maximumAssignmentsProvided + " " + " Assignments available " + AssignmentsAvailableNow);
        }
        sr.Close();
    }

    void InitiateTimers()
    {
        timer = new Timer();
        timer.Interval = 5000;
        timer.Enabled = true;
        timer.Elapsed += timer_Elapsed;
        timer.Start();
    }

    void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        startQuery = true;
    }

    float AssignmentsProgressCalculator()
    {
        if (sankeyEditor.gameStatusCount != 0)
        {
            float finalValue = (((sankeyEditor.gameStatusCount * 1.0f) / float.Parse(requiredAssignments, CultureInfo.InvariantCulture.NumberFormat)) * 100.0f);
            return finalValue;
        }
        else
        {
            return 0.0f;
        }

    }


    void ExecuteHITCreationScript(string exePath)
    {
        System.Diagnostics.Process process = new System.Diagnostics.Process
        {
            StartInfo =
                        {
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            CreateNoWindow = true,
                            FileName = "cmd.exe",
                            Arguments = "/c " + exePath
                        }
        };
        process.Start();
        process.WaitForExit();
        if (process.HasExited)
        {
            string output = process.StandardOutput.ReadToEnd();
        }
    }

    [MenuItem("Window/ARAPID System - Control Widget")]
    public static void DisplayWindow()
    {
        GetWindow<ControlWidget>("Control Widget");

    }



    public void OnInspectorUpdate()
    {

        if (isTestInProgress)
        {
            statusMessage = "Test in progress";
            progressPercentage = AssignmentsProgressCalculator();
            completedAssignments = sankeyEditor.gameStatusCount;

        }

        if (!isTestInProgress)
        {
            statusMessage = "";
        }

        //if (hitCurrentStatus == "Unassignable" && isTestInProgress)
        //{
        //    hitCurrentStatus = "";
        //    statusMessage = "Test Completed";
        //    isTestInProgress = false;

        //    if (timer != null)
        //        timer.Stop();
        //    //progressPercentage = 0;
        //    maximumAssignmentsProvided = 0;
        //    AssignmentsAvailableNow = 0;
        //    isTestInProgress = false;
        //}

        if (progressPercentage == 100)
        {
            isTestInProgress = false;
            statusMessage = "Test Completed";
            if (timer != null)
                timer.Stop();

        }

        if (startQuery)
        {
            startQuery = false;

            //  sankeyEditor.ScanByTrap(testIdDB.ToString());// (testIdVisualization.ToString());


            //Scan the death traps here as well
            //sankeyEditor.ScanGameStatus(testIdDB.ToString(), true);

            // sankeyEditor.ScanSurvivalData("TBD", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name,false);

            //editorPlayerTrajectoryGenrator.ScanAllRunIdsByTestSerialId(testIdDB.ToString());
            //editorPlayerTrajectoryGenrator.ScanAllRunIdsByTestSerialId(testIdDB.ToString());


            //sankeyEditor.ScanSurvivalData("TBD", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            sankeyEditor.ScanConfusionMatrixData("TBD", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        }
    }

    public void ReadWriteTestSerialIds()
    {
        testIdDB = 0;
        maximumAssignments = Int32.Parse(requiredAssignments) * 2;
        testIdDB = CountLines(readTestSerialFile) + 1;
        File.AppendAllText("readTestSerialIds.txt", testIdDB.ToString() + "\r\n");
        using (StreamWriter writetext = new StreamWriter("writeTestSerialIds.txt"))
        {
            writetext.Write(testIdDB + "\t" + requiredAssignments + "\t" + maximumAssignments);
            Debug.Log("Actual test id -- " + testIdDB);
        }
    }

    public int CountLines(string filename)
    {
        int result = 0;

        using (var input = File.OpenText(filename))
        {
            while (input.ReadLine() != null)
            {
                ++result;
            }
        }
        return result;
    }

    void InitDynamoDB()
    {
        if ((GameObject.Find("DynamoDB")))
        {
            dynode = GameObject.Find("DynamoDB").GetComponent<DynamoDB.Dynode>();
        }
        else
        {
            GameObject DynodeObject = new GameObject("DynamoDB");
            dynode = DynodeObject.AddComponent<DynamoDB.Dynode>();
        }

        httpCalls = GameObject.Find("HttpObject").GetComponent<DynamoDB.DDBHTTP>();
        httpCalls.action = "DynamoDB_20120810.PutItem";


        httpCalls.AWS_ACCESS_KEY_ID = "AKIAISWHOY6ZNSDWOORA";
        httpCalls.AWS_SECRET_ACCESS_KEY = "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";
    }

    void OnSceneGUI()
    {
        Handles.BeginGUI();

        Rect rect = new Rect(10, 10, 100, 50);

        if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition))
            Debug.Log("press");

        Handles.EndGUI();

        SceneView.RepaintAll();
    }


}
