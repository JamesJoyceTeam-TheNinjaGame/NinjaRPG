namespace NinjaWorld
{
    using System;

    public static class RandomeEvilName
    {
        public static readonly string[] JediNames = new string[]
        {
            "Adi Gallia", "Akial", "Allynic E'Kles", "Amar Cros", "Andria", "Anoush Rahn", "Arias", "Astaal Vilbum", "Bela Kiwiiks", "Celeste Morne", "Chief Linguist", "Cilghal", "Clarin Karagan", "Dee-Lynn Cance", "Depa Billaba", "Dobe", "Dynaroth", "Felanil Baaks", "Genarra", "Ikrit", "Jolee Bindo", "Jorus C'baoth", "Jwartek", "Khaat Qiyn", "Khoveri", "Kibh Jeen", "Kit Fisto", "Klis Joo", "Maks Leem", "Mynnic", "Nomi Sunrider", "Ooroo", "Pradoc", "Qid Proko", "Qu Rahn", "Sabla-Mandibu", "Seenlu Kir", "Sen Udo-Mal", "Shaak Ti", "Shanji-vru", "Tensh Ly'alu", "Ter-Idi", "Tyneir Renz", "Vergere", "Wettle", "Xandyk", "Yarael Poof", "Ylenic It'kla"
        };

        public static readonly string[] RobotNames = new string[]
        {
            "Terminator", "Robocop", "Agent Smith", "Cylon Centurions", "Number One", "Number Two", "Number Three", "Number Four", "Number Five", "Number Six", "Number Seven", "Number Eight", "Galen Tyrol", "Tory Foster", "Samuel T. Anders", "Saul Tigh", "Ellen Tigh", "Optimus Prime", "Wheeljack", "Bumblebee", "Cliffjumper", "Prowl", "Jazz", "Sideswipe", "Ratchet", "Ironhide", "Hound", "Mirage", "Trailbreaker", "Sunstreaker", "Bluestreak", "Windcharger", "Grimlock", "Beachcomber", "Inferno", "Cosmos", "Omega Supreme", "Devcon", "Skids", "Alana", "Elita One", "Chromia "
        };

        public static readonly string[] AssasinNames = new string[]
        {
            "Jose Aldo", "Mirko 'Cro Cop'", "Rich Franklin", "Quinton 'Rampage' Jackson", "Wanderlei Silva", "Jon Jones", "Ken Shamrock", "Mauricio 'Shogun' Rua", "Royce Gracie", "Tito Ortiz", "Frank Shamrock", "Dan Henderson", "Vitor Belfort", "Takanori Gomi", "Fedor Emelianenko", "Antonio Rodrigo Nogueira ", "Chuck Liddell", "Kazushi Sakuraba", "Bas Rutten", "Randy Couture", "Mark Coleman", "Matt Hughes", "BJ Penn ", "Georges St. Pierre", "Anderson 'The Spider' Silva", "Alistair Overeem", "Andy Hug", "Badr Hari", "Branko Cikatić", "Ernesto Hoost", "Keijiro Maeda", "Mark Hunt", "Mighty Mo", "Peter Aerts", "Remy Bonjasky", "Semmy Schilt", "Kubrat Pulev", "Mike Tyson"
        };

        public static string RandomName(string[] names)
        {
            int random = Randomizer.Rand.Next(0, names.Length);

            return names[random];
        }
    }
}
