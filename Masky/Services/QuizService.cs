using Masky.Models;

namespace Masky.Services
{
    public class QuizService
    {
        public List<Question> Questions { get; private set; } = new();
        private Dictionary<MaskType, int> _score = new();

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
                new() { Text = "Nepáči sa mi hluk, odchádzam", Points = { [MaskType.Smrt] = 2 } }
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
                new() { Text = "Uvažujem nad zmyslom života", Points = { [MaskType.Smrt] = 2 } }
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
                new() { Text = "Zatvorím sa do seba", Points = { [MaskType.Smrt] = 2 } }
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
                new() { Text = "Vážny a hlboký", Points = { [MaskType.Smrt] = 2 } }
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
                new() { Text = "Zima – ticho a chlad", Points = { [MaskType.Smrt] = 2 } }
            }
        },
        new()
        {
            Text = "Ako by si opísal svoje detstvo?",
            Answers = new()
            {
                new() { Text = "Veselé a bezstarostné", Points = { [MaskType.Turon] = 2 } },
                new() { Text = "Samotárske, ale pokojné", Points = { [MaskType.Zobrak] = 2 } },
                new() { Text = "Plné výziev a rebelstva", Points = { [MaskType.Diabol] = 2 } },
                new() { Text = "Hlboké a introspektívne", Points = { [MaskType.Smrt] = 2 } }
            }
        },
        new()
        {
            Text = "Ako si predstavuješ ideálny večer?",
            Answers = new()
            {
                new() { Text = "Pri ohni s priateľmi a hudbou", Points = { [MaskType.Turon] = 2 } },
                new() { Text = "V tichu sám so sebou", Points = { [MaskType.Zobrak] = 2 } },
                new() { Text = "Na koncerte alebo párty", Points = { [MaskType.Diabol] = 2 } },
                new() { Text = "S hlbokým filmom alebo knihou", Points = { [MaskType.Smrt] = 2 } }
            }
        },
        new()
        {
            Text = "Ktoré zviera ťa najviac vystihuje?",
            Answers = new()
            {
                new() { Text = "Medveď – silný a veselý", Points = { [MaskType.Turon] = 2 } },
                new() { Text = "Sova – tichá a múdra", Points = { [MaskType.Zobrak] = 2 } },
                new() { Text = "Kohút – hlučný a hrdý", Points = { [MaskType.Diabol] = 2 } },
                new() { Text = "Netopier – nočný samotár", Points = { [MaskType.Smrt] = 2 } }
            }
        },
        new()
        {
            Text = "Čo si myslíš o smrti?",
            Answers = new()
            {
                new() { Text = "Je to súčasť kolobehu života", Points = { [MaskType.Turon] = 2 } },
                new() { Text = "Radšej o tom nepremýšľam", Points = { [MaskType.Zobrak] = 2 } },
                new() { Text = "Je to výzva osudu", Points = { [MaskType.Diabol] = 2 } },
                new() { Text = "Je to niečo, čo ma fascinuje", Points = { [MaskType.Smrt] = 2 } }
            }
        },
        new()
        {
            Text = "Čo ťa najviac motivuje?",
            Answers = new()
            {
                new() { Text = "Zábava a ľudia", Points = { [MaskType.Turon] = 2 } },
                new() { Text = "Pocit pokoja", Points = { [MaskType.Zobrak] = 2 } },
                new() { Text = "Prelomovanie hraníc", Points = { [MaskType.Diabol] = 2 } },
                new() { Text = "Hľadanie pravdy", Points = { [MaskType.Smrt] = 2 } }
            }
        },
        new()
        {
            Text = "Čo je podľa teba sila?",
            Answers = new()
            {
                new() { Text = "Zabávať a združovať", Points = { [MaskType.Turon] = 2 } },
                new() { Text = "Vydržať v tichu", Points = { [MaskType.Zobrak] = 2 } },
                new() { Text = "Vyjadriť sa nahlas", Points = { [MaskType.Diabol] = 2 } },
                new() { Text = "Nechať veciam zmysel", Points = { [MaskType.Smrt] = 2 } }
            }
        },
        new()
        {
            Text = "Čo by si si vybral ako darček?",
            Answers = new()
            {
                new() { Text = "Zážitok – koncert, výlet", Points = { [MaskType.Turon] = 2 } },
                new() { Text = "Pokojný deň osamote", Points = { [MaskType.Zobrak] = 2 } },
                new() { Text = "Niečo nečakané, výstredné", Points = { [MaskType.Diabol] = 2 } },
                new() { Text = "Osobnú knihu alebo denník", Points = { [MaskType.Smrt] = 2 } }
            }
        },
        new()
        {
            Text = "Kde by si žil najradšej?",
            Answers = new()
            {
                new() { Text = "V živej dedine plnej osláv", Points = { [MaskType.Turon] = 2 } },
                new() { Text = "V malej chalupe pri lese", Points = { [MaskType.Zobrak] = 2 } },
                new() { Text = "V meste plnom výziev", Points = { [MaskType.Diabol] = 2 } },
                new() { Text = "V kláštore alebo samote", Points = { [MaskType.Smrt] = 2 } }
            }
        },
        new()
        {
            Text = "Aká je tvoja slabina?",
            Answers = new()
            {
                new() { Text = "Beriem veci na ľahkú váhu", Points = { [MaskType.Turon] = 2 } },
                new() { Text = "Neviem sa otvoriť", Points = { [MaskType.Zobrak] = 2 } },
                new() { Text = "Často provokujem", Points = { [MaskType.Diabol] = 2 } },
                new() { Text = "Zachádzam do smútku", Points = { [MaskType.Smrt] = 2 } }
            }
        },
        new()
        {
            Text = "Čo by si chcel, aby o tebe ľudia hovorili?",
            Answers = new()
            {
                new() { Text = "Bol to veselý človek", Points = { [MaskType.Turon] = 2 } },
                new() { Text = "Bol tichý, ale múdry", Points = { [MaskType.Zobrak] = 2 } },
                new() { Text = "Nebál sa ísť proti prúdu", Points = { [MaskType.Diabol] = 2 } },
                new() { Text = "Bol hlboký a premýšľavý", Points = { [MaskType.Smrt] = 2 } }
            }
        }
    };
        }
    }
}
