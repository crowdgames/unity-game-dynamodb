using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.SceneManagement;

namespace DynamoDB
{

    // Session-unique, persistent middle class that handles and transports 
    // data between DDBHTTP requests and the logger.
    //
    public class Dynode : MonoBehaviour
    {

        DDBHTTP http;
        public string table_name;
        public string primary_key;
        public string AWS_ACCESS_KEY_ID;
        public string AWS_SECRET_ACCESS_KEY;

        private string session_id;
        public string run_id;
        public int run_count;
        public int action_count;
        private DateTime startTime;
        private string currentVersion = "version 1.0";
        private string playTestTag = "PT";

   
        void Start()
        {
            // Achieve Session Persistence
            DontDestroyOnLoad(gameObject);

            // For detecting scene changes
            SceneManager.activeSceneChanged += onSceneChanged;
            // Call function on game start
            onSceneChanged(SceneManager.GetActiveScene(), SceneManager.GetActiveScene());

            session_id = generateID();
            startTime = DateTime.UtcNow;
  
            http = gameObject.AddComponent<DDBHTTP>();
            http.action = "DynamoDB_20120810.PutItem";
            http.AWS_ACCESS_KEY_ID = AWS_ACCESS_KEY_ID;
            http.AWS_SECRET_ACCESS_KEY = AWS_SECRET_ACCESS_KEY;

            //Debug.Log("Dynode instance created...");
        }

        // Send the DDBHTTP request
        //public void Send(JSONObject Item)
        //{
        //    action_count++;

        //    DateTime stamp = DateTime.UtcNow;

        //    var obj = new JSONObject();
        //    obj["TableName"] = table_name;
        //    obj["Item"] = Item;
        //    obj["Item"]["run_index"]["S"] = run_count.ToString();
        //    obj["Item"]["action_index"]["S"] = action_count.ToString();
        //    obj["Item"]["session_id"]["S"] = session_id;
        //    obj["Item"]["run_id"]["S"] = run_id;
        //    obj["Item"][primary_key]["S"] = generateID();
        //    obj["Item"]["timestamp"]["S"] = stamp.ToString();// (stamp - startTime).ToString();
        //    obj["Item"]["version"]["S"] = currentVersion;
        //    obj["Item"]["playtest_tag"]["S"] = playTestTag;
        //    obj["Item"]["test_serial_id"]["S"] = MainMenu.testID;

        //    http.BuildWWWRequest(obj.ToString(), stamp);
        //    //Debug.Log("data posted!");
        //    StartCoroutine(http.WaitForRequest(http.www, callback =>
        //    {
        //        if (callback != null)
        //        {
        //            //  Debug.Log(callback);
        //        }
        //    }));
        //}


        public void SendUpdatedPlayerTrajectories(JSONObject Item)
        {
            action_count++;

            DateTime stamp = DateTime.UtcNow;

            var obj = new JSONObject();
            obj["TableName"] = "arapid-pp-sub-player-trajectories";
            obj["Item"] = Item;
            obj["Item"]["run_index"]["S"] = run_count.ToString();
            obj["Item"]["action_index"]["S"] = action_count.ToString();
            obj["Item"]["session_id"]["S"] = session_id;
            obj["Item"]["run_id"]["S"] = run_id;
            obj["Item"][primary_key]["S"] = generateID();
            obj["Item"]["timestamp"]["S"] = stamp.ToString();// (stamp - startTime).ToString();
            obj["Item"]["version"]["S"] = currentVersion;
            obj["Item"]["playtest_tag"]["S"] = playTestTag;
            obj["Item"]["test_serial_id"]["S"] = "TBD";// MainMenu.testID;

            http.BuildWWWRequest(obj.ToString(), stamp);
            //Debug.Log("data posted!");
            StartCoroutine(http.WaitForRequest(http.www, callback =>
            {
                if (callback != null)
                {
                    //Debug.Log(callback);
                }
            }));
        }

        public void SendLevelCompletionStatus(string level1Status, string level2Status,
        string level3Status)
        {
            DateTime stamp = DateTime.UtcNow;

            var obj = new JSONObject();
            obj["TableName"] = "arapid-pp-level-completion";
            obj["Item"]["session_id"]["S"] = session_id;
            obj["Item"]["run_id"]["S"] = run_id;
            obj["Item"]["test_serial_id"]["S"] = "TBD";// MainMenu.testID;
            obj["Item"]["level1"]["S"] = level1Status;
            obj["Item"]["level2"]["S"] = level2Status;
            obj["Item"]["level3"]["S"] = level3Status;
            obj["Item"][primary_key]["S"] = generateID();
            obj["Item"]["timestamp"]["S"] = stamp.ToString();
            obj["Item"]["version"]["S"] = currentVersion;


            http.BuildWWWRequest(obj.ToString(), stamp);
            //Debug.Log(obj.ToString());
            StartCoroutine(http.WaitForRequest(http.www, callback =>
            {
                if (callback != null)
                {
                   // Debug.Log(callback);
                }
            }));

        }

        public void SendLevelStatus(string deathLocation, string levelNumber)
        {
            DateTime stamp = DateTime.UtcNow;

            var obj = new JSONObject();
            obj["TableName"] = "arapid-pp-level-status";
            obj["Item"]["session_id"]["S"] = session_id;
            obj["Item"]["run_id"]["S"] = run_id;
            obj["Item"]["test_serial_id"]["S"] = "TBD";// MainMenu.testID;
            obj["Item"]["level_number"]["S"] = levelNumber;
            obj["Item"]["death_location"]["S"] = deathLocation;
            obj["Item"][primary_key]["S"] = generateID();
            obj["Item"]["timestamp"]["S"] = stamp.ToString();
            obj["Item"]["version"]["S"] = currentVersion;


            http.BuildWWWRequest(obj.ToString(), stamp);
            //Debug.Log(obj.ToString());
            StartCoroutine(http.WaitForRequest(http.www, callback =>
            {
                if (callback != null)
                {
                    //Debug.Log(callback);
                }

                //player.ResetPlayer();
            }));

        }



        public void SendEntryLog()
        {
            //action_count++;

            DateTime stamp = DateTime.UtcNow;

            var obj = new JSONObject();
            obj["TableName"] = "arapid-pp-entry-log";
            obj["Item"]["session_id"]["S"] = session_id;
            obj["Item"]["run_id"]["S"] = run_id;
            obj["Item"][primary_key]["S"] = generateID();
            obj["Item"]["timestamp"]["S"] = stamp.ToString();
            obj["Item"]["version"]["S"] = currentVersion;
            obj["Item"]["playtest_tag"]["S"] = playTestTag;
            obj["Item"]["test_serial_id"]["S"] = "TBD";// MainMenu.testID;

            http.BuildWWWRequest(obj.ToString(), stamp);
            //Debug.Log("data posted!");
            StartCoroutine(http.WaitForRequest(http.www, callback =>
            {
                if (callback != null)
                {
                  //  Debug.Log(callback);
                }
            }));
        }




        public void SendMasterGameCompletionStatus(string gameCompletionStatus,
         string finalLocation, string gameplayStartTime)
        {
            DateTime stamp = DateTime.UtcNow;

            var obj = new JSONObject();
            obj["TableName"] = "arapid-pp-master-game-status";
            obj["Item"]["game_completion_status"]["S"] = gameCompletionStatus;
            obj["Item"]["run_id"]["S"] = run_id;
            obj["Item"][primary_key]["S"] = generateID();
            obj["Item"]["timestamp"]["S"] = stamp.ToString();
            obj["Item"]["version"]["S"] = currentVersion;
            obj["Item"]["playtest_tag"]["S"] = playTestTag;
            obj["Item"]["death_location"]["S"] = finalLocation;
            obj["Item"]["test_serial_id"]["S"] = "TBD";// MainMenu.testID;
            obj["Item"]["actual_test_starttime"]["S"] = "TBD";// MainMenu.actaulTestStartTime;
            obj["Item"]["gameplay_starttime"]["S"] = "TBD";// gameplayStartTime;

            http.BuildWWWRequest(obj.ToString(), stamp);
            //Debug.Log(obj.ToString());
            StartCoroutine(http.WaitForRequest(http.www, callback =>
            {
                if (callback != null)
                {
                    //Debug.Log(callback);
                }
            }));

        }


     
        public void SendMturkTestDetails(string testSerialId, string reqAssignments, string maxAssignments,
            string HITId, DDBHTTP httpCall)
        {
            DateTime stamp = DateTime.UtcNow;
            var obj = new JSONObject();
            //obj["TableName"] = "arapid-pp-sub-mturk-test-details";
            obj["TableName"] = "arapid-pp-updated-mturk-test-details";
            obj["Item"]["test_serial_id"]["S"] = testSerialId;
            obj["Item"][primary_key]["S"] = generateID();
            obj["Item"]["timestamp"]["S"] = stamp.ToString();
            obj["Item"]["HITId"]["S"] = HITId;
            obj["Item"]["version"]["S"] = currentVersion;
            obj["Item"]["required_assignments"]["S"] = reqAssignments;
            obj["Item"]["maximum_assignments"]["S"] = maxAssignments;
            httpCall.BuildWWWRequest(obj.ToString(), stamp);

            StartCoroutine(httpCall.WaitForRequest(httpCall.www, callback =>
            {
                if (callback != null)
                {
                    //Debug.Log(callback);
                }
            }));

        }




        public void SendTimestampsData(string testSerialId, string HITId, string taskStartTime,
           string taskEndTime, string taskTime, string totalTestTime, DDBHTTP httpCall)
        {
            DateTime stamp = DateTime.UtcNow;
            var obj = new JSONObject();
            obj["TableName"] = "arapid-pp-test-timestamps";
            obj["Item"]["test_serial_id"]["S"] = testSerialId;
            obj["Item"][primary_key]["S"] = generateID();
            obj["Item"]["HITId"]["S"] = HITId;
            obj["Item"]["task_starttime"]["S"] = taskStartTime;
            obj["Item"]["task_endtime"]["S"] = taskEndTime;
            obj["Item"]["task_time"]["S"] = taskTime;
            obj["Item"]["total_test_time"]["S"] = totalTestTime;
            obj["Item"]["playtest_tag"]["S"] = playTestTag;
            obj["Item"]["log_timestamp"]["S"] = stamp.ToString();

            httpCall.BuildWWWRequest(obj.ToString(), stamp);

            StartCoroutine(httpCall.WaitForRequest(httpCall.www, callback =>
            {
                if (callback != null)
                {
                   // Debug.Log(callback);
                    //Debug.Log("Posted timestamps!");
                }
            }));

        }


        // Random ID generator
        public string generateID()
        {
            return Guid.NewGuid().ToString();
        }

        // Every time a level is loaded.
        // Make sure you don't log during non-playing levels (such as menus).

        private void onSceneChanged(Scene one, Scene two)
        {
            run_id = generateID();
            run_count++;

            action_count = 0;
        }
    }
}