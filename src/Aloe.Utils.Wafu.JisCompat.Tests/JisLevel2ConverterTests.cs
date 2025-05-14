namespace Aloe.Utils.Wafu.JisCompat.Tests;

using Xunit;

/// <summary>
/// JisLevel2Converterのテストクラス
/// </summary>
public class JisLevel2ConverterTests
{
    /// <summary>
    /// 静的コンストラクタ
    /// </summary>
    static JisLevel2ConverterTests()
    {
        // テスト実行前にマッピングテーブルを初期化
        _ = JisLevel2Mapping.IsLevel3Or4Kanji('髙');
    }

    [Theory]
    [InlineData("髙", "高")]
    [InlineData("﨑", "崎")]
    [InlineData("神", "神")]
    [InlineData("髙崎", "高崎")]
    [InlineData("髙崎神社", "高崎神社")]
    [InlineData("普通の文字", "普通の文字")]
    [InlineData("", "")]
    public void ConvertToLevel2_変換が正しく行われる(string input, string expected)
    {
        // Arrange
        // Act
        var actual = JisLevel2Converter.ConvertToLevel2(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConvertToLevel2_第3水準第4水準漢字が全て変換される()
    {
        // Arrange
        var input = "髙﨑神祥福靖精羽﨟蘒﨡諸逸都飯飼館鶴郞隷侮僧免勉勤卑喝嘆器塀墨層屮悔慨憎懲敏既暑梅海渚漢煮爫琢碑";
        var expected = "高崎神祥福靖精羽老耒耳諸逸都飯飼館鶴麗麓麗僧免勉勤卑喝嘆器塚墨層屮悔慨憎懲敏既暑梅海渚漢煮爫琢碑";

        // Act
        var actual = JisLevel2Converter.ConvertToLevel2(input);

        // Assert
        Assert.Equal(expected, actual);
    }
}
