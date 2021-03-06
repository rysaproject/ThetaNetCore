﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThetaNetCore.Wifi;

namespace ThetaNetCoreApp.Controls.Camera
{
	/// <summary>
	/// Camera's base information <br />
	/// Keep data needed for other components. <br />
	/// I prepared this because of overhead for talking Theta all the time.
	/// </summary>
	class CommonCameraInfo
	{
		private static CommonCameraInfo _instance = new CommonCameraInfo();
		public static CommonCameraInfo Instance { get { return _instance; } }

		/// <summary>
		/// Preview needs to be restarted
		/// </summary>
		public event Action RestartPreviewRequested = null;
		/// <summary>
		/// Fire request for preview restart
		/// </summary>
		public void FireRestartPreview()
		{
			RestartPreviewRequested?.Invoke();
		}

		/// <summary>
		/// Basic information of Theta camera.<br />
		/// Model version is especially important because some APIs are available for particular models
		/// </summary>
		public InfoResponse Info { set; get; }
	}
}
