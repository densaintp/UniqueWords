using System.Text;

class Program
{
	static void Main()
	{
		Console.WriteLine("Укажите путь к txt-файлу: ");
		string filePath = Console.ReadLine();

		if (File.Exists(filePath))
		{
			// Читаем файл построчно
			var readTextFile = new StreamReader(filePath);
			int rowsCounter = 0;
			int wordsCounter = 1;

			var dict = new Dictionary<string, int>();

			while (!readTextFile.EndOfStream)
			{
				string[] line = readTextFile.ReadLine().ToLower().Split(" ,.[]--{}?!\'()\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				rowsCounter++;
				foreach (var word in line)
				{
					if (!dict.ContainsKey(word))
						dict.Add(word, wordsCounter);
					else
						dict[word]++;
				}
			}

			var result = dict.OrderByDescending(x => x.Value);

			if (readTextFile.EndOfStream)
			{
				Console.WriteLine("Введите место сохранения файла");
				string path = Console.ReadLine() + @"\test.txt";
				FileStream file = new FileStream(path, FileMode.Append);
				StreamWriter fnew = new StreamWriter(file, Encoding.UTF8);
				rowsCounter++;
				foreach (var keyValuePair in result)
				{
					fnew.WriteLine("Слово {0} встречается {1} раз", keyValuePair.Key, keyValuePair.Value);
				}
			}
		}

		else
		{
			Console.WriteLine("По данному пути ничего не найдено");
		}

		Console.WriteLine("Нажмите на любую кнопку для выхода...");
		Console.ReadKey(true);
	}

}

