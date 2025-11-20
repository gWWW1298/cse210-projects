
public class Scripture
{
    Reference _reference = new Reference();
    List<Word> _word = new List<Word>();

    public Scripture(Reference Reference, string text)
    {
        _reference = Reference;
        _word = text;
    }

    public void HideRandomWords(int numberToHide)
    {
        pass
    }
    public string GetDisplayText()
    {
        // return string;
    }
    public bool IsCompletelyHidden()
    {
        // return bool;
    }
}