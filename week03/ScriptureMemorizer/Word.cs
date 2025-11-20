public class Word
{
    private string _text;
    private bool _isHidden;
    
    public Word(string text)
    {
        _text = text;
    }

    public void Hide()
    {
        _isHidden = true;

    }
    public void Show()
    {
        _isHidden = false;
    }
    public bool isHidden()
    {
        return _isHidden;
    }
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string txt = new string('_', _text.Length);
            return txt;
            
        } 
        else
        {
            return _text;
        }
        
    }
}