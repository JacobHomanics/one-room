using Privy;
using UnityEngine;

public class TextCopier : MonoBehaviour
{
    public async void Copy()
    {
        var user = await PrivyManager.Instance.GetUser();

        GUIUtility.systemCopyBuffer = user.EmbeddedWallets[0].Address;

    }
}
