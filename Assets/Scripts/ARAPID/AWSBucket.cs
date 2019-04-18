using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System.IO;
using BayatGames.SaveGamePro.Examples;

public class AWSBucket : MonoBehaviour
{

    static string accessKey = "AKIAJECGJNEZOKCQUGYQ";
    static string secretKey = "TuHgi47FKDRRB9COTxrzyRpvsG1XBY24OdL0Xagd";
    string myBucket = "gameedits";
    IAmazonS3 client;


    void Awake()
    {
        UnityInitializer.AttachToGameObject(this.gameObject);
        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;
        AWSConfigs.CorrectForClockSkew = true;
        AWSConfigs.RegionEndpoint = RegionEndpoint.USEast2;
        AWSConfigs.LoggingConfig.LogTo = LoggingOptions.UnityLogger;
        AWSConfigs.LoggingConfig.LogResponses = ResponseLoggingOption.Always;
        AWSConfigs.LoggingConfig.LogMetrics = true;
        client = new AmazonS3Client(accessKey, secretKey, RegionEndpoint.USEast2);
    }



    public void PostFileToS3Bucket()
    {

        var stream = new FileStream(Application.persistentDataPath + "/" + SaveGameObject.fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
        var request = new PostObjectRequest()
        {
            Region = RegionEndpoint.USEast2,
            Bucket = myBucket,
            Key = SaveGameObject.fileName,
            InputStream = stream,
            CannedACL = S3CannedACL.PublicRead
        };


        client.PostObjectAsync(request, (responseObj) =>
        {
            if (responseObj.Exception == null)
            {
                Debug.Log(responseObj.Request.Key + " posted to bucket " + responseObj.Request.Bucket);
            }
            else
            {
                Debug.Log("Receieved error" + responseObj.Response.HttpStatusCode.ToString());
            }
        });
    }



    //// Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

}
