﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Linq;

public class SkillManager : MonoBehaviour {

    public string server_data = "";
    public string server_request = "";
    public string server_error = "";
    public string level = "";
    public string scenario = "";
    public float score = 0f;
    public float score_game = 0f;
    public float score_task = 0f;

    Dictionary<string, string> mapping;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        mapping = new Dictionary<string, string>();
        mapping.Add("sports", "Sports Store");
        mapping.Add("grocery", "Grocery Store");
        mapping.Add("pastry", "Pastry Shop");
        mapping.Add("hardware", "Hardware Store");
        mapping.Add("clothing", "Clothing Store");
    }

    public IEnumerator RegisterPlayer(int trurat=1500)
    {
        Debug.Log("REGISTER PLAYER");
        //string reg_player = "http://" + DataManager.host + "/register?q={\"id\":\"" + DataManager.player_id + "\",\"type\":\"player\",\"trurat\":" + trurat + "}";
        //server_request = "http://" + DataManager.host + "/register?q={\"id\":\"" + DataManager.player_id + "\",\"type\":\"player\",\"trurat\":" + trurat + "}";
        server_request = "http://" + DataManager.host + "/register?q={\"id\":\"" + DataManager.player_id + "\",\"type\":\"player\"}";
        //Debug.Log(reg_player);
        yield return StartCoroutine(ContactServer());
    }

    public IEnumerator ContactServer()
    {
        //Debug.Log(rp);
        //UnityWebRequest www = UnityWebRequest.Get(rp);
        UnityWebRequest www = UnityWebRequest.Get(server_request);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("WWW ERROR: " + www.error);
            server_data = "ERROR";
            //LevelManager lm = GameObject.Find("Character").GetComponent<Logger>();
            LevelManager lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            StartCoroutine(lm.ShowError());
        }
        else
        {
            LevelManager lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            lm.HideError();
            server_data = www.downloadHandler.text;
            //byte[] results = www.downloadHandler.data;
        }
    }
    
    public IEnumerator ReportAndRequest()
    {
     //   Debug.Log("INSIDE REPORTANDREQUEST");
        string token = DateTime.UtcNow.ToString();
        if (DataManager.matchmaking == 0)
        {
            string report = "http://" + DataManager.host + "/reportMatch?q={\"token\":\"" + token + "\",\"id1\":\"" + DataManager.player_id + "\",\"id2\":\"" + level + "\",\"score1\":\"" + score + "\"}";
            server_request = "http://" + DataManager.host + "/reportMatch?q={\"token\":\"" + token + "\",\"id1\":\"" + DataManager.player_id + "\",\"id2\":\"" + level + "\",\"score1\":\"" + score + "\"}";
            Debug.Log("***REPORT****: " + report);
        }
        else
        {
            string task = "";
            foreach(string m in mapping.Keys)
            {
                if(mapping[m] == scenario)
                {
                    task = m;
                    break;
                }
            }
            task = task + "_" + level.Substring(level.LastIndexOf("_") + 1, 1);
            level = level.Substring(0, level.LastIndexOf("_"));
            Debug.Log(task + "\t" + level);
            string report = "http://" + DataManager.host + "/reportMatch?q={\"token\":\"" + token + "\",\"id1\":\"" + DataManager.player_id + "\",\"id2\":\"" + level + "\",\"id3\":\"" + task + "\",\"score_game\":\"" + score_game + "\",\"score_task\":\"" + score_task + "\"}";
            server_request = "http://" + DataManager.host + "/reportMatch?q={\"token\":\"" + token + "\",\"id1\":\"" + DataManager.player_id + "\",\"id2\":\"" + level + "\",\"id3\":\"" + task + "\",\"score_game\":\"" + score_game + "\",\"score_task\":\"" + score_task + "\"}";
            Debug.Log("***REPORT****: " + report);
        }
        //yield return StartCoroutine(ContactServer(report));
        yield return StartCoroutine(ContactServer());
        Debug.Log("DATA FROM REPORT: " + server_data);
        if (server_data != "ERROR")
        {
            string request = "http://" + DataManager.host + "/requestMatch?q={\"id\":\"" + DataManager.player_id + "\"}";
            server_request = "http://" + DataManager.host + "/requestMatch?q={\"id\":\"" + DataManager.player_id + "\"}";
            Debug.Log("***REQ***: " + request);
            yield return StartCoroutine(ContactServer());
            Debug.Log("DATA FROM REQUEST: " + server_data);
        }
        else
            server_error = "ReportAndRequest";
    }

    public void RegisterAndGetFirstMatch()
    {
        StartCoroutine(StartGame());
    }

    public IEnumerator StartGame()
    {
        //Debug.Log("Inside StartGame");
        yield return StartCoroutine(RegisterPlayer());
        if (server_data != "ERROR")
            StartCoroutine(RequestMatch());
        else
            server_error = "StartGame";
        //Debug.Log("Exiting StartGame");
    }

    public IEnumerator RequestMatch()
    {
        Debug.Log("REQUESTING A MATCH");
        string request = "http://" + DataManager.host + "/requestMatch?q={\"id\":\"" + DataManager.player_id + "\"}";
        server_request = "http://" + DataManager.host + "/requestMatch?q={\"id\":\"" + DataManager.player_id + "\"}";
        Debug.Log(request);
        yield return StartCoroutine(ContactServer());
        Debug.Log("DATA FROM REQUEST: " + server_data);
        string first_level = "";
        if(DataManager.matchmaking == 0)
            first_level = server_data.Substring(server_data.IndexOf("Level"), 10);
        else
        {
            first_level = ParseRequestResponse();
        }

        SceneManager.LoadScene(first_level);
    }

    public string ParseRequestResponse()
    {
        string lev = "";
        string after_data1 = server_data.Substring(server_data.IndexOf("data1") + 9);
        //Debug.Log("after1: " + after_data1);
        int index = after_data1.IndexOf("\"");
        //Debug.Log(index);
        lev = server_data.Substring(server_data.IndexOf("data1") + 9, index);
        //Debug.Log("Lev: " + lev);

        string scen = "";
        string after_data2 = server_data.Substring(server_data.IndexOf("data2") + 9);
        //Debug.Log("after2: " + after_data2);
        index = after_data2.IndexOf("\"");
        //Debug.Log(index);
        scen = server_data.Substring(server_data.IndexOf("data2") + 9, index);
        //Debug.Log("Scen: " + scen);

        int num_items = int.Parse(scen.Substring(scen.IndexOf("_") + 1));
        scen = scen.Substring(0, scen.IndexOf("_"));
        scenario = mapping[scen];
        lev = lev + "_" + num_items;
        return lev;
    }
}
