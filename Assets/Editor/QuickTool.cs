using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class QuickTool : EditorWindow
{
    [MenuItem("QuickTool/Open _%#T")]
    public static void ShowWindow()
    {
        //открывает окно. Если открыто, ставит фокус на него.
        var window = GetWindow<QuickTool>();

        //добавить заголовок
        window.titleContent = new GUIContent("QuickTool");

        //Задать минимальный размер
        window.minSize = new Vector2(280, 50);
    }


    private void CreateGUI()
    {
        /*пример добавления ui элмента через скрипт
        
        //ссылка на корневой элемент окна
        var root = rootVisualElement;

        //создание кнопки и инициализация поля текст
        var myButton = new Button() { text = "My Button" };

        //раздать стиля
        myButton.style.width = 160;
        myButton.style.height = 30;

        //добавить под корень
        root.Add(myButton);
        */

        var root = rootVisualElement;

        //подтягиваем USS
        root.styleSheets.Add(Resources.Load<StyleSheet>("QuickTool_Style"));

        //подгрузить дерево из файла
        var quickToolVisualTree = Resources.Load<VisualTreeAsset>("QuickTool_Main");
        //клонировать дерево в корень
        quickToolVisualTree.CloneTree(root);

        //получаем все кнопки из дерева по классу quicktool-button
        var toolButtons = root.Query(className: "quicktool-button");
        //пропускаем каждую кнопку через метод SetupButton
        toolButtons.ForEach(SetupButton);
    }

    private void SetupButton(VisualElement button)
    {
        //ищем под кнопкой элемент с нужным классом? да. И извлкаем его
        var buttonIcon = button.Q(className: "quicktool-button-icon");

        //определем имя иконки
        var iconPath = "Icons/" + button.parent.name + "_icon";
        //подгружаем иконку по пути
        var iconAsset = Resources.Load<Texture2D>(iconPath);

        //ставим иконку как bg кнопки
        buttonIcon.style.backgroundImage = iconAsset;

        //callback: спавним примитив по нажатию
        button.RegisterCallback<PointerUpEvent, string>(CreateObject, button.parent.name);

        button.tooltip = button.parent.name;
    }

    //собственно вызываемый кнопкой метод
    private void CreateObject(PointerUpEvent _, string primitiveTypeName)
    {
        //определяем какой примитив нам нужен по имени из параметра
        var pt = (PrimitiveType)Enum.Parse(enumType: typeof(PrimitiveType),
                                           value: primitiveTypeName,
                                           ignoreCase: true);

        //фабрика для создания из эдитора? что то типа аналога Instantiate?
        var go = ObjectFactory.CreatePrimitive(pt);
        go.transform.position = Vector3.zero;
    }

}
