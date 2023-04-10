using UnityEngine;

public class CustomToggleGroup : MonoBehaviour
{
    [SerializeField] private CustomToggle[] _toggleList;
    private void Awake()
    {
        foreach (var item in _toggleList)
        {
            item.OnChangeToggle += OffAllToggle;
        }
    }

    public void OffAllToggle()
    {
        foreach (var item in _toggleList)
        {
            item.OffToggle();
        }
    }

}
