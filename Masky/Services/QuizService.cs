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
                    Text = "Čo urobíš, keď vznikne hádka pri stole?",
                    Answers = new()
                    {
                        new() { Text = "Pozriem do taniera a nechám hádku prejsť.", Points = { [MaskType.Slama] = 2 } },
                        new() { Text = "Zapojím sa, nech je ešte väčšia sranda.", Points = { [MaskType.Turon] = 2 } },
                        new() { Text = "Snažím sa všetkých upokojiť.", Points = { [MaskType.Medved] = 2 } },
                        new() { Text = "Zvýšim hlas a ukážem každému svoje miesto.", Points = { [MaskType.Vodic] = 2 } },
                        new() { Text = "Som ticho a manifestujem koniec.", Points = { [MaskType.Luca] = 2 } },
                        new() { Text = "Urazím sa, ale odpustím rýchlo.", Points = { [MaskType.NevestaZenich] = 2 } }
                    }
                },
                new()
                {
                    Text = "Ako najradšej tráviš dlhý večer?",
                    Answers = new()
                    {
                        new() { Text = "Vymýšľam a tvorím nové veci.", Points = { [MaskType.Slama] = 2 } },
                        new() { Text = "Idem na párty a opijem sa.", Points = { [MaskType.Turon] = 2 } },
                        new() { Text = "Zaleziem pod deku a zapnem si film.", Points = { [MaskType.Medved] = 2 } },
                        new() { Text = "Plánujem prácu na zajtra.", Points = { [MaskType.Vodic] = 2 } },
                        new() { Text = "Sedím v tme a počúvam hudbu.", Points = { [MaskType.Luca] = 2 } },
                        new() { Text = "S partnerom si pustíme seriál a niečo dobré zjeme.", Points = { [MaskType.NevestaZenich] = 2 } }
                    }
                },
                new()
                {
                    Text = "Ako sa zachováš, keď je niekto smutný?",
                    Answers = new()
                    {
                        new() { Text = "Potichu si k nemu sadnem.", Points = { [MaskType.Slama] = 2 } },
                        new() { Text = "Snažím sa ho rozosmiať.", Points = { [MaskType.Turon] = 2 } },
                        new() { Text = "Objímem ho a nič nehovorím.", Points = { [MaskType.Medved] = 2 } },
                        new() { Text = "Poviem mu, nech sa spamätá a ide ďalej.", Points = { [MaskType.Vodic] = 2 } },
                        new() { Text = "Vypočujem si ho, pokúsim sa mu pomôcť.", Points = { [MaskType.Luca] = 2 } },
                        new() { Text = "Poviem, že ho ľúbim a budem mu oporou.", Points = { [MaskType.NevestaZenich] = 2 } }
                    }
                },
                new()
                {
                    Text = "Čo urobíš, keď sa stratíš v lese?",
                    Answers = new()
                    {
                        new() { Text = "Sadnem si pod strom a počkám.", Points = { [MaskType.Slama] = 2 } },
                        new() { Text = "Začnem kričať a možno si ma niekto všimne.", Points = { [MaskType.Turon] = 2 } },
                        new() { Text = "Snažím sa vrátiť po svojich stopách.", Points = { [MaskType.Medved] = 2 } },
                        new() { Text = "Orientujem sa podľa slnka, hľadám cestu späť.", Points = { [MaskType.Vodic] = 2 } },
                        new() { Text = "Stíšim sa, vnímam zvuky a čakám znamenie.", Points = { [MaskType.Luca] = 2 } },
                        new() { Text = "Rozplačem sa a čakám, kým ma niekto nájde.", Points = { [MaskType.NevestaZenich] = 2 } }
                    }
                },
                new()
                {
                    Text = "Čo spravíš, keď niekto poruší pravidlá?",
                    Answers = new()
                    {
                        new() { Text = "Tvárim sa, že som si nič nevšimol.", Points = { [MaskType.Slama] = 2 } },
                        new() { Text = "Začnem sa smiať, pretože pravidlá sú na to.", Points = { [MaskType.Turon] = 2 } },
                        new() { Text = "Nahnevám sa, ale nechám to tak.", Points = { [MaskType.Medved] = 2 } },
                        new() { Text = "Okamžite ho napomeniem.", Points = { [MaskType.Vodic] = 2 } },
                        new() { Text = "Poviem mu, aby si vstúpil do svedomia.", Points = { [MaskType.Luca] = 2 } },
                        new() { Text = "Myslím si, že to bol omyl, a odpustím mu.", Points = { [MaskType.NevestaZenich] = 2 } }
                    }
                },
                new()
                {
                    Text = "Ako reaguješ na to, keď sa niekto zraní alebo ochorie?",
                    Answers = new()
                    {
                        new() { Text = "Rýchlo pomôžem, hoci aj len jednoduchým gestom.", Points = { [MaskType.Slama] = 2 } },
                        new() { Text = "Spanikárim a zavolám všetkých z okolia.", Points = { [MaskType.Turon] = 2 } },
                        new() { Text = "Ponesiem ho na chrbte, ak treba.", Points = { [MaskType.Medved] = 2 } },
                        new() { Text = "Zavolám koho treba a zorganizujem pomoc.", Points = { [MaskType.Vodic] = 2 } },
                        new() { Text = "Pomodlím sa za neho.", Points = { [MaskType.Luca] = 2 } },
                        new() { Text = "Sedím pri posteli a držím ho za ruku.", Points = { [MaskType.NevestaZenich] = 2 } }
                    }
                },
                new()
                {
                    Text = "Ako reaguješ, keď ti niekto zruší plány na poslednú chvíľu?",
                    Answers = new()
                    {
                        new() { Text = "Nevadí, aspoň si upracem byt.", Points = { [MaskType.Slama] = 2 } },
                        new() { Text = "Hneď si nájdem iný program.", Points = { [MaskType.Turon] = 2 } },
                        new() { Text = "Teším sa a spím ďalej.", Points = { [MaskType.Medved] = 2 } },
                        new() { Text = "Napíšem si to do kalendára ako 'zlyhanie systému'.", Points = { [MaskType.Vodic] = 2 } },
                        new() { Text = "Vezmem to ako znamenie a využijem čas produktívne.", Points = { [MaskType.Luca] = 2 } },
                        new() { Text = "Snažím sa ho presvedčiť.", Points = { [MaskType.NevestaZenich] = 2 } }
                    }
                },
                new()
                {
                    Text = "Čo si dáš na jedenie po ťažkom dni?",
                    Answers = new()
                    {
                        new() { Text = "Obyčajnú večeru, chleba so šunkou.", Points = { [MaskType.Slama] = 2 } },
                        new() { Text = "Nezvyčajnú kombináciu – Feta s melónom.", Points = { [MaskType.Turon] = 2 } },
                        new() { Text = "Otvorím chladničku a zjem čo uvidím.", Points = { [MaskType.Medved] = 2 } },
                        new() { Text = "Presne 250g cestovín s pestom, bez odchýlky.", Points = { [MaskType.Vodic] = 2 } },
                        new() { Text = "Bylinkový čaj a bezlepkový koláčik.", Points = { [MaskType.Luca] = 2 } },
                        new() { Text = "Uvarím si niečo instafriendly.", Points = { [MaskType.NevestaZenich] = 2 } }
                    }
                },
                new()
                {
                    Text = "Tvoj najobľúbenejší typ videí na internete?",
                    Answers = new()
                    {
                        new() { Text = "DIY a remeselné videá.", Points = { [MaskType.Slama] = 2 } },
                        new() { Text = "Fail kompilácie a brainrot.", Points = { [MaskType.Turon] = 2 } },
                        new() { Text = "Oddychové zvuky prírody, ASMR.", Points = { [MaskType.Medved] = 2 } },
                        new() { Text = "Videá, z ktorých sa niečo naučím.", Points = { [MaskType.Vodic] = 2 } },
                        new() { Text = "Reiki, konšpiračné teórie, meditácie.", Points = { [MaskType.Luca] = 2 } },
                        new() { Text = "Vzťahové a sexuálne podcasty.", Points = { [MaskType.NevestaZenich] = 2 } }
                    }
                }
            };
        }
    }
}
