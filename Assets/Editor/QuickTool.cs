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
        //ссылка на корневой элемент окна
        var root = rootVisualElement;

        //создание кнопки и инициализация поля текст
        var myButton = new Button() { text = "My Button" };

        //раздать стиля
        myButton.style.width = 160;
        myButton.style.height = 30;

        //добавить под корень
        root.Add(myButton);
    }

}
