abstract class Character
{
    protected string characterType;
    
    protected Character(string characterType)
    {
        this.characterType = characterType;    
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString()
    {
        return $"Character is a {characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    private bool spell = false;
    
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        return spell ? 12 : 3;
    }

    public override bool Vulnerable()
    {
        return spell ? false : true;
    }

    public void PrepareSpell()
    {
        spell = true;
    }
}
