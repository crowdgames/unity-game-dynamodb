using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;
using System.Linq;
using BayatGames.SaveGamePro.Examples;
using UnityEngine.SceneManagement;

public class Logger : MonoBehaviour
{
    public int ticksPerSecond = 60;

    private float _t;

    public string awsAccessKeyID = "";
    public string awsSecretAccessKey = "";
    public string tableName;
    public string primaryKey;
    public string log;
    public bool logging;
    bool isEntryLog = true;
    string playerPositionCoords;

    public bool gameCompletionLogging;
    public bool gameTrapsLogging;
    public bool gameMilestonesLogging;
    public bool insertMasterGameCompletionData;
    public bool updatedGameMilestonesLogging;

    Vector3 currentPosition, previousPosition;
    Vector3 tCurrentPosition, tPreviousPosition;
    public DynamoDB.Dynode dynode;

    //---

    public GameObject sHttp;
    private DynamoDB.DDBHTTP httpScript;

    public static string testID;
    ActionNew[] actionPoints;
    private string version = "1.0";
    List<int> testIDsFromDB = new List<int>();
    //--

    string curr = "";
    SaveGameObject sgo;
    DateTime gameStartTime;
    public bool sendLevelCompletiontoDB = false;
    public bool sendLevelStatustoDB = false;
    public bool sendGameCompletionLoggingtoDB = false;
    public bool sendTrapStatus=false;

    private PlayerController playerController;

    void Start()
    {
        //isEntryLog = true;

        logging = true;
        gameCompletionLogging = false;
        gameMilestonesLogging = false;
        sgo = GameObject.FindGameObjectWithTag("SGO").GetComponent<SaveGameObject>();
        playerController = gameObject.GetComponent<PlayerController>();
        // Create a session-unique, persistent object for logging.
        // If it already exists (from a previous run), then refind it.
        //InitiateHttp();
        //ScanByTrap();


        if ((GameObject.Find("DynamoDB")))
        {
            dynode = GameObject.Find("DynamoDB").GetComponent<DynamoDB.Dynode>();
        }
        else
        {
            GameObject DynodeObject = new GameObject("DynamoDB");
            dynode = DynodeObject.AddComponent<DynamoDB.Dynode>();
        }

        // Set Dynode's parameters
        dynode.AWS_ACCESS_KEY_ID = awsAccessKeyID;
        dynode.AWS_SECRET_ACCESS_KEY = awsSecretAccessKey;
        dynode.table_name = tableName;
        dynode.primary_key = primaryKey;

    }

    void InitiateHttp()
    {
        httpScript = sHttp.GetComponent<DynamoDB.DDBHTTP>();
        httpScript.action = "DynamoDB_20120810.Scan";
        httpScript.AWS_ACCESS_KEY_ID = awsAccessKeyID;
        httpScript.AWS_SECRET_ACCESS_KEY = awsSecretAccessKey;
    }


    //void TestLog(string playerPosition)
    //{

    //    var Item = new JSONObject();
    //    Item["player_position"]["S"] = playerPosition;

    //    dynode.Send(Item);
    //}

    void UpdatedTestLog(string playerPosition)
    {
        var Item = new JSONObject();
        Item["player_position"]["S"] = playerPosition;

         dynode.SendUpdatedPlayerTrajectories(Item);
    }

    //void InsertMilestonesData()
    //{
    //    playerInteractionFactors.DetermineMilestoneCases();
    //    var Item = new JSONObject();
    //    Item["Milestone_1"]["S"] = playerInteractionFactors.milestone1;
    //    Item["Milestone_2"]["S"] = playerInteractionFactors.milestone2;
    //    dynode.SendMilestonesData(Item);

    //}

    //void InsertUpdatedMilestonesData()
    //{
    //    playerInteractionFactors.DetermineMilestoneCases();
    //    var Item = new JSONObject();
    //    Item["Milestone_1"]["S"] = playerInteractionFactors.milestone1;
    //    Item["Milestone_2"]["S"] = playerInteractionFactors.milestone2;
    //    dynode.SendMilestonesDataUpdated(Item);

    //}

    //public void InsertGameCompletionData(string gc, string gpd, string hc, string lp, string tp)
    //{

    //    dynode.SendGameCompletionStatus(gc, gpd, hc, lp, tp);//.Send(Item);
    //}



    //public void InsertTrapStatusData(string tn, string tp)
    //{

    //    dynode.SendTrapTrace(tn, tp);
    //}

    int interval = 1;
    float nextTime = 0;

    float tNextTime = 0;
    int tInterval = 1;


    // Update is called once per frame
    void Update()
    {
        //if (sgo.testMode)
        //{
        // Trigger entry logs for all users
        if (isEntryLog)
        {
            gameStartTime = DateTime.UtcNow;
            isEntryLog = false;
            dynode.SendEntryLog();
        }

        //if (MainMenu.triggerLogs)
        //{
        //    //if (isEntryLog)
        //    //{
        //    //    isEntryLog = false;
        //    //    dynode.SendEntryLog();
        //    //}


        //    if (logging)
        //    {
        //        if (Time.time >= nextTime)
        //        {
        //            currentPosition = transform.position;

        //            if (currentPosition != previousPosition)
        //                TestLog(currentPosition.ToString());
        //            nextTime += interval;
        //            previousPosition = currentPosition;
        //        }
        //    }

        //    //if (gameCompletionLogging)
        //    //{

        //    //    gameCompletionLogging = false;

        //    //    InsertGameCompletionData(playerFactors.gameCompletitionStatus.ToString(),
        //    //        gameTimer.completionTime.ToString(), playerFactors.healthNow.ToString(), progressCalculator.levelProgressState, player.transform.position.ToString());
        //    //}

        //    //if (gameTrapsLogging)
        //    //{
        //    //    gameTrapsLogging = false;
        //    //    InsertTrapStatusData(playerFactors.gameTrapName, playerFactors.gameTrapPosition);
        //    //}

        //    //if (gameMilestonesLogging)
        //    //{
        //    //    gameMilestonesLogging = false;
        //    //    InsertMilestonesData();
        //    //}
        //}

        //updated player trajectories
        if (Time.time >= tNextTime)
        {
            tCurrentPosition = transform.position;

            if (tCurrentPosition != tPreviousPosition)
                UpdatedTestLog(tCurrentPosition.ToString());
            tNextTime += tInterval;
            tPreviousPosition = tCurrentPosition;
        }

        if (sendLevelCompletiontoDB)
        {
            //Trigger when user completes each level
            sendLevelCompletiontoDB = false;
            playerController.ComputeConfusionMatrix();
            dynode.SendLevelCompletionStatus(playerController.level1Completion, playerController.level2Completion, playerController.level3Completion,
                playerController.RC.ToString(), playerController.IC.ToString(),playerController.INC.ToString(),playerController.RNC.ToString());
        }

        if (sendLevelStatustoDB)
        {
            sendLevelStatustoDB = false;
            int lNumber = SceneManager.GetActiveScene().buildIndex + 1;
            dynode.SendLevelStatus(playerController.transform.position.ToString(), lNumber.ToString());
        }

        if (sendGameCompletionLoggingtoDB)
        {

            sendGameCompletionLoggingtoDB = false;

             dynode.SendMasterGameCompletionStatus(playerController.gameCompletionStatus, playerController.transform.position.ToString(), gameStartTime.ToString());

        }

        if (sendTrapStatus)
        {
            int lNumber = SceneManager.GetActiveScene().buildIndex + 1;
            sendTrapStatus = false;
            dynode.SendTrapStatus(playerController.trapPosition.ToString(), lNumber.ToString(),playerController.description);
        }
        //updated milestones

        //if (updatedGameMilestonesLogging)
        //{
        //    updatedGameMilestonesLogging = false;
        //    InsertUpdatedMilestonesData();
        //}
        //// Add the log to game status table - Master

        //if (insertMasterGameCompletionData)
        //{
        //    insertMasterGameCompletionData = false;
        //    //InsertGameCompletionData(playerFactors.gameCompletitionStatus.ToString(),
        //    //       gameTimer.completionTime.ToString(), playerFactors.healthNow.ToString(), progressCalculator.levelProgressState, player.transform.position.ToString());
        //    dynode.SendMasterGameCompletionStatus(playerFactors.gameCompletitionStatus.ToString(), playerFactors.healthNow.ToString(), progressCalculator.levelProgressState,
        //       player.transform.position.ToString(), gameStartTime.ToString());

        //}


        // }
    }

    public void ScanByTrap()
    {
        // Extract using the player
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "unity-pp-mturk-test-details";
        obj["FilterExpression"] = "version = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = version;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        GatherTestIDs(obj, now);
    }

    public void GatherTestIDs(JSONObject jObj, DateTime timeNow)
    {

        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);

        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {

                var results = JSON.Parse(callback);
                actionPoints = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {
                    //GET Test serial ids and maximum assignments
                    testIDsFromDB.Add(results["Items"][i]["test_serial_id"]["S"]);

                }
                testID = testIDsFromDB.Max().ToString();

            }
        }));
    }


}
