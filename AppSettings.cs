﻿using System;

namespace rates
{
	public class AppSettings
	{
		public string DatabaseConnectionString { get; private set; }
		public string RatesRequestUri { get; private set; }
		public string ReportingRequestUri { get; private set; }
	}
}