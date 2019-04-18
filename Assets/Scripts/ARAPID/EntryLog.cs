using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryLog
{

    private string runId;
    private string timestamp;


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



    public EntryLog(string runId, string timestamp)
    {
        this.runId = runId;
        this.timestamp = timestamp;
    }
}
