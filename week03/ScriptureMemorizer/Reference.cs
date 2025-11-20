public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;
    private string _text;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _text = $"{_book} {_chapter}:{_verse}";
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
        _text = $"{_book} {_chapter}:{_verse}-{_endVerse}";
        
    }

    public string GetDisplayText()
    {
        return _text;
    }

}