
fs = require('fs');

var data = fs.readFileSync('writeTestSerialIds.txt','utf8');
//testId = data.toString();
var dat = data.split("\t");
testId = dat[0];
maximumAssignments = Number(dat[2]);
console.log(typeof maximumAssignments);
console.log("Your Test ID "+ testId +" "+"Maximum Assignments "+maximumAssignments);