using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR.InteractionSystem.Sample;

public class ResetButton : ButtonEffect
{

    public List<GameObject> gameObjectToReset;
    public List<GameObject> replacementPrefabs;
    public List<Transform> resetLocations;

    public AudioSource buttonDownSound;
    public AudioSource buttonUpSound;

    public override void OnButtonDown(Hand fromHand)
    {
        base.OnButtonDown(fromHand);
        buttonDownSound.PlayOneShot(buttonDownSound.clip);
        List<GameObject> replacements = new List<GameObject>();
        for (int i = 0; i < gameObjectToReset.Count; i++)
        {
            Destroy(gameObjectToReset[i]);
            replacements.Add(Instantiate(replacementPrefabs[i], resetLocations[i].position, resetLocations[i].rotation));
        }
        gameObjectToReset = replacements;
    }

    public override void OnButtonUp(Hand fromHand)
    {
        base.OnButtonUp(fromHand);
        buttonUpSound.PlayOneShot(buttonUpSound.clip);
    }

    public override void ColorSelf(Color newColor)
    {
        base.ColorSelf(newColor);
    }
}
