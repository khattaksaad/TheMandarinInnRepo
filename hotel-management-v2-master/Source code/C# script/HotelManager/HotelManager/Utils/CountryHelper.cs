using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Utils
{
    internal static class CountryHelper
    {
        /// <summary>
        /// Gets the list of countries
        /// </summary>
        /// <returns>Returns the list of countries </returns>
        public static List<string> GetCountriesList()
        {
            List<RegionInfo> countries = new List<RegionInfo>();
            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo country = new RegionInfo(culture.LCID);
                if (countries.Where(p => p.Name == country.Name).Count() == 0)
                    countries.Add(country);
            }

            return countries.OrderBy(p => p.EnglishName).Select(p=>p.EnglishName).ToList();
        }
    }
}
