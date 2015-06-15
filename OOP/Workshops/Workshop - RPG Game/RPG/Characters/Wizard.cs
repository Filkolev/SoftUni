namespace RPG.Characters
{
    using Attributes;

    [Enemy]
    public class Wizard : Character
    {
        public const int DefaultWizardHitPoints = 350;
        public const int DefaultWizardDamage = 50;
        public const int DefaultWizardArmor = 25;

        public Wizard(Position position)
            : base(position, DefaultWizardDamage, DefaultWizardHitPoints, DefaultWizardArmor)
        {
        }
    }
}
