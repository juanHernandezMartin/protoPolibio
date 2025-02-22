using TMPro;
using UnityEngine;

public class QuestsView : MonoBehaviour
{
    private QuestsController _questsController;

    [SerializeField] private TextMeshProUGUI _quest1Description;
    [SerializeField] private TextMeshProUGUI _quest2Description;
    [SerializeField] private TextMeshProUGUI _quest3Description;

    [SerializeField] private GameObject _quest1CheckMark;
    [SerializeField] private GameObject _quest2CheckMark;
    [SerializeField] private GameObject _quest3CheckMark;

    public void Init(Quest quest1, Quest quest2, Quest quest3)
    {
        _quest1Description.text = quest1.description;
        _quest2Description.text = quest2.description;
        _quest3Description.text = quest3.description;
        _quest1CheckMark.SetActive(false);
        _quest2CheckMark.SetActive(false);
        _quest3CheckMark.SetActive(false);
    }

    public void MarkQuestAsCompleted(int questIndex)
    {
        switch (questIndex)
        {
            case 1:
                _quest1CheckMark.SetActive(true);
                break;
            case 2:
                _quest2CheckMark.SetActive(true);
                break;
            case 3:
                _quest3CheckMark.SetActive(true);
                break;
            default:
                Debug.LogWarning("Quest with index " + questIndex + " not found");
                break;
        }
    }
}