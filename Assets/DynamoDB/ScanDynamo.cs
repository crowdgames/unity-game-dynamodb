using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
//using WindowsInput;

public class ScanDynamo : MonoBehaviour {

    DynamoDB.DDBHTTP http;
    public GameObject player;
    public string run_id;
    public string key;
    public string secret;
    Button get;
    LogAction[] points;

    void Start() {
        http = gameObject.AddComponent<DynamoDB.DDBHTTP>();
        http.action = "DynamoDB_20120810.Scan";
        http.AWS_ACCESS_KEY_ID = key;
        http.AWS_SECRET_ACCESS_KEY = secret;

        get = gameObject.GetComponent<Button>();
        get.onClick.AddListener(Scan);
    }


    // Method for querying the data for a specific run, 
    // and then moving the player along the path data
    void Scan()
    {
        var obj = new JSONObject();
        DateTime now = DateTime.UtcNow;

        obj["TableName"] = "Unity";
        obj["FilterExpression"] = "run_id = :val";
        obj["ExpressionAttributeValues"][":val"]["S"] = run_id;
        obj["ReturnConsumedCapacity"] = "TOTAL";

        http.BuildWWWRequest(obj.ToString(), now);

        StartCoroutine(http.WaitForRequest(http.www, callback => {
            if (callback != null)
            {
                // Put results from callback into a JSON object
                var results = JSON.Parse(callback);
                
                // Sort results into an Action array
                points = new LogAction[results["Items"].Count];
                for(int i = 0; i < results["Items"].Count; i++) {
                    for(int p = 0; p < results["Items"].Count; p++)
                    {
                        if(results["Items"][p]["action_count"]["S"].AsInt == i + 1)
                        {
                            string action = results["Items"][p]["Action"]["S"].Value;
                            double time = results["Items"][p]["Stamp"]["S"].AsDouble;
                            int action_count = results["Items"][p]["action_count"]["S"].AsInt;
                            points[i] = new LogAction(action, time, action_count);
                        }
                    }
                }

                // Move player to first logged point
                //iTween.MoveTo(player, new Vector2(points[0].x, points[0].y), 1.0f);

                /*for(int i = 1; i < points.Length; i++)
                {
                    float duration = Convert.ToSingle(points[i].stamp - points[i - 1].stamp);
                    iTween.MoveTo(player, new Vector2(points[i].x, points[i].y), 1.0f);
                    new WaitForSeconds(1.0f);
                }*/

                // Move player along path using recursive couroutines.
                // This initial time passed in is just an initial delay.
                //StartCoroutine(ExecuteAfterTime(1.0f, 0));

                //InputSimulator.SimulateKeyDown(VirtualKeyCode.RIGHT);
            }
        }));
    }

    //IEnumerator ExecuteAfterTime(float time, int action_count)
    //{
    //    yield return new WaitForSeconds(time);

    //    // Code to execute after the delay
    //    if (action_count + 1 < points.Length)
    //    {
    //        Debug.Log("Perform event: " + points[action_count].action);
    //        PerformEvent(points[action_count].action);
    //        float duration = Convert.ToSingle(points[action_count + 1].stamp - points[action_count].stamp);
    //        StartCoroutine(ExecuteAfterTime(duration, action_count + 1));
    //    }
    //}

    //void PerformEvent(string Event)
    //{
    //    switch(Event)
    //    {
    //        case "RightDown": InputSimulator.SimulateKeyDown(VirtualKeyCode.RIGHT); break;
    //        case "RightUp": InputSimulator.SimulateKeyUp(VirtualKeyCode.RIGHT); break;
    //        case "LeftDown": InputSimulator.SimulateKeyDown(VirtualKeyCode.LEFT); break;
    //        case "LeftUp": InputSimulator.SimulateKeyUp(VirtualKeyCode.LEFT); break;
    //        case "UpDown": InputSimulator.SimulateKeyDown(VirtualKeyCode.UP); break;
    //        case "UpUp": InputSimulator.SimulateKeyUp(VirtualKeyCode.UP); break;
    //        case "SDown": InputSimulator.SimulateKeyDown(VirtualKeyCode.VK_S); break;
    //        case "SUp": InputSimulator.SimulateKeyUp(VirtualKeyCode.VK_S); break;
    //        default: Debug.Log("Unknown key event"); break;
    //    }
    //}
}

// Action class for storing key events
public class LogAction
{
    public string action;
    public double stamp;
    public int action_count;

    public LogAction(string a, double time, int actionCount)
    {
        action = a;
        stamp = time;
        action_count = actionCount;
    }

    override
    public string ToString()
    {
        return "ActionCount: " + action_count + " - Stamp: " + stamp;
    }
}

public class ActionNew
{
    public string action;
    public double stamp;
    public int action_count;

    public ActionNew(string a, double time, int actionCount)
    {
        action = a;
        stamp = time;
        action_count = actionCount;
    }

    override
    public string ToString()
    {
        return "ActionCount: " + action_count + " - Stamp: " + stamp;
    }
}