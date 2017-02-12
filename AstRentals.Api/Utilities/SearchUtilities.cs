using System.Collections.Generic;
using System.Linq;
using AstRentals.Data.Entities;

namespace AstRentals.Api.Utilities
{
    public class SearchUtilities
    {
        public IEnumerable<Car> TextSearch(string searchText, IEnumerable<Car> allCars)
        {
            var initial = new List<IEnumerable<Car>>();

            string[] words = searchText.Split(null);

            var loopResults = new List<Car>();

            for (int i = 0; i < words.Length; i++)
            {
                loopResults = allCars.Where(c => words.Any(w =>
                    c.Make.ToLower() == words[i].ToLower() ||
                    c.Model.ToLower() == words[i].ToLower() ||
                    c.Year.ToString() == words[i] ||
                    c.Make.ToLower().Contains(words[i].ToLower()) ||
                    c.Model.ToLower().Contains(words[i].ToLower()))).ToList();

                initial.Add(loopResults.Distinct());
            }

            loopResults = initial.SelectMany(l => l).Distinct().ToList();


            var final = new List<Car>();


            if (words.Length == 1)
            {
                return loopResults.Distinct().ToList();
            }
            if (words.Length == 2)
            {
                foreach (var item in loopResults)
                {
                    for (int i = 0; i < words.Length - 1; i++)
                    {
                        if (item.Make == words[i] && item.Model == words[i + 1] ||
                            item.Model == words[i] && item.Make == words[i + 1] ||
                            item.Make == words[i] && item.Year.ToString() == words[i + 1] ||
                            item.Model == words[i] && item.Year.ToString() == words[i + 1] ||
                            item.Year.ToString() == words[i] && item.Make == words[i + 1] ||
                            item.Year.ToString() == words[i] && item.Model == words[i + 1])
                        {
                            final.Add(item);
                        }
                    }
                }
            }
            else if (words.Length >= 3)
            {
                foreach (var item in loopResults)
                {
                    for (int i = 0; i < words.Length - 2; i++)
                    {
                        if (item.Make == words[i] && item.Model == words[i + 1] && item.Year.ToString() == words[i + 2] ||
                            item.Model == words[i] && item.Make == words[i + 1] && item.Year.ToString() == words[i + 2] ||
                            item.Make == words[i] && item.Year.ToString() == words[i + 1] && item.Model == words[i + 2] ||
                            item.Model == words[i] && item.Year.ToString() == words[i + 1] && item.Make == words[i + 2] ||
                            item.Year.ToString() == words[i] && item.Make == words[i + 1] && item.Model == words[i + 2] ||
                            item.Year.ToString() == words[i] && item.Model == words[i + 1] && item.Make == words[i + 2])
                        {
                            final.Add(item);
                        }
                    }
                }
            }

            return final.Distinct().ToList();
        }

    }
}