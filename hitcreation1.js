


var AWS = require('aws-sdk');
fs = require('fs');
var datetime = require('node-datetime');

var region = 'us-east-1';
var aws_access_key_id = 'AKIAJSAFDSZIHP2F5KRQ';
var aws_secret_access_key = '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';
var testId;

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




fs.readFile('myQuestion2.xml', 'utf8', function (err, myQuestion) {
    if (err) {
        return console.log(err);
    }

var data = fs.readFileSync('writeTestSerialIds.txt','utf8');

testId = data.toString();
    // Construct the HIT object below
    var myHIT = {
        Title: 'This HIT is for worker ID xxxxxxxxx6UEZ3 ONLY - All other submissions will be rejected',
        Description: 'PLEASE NOTE, THIS HIT IS FOR A SPECIFIC WORKER ONLY. ALL OTHERS WILL BE REJECTED',
        MaxAssignments: 1,
        LifetimeInSeconds: 86400,
        AssignmentDurationInSeconds: 900,
        Reward: '0.30',
        Keywords:"survey",
        Question: myQuestion,

        // Add a qualification requirement that the Worker must be either in Canada or the US 
        QualificationRequirements: [
            {
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
  
