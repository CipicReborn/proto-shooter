namespace Game.Behaviour.Weapons
{
    public interface IWeaponData {

        eWeaponMode Mode { get; }

        float BurstCooldownDuration { get; }
        int BurstSize { get; }

        float CooldownDuration { get; }
        float BulletSpeed { get; }
    }
}
