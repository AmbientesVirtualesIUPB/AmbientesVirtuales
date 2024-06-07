const WebSocket = require('ws');
const server = new WebSocket.Server({ port: 8080 });
console.log('Servidor ejecutado...');
server.on('connection', (socket) => {
  console.log('Cliente conectado');
  socket.on('message', (message) => {
    console.log(`Mensaje Recibido: ${message}`);
    // Broadcast the message to all clients
    server.clients.forEach((client) => {
      if (client !== socket && client.readyState === WebSocket.OPEN) {
        client.send(`m:${message}`);
      }
    });
  });
  socket.on('close', () => {
    console.log('Cliente desconectado');
  });
});