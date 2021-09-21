using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ShowUnitStat : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject _unitStat;
    [SerializeField] Sprite _statSprite;
    
    void Update()
    {
        //if (IsMouseOverUI())
        //{
        //    _unitStat.SetActive(true);
        //    Debug.Log("Hellooo");

        //}
        //else
        //{
        //    _unitStat.SetActive(false);
        //}
    }

    private void OnMouseOver()
    {
        //_unitStat.SetActive(true);

        Debug.Log("Hello");

        if (IsMouseOverUI())
        {
            _unitStat.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        //_unitStat.SetActive(false);
    }

    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    bool IsMouseOverUIWithIgnores()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);

        for (int i = 0; i < raycastResultList.Count; i++)
        {
            if (raycastResultList[i].gameObject.GetComponent<UI_UnitDeploySelect>() == null)
            {
                raycastResultList.RemoveAt(i);
                i--;
            }
        }

        return raycastResultList.Count > 0;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _unitStat.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _unitStat.SetActive(false);
    }
}
