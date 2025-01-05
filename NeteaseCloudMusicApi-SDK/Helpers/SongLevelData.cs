using Microsoft.Extensions.Logging;
using System.Collections.Generic;

public static class SongLevelData
{
    public static readonly Dictionary<SongLevel, (string Level, string Name)> Levels = new()
    {
        { SongLevel.l, ("standard", "标准音质") },
        { SongLevel.m, ("higher", "较高音质") },
        { SongLevel.h, ("exhigh", "极高音质") },
        { SongLevel.sq, ("lossless", "无损音质") },
        { SongLevel.hr, ("hires", "Hi-Res") },
        { SongLevel.je, ("jyeffect", "高清环绕声") },
        { SongLevel.sk, ("sky", "沉浸环绕声") },
        { SongLevel.db, ("dolby", "杜比全景声") },
        { SongLevel.jm, ("jymaster", "超清母带") }
    };
}

public enum SongLevel
{
    l,  // Standard
    m,  // Higher
    h,  // ExHigh
    sq, // Lossless
    hr, // HiRes
    je, // JyEffect
    sk, // Sky
    db, // Dolby
    jm  // JyMaster
}

public class Song
{
    private SongLevel _level;

    /// <summary>
    /// The audio quality level of the song.
    /// </summary>
    public SongLevel Level
    {
        get => _level;
        set
        {
            if (!SongLevelData.Levels.ContainsKey(value))
            {
                throw new ArgumentException("Invalid level provided.");
            }
            _level = value;
        }
    }

    /// <summary>
    /// Retrieves the associated level and name for the current song level.
    /// </summary>
    /// <returns>Tuple containing level and name.</returns>
    public (string Level, string Name) GetLevelInfo()
    {
        return SongLevelData.Levels[_level];
    }
}


