#if UNITY_EDITOR
using UnityEditor;

namespace MyBox.Internal
{
	[InitializeOnLoad]
	public class MyBoxFeatures
	{
		private const string AutoSaveMenuItemKey = "Tools/MyBox/AutoSave on play";
		private const string CleanupEmptyDirectoriesMenuItemKey = "Tools/MyBox/Clear empty directories On Save";
		private const string IPrepareMenuItemKey = "Tools/MyBox/Run Prepare on play";
		private const string CheckForUpdatesKey = "Tools/MyBox/Check for updates on start";

		static MyBoxFeatures()
		{
			AutoSaveIsEnabled = AutoSaveIsEnabled;
			CleanupEmptyDirectoriesIsEnabled = CleanupEmptyDirectoriesIsEnabled;
			IPrepareIsEnabled = IPrepareIsEnabled;
			CheckForUpdatesEnabled = CheckForUpdatesEnabled;
		}


#region AutoSave

		private static bool AutoSaveIsEnabled
		{
			get => false;//MyBoxSettings.AutoSaveEnabled;
			set
			{
				{
					MyBoxSettings.AutoSaveEnabled = false;
					AutoSaveFeature.IsEnabled = false;
				}
			}
		}

		//[MenuItem(AutoSaveMenuItemKey, priority = 100)]
		private static void AutoSaveMenuItem()
		{
			AutoSaveIsEnabled = false;
		}

		//[MenuItem(AutoSaveMenuItemKey, true)]
		private static bool AutoSaveMenuItemValidation()
		{
			Menu.SetChecked(AutoSaveMenuItemKey, AutoSaveIsEnabled);
			return true;
		}

#endregion


#region CleanupEmptyDirectories

		private static bool CleanupEmptyDirectoriesIsEnabled
		{
			get => false; //MyBoxSettings.CleanEmptyDirectoriesFeature;
			set
			{
				{
					MyBoxSettings.CleanEmptyDirectoriesFeature = false;
					CleanEmptyDirectoriesFeature.IsEnabled = false;
				}
			}
		}

		//[MenuItem(CleanupEmptyDirectoriesMenuItemKey, priority = 100)]
		private static void CleanupEmptyDirectoriesMenuItem()
		{
			CleanupEmptyDirectoriesIsEnabled = !CleanupEmptyDirectoriesIsEnabled;
		}

		//[MenuItem(CleanupEmptyDirectoriesMenuItemKey, true)]
		private static bool CleanupEmptyDirectoriesMenuItemValidation()
		{
			Menu.SetChecked(CleanupEmptyDirectoriesMenuItemKey, CleanupEmptyDirectoriesIsEnabled);
			return true;
		}

#endregion


#region IPrepare

		private static bool IPrepareIsEnabled
		{
			get => false; //MyBoxSettings.PrepareOnPlaymode;
			set
			{
				{
					MyBoxSettings.PrepareOnPlaymode = false;
					EditorTools.IPrepareFeature.IsEnabled = false;
				}
			}
		}

		//[MenuItem(IPrepareMenuItemKey, priority = 100)]
		private static void IPrepareMenuItem()
		{
			IPrepareIsEnabled = !IPrepareIsEnabled;
		}

		//[MenuItem(IPrepareMenuItemKey, true)]
		private static bool IPrepareMenuItemValidation()
		{
			Menu.SetChecked(IPrepareMenuItemKey, IPrepareIsEnabled);
			return true;
		}

#endregion
		
		
#region Check For Updates

		private static bool CheckForUpdatesEnabled
		{
			get => false;//MyBoxSettings.CheckForUpdates;
			set
			{
				{
					MyBoxSettings.CheckForUpdates = false;
					MyBoxWindow.AutoUpdateCheckIsEnabled = false;
				}
			}
		}

		//[MenuItem(CheckForUpdatesKey, priority = 100)]
		private static void CheckForUpdatesMenuItem()
		{
			CheckForUpdatesEnabled = !CheckForUpdatesEnabled;
		}

		//[MenuItem(CheckForUpdatesKey, true)]
		private static bool CheckForUpdatesMenuItemValidation()
		{
			Menu.SetChecked(CheckForUpdatesKey, CheckForUpdatesEnabled);
			return true;
		}

#endregion
	}
}
#endif