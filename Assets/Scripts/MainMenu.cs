using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;
using System;
using System.Linq;

public class MainMenu : MonoBehaviour {

    bool isRetainerEntry = true;
    DynamoDB.Dynode dynode;
    DynamoDB.DDBHTTP httpCalls;
    public string awsAccessKeyID = "";
    public string awsSecretAccessKey = "";
    public string tableName;
    public string primaryKey;
    public string log;
    public bool logging;


    public GameObject playButton;
    public Text loadingText;
    public Button btn_start;
    public Button btn_info;
    public Button btn_play;
    public Button btn_back;
    public Button btn_back2;
    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas canvas3;
    public static string username;


    public static string testID;
    public static int requiredAssignments;
    public static bool triggerLogs = true;
    int gameStatusTableCount = 0;

    ActionNew[] actionPoints;
    private string version = "version 1.0";
    public GameObject sHttp;
    private DynamoDB.DDBHTTP httpScript;
    public string key;
    public string secret;

    Dictionary<int, TestConfigurationData> testIDsFromDB = new Dictionary<int, TestConfigurationData>();
    List<int> gameStatusCount = new List<int>();

    string testMode;
    public static string actaulTestStartTime;

    // Use this for initialization
    void Start () {

        playButton.SetActive(false);
        CanvasSwitch(2);
        InitiateHttp();

        ScanMturkTestIds();

        btn_play.onClick.AddListener(PlayButton);
        CanvasSwitch(1);

        //btn_start.onClick.AddListener(StartButton);
        //btn_info.onClick.AddListener(InfoButton);
        //btn_play.onClick.AddListener(PlayButton);
        //btn_back.onClick.AddListener(BackButton);
        //btn_back2.onClick.AddListener(BackButton2);
    }

    void StartButton()
    {
        CanvasSwitch(2);
    }

    void InfoButton()
    {
        CanvasSwitch(3);
    }

    void PlayButton()
    {
        InputField input = canvas2.GetComponentInChildren<InputField>();
        username = input.text;
        SceneManager.LoadScene(1);
    }

    void BackButton()
    {
        CanvasSwitch(1);
    }

    void BackButton2()
    {
        CanvasSwitch(1);
    }

    void CanvasSwitch(int index)
    {
        switch(index)
        {
            case 1:
                {
                    canvas1.gameObject.SetActive(true);
                    canvas2.gameObject.SetActive(false);
                    canvas3.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    canvas1.gameObject.SetActive(false);
                    canvas2.gameObject.SetActive(true);
                    canvas3.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    canvas1.gameObject.SetActive(false);
                    canvas2.gameObject.SetActive(false);
                    canvas3.gameObject.SetActive(true);
                    break;
                }
            default: break;
        }
    }

    void InitiateHttp()
    {
        httpScript = sHttp.GetComponent<DynamoDB.DDBHTTP>();
        httpScript.action = "DynamoDB_20120810.Scan";
        httpScript.AWS_ACCESS_KEY_ID = key;
        httpScript.AWS_SECRET_ACCESS_KEY = secret;
    }

    public void ScanMturkTestIds()
    {
        // Extract using the player
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;
        // obj["TableName"] = "arapid-pp-sub-mturk-test-details";
        obj["TableName"] = "arapid-pp-updated-mturk-test-details";
        obj["FilterExpression"] = "version = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = version;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        GatherTestIDs(obj, now);
    }

    public void ExtractGameStatusCount()
    {
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "arapid-pp-game-status";
        obj["FilterExpression"] = "test_serial_id = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = testID;// -insert MainMenu test serial_id and remove playTestTag;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        QueryGameStatus(obj, now);

    }

    public void GatherTestIDs(JSONObject jObj, DateTime timeNow)
    {

        httpScript.BuildWWWRequest(jObj.ToString(), timeNow);

        StartCoroutine(httpScript.WaitForRequest(httpScript.www, callback =>
        {
            if (callback != null)
            {
                // Debug.Log(callback);
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                //Debug.Log("My results for GatherTestIds " + results);
                // Sort results into an Action array
                actionPoints = new ActionNew[results["Items"].Count];
                for (int i = 0; i < results["Items"].Count; i++)
                {
                    if (!testIDsFromDB.ContainsKey(results["Items"][i]["test_serial_id"]["S"]))
                    {
                        testIDsFromDB.Add(results["Items"][i]["test_serial_id"]["S"], new TestConfigurationData(results["Items"][i]["test_mode"]["S"], results["Items"][i]["timestamp"]["S"],
                            results["Items"][i]["required_assignments"]["S"]));
                    }
                    //testMode = results["Items"][i]["test_mode"]["S"];

                }

                testID = testIDsFromDB.Keys.Max().ToString();
                requiredAssignments = Int32.Parse(testIDsFromDB[testIDsFromDB.Keys.Max()].RequiredAssignments);





                //ExtractGameStatusCount();

                //Comment this line for actual Mturk impl
                //playButton.SetActive(true);
                Debug.Log("TestID " + testID + "------" + "Required assignments " + requiredAssignments);
            }


        }));
    }

    public void QueryGameStatus(JSONObject jObj, DateTime timeNow)
    {
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
                    gameStatusCount.Add(1);
                }
            }
            gameStatusTableCount = gameStatusCount.Count;
            Debug.Log("Game status table count " + gameStatusTableCount);
            DetermineLoggingStatus();
            loadingText.text = "Press Play button to continue";
            playButton.SetActive(true);

        }));
    }

    void DetermineLoggingStatus()
    {
        if (gameStatusTableCount >= requiredAssignments)
        {
            triggerLogs = false;
        }

        if (gameStatusTableCount < requiredAssignments)
        {
            triggerLogs = true;
        }

        Debug.Log("Logging status " + triggerLogs);
    }
}

public class TestConfigurationData
{
    string testMode;
    string timestamp;
    string requiredAssignments;

    public string TestMode
    {
        get
        {
            return testMode;
        }

        set
        {
            testMode = value;
        }
    }

    public string Timestamp
    {
        get
        {
            return timestamp;
        }

        set
        {
            timestamp = value;
        }
    }

    public string RequiredAssignments
    {
        get
        {
            return requiredAssignments;
        }

        set
        {
            requiredAssignments = value;
        }
    }

    public TestConfigurationData(string testMode, string timestamp, string requiredAssignments)
    {
        this.TestMode = testMode;
        this.Timestamp = timestamp;
        this.RequiredAssignments = requiredAssignments;
    }
}
