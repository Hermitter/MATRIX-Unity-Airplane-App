//Initial Variables
var imu = require('./imu.js');//MATRIX CORE Gyroscope Data
var webSocketPort = 3000;//port to serve web page
var webPagePort = 3001;//port to serve game

/////////////////////////////////////////
//MATRIX Gyroscope
var yaw = 0;
var pitch = 0;
var roll = 0;

//Obtain Gyroscope Data
function imuData(){
    if(imu.gyroscope !== undefined){
        yaw = Math.trunc(imu.gyroscope.yaw);
        pitch = Math.trunc(imu.gyroscope.pitch); 
        roll = Math.trunc(imu.gyroscope.roll);
    }
    setTimeout(imuData, 10);//wait 10 milliseconds
}
imuData();//start endless loop

/////////////////////////////////////////
//Web Socket Server
var ws = require('nodejs-websocket');
console.log('Game Server Initiated At: ' + webSocketPort);
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
            //console.log('Received Ready Status');//for testing connection
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
var path = require('path');

//serve game folder
app.use(express.static(__dirname + '/game'));

//start web server
http.listen(webPagePort, function(){
    console.log('Web Server Initiated At: ' + webPagePort);//log server running
});