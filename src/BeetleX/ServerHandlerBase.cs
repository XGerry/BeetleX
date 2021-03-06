﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeetleX.EventArgs;

namespace BeetleX
{
	public class ServerHandlerBase : IServerHandler
	{
		public virtual void Connected(IServer server, ConnectedEventArgs e)
		{
			server.Log(LogType.Info, null, "session connected from {0}@{1}", e.Session.RemoteEndPoint, e.Session.ID);
		}

		public virtual void Connecting(IServer server, ConnectingEventArgs e)
		{
			server.Log(LogType.Info, null, "connect from {0}", e.Socket.RemoteEndPoint);
		}

		public virtual void Disconnect(IServer server, SessionEventArgs e)
		{
			server.Log(LogType.Info, null, "session {0}@{1} disconnected", e.Session.RemoteEndPoint, e.Session.ID);
		}

		public virtual void Error(IServer server, ServerErrorEventArgs e)
		{
			if (e.Session == null)
			{
				server.Log(LogType.Error, null, "server error {0}@{1}\r\n{2}", e.Message, e.Error.Message, e.Error.StackTrace);
			}
			else
			{
				server.Log(LogType.Error, null, "session {2}@{3} error {0}@{1}\r\n{4}", e.Message, e.Error.Message, e.Session.RemoteEndPoint, e.Session.ID, e.Error.StackTrace);
			}
		}

		public virtual void Log(IServer server, ServerLogEventArgs e)
		{
			Console.WriteLine("[{0}:{2}] {1}", e.Type, e.Message, DateTime.Now);
		}

		public virtual void SessionDetection(IServer server, SessionDetectionEventArgs e)
		{
			;
		}

		public virtual void SessionPacketDecodeCompleted(IServer server, PacketDecodeCompletedEventArgs e)
		{

		}

		public virtual void SessionReceive(IServer server, SessionReceiveEventArgs e)
		{

		}
	}
}
