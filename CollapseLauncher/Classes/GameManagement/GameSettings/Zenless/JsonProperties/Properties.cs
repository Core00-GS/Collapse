using CollapseLauncher.GameSettings.Base;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Nodes;

#nullable enable
namespace CollapseLauncher.GameSettings.Zenless.JsonProperties;

public struct SystemSettingLocalData<TData>
    where TData : struct
{
    private const string TypeKey = "MoleMole.SystemSettingLocalData";

    private readonly int _defaultVersion;
    private readonly TData _defaultData;
    private readonly JsonNode _node;

    public int GetVersion() => _node.GetNodeValue("Version", _defaultVersion);
    public void SetVersion(int value) => _node.SetNodeValue("Version", value);

    public TData GetData() => _node.GetNodeValue("Data", _defaultData);
    public TData GetDataEnum<TDataEnum>() => _node.GetNodeValueEnum("Data", _defaultData);

    public void SetData(TData value) => _node.SetNodeValue("Data", value);
    public void SetDataEnum<TDataEnum>(TDataEnum value, JsonEnumStoreType enumStoreType = JsonEnumStoreType.AsNumber)
        where TDataEnum : struct, Enum => _node.SetNodeValueEnum("Data", value, enumStoreType);

    public SystemSettingLocalData([NotNull] JsonNode node, TData defaultData = default, int defaultVersion = 1)
    {
        ArgumentNullException.ThrowIfNull(node, nameof(node));
        _node = node;
        _defaultVersion = defaultVersion;
        _defaultData = defaultData;

        string? keyVal = node.GetNodeValue("$Type", "");
        if (!(keyVal?.Equals(TypeKey, StringComparison.OrdinalIgnoreCase) ?? false))
            node.SetNodeValue("$Type", TypeKey);
    }
}

public static class SystemSettingLocalDataExt
{
    public static SystemSettingLocalData<TData> AsSystemSettingLocalData<TData>(
        [NotNull] this JsonNode node, string keyName, TData defaultData = default, int defaultVersion = 1)
        where TData : struct
    {
        ArgumentNullException.ThrowIfNull(node, nameof(node));

        JsonNode ensuredNode = node.EnsureCreated<JsonObject>(keyName);
        SystemSettingLocalData<TData> map = new SystemSettingLocalData<TData>(ensuredNode, defaultData, defaultVersion);
        return map;
    }
}
