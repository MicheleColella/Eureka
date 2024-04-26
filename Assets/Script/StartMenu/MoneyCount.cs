using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCount : MonoBehaviour
{
    public TextMeshProUGUI[] ResistorText;
    public TextMeshProUGUI[] TransistorText;

    public int ResistorsCont;
    public int TransistorsCont;

    private void Update()
    {
        updateResistors(ResistorsCont);
        updateTransistors(TransistorsCont);
    }

    public void updateResistors(int ResistorsCont)
    {
        for(int i = 0; i < ResistorText.Length; i++)
        {
            ResistorText[i].text = ResistorsCont.ToString();
        }
    }

    public void updateTransistors(int TransistorsCont)
    {
        for (int i = 0; i < TransistorText.Length; i++)
        {
            TransistorText[i].text = TransistorsCont.ToString();
        }
    }
}
