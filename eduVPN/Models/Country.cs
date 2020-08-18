/*
    eduVPN - VPN for education and research

    Copyright: 2017-2020 The Commons Conservancy eduVPN Programme
    SPDX-License-Identifier: GPL-3.0+
*/

using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace eduVPN.Models
{
    /// <summary>
    /// Country
    /// </summary>
    public class Country : BindableBase
    {
        #region Properties

        /// <summary>
        /// Two-letter ISO 3166 country code
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { SetProperty(ref _code, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _code;

        /// <summary>
        /// All known countries with English and local names
        /// </summary>
        public static Dictionary<string, object> Countries
        {
            get => _countries;
        }

        private static Dictionary<string, object> _countries = new Dictionary<string, object>()
        {
            { "AD", new Dictionary<string, object>() {
                { "ca", "Andorra" },
                { "en", "Andorra" }
            }},
            { "AE", new Dictionary<string, object>() {
                { "ar", "دولة الإمارات العربيّة المتّحدة" },
                { "en", "United Arab Emirates" }
            }},
            { "AF", new Dictionary<string, object>() {
                { "en", "Afghanistan" },
                { "fa", "د افغانستان اسلامي دولتدولت اسلامی افغانستان" },
                { "ps", "جمهوری اسلامی افغانستان" }
            }},
            { "AG", new Dictionary<string, object>() {
                { "en", "Antigua and Barbuda" }
            }},
            { "AI", new Dictionary<string, object>() {
                { "en", "Anguilla" }
            }},
            { "AL", new Dictionary<string, object>() {
                { "en", "Albania" },
                { "sq", "Shqipëria" }
            }},
            { "AM", new Dictionary<string, object>() {
                { "en", "Armenia" },
                { "hy", "Հայաստան" }
            }},
            { "AO", new Dictionary<string, object>() {
                { "en", "Angola" },
                { "pt", "Angola" }
            }},
            { "AQ", new Dictionary<string, object>() {
                { "en", "Antarctica" },
                { "es", "Antártico" },
                { "fr", "Antarctique" },
                { "ru", "Антарктике" }
            }},
            { "AR", new Dictionary<string, object>() {
                { "en", "Argentina" },
                { "es", "Argentina" }
            }},
            { "AS", new Dictionary<string, object>() {
                { "en", "American Samoa" }
            }},
            { "AT", new Dictionary<string, object>() {
                { "de", "Österreich" },
                { "en", "Austria" }
            }},
            { "AU", new Dictionary<string, object>() {
                { "da", "Australien" },
                { "en", "Australia" },
                { "nb", "Australia" },
                { "nl", "Australië" }
            }},
            { "AW", new Dictionary<string, object>() {
                { "en", "Aruba" },
                { "nl", "Aruba" }
            }},
            { "AX", new Dictionary<string, object>() {
                { "en", "Aland Islands" },
                { "sv", "Åland" }
            }},
            { "AZ", new Dictionary<string, object>() {
                { "az", "Azərbaycan" },
                { "en", "Azerbaijan" }
            }},
            { "BA", new Dictionary<string, object>() {
                { "bs", "Bosna i Hercegovina" },
                { "en", "Bosnia and Herzegovina" }
            }},
            { "BB", new Dictionary<string, object>() {
                { "en", "Barbados" }
            }},
            { "BD", new Dictionary<string, object>() {
                { "bn", "গণপ্রজাতন্ত্রী বাংলাদেশ" },
                { "en", "Bangladesh" }
            }},
            { "BE", new Dictionary<string, object>() {
                { "de", "Belgien" },
                { "en", "Belgium" },
                { "fr", "Belgique" },
                { "nl", "België" }
            }},
            { "BF", new Dictionary<string, object>() {
                { "en", "Burkina Faso" },
                { "fr", "Burkina Faso" }
            }},
            { "BG", new Dictionary<string, object>() {
                { "bg", "България" },
                { "en", "Bulgaria" }
            }},
            { "BH", new Dictionary<string, object>() {
                { "ar", "البحرين" },
                { "en", "Bahrain" }
            }},
            { "BI", new Dictionary<string, object>() {
                { "en", "Burundi" },
                { "fr", "Burundi" }
            }},
            { "BJ", new Dictionary<string, object>() {
                { "en", "Benin" },
                { "fr", "Bénin" }
            }},
            { "BL", new Dictionary<string, object>() {
                { "en", "Saint-Barthélemy" },
                { "fr", "Saint-Barthélemy" }
            }},
            { "BM", new Dictionary<string, object>() {
                { "en", "Bermuda" }
            }},
            { "BN", new Dictionary<string, object>() {
                { "en", "Brunei Darussalam" },
                { "ms", "Brunei Darussalam" }
            }},
            { "BO", new Dictionary<string, object>() {
                { "ay", "Wuliwya" },
                { "en", "Bolivia" },
                { "es", "Bolivia" },
                { "gn", "Volívia" },
                { "qu", "Bulibiya" }
            }},
            { "BQ", new Dictionary<string, object>() {
                { "en", "Caribbean Netherlands" },
                { "nl", "Caribisch Nederland" }
            }},
            { "BR", new Dictionary<string, object>() {
                { "en", "Brazil" },
                { "pt", "Brasil" }
            }},
            { "BS", new Dictionary<string, object>() {
                { "en", "Bahamas" }
            }},
            { "BT", new Dictionary<string, object>() {
                { "dz", "འབྲུག་ཡུལ" },
                { "en", "Bhutan" }
            }},
            { "BV", new Dictionary<string, object>() {
                { "en", "Bouvet Island" },
                { "no", "Bouvetøya" }
            }},
            { "BW", new Dictionary<string, object>() {
                { "en", "Botswana" }
            }},
            { "BY", new Dictionary<string, object>() {
                { "be", "Беларусь" },
                { "en", "Belarus" }
            }},
            { "BZ", new Dictionary<string, object>() {
                { "en", "Belize" }
            }},
            { "CA", new Dictionary<string, object>() {
                { "en", "Canada" }
            }},
            { "CC", new Dictionary<string, object>() {
                { "en", "Cocos (Keeling) Islands" }
            }},
            { "CD", new Dictionary<string, object>() {
                { "en", "Democratic Republic of the Congo (Congo-Kinshasa, former Zaire)" },
                { "fr", "République Démocratique du Congo" }
            }},
            { "CF", new Dictionary<string, object>() {
                { "en", "Central African Republic" },
                { "fr", "République centrafricaine" },
                { "sg", "Ködörösêse tî Bêafrîka" }
            }},
            { "CG", new Dictionary<string, object>() {
                { "en", "Republic of the Congo (Congo-Brazzaville)" },
                { "fr", "République du Congo" }
            }},
            { "CH", new Dictionary<string, object>() {
                { "de", "Schweiz" },
                { "en", "Switzerland" },
                { "fr", "Suisse" },
                { "it", "Svizzera" },
                { "rm", "Svizra" }
            }},
            { "CI", new Dictionary<string, object>() {
                { "en", "Ivory Coast" },
                { "fr", "Côte d'Ivoire" }
            }},
            { "CK", new Dictionary<string, object>() {
                { "en", "Cook Islands" },
                { "rar", "Kūki ʻĀirani" }
            }},
            { "CL", new Dictionary<string, object>() {
                { "en", "Chile" },
                { "es", "Chile" }
            }},
            { "CM", new Dictionary<string, object>() {
                { "en", "Cameroon" },
                { "fr", "Cameroun" }
            }},
            { "CN", new Dictionary<string, object>() {
                { "en", "China" },
                { "zh-hans", "中国" }
            }},
            { "CO", new Dictionary<string, object>() {
                { "en", "Colombia" },
                { "es", "Colombia" }
            }},
            { "CR", new Dictionary<string, object>() {
                { "en", "Costa Rica" },
                { "es", "Costa Rica" }
            }},
            { "CU", new Dictionary<string, object>() {
                { "en", "Cuba" },
                { "es", "Cuba" }
            }},
            { "CV", new Dictionary<string, object>() {
                { "en", "Cabo Verde" },
                { "pt", "Cabo Verde" }
            }},
            { "CW", new Dictionary<string, object>() {
                { "en", "Curaçao" },
                { "nl", "Curaçao" }
            }},
            { "CX", new Dictionary<string, object>() {
                { "en", "Christmas Island" }
            }},
            { "CY", new Dictionary<string, object>() {
                { "el", "Κύπρος" },
                { "en", "Cyprus" },
                { "tr", "Kibris" }
            }},
            { "CZ", new Dictionary<string, object>() {
                { "cs", "Česká republika" },
                { "en", "Czech Republic" }
            }},
            { "DE", new Dictionary<string, object>() {
                { "de", "Deutschland" },
                { "en", "Germany" },
                { "nb", "Tyskland" },
                { "nl", "Duitsland" }
            }},
            { "DJ", new Dictionary<string, object>() {
                { "aa", "Gabuutih" },
                { "ar", "جيبوتي" },
                { "en", "Djibouti" },
                { "fr", "Djibouti" },
                { "so", "Jabuuti" }
            }},
            { "DK", new Dictionary<string, object>() {
                { "da", "Danmark" },
                { "en", "Denmark" },
                { "nb", "Danmark" },
                { "nl", "Denemarken" }
            }},
            { "DM", new Dictionary<string, object>() {
                { "en", "Dominica" }
            }},
            { "DO", new Dictionary<string, object>() {
                { "en", "Dominican Republic" },
                { "es", "República Dominicana" }
            }},
            { "DZ", new Dictionary<string, object>() {
                { "ar", "الجزائر" },
                { "en", "Algeria" }
            }},
            { "EC", new Dictionary<string, object>() {
                { "en", "Ecuador" },
                { "es", "Ecuador" }
            }},
            { "EE", new Dictionary<string, object>() {
                { "en", "Estonia" },
                { "et", "Eesti" }
            }},
            { "EG", new Dictionary<string, object>() {
                { "ar", "مصر" },
                { "en", "Egypt" }
            }},
            { "EH", new Dictionary<string, object>() {
                { "ar", "Sahara Occidental" },
                { "en", "Western Sahara" }
            }},
            { "ER", new Dictionary<string, object>() {
                { "ar", "إرتريا" },
                { "en", "Eritrea" },
                { "ti", "ኤርትራ" }
            }},
            { "ES", new Dictionary<string, object>() {
                { "ast", "España" },
                { "en", "Spain" }
            }},
            { "ET", new Dictionary<string, object>() {
                { "am", "ኢትዮጵያ" },
                { "en", "Ethiopia" },
                { "om", "Itoophiyaa" }
            }},
            { "FI", new Dictionary<string, object>() {
                { "en", "Finland" },
                { "fi", "Suomi" },
                { "nb", "Finland" },
                { "nl", "Finland" }
            }},
            { "FJ", new Dictionary<string, object>() {
                { "en", "Fiji" }
            }},
            { "FK", new Dictionary<string, object>() {
                { "en", "Falkland Islands" }
            }},
            { "FM", new Dictionary<string, object>() {
                { "en", "Micronesia" }
            }},
            { "FO", new Dictionary<string, object>() {
                { "da", "Færøerne" },
                { "en", "Faroe Islands" },
                { "fo", "Føroyar" }
            }},
            { "FR", new Dictionary<string, object>() {
                { "en", "France" },
                { "fr", "France" },
                { "nb", "Frankrike" },
                { "nl", "Frankrijk" }
            }},
            { "GA", new Dictionary<string, object>() {
                { "en", "Gabon" },
                { "fr", "Gabon" }
            }},
            { "GB", new Dictionary<string, object>() {
                { "en", "United Kingdom" }
            }},
            { "GD", new Dictionary<string, object>() {
                { "en", "Grenada" }
            }},
            { "GE", new Dictionary<string, object>() {
                { "en", "Georgia" },
                { "ka", "საქართველო" }
            }},
            { "GF", new Dictionary<string, object>() {
                { "en", "French Guiana" },
                { "fr", "Guyane française" }
            }},
            { "GG", new Dictionary<string, object>() {
                { "en", "Guernsey" }
            }},
            { "GH", new Dictionary<string, object>() {
                { "en", "Ghana" }
            }},
            { "GI", new Dictionary<string, object>() {
                { "en", "Gibraltar" }
            }},
            { "GL", new Dictionary<string, object>() {
                { "da", "Grønland" },
                { "en", "Greenland" },
                { "kl", "Kalaallit Nunaat" }
            }},
            { "GM", new Dictionary<string, object>() {
                { "en", "The Gambia" }
            }},
            { "GN", new Dictionary<string, object>() {
                { "en", "Guinea" },
                { "fr", "Guinée" }
            }},
            { "GP", new Dictionary<string, object>() {
                { "en", "Guadeloupe" },
                { "fr", "Guadeloupe" }
            }},
            { "GQ", new Dictionary<string, object>() {
                { "en", "Equatorial Guinea" },
                { "es", "Guiena ecuatorial" },
                { "fr", "Guinée équatoriale" },
                { "pt", "Guiné Equatorial" }
            }},
            { "GR", new Dictionary<string, object>() {
                { "el", "Ελλάδα" },
                { "en", "Greece" }
            }},
            { "GS", new Dictionary<string, object>() {
                { "en", "South Georgia and the South Sandwich Islands" }
            }},
            { "GT", new Dictionary<string, object>() {
                { "en", "Guatemala" },
                { "es", "Guatemala" }
            }},
            { "GU", new Dictionary<string, object>() {
                { "ch", "Guåhån" },
                { "en", "Guam" }
            }},
            { "GW", new Dictionary<string, object>() {
                { "en", "Guinea Bissau" },
                { "pt", "Guiné-Bissau" }
            }},
            { "GY", new Dictionary<string, object>() {
                { "en", "Guyana" }
            }},
            { "HK", new Dictionary<string, object>() {
                { "en", "Hong Kong" },
                { "zh-hant", "香港" }
            }},
            { "HM", new Dictionary<string, object>() {
                { "en", "Heard Island and McDonald Islands" }
            }},
            { "HN", new Dictionary<string, object>() {
                { "en", "Honduras" },
                { "es", "Honduras" }
            }},
            { "HR", new Dictionary<string, object>() {
                { "en", "Croatia" },
                { "hr", "Hrvatska" }
            }},
            { "HT", new Dictionary<string, object>() {
                { "en", "Haiti" },
                { "fr", "Haïti" },
                { "ht", "Ayiti" }
            }},
            { "HU", new Dictionary<string, object>() {
                { "en", "Hungary" },
                { "hu", "Magyarország" }
            }},
            { "ID", new Dictionary<string, object>() {
                { "en", "Indonesia" },
                { "id", "Indonesia" }
            }},
            { "IE", new Dictionary<string, object>() {
                { "en", "Ireland" },
                { "ga", "Éire" }
            }},
            { "IL", new Dictionary<string, object>() {
                { "en", "Israel" },
                { "he", "ישראל" }
            }},
            { "IM", new Dictionary<string, object>() {
                { "en", "Isle of Man" }
            }},
            { "IN", new Dictionary<string, object>() {
                { "en", "India" },
                { "hi", "भारत" }
            }},
            { "IO", new Dictionary<string, object>() {
                { "en", "British Indian Ocean Territory" }
            }},
            { "IQ", new Dictionary<string, object>() {
                { "ar", "العراق" },
                { "en", "Iraq" },
                { "ku", "Iraq" }
            }},
            { "IR", new Dictionary<string, object>() {
                { "en", "Iran" },
                { "fa", "ایران" }
            }},
            { "IS", new Dictionary<string, object>() {
                { "en", "Iceland" },
                { "is", "Ísland" }
            }},
            { "IT", new Dictionary<string, object>() {
                { "en", "Italy" },
                { "it", "Italia" }
            }},
            { "JE", new Dictionary<string, object>() {
                { "en", "Jersey" }
            }},
            { "JM", new Dictionary<string, object>() {
                { "en", "Jamaica" }
            }},
            { "JO", new Dictionary<string, object>() {
                { "ar", "الأُرْدُن" },
                { "en", "Jordan" }
            }},
            { "JP", new Dictionary<string, object>() {
                { "en", "Japan" },
                { "ja", "日本" }
            }},
            { "KE", new Dictionary<string, object>() {
                { "en", "Kenya" },
                { "sw", "Kenya" }
            }},
            { "KG", new Dictionary<string, object>() {
                { "en", "Kyrgyzstan" },
                { "ky", "Кыргызстан" },
                { "ru", "Киргизия" }
            }},
            { "KH", new Dictionary<string, object>() {
                { "en", "Cambodia" },
                { "km", "កម្ពុជា" }
            }},
            { "KI", new Dictionary<string, object>() {
                { "en", "Kiribati" }
            }},
            { "KM", new Dictionary<string, object>() {
                { "ar", "ﺍﻟﻘﻤﺮي" },
                { "en", "Comores" },
                { "fr", "Comores" },
                { "sw", "Komori" }
            }},
            { "KN", new Dictionary<string, object>() {
                { "en", "Saint Kitts and Nevis" }
            }},
            { "KP", new Dictionary<string, object>() {
                { "en", "North Korea" },
                { "ko", "북조선" }
            }},
            { "KR", new Dictionary<string, object>() {
                { "en", "South Korea" },
                { "ko", "대한민국" }
            }},
            { "KW", new Dictionary<string, object>() {
                { "ar", "الكويت" },
                { "en", "Kuwait" }
            }},
            { "KY", new Dictionary<string, object>() {
                { "en", "Cayman Islands" }
            }},
            { "KZ", new Dictionary<string, object>() {
                { "en", "Kazakhstan" },
                { "kk", "Қазақстан" },
                { "ru", "Казахстан" }
            }},
            { "LA", new Dictionary<string, object>() {
                { "en", "Laos" },
                { "lo", "ປະຊາຊົນລາວ" }
            }},
            { "LB", new Dictionary<string, object>() {
                { "ar", "لبنان" },
                { "en", "Lebanon" },
                { "fr", "Liban" }
            }},
            { "LC", new Dictionary<string, object>() {
                { "en", "Saint Lucia" }
            }},
            { "LI", new Dictionary<string, object>() {
                { "de", "Liechtenstein" },
                { "en", "Liechtenstein" }
            }},
            { "LK", new Dictionary<string, object>() {
                { "en", "Sri Lanka" },
                { "nb", "Sri Lanka" },
                { "nl", "Sri Lanka" },
                { "si", "ශ්‍රී ලංකා" },
                { "ta", "இலங்கை" }
            }},
            { "LR", new Dictionary<string, object>() {
                { "en", "Liberia" }
            }},
            { "LS", new Dictionary<string, object>() {
                { "en", "Lesotho" }
            }},
            { "LT", new Dictionary<string, object>() {
                { "en", "Lithuania" },
                { "lt", "Lietuva" }
            }},
            { "LU", new Dictionary<string, object>() {
                { "de", "Luxemburg" },
                { "en", "Luxembourg" },
                { "fr", "Luxembourg" },
                { "lb", "Lëtzebuerg" }
            }},
            { "LV", new Dictionary<string, object>() {
                { "en", "Latvia" },
                { "lv", "Latvija" }
            }},
            { "LY", new Dictionary<string, object>() {
                { "ar", "ليبيا" },
                { "en", "Libya" }
            }},
            { "MA", new Dictionary<string, object>() {
                { "ar", "المغرب" },
                { "en", "Morocco" },
                { "fr", "Maroc" },
                { "nb", "Marokko" },
                { "nl", "Marokko" },
                { "zgh", "ⵍⵎⵖⵔⵉⴱ" }
            }},
            { "MC", new Dictionary<string, object>() {
                { "en", "Monaco" },
                { "fr", "Monaco" }
            }},
            { "MD", new Dictionary<string, object>() {
                { "en", "Moldova" },
                { "ro", "Moldova" },
                { "ru", "Молдавия" }
            }},
            { "ME", new Dictionary<string, object>() {
                { "en", "Montenegro" },
                { "sr", "Црна Гора" },
                { "srp", "Crna Gora" }
            }},
            { "MF", new Dictionary<string, object>() {
                { "en", "Saint Martin (French part)" },
                { "fr", "Saint-Martin" }
            }},
            { "MG", new Dictionary<string, object>() {
                { "en", "Madagascar" },
                { "fr", "Madagascar" },
                { "mg", "Madagasikara" }
            }},
            { "MH", new Dictionary<string, object>() {
                { "en", "Marshall Islands" }
            }},
            { "MK", new Dictionary<string, object>() {
                { "en", "Macedonia (Former Yugoslav Republic of)" },
                { "mk", "Македонија" }
            }},
            { "ML", new Dictionary<string, object>() {
                { "en", "Mali" },
                { "fr", "Mali" }
            }},
            { "MM", new Dictionary<string, object>() {
                { "en", "Myanmar" },
                { "my", "မြန်မာ" }
            }},
            { "MN", new Dictionary<string, object>() {
                { "en", "Mongolia" },
                { "mn", "Монгол Улс" }
            }},
            { "MO", new Dictionary<string, object>() {
                { "en", "Macao (SAR of China)" },
                { "pt", "Macau" },
                { "zh-hant", "澳門" }
            }},
            { "MP", new Dictionary<string, object>() {
                { "en", "Northern Mariana Islands" }
            }},
            { "MQ", new Dictionary<string, object>() {
                { "en", "Martinique" },
                { "fr", "Martinique" }
            }},
            { "MR", new Dictionary<string, object>() {
                { "ar", "موريتانيا" },
                { "en", "Mauritania" },
                { "fr", "Mauritanie" }
            }},
            { "MS", new Dictionary<string, object>() {
                { "en", "Montserrat" }
            }},
            { "MT", new Dictionary<string, object>() {
                { "en", "Malta" },
                { "mt", "Malta" }
            }},
            { "MU", new Dictionary<string, object>() {
                { "en", "Mauritius" },
                { "fr", "Mauritius" },
                { "mfe", "Maurice" }
            }},
            { "MV", new Dictionary<string, object>() {
                { "en", "Maldives" }
            }},
            { "MW", new Dictionary<string, object>() {
                { "en", "Malawi" }
            }},
            { "MX", new Dictionary<string, object>() {
                { "en", "Mexico" },
                { "es", "México" }
            }},
            { "MY", new Dictionary<string, object>() {
                { "en", "Malaysia" }
            }},
            { "MZ", new Dictionary<string, object>() {
                { "en", "Mozambique" },
                { "pt", "Mozambique" }
            }},
            { "NA", new Dictionary<string, object>() {
                { "en", "Namibia" }
            }},
            { "NC", new Dictionary<string, object>() {
                { "en", "New Caledonia" },
                { "fr", "Nouvelle-Calédonie" }
            }},
            { "NE", new Dictionary<string, object>() {
                { "en", "Niger" },
                { "fr", "Niger" }
            }},
            { "NF", new Dictionary<string, object>() {
                { "en", "Norfolk Island" }
            }},
            { "NG", new Dictionary<string, object>() {
                { "en", "Nigeria" }
            }},
            { "NI", new Dictionary<string, object>() {
                { "en", "Nicaragua" },
                { "es", "Nicaragua" }
            }},
            { "NL", new Dictionary<string, object>() {
                { "da", "Holland" },
                { "en", "The Netherlands" },
                { "nb", "Nederland" },
                { "nl", "Nederland" }
            }},
            { "NO", new Dictionary<string, object>() {
                { "da", "Norge" },
                { "en", "Norway" },
                { "nb", "Norge" },
                { "nl", "Noorwegen" },
                { "nn", "Noreg" }
            }},
            { "NP", new Dictionary<string, object>() {
                { "en", "Nepal" }
            }},
            { "NR", new Dictionary<string, object>() {
                { "en", "Nauru" },
                { "na", "Nauru" }
            }},
            { "NU", new Dictionary<string, object>() {
                { "en", "Niue" },
                { "niu", "Niue" }
            }},
            { "NZ", new Dictionary<string, object>() {
                { "en", "New Zealand" },
                { "mi", "New Zealand" }
            }},
            { "OM", new Dictionary<string, object>() {
                { "ar", "سلطنة عُمان" },
                { "en", "Oman" }
            }},
            { "PA", new Dictionary<string, object>() {
                { "en", "Panama" },
                { "es", "Panama" }
            }},
            { "PE", new Dictionary<string, object>() {
                { "en", "Peru" },
                { "es", "Perú" }
            }},
            { "PF", new Dictionary<string, object>() {
                { "en", "French Polynesia" },
                { "fr", "Polynésie française" }
            }},
            { "PG", new Dictionary<string, object>() {
                { "en", "Papua New Guinea" }
            }},
            { "PH", new Dictionary<string, object>() {
                { "en", "Philippines" }
            }},
            { "PK", new Dictionary<string, object>() {
                { "en", "Pakistan" },
                { "nb", "Pakistan" },
                { "nl", "Pakistan" },
                { "ur", "پاکستان" }
            }},
            { "PL", new Dictionary<string, object>() {
                { "en", "Poland" },
                { "pl", "Polska" }
            }},
            { "PM", new Dictionary<string, object>() {
                { "en", "Saint Pierre and Miquelon" },
                { "fr", "Saint-Pierre-et-Miquelon" }
            }},
            { "PN", new Dictionary<string, object>() {
                { "en", "Pitcairn" }
            }},
            { "PR", new Dictionary<string, object>() {
                { "en", "Puerto Rico" },
                { "es", "Puerto Rico" }
            }},
            { "PS", new Dictionary<string, object>() {
                { "ar", "Palestinian Territory" },
                { "en", "Palestinian Territory" }
            }},
            { "PT", new Dictionary<string, object>() {
                { "en", "Portugal" },
                { "pt", "Portugal" }
            }},
            { "PW", new Dictionary<string, object>() {
                { "en", "Palau" }
            }},
            { "PY", new Dictionary<string, object>() {
                { "en", "Paraguay" },
                { "es", "Paraguay" }
            }},
            { "QA", new Dictionary<string, object>() {
                { "ar", "قطر" },
                { "en", "Qatar" }
            }},
            { "RE", new Dictionary<string, object>() {
                { "en", "Reunion" },
                { "fr", "La Réunion" }
            }},
            { "RO", new Dictionary<string, object>() {
                { "en", "Romania" },
                { "ro", "România" }
            }},
            { "RS", new Dictionary<string, object>() {
                { "en", "Serbia" },
                { "sr", "Србија" }
            }},
            { "RU", new Dictionary<string, object>() {
                { "en", "Russia" },
                { "ru", "Россия" }
            }},
            { "RW", new Dictionary<string, object>() {
                { "en", "Rwanda" },
                { "rw", "Rwanda" }
            }},
            { "SA", new Dictionary<string, object>() {
                { "ar", "السعودية" },
                { "en", "Saudi Arabia" }
            }},
            { "SB", new Dictionary<string, object>() {
                { "en", "Solomon Islands" }
            }},
            { "SC", new Dictionary<string, object>() {
                { "en", "Seychelles" },
                { "fr", "Seychelles" }
            }},
            { "SD", new Dictionary<string, object>() {
                { "ar", "السودان" },
                { "en", "Sudan" }
            }},
            { "SE", new Dictionary<string, object>() {
                { "en", "Sweden" },
                { "sv", "Sverige" }
            }},
            { "SG", new Dictionary<string, object>() {
                { "en", "Singapore" },
                { "zh-hans", "Singapore" }
            }},
            { "SH", new Dictionary<string, object>() {
                { "en", "Saint Helena" }
            }},
            { "SI", new Dictionary<string, object>() {
                { "en", "Slovenia" },
                { "sl", "Slovenija" }
            }},
            { "SJ", new Dictionary<string, object>() {
                { "en", "Svalbard and Jan Mayen" },
                { "no", "Svalbard and Jan Mayen" }
            }},
            { "SK", new Dictionary<string, object>() {
                { "en", "Slovakia" },
                { "sk", "Slovensko" }
            }},
            { "SL", new Dictionary<string, object>() {
                { "en", "Sierra Leone" }
            }},
            { "SM", new Dictionary<string, object>() {
                { "en", "San Marino" },
                { "it", "San Marino" }
            }},
            { "SN", new Dictionary<string, object>() {
                { "en", "Sénégal" },
                { "fr", "Sénégal" }
            }},
            { "SO", new Dictionary<string, object>() {
                { "ar", "الصومال" },
                { "en", "Somalia" },
                { "so", "Somalia" }
            }},
            { "SR", new Dictionary<string, object>() {
                { "en", "Suriname" },
                { "nl", "Suriname" }
            }},
            { "SS", new Dictionary<string, object>() {
                { "en", "South Sudan" }
            }},
            { "ST", new Dictionary<string, object>() {
                { "en", "São Tomé and Príncipe" },
                { "pt", "São Tomé e Príncipe" }
            }},
            { "SV", new Dictionary<string, object>() {
                { "en", "El Salvador" },
                { "es", "El Salvador" }
            }},
            { "SX", new Dictionary<string, object>() {
                { "en", "Saint Martin (Dutch part)" },
                { "nl", "Sint Maarten" }
            }},
            { "SY", new Dictionary<string, object>() {
                { "ar", "سوريا" },
                { "en", "Syria" }
            }},
            { "SZ", new Dictionary<string, object>() {
                { "en", "Swaziland" }
            }},
            { "TC", new Dictionary<string, object>() {
                { "en", "Turks and Caicos Islands" }
            }},
            { "TD", new Dictionary<string, object>() {
                { "ar", "تشاد" },
                { "en", "Chad" },
                { "fr", "Tchad" }
            }},
            { "TF", new Dictionary<string, object>() {
                { "en", "French Southern and Antarctic Lands" },
                { "fr", "Terres australes et antarctiques françaises" }
            }},
            { "TG", new Dictionary<string, object>() {
                { "en", "Togo" },
                { "fr", "Togo" }
            }},
            { "TH", new Dictionary<string, object>() {
                { "en", "Thailand" },
                { "th", "ประเทศไทย" }
            }},
            { "TJ", new Dictionary<string, object>() {
                { "en", "Tajikistan" }
            }},
            { "TK", new Dictionary<string, object>() {
                { "en", "Tokelau" },
                { "tkl", "Tokelau" }
            }},
            { "TL", new Dictionary<string, object>() {
                { "en", "Timor-Leste" },
                { "pt", "Timor-Leste" },
                { "tet", "Timor Lorosa'e" }
            }},
            { "TM", new Dictionary<string, object>() {
                { "en", "Turkmenistan" },
                { "tk", "Türkmenistan" }
            }},
            { "TN", new Dictionary<string, object>() {
                { "ar", "تونس" },
                { "en", "Tunisia" },
                { "fr", "Tunisie" }
            }},
            { "TO", new Dictionary<string, object>() {
                { "en", "Tonga" }
            }},
            { "TR", new Dictionary<string, object>() {
                { "en", "Turkey" },
                { "tr", "Türkiye" }
            }},
            { "TT", new Dictionary<string, object>() {
                { "en", "Trinidad and Tobago" }
            }},
            { "TV", new Dictionary<string, object>() {
                { "en", "Tuvalu" }
            }},
            { "TW", new Dictionary<string, object>() {
                { "en", "Taiwan" },
                { "zh-hant", "Taiwan" }
            }},
            { "TZ", new Dictionary<string, object>() {
                { "en", "Tanzania" },
                { "sw", "Tanzania" }
            }},
            { "UA", new Dictionary<string, object>() {
                { "en", "Ukraine" },
                { "nb", "Ukraina" },
                { "nl", "Oekraïne" },
                { "uk", "Україна" }
            }},
            { "UG", new Dictionary<string, object>() {
                { "en", "Uganda" },
                { "nb", "Uganda" },
                { "nl", "Oeganda" }
            }},
            { "UM", new Dictionary<string, object>() {
                { "en", "United States Minor Outlying Islands" }
            }},
            { "US", new Dictionary<string, object>() {
                { "en", "United States of America" }
            }},
            { "UY", new Dictionary<string, object>() {
                { "en", "Uruguay" },
                { "es", "Uruguay" }
            }},
            { "UZ", new Dictionary<string, object>() {
                { "en", "Uzbekistan" }
            }},
            { "VA", new Dictionary<string, object>() {
                { "en", "City of the Vatican" },
                { "it", "Città del Vaticano" }
            }},
            { "VC", new Dictionary<string, object>() {
                { "en", "Saint Vincent and the Grenadines" }
            }},
            { "VE", new Dictionary<string, object>() {
                { "en", "Venezuela" },
                { "es", "Venezuela" }
            }},
            { "VG", new Dictionary<string, object>() {
                { "en", "British Virgin Islands" }
            }},
            { "VI", new Dictionary<string, object>() {
                { "en", "United States Virgin Islands" }
            }},
            { "VN", new Dictionary<string, object>() {
                { "en", "Vietnam" },
                { "vi", "Việt Nam" }
            }},
            { "VU", new Dictionary<string, object>() {
                { "bi", "Vanuatu" },
                { "en", "Vanuatu" }
            }},
            { "WF", new Dictionary<string, object>() {
                { "en", "Wallis and Futuna" },
                { "fr", "Wallis-et-Futuna" }
            }},
            { "WS", new Dictionary<string, object>() {
                { "en", "Samoa" },
                { "sm", "Samoa" }
            }},
            { "YE", new Dictionary<string, object>() {
                { "ar", "اليَمَن" },
                { "en", "Yemen" }
            }},
            { "YT", new Dictionary<string, object>() {
                { "en", "Mayotte" },
                { "fr", "Mayotte" }
            }},
            { "ZA", new Dictionary<string, object>() {
                { "en", "South Africa" }
            }},
            { "ZM", new Dictionary<string, object>() {
                { "en", "Zambia" }
            }},
            { "ZW", new Dictionary<string, object>() {
                { "en", "Zimbabwe" }
            } }
        };

        #endregion

        #region Constructors

        /// <summary>
        /// Create a country
        /// </summary>
        /// <param name="code">Two-letter ISO 3166 country code</param>
        public Country(string code)
        {
            _code = code;
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public override string ToString()
        {
            // Some countries (e.g. AQ - Antarctica) are not defined in .NET.
            try
            {
                return new RegionInfo(_code).DisplayName;
            }
            catch (ArgumentException)
            {
                return eduJSON.Parser.GetLocalizedValue(Countries, _code, out string country) ? country : _code;
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = obj as Country;
            if (!_code.Equals(other._code))
                return false;

            return true;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return _code.GetHashCode();
        }

        #endregion
    }
}
