using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace GymAppDiet.Api
{
    public class WebSocketHandler
    {
        private static readonly ConcurrentDictionary<string, WebSocket> _connectedClients =
           new ConcurrentDictionary<string, WebSocket>();

        public async Task HandleWebSocketAsync(HttpContext context, WebSocket webSocket)
        {
            var clientId = Guid.NewGuid().ToString();
            _connectedClients.TryAdd(clientId, webSocket);

            try
            {
                while (webSocket.State == WebSocketState.Open)
                {
                    var buffer = new byte[1024 * 4];
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);


                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        await BroadcastMessageAsync($"Echo from client {clientId}: {message}");
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                        _connectedClients.TryRemove(clientId, out _);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WebSocket communication error: {ex.Message}");
                await RemoveClientAsync(clientId, webSocket);
            }
        }

        private static async Task BroadcastMessageAsync(string message)
        {
            foreach (var clientWebSocket in _connectedClients.Values)
            {
                try
                {
                    var buffer = Encoding.UTF8.GetBytes(message);
                    await clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error broadcasting message: {ex.Message}");
                }
            }
        }
        private static async Task RemoveClientAsync(string clientId, WebSocket webSocket)
        {
            if (_connectedClients.TryRemove(clientId, out _))
            {
                try
                {
                    if (webSocket.State != WebSocketState.Closed)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                    }
                    webSocket.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error closing WebSocket for client {clientId}: {ex.Message}");
                }
            }

        }
    }
}
