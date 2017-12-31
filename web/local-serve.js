var express = require('express');
var app = express();

app.use(express.static(__dirname));

// Listen for requests
app.listen(9001, function () {
    console.log('Magic happens on port ' + 9001);
});