using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System.Globalization;

[ExecuteInEditMode]
public class SankeyEditor : MonoBehaviour
{
    //public static SankeyEditor Instance;

    //void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }

    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    // Oragnized trap trace
    public List<TrapTraces> collectedTrapTraces = new List<TrapTraces>();
    public List<TrapTraces> cloneCollectedTrapTraces = new List<TrapTraces>();
    private List<string> tempPlayerNames = new List<string>();
    public List<GameStatus> gameStatusDetails = new List<GameStatus>();
    public List<LevelStatus> levelStatusDetails = new List<LevelStatus>();
    public int level1CompCount, level2CompCount, level3CompCount = 0;
    public int level1Completion, level2Completion, level3Completion = 0;

    public List<string> totalTestIDs = new List<string>();
    private List<string> collectedDeathLocation = new List<string>();
    private List<string> collectedDeathLocationL1 = new List<string>();
    private List<string> collectedDeathLocationL2 = new List<string>();
    private List<string> collectedDeathLocationL3 = new List<string>();
    public List<Vector3> deathLocationOnScene = new List<Vector3>();
    public List<Vector3> deathLocationOnSceneL1 = new List<Vector3>();
    public List<Vector3> deathLocationOnSceneL2 = new List<Vector3>();
    public List<Vector3> deathLocationOnSceneL3 = new List<Vector3>();
    private List<Vector3> cloneDeathLocationOnScene = new List<Vector3>();
    public List<Vector3> cloneDeathLocationOnSceneL1 = new List<Vector3>();
    public List<Vector3> cloneDeathLocationOnSceneL2 = new List<Vector3>();
    public List<Vector3> cloneDeathLocationOnSceneL3 = new List<Vector3>();
    public List<Vector3> refinedDeathLocationOnScene = new List<Vector3>();
    public List<Vector3> refinedDeathLocationOnSceneL1 = new List<Vector3>();
    public List<Vector3> refinedDeathLocationOnSceneL2 = new List<Vector3>();
    public List<Vector3> refinedDeathLocationOnSceneL3 = new List<Vector3>();

    //Integrated Editor
    private List<string> collectedDeathLocationIEL1 = new List<string>();
    private List<string> collectedDeathLocationIEL2 = new List<string>();
    private List<string> collectedDeathLocationIEL3 = new List<string>();
    public List<Vector3> deathLocationOnSceneIEL1 = new List<Vector3>();
    public List<Vector3> deathLocationOnSceneIEL2 = new List<Vector3>();
    public List<Vector3> deathLocationOnSceneIEL3 = new List<Vector3>();
    public List<Vector3> cloneDeathLocationOnSceneIEL1 = new List<Vector3>();
    public List<Vector3> cloneDeathLocationOnSceneIEL2 = new List<Vector3>();
    public List<Vector3> cloneDeathLocationOnSceneIEL3 = new List<Vector3>();
    public List<Vector3> refinedDeathLocationOnSceneIEL1 = new List<Vector3>();
    public List<Vector3> refinedDeathLocationOnSceneIEL2 = new List<Vector3>();
    public List<Vector3> refinedDeathLocationOnSceneIEL3 = new List<Vector3>();
    public int level1CompCountIE, level2CompCountIE, level3CompCountIE = 0;
    public int level1CompletionIE, level2CompletionIE, level3CompletionIE = 0;
    float descendValueL1, descendValueL2, descendValueL3;

    public Dictionary<string, string> runIdsComparison = new Dictionary<string, string>();
    //Counter variables for each trap
    private int acidPit;
    private int spikes;
    private int saw;
    private int dangerousSubstances;
    private int electricArc;
    private float maxValue = 100.0f;

    public bool isCompletionNil = false;
    public bool isL1CompletionNil = false;
    public bool isL2CompletionNil = false;
    public bool isL3CompletionNil = false;
    public bool generateDamageProportion = false;


    public bool generateDeathMarkers = false;

    public GameObject sHttp;
    private DynamoDB.DDBHTTP httpScript;


    private string version = "version 1.0";
    public string playTestTag;

    public string key;
    public string secret;
    Button get;
    ActionNew[] actionPoints;
    int counter = 0;

    public int gameStatusCount = 0;
    bool plotCondition;
    string plotScreenNumber;
    List<Vector3> dataList = new List<Vector3>();
    int levelCompCount = 0;

    void InitiateHttp()
    {

        httpScript = sHttp.GetComponent<DynamoDB.DDBHTTP>();
        httpScript.action = "DynamoDB_20120810.Scan";
        httpScript.AWS_ACCESS_KEY_ID = key;
        httpScript.AWS_SECRET_ACCESS_KEY = secret;

    }

    // Update is called once per frame
    void Update()
    {
        InitiateHttp();

    }

    public void emptyList()
    {
        Debug.Log("List Cleared");
        collectedTrapTraces.Clear();
        tempPlayerNames.Clear();
        collectedDeathLocation.Clear();
        deathLocationOnScene.Clear();
        gameStatusDetails.Clear();
        cloneCollectedTrapTraces.Clear();
        cloneDeathLocationOnScene.Clear();
        refinedDeathLocationOnScene.Clear();


    }

    public void emptyListForDeathMarkers()
    {
        collectedDeathLocation.Clear();
        deathLocationOnScene.Clear();
    }

    public void emptyListForTrapTraces()
    {
        //cloneCollectedTrapTraces.Clear();
        collectedTrapTraces.Clear();
        tempPlayerNames.Clear();
    }




    public void LoadStringToVector(List<string> fromReadList, List<Vector3> toStoreList, bool isFlowMode, string levelNumber)
    {
        toStoreList.Clear();
        foreach (string value in fromReadList)
        {
            toStoreList.Add(StringToVector3(value));
        }

        if (isFlowMode)
        {
            if (levelNumber == "level_00")
            {
                toStoreList.Add(new Vector3(-15, 10, 0.0f));
                toStoreList.Add(new Vector3(47.8f, 5.4f, 0.0f));
            }

            if (levelNumber == "level_01")
            {
                toStoreList.Add(new Vector3(-14, 10.0f, 0.0f));
                toStoreList.Add(new Vector3(48, 0, 0.0f));
            }

            if (levelNumber == "level_03")
            {
                toStoreList.Add(new Vector3(-14, 10.0f, 0.0f));
                toStoreList.Add(new Vector3(48, 0, 0.0f));
            }


        }



    }
    public Vector3 StringToVector3(string sVector)
    {

        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }


        string[] sArray = sVector.Split(',');


        Vector3 result = new Vector3(
            float.Parse(sArray[0],
                      CultureInfo.InvariantCulture),
            float.Parse(sArray[1],
                      CultureInfo.InvariantCulture),
            float.Parse(sArray[2],
                      CultureInfo.InvariantCulture));

        return result;
    }

    public void OnDrawGizmos()
    {
        //Milestones mapper


        var tempProcess = collectedTrapTraces.GroupBy(x => new { x.RunId, x.TrapPosition }).Select(g => g.First());

        var query = tempProcess.Select(x => x.TrapPosition)
                        .GroupBy(s => s)
                        .Select(g => new { Name = g.Key, Count = g.Count() });


        foreach (var result in query)
        {
            float totalPercentage = (result.Count / ComputePlayersCount()) * 100;


            Gizmos.color = Color.magenta;

            Gizmos.DrawSphere(StringToVector3(result.Name), totalPercentage / 40.0f);

            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.red;
            style.fontSize = 12;
            style.fontStyle = FontStyle.Bold;

            UnityEditor.Handles.Label(StringToVector3(result.Name) + new Vector3(-1.7f + (totalPercentage / 100.0f), 2.5f + (totalPercentage / 100.0f), 0.0f), Mathf.Round(totalPercentage) + " %", style);
        }


        for (int i = 0; i < deathLocationOnScene.Count; i++)
        {
            // if (i != 0 && i != deathLocationOnScene.Count - 1)
            Gizmos.DrawIcon(new Vector3(deathLocationOnScene[i].x, deathLocationOnScene[i].y), "death_marker1.png", true);
        }

        if (plotCondition)
        {
            plotCondition = false;

            if (plotScreenNumber == "1")
            {

                CopyList(cloneDeathLocationOnSceneL1, dataList);
                levelCompCount = level1CompCount;
            }
            if (plotScreenNumber == "2")
            {
                CopyList(cloneDeathLocationOnSceneL2, dataList);
                levelCompCount = level2CompCount;
            }

            if (plotScreenNumber == "3")
            {
                //Debug.Log("YYYYY");
                CopyList(cloneDeathLocationOnSceneL3, dataList);
                levelCompCount = level3CompCount;
            }

        }
        if (dataList.Count > 0)
        {

            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.blue;
            style.fontSize = 12;
            style.fontStyle = FontStyle.BoldAndItalic;

            //float percentage = (1.0f / (cloneDeathLocationOnScene.Count - 2) * 1.0f) * 100.0f;
            //Debug.Log(dataList.Count +" "+ levelCompCount);
            float percentage = (((dataList.Count - 2) * 1.0f / levelCompCount * 1.0f) * 100.0f) / (dataList.Count - 2) * 1.0f;
            //Debug.Log("Percentage value " + percentage);
            float baseSet = 0.0f;

            if (levelCompCount != 0)
            {
                for (int i = 0; i < refinedDeathLocationOnScene.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(refinedDeathLocationOnScene[i].x, refinedDeathLocationOnScene[i].y), new Vector3(refinedDeathLocationOnScene[i + 1].x, refinedDeathLocationOnScene[i + 1].y) + transform.forward, Color.red, 2.0f);
                    if (i % 2 == 0)
                    {
                        if (maxValue - baseSet > 1)
                        {
                            UnityEditor.Handles.Label(new Vector3(refinedDeathLocationOnScene[i].x, refinedDeathLocationOnScene[i].y), Math.Round(maxValue - baseSet, 2) + " %", style);
                            baseSet += percentage;
                        }

                        if (maxValue - baseSet < 0 && !isCompletionNil)
                        {
                            UnityEditor.Handles.Label(new Vector3(refinedDeathLocationOnScene[i].x, refinedDeathLocationOnScene[i].y), "< " + Math.Round(percentage, 2) + " %", style);
                        }

                    }
                }
            }
        }

    }



    void CopyList(List<Vector3> from, List<Vector3> to)
    {
        to.Clear();
        for (int i = 0; i < from.Count; i++)
        {
            to.Add(from[i]);
        }
    }


    //public void ComputeDeathMarkersRatio()
    //{
    //    cloneDeathLocationOnScene = cloneDeathLocationOnScene.OrderBy(v => v.x).ToList();
    //    float baseValue = 10.0f;

    //    //float descendValue = (1.0f / cloneDeathLocationOnScene.Count) * 10;


    //    float descendValue = (cloneDeathLocationOnScene.Count * 1.0f / gameStatusDetails.Count * 1.0f) * 10.0f / (cloneDeathLocationOnScene.Count * 1.0f);

    //    //Debug.Log("Descend value " + descendValue);
    //    if (cloneDeathLocationOnScene.Count > 0)
    //    {
    //        for (int i = 0; i < cloneDeathLocationOnScene.Count - 1; i++)
    //        {

    //            refinedDeathLocationOnScene.Add(new Vector3(cloneDeathLocationOnScene[i + 1].x, baseValue));
    //            refinedDeathLocationOnScene.Add(new Vector3(cloneDeathLocationOnScene[i + 1].x, baseValue - descendValue));

    //            baseValue = baseValue - descendValue;
    //            if (i == 0 || i == cloneDeathLocationOnScene.Count - 1)
    //            {
    //                refinedDeathLocationOnScene.Add(cloneDeathLocationOnScene[i]);
    //            }

    //        }
    //        refinedDeathLocationOnScene = refinedDeathLocationOnScene.OrderBy(v => v.x).ToList();
    //    }
    //}

    public void ComputeDeathMarkersRatioIE(List<Vector3> cDL, int levelCompletionCount, int levelNumber)
    {
        cDL = cDL.OrderBy(v => v.x).ToList();
        float baseValue = 10.0f;

        //float descendValue = (1.0f / cloneDeathLocationOnScene.Count) * 10;

        if (levelNumber == 1)
        {
            descendValueL1 = (cDL.Count * 1.0f / levelCompletionCount * 1.0f) * 10.0f / (cDL.Count * 1.0f);

        }

        if (levelNumber == 2)
        {
            descendValueL2 = (cDL.Count * 1.0f / levelCompletionCount * 1.0f) * 10.0f / (cDL.Count * 1.0f);
        }

        if (levelNumber == 3)
        {

            descendValueL3 = (cDL.Count * 1.0f / levelCompletionCount * 1.0f) * 10.0f / (cDL.Count * 1.0f);
        }
        //Debug.Log("Descend value " + descendValue);
        if (cDL.Count > 0)
        {
            for (int i = 0; i < cDL.Count - 1; i++)
            {
                if (levelNumber == 1)
                {
                    refinedDeathLocationOnSceneIEL1.Add(new Vector3(cDL[i + 1].x, baseValue));
                    refinedDeathLocationOnSceneIEL1.Add(new Vector3(cDL[i + 1].x, baseValue - descendValueL1));

                    baseValue = baseValue - descendValueL1;
                    if (i == 0 || i == cDL.Count - 1)
                    {
                        refinedDeathLocationOnSceneIEL1.Add(cDL[i]);
                    }
                }

                if (levelNumber == 2)
                {
                    refinedDeathLocationOnSceneIEL2.Add(new Vector3(cDL[i + 1].x, baseValue));
                    refinedDeathLocationOnSceneIEL2.Add(new Vector3(cDL[i + 1].x, baseValue - descendValueL2));

                    baseValue = baseValue - descendValueL2;
                    if (i == 0 || i == cDL.Count - 1)
                    {
                        refinedDeathLocationOnSceneIEL2.Add(cDL[i]);
                    }

                }

                if (levelNumber == 3)
                {
                    refinedDeathLocationOnSceneIEL3.Add(new Vector3(cDL[i + 1].x, baseValue));
                    refinedDeathLocationOnSceneIEL3.Add(new Vector3(cDL[i + 1].x, baseValue - descendValueL3));

                    baseValue = baseValue - descendValueL3;
                    if (i == 0 || i == cDL.Count - 1)
                    {
                        refinedDeathLocationOnSceneIEL3.Add(cDL[i]);
                    }

                }
                //refinedDeathLocationOnScene.Add(new Vector3(cDL[i + 1].x, baseValue));
                //refinedDeathLocationOnScene.Add(new Vector3(cDL[i + 1].x, baseValue - descendValue));

                //baseValue = baseValue - descendValue;
                //if (i == 0 || i == cDL.Count - 1)
                //{
                //    refinedDeathLocationOnScene.Add(cDL[i]);
                //}

            }

            refinedDeathLocationOnSceneIEL1 = refinedDeathLocationOnSceneIEL1.OrderBy(v => v.x).ToList();
            refinedDeathLocationOnSceneIEL2 = refinedDeathLocationOnSceneIEL2.OrderBy(v => v.x).ToList();
            refinedDeathLocationOnSceneIEL3 = refinedDeathLocationOnSceneIEL3.OrderBy(v => v.x).ToList();
        }
    }

    public void ComputeDeathMarkersRatioIndividualLevel(List<Vector3> cDL, int levelCompletionCount, int levelNumber)
    {

        cDL = cDL.OrderBy(v => v.x).ToList();
        float baseValue = 10.0f;

        //float descendValue = (1.0f / cloneDeathLocationOnScene.Count) * 10;


        float descendValue = (cDL.Count * 1.0f / levelCompletionCount * 1.0f) * 10.0f / (cDL.Count * 1.0f);

        //Debug.Log("Descend value " + descendValue);
        if (cDL.Count > 0)
        {
            for (int i = 0; i < cDL.Count - 1; i++)
            {

                refinedDeathLocationOnScene.Add(new Vector3(cDL[i + 1].x, baseValue));
                refinedDeathLocationOnScene.Add(new Vector3(cDL[i + 1].x, baseValue - descendValue));

                baseValue = baseValue - descendValue;
                if (i == 0 || i == cDL.Count - 1)
                {
                    refinedDeathLocationOnScene.Add(cDL[i]);
                }

            }

            refinedDeathLocationOnScene = refinedDeathLocationOnScene.OrderBy(v => v.x).ToList();
        }
    }


    public void deathLocationsClear()
    {
        //deathLocationOnScene.Clear();
        gameStatusDetails.Clear();
        cloneDeathLocationOnScene.Clear();
        refinedDeathLocationOnScene.Clear();
        collectedDeathLocation.Clear();
    }

    //Calculates the total run_ids who played the game
    public float ComputePlayersCount()
    {
        for (int i = 0; i < collectedTrapTraces.Count; i++)
        {
            if (!tempPlayerNames.Contains(collectedTrapTraces[i].RunId))
            {
                tempPlayerNames.Add(collectedTrapTraces[i].RunId);
            }
        }
        // Debug.Log("Distinct Run_ids count: " + tempPlayerNames.Count);
        return tempPlayerNames.Count;
    }


    public void ScanByTrap(string testID)
    {
        // Extract using the player
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-trap-traces";
        obj["FilterExpression"] = "version = :val and test_serial_id = :val_1";
        obj["ExpressionAttributeValues"][":val"]["S"] = version;
        obj["ExpressionAttributeValues"][":val_1"]["S"] = testID;//- insert MainMenu test serial_id and remove playTestTag;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        GenearateHeatMapBasedOnTraps(obj, now);
    }

    public void ScanByProportions(string testID)
    {
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-trap-traces";
        obj["FilterExpression"] = "version = :val and test_serial_id = :val_1";
        obj["ExpressionAttributeValues"][":val"]["S"] = version;
        obj["ExpressionAttributeValues"][":val_1"]["S"] = testID;//- insert MainMenu test serial_id and remove playTestTag;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        GenearateDamageProportionsforTraps(obj, now);
    }


    public void ScanGameStatus(string testID, bool isLoad)
    {
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-master-game-status";
        obj["FilterExpression"] = "test_serial_id = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = testID;// -insert MainMenu test serial_id and remove playTestTag;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        GenerateDeathLocationMarkers(obj, now);
    }

    //public void ScanDamageFlow(string testID)
    //{
    //    var obj = new JSONObject();
    //    DateTime now = DateTime.UtcNow;

    //    obj["TableName"] = "arapid-pp-master-game-status";
    //    obj["FilterExpression"] = "test_serial_id = :val";
    //    obj["ExpressionAttributeValues"][":val"]["S"] = testID;// -insert MainMenu test serial_id and remove playTestTag;
    //    obj["ReturnConsumedCapacity"] = "TOTAL";

    //    GenerateDamageFlow(obj, now);

    //}

    public void ScanDamageFlowNewIE(string testID, string levelNumber)
    {
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-level-status";
        obj["FilterExpression"] = "test_serial_id = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = testID;// -insert MainMenu test serial_id and remove playTestTag;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        GenerateDamageFlowIE(obj, now, levelNumber);

    }

    public void ScanSurvivalDataIE(string testIdDat, string levelNumber)
    {
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-level-completion";
        obj["FilterExpression"] = "test_serial_id = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = testIdDat;// -insert MainMenu test serial_id and remove playTestTag;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        GenerateSurvivalPlotIE(obj, now, levelNumber);
    }


    public void ScanSurvivalData(string testIdDat, string levelNumber)
    {
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-level-completion";
        obj["FilterExpression"] = "test_serial_id = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = testIdDat;// -insert MainMenu test serial_id and remove playTestTag;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        GenerateSurvivalPlot(obj, now, levelNumber);
    }

    public void GenerateSurvivalPlot(JSONObject jObj, DateTime timeNow, string levelNumber)
    {
        level1CompCount = 0;
        level2CompCount = 0;
        level3CompCount = 0;

        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);

        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                //Debug.Log(results);
                // Sort results into an Action array
                actionPoints = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {

                    if (results["Items"][i]["level1"]["S"] == "Complete")
                    {

                        level1CompCount += 1;
                        level1Completion += 1;

                    }

                    if (results["Items"][i]["level2"]["S"] == "Complete")
                    {

                        level2CompCount += 1;
                        level2Completion += 1;

                    }

                    if (results["Items"][i]["level3"]["S"] == "Complete")
                    {

                        level3CompCount += 1;
                        level3Completion += 1;

                    }

                }

            }

            //Generate damage flow here
            ScanDamageFlowNew("TBD", levelNumber);
        }));
    }

    public void ScanDamageFlowNew(string testID, string levelNumber)
    {
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-level-status";
        obj["FilterExpression"] = "test_serial_id = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = testID;// -insert MainMenu test serial_id and remove playTestTag;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        GenerateDamageFlow(obj, now, levelNumber);

    }

    public void GenerateDamageFlow(JSONObject jObj, DateTime timeNow, string levelNumber)
    {

        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);
        //Debug.Log("Query complete!");
        levelStatusDetails.Clear();
        //gameStatusDetails.Clear();
        collectedDeathLocation.Clear();
        collectedDeathLocationL1.Clear();
        collectedDeathLocationL2.Clear();
        collectedDeathLocationL3.Clear();
        refinedDeathLocationOnScene.Clear();
        refinedDeathLocationOnScene.Clear();
        refinedDeathLocationOnSceneL1.Clear();
        refinedDeathLocationOnSceneL2.Clear();
        refinedDeathLocationOnSceneL3.Clear();



        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                //Debug.Log(results);
                // Sort results into an Action array
                actionPoints = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {

                    //Segregate the death locations based on level number

                    if (results["Items"][i]["level_number"]["S"] == "1")
                    {

                        level1CompCount += 1;
                        collectedDeathLocationL1.Add(results["Items"][i]["death_location"]["S"]);

                    }
                    if (results["Items"][i]["level_number"]["S"] == "2")
                    {

                        level2CompCount += 1;
                        collectedDeathLocationL2.Add(results["Items"][i]["death_location"]["S"]);


                    }
                    if (results["Items"][i]["level_number"]["S"] == "3")
                    {

                        level3CompCount += 1;
                        collectedDeathLocationL3.Add(results["Items"][i]["death_location"]["S"]);

                    }

                }

                //Debug.Log(levelNumber);
                //Debug.Log("Death count at Level 1: " + collectedDeathLocationL1.Count);
                //Debug.Log("Death count at Level 2: " + collectedDeathLocationL2.Count);
                //Debug.Log("Death count at Level 3: " + collectedDeathLocationL3.Count);

                if (level1Completion == 0)
                    isL1CompletionNil = true;
                else
                    isL1CompletionNil = false;

                if (level2Completion == 0)
                    isL2CompletionNil = true;
                else
                    isL2CompletionNil = false;

                if (level3Completion == 0)
                    isL3CompletionNil = true;
                else
                    isL3CompletionNil = false;

                if (levelNumber == "level_00")
                {
                    LoadStringToVector(collectedDeathLocationL1, cloneDeathLocationOnSceneL1, true, levelNumber);
                    LoadStringToVector(collectedDeathLocationL1, deathLocationOnSceneL1, false, levelNumber);
                    ComputeDeathMarkersRatioIndividualLevel(cloneDeathLocationOnSceneL1, level1CompCount, 1);

                    //LoadStringToVector(collectedDeathLocationL1, cloneDeathLocationOnSceneL1, true, levelNumber);
                    //LoadStringToVector(collectedDeathLocationL1, deathLocationOnSceneL1, false, levelNumber);
                    //ComputeDeathMarkersRatio(cloneDeathLocationOnSceneL1, level1CompCount, 1);
                    plotCondition = true;
                    plotScreenNumber = "1";
                }

                if (levelNumber == "level_01")
                {
                    LoadStringToVector(collectedDeathLocationL2, cloneDeathLocationOnSceneL2, true, levelNumber);
                    LoadStringToVector(collectedDeathLocationL2, deathLocationOnSceneL2, false, levelNumber);
                    ComputeDeathMarkersRatioIndividualLevel(cloneDeathLocationOnSceneL2, level2CompCount, 2);
                    //LoadStringToVector(collectedDeathLocationL2, cloneDeathLocationOnSceneL2, true, levelNumber);
                    //LoadStringToVector(collectedDeathLocationL2, deathLocationOnSceneL2, false, levelNumber);
                    //ComputeDeathMarkersRatio(cloneDeathLocationOnSceneL2, level2CompCount, 2);
                    plotCondition = true;
                    plotScreenNumber = "2";
                }

                if (levelNumber == "level_03")
                {
                    LoadStringToVector(collectedDeathLocationL3, cloneDeathLocationOnSceneL3, true, levelNumber);
                    LoadStringToVector(collectedDeathLocationL3, deathLocationOnSceneL3, false, levelNumber);
                    ComputeDeathMarkersRatioIndividualLevel(cloneDeathLocationOnSceneL3, level3CompCount, 3);
                    //LoadStringToVector(collectedDeathLocationL3, cloneDeathLocationOnSceneL3, true, levelNumber);
                    //LoadStringToVector(collectedDeathLocationL3, deathLocationOnSceneL3, false, levelNumber);
                    //ComputeDeathMarkersRatio(cloneDeathLocationOnSceneL3, level3CompCount, 3);
                    plotCondition = true;
                    plotScreenNumber = "3";
                }


            }
        }));
    }

    public void ScanGameStatusBasedOnTestSerialId(string myTestID, bool isLoad)
    {
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-game-status";
        obj["FilterExpression"] = "test_serial_id = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = myTestID;//Insert Main Menu.TestId;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        GenerateDeathLocationMarkers(obj, now);

    }

    public void ScanMTurkTestIDs()
    {
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-mturk-test-details";
        obj["FilterExpression"] = "version = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = version;//Insert Main Menu.TestId;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        LoadTestIDsFromDB(obj, now);
    }

    public void PopulateRunIdsDict()
    {
        //Debug.Log("Runids count before : " + runIdsComparison.Count);
        runIdsComparison.Clear();

        for (int i = 0; i < gameStatusDetails.Count; i++)
        {
            if (!runIdsComparison.ContainsKey(gameStatusDetails[i].RunId))
            {
                runIdsComparison.Add(gameStatusDetails[i].RunId, gameStatusDetails[i].CompletionRatio);
                //Debug.Log(gameStatusDetails[i].RunId+" --- "+ gameStatusDetails[i].CompletionRatio);
            }
        }


    }

    public void GenearateHeatMapBasedOnTraps(JSONObject jObj, DateTime timeNow)
    {
        collectedTrapTraces.Clear();
        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);
        //Debug.Log("Query complete!");
        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {
                //Debug.Log("printing results");
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                //Debug.Log(results);
                // Sort results into an Action array
                actionPoints = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {
                    collectedTrapTraces.Add(new TrapTraces(results["Items"][i]["trap_name"]["S"],
                            results["Items"][i]["trap_position"]["S"], results["Items"][i]["run_id"]["S"]));
                }
            }
        }));
    }

    public void GenearateDamageProportionsforTraps(JSONObject jObj, DateTime timeNow)
    {

        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);
        //Debug.Log("Query complete!");
        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {
                //Debug.Log("printing results");
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                //Debug.Log(results);
                // Sort results into an Action array
                actionPoints = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {
                    cloneCollectedTrapTraces.Add(new TrapTraces(results["Items"][i]["trap_name"]["S"],
                            results["Items"][i]["trap_position"]["S"], results["Items"][i]["run_id"]["S"]));
                }
            }
        }));
    }


    public void GenerateDeathLocationMarkers(JSONObject jObj, DateTime timeNow)
    {
        gameStatusDetails.Clear();
        collectedDeathLocation.Clear();
        deathLocationOnScene.Clear();

        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);
        //Debug.Log("Query complete!");
        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                //Debug.Log(results);
                // Sort results into an Action array
                actionPoints = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {
                    gameStatusDetails.Add(new GameStatus(results["Items"][i]["game_completion_status"]["S"], results["Items"][i]["level_progress"]["S"],
                        results["Items"][i]["gameplay_duration"]["S"], results["Items"][i]["death_location"]["S"], results["Items"][i]["run_id"]["S"]));

                    if (results["Items"][i]["game_completion_status"]["S"] == "Incomplete")
                    {
                        if (results["Items"][i]["death_location"]["S"] != null)
                        {
                            //Debug.Log(results["Items"][i]["death_location"]["S"]);
                            collectedDeathLocation.Add(results["Items"][i]["death_location"]["S"]);
                        }
                    }

                }

                //LoadStringToVector(collectedDeathLocation, deathLocationOnScene, false);
                // PopulateRunIdsDict();
                // ScanDamageFlow("189");
            }
        }));
    }

    public void GenerateSurvivalPlotIE(JSONObject jObj, DateTime timeNow, string levelNumber)
    {
        level1CompCountIE = 0;
        level2CompCountIE = 0;
        level3CompCountIE = 0;
        level1CompletionIE = 0;
        level2CompletionIE = 0;
        level3CompletionIE = 0;

        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);

        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                //Debug.Log(results);
                // Sort results into an Action array
                actionPoints = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {

                    if (results["Items"][i]["level1"]["S"] == "Complete")
                    {

                        level1CompCountIE += 1;
                        level1CompletionIE += 1;

                    }

                    if (results["Items"][i]["level2"]["S"] == "Complete")
                    {

                        level2CompCountIE += 1;
                        level2CompletionIE += 1;

                    }

                    if (results["Items"][i]["level3"]["S"] == "Complete")
                    {

                        level3CompCountIE += 1;
                        level3CompletionIE += 1;


                    }

                }

                //Generate damage flow here
                ScanDamageFlowNewIE("TBD", levelNumber);
            }
        }));
    }

    public void GenerateDamageFlowIE(JSONObject jObj, DateTime timeNow, string levelNumber)
    {

        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);
        //Debug.Log("Query complete!");
        levelStatusDetails.Clear();
        collectedDeathLocationIEL1.Clear();
        collectedDeathLocationIEL2.Clear();
        collectedDeathLocationIEL3.Clear();
        refinedDeathLocationOnSceneIEL1.Clear();
        refinedDeathLocationOnSceneIEL2.Clear();
        refinedDeathLocationOnSceneIEL3.Clear();
        descendValueL1 = 0;
        descendValueL2 = 0;
        descendValueL3 = 0;


        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                //Debug.Log(results);
                // Sort results into an Action array
                actionPoints = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {

                    //Segregate the death locations based on level number

                    if (results["Items"][i]["level_number"]["S"] == "1")
                    {

                        level1CompCountIE += 1;
                        collectedDeathLocationIEL1.Add(results["Items"][i]["death_location"]["S"]);

                    }
                    if (results["Items"][i]["level_number"]["S"] == "2")
                    {

                        level2CompCountIE += 1;
                        collectedDeathLocationIEL2.Add(results["Items"][i]["death_location"]["S"]);



                    }
                    if (results["Items"][i]["level_number"]["S"] == "3")
                    {

                        level3CompCountIE += 1;
                        collectedDeathLocationIEL3.Add(results["Items"][i]["death_location"]["S"]);

                    }

                }

                //Debug.Log(levelNumber);
                //Debug.Log("Death count at Level 1: " + collectedDeathLocationL1.Count);
                //Debug.Log("Death count at Level 2: " + collectedDeathLocationL2.Count);
                //Debug.Log("Death count at Level 3: " + collectedDeathLocationL3.Count);

                if (level1CompletionIE == 0)
                    isL1CompletionNil = true;
                else
                    isL1CompletionNil = false;

                if (level2CompletionIE == 0)
                    isL2CompletionNil = true;
                else
                    isL2CompletionNil = false;

                if (level3CompletionIE == 0)
                    isL3CompletionNil = true;
                else
                    isL3CompletionNil = false;

                //gameStatusCount = gameStatusDetails.Count;
                //PopulateRunIdsDict();

               
                    LoadStringToVector(collectedDeathLocationIEL1, cloneDeathLocationOnSceneIEL1, true, levelNumber);
                    LoadStringToVector(collectedDeathLocationIEL1, deathLocationOnSceneIEL1, false, levelNumber);
                    ComputeDeathMarkersRatioIE(cloneDeathLocationOnSceneIEL1, level1CompCountIE, 1);
                    //plotCondition = true;
                    //plotScreenNumber = "1";

                    LoadStringToVector(collectedDeathLocationIEL2, cloneDeathLocationOnSceneIEL2, true, levelNumber);
                    LoadStringToVector(collectedDeathLocationIEL2, deathLocationOnSceneIEL2, false, levelNumber);
                    ComputeDeathMarkersRatioIE(cloneDeathLocationOnSceneIEL2, level2CompCountIE, 2);

                    LoadStringToVector(collectedDeathLocationIEL3, cloneDeathLocationOnSceneIEL3, true, levelNumber);
                    LoadStringToVector(collectedDeathLocationIEL3, deathLocationOnSceneIEL3, false, levelNumber);
                    ComputeDeathMarkersRatioIE(cloneDeathLocationOnSceneIEL3, level3CompCountIE, 3);
         
            }
        }));
    }

    public void LoadTestIDsFromDB(JSONObject jObj, DateTime timeNow)
    {
        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);
        Debug.Log("Query complete!");
        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                //Debug.Log(results);
                // Sort results into an Action array
                actionPoints = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {
                    totalTestIDs.Add(results["Items"][i]["test_serial_id"]["S"]);
                }

                Debug.Log("test serial IDS count" + totalTestIDs.Count);
            }
        }));
    }

    //public void ConsolidatedScanSurvivalData(string testIdDat)
    //{
    //    var obj = new JSONObject();
    //    DateTime now = DateTime.UtcNow;

    //    obj["TableName"] = "arapid-pp-level-completion";
    //    obj["FilterExpression"] = "test_serial_id = :val";
    //    obj["ExpressionAttributeValues"][":val"]["S"] = testIdDat;// -insert MainMenu test serial_id and remove playTestTag;
    //    obj["ReturnConsumedCapacity"] = "TOTAL";

    //    GenerateConsolidatedSurvivalPlot(obj, now);
    //}

    //public void GenerateConsolidatedSurvivalPlot(JSONObject jObj, DateTime timeNow, string levelNumber)
    //{

    //}

}

public class TrapTraces
{
    private string trapName;
    private string trapPosition;
    private string runId;

    public TrapTraces(string tn, string tp, string ri)
    {
        trapName = tn;
        trapPosition = tp;
        runId = ri;
    }

    public string TrapName
    {
        get
        {
            return trapName;
        }

        set
        {
            trapName = value;
        }
    }

    public string TrapPosition
    {
        get
        {
            return trapPosition;
        }

        set
        {
            trapPosition = value;
        }
    }

    public string RunId
    {
        get
        {
            return runId;
        }

        set
        {
            runId = value;
        }
    }
}

public class GameStatus
{
    private string completionRatio;
    private string levelProgression;
    private string gameplayDuration;
    private string deathLocation;
    private string runId;



    public GameStatus(string compRatio, string levelProgress, string gameDuration, string deathLoc, string runid)
    {
        completionRatio = compRatio;
        levelProgression = levelProgress;
        gameplayDuration = gameDuration;
        DeathLocation = deathLoc;
        runId = runid;
    }

    public string CompletionRatio
    {
        get
        {
            return completionRatio;
        }

        set
        {
            completionRatio = value;
        }
    }

    public string LevelProgression
    {
        get
        {
            return levelProgression;
        }

        set
        {
            levelProgression = value;
        }
    }

    public string GameplayDuration
    {
        get
        {
            return gameplayDuration;
        }

        set
        {
            gameplayDuration = value;
        }
    }

    public string DeathLocation
    {
        get
        {
            return deathLocation;
        }

        set
        {
            deathLocation = value;
        }
    }

    public string RunId
    {
        get
        {
            return runId;
        }

        set
        {
            runId = value;
        }
    }
}

public class LevelStatus
{

    private string completionRatio;
    private string currentLevel;
    private string deathLocation;
    private string runId;

    public LevelStatus(string completionRatio, string currentLevel, string deathLocation, string runId)
    {
        this.completionRatio = completionRatio;
        this.currentLevel = currentLevel;
        this.deathLocation = deathLocation;
        this.runId = runId;
    }

    public string CompletionRatio
    {
        get
        {
            return completionRatio;
        }

        set
        {
            completionRatio = value;
        }
    }

    public string CurrentLevel
    {
        get
        {
            return currentLevel;
        }

        set
        {
            currentLevel = value;
        }
    }



    public string DeathLocation
    {
        get
        {
            return deathLocation;
        }

        set
        {
            deathLocation = value;
        }
    }

    public string RunId
    {
        get
        {
            return runId;
        }

        set
        {
            runId = value;
        }
    }
}


