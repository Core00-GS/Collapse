﻿using CollapseLauncher.Helper;
using Hi3Helper;
using Hi3Helper.Data;
using Hi3Helper.EncTool.Parser.AssetIndex;
using Hi3Helper.Http;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static Hi3Helper.Locale;
using static Hi3Helper.Logger;

namespace CollapseLauncher
{
    internal partial class GenshinRepair
    {
        private async Task<bool> Repair(List<PkgVersionProperties> repairAssetIndex, CancellationToken token)
        {
            // Set total activity string as "Waiting for repair process to start..."
            _status.ActivityStatus = Lang._GameRepairPage.Status11;
            _status.IsProgressAllIndetermined = true;
            _status.IsProgressPerFileIndetermined = true;

            // Update status
            UpdateStatus();

            // Reset stopwatch
            RestartStopwatch();

            // Initialize new proxy-aware HttpClient
            using HttpClient client = new HttpClientBuilder()
                .UseLauncherConfig()
                .SetUserAgent(_userAgent)
                .SetAllowedDecompression(DecompressionMethods.None)
                .Create();

            // Use HttpClient instance on fetching
            using Http _httpClient = new Http(true, 5, 1000, _userAgent, client);

            // Try running instance
            try
            {
                // Assign downloader event
                _httpClient.DownloadProgress += _httpClient_RepairAssetProgress;

                // Iterate repair asset
                foreach (PkgVersionProperties asset in
#if ENABLEHTTPREPAIR
                    EnforceHTTPSchemeToAssetIndex(repairAssetIndex)
#else
                    repairAssetIndex
#endif
                    )
                {
                    await RepairAssetTypeGeneric(asset, _httpClient, token);
                }

                return true;
            }
            finally
            {
                // Unassign downloader event
                _httpClient.DownloadProgress -= _httpClient_RepairAssetProgress;
            }
        }

        #region GenericRepair
        private async Task RepairAssetTypeGeneric(PkgVersionProperties asset, Http _httpClient, CancellationToken token)
        {
            // Increment total count current
            _progressAllCountCurrent++;
            // Set repair activity status
            UpdateRepairStatus(
                string.Format(Lang._GameRepairPage.Status8, asset.remoteName),
                string.Format(Lang._GameRepairPage.PerProgressSubtitle2, _progressAllCountCurrent, _progressAllCountTotal),
                true);

            // If file is unused, then delete
            if (asset.type == "Unused")
            {
                string assetPath = Path.Combine(_gamePath, ConverterTool.NormalizePath(asset.localName));

                // Delete the file
                TryDeleteReadOnlyFile(assetPath);
            }
            else
            {
                string assetPath = Path.Combine(_gamePath, ConverterTool.NormalizePath(asset.remoteName));

                // or start asset download task
                await RunDownloadTask(asset.fileSize, assetPath, asset.remoteURL, _httpClient, token);
                LogWriteLine($"File [T: {RepairAssetType.General}] {asset.remoteName} has been downloaded!", LogType.Default, true);
            }

            // Pop repair asset display entry
            PopRepairAssetEntry();
        }
        #endregion
    }
}
