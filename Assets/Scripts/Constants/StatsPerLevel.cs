/// <summary>
/// Determines by what amount a stat should increase when leveling up.
/// </summary> 
public static class StatsPerLevel
{
    public const int hpPerLevel = 15;
    public const int spPerLevel = 8;
    public const int mpPerLevel = 8;

    public const int strengthPerLevel = 2;
    public const int intPerLevel = 2;

    public const int agilityPerLevel = 1;
    public const int luckPerLevel = 1;

    public const int physAttackPowerPerLevel = 2;
    public const int physDefensePerLevel = 1;

    public const int magicAttackPowerPerLevel = 2;
    public const int magicDefensePerLevel = 1;

    /// <summary>
    /// Increases the experience to next level stat.
    /// </summary>
    public const float experienceMultiplier = 1.5f;
}