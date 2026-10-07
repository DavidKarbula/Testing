using System;
using System.Collections.Generic;
using System.Text;

namespace Testing
{
    /// <summary>
    /// Třída pro správy seznamu uživatelů a výpočet věkových parametrů.
    /// </summary>
    public class SpravaUzivatelu
    {
        private List<string> uzivatele = new List<string>();

        /// <summary>
        /// Přidá nového uživatele do seznamu.
        /// </summary>
        /// <param name="jmeno">Jméno uživatele k přidání.</param>
        /// <exception cref="ArgumentException">Vyhozeno, pokud je jméno prázdné nebo obsahuje pouze bílé znaky.</exception>
        public void PridejUzivatele(string jmeno)
        {
            if (string.IsNullOrWhiteSpace(jmeno))
                throw new ArgumentException("Jméno je povinné.");
            uzivatele.Add(jmeno);
        }

        /// <summary>
        /// Odebere uživatele ze seznamu.
        /// </summary>
        /// <param name="jmeno">Jméno uživatele k odebrání.</param>
        /// <returns><c>true</c>, pokud byl uživatel nalezen a odebrán; jinak <c>false</c>.</returns>
        public bool OdeberUzivatele(string jmeno) => uzivatele.Remove(jmeno);

        /// <summary>
        /// Vrátí aktuální celkový počet registrovaných uživatelů.
        /// </summary>
        /// <returns>Počet uživatelů v seznamu.</returns>
        public int ZiskejPocetUzivatelu() => uzivatele.Count;

        /// <summary>
        /// Vymaže všechny uživatele ze seznamu.
        /// </summary>
        public void VymazVsechny() => uzivatele.Clear();

        /// <summary>
        /// Zjistí, zda se uživatel se zadaným jménem nachází v seznamu.
        /// </summary>
        /// <param name="jmeno">Hledané jméno.</param>
        /// <returns><c>true</c>, pokud uživatel existuje; jinak <c>false</c>.</returns>
        public bool ExistujeUzivatel(string jmeno) => uzivatele.Contains(jmeno);

        /// <summary>
        /// Vypočítá přesný věk v letech k určitému datu.
        /// </summary>
        /// <param name="datumNarozeni">Datum narození osoby.</param>
        /// <param name="aktualniDatum">Datum, ke kterému se věk počítá.</param>
        /// <returns>Dosažený věk v letech.</returns>
        public int SpocitejVek(DateTime datumNarozeni, DateTime aktualniDatum)
        {
            int vek = aktualniDatum.Year - datumNarozeni.Year;
            if (datumNarozeni.Date > aktualniDatum.AddYears(-vek)) vek--;
            return vek;
        }

        /// <summary>
        /// Ověří, zda dosažený věk odpovídá hranici plnoletosti (18 let).
        /// </summary>
        /// <param name="vek">Věk v letech.</param>
        /// <returns><c>true</c>, pokud je věk 18 nebo více; jinak <c>false</c>.</returns>
        public bool JePlnolety(int vek) => vek >= 18;

        /// <summary>
        /// Vrátí kopii aktuálního seznamu všech uživatelů.
        /// </summary>
        /// <returns>Nová instance <see cref="List{String}"/> obsahující jména uživatelů.</returns>
        public List<string> ZiskejVsechnyUzivatele() => new List<string>(uzivatele);

        /// <summary>
        /// Vyhledá uživatele, jejichž jméno začíná na zadanou předponu (bez ohledu na velikost písmen).
        /// </summary>
        /// <param name="predpona">Začátek jména pro vyhledávání.</param>
        /// <returns>Pole odpovídajících jmen.</returns>
        public string[] NajdiUzivateleDleZacatku(string predpona)
        {
            if (string.IsNullOrEmpty(predpona)) return new string[0];
            return uzivatele.Where(u => u.StartsWith(predpona, StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        /// <summary>
        /// Nahradí stávající seznam uživatelů novým polem uživatelů.
        /// </summary>
        /// <param name="noviUzivatele">Pole nových uživatelů. Pokud je <c>null</c>, seznam se vyprázdní.</param>
        public void NastavSeznam(string[] noviUzivatele)
        {
            uzivatele = noviUzivatele.ToList() ?? new List<string>();
        }
    }
}

