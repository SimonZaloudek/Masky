namespace Masky.Models
{
    public enum MaskType
    {
        Turon,
        Slama,
        Medved,
        Vodic,
        NevestaZenich,
        Luca
    }

    public class Answer
    {
        public string Text { get; set; } = "";
        public Dictionary<MaskType, int> Points { get; set; } = new();
    }

    public class Question
    {
        public string Text { get; set; } = "";
        public List<Answer> Answers { get; set; } = new();
    }
}
