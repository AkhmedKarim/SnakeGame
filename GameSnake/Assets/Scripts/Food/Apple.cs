using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Apple : Food
{
    public override int Points
    {
        get
        {
            switch (DifficultController.currentDifficult)
            {
                default:
                case DifficultController.Difficult.Easy:
                    return 1;
                case DifficultController.Difficult.Medium:
                    return 2;
                case DifficultController.Difficult.Hard:
                    return 3;
            }
        }
    }

    public override void Eated()
    {
        base.Eated();

        StartCoroutine(DestroyAfterSoundPlayd());
    }

    

    public IEnumerator DestroyAfterSoundPlayd()
    {
        Destroy(GetComponent<SpriteRenderer>());
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        Destroy(gameObject);
    }



}

