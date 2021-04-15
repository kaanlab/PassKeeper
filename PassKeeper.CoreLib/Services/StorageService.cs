using PassKeeper.CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassKeeper.CoreLib.Services
{
    public class StorageService
    {
        public IEnumerable<Cadet> GetCadets() => new[]
        {
            new Cadet { FirstName = "Кирилл", MiddleName="Алексеевич", LastName="Брянцев", Login="brancevka", Password="32DrvcBrvs", Passphrase="32 Заношенных Шинели"},
            new Cadet { FirstName = "Леонид", MiddleName="Сергеевич", LastName="Петров", Login="petrovls", Password="77OvgrZrtu", Passphrase="77 Нелепых Прачки"}
        };
    }
}
