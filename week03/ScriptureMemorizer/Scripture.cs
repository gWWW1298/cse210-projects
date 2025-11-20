
public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private Random _rand = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        // Split text into words and create Word objects
        foreach (string w in text.Split(' '))
        {
            _words.Add(new Word(w));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // Split into words (removing extra spaces)
        // string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        
        for (int i = 0; i < numberToHide; i++)
        {
            // Randomly select a word index
            int index = _rand.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        List<string> output = new List<string>();

        foreach (Word w in _words)
        {
            output.Add(w.GetDisplayText());
        }

        return string.Join(" ", output);
    }
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.isHidden());
    }

    public int GetHiddenWordCount()
    {
        return _words.Count(w => w.isHidden());
    }

    public int GetTotalWordCount()
    {
        return _words.Count;
    }


}