//Initial Variables
var ipAddress = require('os').networkInterfaces().wlan0[1].address;
var webSocketPort = 3000;//port to serve web page
var webPagePort = 3001;//port to serve game

/////////////////////////////////////////
//MATRIX Dashboard
setInterval(function(){
    matrix.type('ipAddress').send({
        'websiteIP': ipAddress+':'+webPagePort,
        'gameIP': ipAddress+':'+webSocketPort
    });
},1000);

/////////////////////////////////////////
//MATRIX Gyroscope
var yaw = 0;
var pitch = 0;
var roll = 0;

var options = {
  refresh: 50, //milliseconds
  timeout: 15000 //milliseconds
};
//start gyroscope and set variables
matrix.init('gyroscope', options).then(function(data){
  yaw = Math.trunc(data.yaw);
  pitch = Math.trunc(data.pitch); 
  roll = Math.trunc(data.roll);
});

/////////////////////////////////////////
//Web Socket Server
var ws = require('nodejs-websocket');
console.log('Game Server Initiated');
//Server Start && On Client Connection
ws.createServer(function (conn) {
	console.log('New connection');
    //on client response
    conn.on('binary', function (inStream) {
        // Empty buffer for collecting binary data 
        var data = new Buffer(0);
        // Read chunks of binary data and add to the buffer 
        inStream.on('readable', function () {
            var newData = inStream.read();
            if (newData)
                data = Buffer.concat([data, newData], data.length+newData.length);
        });
        inStream.on('end', function () {
            console.log('Received Ready Status');
            conn.sendText(''+yaw+'/'+pitch+'/'+roll+'');//send client data
        });
    });
    //on client disconnect
    conn.on('close', function () {
        console.log('Connection closed');
    });
    //on client error
    conn.on('error', function (error) {
        console.log(error+'\nConnection Error');
    });
}).listen(webSocketPort);

/////////////////////////////////////////
//Express Server
var express = require('express');
var app = express();
var http = require('http').Server(app);

//serve game folder
app.use(express.static(__dirname+'/game'));
//log server running
http.listen(webPagePort,function(){
    console.log('Web Server Initiated' );
});


