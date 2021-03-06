﻿using System;
using System.Configuration;

namespace RegTesting.Node
{
	/// <summary>
	/// Configuration of node
	/// </summary>
	public class NodeConfiguration
	{
		/// <summary>
		/// the pollingIntervall of the node
		/// </summary>
		public static int PollingIntervall
		{
			get
			{
				string pollingIntervall = ConfigurationManager.AppSettings["PollingIntervall"];
				return String.IsNullOrWhiteSpace(pollingIntervall) ? 5000 : int.Parse(pollingIntervall);
			}
		}

		/// <summary>
		/// the address to the hosted node service
		/// </summary>
		public static string ServerAddress
		{
			get
			{
				return ConfigurationManager.AppSettings["ServerAddress"];
			}
		}
	}
}
