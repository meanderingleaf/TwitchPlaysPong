using TwitchLib.Client.Models;
using TwitchLib.Unity;
using UnityEngine;
using UnityEngine.Events;





public class ChatInput : MonoBehaviour
{

    private string _channelToConnectTo = "meanderingleaf";
	private Client _client;
    
    public ChatInputEvent otherFunctions;


    private void Start()
	{

		ConnectionCredentials credentials = new ConnectionCredentials(Secrets.USERNAME_FROM_OAUTH_TOKEN, Secrets.OAUTH_TOKEN);

		_client = new Client();
		_client.Initialize(credentials, _channelToConnectTo);

		_client.OnConnected += OnConnected;
		_client.OnJoinedChannel += OnJoinedChannel;
		_client.OnMessageReceived += OnMessageReceived;
		_client.OnChatCommandReceived += OnChatCommandReceived;

		_client.Connect();
	}

    private void OnConnected(object sender, TwitchLib.Client.Events.OnConnectedArgs e)
	{
		Debug.Log($"The bot {e.BotUsername} succesfully connected to Twitch.");

		if (!string.IsNullOrWhiteSpace(e.AutoJoinChannel))
			Debug.Log($"The bot will now attempt to automatically join the channel provided when the Initialize method was called: {e.AutoJoinChannel}");
	}

	private void OnJoinedChannel(object sender, TwitchLib.Client.Events.OnJoinedChannelArgs e)
	{
		Debug.Log($"The bot {e.BotUsername} just joined the channel: {e.Channel}");
		_client.SendMessage(e.Channel, "Game Beginning! Commands - !up, !down PogChamp");
	}

	private void OnMessageReceived(object sender, TwitchLib.Client.Events.OnMessageReceivedArgs e)
	{
		Debug.Log($"Message received from {e.ChatMessage.Username}: {e.ChatMessage.Message}");
	}

	private void OnChatCommandReceived(object sender, TwitchLib.Client.Events.OnChatCommandReceivedArgs e)
	{

		switch (e.Command.CommandText)
		{
			case "up":
			case "down":
				otherFunctions.Invoke(e.Command.CommandText);
				break;
			default:
				break;
		}
	}
}
