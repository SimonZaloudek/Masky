using Masky.Models;

namespace Masky.Services
{
    public class QuizService
    {
        public List<Question> Questions { get; private set; } = new();
        private Dictionary<MaskType, int> _score = new();
        private Random _random = new();

        public int CurrentIndex { get; private set; } = 0;
        public bool IsFinished => CurrentIndex >= Questions.Count;

        public QuizService()
        {
            InitQuestions();
            Reset();
        }

        public void Reset()
        {
            CurrentIndex = 0;
            _score = Enum.GetValues<MaskType>().ToDictionary(m => m, _ => 0);

            Questions = Questions.OrderBy(_ => _random.Next()).ToList();

            foreach (var question in Questions)
            {
                question.Answers = question.Answers.OrderBy(_ => _random.Next()).ToList();
            }
        }

        public void SubmitAnswer(Answer answer)
        {
            foreach (var (mask, points) in answer.Points)
                _score[mask] += points;

            CurrentIndex++;
        }

        public MaskType GetResult()
        {
            return _score.OrderByDescending(kvp => kvp.Value).First().Key;
        }

        public Dictionary<MaskType, int> GetResultBreakdown()
        {
            return new Dictionary<MaskType, int>(_score);
        }

        private void InitQuestions()
        {
            Questions = new List<Question>
            {
                new()
                {
                    Text = "Ako sa správaš na oslavách?",
                    Answers = new()
                    {
                        new() { Text = "Tancujem, žartujem, som stredobodom pozornosti", Points = { [MaskType.Turon] = 2 } },
                        new() { Text = "Sedím v kúte a pozorujem", Points = { [MaskType.Zobrak] = 2 } },
                        new() { Text = "Provokujem alebo robím chaos", Points = { [MaskType.Diabol] = 2 } },
                        new() { Text = "Nepáči sa mi hluk, odchádzam", Points = { [MaskType.Smrt] = 2 } },
                        new() { Text = "Ticho sa bavím s pár blízkymi", Points = { [MaskType.Zobrak] = 1, [MaskType.Turon] = 1 } },
                        new() { Text = "Pozorujem reakcie ľudí a vnímam atmosféru", Points = { [MaskType.Smrt] = 1, [MaskType.Zobrak] = 1 } }
                    }
                },
                new()
                {
                    Text = "Ako tráviš voľný čas?",
                    Answers = new()
                    {
                        new() { Text = "S priateľmi vonku, v prírode", Points = { [MaskType.Turon] = 2 } },
                        new() { Text = "S knihou alebo sám doma", Points = { [MaskType.Zobrak] = 2 } },
                        new() { Text = "Skúšam niečo nezvyčajné alebo riskantné", Points = { [MaskType.Diabol] = 2 } },
                        new() { Text = "Uvažujem nad zmyslom života", Points = { [MaskType.Smrt] = 2 } },
                        new() { Text = "Cestujem na neznáme miesta", Points = { [MaskType.Diabol] = 1, [MaskType.Turon] = 1 } },
                        new() { Text = "Rozjímam a zapisujem si myšlienky", Points = { [MaskType.Smrt] = 1, [MaskType.Zobrak] = 1 } }
                    }
                },
                new()
                {
                    Text = "Ako reaguješ na konflikty?",
                    Answers = new()
                    {
                        new() { Text = "Zmierujem ľudí, žartujem", Points = { [MaskType.Turon] = 2 } },
                        new() { Text = "Vyhýbam sa, radšej odídem", Points = { [MaskType.Zobrak] = 2 } },
                        new() { Text = "Idem do konfrontácie", Points = { [MaskType.Diabol] = 2 } },
                        new() { Text = "Zatvorím sa do seba", Points = { [MaskType.Smrt] = 2 } },
                        new() { Text = "Snažím sa pochopiť obe strany", Points = { [MaskType.Zobrak] = 1, [MaskType.Smrt] = 1 } },
                        new() { Text = "Používam humor ako štít", Points = { [MaskType.Turon] = 1, [MaskType.Diabol] = 1 } }
                    }
                },
                new()
                {
                    Text = "Ako ťa vnímajú iní?",
                    Answers = new()
                    {
                        new() { Text = "Veselý a spoločenský", Points = { [MaskType.Turon] = 2 } },
                        new() { Text = "Tichý a záhadný", Points = { [MaskType.Zobrak] = 2 } },
                        new() { Text = "Silný, ale kontroverzný", Points = { [MaskType.Diabol] = 2 } },
                        new() { Text = "Vážny a hlboký", Points = { [MaskType.Smrt] = 2 } },
                        new() { Text = "Pozitívny a povzbudzujúci", Points = { [MaskType.Turon] = 1, [MaskType.Smrt] = 1 } },
                        new() { Text = "Nevyspytateľný a zaujímavý", Points = { [MaskType.Diabol] = 1, [MaskType.Zobrak] = 1 } }
                    }
                },
                new()
                {
                    Text = "Ktoré ročné obdobie máš najradšej?",
                    Answers = new()
                    {
                        new() { Text = "Jar – všetko ožíva!", Points = { [MaskType.Turon] = 2 } },
                        new() { Text = "Jeseň – pokoj a farby", Points = { [MaskType.Zobrak] = 2 } },
                        new() { Text = "Leto – extrémy a dobrodružstvá", Points = { [MaskType.Diabol] = 2 } },
                        new() { Text = "Zima – ticho a chlad", Points = { [MaskType.Smrt] = 2 } },
                        new() { Text = "Prechod medzi sezónami – zmena je krásna", Points = { [MaskType.Turon] = 1, [MaskType.Smrt] = 1 } },
                        new() { Text = "Nezáleží na období, ale na ľuďoch okolo", Points = { [MaskType.Turon] = 1, [MaskType.Zobrak] = 1 } }
                    }
                }
            };
        }
    }
}
