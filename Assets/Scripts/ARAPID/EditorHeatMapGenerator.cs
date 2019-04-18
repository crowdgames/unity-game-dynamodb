using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using System.IO;
using System.Linq;


[ExecuteInEditMode]
public class EditorHeatMapGenerator : MonoBehaviour
{

    string readpath;
    public float m1, m2;
    private List<Vector3> milestonePositions = new List<Vector3>() {
        new Vector3(83.4f,-1.1f,0.0f),
        new Vector3(199.4f,-1.1f,0.0f),
    };

    private Dictionary<Vector3, float> MilestonesMapper = new Dictionary<Vector3, float>();

    private List<Vector3> playerTrace = new List<Vector3>();
    public Dictionary<int, Vector3> playerTraces = new Dictionary<int, Vector3>();
    public List<MilestonesRatio> milestonesStatus = new List<MilestonesRatio>();
    Color lineColor;

    public List<PlayerTrajectory> playerTrajectories = new List<PlayerTrajectory>();
    public Dictionary<int, string> playerTrajectoriesDict = new Dictionary<int, string>();

    public List<Dictionary<int, Vector3>> individualTelemetry = new List<Dictionary<int, Vector3>>();
    public List<List<Vector3>> individualTelemetryFinal = new List<List<Vector3>>();
    private List<EntryLog> entryLogData = new List<EntryLog>();
    public List<string> discontinuedGameplays = new List<string>();

    public List<string> displayedRId = new List<string>();

    public List<string> runIDs = new List<string>();

    public bool loadDataWithRunId = false;

    public bool loadDataWithPlayerName = false;

    public bool generateHeatMap = false;
    public bool clearData = false;
    public GameObject http;
    private DynamoDB.DDBHTTP httpScript;

    public GameObject player;
    public string run_id;
    public string playerName;
    public string key;
    public string secret;
    Button get;
    ActionNew[] points;

    public bool loadData = false;
    Dictionary<int, Vector3> sublist = new Dictionary<int, Vector3>();
    List<Vector3> sublistSec = new List<Vector3>();
    SankeyEditor sankeyEditor;

    int completeCounter = 0;
    int incompleCOunter = 0;

    void Start()
    {
        sankeyEditor = GameObject.FindGameObjectWithTag("SKE").GetComponent<SankeyEditor>();

    }

    void InitiateHTTPObject()
    {
        httpScript = http.GetComponent<DynamoDB.DDBHTTP>();
        httpScript.action = "DynamoDB_20120810.Scan";
        httpScript.AWS_ACCESS_KEY_ID = key;
        httpScript.AWS_SECRET_ACCESS_KEY = secret;
    }


    void Update()
    {
        InitiateHTTPObject();
        /////z
        //Debug.DrawRay(new Vector3(-5.3f, 4.6f, 0.0f), Vector3.forward, Color.green, 5.0f);
        readpath = Application.dataPath + "/PlayerPositions.txt";
        if (loadDataWithRunId)
        {
            loadDataWithRunId = false;
            //ScanByRunId();
        }



        if (clearData)
        {
            clearData = false;
            emptyList();
        }
    }

    public void emptyList()
    {

        Debug.Log("List Cleared");

        playerTrace.Clear();
        playerTraces.Clear();


        playerTrajectoriesDict.Clear();
        playerTrajectories.Clear();
        individualTelemetry.Clear();
        individualTelemetryFinal.Clear();

    }



    public Vector3 StringToVector3(string sVector)
    {

        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }


        string[] sArray = sVector.Split(',');


        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        return result;
    }

    public void clearEntryLog()
    {
        entryLogData.Clear();
    }

    void OnDrawGizmos()
    {



        if (MilestonesMapper.Count > 0)
        {
            Gizmos.color = Color.yellow;
            foreach (var item in MilestonesMapper)
            {
                Gizmos.DrawWireSphere(item.Key, (item.Value / 100.0f) * 5.0f);
            }

        }

        //lineColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
        if (playerTraces.Count > 0)
        {
            playerTraces = playerTraces.OrderBy(kpv => kpv.Key).ToDictionary(kpv => kpv.Key, kpv => kpv.Value);
            playerTrace = playerTraces.Values.Select(c => c).ToList(); ;
            for (int i = 0; i < playerTrace.Count - 1; i++)
            {
                Debug.DrawLine(new Vector3(playerTrace[i].x, playerTrace[i].y), new Vector3(playerTrace[i + 1].x, playerTrace[i + 1].y) + transform.forward, Color.yellow);

            }
        }

        //Consolidated player

        if (playerTrajectories.Count > 0 && loadData)
        {
            Dictionary<int, Vector3> tempVector;
            List<Vector3> tempVectorTwo;

            var result = playerTrajectories.GroupBy(item => item.Run_ids,
                 (key, group) => new { RunId = key, Positions = group.ToList() })
                 .ToList();



            foreach (var r in result)
            {

                if (sankeyEditor.runIdsComparison.ContainsKey(r.RunId))
                {
                    for (int i = 0; i < r.Positions.Count; i++)
                    {
                        Vector3 myPos = StringToVector3(r.Positions[i].PlayerPositions);
                        if (!sublist.ContainsKey(Int32.Parse(r.Positions[i].ActionIndex)))
                            sublist.Add(Int32.Parse(r.Positions[i].ActionIndex), myPos);
                    }


                    tempVector = new Dictionary<int, Vector3>(sublist);
                    individualTelemetry.Add(tempVector);
                    sublist.Clear();

                    for (int i = 0; i < individualTelemetry.Count; i++)
                    {
                        individualTelemetry[i] = individualTelemetry[i].OrderBy(kpv => kpv.Key).ToDictionary(kpv => kpv.Key, kpv => kpv.Value);

                        sublistSec = individualTelemetry[i].Values.Select(c => c).ToList();

                        tempVectorTwo = new List<Vector3>(sublistSec);
                        individualTelemetryFinal.Add(tempVectorTwo);
                    }


                    for (int j = 0; j < individualTelemetryFinal.Count; j++)
                    {
                        if (sankeyEditor.runIdsComparison.ContainsKey(r.RunId))
                        {
                            if (sankeyEditor.runIdsComparison[r.RunId] == "Complete")
                            {
                                displayedRId.Add(r.RunId);
                                Gizmos.DrawIcon(new Vector3(UnityEngine.Random.Range(258.4f, 278.0f), UnityEngine.Random.Range(-2.0f, 18.0f), 0.0f), "complete.png", true);
                                break;
                            }

                            if (sankeyEditor.runIdsComparison[r.RunId] == "Incomplete")
                            {
                                displayedRId.Add(r.RunId);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    sublist.Clear();
                    individualTelemetry.Clear();
                    individualTelemetryFinal.Clear();

                    for (int i = 0; i < r.Positions.Count; i++)
                    {
                        Vector3 myPos = StringToVector3(r.Positions[i].PlayerPositions);
                        if (!sublist.ContainsKey(Int32.Parse(r.Positions[i].ActionIndex)))
                            sublist.Add(Int32.Parse(r.Positions[i].ActionIndex), myPos);
                    }


                    tempVector = new Dictionary<int, Vector3>(sublist);
                    individualTelemetry.Add(tempVector);
                    sublist.Clear();

                    for (int i = 0; i < individualTelemetry.Count; i++)
                    {
                        individualTelemetry[i] = individualTelemetry[i].OrderBy(kpv => kpv.Key).ToDictionary(kpv => kpv.Key, kpv => kpv.Value);

                        sublistSec = individualTelemetry[i].Values.Select(c => c).ToList();

                        tempVectorTwo = new List<Vector3>(sublistSec);
                        individualTelemetryFinal.Add(tempVectorTwo);
                    }

                    for (int j = 0; j < individualTelemetryFinal.Count; j++)
                    {
                        if (!displayedRId.Contains(r.RunId))
                            Gizmos.DrawIcon(new Vector3(individualTelemetryFinal[j][individualTelemetryFinal[j].Count - 1].x, individualTelemetryFinal[j][individualTelemetryFinal[j].Count - 1].y), "wayCone.png", true);
                    }

                }

            }
            // Debug.Log("Display runId " + displayedRId.Count);

            loadData = false;
        }

    }

    void GenearateConsolidatedPlayerTrajectories(JSONObject jObj, DateTime timeNow)
    {
        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);
        //  Debug.Log("Query complete!");
        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                //Debug.Log(results);
                // Sort results into an Action array
                points = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {

                    playerTrajectories.Add(new PlayerTrajectory(results["Items"][i]["run_id"]["S"], results["Items"][i]["action_index"]["S"], results["Items"][i]["player_position"]["S"]));
                }

                loadData = true;
            }
        }));

    }

    void GenearateIndividualPlayerTrajectory(JSONObject jObj, DateTime timeNow)
    {
        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);
        //  Debug.Log("Query complete!");
        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                Debug.Log(results);
                // Sort results into an Action array
                points = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {
                    playerTraces.Add(Int32.Parse(results["Items"][i]["action_index"]["S"]), StringToVector3(results["Items"][i]["player_position"]["S"]));

                }
                // LoadStringToVector(readList, playerTrace);
            }
        }));

    }




    void StoreTestIDs(JSONObject jObj, DateTime timeNow)
    {
        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);
        //  Debug.Log("Query complete!");
        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                Debug.Log(results);
                // Sort results into an Action array
                points = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {
                    runIDs.Add(results["Items"][i]["run_id"]["S"]);
                }
                //Debug.Log("RunIDs count"+ runIDs.Count);
            }
        }));

    }

    void StoreMilestonesStatus(JSONObject jObj, DateTime timeNow)
    {
        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);
        //Debug.Log(jObj.ToString());
        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {
                //Debug.Log(callback);
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                // Debug.Log(results);
                // Sort results into an Action array
                points = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {
                    milestonesStatus.Add(new MilestonesRatio(results["Items"][i]["Milestone_1"]["S"], results["Items"][i]["Milestone_2"]["S"],
                        results["Items"][i]["Milestone_3"]["S"], results["Items"][i]["Milestone_4"]["S"]));
                }

                calculateMilestonesRatio();

            }
        }));
    }

    void ScanEntryLogData(JSONObject jObj, DateTime timeNow, string testSId)
    {
        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);
        //Debug.Log(jObj.ToString());
        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {
                //Debug.Log(callback);
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                Debug.Log(results);
                // Sort results into an Action array
                points = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {
                    //string runId, string timestamp, string testSerialId
                    entryLogData.Add(new EntryLog(results["Items"][i]["run_id"]["S"], results["Items"][i]["timestamp"]["S"]));

                }
                ComputePlayerLogTimestamp(testSId);
            }
        }));
    }

    public void ComputePlayerLogTimestamp(string myTestID)
    {

        //runIDs.Clear();
        //discontinuedGameplays.Clear();
        //ScanGameStatusTable(myTestID);

        for (int i = 0; i < entryLogData.Count; i++)
        {
            DateTime dt = Convert.ToDateTime(entryLogData[i].Timestamp);
            CompareTimestamps(dt, DateTime.UtcNow, entryLogData[i].RunId);
        }
    }

    public void CompareTimestamps(DateTime dt1, DateTime dt2, string checkRunId)
    {

        var minutes = (dt2 - dt1).TotalMinutes;

        if (minutes > 10.0f)
        {
            if (!runIDs.Contains(checkRunId))
            {
                //Debug.Log(checkRunId+ " discontinued from gameplay");
                discontinuedGameplays.Add(checkRunId);
            }
        }
    }

    public void ScanEntryLog(string testID)
    {
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-entry-log";
        obj["FilterExpression"] = "test_serial_id = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = testID;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        ScanEntryLogData(obj, now, testID);

    }

    public void ScanGameStatusTable(string testID)
    {
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-game-status";
        obj["FilterExpression"] = "test_serial_id = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = testID;//MainMenu.testID;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        StoreTestIDs(obj, now);
    }

    public void ScanMilestonesStatusBasedOnTestSerialId(string testID)
    {
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-milestones";
        obj["FilterExpression"] = "test_serial_id = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = testID;//Insert Main Menu.TestId;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        StoreMilestonesStatus(obj, now);

    }

    public void clearMilestonesRatio()
    {
        m1 = 0;
        m2 = 0;
        //m3 = 0;
        //m4 = 0;
        MilestonesMapper.Clear();
    }

    public void calculateMilestonesRatio()
    {
        for (int i = 0; i < milestonesStatus.Count; i++)
        {
            if (milestonesStatus[i].Milestone1 == "Complete")
            {
                m1 += 1;
            }
            if (milestonesStatus[i].Milestone2 == "Complete")
            {
                m2 += 1;
            }

        }

        m1 = (m1 / milestonesStatus.Count) * 100.0f;
        m2 = (m2 / milestonesStatus.Count) * 100.0f;
        List<float> tempMilestones = new List<float>() {
        m1,m2};

        for (int i = 0; i < milestonePositions.Count; i++)
        {
            MilestonesMapper.Add(milestonePositions[i], tempMilestones[i]);
            //Debug.Log(milestonePositions[i]);
        }

    }



    public void ScanByRunId(string currentRunId)
    {
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-sub-player-trajectories";
        obj["FilterExpression"] = "run_id = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = currentRunId;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        //Generating Map
        GenearateIndividualPlayerTrajectory(obj, now);
    }

    public void ScanAllRunIdsByTestSerialId(string testSerialId)
    {
        displayedRId.Clear();
        playerTrajectoriesDict.Clear();
        playerTrajectories.Clear();
        individualTelemetry.Clear();
        individualTelemetryFinal.Clear();
        runIDs.Clear();

        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-sub-player-trajectories";
        obj["FilterExpression"] = "test_serial_id = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = testSerialId;
        obj["ReturnConsumedCapacity"] = "TOTAL";


        //Generating Map
        GenearateConsolidatedPlayerTrajectories(obj, now);
    }

    void LoadToDictionary(List<PlayerTrajectory> fromDBList, Dictionary<int, string> toStoreDict)
    {
        for (int i = 0; i < fromDBList.Count; i++)
        {
            toStoreDict.Add(Convert.ToInt32(fromDBList[i].ActionIndex), fromDBList[i].PlayerPositions);
        }
        Debug.Log("Successfully completed");
    }


}

public class PlayerTrajectory
{
    private string run_ids;
    private string actionIndex;
    private string playerPositions;

    public PlayerTrajectory(string run_ids, string actionIndex, string playerPositions)
    {
        this.run_ids = run_ids;
        this.actionIndex = actionIndex;
        this.playerPositions = playerPositions;
    }

    public string Run_ids
    {
        get
        {
            return run_ids;
        }

        set
        {
            run_ids = value;
        }
    }

    public string PlayerPositions
    {
        get
        {
            return playerPositions;
        }

        set
        {
            playerPositions = value;
        }
    }

    public string ActionIndex
    {
        get
        {
            return actionIndex;
        }

        set
        {
            actionIndex = value;
        }
    }




}

public class MilestonesRatio
{
    private string milestone1;
    private string milestone2;
    private string milestone3;
    private string milestone4;

    public MilestonesRatio(string milestone1, string milestone2, string milestone3, string milestone4)
    {
        this.milestone1 = milestone1;
        this.milestone2 = milestone2;
        this.milestone3 = milestone3;
        this.milestone4 = milestone4;
    }

    public string Milestone1
    {
        get
        {
            return milestone1;
        }

        set
        {
            milestone1 = value;
        }
    }

    public string Milestone2
    {
        get
        {
            return milestone2;
        }

        set
        {
            milestone2 = value;
        }
    }

    public string Milestone3
    {
        get
        {
            return milestone3;
        }

        set
        {
            milestone3 = value;
        }
    }

    public string Milestone4
    {
        get
        {
            return milestone4;
        }

        set
        {
            milestone4 = value;
        }
    }
}







