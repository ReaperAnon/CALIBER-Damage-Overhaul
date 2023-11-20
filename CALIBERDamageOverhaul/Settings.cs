using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace CALIBERDamageOverhaul
{
    public class AmmoEntry
    {
        [SettingName("Ammo")]
        [Tooltip("The form ID of the ammo to be changed.")]
        public IFormLinkGetter<IAmmunitionGetter> AmmoLink { get; set; } = FormLink<IAmmunitionGetter>.Null;

        [SettingName("Damage Value")]
        [Tooltip("The damage value the selected ammo should have. Overridden if the settings below are active.")]
        public float AmmoDamage { get; set; } = 0f;

        [SettingName("Target Race")]
        [Tooltip("The target race to be used for the ammo damage calculation. The regular damage value is used if no race is given. The average of the lowest and highest health values and of all actor health values will be used for the calculation.")]
        public IFormLinkGetter<IRaceGetter> TargetToKill { get; set; } = FormLink<IRaceGetter>.Null;

        [SettingName("Shots to Kill")]
        [Tooltip("The number of shots it should take to kill the average member of the selected target race, without accounting for armor. The regular damage value is used if the value is 0 or less.\nWorth noting here that the average enemy might not actually exist, so don't expect the exact results written here.")]
        public uint ShotsToKill { get; set; } = 0;
    }

    public class WeaponMods
    {
        [SettingName("Range Multiplier")]
        [Tooltip("Range multipier for the weapon type.")]
        public float RangeMult { get; set; } = 1f;

        [SettingName("Damage Multiplier")]
        [Tooltip("Damage multiplier (including ammo damage) for the weapon type.")]
        public float DamageMult { get; set; } = 1f;

        [SettingName("Accuracy Multiplier")]
        [Tooltip("Accuracy multiplier for the weapon type.")]
        public float AccuracyMult { get; set; } = 1f;

        [SettingName("Armor Penetration Multiplier")]
        [Tooltip("Every .1 above 1 is 10% armor penetration.")]
        public float ArmorPen { get; set; } = 1f;
    }

    public class ModSettings
    {
        public WeaponMods BallisticPistols { get; set; } = new();
        public WeaponMods BallisticRifles { get; set; } = new();
        public WeaponMods BallisticShotguns { get; set; } = new();
        public WeaponMods BallisticSnipers { get; set; } = new();
        public WeaponMods BallisticHeavyWeapons { get; set; } = new();
        public WeaponMods EnergyWeapons { get; set; } = new();
        public List<AmmoEntry> AmmoEntries { get; set; } = new();
    }
}