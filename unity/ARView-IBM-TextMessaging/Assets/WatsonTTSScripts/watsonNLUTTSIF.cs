using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Watson.NaturalLanguageUnderstanding.V1;
using IBM.Watson.NaturalLanguageUnderstanding.V1.Model;

public class watsonNLUTTSIF 
{
    private WasonNLU wasonNLU;
    //private string NLUResult;
    private int indexOfEmotion = -1;
    public watsonNLUTTSIF(string str)
    {
        wasonNLU = new WasonNLU();
        wasonNLU.sendTextToNLU(str);
        //GameObject.Find("WatsonTTSAndNLU").SendMessage("AddTextToQueue", str);
    }

    public watsonNLUTTSIF()
    {
        wasonNLU = new WasonNLU();
    }
    // use the TTS
    public void soundTTS(string str) {
        GameObject.Find("WatsonTTSAndNLU").SendMessage("AddTextToQueue", str);

    }
    //return index of emotion 
    //Sad return 1 //Joy return2 //Fear return3 //Disgust return4 //Anger return5 //no emotion return 0
    public int getEmotion()
    {
        AnalysisResults analyzeResponse;
        analyzeResponse = wasonNLU.getAnalysisResults();
        parserForNLU p = new parserForNLU();
        indexOfEmotion = p.parse(analyzeResponse);
        return indexOfEmotion;
    }
    // return nlu result (string)
    public string getNLUResult() {

        string NLUResult = null;
        NLUResult = wasonNLU.getResult();
        return NLUResult;
    }
    // return whether aduio is playing  
    public bool getStatusOfAudio()
    {
        return GameObject.Find("WatsonTTSAndNLU").GetComponent<TextToSpeech>().outputAudioSource.isPlaying;
    }
    public void destroyAudio()
    {
        GameObject.Find("WatsonTTSAndNLU").GetComponent<TextToSpeech>().stopSound();
    }


}
