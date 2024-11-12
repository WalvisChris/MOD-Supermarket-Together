/*
Displaying the max price on the price changer machine thingy
*/

private void Update()
{
	if (this.hatID > 0 && !this.hatOBJ)
	{
		GameObject gameObject = null;
		foreach (Transform child in base.transform)							// EDIT: error fixing for IEnumerator not being disposable (replace with a foreach loop)
		{																	//
			if (child.name == "Character")									//
			{																//
				gameObject = base.transform.Find("Character").gameObject;	//
				break;														//
			}																//
		}																	//
		if (gameObject == null)
		{
			return;
		}
		int num = this.hatID;
		num = Mathf.Clamp(num, 0, this.hatsArray.Length - 1);
		GameObject value = gameObject.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("HatSpot").Value;
		this.hatOBJ = UnityEngine.Object.Instantiate<GameObject>(this.hatsArray[num], value.transform);	// EDIT: replace Object with UnityEngine.Object (ambiguous error)
		this.hatOBJ.transform.localPosition = this.hatOBJ.GetComponent<HatInfo>().offset;
		this.hatOBJ.transform.localRotation = Quaternion.Euler(this.hatOBJ.GetComponent<HatInfo>().rotation);
		if (base.isLocalPlayer)
		{
			this.hatOBJ.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.ShadowsOnly;
			if (this.hatOBJ.transform.childCount > 0)
			{
				this.hatOBJ.transform.GetChild(0).gameObject.SetActive(false);
			}
		}
	}
	if (!base.isLocalPlayer)
	{
		return;
	}
	this.PoseBehaviour();
	if (this.MainPlayer.GetButtonDown("Drop Item") && this.equippedItem > 0)
	{
		if (this.dropCooldown)
		{
			return;
		}
		if (FsmVariables.GlobalVariables.GetFsmBool("InChat").Value || FsmVariables.GlobalVariables.GetFsmBool("InOptions").Value)
		{
			return;
		}
		Vector3 vector = Vector3.zero;
		RaycastHit raycastHit;
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 4f, this.lMask))
		{
			vector = raycastHit.point + raycastHit.normal.normalized * 0.5f;
			if (raycastHit.transform.gameObject.tag == "Interactable" && !raycastHit.transform.GetComponent<BoxData>())
			{
				return;
			}
			RaycastHit raycastHit2;
			if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit2, 4f, this.interactableMask) && raycastHit2.transform.gameObject.tag == "Interactable")
			{
				return;
			}
		}
		else
		{
			vector = Camera.main.transform.position + Camera.main.transform.forward * 3.5f;
		}
		if (this.equippedItem > 0)
		{
			base.StartCoroutine(this.DropCooldown());
		}
		switch (this.equippedItem)
		{
		case 0:
		case 4:
			break;
		case 1:
			this.CmdChangeEquippedItem(0);
			GameData.Instance.GetComponent<ManagerBlackboard>().CmdSpawnBoxFromPlayer(vector, this.extraParameter1, this.extraParameter2, base.transform.rotation.eulerAngles.y);
			break;
		case 2:
			this.CmdChangeEquippedItem(0);
			GameData.Instance.GetComponent<NetworkSpawner>().CmdSpawnProp(2, vector, new Vector3(0f, 0f, 90f));
			break;
		case 3:
			this.CmdChangeEquippedItem(0);
			GameData.Instance.GetComponent<NetworkSpawner>().CmdSpawnProp(3, vector, new Vector3(270f, 0f, 0f));
			break;
		case 5:
			this.CmdChangeEquippedItem(0);
			GameData.Instance.GetComponent<NetworkSpawner>().CmdSpawnProp(5, vector, new Vector3(270f, 0f, 0f));
			break;
		default:
			MonoBehaviour.print("Equipped item error");
			break;
		}
	}
	if (!this.gameCanvasProductOBJ && GameCanvas.Instance)
	{
		this.gameCanvasProductOBJ = GameCanvas.Instance.transform.Find("ProductShow").gameObject;
	}
	RaycastHit raycastHit3;
	if (this.gameCanvasProductOBJ && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit3, 4f, this.interactableMask))
	{
		if (raycastHit3.transform.gameObject.name == "SubContainer")
		{
			int siblingIndex = raycastHit3.transform.GetSiblingIndex();
			Data_Container component = raycastHit3.transform.parent.transform.parent.GetComponent<Data_Container>();
			if (component.containerClass < 20)
			{
				int num2 = component.productInfoArray[siblingIndex * 2];
				if (num2 < 0)
				{
					this.oldCanvasProductID = -2;
					this.gameCanvasProductOBJ.SetActive(false);
				}
				if (num2 >= 0 && this.oldCanvasProductID != num2)
				{
					this.gameCanvasProductOBJ.SetActive(true);
					this.gameCanvasProductOBJ.transform.Find("Container/ProductName").GetComponent<TextMeshProUGUI>().text = LocalizationManager.instance.GetLocalizationString("product" + num2.ToString());
					this.gameCanvasProductOBJ.transform.Find("Container/ProductBrand").GetComponent<TextMeshProUGUI>().text = ProductListing.Instance.productPrefabs[num2].GetComponent<Data_Product>().productBrand;
					this.gameCanvasProductOBJ.transform.Find("Container/ProductImage").GetComponent<Image>().sprite = ProductListing.Instance.productSprites[num2];
					this.oldCanvasProductID = num2;
				}
			}
			else
			{
				this.oldCanvasProductID = -3;
				this.gameCanvasProductOBJ.SetActive(false);
			}
		}
		else
		{
			this.oldCanvasProductID = -4;
			this.gameCanvasProductOBJ.SetActive(false);
		}
	}
	else if (this.gameCanvasProductOBJ)
	{
		this.oldCanvasProductID = -5;
		this.gameCanvasProductOBJ.SetActive(false);
	}
	if (this.instantiatedOBJ)
	{
		switch (this.equippedItem)
		{
		case 0:
		case 3:
		case 4:
		case 5:
			break;
		case 1:
		{
			float num3 = Camera.main.transform.localEulerAngles.x;
			if (num3 > 90f)
			{
				this.instantiatedOBJ.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
				this.instantiatedOBJ.transform.localPosition = new Vector3(0f, 0.1f, 0f);
			}
			else
			{
				num3 = Mathf.Clamp(num3, 0f, 20f);
				this.instantiatedOBJ.transform.localRotation = Quaternion.Euler(0f, 90f, num3);
				float t = num3 / 20f;
				float y = Mathf.Lerp(0.1f, -0.3f, t);
				float x = Mathf.Lerp(0f, 0.55f, t);
				this.instantiatedOBJ.transform.localPosition = new Vector3(x, y, 0f);
			}
			this.canvasTMP.text = "x" + this.extraParameter2.ToString();
			return;
		}
		case 2:
		{
			RaycastHit raycastHit4;
			if (!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit4, 4f, this.interactableMask))
			{
				this.oldProductID = -5;
				this.pricingCanvas.SetActive(false);
				this.basefloatString = "";
				return;
			}
			if (!(raycastHit4.transform.gameObject.name == "SubContainer"))
			{
				this.oldProductID = -4;
				this.pricingCanvas.SetActive(false);
				this.basefloatString = "";
				return;
			}
			int siblingIndex2 = raycastHit4.transform.GetSiblingIndex();
			Data_Container component2 = raycastHit4.transform.parent.transform.parent.GetComponent<Data_Container>();
			if (component2.containerClass >= 20)
			{
				this.oldProductID = -3;
				this.pricingCanvas.SetActive(false);
				this.basefloatString = "";
				return;
			}
			int num4 = component2.productInfoArray[siblingIndex2 * 2];
			if (num4 < 0)
			{
				this.oldProductID = -2;
				this.pricingCanvas.SetActive(false);
				this.basefloatString = "";
				return;
			}
			if (this.oldProductID != num4)
			{
				this.productNameTMP.text = LocalizationManager.instance.GetLocalizationString("product" + num4.ToString());
				this.productBrandTMP.text = ProductListing.Instance.productPrefabs[num4].GetComponent<Data_Product>().productBrand;
				this.productImage.sprite = ProductListing.Instance.productSprites[num4];
				float num5 = ProductListing.Instance.tierInflation[ProductListing.Instance.productPrefabs[num4].GetComponent<Data_Product>().productTier];
				float num6 = ProductListing.Instance.productPrefabs[num4].GetComponent<Data_Product>().basePricePerUnit * num5;
				num6 = Mathf.Round(num6 * 100f) / 100f;
				this.marketPriceTMP.text = "$" + num6.ToString();
				float num7 = ProductListing.Instance.productPlayerPricing[num4];
				num7 = Mathf.Round(num7 * 100f) / 100f;
				this.yourPriceTMP.text = string.Concat(new string[]		// EDIT: showing the market price x2 in red
				{														//
					"$",												//
					num7.ToString(),									// num7 = your price
					" <color=red>$",									//
					(num6 * 2f).ToString(),								// num6 = market price
					"</color>"											//
				});														//
				this.pPrice = num7;
				this.pricingCanvas.SetActive(true);
				this.oldProductID = num4;
				this.basefloatString = "";
			}
			this.PriceSetFromNumpad(num4);
			if (this.MainPlayer.GetButtonDown("Menu Previous"))
			{
				this.pPrice += (this.MainPlayer.GetButton("Build") ? 0.2f : 0.01f);
				this.yourPriceTMP.text = ProductListing.Instance.ConvertFloatToTextPrice(this.pPrice);
			}
			else if (this.MainPlayer.GetButtonDown("Menu Next"))
			{
				this.pPrice -= (this.MainPlayer.GetButton("Build") ? 0.2f : 0.01f);
				this.pPrice = Mathf.Clamp(this.pPrice, 0f, float.PositiveInfinity);
				this.yourPriceTMP.text = ProductListing.Instance.ConvertFloatToTextPrice(this.pPrice);
			}
			if (this.MainPlayer.GetButtonDown("Main Action") && ProductListing.Instance.productPlayerPricing[num4] != this.pPrice)
			{
				this.CmdPlayPricingSound();
				ProductListing.Instance.CmdUpdateProductPrice(num4, this.pPrice);
			}
			if (this.MainPlayer.GetButtonDown("Secondary Action") && component2.productInfoArray[siblingIndex2 * 2 + 1] <= 0)
			{
				base.transform.Find("ResetProductSound").GetComponent<AudioSource>().Play();
				component2.CmdContainerClear(siblingIndex2 * 2);
				return;
			}
			break;
		}
		default:
			MonoBehaviour.print("Equipped item error");
			break;
		}
	}
}