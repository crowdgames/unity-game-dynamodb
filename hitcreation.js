


var AWS = require('aws-sdk');
fs = require('fs');
var datetime = require('node-datetime');

var region = 'us-east-1';
var aws_access_key_id = 'AKIAJSAFDSZIHP2F5KRQ';
var aws_secret_access_key = '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';
var testId;
var maximumAssignments;

AWS.config = {
    "accessKeyId": aws_access_key_id,
    "secretAccessKey": aws_secret_access_key,
    "region": region,
    "sslEnabled": 'true'
};

var endpoint = 'https://mturk-requester-sandbox.us-east-1.amazonaws.com';

// Uncomment this line to use in production
//endpoint = 'https://mturk-requester.us-east-1.amazonaws.com';

var mturk = new AWS.MTurk({ endpoint: endpoint });

// This will return $10,000.00 in the MTurk Developer Sandbox
mturk.getAccountBalance(function(err, data){
    console.log("Your available balance: "+ data.AvailableBalance);
});




fs.readFile('myQuestion1.xml', 'utf8', function (err, myQuestion) {
    if (err) {
        return console.log(err);
    }

var data = fs.readFileSync('writeTestSerialIds.txt','utf8');
//testId = data.toString();
var dat = data.split("\t");
testId = dat[0];
maximumAssignments = Number(dat[2]);

    // Construct the HIT object below
    var myHIT = {
        Title: 'Gameplay Task - '+ testId,
        Description: 'Game play test survey',
        MaxAssignments: maximumAssignments, //3,
        LifetimeInSeconds: 10800,
        AssignmentDurationInSeconds: 1800,
        Reward: '0.30',
        Keywords:"survey",
        Question: myQuestion,

        // Add a qualification requirement that the Worker must be either in Canada or the US 
        QualificationRequirements: [
            {
               // QualificationTypeId: '3SHVTVENCCU3LKP8252ZI7VFOC3SJ7',
                //Comparator: 'DoesNotExist',
                //IntegerValues: null,       
                //LocaleValues: null,

                QualificationTypeId: '00000000000000000071',
                Comparator: 'In',
                LocaleValues: [
                { Country: 'US' },
                { Country: 'CA' },
                ],
            },
        ],
    };

    // Publish the object created above
    mturk.createHIT(myHIT, function (err, data) {
        if (err) {
            console.log(err.message);
        } else {
            console.log(data);
            // Save the HITId printed by data.HIT.HITId and use it in the RetrieveAndApproveResults.js code sample

           var dt = datetime.create(new Date());

            var formattedDate = dt.format('m/d/y H:M:S');

            var myHITData = formattedDate + " -- " +'HITID - '+ data.HIT.HITId;
            fs.appendFile("HITsData.txt", myHITData + '\r\n','utf8');
            console.log('HIT has been successfully published here: https://workersandbox.mturk.com/mturk/preview?groupId=' + data.HIT.HITTypeId + ' with this HITId: ' + data.HIT.HITId);
        }
    })
});
  
