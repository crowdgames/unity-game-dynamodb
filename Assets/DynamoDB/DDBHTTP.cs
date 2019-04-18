using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;
using System;
using System.Globalization;

namespace DynamoDB
{

    public class DDBHTTP : MonoBehaviour
    {

        public string AWS_ACCESS_KEY_ID;// = awsAccessKeyID;
        public string AWS_SECRET_ACCESS_KEY;// = awsSecretAccessKey;
        public string action = "DynamoDB_20120810.Scan";
        public string response;

        public WWW www;

        public const string ISO8601BasicDateTimeFormat = "yyyyMMddTHHmmssZ";
        public const string ISO8601BasicDateFormat = "yyyyMMdd";
        public const string Scheme = "AWS4";
        public const string Algorithm = "HMAC-SHA256";
        public const string Terminator = "aws4_request";

        public static readonly byte[] TerminatorBytes = Encoding.UTF8.GetBytes(Terminator);

        /// Constructor
        public DDBHTTP(string a)
        {
            action = a;
        }


        /// <summary>
        /// Unity uses reflection to invoke any Start() methods when the program runs, so
        /// Start() is where we begin the request - pretty simple
        /// </summary>
        void Start()
        {
            Debug.Log("DDBHTTP instance created.");
        }

        /// <summary>
        /// Try to build request with the string provided.  For simplicity, we're just assuming
        /// this is all describe-table.  It seems to the most basic thing I could do.
        /// </summary>
        /// <param name="payload"></param>
        public void BuildWWWRequest(string payload, DateTime now)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();

            // Determine the time of the request only once at the beginning of the request to stay consistent.
            // (Don't call DateTime.UtcNow any more)
            // DateTime now = DateTime.UtcNow;

            // all of this is pretty specific for doing DescribeTable on specific table in specific region endpoint
            // you'll need to modify this for your own settings
            string dateHeaderName = "x-amz-date";
            string dateHeaderValue = FormatDateTime(now, ISO8601BasicDateTimeFormat);
            string targetHeaderName = "x-amz-target";
            string targetHeaderValue = action;
            string method = "POST";
            string service = "dynamodb";
            string host = "dynamodb.us-west-2.amazonaws.com";
            string region = "us-west-2";
            string contentType = "application/x-amz-json-1.0";
            string endpoint = "http://dynamodb.us-west-2.amazonaws.com/";

            // quite sure this was needed, but appears to work without
            //string request_parameters = "DynamoDB_20120810.DescribeTable";

            string signedHeaders = "content-type;host;" + dateHeaderName + ";" + targetHeaderName;

            // create a hashing object
            HashAlgorithm hash = HashAlgorithm.Create("SHA-256");
            hash.Initialize();

            //**************************************
            // Task 1: Create a Canonical Request For Signature Version 4
            //**************************************

            // convert the actual request to bytes
            // payloadBytes for the request will be preserved as bytes in this variable
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);

            // IMPORTANT! reset the hasher function before every use!
            hash.Initialize();
            string payloadBytesHash = ToHex(hash.ComputeHash(payloadBytes), true);

            string canonicalString = method + "\n"
                + "/" + "\n"
                + "" + "\n"
                + "content-type:" + contentType + "\n"
                + "host:" + host + "\n"
                + dateHeaderName + ":" + dateHeaderValue + "\n"
                + targetHeaderName + ":" + targetHeaderValue + "\n"
                + "\n"
                + signedHeaders + "\n"
                + payloadBytesHash;
            //Debug.Log(canonicalString);

            //**************************************
            // Task 2: Create a String to Sign for Signature Version 4
            //**************************************

            // create hash to add to string to sign
            // IMPORTANT! reset the hasher function before every use!
            hash.Initialize();
            string hashedCanonicalRequest = ToHex(hash.ComputeHash(Encoding.UTF8.GetBytes(canonicalString)), true);

            var scope = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}/{3}",
                FormatDateTime(now, ISO8601BasicDateFormat),
                region,
                service,
                Terminator);

            var stringToSign = new StringBuilder();
            stringToSign.AppendFormat(CultureInfo.InvariantCulture, "{0}-{1}\n{2}\n{3}\n",
                Scheme,
                Algorithm,
                FormatDateTime(now, ISO8601BasicDateTimeFormat),
                scope);
            stringToSign.Append(hashedCanonicalRequest);
            //Debug.Log(stringToSign);

            //**************************************
            // Task 3: Calculate the AWS Signature Version 4
            //**************************************

            // create signing key
            byte[] signingKey = ComposeSigningKey(AWS_SECRET_ACCESS_KEY, region, FormatDateTime(now, ISO8601BasicDateFormat), service);
            string encodedSigningKey = ToHex(signingKey, true);
            //Debug.Log("encodedSigningKey = " + encodedSigningKey);

            // use key and stringToSign to create signature
            byte[] signature = HMACSignBinary(Encoding.UTF8.GetBytes(stringToSign.ToString()), signingKey);
            string encodedSignature = ToHex(signature, true);
            //Debug.Log("encodedSignature = " + encodedSignature);

            //**************************************
            // Task 4: Add the Signing Information to the Request
            //**************************************

            // Create Authorization header
            string auth = "AWS4-HMAC-SHA256 Credential=" + AWS_ACCESS_KEY_ID + "/" + FormatDateTime(now, ISO8601BasicDateFormat)
            + "/" + region + "/" + service + "/aws4_request"
            + ", SignedHeaders=" + signedHeaders
            + ", Signature=" + encodedSignature;

            // Add Authorization header
            headers.Add("Authorization", auth);

            // Add other headers
            headers.Add("host", host);
            headers.Add(dateHeaderName, dateHeaderValue);
            headers.Add(targetHeaderName, targetHeaderValue);
            headers.Add("content-type", contentType);

            // View all headers
            //foreach (KeyValuePair<string, string> entry in headers)
            //    Debug.Log("HEADER = " + entry.Key + ":" + entry.Value);

            // I don't know when this was changed, but it was... 
#if UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2
            Hashtable table = new Hashtable(headers);
   
            // Setup the request url to be sent to DynamoDB
            WWW www = new WWW(endpoint, Encoding.UTF8.GetBytes(payload), table);
#else
            // Setup the request url to be sent to DynamoDB
            www = new WWW(endpoint, Encoding.UTF8.GetBytes(payload), headers);
#endif
            // Send the request in this coroutine so as not to wait busily
            // StartCoroutine(WaitForRequest(www));
        }

        /// <summary>
        /// Formats the DateTime to correct output as needed
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="formatString"></param>
        /// <returns></returns>
        public static string FormatDateTime(DateTime dt, string formatString)
        {
            return dt.ToString(formatString, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats a bunch of bytes into numbers
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string FormatBytes(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b + ", ");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Converts byte[] to hex
        /// </summary>       
        public static string ToHex(byte[] data, bool lowercase)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString(lowercase ? "x2" : "X2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }

        /// <summary>
        /// Creates signing key
        /// </summary>
        public static byte[] ComposeSigningKey(string awsSecretAccessKey, string region, string date, string service)
        {
            char[] ksecret = null;

            try
            {
                ksecret = (Scheme + awsSecretAccessKey).ToCharArray();
                var hashDate = HMACSignBinary(Encoding.UTF8.GetBytes(date), Encoding.UTF8.GetBytes(ksecret));
                var hashRegion = HMACSignBinary(Encoding.UTF8.GetBytes(region), hashDate);
                var hashService = HMACSignBinary(Encoding.UTF8.GetBytes(service), hashRegion);
                return HMACSignBinary(TerminatorBytes, hashService);
            }
            finally
            {
                // clean up all secrets, regardless of how initially seeded (for simplicity)
                if (ksecret != null)
                    Array.Clear(ksecret, 0, ksecret.Length);
            }
        }

        /// <summary>
        /// Use hashing algorithm to compute a value using the signing key and data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] HMACSignBinary(byte[] data, byte[] key)
        {
            if (key == null || key.Length == 0)
                throw new ArgumentNullException("key", "Please specify a Secret Signing Key.");

            if (data == null || data.Length == 0)
                throw new ArgumentNullException("data", "Please specify data to sign.");

            KeyedHashAlgorithm algorithm = KeyedHashAlgorithm.Create("HmacSHA256".ToUpper(CultureInfo.InvariantCulture));
            if (null == algorithm)
                throw new InvalidOperationException("Please specify a KeyedHashAlgorithm to use.");

            try
            {
                algorithm.Key = key;
                byte[] bytes = algorithm.ComputeHash(data);
                return bytes;
            }
            finally
            {
                algorithm.Clear();
            }
        }

        /// <summary>
        /// Unity's built-in coroutine / IEnumerator which sends the HTTP Request, processes the rest of the program normally
        /// while checking back each frame to see if there is a response.  Nonblocking.
        /// </summary>
        /// <param name="www"></param>
        /// <returns></returns>
        public IEnumerator WaitForRequest(WWW www, Action<string> response)
        {
            yield return www;

            // Check for errors in the response
            if (www != null)
            {
                //Debug.Log("WWW Successful Response: " + www.text);
                response(www.text);

                //foreach (var item in www.responseHeaders)
                //  Debug.Log(item.ToString());
            }
            else
            {
                // The kick in the face is that this error is very, very generic.
                // In order to actually see real information on an error, you'll
                // need to use wireshark and look at the response
                Debug.Log("WWW Error: " + www.error);
            }
        }
    }

}
