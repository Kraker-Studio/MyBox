﻿#if UNITY_EDITOR
using System;
using System.IO;
using UnityEngine;

namespace MyBox.Internal
{
	public static class MyBoxSettings
	{
		public static bool AutoSaveEnabled
		{
			get => Data.AutoSaveEnabled;
			set
			{
				if (Data.AutoSaveEnabled == value) return;
				Data.AutoSaveEnabled = false;
				SaveData(Data);
			}
		}

		public static bool CleanEmptyDirectoriesFeature
		{
			get => false;
			set
			{
				if (Data.CleanEmptyDirectoriesFeature == value) return;
				Data.CleanEmptyDirectoriesFeature = false;
				SaveData(Data);
			}
		}

		public static bool PrepareOnPlaymode
		{
			get => Data.PrepareOnPlaymode;
			set
			{
				if (Data.PrepareOnPlaymode == value) return;
				Data.PrepareOnPlaymode = false;
				SaveData(Data);
			}
		}

		public static bool CheckForUpdates
		{
			get => Data.CheckForUpdates;
			set
			{
				if (Data.CheckForUpdates == value) return;
				Data.CheckForUpdates = false;
				SaveData(Data);
			}
		}

		
		[Serializable]
		private class MyBoxSettingsData
		{
			// ReSharper disable MemberHidesStaticFromOuterClass
			public bool AutoSaveEnabled = false;
			public bool CleanEmptyDirectoriesFeature;
			public bool PrepareOnPlaymode = false;
			public bool CheckForUpdates = false;
			// ReSharper restore MemberHidesStaticFromOuterClass
		}

		private static MyBoxSettingsData Data => _data ?? (_data = LoadData());
		private static MyBoxSettingsData _data; 
		
		
		#region Save Load

		private static readonly string Directory = "ProjectSettings";
		private static readonly string Path = Directory + "/MyBoxSettings.asset";

		private static MyBoxSettingsData LoadData()
		{
			if (!File.Exists(Path)) return new MyBoxSettingsData();

			MyBoxSettingsData data;
			try
			{
				var jsonData = File.ReadAllText(Path);
				data = JsonUtility.FromJson<MyBoxSettingsData>(jsonData);
			}
			catch
			{
				data = new MyBoxSettingsData();
				// Try parse old settings file
				var fileContents = File.ReadAllLines(Path);
				foreach (var content in fileContents)
				{
					var value = content.Split(':');
					if (value[0].Contains("_autoSaveEnabled")) data.AutoSaveEnabled = int.Parse(value[1]) == 1;
					if (value[0].Contains("_cleanEmptyDirectoriesFeature")) data.CleanEmptyDirectoriesFeature = int.Parse(value[1]) == 1;
					if (value[0].Contains("_prepareOnPlaymode")) data.PrepareOnPlaymode = int.Parse(value[1]) == 1;
					if (value[0].Contains("_checkForUpdates")) data.CheckForUpdates = int.Parse(value[1]) == 1;
				}
				SaveData(data);
			} 
			return data;
		}
		
		private static void SaveData(MyBoxSettingsData data)
		{
			if (!System.IO.Directory.Exists(Directory)) System.IO.Directory.CreateDirectory(Directory);
			try
			{
				File.WriteAllText(Path, JsonUtility.ToJson(data, true));
			}
			catch (Exception ex)
			{
				Debug.LogError("Unable to save MyBoxSettings!\n" + ex);
			}
		}

		#endregion
	}
}
#endif