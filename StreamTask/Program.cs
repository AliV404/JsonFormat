using Newtonsoft.Json;

namespace StreamTask
{
    internal class Program
    {
        const string file_path = @"C:\Users\Ali\source\repos\StreamTask\StreamTask\Files\Names.json";
        static void Main(string[] args)
        {


            //Add("Nihad");
            //Console.WriteLine(Search("Kamil"));
            Delete(0);
        }

        public static void Add(string name)
        {
            List<string> names = new List<string>();

            if (File.Exists(file_path))
            {
                string text = File.ReadAllText(file_path);
                names = JsonConvert.DeserializeObject<List<string>>(text);
            }

            if (!names.Contains(name))
            {
                names.Add(name);
                Console.WriteLine("Add olundu");
            }
            else
            {
                Console.WriteLine("Movcuddur");
            }

            string updatedText = JsonConvert.SerializeObject(names);
            File.WriteAllText(file_path, updatedText);
        }

        public static bool Search(string name)
        {
            if (!File.Exists(file_path))
            {
                return false;
            }

            string text = File.ReadAllText(file_path) ;
            List<string> names = JsonConvert.DeserializeObject<List<string>>(text);

            Predicate<string> predicate = x => x.Equals(name);
            return names.Exists(predicate);
        }


        public static void Delete(int index)
        {
            if (!File.Exists(file_path))
            {
                Console.WriteLine("Json fayli movcud deyil");
                return;
            }

            string text = File.ReadAllText(file_path);
            List<string> names = JsonConvert.DeserializeObject<List<string>>(text);

            if (names.Count == 0)
            {
                Console.WriteLine("Json fayli boshdur.");
                return;
            }

            if (index < 0 || index >= names.Count)
            {
                Console.WriteLine("Index out of range");
                return;
            }

            Console.WriteLine($"{names[index]} siyahidan silindi");
            names.RemoveAt(index);

            string updatedJson = JsonConvert.SerializeObject(names);
            File.WriteAllText(file_path, updatedJson);

        }

    }
}
/*StreamWriter, StreamReader, Serialize, Deserialize
Program cs de ashagidaki methodlari yazirsiz:

void Add(string name) - names.json file-sinde datalari cekib deserialize edirsiz(List<string>)  Liste gonderilen deyeri elave edib yeniden serialize edib names.json-a gonderirsiz

bool Search(stiring name) - names.json file-sinde datalari cekib deserialize edirsiz(List<string>)  Listde gonderilen deyer movcuddursa true, deyilse false qaytaran method(Predicate istifade edin)

void Delete(int index) - names.json file-sinde datalari cekib deserialize edirsiz(List<string>)  Listden gonderilen deyeri silib yeniden serialize edib names.json-a gonderirsiz.*/