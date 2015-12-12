package empires.models.units;

import empires.contracts.Unit;

public class AbstractUnit implements Unit {
    private int health;
    private int attackDamage;
    
    public AbstractUnit(int health, int attackDamage) {
        this.initHealth(health);
        this.setAttackDamage(attackDamage);
    }
    
    private void initHealth(int health) {
        if (health <= 0) {
            throw new IllegalArgumentException("Initial health should be positive.");
        }
        
        this.health = health;
    }
    
    @Override
    public int getHealth() {
        return this.health;
    }
    
    @Override
    public void setHealth(int health) {
        if (health < 0) {
            this.health = 0;
        } else {
            this.health = health;
        }
    }

    @Override
    public int getAttackDamage() {
        return this.attackDamage;
    }
    
    private void setAttackDamage(int attackDamage) {
        if (attackDamage <= 0) {
            throw new IllegalArgumentException("Attack damage should be positive.");
        }
        
        this.attackDamage = attackDamage;
    }    
}