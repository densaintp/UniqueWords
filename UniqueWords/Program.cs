class Program
{
	static void Main()
	{
		Console.WriteLine("Укажите путь сохранения txt-файла: ");
		string filePath = Console.ReadLine();	

		if (File.Exists(filePath))
		{
			// Читаем файл построчно
			var textFile = new StreamReader(filePath);
			int rowsCounter = 0;
			int wordsCounter = 1;

			var dict = new Dictionary<string, int>();

			while (!textFile.EndOfStream)
			{
				string[] line = textFile.ReadLine().ToLower().Split(" ,.?!\'()\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries); 
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

			foreach (var keyValuePair in result)
			{
				Console.WriteLine("Слово {0} встречается {1} раз", keyValuePair.Key, keyValuePair.Value);
			}
		}
		else
		{
			Console.WriteLine("По данному пути ничего не найдено");
		}
	}
}

