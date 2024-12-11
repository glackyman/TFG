using Godot;
using System;

public partial class Wizzard : Player
{
	
 private double burnDamage;
 [Export]
 public double BurnDamage
 {
	 set { burnDamage = value; }
	 get { return burnDamage; }
 }

 public Wizzard(string name, double burnDamage) : base(name, 100, 10, 0, 100)
 {
	 this.BurnDamage = burnDamage;
 }

public Wizzard(){
	
}

 public override string Attack()
 {
	 
	 return base.Attack() + "el enemigo arde por la fuerza arcana";
 }

}
