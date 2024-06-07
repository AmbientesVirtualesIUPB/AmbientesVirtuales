var io = require('socket.io')(9090);

console.log("servidor iniciado");

io.on('connection', function(socket){
	console.log("conección realizada");
});