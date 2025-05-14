// <copyright file="JisLevel2Converter.cs" company="ted-sharp">
// Copyright (c) ted-sharp. All rights reserved.
// </copyright>

using System.Text;

// ReSharper disable ArrangeStaticMemberQualifier
namespace Aloe.Utils.Wafu.JisCompat;

/// <summary>
/// JIS Level 2 に縮退します。
/// </summary>
public static class JisLevel2Converter
{
    /// <summary>
    /// 第3水準、第4水準漢字を第2水準漢字に縮退します。
    /// </summary>
    /// <param name="input">変換対象の文字列</param>
    /// <returns>変換後の文字列</returns>
    public static string ConvertToLevel2(string input)
    {
        var result = new char[input.Length];
        for (var i = 0; i < input.Length; i++)
        {
            result[i] = JisLevel2Mapping.GetLevel2Equivalent(input[i]);
        }

        return new string(result);
    }
}
