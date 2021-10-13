using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Types;

public class ShopWindow : EditorWindow
{
    //background color textures
    Texture2D headerSectionTexture;
    Texture2D swordSectionTexture;
    Texture2D gunSectionTexture;
    Texture2D potionSectionTexture;

    //icon textures
    Texture2D swordTexture;
    Texture2D gunTexture;
    Texture2D potTexture;

    Color headerSectionColor = new Color(18f / 255, 32f / 255f, 44f / 255f, 1f);

    Rect headerSection;
    Rect swordSection;
    Rect gunSection;
    Rect potionSection;

    //adding icons
    Rect swordIconSection;
    Rect gunIconSection;
    Rect potIconSection;

    GUISkin skin;

    static SwordData swData;
    static GunData gunData;
    static PotionData potData;

    public static SwordData SwordInfo { get { return swData; } }
    public static GunData GunInfo { get { return gunData; } }
    public static PotionData PotionInfo { get { return potData; } }

    float iconSize = 80;

    [MenuItem("Window/Shop Designer")]
    static void OpenWindow()
    {
        ShopWindow window = (ShopWindow)GetWindow(typeof(ShopWindow));
        window.minSize = new Vector2(600, 300);
        window.Show();
    }

    private void OnEnable()
    {
        InitTextures();
        InitData();
        skin = Resources.Load<GUISkin>("GuiStyles/WeaponCreator_Skin");
    }

    public static void InitData()
    {
        swData = (SwordData)ScriptableObject.CreateInstance(typeof(SwordData));
        gunData = (GunData)ScriptableObject.CreateInstance(typeof(GunData));
        potData = (PotionData)ScriptableObject.CreateInstance(typeof(PotionData));
    }

    void InitTextures() //initialize 2D textures
    {
        headerSectionTexture = new Texture2D(1, 1);
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        headerSectionTexture.Apply();

        swordSectionTexture = Resources.Load<Texture2D>("icons/Red_texture");
        gunSectionTexture = Resources.Load<Texture2D>("icons/Green_texture");
        potionSectionTexture = Resources.Load<Texture2D>("icons/Blue_texture");

        swordTexture = Resources.Load<Texture2D>("Icons/Sword");
        gunTexture = Resources.Load<Texture2D>("Icons/gun");
        potTexture = Resources.Load<Texture2D>("Icons/potion");
    }

    private void OnGUI() //while mouse is over GUI do this
    {
        DrawLayouts();
        DrawHeader();
        DrawSwordSettings();
        DrawGunSettings();
        DrawPotionSettings();
    }

    void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = 50;

        //sword start
        swordSection.x = 0;
        swordSection.y = 50;
        swordSection.width = Screen.width/3f;
        swordSection.height = Screen.width - 50;

        swordIconSection.x = (swordSection.x + swordSection.width / 2f) - iconSize/2;
        swordIconSection.y = swordSection.y + 8;
        swordIconSection.width = iconSize;
        swordIconSection.height = iconSize;
        //sword end

        //gun start
        gunSection.x = Screen.width / 3f;
        gunSection.y = 50;
        gunSection.width = (Screen.width / 3f);
        gunSection.height = Screen.width - 50;

        gunIconSection.x = (gunSection.x + gunSection.width / 2f) - iconSize / 2;
        gunIconSection.y = gunSection.y + 8;
        gunIconSection.width = iconSize;
        gunIconSection.height = iconSize;

        //gun end

        //potion start
        potionSection.x = (Screen.width / 3f) * 2;
        potionSection.y = 50;
        potionSection.width = Screen.width / 3f;
        potionSection.height = Screen.width - 50;

        potIconSection.x = (potionSection.x + potionSection.width / 2f) - iconSize / 2;
        potIconSection.y = potionSection.y + 8;
        potIconSection.width = iconSize;
        potIconSection.height = iconSize;
        //potion end

        //draw backgrounds
        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(swordSection, swordSectionTexture);
        GUI.DrawTexture(gunSection, gunSectionTexture);
        GUI.DrawTexture(potionSection, potionSectionTexture);
        //draw icons
        GUI.DrawTexture(swordIconSection, swordTexture);
        GUI.DrawTexture(gunIconSection, gunTexture);
        GUI.DrawTexture(potIconSection, potTexture);
    }

    void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);

        GUILayout.Label("Item Designer", skin.GetStyle("Header1"));


        GUILayout.EndArea();
    }

    void DrawSwordSettings()
    {
        GUILayout.BeginArea(swordSection);

        GUILayout.Space(iconSize + 8);

        GUILayout.Label("Sword", skin.GetStyle("SwordHeader"));

        //sword damage field
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage Type", skin.GetStyle("SwordField"));
        swData.dmgType = (SwordDmgType)EditorGUILayout.EnumPopup(swData.dmgType);
        EditorGUILayout.EndHorizontal();

        //sword weapon type field
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon Type", skin.GetStyle("SwordField"));
        swData.wpnType = (SwordWpnType)EditorGUILayout.EnumPopup(swData.wpnType);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        { //in final version, it should create it and then push onto a list or array, which can then be accessed in a shop tab.

            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.SWORD);
        }

        GUILayout.EndArea();
    }

    void DrawGunSettings()
    {
        GUILayout.BeginArea(gunSection);

        GUILayout.Space(iconSize + 8);

        GUILayout.Label("Gun", skin.GetStyle("GunHeader"));

        //gun damage field
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage Type", skin.GetStyle("GunField"));
        gunData.dmgType = (GunDmgType)EditorGUILayout.EnumPopup(gunData.dmgType);
        EditorGUILayout.EndHorizontal();

        //gun rate type field
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Rate of Fire", skin.GetStyle("GunField"));
        gunData.rateType = (GunRateType)EditorGUILayout.EnumPopup(gunData.rateType);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        { //in final version, it should create it and then push onto a list or array, which can then be accessed in a shop tab.

            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.GUN);
        }

        GUILayout.EndArea();
    }

    void DrawPotionSettings()
    {
        GUILayout.BeginArea(potionSection);

        GUILayout.Space(iconSize + 8);

        GUILayout.Label("Potion", skin.GetStyle("PotionHeader"));

        //potion effect field
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Effect", skin.GetStyle("PotionField"));
        potData.efctType = (PotionEffectType)EditorGUILayout.EnumPopup(potData.efctType);
        EditorGUILayout.EndHorizontal();

        //potion size field
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Potion Size", skin.GetStyle("PotionField"));
        potData.sizeType = (PotionSizeType)EditorGUILayout.EnumPopup(potData.sizeType);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        { //in final version, it should create it and then push onto a list or array, which can then be accessed in a shop tab.

            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.POTION);
        }

        GUILayout.EndArea();
    }
}


public class GeneralSettings : EditorWindow
{
    public enum SettingsType
    {
        SWORD,
        GUN,
        POTION
    }
    static SettingsType dataSetting;
    static GeneralSettings window;

    public static void OpenWindow(SettingsType setting)
    {
        dataSetting = setting;
        window = (GeneralSettings)GetWindow(typeof(GeneralSettings));
        window.minSize = new Vector2(250, 200);
        window.Show();
    }

    void OnGUI()
    {
        switch (dataSetting)
        {
            case SettingsType.SWORD:
                DrawSettings((ItemData)ShopWindow.SwordInfo);
                break;
            case SettingsType.GUN:
                DrawSettings((ItemData)ShopWindow.GunInfo);
                break;
            case SettingsType.POTION:
                DrawSettings((ItemData)ShopWindow.PotionInfo);
                break;
        }
    }

    void DrawSettings(ItemData itemData)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Prefab");
        itemData.prefab = (GameObject)EditorGUILayout.ObjectField(itemData.prefab, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Sprite/Image");
        itemData.visualSprite = (Sprite)EditorGUILayout.ObjectField(itemData.visualSprite, typeof(Sprite), false);
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Price in Shops");
        itemData.price = EditorGUILayout.FloatField(itemData.price);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        itemData.canBreak = EditorGUILayout.Toggle("Item is Breakable", itemData.canBreak);
        if (itemData.canBreak)
        {
            GUILayout.Label("Item Health");
            itemData.maxHealth = EditorGUILayout.FloatField(itemData.maxHealth);
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Cooldown Time");
        itemData.maxCharge = EditorGUILayout.FloatField(itemData.maxCharge);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Power");
        itemData.power = EditorGUILayout.Slider(itemData.power, 0, 100);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("% Crit Chance");
        itemData.critChance = EditorGUILayout.Slider(itemData.critChance, 0, 100);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Name");
        itemData._name = EditorGUILayout.TextField(itemData._name);
        EditorGUILayout.EndHorizontal();

        if (itemData.prefab == null)
        {
            EditorGUILayout.HelpBox("This item needs a [Prefab]. It cannot be created otherwise.", MessageType.Warning);
        }

        else if (itemData.visualSprite == null)
        {
            EditorGUILayout.HelpBox("This item needs a [Sprite] to show up on the Shop.", MessageType.Warning);
        }

        else if (itemData._name == null || itemData._name.Length < 1)
        {
            EditorGUILayout.HelpBox("This item needs a [Name] to show up on the Shop.", MessageType.Warning);
        }

        else if (GUILayout.Button("Finish and Save", GUILayout.Height(30)))
        {
            SaveItemData();
            window.Close();
        }

    }

    void SaveItemData()
    {
        string prefabPath; //path at the base prefab
        string newPrefabPath = "Assets/Prefabs/Items/";
        string dataPath = "Assets/Resources/ItemData/Data/";

        switch (dataSetting)
        {
            case SettingsType.SWORD:
                //create .asset file
                dataPath += "sword/" + ShopWindow.SwordInfo._name + ".asset";
                AssetDatabase.CreateAsset(ShopWindow.SwordInfo, dataPath);

                newPrefabPath += "sword/" + ShopWindow.SwordInfo._name + ".prefab";
                //get prefab path
                prefabPath = AssetDatabase.GetAssetPath(ShopWindow.SwordInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject swordPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                Debug.Log(swordPrefab);
                if (!swordPrefab.GetComponent<Sword>())
                    swordPrefab.AddComponent(typeof(Sword));
                swordPrefab.GetComponent<Sword>().swordData = ShopWindow.SwordInfo;
                ShopWindow.InitData();
                break;

            case SettingsType.GUN:
                //create .asset file
                dataPath += "gun/" + ShopWindow.GunInfo._name + ".asset";
                AssetDatabase.CreateAsset(ShopWindow.GunInfo, dataPath);

                newPrefabPath += "gun/" + ShopWindow.GunInfo._name + ".prefab";
                //get prefab path
                prefabPath = AssetDatabase.GetAssetPath(ShopWindow.GunInfo.prefab);

                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject gunPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!gunPrefab.GetComponent<Gun>())
                    gunPrefab.AddComponent(typeof(Gun));
                gunPrefab.GetComponent<Gun>().gunData = ShopWindow.GunInfo;
                ShopWindow.InitData();
                break;
            case SettingsType.POTION:
                //create .asset file
                dataPath += "potion/" + ShopWindow.PotionInfo._name + ".asset";
                AssetDatabase.CreateAsset(ShopWindow.PotionInfo, dataPath);

                newPrefabPath += "potion/" + ShopWindow.PotionInfo._name + ".prefab";
                //get prefab path
                prefabPath = AssetDatabase.GetAssetPath(ShopWindow.PotionInfo.prefab);

                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject potionPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!potionPrefab.GetComponent<Potion>())
                    potionPrefab.AddComponent(typeof(Potion));
                potionPrefab.GetComponent<Potion>().potionData = ShopWindow.PotionInfo;
                ShopWindow.InitData();
                break;
        }
    }


}
