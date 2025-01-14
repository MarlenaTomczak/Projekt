using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Panel obsługujący pasek narzędzi w grze
public class ItemToolBarPanel : ItemPanel
{
    // Referencja do kontrolera paska narzędzi
    [SerializeField] ToolBarController toolBarController;

    private void Start()
    {
        // Inicjalizacja panelu
        Init();

        // Subskrybuj zdarzenie zmiany narzędzia w pasku narzędzi
        toolBarController.onChange += Highlight;

        // Podświetl domyślne narzędzie
        Highlight(0);
    }

    // Obsługuje kliknięcia na przyciski paska narzędzi
    public override void OnClick(int id)
    {
        toolBarController.Set(id); // Ustaw narzędzie w kontrolerze paska narzędzi
        Highlight(id); // Podświetl wybrane narzędzie
    }

    int currentSelectedTool; // Aktualnie wybrane narzędzie

    // Podświetla wybrane narzędzie
    public void Highlight(int id)
    {
        buttons[currentSelectedTool].Highlight(false); // Wyłącz podświetlenie poprzedniego narzędzia
        currentSelectedTool = id;
        buttons[currentSelectedTool].Highlight(true); // Włącz podświetlenie nowego narzędzia
    }

    // Wyświetla zawartość paska narzędzi i aktualizuje ikonę podświetlenia
    public override void Show()
    {
        base.Show(); // Wywołaj metodę bazową, aby wyświetlić elementy paska narzędzi
        toolBarController.UpdateHighlightIcon(); // Zaktualizuj ikonę podświetlenia
    }
}