using System.Collections; // required for arrays and other collections
using System.Collections.Generic; // required to use Lists or dictionaries
using UnityEngine; // required for unity

//  <summary>
// this is an enum of the various possible weapon types
// it also includes a "shield" type to allow a shield power-up.
// Items marked [NI] below are notImplemented in the IGDPD book
// </summary>

public enum WeaponType {
    none,           // the default / no weapon
    blaster,        // a simple blaster
    spread,         // two shots simultaneously
    phaser,         // [NI] shots that move in waves
    missle,         // [NI] homing missles
    laser,          // [NI]Damage over time
    shield          // Raise shieldLevel
}

//<summary> 
// the WeaponDefinition class allows you to set the properties
// of a specific weapon in the Inspector.  The main class has
// an array of Weapon Definitions that makes this possible
// </summary> 

[System.Serializable]

public class WeaponDefinition {
    public WeaponType       type = WeaponType.none;
    public string           letter; // letter to show on the power up
    public Color            color = Color.white;  // Color of collar
    public GameObject       projectilePrefab; // prefab for projectiles 
    public Color            projectileColor = Color.white;
    public float            damageonHit = 0; // amount of damage caused
    public float            continuousDamage = 0; // damage per second (Laser)
    public float            delaybetweenShots = 0;
    public float            velocity = 20; // speed of projectiles

}


public class Weapon: MonoBehaviour      {
                // the weapon class will be filled in later in the chapter

	
}
