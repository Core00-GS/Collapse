using Hi3Helper.Data;
using Hi3Helper.Screen;
using Hi3Helper.Shared.ClassStruct;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Numerics;
using System.Text;
using static Hi3Helper.Locale;

namespace Hi3Helper.Shared.Region
{
    #region CDN Property
    public struct CDNURLProperty : IEquatable<CDNURLProperty>
    {
        public string URLPrefix { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public bool PartialDownloadSupport { get; init; }
        public bool Equals(CDNURLProperty other) => URLPrefix == other.URLPrefix && Name == other.Name && Description == other.Description;
    }
    #endregion

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "RedundantDefaultMemberInitializer")]
    public static class LauncherConfig
    {
        #region Main Launcher Config Methods
        public static void InitAppPreset()
        {
            // Initialize resolution settings first and assign AppConfigFile to ProfilePath
            InitScreenResSettings();
            appIni.ProfilePath = AppConfigFile;

            // Set user permission check to its default and check for the existence of config file.
            bool IsConfigFileExist = File.Exists(appIni.ProfilePath);

            // If the config file is exist, then continue to load the file
            appIni.Profile = new IniFile();
            if (IsConfigFileExist)
            {
                appIni.Profile.Load(appIni.ProfilePath);
            }

            // If the section doesn't exist, then add the section template
            if (!appIni.Profile.ContainsSection(SectionName))
            {
                appIni.Profile.Add(SectionName, AppSettingsTemplate);
            }

            // Check and assign default for the null and non-existence values.
            CheckAndSetDefaultConfigValue();

            // Set the startup background path and GameFolder to check if user has permission.
            startupBackgroundPath = GetAppConfigValue("CurrentBackground").ToString();
            string GameFolder = GetAppConfigValue("GameFolder").ToString();

            // Check if the drive is exist. If not, then reset the GameFolder variable and set IsFirstInstall to true;
            if (!IsDriveExist(GameFolder))
            {
                IsFirstInstall = true;

                // Reset GameFolder to default value
                SetAppConfigValue("GameFolder", AppSettingsTemplate!["GameFolder"]);

                // Force enable Console Log and return
                Logger._log = new LoggerConsole(AppGameLogsFolder, Encoding.UTF8);
                Logger.LogWriteLine($"Game App Folder path: {GameFolder} doesn't exist! The launcher will be reinitialize the setup.", LogType.Error, true);
                return;
            }

            // Check if user has permission
            bool IsUserHasPermission = ConverterTool.IsUserHasPermission(GameFolder);

            // Assign boolean if IsConfigFileExist and IsUserHasPermission.
            IsFirstInstall = !(IsConfigFileExist && IsUserHasPermission);

            // Initialize the DownloadClient speed at start.
            // ignored
            _ = DownloadSpeedLimit;
        }

        public static bool IsConfigKeyExist(string key) => appIni.Profile![SectionName!]!.ContainsKey(key!);
        public static IniValue GetAppConfigValue(string key) => appIni.Profile![SectionName]![key!];
        public static void SetAndSaveConfigValue(string key, IniValue value, bool doNotLog = false)
        {
            SetAppConfigValue(key, value);
            SaveAppConfig();
            #if DEBUG
            if (!doNotLog)
                Logger.LogWriteLine($"SetAndSaveConfigValue::Key[{key}]::Value[{value}]", LogType.Debug);
            #endif
        }
        public static void SetAppConfigValue(string key, IniValue value) => appIni.Profile![SectionName]![key!] = value;

        public static void LoadAppConfig() => appIni.Profile!.Load(appIni.ProfilePath);
        public static void SaveAppConfig() => appIni.Profile!.Save(appIni.ProfilePath);

        public static void CheckAndSetDefaultConfigValue()
        {
            foreach (KeyValuePair<string, IniValue> Entry in AppSettingsTemplate!)
            {
                if (!appIni.Profile![SectionName]!.ContainsKey(Entry.Key!) || string.IsNullOrEmpty(appIni.Profile[SectionName][Entry.Key].Value))
                {
                    SetAppConfigValue(Entry.Key, Entry.Value);
                }
            }
        }
        #endregion

        #region Misc Methods
        public static void LoadGamePreset() => AppGameFolder = Path.Combine(GetAppConfigValue("GameFolder").ToString()!);

        public static void GetScreenResolutionString()
        {
            foreach (var res in ScreenProp.screenResolutions!)
                ScreenResolutionsList!.Add($"{res.Width}x{res.Height}");
        }

        private static bool IsDriveExist(string path)
        {
            return new DriveInfo(Path.GetPathRoot(path)!).IsReady;
        }

        private static void InitScreenResSettings()
        {
            ScreenProp.InitScreenResolution();
            GetScreenResolutionString();
        }
        #endregion

        #region CDN List
        public static List<CDNURLProperty> CDNList => new()
          {
              new CDNURLProperty
              {
                  Name = "GitHub",
                  URLPrefix = "https://github.com/neon-nyan/CollapseLauncher-ReleaseRepo/raw/main",
                  Description = Lang!._Misc!.CDNDescription_Github,
                  PartialDownloadSupport = true
              },
              new CDNURLProperty
              {
                  Name = "Cloudflare",
                  URLPrefix = "https://r2.bagelnl.my.id/cl-cdn",
                  Description = Lang!._Misc!.CDNDescription_Cloudflare,
                  PartialDownloadSupport = true
              },
              new CDNURLProperty
              {
                  Name = "GitLab",
                  URLPrefix = "https://gitlab.com/bagusnl/CollapseLauncher-ReleaseRepo/-/raw/main/",
                  Description = Lang!._Misc!.CDNDescription_GitLab
              },
              new CDNURLProperty
              {
                  Name = "Coding",
                  URLPrefix = "https://ohly-generic.pkg.coding.net/collapse/release/",
                  Description = Lang!._Misc!.CDNDescription_Coding
              },
          };

        public static CDNURLProperty GetCurrentCDN() => CDNList![GetAppConfigValue("CurrentCDN").ToInt()];
        #endregion

        #region Misc Fields
        public static Vector3 Shadow16 = new(0, 0, 16);
        public static Vector3 Shadow32 = new(0, 0, 32);
        public static Vector3 Shadow48 = new(0, 0, 48);
        // Format in milliseconds
        public static int RefreshTime = 250;

        const         string       SectionName = "app";
        public static string       startupBackgroundPath;
        public static List<string> ScreenResolutionsList = new();

        public const long AppDiscordApplicationID     = 1138126643592970251;
        public const long AppDiscordApplicationID_HI3 = 1124126288370737314;
        public const long AppDiscordApplicationID_GI  = 1124137436650426509;
        public const long AppDiscordApplicationID_HSR = 1124153902959431780;
        public const long AppDiscordApplicationID_ZZZ = 1124154024879456276;
      
        public const string AppNotifURLPrefix           = "/notification_{0}.json";
        public const string AppGameConfigV2URLPrefix    = "/metadata/metadatav2_{0}.json";
        public const string AppGameRepairIndexURLPrefix = "/metadata/repair_indexes/{0}/{1}/index";
        public const string AppGameRepoIndexURLPrefix   = "/metadata/repair_indexes/{0}/repo";

        public static IntPtr AppIconLarge;
        public static IntPtr AppIconSmall;
        #endregion

        #region App Config Definitions
        public static AppIniStruct appIni;
        
        public static readonly string AppFolder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule!.FileName);
        public static readonly string AppDefaultBG = Path.Combine(AppFolder!, "Assets", "Images", "PageBackground", "default.png");
        
        public static readonly string AppLangFolder = Path.Combine(AppFolder, "Lang");
        public static readonly string AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "LocalLow", "CollapseLauncher");
        
        public static string AppImagesFolder = Path.Combine(AppFolder, "Assets", "Images");
        public static string AppGameFolder
        {
            get => GetAppConfigValue("GameFolder").ToString();
            set => SetAppConfigValue("GameFolder", value);
        }
        public static string[] AppCurrentArgument;
        private static string _appExecutablePath;
        public static string AppExecutablePath
        {
            get
            {
                if (string.IsNullOrEmpty(_appExecutablePath))
                {
                    using Process currentProcess = Process.GetCurrentProcess();
                    string execName = Path.GetFileNameWithoutExtension(currentProcess.MainModule?.FileName);
                    string dirPath = AppFolder;
                    return _appExecutablePath = Path.Combine(dirPath!, execName + ".exe");
                }
                return _appExecutablePath;
            }
        }
        public static string AppExecutableName       { get => Path.GetFileName(AppExecutablePath); }
        public static string AppGameImgFolder        { get => Path.Combine(AppGameFolder!,    "_img"); }
        public static string AppGameImgCachedFolder  { get => Path.Combine(AppGameImgFolder!, "cached"); }
        public static string AppGameLogsFolder       { get => Path.Combine(AppGameFolder!,    "_logs"); }

        private static string _appCurrentVersionString;
        public static string AppCurrentVersionString
        {
            get
            {
                if (string.IsNullOrEmpty(_appCurrentVersionString))
                {
                    string executablePath = AppExecutablePath;
                    if (string.IsNullOrEmpty(executablePath))
                        return "Unknown";

                    try
                    {
                        FileVersionInfo verInfo = FileVersionInfo.GetVersionInfo(executablePath);
                        string version = $"{verInfo.FileMajorPart}.{verInfo.FileMinorPart}.{verInfo.FileBuildPart}";
                        return _appCurrentVersionString = version;
                    }
                    catch
                    {
                        return "Unknown";
                    }
                }
                return _appCurrentVersionString;
            }
        }

        public static readonly string AppConfigFile      = Path.Combine(AppDataFolder!, "config.ini");
        public static readonly string AppNotifIgnoreFile = Path.Combine(AppDataFolder,  "ignore_notif_ids.json");
        
        public static string GamePathOnSteam;
        public static long   AppGameConfigLastUpdate;
        public static int AppCurrentThread
        {
            get
            {
                int val = GetAppConfigValue("ExtractionThread").ToInt();
                return val <= 0 ? Environment.ProcessorCount : val;
            }
        }
        public static int AppCurrentDownloadThread => GetAppConfigValue("DownloadThread").ToInt();
        public static string AppGameConfigMetadataFolder { get => Path.Combine(AppGameFolder!, "_metadatav3"); }

        public static readonly bool IsAppLangNeedRestart    = false;

        public static bool IsPreview                        = false;
        public static bool IsAppThemeNeedRestart            = false;
        public static bool IsChangeRegionWarningNeedRestart = false;
        public static bool IsInstantRegionNeedRestart       = false;
        public static bool IsFirstInstall                   = false;
        public static bool IsConsoleEnabled
        {
            get => GetAppConfigValue("EnableConsole").ToBoolNullable() ?? false;
            set => SetAppConfigValue("EnableConsole", value);
        }

        public static bool IsMultipleInstanceEnabled
        {
            get => GetAppConfigValue("EnableMultipleInstance").ToBoolNullable() ?? false;
            set => SetAndSaveConfigValue("EnableMultipleInstance", value);
        }

        public static bool IsShowRegionChangeWarning
        {
            get => GetAppConfigValue("ShowRegionChangeWarning").ToBool();
            set => SetAndSaveConfigValue("ShowRegionChangeWarning", value);
        }

        public static bool EnableAcrylicEffect
        {
            get => GetAppConfigValue("EnableAcrylicEffect").ToBoolNullable() ?? false;
            set => SetAndSaveConfigValue("EnableAcrylicEffect", value);
        }

        public static bool IsUseVideoBGDynamicColorUpdate
        {
            get => GetAppConfigValue("IsUseVideoBGDynamicColorUpdate").ToBoolNullable() ?? false;
            set => SetAndSaveConfigValue("IsUseVideoBGDynamicColorUpdate", value);
        }

        public static bool IsIntroEnabled
        {
            get => GetAppConfigValue("IsIntroEnabled").ToBoolNullable() ?? true;
            set => SetAndSaveConfigValue("IsIntroEnabled", value);
        }

        public static bool IsBurstDownloadModeEnabled
        {
            get => GetAppConfigValue("IsBurstDownloadModeEnabled").ToBoolNullable() ?? true;
            set => SetAndSaveConfigValue("IsBurstDownloadModeEnabled", value);
        }

        public static bool IsUsePreallocatedDownloader
        {
            get => GetAppConfigValue("IsUsePreallocatedDownloader").ToBoolNullable() ?? true;
            set => SetAndSaveConfigValue("IsUsePreallocatedDownloader", value);
        }

        public static bool IsUseDownloadSpeedLimiter
        {
            get => GetAppConfigValue("IsUseDownloadSpeedLimiter").ToBoolNullable() ?? true;
            set
            {
                SetAndSaveConfigValue("IsUseDownloadSpeedLimiter", value);

                _ = DownloadSpeedLimit;
            }
        }

        public static long DownloadSpeedLimit
        {
            get => DownloadSpeedLimitCached = GetAppConfigValue("DownloadSpeedLimit").ToLong();
            set => SetAndSaveConfigValue("DownloadSpeedLimit", DownloadSpeedLimitCached = value);
        }

        public static int DownloadChunkSize
        {
            get => GetAppConfigValue("DownloadChunkSize").ToInt();
            set => SetAndSaveConfigValue("DownloadChunkSize", value);
        }

        private static long _downloadSpeedLimitCached = 0; // Default: 0 == Unlimited
        public static long DownloadSpeedLimitCached
        {
            get => _downloadSpeedLimitCached;
            set
            {
                _downloadSpeedLimitCached = IsUseDownloadSpeedLimiter ? value : 0;
                DownloadSpeedLimitChanged?.Invoke(null, _downloadSpeedLimitCached);
            }
        }

#nullable enable
        public static event EventHandler<long>? DownloadSpeedLimitChanged;
#nullable restore

        private static bool? _cachedIsInstantRegionChange = null;
        public static bool IsInstantRegionChange
        {
            get
            {
                _cachedIsInstantRegionChange ??= GetAppConfigValue("UseInstantRegionChange").ToBool();
                return (bool)_cachedIsInstantRegionChange;
            }
            set => SetAndSaveConfigValue("UseInstantRegionChange", value);
        }

        public static bool                 ForceInvokeUpdate     = false;
        public static GameInstallStateEnum GameInstallationState = GameInstallStateEnum.NotInstalled;

        public static Guid GetGuid(int sessionNum)
        {
            var guidString = GetAppConfigValue($"sessionGuid{sessionNum}").ToString();
            if (string.IsNullOrEmpty(guidString))
            {
                var g = Guid.NewGuid();
                SetAndSaveConfigValue($"sessionGuid{sessionNum}", g.ToString());
                return g;
            }
            return Guid.Parse(guidString);
        }
        #endregion

        #region App Settings Template
        public static Dictionary<string, IniValue> AppSettingsTemplate = new Dictionary<string, IniValue>
        {
            { "CurrentBackground", "ms-appx:///Assets/Images/default.png" },
            { "DownloadThread", 4 },
            { "ExtractionThread", 0 },
            { "GameFolder", Path.Combine(AppDataFolder, "GameFolder") },
            { "UserAgent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Safari/537.36 Edg/118.0.0.0" },
            #if DEBUG
            { "EnableConsole", true },
            #else
            { "EnableConsole", false },
            #endif
            { "EnableMultipleInstance", false },
            { "DontAskUpdate", false },
            { "ThemeMode", new IniValue(AppThemeMode.Default) },
            { "AppLanguage", "en-us" },
            { "UseCustomBG", false },
            { "IsUseVideoBGDynamicColorUpdate", false },
            { "ShowEventsPanel", true },
            { "ShowSocialMediaPanel", true },
            { "ShowGamePlaytime", true},
            { "CustomBGPath", "" },
            { "GameCategory", "Honkai Impact 3rd" },
            { "WindowSizeProfile", "Normal" },
            { "CurrentCDN", 0 },
            { "ShowRegionChangeWarning", false },
            #if !DISABLEDISCORD
            { "EnableDiscordRPC", false },
            { "EnableDiscordGameStatus", true },
            { "EnableDiscordIdleStatus", true},
            #endif
            { "EnableAcrylicEffect", true },
            { "IncludeGameLogs", false },
            { "UseDownloadChunksMerging", false },
            { "LowerCollapsePrioOnGameLaunch", false },
            { "EnableHTTPRepairOverride", false },
            { "ForceGIHDREnable", false },
            { "HI3IgnoreMediaPack", false },
            { "GameLaunchedBehavior", "Minimize" }, // Possible Values: "Minimize", "ToTray", and "Nothing"
            { "MinimizeToTray", false },
            { "UseExternalBrowser", false },
            { "EnableWaifu2X", false },
            { "BackgroundAudioVolume", 0.5d },
            { "BackgroundAudioIsMute", true },
            { "UseInstantRegionChange", true },
            { "IsIntroEnabled", true },
            { "IsEnableSophon", true},
            { "SophonCpuThread", 0},
            { "SophonHttpConnInt", 0},

            { "IsUseProxy", false },
            { "IsAllowHttpRedirections", true },
            { "IsAllowHttpCookies", false },
            { "IsAllowUntrustedCert", false },
            { "IsUseDownloadSpeedLimiter", false },
            { "IsUsePreallocatedDownloader", true },
            { "IsBurstDownloadModeEnabled", true },
            { "DownloadSpeedLimit", 0 },
            { "DownloadChunkSize", 4 << 20 },
            { "HttpProxyUrl", string.Empty },
            { "HttpProxyUsername", string.Empty },
            { "HttpProxyPassword", string.Empty },
            { "HttpClientTimeout", 90 }
        };
        #endregion
    }
}
