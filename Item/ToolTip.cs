//Made by Alex
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour 
{
	RectTransform rect;
    public int minWidth = 220;

	public Text Name;
    public Text SubName;
    public Text DesMain;
    public Text DesTopL;
    public Text DesTopR;
    public Text DesSpecial;
    public Text DesWarning;
    public Text DesStoryL;
    public Text DesStoryR;
    public Text DesPrice;
    public Image TopBG;
    public Image Icon;
    CanvasGroup canvasGroup;

    private float width;
    private float height;

    void Awake()
	{
		canvasGroup = this.transform.GetComponent<CanvasGroup>();
		rect = this.GetComponent<RectTransform> ();
		//DescriptionTextRect = this.transform.GetChild (1).GetComponent<RectTransform> ();
		//nameText = this.transform.GetChild (0).GetComponent<Text> ();
		//descriptionText = this.transform.GetChild (1).GetComponent<Text> ();
	}

	public void Show(ItemData itemData)
	{
        //Set Text
        Name.text = itemData.Name;
        SubName.text = itemData.SubName;
        DesMain.text = itemData.DesMain;
        DesTopL.text = itemData.DesTop.Split('#')[0];
        DesTopR.text = itemData.DesTop.Split('#').Length >= 2 ? itemData.DesTop.Split('#')[1] : "";
        DesSpecial.text = itemData.DesSpecial;
        DesWarning.text = itemData.DesWarning;
        DesStoryL.text = itemData.DesStory.Split('#')[0];
        DesStoryR.text = itemData.DesStory.Split('#').Length >= 2 ? DesStoryR.text = itemData.DesStory.Split('#')[1] : "";
        DesPrice.text = "Price: " + itemData.SellPrice.ToString();

        //Set Icon
        Icon.sprite = Resources.Load<Sprite>(itemData.IconPath);

        //Set Width by Name and SubName
        width = Mathf.RoundToInt(Mathf.Max(minWidth ,Mathf.Max(Name.preferredWidth, SubName.preferredWidth)) + 80);

        TopBG.rectTransform.sizeDelta = new Vector2(width, TopBG.rectTransform.sizeDelta.y);
        DesMain.rectTransform.sizeDelta = new Vector2(width - 20, DesMain.rectTransform.sizeDelta.y);
        DesTopL.rectTransform.sizeDelta = new Vector2(width - 20, DesTopL.rectTransform.sizeDelta.y);
        DesTopR.rectTransform.sizeDelta = new Vector2(width - 20, DesTopR.rectTransform.sizeDelta.y);
        DesSpecial.rectTransform.sizeDelta = new Vector2(width - 20, DesSpecial.rectTransform.sizeDelta.y);
        DesWarning.rectTransform.sizeDelta = new Vector2(width - 20, DesWarning.rectTransform.sizeDelta.y);
        DesStoryL.rectTransform.sizeDelta = new Vector2(width - 20, DesStoryL.rectTransform.sizeDelta.y);
        DesStoryR.rectTransform.sizeDelta = new Vector2(width - 20, DesStoryR.rectTransform.sizeDelta.y);
        DesPrice.rectTransform.sizeDelta = new Vector2(width - 37, DesPrice.rectTransform.sizeDelta.y);

        height = 70;

        if (!string.IsNullOrEmpty(DesTopL.text))
        {
            DesTopL.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            DesMain.rectTransform.anchoredPosition = new Vector2(DesMain.rectTransform.anchoredPosition.x, -DesTopL.preferredHeight - 10);
            height += 10 + DesTopL.preferredHeight;
        }
        else
        {
            DesTopL.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.MinSize;
            DesMain.rectTransform.anchoredPosition = new Vector2(DesMain.rectTransform.anchoredPosition.x, 0);
        }

        DesTopR.rectTransform.anchoredPosition = new Vector2(DesTopR.rectTransform.anchoredPosition.x, DesTopL.rectTransform.anchoredPosition.y - 10);

        if (!string.IsNullOrEmpty(DesMain.text))
        {
            DesMain.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            DesSpecial.rectTransform.anchoredPosition = new Vector2(DesSpecial.rectTransform.anchoredPosition.x, -DesMain.preferredHeight - 10);
            height += 10 + DesMain.preferredHeight;
        }
        else
        {
            DesMain.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.MinSize;
            DesSpecial.rectTransform.anchoredPosition = new Vector2(DesSpecial.rectTransform.anchoredPosition.x, 0);
        }

        if (!string.IsNullOrEmpty(DesSpecial.text))
        {
            DesSpecial.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            DesWarning.rectTransform.anchoredPosition = new Vector2(DesWarning.rectTransform.anchoredPosition.x, -DesSpecial.preferredHeight - 10);
            height += 10 + DesSpecial.preferredHeight;
        }
        else
        {
            DesSpecial.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.MinSize;
            DesWarning.rectTransform.anchoredPosition = new Vector2(DesWarning.rectTransform.anchoredPosition.x, 0);
        }

        if (!string.IsNullOrEmpty(DesWarning.text))
        {
            DesWarning.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            DesStoryL.rectTransform.anchoredPosition = new Vector2(DesStoryL.rectTransform.anchoredPosition.x, -DesWarning.preferredHeight - 10);
            DesStoryR.rectTransform.anchoredPosition = new Vector2(DesStoryR.rectTransform.anchoredPosition.x, -DesWarning.preferredHeight - 10);
            height += 10 + DesWarning.preferredHeight;
        }
        else
        {
            DesWarning.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.MinSize;
            DesStoryL.rectTransform.anchoredPosition = new Vector2(DesStoryL.rectTransform.anchoredPosition.x, 0);
            DesStoryR.rectTransform.anchoredPosition = new Vector2(DesStoryR.rectTransform.anchoredPosition.x, 0);
        }

        if (!string.IsNullOrEmpty(DesStoryL.text))
        {
            DesStoryL.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            DesPrice.rectTransform.anchoredPosition = new Vector2(DesPrice.rectTransform.anchoredPosition.x, -DesStoryL.preferredHeight - 10);
            height += 10 + DesStoryL.preferredHeight;
        }
        else
        {
            DesStoryL.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.MinSize;
            DesPrice.rectTransform.anchoredPosition = new Vector2(DesPrice.rectTransform.anchoredPosition.x, 0);
        }
        
        height += 10 + DesPrice.preferredHeight;

        Debug.Log(width);
        Debug.Log(height);
        rect.sizeDelta = new Vector2(width, height);

        //Set Color
        switch (itemData.ItemQuality)
		{
		case eItemQuality.Common:
			Name.color = SubName.color = TopBG.color = Color.white;
			break;
		case eItemQuality.Rare:
			Name.color = SubName.color = TopBG.color = Color.green;
			break;
		case eItemQuality.Special:
			Name.color = SubName.color = TopBG.color = new Color(0.25f,0.4f,1f);
			break;
		case eItemQuality.Epic:
			Name.color = SubName.color = TopBG.color = new Color(0.8f,0.1f,0.6f);
			break;
		case eItemQuality.Legendary:
			Name.color = SubName.color = TopBG.color = new Color(1f,0.7f,0f);
			break;
		default:
			break;
		}


		StartCoroutine ("ShowContent");
	}

	IEnumerator ShowContent()
	{
		yield return new WaitForEndOfFrame ();
		//Resize ();
		canvasGroup.alpha = 1f;
	}

	public void Hide()
	{
		canvasGroup.alpha = 0f;
		Name.text = "";
		DesMain.text = "";
	}

	public void Resize()
	{

	}

	public void Reposition()
	{
		this.GetComponent<RectTransform> ().position = Input.mousePosition;
	}
}