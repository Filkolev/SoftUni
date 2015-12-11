package org.softuni.empires.models.units;

import org.softuni.empires.contracts.Unit;

public class AbstractUnit implements Unit {
    private int health;
    private int attackDamage;
    
    public AbstractUnit(int health, int attackDamage) {
        this.setHealth(health);
        this.setAttackDamage(attackDamage);
    }
    
    @Override
    public int getHealth() {
        return this.health;
    }
    
    private void setHealth(int health) {
        if (health <= 0) {
            throw new IllegalArgumentException("Health should be positive.");
        }
        
        this.health = health;
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
