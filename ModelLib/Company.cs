namespace ModelLib;

public class Company
{
    public int CompanyId { get; set; }
    public string Name { get; set; }
    public Country Country { get; set; }
    public byte[] CountryFlag { get; set; } = File.ReadAllBytes("images/flags/nan.gif");
    public int Level { get; set; }
    public Company()
    {
        LoadCountryFlag();
    }
    private void LoadCountryFlag()
    {
        switch (this.Country)
        {
            case Country.USA:
                this.CountryFlag = File.ReadAllBytes("images/flags/usa.gif");
                break;
            case Country.Canada:
                this.CountryFlag = File.ReadAllBytes("images/flags/canada.gif");
                break;
            case Country.Brazil:
                this.CountryFlag = File.ReadAllBytes("images/flags/brazil.gif");
                break;
            case Country.Mexico:
                this.CountryFlag = File.ReadAllBytes("images/flags/mexico.gif");
                break;
            case Country.Argentina:
                this.CountryFlag = File.ReadAllBytes("images/flags/argentina.gif");
                break;
            case Country.China:
                this.CountryFlag = File.ReadAllBytes("images/flags/china.gif");
                break;
            case Country.Japan:
                this.CountryFlag = File.ReadAllBytes("images/flags/japan.gif");
                break;
            case Country.India:
                this.CountryFlag = File.ReadAllBytes("images/flags/india.gif");
                break;
            case Country.SouthKorea:
                this.CountryFlag = File.ReadAllBytes("images/flags/southkorea.gif");
                break;
            case Country.Australia:
                this.CountryFlag = File.ReadAllBytes("images/flags/australia.gif");
                break;
            case Country.Germany:
                this.CountryFlag = File.ReadAllBytes("images/flags/germany.gif");
                break;
            case Country.France:
                this.CountryFlag = File.ReadAllBytes("images/flags/france.gif");
                break;
            case Country.England:
                this.CountryFlag = File.ReadAllBytes("images/flags/england.gif");
                break;
            case Country.Italy:
                this.CountryFlag = File.ReadAllBytes("images/flags/italy.gif");
                break;
            case Country.Netherlands:
                this.CountryFlag = File.ReadAllBytes("images/flags/netherlands.gif");
                break;
            case Country.SouthAfrica:
                this.CountryFlag = File.ReadAllBytes("images/flags/southafrica.gif");
                break;
            case Country.Nigeria:
                this.CountryFlag = File.ReadAllBytes("images/flags/nigeria.gif");
                break;
            case Country.Egypt:
                this.CountryFlag = File.ReadAllBytes("images/flags/egypt.gif");
                break;
            case Country.Kenya:
                this.CountryFlag = File.ReadAllBytes("images/flags/kenya.gif");
                break;
            case Country.SaudiArabia:
                this.CountryFlag = File.ReadAllBytes("images/flags/saudiarabia.gif");
                break;
            case Country.Ukrain:
                this.CountryFlag = File.ReadAllBytes("images/flags/ukrain.gif");
                break;
            case Country.Turkey:
                this.CountryFlag = File.ReadAllBytes("images/flags/turkey.gif");
                break;
            case Country.UnitedArabEmirates:
                this.CountryFlag = File.ReadAllBytes("images/flags/uae.gif");
                break;
            case Country.Israel:
                this.CountryFlag = File.ReadAllBytes("images/flags/israel.gif");
                break;
            case Country.Singapore:
                this.CountryFlag = File.ReadAllBytes("images/flags/singapore.gif");
                break;
            case Country.Malaysia:
                this.CountryFlag = File.ReadAllBytes("images/flags/malaysia.gif");
                break;
            case Country.Indonesia:
                this.CountryFlag = File.ReadAllBytes("images/flags/indonesia.gif");
                break;
            case Country.NewZealand:
                this.CountryFlag = File.ReadAllBytes("images/flags/newzeland.gif");
                break;
            case Country.Colombia:
                this.CountryFlag = File.ReadAllBytes("images/flags/colombia.gif");
                break;
            case Country.Chile:
                this.CountryFlag = File.ReadAllBytes("images/flags/chile.gif");
                break;
            case Country.Peru:
                this.CountryFlag = File.ReadAllBytes("images/flags/peru.gif");
                break;
            case Country.Venezuela:
                this.CountryFlag = File.ReadAllBytes("images/flags/venezuela.gif");
                break;
            case Country.Iran:
                this.CountryFlag = File.ReadAllBytes("images/flags/iran.gif");
                break;
            default:
                this.CountryFlag = File.ReadAllBytes("images/flags/nan.gif");
                break;
        }
    }
}