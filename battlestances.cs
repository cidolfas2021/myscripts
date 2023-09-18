using UnityEngine;
public class battlestances : MonoBehaviour
{
    public Equipment equipable;
    public Player player;
    public Animator animator;
    // public string mainHandidleAni;
    // public string offHandidleAni;

    public bool twoMainHandswordAIMnoOH;
    public bool twoOffHandswordAIMnoOH;
    public bool twoMainHandspearAIMnoOH;
    public bool twoMainHandmaceAIMnoOH;
    public bool twoOffHandmaceAIMnoOH;
    public bool twoMainHandaxeAIMnoOH;
    public bool twoOffHandaxeAIMnoOH;
    public bool twoMainHandgunAIMnoOH;
    public bool twoOffHandgunAIMnoOH;
    public bool twoMainHandbowAIMnoOH;
    public bool unarmedAIM;

    private Entity entity;
    //public PlayerEquipment player;

    public void clearstances()
    {
        foreach (Animator anim in GetComponentsInChildren<Animator>())
        {
            anim.SetBool("twoMainHandswordAIMnoOH", false);
            anim.SetBool("twoOffHandswordAIMnoOH", false);
            anim.SetBool("oneMainHandswordAIMnoOH", false);
            anim.SetBool("oneOffHandswordAIMnoOH", false);
            anim.SetBool("twoMainHandspearAIMnoOH", false);
            anim.SetBool("twoOffHandspearAIMnoOH", false);
            anim.SetBool("twoMainHandmaceAIMnoOH", false);
            anim.SetBool("twoOffHandmaceAIMnoOH", false);
            anim.SetBool("twoMainHandaxeAIMnoOH", false);
            anim.SetBool("twoOffHandaxeAIMnoOH", false);
            anim.SetBool("twoMainHandgunAIMnoOH", false);
            anim.SetBool("twoOffHandgunAIMnoOH", false);
            anim.SetBool("twoMainHandbowAIMnoOH", false);
            anim.SetBool("AIMING", false);
        }
    }

    public void CloseAll()
    {
        foreach (Animator animator in GetComponentsInChildren<Animator>())
        {
            animator.SetBool("closeLeft", true);
            animator.SetBool("closeRight", true);
        }
    }

    public void OpenAll()
    {
        foreach (Animator animator in GetComponentsInChildren<Animator>())
        {
            animator.SetBool("OpenLeft", true);
            animator.SetBool("OpenRight", true);
        }
    }

    public void CloseLeft()
    {
        foreach (Animator animator in GetComponentsInChildren<Animator>())
        {
            animator.SetBool("closeLeft", true);
        }
    }

    public void CloseRight()
    {
        foreach (Animator animator in GetComponentsInChildren<Animator>())
        {
            animator.SetBool("closeRight", true);
        }
    }

    public void OpenLeft()
    {
        foreach (Animator animator in GetComponentsInChildren<Animator>())
        {
            animator.SetBool("OpenLeft", true);
        }
    }

    public void OpenRight()
    {
        foreach (Animator animator in GetComponentsInChildren<Animator>())
        {
            animator.SetBool("OpenRight", true);
        }
    }
    public void Start()
    {
        entity = GetComponent<Entity>();

        OpenAll();
    }
    public void Update()
    {
        if (Player.localPlayer == null) return;

        if (Player.localPlayer.target != null && Player.localPlayer.target.tag == "Monster")
        {
            monster_selected();
        }
        else if (Player.localPlayer.target != null)
        {
            if (Player.localPlayer.target.tag != "Monster")
            {
                monster_not_selected();
            }
        }
        else
        {
            nothing_selected();
        }
    }
    public void monster_selected()
    {
        if (player != null)
        {
            Debug.Log("player is not null");
            // only call this for server and for local player. not for other
            // players on the client. no need in locally creating their
            // instances too.
            if (player.isLocalPlayer)
            {
                // Debug.Log("monster selected");
                // Debug.Log("Equipped Weapon: " + player.equipment.GetEquippedWeaponType());
                // Debug.Log("Hands: " + player.equipment.GetHands());

                Animator anim = GetComponentInChildren<Animator>();
                anim.SetBool("AIMING", true);

                if (player.equipment.slots[24].amount == 0 && player.equipment.slots[25].amount != 0)
                {

                    if (player.equipment.GetHands() == ScriptableItem.HandsRequired.NONE)
                    {
                        //Debug.Log("No weapons equip");




                    }
                    else if (player.equipment.GetHands() == ScriptableItem.HandsRequired.ONE_HANDED)
                    {
                        // Debug.Log("1h equp");

                        switch (player.equipment.GetEquippedWeaponType())
                        {
                            case ScriptableItem.WeaponType.Fist:
                                {
                                    Debug.Log("Its a 1h fist");
                                    anim.SetBool("oneMainHandfistAIMnoOH", true);
                                    anim.SetBool("oneMainHandfistAIMnoOH", true);
                                    break;
                                }
                            case ScriptableItem.WeaponType.Sword:
                                {
                                    Debug.Log("Its a 1h sword!");
                                    anim.SetBool("oneMainHandswordAIMnoOH", true);
                                    anim.SetBool("oneOffHandswordAIMnoOH", true);
                                    break;
                                }
                            case ScriptableItem.WeaponType.Dagger:
                                {
                                    Debug.Log("Its a 1h dagger!");
                                    anim.SetBool("oneMainHanddaggerAIMnoOH", true);
                                    anim.SetBool("oneOffHanddaggerAIMnoOH", true);
                                    break;
                                }
                            case ScriptableItem.WeaponType.Axe:
                                {
                                    Debug.Log("Its a 1h axe!");
                                    anim.SetBool("oneMainHandaxeAIMnoOH", true);
                                    anim.SetBool("oneOffHandaxeAIMnoOH", true);
                                    break;
                                }
                            case ScriptableItem.WeaponType.Mace:
                                {
                                    Debug.Log("Its a 1h mace!");
                                    anim.SetBool("oneMainHandmaceAIMnoOH", true);
                                    anim.SetBool("oneOffHandmaceAIMnoOH", true);
                                    break;
                                }
                            case ScriptableItem.WeaponType.Shield:
                                {
                                    Debug.Log("Its a shield!");
                                    anim.SetBool("shieldAIMnoOH", true);
                                    anim.SetBool("shieldAIMnoOH", true);
                                    break;
                                }
                        }

                    }

                    else if (player.equipment.GetHands() == ScriptableItem.HandsRequired.TWO_HANDED)
                    {
                        // Debug.Log("2h equip equip");

                        switch (player.equipment.GetEquippedWeaponType())
                        {
                            case ScriptableItem.WeaponType.Spear:
                                {
                                    CloseRight(); CloseLeft();
                                    Debug.Log("Its a 2h spear");
                                    anim.SetBool("twoMainHandspearAIMnoOH", true);
                                    anim.SetBool("twoOffHandspearAIMnoOH", true);
                                    break;

                                }

                            case ScriptableItem.WeaponType.Sword:
                                {
                                    CloseRight();
                                    Debug.Log("Its a 2h sword!");
                                    anim.SetBool("twoMainHandswordAIMnoOH", true);
                                    anim.SetBool("twoOffHandswordAIMnoOH", true);
                                    break;

                                }
                            case ScriptableItem.WeaponType.Gun:
                                {
                                    CloseRight(); CloseLeft();
                                    Debug.Log("Its a 2h Gun!");
                                    anim.SetBool("twoMainHandgunAIMnoOH", true);
                                    anim.SetBool("twoOffHandgunAIMnoOH", true);


                                    break;

                                }
                            case ScriptableItem.WeaponType.Axe:
                                {
                                    CloseRight(); CloseLeft();
                                    Debug.Log("Its a 2h axe!");
                                    anim.SetBool("twoMainHandaxeAIMnoOH", true);
                                    anim.SetBool("twoOffHandaxeAIMnoOH", true);
                                    break;
                                }
                            case ScriptableItem.WeaponType.Mace:
                                {
                                    CloseRight(); CloseLeft();
                                    Debug.Log("Its a 2h mace!");
                                    anim.SetBool("twoMainHandmaceAIMnoOH", true);
                                    anim.SetBool("twoOffHandmaceAIMnoOH", true);
                                    break;
                                }


                            case ScriptableItem.WeaponType.Bow:
                                {
                                    Debug.Log("Its a 2h bow!");
                                    anim.SetBool("twoMainHandbowAIMnoOH", true);
                                    anim.SetBool("twoOffHandbowAIMnoOH", true);
                                    break;
                                }
                        }
                    }


                }

                if (player.equipment.slots[24].amount != 0 && player.equipment.slots[25].amount == 0)
                {

                    if (player.equipment.GetHands() == ScriptableItem.HandsRequired.NONE)
                    {
                        // Debug.Log("No weapons equip");




                    }
                    else if (player.equipment.GetHands() == ScriptableItem.HandsRequired.ONE_HANDED)
                    {
                        // Debug.Log("1h equp");

                        switch (player.equipment.GetEquippedWeaponType())
                        {
                            case ScriptableItem.WeaponType.Fist:
                                {
                                    // Debug.Log("Its a 1h fist");
                                    anim.SetBool("oneMainHandfistAIMnoOH", true);
                                    anim.SetBool("oneMainHandfistAIMnoOH", true);
                                    break;
                                }
                            case ScriptableItem.WeaponType.Sword:
                                {
                                    //Debug.Log("Its a 1h sword!");
                                    anim.SetBool("oneMainHandswordAIMnoOH", true);
                                    anim.SetBool("oneOffHandswordAIMnoOH", true);
                                    break;
                                }
                            case ScriptableItem.WeaponType.Dagger:
                                {
                                    //Debug.Log("Its a 1h dagger!");
                                    anim.SetBool("oneMainHanddaggerAIMnoOH", true);
                                    anim.SetBool("oneOffHanddaggerAIMnoOH", true);
                                    break;
                                }
                            case ScriptableItem.WeaponType.Axe:
                                {
                                    //Debug.Log("Its a 1h axe!");
                                    anim.SetBool("oneMainHandaxeAIMnoOH", true);
                                    anim.SetBool("oneOffHandaxeAIMnoOH", true);
                                    break;
                                }
                            case ScriptableItem.WeaponType.Mace:
                                {
                                    //Debug.Log("Its a 1h mace!");
                                    anim.SetBool("oneMainHandmaceAIMnoOH", true);
                                    anim.SetBool("oneOffHandmaceAIMnoOH", true);
                                    break;
                                }
                        }

                    }
                    else if (player.equipment.GetHands() == ScriptableItem.HandsRequired.TWO_HANDED)
                    {
                        // Debug.Log("2h equip equip");

                        switch (player.equipment.GetEquippedWeaponType())
                        {
                            case ScriptableItem.WeaponType.Spear:
                                {
                                    CloseRight(); CloseLeft();
                                    // Debug.Log("Its a 2h spear");
                                    anim.SetBool("twoMainHandspearAIMnoOH", true);
                                    anim.SetBool("twoOffHandspearAIMnoOH", true);
                                    break;

                                }
                            case ScriptableItem.WeaponType.Mace:
                                {
                                    CloseRight(); CloseLeft();
                                    // Debug.Log("Its a 2h spear");
                                    anim.SetBool("twoMainHandmaceAIMnoOH", true);
                                    anim.SetBool("twoOffHandmaceAIMnoOH", true);
                                    break;

                                }

                            case ScriptableItem.WeaponType.Sword:
                                {
                                    CloseRight();
                                    //Debug.Log("Its a 2h sword!");
                                    anim.SetBool("twoMainHandswordAIMnoOH", true);
                                    anim.SetBool("twoOffHandswordAIMnoOH", true);

                                    break;

                                }
                            case ScriptableItem.WeaponType.Gun:
                                {
                                    CloseRight(); CloseLeft();
                                    // Debug.Log("Its a 2h Gun!");
                                    anim.SetBool("twoMainHandgunAIMnoOH", true);
                                    anim.SetBool("twoOffHandgunAIMnoOH", true);


                                    break;

                                }
                            case ScriptableItem.WeaponType.Axe:
                                {
                                    CloseRight(); CloseLeft();
                                    // Debug.Log("Its a 2h axe!");
                                    anim.SetBool("twoMainHandaxeAIMnoOH", true);
                                    anim.SetBool("twoOffHandaxeAIMnoOH", true);
                                    break;
                                }
                            case ScriptableItem.WeaponType.Bow:
                                {
                                    // Debug.Log("Its a 2h bow!");
                                    anim.SetBool("twoMainHandbowAIMnoOH", true);
                                    anim.SetBool("twoOffHandbowAIMnoOH", true);
                                    break;
                                }
                        }
                    }


                }

                if (player.equipment.slots[24].amount == 0 && player.equipment.slots[25].amount != 0)
                {
                    foreach (Animator animator in GetComponentsInChildren<Animator>())
                    {
                        // do something
                    }
                }
                else if (player.equipment.slots[24].amount != 0 && player.equipment.slots[25].amount != 0)
                {
                    foreach (Animator animator in GetComponentsInChildren<Animator>())
                    {
                        // do something
                    }
                }
                else if (player.equipment.slots[24].amount == 0 && player.equipment.slots[25].amount == 0)
                {
                    foreach (Animator animator in GetComponentsInChildren<Animator>())
                    {
                        // do something
                    }
                }

                if (player.equipment.slots[24].amount == 0)
                {
                    OpenRight();
                }

                if (player.equipment.slots[25].amount == 0)
                {
                    OpenLeft();
                }

                if (Player.localPlayer.state == "MOUNTED" ||
                    Player.localPlayer.state == "MOVING" ||
                    Player.localPlayer.state == "CASTING" ||
                    Player.localPlayer.state == "STUNNED" ||
                    Player.localPlayer.state == "Autoattack" ||
                    Player.localPlayer.state == "Strong Hit" ||
                    Player.localPlayer.state == "aoedamageskill" ||
                    Player.localPlayer.state == "frontflip" ||
                    Player.player.charging ||
                    Player.localPlayer.state == "Fireball" ||
                    Player.localPlayer.state == "Fireblast")
                {
                    clearstances();
                }

            }
        }

    }
    public void monster_not_selected()
    {
        clearstances();

    }
    public void nothing_selected()
    {
        clearstances();

    }
}


